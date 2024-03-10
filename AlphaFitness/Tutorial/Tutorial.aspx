<%@ Page Title="" Language="C#" MasterPageFile="~/Contents.Master" AutoEventWireup="true" CodeBehind="Tutorial.aspx.cs" Inherits="AlphaFitness.Tutorial.Tutorial" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="Tutorial.css" rel="stylesheet" />
    <style>
        #TutorialLi {
            border-right: 5px solid #ffc219;
            background-color: #808080;
        }
    </style>
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
                                <asp:Image ID="Image1" runat="server" CssClass="img-icon" ImageUrl="~/Image/Tutorial/cardio-session-icon.png" />
                                <h4>Cardio Session</h4>
                            </asp:HyperLink>
                            <asp:HyperLink runat="server" ID="HyperLink1" CssClass="category-box" NavigateUrl="~/Tutorial/weightLossTraining.aspx">
                                <asp:Image ID="Image2" runat="server" CssClass="img-icon" ImageUrl="~/Image/Tutorial/weight-icon.png" />
                                <h4>Weight Loss Training</h4>
                            </asp:HyperLink>
                            <asp:HyperLink runat="server" ID="HyperLink2" CssClass="category-box" NavigateUrl="~/Tutorial/kickBoxing.aspx">
                                <asp:Image ID="Image3" runat="server" CssClass="img-icon" ImageUrl="~/Image/Tutorial/boxing-icon.png" />
                                <h4>Kick Boxing</h4> 
                            </asp:HyperLink>
                            <asp:HyperLink runat="server" ID="HyperLink3" CssClass="category-box" NavigateUrl="~/Tutorial/supersets.aspx">
                                <asp:Image ID="Image4" runat="server" CssClass="img-icon" ImageUrl="~/Image/Tutorial/supersets-icon.png" />
                                <h4>Supersets</h4>
                            </asp:HyperLink>
                            <asp:HyperLink runat="server" ID="HyperLink4" CssClass="category-box" NavigateUrl="~/Tutorial/yogaStretching.aspx">
                                <asp:Image ID="Image5" runat="server" CssClass="img-icon" ImageUrl="~/Image/Tutorial/yoga-icon.png" />
                                <h4>Yoga & Stretching</h4>
                            </asp:HyperLink>
                            <asp:HyperLink runat="server" ID="HyperLink5" CssClass="category-box" NavigateUrl="~/Tutorial/functionalTraining.aspx">
                                <asp:Image ID="Image6" runat="server" CssClass="img-icon" ImageUrl="~/Image/Tutorial/functional-training-icon.png" />
                                <h4>Functional Training</h4>
                            </asp:HyperLink>
                            <asp:HyperLink runat="server" ID="HyperLink6" CssClass="category-box" NavigateUrl="~/Tutorial/dumbbell.aspx">
                                <asp:Image ID="Image7" runat="server" CssClass="img-icon" ImageUrl="~/Image/Tutorial/dumbbell-icon.png" />
                                <h4>Dumbbell</h4>
                            </asp:HyperLink>
                            <asp:HyperLink runat="server" ID="HyperLink7" CssClass="category-box" NavigateUrl="~/Tutorial/bodybuidling.aspx">
                                <asp:Image ID="Image8" runat="server" CssClass="img-icon" ImageUrl="~/Image/Tutorial/bodybuilding-icon.png" />
                                <h4>Bodybuilding</h4>
                            </asp:HyperLink>
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
</asp:Content>
