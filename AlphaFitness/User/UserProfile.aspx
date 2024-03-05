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
                            <th>Phone No.
                                <div style="height: inherit; text-align: right;">:</div>
                            </th>
                            <td>
                                <asp:Label runat="server" ID="phone" /></td>
                        </tr>
                        <tr>

                        </tr>
                    </table>
                </fieldset>
            </div>
        </div>
    </div>
</asp:Content>
