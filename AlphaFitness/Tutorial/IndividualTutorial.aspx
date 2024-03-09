<%@ Page Title="" Language="C#" MasterPageFile="~/Contents.Master" AutoEventWireup="true" CodeBehind="IndividualTutorial.aspx.cs" Inherits="AlphaFitness.Tutorial.IndividualTutorial" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="IndividualTutorial.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="product-container">
    <div class="left-box">
        <div class="top-container">
            <div class="product-header">
                <div class="left-info">
                    <div class="status-icon" id="status">
                        <asp:Label runat="server" ID="tutFilter" CssClass="topStatus" Text="" />
                    </div>
                    <div class="subtitle">
                        <asp:Label ID="tutSubtitle" runat="server" Text="" />
                    </div>
                    <div class="header-title">
                        <asp:Label Style="font-weight: bold; font-size: 28px; color: #ff7e29" ID="tutTitle" runat="server" Text="" />
                    </div>
                    <div class="series">
                        <span style="color: #ff7e29;">By : </span>
                        <asp:Label ID="tutAuthor" runat="server" Text="" />
                    </div>
                </div>

            </div>
                            
            <div class="middle">
                <div class="main-img">
                    <asp:Image runat="server" ID="mainimg" Style="width: 100%; padding: 20px 0px 20px 130px;" />
                </div>
            </div>
        </div>
        <div style="padding: 10px; border-top: 1px solid lightgrey;">
            <div class="content-details">
                <asp:Label runat="server" CssClass="content-text" ID="tutContent" Text="" />
            </div>
        </div>
        <div class="back-icon">
            <asp:HyperLink runat="server" NavigateUrl="~/Tutorial/cardioSession.aspx" ID="Label1" CssClass="topStatus" Text="Back" />
        </div>
    </div>
</div>
</asp:Content>
