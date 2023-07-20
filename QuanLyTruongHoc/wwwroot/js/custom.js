
/*=============================================================
    Authour URI: www.binarytheme.com
    License: Commons Attribution 3.0

    http://creativecommons.org/licenses/by/3.0/

    100% To use For Personal And Commercial Use.
    IN EXCHANGE JUST GIVE US CREDITS AND TELL YOUR FRIENDS ABOUT US
   
    ========================================================  */


(function ($) {
    "use strict";
    var mainApp = {

        metisMenu: function () {

            /*====================================
            METIS MENU 
            ======================================*/

            $('#main-menu').metisMenu();

        },


        loadMenu: function () {

            /*====================================
            LOAD APPROPRIATE MENU BAR
         ======================================*/

            $(window).bind("load resize", function () {
                if ($(this).width() < 768) {
                    $('div.sidebar-collapse').addClass('collapse')
                } else {
                    $('div.sidebar-collapse').removeClass('collapse')
                }
            });
        },
        slide_show: function () {

            /*====================================
           SLIDESHOW SCRIPTS
        ======================================*/

            $('#carousel-example').carousel({
                interval: 3000 // THIS TIME IS IN MILLI SECONDS
            })
        },
        reviews_fun: function () {
            /*====================================
         REWIEW SLIDE SCRIPTS
      ======================================*/
            $('#reviews').carousel({
                interval: 2000 //TIME IN MILLI SECONDS
            })
        },
        wizard_fun: function () {
            /*====================================
            //horizontal wizrd code section
             ======================================*/
            $(function () {
                $("#wizard").steps({
                    headerTag: "h2",
                    bodyTag: "section",
                    transitionEffect: "slideLeft"
                });
            });
            /*====================================
            //vertical wizrd  code section
            ======================================*/
            $(function () {
                $("#wizardV").steps({
                    headerTag: "h2",
                    bodyTag: "section",
                    transitionEffect: "slideLeft",
                    stepsOrientation: "vertical"
                });
            });
        },
       
        
    };
    $(document).ready(function () {
        mainApp.metisMenu();
        mainApp.loadMenu();
        mainApp.slide_show();
        mainApp.reviews_fun();
        mainApp.wizard_fun();
       
    });

    $(document).on("change", ".subject", function () {
        var id = $(this).val();
        var url = "/Teacher/getListGiaoVienByIdMonHoc/" + id;
        var target = $(this).parent("div").parent("div").find(".teacher");
        let ssCallBack = function (rs) {
            jQuery(target).html('');
            jQuery(target).html(rs);
        };
        $.ajax({
            url: url,
            type: 'GET',
            dataType: 'text',
        }).done(function (rs) {
            ssCallBack(rs);
        });
    })

    $(document).on("click", ".chamDiemBtn", function () {
        var id = $(this).attr('id');
        console.log(1);
        $(".chamThi").each(function (obj) {
            $(this).fadeOut("fast", function () { 
                $(this).css("display", "none");
            }) 
        });
        $(".kiThi-" + id).css("display", "").delay(200);
        $(".kiThi-" + id).hide().fadeIn("fast", function () { 
            console.log(1);
        })
    })

    $(document).on("change", "#doiTuongMuon1", function () {
        var isHsChecked = $("#doiTuongMuon1").is(":checked");
        var isGvChecked = $("#doiTuongMuon2").is(":checked");
        console.log(isHsChecked);
        console.log(isGvChecked);
        if (isHsChecked) {
            var url = "/Class/RenderClassAsOption";
            var target = $(this).parent("div").parent("div").find("#class");
            var target2 = $(this).parent("div").parent("div").find("#person");
            let ssCallBack = function (rs) {
                jQuery(target).html('');
                jQuery(target2).html('');
                jQuery(target).html(rs);
                jQuery(target).prop('disabled', false);
                jQuery(target2).prop('disabled', true);
            };
            $.ajax({
                url: url,
                method: 'GET',
                dataType: 'text'
            }).done(function (rs) {
                ssCallBack(rs);
            });
        }
        if (isGvChecked) {
            var url = "/Teacher/RenderTeacherAsOption";
            var target = $(this).parent("div").parent("div").find("#class");
            var target2 = $(this).parent("div").parent("div").find("#person");
            let ssCallBack = function (rs) {   
                console.log(rs);
                jQuery(target).html('');
                jQuery(target2).html('');
                jQuery(target2).html(rs);
            };
            $.ajax({
                url: url,
                method: 'GET',
                dataType: 'text'
            }).done(function (rs) {
                ssCallBack(rs);
            });
        };
    })
    $(document).on("change", "#doiTuongMuon2", function () {
        var isGvChecked = $("#doiTuongMuon2").is(":checked");
        console.log(isGvChecked);
        if (isGvChecked) {
            var url = "/Teacher/RenderTeacherAsOption";
            var target = $(this).parent("div").parent("div").find("#class");
            var target2 = $(this).parent("div").parent("div").find("#person");
            let ssCallBack = function (rs) {
                console.log(rs);
                jQuery(target).html('');
                jQuery(target).prop('disabled', true);
                jQuery(target2).html('');
                jQuery(target2).html(rs);
                jQuery(target2).prop('disabled', false);
            };
            $.ajax({
                url: url,
                method: 'GET',
                dataType: 'text'
            }).done(function (rs) {
                ssCallBack(rs);
            });
        };
    })

    $(document).on("change", "#class", function () {
        var isHsChecked = $("#doiTuongMuon1").is(":checked");
        var id = $(this).val();
        console.log(id);
        if (isHsChecked) {
            var url = "/Student/RenderStudentAsOption/?id=" + id;
            var target = $(this).parent("div").parent("div").find("#class");
            var target2 = $(this).parent("div").parent("div").find("#person");
            let ssCallBack = function (rs) {
                console.log(rs);
                jQuery(target).prop('disabled', false);
                jQuery(target2).html(rs);
                jQuery(target2).prop('disabled', false);
            };
            $.ajax({
                url: url,
                method: 'GET',
                dataType: 'text'
            }).done(function (rs) {
                ssCallBack(rs);
            });
        };
    })

    $(document).on("change", ".allClassCheck", function () {
        var isCheck = $(this).is(":checked");
        if (isCheck) {
            $(this).parent().parent().find(".form-check-input").prop('checked', true);
        } else {
            $(this).parent().parent().find(".form-check-input").prop('checked', false);
        }
    })
}(jQuery));