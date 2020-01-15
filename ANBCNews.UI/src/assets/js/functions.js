jQuery(document).ready(function ($) { 
    var sa = setInterval(function () {
      $('.marquee').marquee({
          duration: 9000,
            pauseOnHover: true
        }); clearInterval(sa); }, 1000);
    
});
 
