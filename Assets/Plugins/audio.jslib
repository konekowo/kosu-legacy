mergeInto(LibraryManager.library, {
    audioPlay: function(base64audioData)
    {
        audioPlay(UTF8ToString(base64audioData));
    },
    audioPause: function()
    {
        audioPause();
    },
    audioUnPause: function()
    {
        audioUnPause();
    },
    audioSetTime: function(time)
    {
        audioSetTime(time);
    },
    audioMakeBlob: function(base64audioData, time, parentObjectName, isSongSelect)
    {
        audioMakeBlob(UTF8ToString(base64audioData), time, UTF8ToString(parentObjectName), isSongSelect);
    },
    JSAlert: function(message)
    {
        alert(UTF8ToString(message));
    }
    
});