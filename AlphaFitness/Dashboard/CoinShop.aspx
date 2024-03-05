<%@ Page Title="" Language="C#" MasterPageFile="~/Contents.Master" AutoEventWireup="true" CodeBehind="CoinShop.aspx.cs" Inherits="AlphaFitness.Dashboard.CoinShop" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="CoinShop.css" rel="stylesheet" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <div class="home-content">
        <div class="heading">
            <div class="title">
                <asp:HyperLink runat="server" ID="hypTitle" Text="Title"/>
            </div>
        </div>
        <div class="show-item">

        </div>
    </div>


</asp:Content>
