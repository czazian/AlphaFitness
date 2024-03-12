<%@ Page Title="" Language="C#" MasterPageFile="~/Contents.Master" AutoEventWireup="true" CodeBehind="OtherPersonProfile.aspx.cs" Inherits="AlphaFitness.User.OtherPersonProfile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="UserProfile.css" />
    <style>
        .backBtn {
            display: flex;
            flex-flow: row nowrap;
            gap: 10px;
            margin-top: 10px;
        }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="profile">
        <div class="main">


            <div class="left" style="position: relative;">
                <div class="backBtn" style="position: absolute; left: 30px; top: 25px;">
                    <asp:LinkButton CausesValidation="false" CssClass="bt" runat="server" OnClick="Unnamed_Click">
                        <i class="fa-solid fa-arrow-left"></i>&nbsp;&nbsp;Back
                    </asp:LinkButton>
                </div>
                <div class="profileimg">
                    <asp:Image Style="width: 250px; height: 250px; border-radius: 100px; z-index: 3;"
                        runat="server" ID="profileimg" />
                </div>
                <div class="profilename">
                    @<asp:Label runat="server" ID="username" />
                </div>
            </div>

            <div class="right">
                <fieldset class="right-content">
                    <legend>User Profile</legend>
                    <table class="profile-info">
                        <tr>
                            <th>Email Address
                                <div style="height: inherit; text-align: right;">:</div>
                            </th>
                            <td>
                                <asp:Label runat="server" ID="email" /></td>
                        </tr>
                        <tr>
                            <th>Weight
                                <div style="height: inherit; text-align: right;">:</div>
                            </th>
                            <td>
                                <asp:Label runat="server" ID="weight" />&nbsp;KG</td>
                        </tr>
                        <tr>
                            <th>Height
                                <div style="height: inherit; text-align: right;">:</div>
                            </th>
                            <td>
                                <asp:Label runat="server" ID="height" />&nbsp;CM</td>
                        </tr>
                        <tr>
                            <th style="vertical-align: central; margin-top: 5px;">Title
                                <div style="height: inherit; text-align: right;">:</div>
                            </th>
                            <td>
                                <div class="title-obtain">
                                    <asp:Image runat="server" ID="Image4" CssClass="titleImg" ImageUrl="~/Image/Title/5.png" />
                                </div>
                        </tr>
                        <tr>
                            <th>Date Of Join
                                <div style="height: inherit; text-align: right;">:</div>
                            </th>
                            <td>
                                <asp:Label runat="server" ID="dateJoin" />&nbsp;</td>
                        </tr>
                    </table>
                </fieldset>
            </div>
        </div>
    </div>

</asp:Content>
