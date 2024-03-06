<%@ Page Title="" Language="C#" MasterPageFile="~/Contents.Master" AutoEventWireup="true" CodeBehind="Tutorial.aspx.cs" Inherits="AlphaFitness.Tutorial.Tutorial" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="Tutorial.css" rel="stylesheet" />
    <!--<link href="https://slidesigma.com/themes/html/joblify/assets/css/bootstrap.min.css" rel="stylesheet">-->
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css">
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/line-awesome/1.3.0/line-awesome/css/line-awesome.min.css">
    <link href="https://fonts.googleapis.com/css?family=Poppins:300,400,500,600,700&display=swap" rel="stylesheet">
    <link href="https://fonts.googleapis.com/css?family=Rubik:400,500,700,900&display=swap" rel="stylesheet">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <div class="home-content">
        <section class="jb-profile-slider-2">
            <div class="container">
                <div class="row">
                    <div class="col-10">
                        <div class="section-title-wrapper">
                            <h2 class="section-title">Popular Categories</h2>
                            <h6 class="section-title"><i class="bx bx-run"></i>&nbsp;Take a peek inside our fitness world</h6>
                        </div>
                    </div>
                    <div class="col-10">
                        <div class="Categories-boxes-container">
                            <asp:HyperLink runat="server" ID="communityLink" CssClass="category-box" NavigateUrl="~/Tutorial/cardioSession.aspx">
                                <asp:Image ID="Image1" runat="server" CssClass="img-icon" ImageUrl="~/Image/Element/cardio-session-icon.png" />
                                <h4>Cardio Session</h4>
                            </asp:HyperLink>
                            <a href="#" class="category-box">
                                <asp:Image ID="Image2" runat="server" CssClass="img-icon" ImageUrl="~/Image/Element/weight-icon.png" />
                                <h4>Weight Loss Training</h4>
                            </a>
                            <a href="#" class="category-box">
                                <asp:Image ID="Image3" runat="server" CssClass="img-icon" ImageUrl="~/Image/Element/boxing-icon.png" />
                                <h4>Kick Boxing</h4>
                            </a>
                            <a href="#" class="category-box">
                                <asp:Image ID="Image4" runat="server" CssClass="img-icon" ImageUrl="~/Image/Element/supersets-icon.png" />
                                <h4>Supersets</h4>
                            </a>
                            <a href="#" class="category-box">
                                <asp:Image ID="Image5" runat="server" CssClass="img-icon" ImageUrl="~/Image/Element/yoga-icon.png" />
                                <h4>Yoga & Stretching</h4>
                            </a>
                            <a href="#" class="category-box">
                                <asp:Image ID="Image6" runat="server" CssClass="img-icon" ImageUrl="~/Image/Element/functional-training-icon.png" />
                                <h4>Functional Training</h4>
                            </a>
                            <a href="#" class="category-box">
                                <asp:Image ID="Image7" runat="server" CssClass="img-icon" ImageUrl="~/Image/Element/dumbbell-icon.png" />
                                <h4>Dumbbell</h4>
                            </a>
                            <a href="#" class="category-box">
                                <asp:Image ID="Image8" runat="server" CssClass="img-icon" ImageUrl="~/Image/Element/bodybuilding-icon.png" />
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
