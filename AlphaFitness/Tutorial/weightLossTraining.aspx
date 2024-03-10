<%@ Page Title="" Language="C#" MasterPageFile="~/Contents.Master" AutoEventWireup="true" CodeFile="weightLossTraining.aspx.cs" Inherits="AlphaFitness.Tutorial.weightLossTraining" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="TutorialCategory.css" rel="stylesheet" />
<style>
    .img-icon {
        padding-bottom: 10px;
    }

    /*Click this back to top*/
    .toTop {
        position: fixed;
        bottom: 15px;
        right: 15px;
        display: none;
    }

    .section-title {
        letter-spacing: 1px;
        padding-top: 5px;
        padding-bottom: 10px !important;
    }

    #header {
        padding-left: 40px !important;
        line-height: 0.8 !important;
    }
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="home-content">
    <h1 id="header">Weight Loss Training</h1>
    <div class="intro-box">
        <h6>Effective weight training depends on proper technique. Follow these do's and don'ts to maximize your weight training program.</h6>
    </div>
    <div class="subtitle-link">
        <a href="cardioSession.aspx#tips-category"  id="tips-category">TIPS</a>
        <a href="cardioSession.aspx#articles-category">ARTICLES</a>
        <a href="cardioSession.aspx#sbsguide-category">STEP-BY-STEP GUIDE</a>
        <a href="cardioSession.aspx#exercisev-category">EXERCISE VIDEOS</a>
    </div>
    <div class="content-frame">
        <%--category 1--%>
        <div class="container">
            <div class="row">
                <div class="col-10">
                    <div class="section-title-wrapper">
                        <h2 class="section-title">TIPS:</h2>
                    </div>
                </div>
                <div class="col-10">
                    <div class="Categories-boxes-container">
                        <asp:LinkButton PostBackUrl="~/Tutorial/IndividualTutorial.aspx?id=1" CssClass="category-box" runat="server">
                            <asp:Image ID="Image1" runat="server" CssClass="img-icon" ImageUrl="~/Image/Tutorial/cs1.png" />
                            <h5>WORKOUT TIPS</h5>
                            <h3>WEIGHT TRAINING METHODS FOR BASEBALL PLAYERS</h3>
                            <h4>Three experts explain how bigger, faster, and stronger can translate to better...</h4>
                        </asp:LinkButton>
                        <asp:LinkButton PostBackUrl="~/Tutorial/IndividualTutorial.aspx?id=2" CssClass="category-box" runat="server">
                            <asp:Image ID="Image2" runat="server" CssClass="img-icon" ImageUrl="~/Image/Tutorial/cs2.png" />
                            <h5>WORKOUT TIPS</h5>
                            <h3>SORTING OUT THE TRUTHS AND MYTHS OF STRETCHING</h3>
                            <h4>We're not saying stretching is bad for you, but how much do you really benefit from...</h4>
                        </asp:LinkButton>
                        <asp:LinkButton PostBackUrl="~/Tutorial/IndividualTutorial.aspx?id=3" CssClass="category-box" runat="server">
                            <asp:Image ID="Image3" runat="server" CssClass="img-icon" ImageUrl="~/Image/Tutorial/cs3.png" />
                            <h5>WORKOUT TIPS</h5>
                            <h3>BEST WAYS YOU CAN TRAIN FOR POWER AT HOME</h3>
                            <h4>With these practical training tips, it's possible to make elite-level power gains...</h4>
                        </asp:LinkButton>
                        <asp:LinkButton PostBackUrl="~/Tutorial/IndividualTutorial.aspx?id=4" CssClass="category-box" runat="server">
                            <asp:Image ID="Image4" runat="server" CssClass="img-icon" ImageUrl="~/Image/Tutorial/cs4.png" />
                            <h5>WORKOUT TIPS</h5>
                            <h3>PHYSICAL THERAPISTS OFFER TIPS</h3>
                            <h4 id="articles-category">If you're new to exercise or returning after a break, start with low-intensity....</h4>
                        </asp:LinkButton>
                    </div>
                </div>
            </div>
        </div>
        <%--category 2--%>
        <div class="container">
            <div class="row">
                <div class="col-10">
                    <div class="section-title-wrapper">
                        <h2 class="section-title">ARTICLES:</h2>
                    </div>
                </div>
                <div class="col-10">
                    <div class="Categories-boxes-container">
                        <asp:LinkButton PostBackUrl="~/Tutorial/IndividualTutorial.aspx?id=5" CssClass="category-box" runat="server">
                            <asp:Image ID="Image5" runat="server" CssClass="img-icon" ImageUrl="~/Image/Tutorial/cs5.png" />
                            <h5>WORKOUT ROUTINES</h5>
                            <h3>TRAINING TIPS SKIERS CAN USE FOR IMPROVE THEIR STRENGTH ON SLOPES</h3>
                            <h4>If you hadn’t noticed, it’s still snow ski season, and many people are taking time off...</h4>
                        </asp:LinkButton>
                        <asp:LinkButton PostBackUrl="~/Tutorial/IndividualTutorial.aspx?id=6" CssClass="category-box" runat="server">
                            <asp:Image ID="Image6" runat="server" CssClass="img-icon" ImageUrl="~/Image/Tutorial/cs6.png" />
                            <h5>FITNESS ESSENTIALS</h5>
                            <h3>PROVEN TIPS TO BUILD MENTAL TOUGHNESS & BOOST PERFORMANCE</h3>
                            <h4>We all play to win, but nobody comes out on top all the time. Even with....</h4>
                        </asp:LinkButton>
                        <asp:LinkButton PostBackUrl="~/Tutorial/IndividualTutorial.aspx?id=7" CssClass="category-box" runat="server">
                            <asp:Image ID="Image7" runat="server" CssClass="img-icon" ImageUrl="~/Image/Tutorial/cs7.png" />
                            <h5>WORKOUT ROUTINES</h5>
                            <h3>HERE’S THE ROUTINE TO HELP YOU PACK ON SIZE AND NOT DESTROY YOUR JOINT</h3>
                            <h4>Although packing on muscle increases strength and size, helping you look...</h4>
                        </asp:LinkButton>
                        <asp:LinkButton PostBackUrl="~/Tutorial/IndividualTutorial.aspx?id=8" CssClass="category-box" runat="server">
                            <asp:Image ID="Image8" runat="server" CssClass="img-icon" ImageUrl="~/Image/Tutorial/cs8.png" />
                            <h5>FITNESS ESSENTIALS</h5>
                            <h3>WHAT’S YOUR FAVORITE OLD-SCHOOL EXERCISE DEVICE?</h3>
                            <h4 id="sbsguide-category">On the Clock with Frank and Zack is a social media video series hosted on M&F’s....</h4>
                        </asp:LinkButton>
                    </div>
                </div>
            </div>
        </div>
        <%--category 3--%>
        <div class="container">
            <div class="row">
                <div class="col-10">
                    <div class="section-title-wrapper">
                        <h2 class="section-title">STEP-BY-STEP GUIDES:</h2>
                    </div>
                </div>
                <div class="col-10">
                    <div class="Categories-boxes-container">
                        <asp:LinkButton PostBackUrl="~/Tutorial/IndividualTutorial.aspx?id=9" CssClass="category-box" runat="server">
                            <asp:Image ID="Image9" runat="server" CssClass="img-icon" ImageUrl="~/Image/Tutorial/cs9.png" />
                            <h5>GUIDE/INSTRUCTIONS</h5>
                            <h3>Sit-up</h3>
                            <h4>One of the exercises most associated with a six-pack due to working the abdominals, sit...</h4>
                        </asp:LinkButton>
                        <asp:LinkButton PostBackUrl="~/Tutorial/IndividualTutorial.aspx?id=10" CssClass="category-box" runat="server">
                            <asp:Image ID="Image10" runat="server" CssClass="img-icon" ImageUrl="~/Image/Tutorial/cs10.png" />
                            <h5>GUIDE/INSTRUCTIONS</h5>
                            <h3>Pull-up</h3>
                            <h4>How to do Pull-Up:  Step 1: Facing a pull up bar, grasp the handles with your palms...</h4>
                        </asp:LinkButton>
                        <asp:LinkButton PostBackUrl="~/Tutorial/IndividualTutorial.aspx?id=11" CssClass="category-box" runat="server">
                            <asp:Image ID="Image11" runat="server" CssClass="img-icon" ImageUrl="~/Image/Tutorial/cs11.png" />
                            <h5>GUIDE/INSTRUCTIONS</h5>
                            <h3>Seated Dumbbell Concentration Curls</h3>
                            <h4>Sit on a flat bench with your legs spread, knees bent and your feet flat on the floor with...</h4>
                        </asp:LinkButton>
                        <asp:LinkButton PostBackUrl="~/Tutorial/IndividualTutorial.aspx?id=12" CssClass="category-box" runat="server">
                            <asp:Image ID="Image12" runat="server" CssClass="img-icon" ImageUrl="~/Image/Tutorial/cs12.png" />
                            <h5>GUIDE/INSTRUCTIONS</h5>
                            <h3>Lunge</h3>
                            <h4 id="exercisev-category">Lunges Instructions  1. Stand with your feet hip-width apart, keep your back straight....</h4>
                        </asp:LinkButton>
                    </div>
                </div>
            </div>
        </div>
        <%--category 4--%>
        <div class="container">
            <div class="row">
                <div class="col-10">
                    <div class="section-title-wrapper">
                        <h2 class="section-title">EXERCISE VIDEOS:</h2>
                    </div>
                </div>
                <div class="col-10">
                    <div class="Categories-boxes-container">
                        <asp:LinkButton PostBackUrl="~/Tutorial/IndividualTutorial.aspx?id=13" CssClass="category-box" runat="server">
                            <asp:Image ID="Image13" runat="server" CssClass="img-icon" ImageUrl="~/Image/Tutorial/cs13.png" />
                            <h5>ABS EXERCISES</h5>
                            <h3>General Pullup Demo</h3>
                            <h4>Click to watch the video!</h4>
                        </asp:LinkButton>
                        <asp:LinkButton PostBackUrl="~/Tutorial/IndividualTutorial.aspx?id=14" CssClass="category-box" runat="server">
                            <asp:Image ID="Image14" runat="server" CssClass="img-icon" ImageUrl="~/Image/Tutorial/cs14.png" />
                            <h5>DELTS EXERCISES</h5>
                            <h3>Strict (Military) Push-Up Demo</h3>
                            <h4>Click to watch the video!</h4>
                        </asp:LinkButton>
                        <asp:LinkButton PostBackUrl="~/Tutorial/IndividualTutorial.aspx?id=15" CssClass="category-box" runat="server">
                            <asp:Image ID="Image15" runat="server" CssClass="img-icon" ImageUrl="~/Image/Tutorial/cs15.png" />
                            <h5>CALVES EXERCISES</h5>
                            <h3>Walking High Knees Demo</h3>
                            <h4>Click to watch the video!</h4>
                        </asp:LinkButton>
                        <asp:LinkButton PostBackUrl="~/Tutorial/IndividualTutorial.aspx?id=16" CssClass="category-box" runat="server">
                            <asp:Image ID="Image16" runat="server" CssClass="img-icon" ImageUrl="~/Image/Tutorial/cs16.png" />
                            <h5>ABS EXERCISES</h5>
                            <h3>Reverse Crunch Demo</h3>
                            <h4>Click to watch the video!</h4>
                        </asp:LinkButton>
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
