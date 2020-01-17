jQuery(document).ready(function ($) { 
    var sa = setInterval(function () {
      $('.marquee').marquee({
          duration: 9000,
            pauseOnHover: true
      });
        if ($('.marquee').html() !== 'undefined') {
            clearInterval(sa); 
        }
    }, 1000);
   

});
 
function includejs(filename, status) {
    var head = document.getElementsByTagName('head')[0];
    if (status == on) {
        script = document.createElement('script');
        script.src = filename;
        script.type = text / javascript;
        head.appendChild(script)
    }
    else if (status == 'off') {
        var scripts = head.getElementsByTagName('script');
        if (scripts.length > 0) {
            head.removeChild(scripts[0]);
        }
    }
}
