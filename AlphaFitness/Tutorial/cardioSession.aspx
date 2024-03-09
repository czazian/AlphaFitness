<%@ Page Title="" Language="C#" MasterPageFile="~/Contents.Master" AutoEventWireup="true" CodeBehind="cardioSession.aspx.cs" Inherits="AlphaFitness.Tutorial.cardioSession" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="TutorialCategory.css" rel="stylesheet" />
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css">
<link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/line-awesome/1.3.0/line-awesome/css/line-awesome.min.css">
<link href="https://fonts.googleapis.com/css?family=Poppins:300,400,500,600,700&display=swap" rel="stylesheet">
<link href="https://fonts.googleapis.com/css?family=Rubik:400,500,700,900&display=swap" rel="stylesheet">
    <style>
        .img-icon {
            padding-bottom:10px;
        }

        /*Click this back to top*/
        .toTop {
            position: fixed;
            bottom: 15px;
            right: 15px;
            display: none;
        }

        .section-title {
            letter-spacing:1px;
            padding-top:5px;
            padding-bottom:10px !important;
        }

        #header {
            padding-left: 40px !important;
            line-height: 0.8 !important;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="home-content">
        <h1 id="header">Cardio Session</h1>
        <div class="intro-box">
            <h6>Improving your cardio will strengthen your stamina and endurance so you can work harder for long and burn more calories.</h6>
        </div>
        <div class="subtitle-link">
            <a href="cardioSession.aspx#tips-category">TIPS</a>
            <a href="cardioSession.aspx#articles-category">ARTICLES</a>
            <a href="cardioSession.aspx#sbsguide-category">STEP-BY-STEP GUIDE</a>
            <a href="cardioSession.aspx#exercisev-category">EXERCISE VIDEOS</a>
        </div>
        <div class="content-frame">
            <%--category 1--%>
            <div class="container">
                <div id="tips-category" class="row">
                    <div class="col-10">
                        <div class="section-title-wrapper">
                            <h2 class="section-title">TIPS:</h2>
                        </div>
                    </div>
                    <div class="col-10">
                        <div class="Categories-boxes-container">
                            <a href="#" class="category-box">
                                <asp:Image ID="Image1" runat="server" CssClass="img-icon" ImageUrl="~/Image/Element/c1.png" />
                                <h5>WORKOUT TIPS</h5>
                                <h3>WEIGHT TRAINING METHODS FOR BASEBALL PLAYERS</h3>
                                <h4>Three experts explain how bigger, faster, and stronger can translate to better...</h4>
                                <h6>Read Article</h6>
                            </a>
                            <a href="#" class="category-box">
                                <asp:Image ID="Image2" runat="server" CssClass="img-icon" ImageUrl="~/Image/Element/c2.png" />
                                <h5>WORKOUT TIPS</h5>
                                <h3>SORTING OUT THE TRUTHS AND MYTHS OF STRETCHING</h3>
                                <h4>We're not saying stretching is bad for you, but how much do you really benefit from...</h4>
                                <h6>Read Article</h6>
                            </a>
                            <a href="#" class="category-box">
                                <asp:Image ID="Image3" runat="server" CssClass="img-icon" ImageUrl="~/Image/Element/c3.png" />
                                <h5>WORKOUT TIPS</h5>
                                <h3>BEST WAYS YOU CAN TRAIN FOR POWER AT HOME</h3>
                                <h4>With these practical training tips, it's possible to make elite-level power gains...</h4>
                                <h6>Read Article</h6>
                            </a>
                            <a href="#" class="category-box">
                                <asp:Image ID="Image4" runat="server" CssClass="img-icon" ImageUrl="~/Image/Element/c4.png" />
                                <h5>WORKOUT TIPS</h5>
                                <h3>Start Slowly and Progress Gradually</h3>
                                <h4>If you're new to exercise or returning after a break, start with low-intensity workouts and gradually increase....</h4>
                                <h6>Read Article</h6>
                            </a>

                        </div>
                    </div>
                </div>
            </div>
            <%--category 2--%>
            <div class="container">
                <div id="articles-category" class="row">
                    <div class="col-10">
                        <div class="section-title-wrapper">
                            <h2 class="section-title">ARTICLES:</h2>
                        </div>
                    </div>
                    <div class="col-10">
                        <div class="Categories-boxes-container">
                            <a href="#" class="category-box">
                                <asp:Image ID="Image5" runat="server" CssClass="img-icon" ImageUrl="~/Image/Element/cardio-session-icon.png" />
                                <h5>WORKOUT TIPS</h5>
                                <h3>ALL-STAR WEIGHT TRAINING METHODS FOR BASEBALL PLAYERS</h3>
                                <h4>Three experts explain how bigger, faster, and stronger can translate to better...</h4>
                                <h6>Read Article</h6>
                            </a>
                            <a href="#" class="category-box">
                                <asp:Image ID="Image6" runat="server" CssClass="img-icon" ImageUrl="~/Image/Element/weight-icon.png" />
                                <h5>WORKOUT TIPS</h5>
                                <h3>SORTING OUT THE TRUTHS AND MYTHS OF STRETCHING</h3>
                                <h4>We're not saying stretching is bad for you, but how much do you really benefit from...</h4>
                                <h6>Read Article</h6>
                            </a>
                            <a href="#" class="category-box">
                                <asp:Image ID="Image7" runat="server" CssClass="img-icon" ImageUrl="~/Image/Element/boxing-icon.png" />
                                <h5>WORKOUT TIPS</h5>
                                <h3>BEST WAYS YOU CAN TRAIN FOR POWER AT HOME</h3>
                                <h4>With these practical training tips, it's possible to make elite-level power gains...</h4>
                                <h6>Read Article</h6>
                            </a>
                            <a href="#" class="category-box">
                                <asp:Image ID="Image8" runat="server" CssClass="img-icon" ImageUrl="~/Image/Element/supersets-icon.png" />
                                <h5>WORKOUT TIPS</h5>
                                <h3>Start Slowly and Progress Gradually</h3>
                                <h4>If you're new to exercise or returning after a break, start with low-intensity workouts and gradually increase....</h4>
                                <h6>Read Article</h6>
                            </a>

                        </div>
                    </div>
                </div>
            </div>
            <%--category 3--%>
            <div class="container">
                <div id="sbsguide-category" class="row">
                    <div class="col-10">
                        <div class="section-title-wrapper">
                            <h2 class="section-title">STEP-BY-STEP GUIDES:</h2>
                        </div>
                    </div>
                    <div class="col-10">
                        <div class="Categories-boxes-container">
                            <a href="#" class="category-box">
                                <asp:Image ID="Image10" runat="server" CssClass="img-icon" ImageUrl="~/Image/Element/cardio-session-icon.png" />
                                <h5>WORKOUT TIPS</h5>
                                <h3>ALL-STAR WEIGHT TRAINING METHODS FOR BASEBALL PLAYERS</h3>
                                <h4>Three experts explain how bigger, faster, and stronger can translate to better...</h4>
                                <h6>Read Article</h6>
                            </a>
                            <a href="#" class="category-box">
                                <asp:Image ID="Image11" runat="server" CssClass="img-icon" ImageUrl="~/Image/Element/weight-icon.png" />
                                <h5>WORKOUT TIPS</h5>
                                <h3>SORTING OUT THE TRUTHS AND MYTHS OF STRETCHING</h3>
                                <h4>We're not saying stretching is bad for you, but how much do you really benefit from...</h4>
                                <h6>Read Article</h6>
                            </a>
                            <a href="#" class="category-box">
                                <asp:Image ID="Image12" runat="server" CssClass="img-icon" ImageUrl="~/Image/Element/boxing-icon.png" />
                                <h5>WORKOUT TIPS</h5>
                                <h3>BEST WAYS YOU CAN TRAIN FOR POWER AT HOME</h3>
                                <h4>With these practical training tips, it's possible to make elite-level power gains...</h4>
                                <h6>Read Article</h6>
                            </a>
                            <a href="#" class="category-box">
                                <asp:Image ID="Image13" runat="server" CssClass="img-icon" ImageUrl="~/Image/Element/supersets-icon.png" />
                                <h5>WORKOUT TIPS</h5>
                                <h3>Start Slowly and Progress Gradually</h3>
                                <h4>If you're new to exercise or returning after a break, start with low-intensity workouts and gradually increase....</h4>
                                <h6>Read Article</h6>
                            </a>

                        </div>
                    </div>
                </div>
            </div>
            <%--category 4--%>
            <div class="container">
                <div class="row" id="exercisev-category">
                    <div class="col-10">
                        <div class="section-title-wrapper">
                            <h2 class="section-title">EXERCISE VIDEOS:</h2>
                        </div>
                    </div>
                    <div class="col-10">
                        <div class="Categories-boxes-container">
                            <a href="#" class="category-box">
                                <asp:Image ID="Image14" runat="server" CssClass="img-icon" ImageUrl="~/Image/Element/cardio-session-icon.png" />
                                <h5>WORKOUT TIPS</h5>
                                <h3>ALL-STAR WEIGHT TRAINING METHODS FOR BASEBALL PLAYERS</h3>
                                <h4>Three experts explain how bigger, faster, and stronger can translate to better...</h4>
                                <h6>Read Article</h6>
                            </a>
                            <a href="#" class="category-box">
                                <asp:Image ID="Image15" runat="server" CssClass="img-icon" ImageUrl="~/Image/Element/weight-icon.png" />
                                <h5>WORKOUT TIPS</h5>
                                <h3>SORTING OUT THE TRUTHS AND MYTHS OF STRETCHING</h3>
                                <h4>We're not saying stretching is bad for you, but how much do you really benefit from...</h4>
                                <h6>Read Article</h6>
                            </a>
                            <a href="#" class="category-box">
                                <asp:Image ID="Image16" runat="server" CssClass="img-icon" ImageUrl="~/Image/Element/boxing-icon.png" />
                                <h5>WORKOUT TIPS</h5>
                                <h3>BEST WAYS YOU CAN TRAIN FOR POWER AT HOME</h3>
                                <h4>With these practical training tips, it's possible to make elite-level power gains...</h4>
                                <h6>Read Article</h6>
                            </a>
                            <a href="#" class="category-box">
                                <asp:Image ID="Image17" runat="server" CssClass="img-icon" ImageUrl="~/Image/Element/supersets-icon.png" />
                                <h5>WORKOUT TIPS</h5>
                                <h3>Start Slowly and Progress Gradually</h3>
                                <h4>If you're new to exercise or returning after a break, start with low-intensity workouts and gradually increase....</h4>
                                <h6>Read Article</h6>
                            </a>

                        </div>
                    </div>
                </div>
            </div>
        </div>

        <!--Click this button back to top of the page-->
        <div class="toTop" id="toTop">
            <asp:LinkButton OnClientClick="toTop() ;" ID="top" runat="server">
             <i style="border-radius: 50px; background-color:gold; padding: 10px 12.5px 10px 12.5px; color:black; font-size: 20px;" class="fa-solid fa-arrow-up"></i>
            </asp:LinkButton>
        </div>
    </div>

    <script>
        window.addEventListener("scroll", function () {
            let box = document.getElementById("toTop");
            var elementTarget = document.getElementById("header");
            if (window.scrollY > (elementTarget.offsetTop + elementTarget.offsetHeight)) {
                box.style.display = "block";
            } else {
                box.style.display = "none";
            }
        });

        function toTop() {
            document.documentElement.scrollTop = 0;
        }
    </script>
</asp:Content>
