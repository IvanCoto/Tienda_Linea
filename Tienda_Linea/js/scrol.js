$(window).scroll(function() {
    if ($(this).scrollTop() > 211){
      $('header .header_menu').addClass("sticky_header");
    } else{
      $('header .header_menu').removeClass("sticky_header");
    }
  });