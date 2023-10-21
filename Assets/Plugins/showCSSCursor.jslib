mergeInto(LibraryManager.library, {
    showCSSCursor: function()
    {
        document.getElementById("unity-canvas").style.cursor = 'url("./cursor.png") 24 24, auto';
    },
    hideCSSCursor: function()
    {
        document.getElementById("unity-canvas").style.cursor = 'none';
    },
});