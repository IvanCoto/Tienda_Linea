$(document).ready(function(){
    $('#category_block').owlCarousel({	
            items: 6,
            itemsDesktop:[1199,5],
            itemsDesktopSmall:[992,4],
            itemsTablet:[768,3],
            itemsMobile:[550,2],
            autoPlay: 6000,
            pagination: false,
            navigation: true,
            navigationText: ['<i class="fa fa-angle-left fa-5x"></i>', '<i class="fa fa-angle-right fa-5x"></i>']
        });
    });