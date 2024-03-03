<%@ Page Title="" Language="C#" MasterPageFile="~/Contents.Master" AutoEventWireup="true" CodeBehind="Community.aspx.cs" Inherits="AlphaFitness.Community.Community" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="Community.css" rel="stylesheet" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="community-container">
        <div class="header-community">
            <div class="numberofposts">
                There are totally&nbsp;<asp:Label Style="font-weight: 500;" runat="server" ID="numOfPosts" Text="123"/>.
            </div>
            <div class="date">
                <i class='bx bxs-calendar'></i><asp:Label runat="server" ID="currentTime" Text="Mar, 10 2024"/>
            </div>
        </div>
        <div class="">
            <div class="top-community">
            </div>
            <div class="middle-community">
            </div>
            <div class="bottom-community">
            </div>
        </div>
    </div>

</asp:Content>
