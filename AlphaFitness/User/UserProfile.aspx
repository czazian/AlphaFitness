<%@ Page Title="" Language="C#" MasterPageFile="~/Contents.Master" AutoEventWireup="true" CodeBehind="UserProfile.aspx.cs" Inherits="AlphaFitness.User.UserProfile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="UserProfile.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="profile">
        <div class="main">
            <div class="left">
                <div class="profileimg">
                    <asp:Image Style="width: 250px; height: 250px; border-radius: 100px; z-index: 3;"
                        runat="server" ID="profileimg" ImageUrl="~/Image/Profile/user.png" />
                </div>
                <div class="profilename">
                    @<asp:Label runat="server" ID="username" />andrewyeooo
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
                                <asp:Label runat="server" ID="email" />junken03@gmail.com</td>
                        </tr>
                        <tr>
                            <th>Weight
                                <div style="height: inherit; text-align: right;">:</div>
                            </th>
                            <td>
                                <asp:Label runat="server" ID="weight" Text="5" />&nbsp;KG</td>
                        </tr>
                        <tr>
                            <th>Height
                                <div style="height: inherit; text-align: right;">:</div>
                            </th>
                            <td>
                                <asp:Label runat="server" ID="height" Text="1000" />&nbsp;CM</td>
                        </tr>
                        <tr>
                            <th style="vertical-align: central; margin-top:5px;">Title
                                <div style="height: inherit; text-align: right;">:</div>
                            </th>
                            <td>
                                <div class="title-obtain">
                                    <asp:Image runat="server" ID="Image4" CssClass="titleImg" ImageUrl="~/Image/Title/5.png" />
                                </div>
                        </tr>
                    </table>
                    <div class="edit-btn">
                        <asp:Button PostBackUrl="~/Customer/EditProfile.aspx" CssClass="border btn btn-edit" runat="server" Text="Go Edit Profile" />
                    </div>
                </fieldset>
            </div>
        </div>
    </div>
</asp:Content>
