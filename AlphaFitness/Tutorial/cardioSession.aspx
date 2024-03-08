<%@ Page Title="" Language="C#" MasterPageFile="~/Contents.Master" AutoEventWireup="true" CodeBehind="cardioSession.aspx.cs" Inherits="AlphaFitness.Tutorial.cardioSession" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="TutorialCategory.css" rel="stylesheet" />
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css">
<link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/line-awesome/1.3.0/line-awesome/css/line-awesome.min.css">
<link href="https://fonts.googleapis.com/css?family=Poppins:300,400,500,600,700&display=swap" rel="stylesheet">
<link href="https://fonts.googleapis.com/css?family=Rubik:400,500,700,900&display=swap" rel="stylesheet">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="home-content">
        <h1><span>
            <asp:Image ID="Image9" runat="server" CssClass="header-img-icon" ImageUrl="~/Image/Element/cardio-session-icon.png" /></span>&nbsp;Cardio Session</h1>
        <div class="intro-box">
            <h6>Improving your cardio will strengthen your stamina and endurance so you can work harder for long and burn more calories.</h6>
        </div>
        <div class="subtitle-link">
            <a href="#">TIPS</a>
            <a href="#">ARTICLES</a>
            <a href="#">STEP-BY-STEP GUIDE</a>
            <a href="#">EXERCISE VIDEOS</a>
        </div>
        <div class="content-frame">
            <div class="container">
                <div class="row">
                    <div class="col-10">
                        <div class="section-title-wrapper">
                            <h2 class="section-title">TIPS:</h2>
                        </div>
                    </div>
                    <div class="col-10">
                        <div class="Categories-boxes-container">
                            <a href="#" class="category-box">
                                <asp:Image ID="Image1" runat="server" CssClass="img-icon" ImageUrl="~/Image/Element/cardio-session-icon.png" />
                                <h5>WORKOUT TIPS</h5>
                                <h3>ALL-STAR WEIGHT TRAINING METHODS FOR BASEBALL PLAYERS</h3>
                                <h4>Three experts explain how bigger, faster, and stronger can translate to better...</h4>
                                <h6>Read Article</h6>
                            </a>
                            <a href="#" class="category-box">
                                <asp:Image ID="Image2" runat="server" CssClass="img-icon" ImageUrl="~/Image/Element/weight-icon.png" />
                                <h5>WORKOUT TIPS</h5>
                                <h3>SORTING OUT THE TRUTHS AND MYTHS OF STRETCHING</h3>
                                <h4>We're not saying stretching is bad for you, but how much do you really benefit from...</h4>
                                <h6>Read Article</h6>
                            </a>
                            <a href="#" class="category-box">
                                <asp:Image ID="Image3" runat="server" CssClass="img-icon" ImageUrl="~/Image/Element/boxing-icon.png" />
                                <h5>WORKOUT TIPS</h5>
                                <h3>BEST WAYS YOU CAN TRAIN FOR POWER AT HOME</h3>
                                <h4>With these practical training tips, it's possible to make elite-level power gains...</h4>
                                <h6>Read Article</h6>
                            </a>
                            <a href="#" class="category-box">
                                <asp:Image ID="Image4" runat="server" CssClass="img-icon" ImageUrl="~/Image/Element/supersets-icon.png" />
                                <h5>WORKOUT TIPS</h5>
                                <h3>ALL-STAR WEIGHT TRAINING METHODS FOR BASEBALL PLAYERS</h3>
                                <h4>Three experts explain how bigger, faster, and stronger can translate to better...</h4>
                                <h6>Read Article</h6>
                            </a>

                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
