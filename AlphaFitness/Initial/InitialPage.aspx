<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="InitialPage.aspx.cs" Inherits="AlphaFitness.Initial.InitialPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

    <meta charset="UTF-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <link href="../Style/reset.css" rel="stylesheet" />
    <link href="InitialPage.css" rel="stylesheet" />

    <!-- Boxicons CDN Link -->
    <link href='https://unpkg.com/boxicons@2.0.7/css/boxicons.min.css' rel='stylesheet' />
    <link rel="stylesheet" href="//cdnjs.cloudflare.com/ajax/libs/bootstrap-select/1.7.5/css/bootstrap-select.min.css" />
    <script src="//cdnjs.cloudflare.com/ajax/libs/bootstrap-select/1.12.4/js/bootstrap-select.min.js"></script>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.6.3/jquery.min.js"></script>
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/6.0.0-beta2/css/all.min.css"
        integrity="sha512-YWzhKL2whUzgiheMoBFwW8CKV4qpHQAEuvilg9FAn5VJUDwKZZxkJNuGM4XkWuk94WCrrwslk8yWNGmY1EduTA=="
        crossorigin="anonymous" referrerpolicy="no-referrer" />
    <script src="https://cdnjs.cloudflare.com/ajax/libs/lodash.js/3.10.1/lodash.min.js"></script>
    <script src="https://code.jquery.com/jquery-2.1.4.min.js"></script>

    <title>Alpha Fitness | A Life On the Palm of Hand</title>

    <link rel="icon" type="image/x-icon" href="../Image/Element/web-icon.jpg" />
</head>
<body>

    <form id="form1" runat="server">
        <div class="container">
            <!--The Main-->
            <section class="background">
                <div class="header">
                    <asp:Image runat="server" CssClass="image" ImageUrl="~/Image/Element/rmbg-logo1.png" />
                </div>
                <div class="content-wrapper">
                    <p class="content-title css-typing"></p>
                    <p class="content-subtitle">Welcome to Alpha Fitness, your ultimate companion on the path to a healthier, stronger you, offering tailored workouts and expert guidance at your fingertips.</p>
                    <div class="btns">
                        <asp:Button runat="server" OnClientClick="window.location.href = '../User/UserLogin.aspx#login'; return false;" ID="btnLogin" CssClass="btn" Text="Login Now" />
                        <asp:Button runat="server" OnClientClick="window.location.href = '../User/UserLogin.aspx#register'; return false;" ID="btnRegister" CssClass="btn" Text="Register Now" />
                    </div>
<%--                    <div class="moveBtn-ctn">
                        <button id="nextOne" onclick="toNext(); return false;" class="moveBtn">
                            <i class='bx bx-down-arrow-alt' ></i>
                        </button>
                    </div>--%>
                </div>
            </section>
            <!--The Description-->
            <section class="background">
                <div class="content-wrapper">
                    <p class="content-title">Do You Know?</p>
                    <p class="content-subtitle">
                        Regular workouts not only improve physical health but also boost mental well-being. They enhance cardiovascular health, reduce stress, and promote a positive mindset. Exercise contributes to muscle strength, flexibility, and a robust immune system, reducing the risk of chronic illnesses. The discipline fosters self-esteem and confidence while improving sleep, increasing energy levels, and enhancing cognitive function. In essence, fitness is a holistic approach to a balanced and vibrant life.
                    </p>
                </div>
            </section>
            <!--The Description-->
            <section class="background">
                <div class="content-wrapper">
                    <p class="content-title">Why Consider Us?</p>
                    <p class="content-subtitle">
                        Join our program for a transformative fitness journey tailored to your goals. Experience personalized workouts, a supportive community, and expert guidance. Achieve not only physical gains like strength and flexibility but also reduced stress, elevated mood, and increased self-esteem. Our comprehensive approach includes nutrition and lifestyle tips for optimal well-being. Embrace a fitness journey that goes beyond the physical, contributing to a balanced and empowered lifestyle.
                    </p>
                </div>
            </section>
            <!--The Description-->
            <section class="background">
                <div class="content-wrapper">
                    <p class="content-title">
                        Still considering? Don't miss out on the chance to improve!
                    </p>
                    <p class="content-subtitle">Join our program now for a transformative fitness experience tailored to your goals.</p>
                    <div class="btns">
                        <asp:Button runat="server" OnClientClick="window.location.href = '../User/UserLogin.aspx#login'; return false;" ID="Button1" CssClass="btn" Text="Login Now" />
                        <asp:Button runat="server" OnClientClick="window.location.href = '../User/UserLogin.aspx#register'; return false;" ID="Button2" CssClass="btn" Text="Register Now" />
                    </div>
                </div>
            </section>
        </div>


    </form>

</body>

<script type="text/javascript">

    // ------------- VARIABLES ------------- //
    var ticking = false;
    var isFirefox = (/Firefox/i.test(navigator.userAgent));
    var isIe = (/MSIE/i.test(navigator.userAgent)) || (/Trident.*rv\:11\./i.test(navigator.userAgent));
    var scrollSensitivitySetting = 30; //Increase/decrease this number to change sensitivity to trackpad gestures (up = less sensitive; down = more sensitive) 
    var slideDurationSetting = 600; //Amount of time for which slide is "locked"
    var currentSlideNumber = 0;
    var totalSlideNumber = $(".background").length;
    var nextOne = document.getElementById("nextOne");

    // ------------- DETERMINE DELTA/SCROLL DIRECTION ------------- //
    function parallaxScroll(evt) {
        if (isFirefox) {
            //Set delta for Firefox
            delta = evt.detail * (-120);
        } else if (isIe) {
            //Set delta for IE
            delta = -evt.deltaY;
        } else {
            //Set delta for all other browsers
            delta = evt.wheelDelta;
        }

        if (ticking != true) {
            if (delta <= -scrollSensitivitySetting) {
                //Down scroll
                ticking = true;
                if (currentSlideNumber !== totalSlideNumber - 1) {
                    currentSlideNumber++;
                    nextItem();
                }
                slideDurationTimeout(slideDurationSetting);
            }
            if (delta >= scrollSensitivitySetting) {
                //Up scroll
                ticking = true;
                if (currentSlideNumber !== 0) {
                    currentSlideNumber--;
                }
                previousItem();
                slideDurationTimeout(slideDurationSetting);
            }
        }
    }

    // ------------- SET TIMEOUT TO TEMPORARILY "LOCK" SLIDES ------------- //
    function slideDurationTimeout(slideDuration) {
        setTimeout(function () {
            ticking = false;
        }, slideDuration);
    }

    // ------------- ADD EVENT LISTENER ------------- //
    var mousewheelEvent = isFirefox ? "DOMMouseScroll" : "wheel";
    window.addEventListener(mousewheelEvent, _.throttle(parallaxScroll, 60), false);

    // ------------- SLIDE MOTION ------------- //
    function nextItem() {
        var $previousSlide = $(".background").eq(currentSlideNumber - 1);
        $previousSlide.removeClass("up-scroll").addClass("down-scroll");
    }

    function previousItem() {
        var $currentSlide = $(".background").eq(currentSlideNumber);
        $currentSlide.removeClass("down-scroll").addClass("up-scroll");
    }


    //Typewriter

    var title = "Elevate Your Fitness Journey, Transform Your Life, A Life on Your Palm of Hand."
    var spans = '<span>' + title.split('').join('</span><span>') + '</span>';
    $(spans).hide().appendTo('.css-typing').each(function (i) {
        $(this).delay(50 * i).css({
            display: 'inline',
            opacity: 0
        }).animate({
            opacity: 1
        }, 100);
    });

</script>

</html>
