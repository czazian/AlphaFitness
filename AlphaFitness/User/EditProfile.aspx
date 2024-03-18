<%@ Page Title="" Language="C#" MasterPageFile="~/Contents.Master" AutoEventWireup="true" CodeBehind="EditProfile.aspx.cs" Inherits="AlphaFitness.User.EditProfile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="EditProfile.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="home-content">
        <div class="box">
            <div class="title">
                <div class="maintitle">
                    Edit Profile
                </div>
                <div class="subtitle">
                    Manage Profile Information 
                </div>
            </div>
            <hr style="color: black; margin-top: 10px; margin-bottom: 10px; opacity: 1;" />
            <div class="changeimg">
                <div class="profile-title">
                    Your Profile Photo
                </div>

                <div class="image-container">
                    <div class="img">
                        <asp:Image Style="border-radius: 100px; width: 100%; width: 120px; height: 120px;"
                            runat="server" ID="profileimg" />
                    </div>
                    <div class="btn-grouping">
                        <div class="img-change-btn">
                            <asp:FileUpload accept=".png,.jpg,.jpeg,.gif" ID="FileUpload1" Style="display: none" runat="server" onchange="upload()" />
                            <input type="button" value="Change Photo" class="btn border b1" onclick="showBrowseDialog()" />

                            <asp:LinkButton OnClientClick="return true;" CausesValidation="false" runat="server" ID="hideBtn" Style="display: none;" OnClick="hideButton_Click" />
                        </div>
                        <div class="img-delete-btn" style="min-width: contain">
                            <asp:LinkButton ID="Delete" Style="min-width: contain" CausesValidation="false" OnClick="Delete_Click" CssClass="b2" runat="server">
                    <i class="fa-solid fa-trash" style="color:red"></i>&nbsp;<span style="color:black;">Delete</span>
                            </asp:LinkButton>
                        </div>
                    </div>
                </div>



                <div class="suggestion-img">
                    Change your photo. A photo of 120×120px and within 5MB is recommended.
                </div>
            </div>


            <!--An instance for update panel-->
            <asp:ScriptManager ID="ScriptManager1" runat="server">
            </asp:ScriptManager>
            <asp:UpdatePanel runat="server" UpdateMode="Conditional">
                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="edit" />
                </Triggers>
                <ContentTemplate>

                    <div class="edit-input">
                        <div class="profile-title">
                            Your Personal Information
                        </div>
                        <table class="edit-items">
                            <tr class="form-floating username">
                                <td style="padding-right: 8px;">
                                    <label for="txtUsername">Username</label></td>
                                <td>
                                    <asp:TextBox AutoPostBack="true" OnTextChanged="Change_TextChanged" runat="server" ID="txtUsername" class="form-control" placeholder="Username" />
                                    <div class="msg">
                                        <asp:Label CssClass="lblMsg" runat="server" ID="modified1" />
                                        <asp:RequiredFieldValidator Display="Dynamic" runat="server" ControlToValidate="txtUsername" ForeColor="Red" ErrorMessage="*Please do not leave username empty." />
                                    </div>
                                </td>
                            </tr>
                            <tr class="form-floating weight">
                                <td style="padding-right: 8px;">
                                    <label for="txtWeight">Weight</label></td>
                                <td>
                                    <asp:TextBox AutoPostBack="true" OnTextChanged="Change_TextChanged" runat="server" ID="txtWeight" class="form-control" placeholder="Weight" />
                                    <div class="msg">
                                        <asp:Label CssClass="lblMsg" runat="server" ID="modified2" />
                                        <asp:RequiredFieldValidator Display="Dynamic" runat="server" ControlToValidate="txtWeight" ForeColor="Red" ErrorMessage="*Please do not leave weight empty." />
                                    </div>
                                </td>
                            </tr>
                            <tr class="form-floating height">
                                <td style="padding-right: 8px;">
                                    <label for="txtHeight">Height</label></td>
                                <td>
                                    <asp:TextBox AutoPostBack="true" OnTextChanged="Change_TextChanged" runat="server" ID="txtHeight" class="form-control" placeholder="Height" />
                                    <div class="msg">
                                        <asp:Label CssClass="lblMsg" runat="server" ID="modified3" />
                                        <asp:RequiredFieldValidator Display="Dynamic" runat="server" ControlToValidate="txtHeight" ForeColor="Red" ErrorMessage="*Please do not leave height empty." />
                                    </div>
                                </td>
                            </tr>

                            <tr class="form-floating title">
                                <td style="padding-right: 8px;">
                                    <label for="txtTitle">Title</label></td>
                                <td>
                                    <asp:DropDownList AutoPostBack="true" OnSelectedIndexChanged="ddlTitle_SelectedIndexChanged" runat="server" ID="ddlTitle" class="form-control" />
                                </td>
                            </tr>
                        </table>
                    </div>
                    <div class="edit-btn">
                        <asp:Button OnClick="edit_Click" CausesValidation="false" Enabled="false" ID="edit" CssClass="border btn btn-edit" runat="server" Text="Edit Profile" />
                    </div>

                </ContentTemplate>
            </asp:UpdatePanel>

        </div>
    </div>
</asp:Content>
