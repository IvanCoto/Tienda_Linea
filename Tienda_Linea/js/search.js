$(document).ready(function(){
    $('.ebsearch').on('click', function(event) { 
        $('#search').addClass('open');
        $('#search > form > input[type="search"]').focus();
    });            
    $('#search, #search button.close').on('click keyup', function(event) {
        if (event.target == this || event.target.className == 'close' || event.keyCode == 27) {
            $(this).removeClass('open');
        }
    });            
});

$('#slideshow0').swiper({
	mode: 'horizontal',
	slidesPerView: 1,
	pagination: '.slideshow0',
	paginationClickable: true,
	nextButton: '.swiper-button-next',
    prevButton: '.swiper-button-prev',
    spaceBetween: 30,
	autoplay: 6000,
    autoplayDisableOnInteraction: true,
	loop: true
});