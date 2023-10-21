

var audio = new Audio();
audio.loop = false;
let unityInstanceSound;


function onDrop(ev) {
	console.log("File(s) dropped");

	// Prevent default behavior (Prevent file from being opened)
	ev.preventDefault();

	if (ev.dataTransfer.items) {
		// Use DataTransferItemList interface to access the file(s)
		[...ev.dataTransfer.items].forEach((item, i) => {
		// If dropped items aren't files, reject them
		if (item.kind === "file") {
			const file = item.getAsFile();
			console.log(`… file[${i}].name = ${file.name}`);
			if (file.name.endsWith(".osz")) {
				unityInstanceSound.SendMessage('SoundSystem', 'DownloadSong', URL.createObjectURL(file) + "kosu!seperateArgsHere📂📂📂📂" + file.name);
			}
			
		}
		});
	} else {
		// Use DataTransfer interface to access the file(s)
		[...ev.dataTransfer.files].forEach((file, i) => {
		console.log(`… file[${i}].name = ${file.name}`);
		if (file.name.endsWith(".osz")) {
			unityInstanceSound.SendMessage('SoundSystem', 'DownloadSong', URL.createObjectURL(file) + "kosu!seperateArgsHere📂📂📂📂" + file.name);
		}
		});
	}
}

function dragOverHandler(ev) {
	console.log("File(s) in drop zone");

	// Prevent default behavior (Prevent file from being opened)
	ev.preventDefault();
}


function audioPlay(base64audioData){
    //console.log(base64audioData)
    //let src = "data:audio/mpeg;base64,"+base64audioData;


	//audio.src = src;
    //audio.play();
}

function audioPause(){
    //audio.pause();
}

function audioUnPause(){
    //audio.play();
}

function audioSetTime(time){
	//audio.currentTime = time;
}

function audioMakeBlob(base64audioData, time, parentObjectName, isSongSelect){
	let xhr = new XMLHttpRequest();
	xhr.open("GET", "data:audio/mpeg;base64,"+base64audioData, true);
	xhr.responseType = 'blob';
	xhr.onload = function() {
		const bloblURL = URL.createObjectURL(xhr.response);
		console.log("Audio Blob URL:", bloblURL);
		console.log(parentObjectName);
		console.log(time);
		if (isSongSelect){
			unityInstanceSound.SendMessage('SongSelectCarousel', 'playAndDownloadAudio', bloblURL);
		}
		else {
			unityInstanceSound.SendMessage('SongLoader', 'playAndDownloadAudio', bloblURL);
		}
		
	}
	xhr.onerror = function() {
		alert("Failed to load audio! See more in devtools console.");
	}
	xhr.send();
}



/*
WebGLInject - Part of Simple Spectrum V2.1 by Sam Boyer.
*/

window.SimpleSpectrum = {};

window.AudioContext = (function(){
	var ACConsructor = window.AudioContext || window.webkitAudioContext; //keep a reference to the original function
	
	//console.log('AudioContext Constructor overriden');
		
	return function(){
		var ac = new ACConsructor();

		//console.log('AudioContext constructed');
		
		window.SimpleSpectrum.ac = ac;

		window.SimpleSpectrum.a = ac.createAnalyser();
		window.SimpleSpectrum.a.smoothingTimeConstant = 0;
			
		window.SimpleSpectrum.fa = new Uint8Array(window.SimpleSpectrum.a.frequencyBinCount); //frequency array, size of frequencyBinCount
			
		window.SimpleSpectrum.la = new Uint8Array(window.SimpleSpectrum.a.fftSize); //loudness array, size of fftSize
			
		window.SimpleSpectrum.a.connect(ac.destination); //connect the AnalyserNode to the AudioContext's destination.
			
		ac.actualDestination = ac.destination; //keep a reference to the destination.
			
		Object.defineProperty(ac, 'destination', { //replace ac.destination with our AnalyserNode.
			value: window.SimpleSpectrum.a,
			writable: false
		});		
			
		return ac; //send our modified AudioContext back to Unity.
	}
})();

// end of simpleSpectrum