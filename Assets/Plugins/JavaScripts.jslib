mergeInto(LibraryManager.library, {
OpenURL : function(link){
	var url = UTF8ToString(link);
	document.onmouseup = function(){
	window.open(url);
	document.onmouseup = null;
	}
},

CopyToClipboard : function(strinput){
    var str = UTF8ToString(strinput);
	document.onmouseup = function(){
		const el = document.createElement('textarea');
		el.value = str;
		document.body.appendChild(el);
		el.select();
		document.execCommand('copy');
		document.body.removeChild(el);
	}	
}
});
