<%@ Page Title="" Language="C#" MasterPageFile="~/Contents.Master" AutoEventWireup="true" CodeBehind="Tutorial.aspx.cs" Inherits="AlphaFitness.Tutorial.Tutorial" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="https://slidesigma.com/themes/html/joblify/assets/css/bootstrap.min.css" rel="stylesheet">
     
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css">
     
     <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/line-awesome/1.3.0/line-awesome/css/line-awesome.min.css">
    
     <link href="https://fonts.googleapis.com/css?family=Poppins:300,400,500,600,700&display=swap" rel="stylesheet">


      <link href="https://fonts.googleapis.com/css?family=Rubik:400,500,700,900&display=swap" rel="stylesheet">
    <style>
        .home-section .home-content {
            position: relative;
            padding-top: 32px;
        }

        .img-icon {
            width:50%;
            margin: auto auto;
        }

        .section-padding {
            padding: 80px 0;
        }

        .jb-profile-slider-2 {
            background-color: #262629;
        }

        body {
            position: relative;
            font-family: 'Poppins', sans-serif !important;
            margin: 0px;
            padding: 0px;
            font-size: 14px !important;
            line-height: 28px !important;
            overflow-x: hidden;
            font-weight: 400 !important;
            color: #555b62;
            left: 0;
            background-color: #1a191f;
            transition: 0.3s;
        }

        .section-title {
            max-width: 100% !important;
            color: #fff;
            padding-bottom: 28px !important;
            text-align: left;
            font-weight: 400 !important;
            margin-bottom: 0 !important;
        }

        h1, h2, h3, h4, h5, h6 {
            color: #fff;
            margin: 0 auto 5px !important;
            font-family: 'Rubik', sans-serif !important;
            font-weight: 500 !important;
            width: 100% !important;
            word-break: break-word;
            line-height: 1.4;
        }

        h2 {
            font-size: 36px !important;
        }

        h4 {
            text-align:center;
            padding-top:15px;
            font-size: 24px !important;
        }

        .Categories-boxes-container {
            width: calc(100% + 20px);
            left: -20px;
            top: -10px;
            position: relative;
            display: flex;
            flex-wrap: wrap;
        }

        a {
            -webkit-transition: 0.3s;
            transition: 0.3s;
            text-decoration: none;
            font-weight: normal;
            color: #000;
            cursor: pointer;
            font-family: 'Poppins', sans-serif !important;
            word-break: break-word !important;
        }

        .category-box {
            width: calc(100% * (1/4) - 20px);
            background-color: rgba(210,201,255,0.04);
            border-radius: 6px;
            margin: 20px 0 0 20px;
            padding: 20px;
            text-align: left;
            color: #fff;
            transition: .4s;
            transform: scale(1);
            vertical-align: top;
            position: relative;
            display: flex;
            flex-direction: column;
            justify-content: center;
            min-height: 124px;
            overflow: hidden;
            border: 3px solid transparent;
        }

            .category-box i {
                color: #ffd80e;
                font-size: 40px;
                height: 42px;
                transition: .4s;
                display: inline-block;
            }

            .category-box h4 {
                font-size: 15px !important;
                color: #fff;
                transition: .4s;
                line-height: 22px !important;
                margin-top: 10px !important;
            }

            .category-box span {
                font-size: 13px;
                color: #fff;
                border-radius: 3px;
                background-color: rgba(0, 0, 0, 0.44);
                display: block;
                width: 40px;
                text-align: center;
                transition: .4s;
            }

        a:hover, a:focus {
            text-decoration: none !important;
            outline: none;
            color: #ff8400;
        }

        .category-box:hover {
            border: 3px solid #ffd80e;
            transform: scale(1.06);
        }


        /* media query */
        @media only screen and (max-width: 990px) and (min-width: 768px) {
            .category-box {
                width: calc(100% * (1/3) - 20px);
            }
        }

        @media only screen and (max-width: 767px) and (min-width: 480px) {
            .category-box {
                width: calc(100% * (1/2) - 20px);
            }
        }

        @media (max-width: 480px) {
            .category-box {
                width: 100%;
            }
        }
    </style>

    <div class="home-content">
        <section class="jb-profile-slider-2 section-padding">
            <div class="container">
                <div class="row">
                    <div class="col-12">
                        <div class="section-title-wrapper">
                            <h2 class="section-title">Popular Categories</h2>
                            <h6 class="section-title"><i class="bx bx-run"></i> &nbsp;Take a peek inside our fitness world</h6>
                        </div>
                    </div>
                    <div class="col-12">
                        <div class="Categories-boxes-container">
                            <a href="#" class="category-box">
                                <asp:Image ID="Image1" runat="server" cssClass="img-icon" ImageUrl="~/Image/Element/cardio-session-icon.png"/>
                                <h4>Cardio Session</h4>
                            </a>
                            <a href="#" class="category-box">
                                <asp:Image ID="Image2" runat="server" cssClass="img-icon" ImageUrl="~/Image/Element/weight-icon.png"/>
                                <h4>Weight Loss Training</h4>
                            </a>
                            <a href="#" class="category-box">
                                <asp:Image ID="Image3" runat="server" cssClass="img-icon" ImageUrl="~/Image/Element/boxing-icon.png"/>
                                <h4>Kick Boxing</h4>
                            </a>
                            <a href="#" class="category-box">
                                <asp:Image ID="Image4" runat="server" cssClass="img-icon" ImageUrl="~/Image/Element/supersets-icon.png"/>
                                <h4>Supersets</h4>
                            </a>
                            <a href="#" class="category-box">
                                <asp:Image ID="Image5" runat="server" cssClass="img-icon" ImageUrl="~/Image/Element/yoga-icon.png"/>
                                <h4>Yoga & Stretching</h4>
                            </a>
                            <a href="#" class="category-box">
                                <asp:Image ID="Image6" runat="server" cssClass="img-icon" ImageUrl="~/Image/Element/functional-training-icon.png"/>
                                <h4>Functional Training</h4>
                            </a>
                            <a href="#" class="category-box">
                                <asp:Image ID="Image7" runat="server" cssClass="img-icon" ImageUrl="~/Image/Element/dumbbell-icon.png"/>
                                <h4>Dumbbell</h4>
                            </a>
                            <a href="#" class="category-box">
                                <asp:Image ID="Image8" runat="server" cssClass="img-icon" ImageUrl="~/Image/Element/bodybuilding-icon.png"/>
                                <h4>Bodybuilding</h4>
                            </a>
                        </div>
                    </div>
                </div>
            </div>
        </section>
    </div>

    <script>
        $(document).ready(function () {
            // set up hover panels
            // although this can be done without JavaScript, we've attached these events
            // because it causes the hover to be triggered when the element is tapped on a touch device
            $('.hover').hover(function () {
                $(this).addClass('flip');
            }, function () {
                $(this).removeClass('flip');
            });
        });
    </script>
    <script src="https://slidesigma.com/themes/html/joblify/assets/js/jquery.min.js"></script>
    <!-- Popper -->
    <script src="https://slidesigma.com/themes/html/joblify/assets/js/popper.min.js"></script>
    <!-- Bootstrap -->
    <script src="https://slidesigma.com/themes/html/joblify/assets/js/bootstrap.min.js"></script>
</asp:Content>
