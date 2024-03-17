<%@ Page Title="" Language="C#" MasterPageFile="~/Contents.Master" AutoEventWireup="true" CodeBehind="EditProfile.aspx.cs" Inherits="AlphaFitness.User.EditProfile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="EditProfile.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
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
                    <div class="img-delete-btn">
                        <asp:LinkButton ID="Delete" CausesValidation="false" OnClick="Delete_Click" CssClass="btn border b2" runat="server">
                    <i class="fa-solid fa-trash" style="color:red"></i>&nbsp;Delete
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
                    <div class="edit-items">
                        <div class="form-floating username">
                            <asp:TextBox AutoPostBack="true" OnTextChanged="Change_TextChanged" runat="server" ID="txtUsername" class="form-control" placeholder="Username" />
                            <label for="txtUsername">Username</label>
                            <div class="msg">
                                <asp:Label CssClass="lblMsg" runat="server" ID="modified1" />
                                <asp:RequiredFieldValidator Display="Dynamic" runat="server" ControlToValidate="txtUsername" ForeColor="Red" ErrorMessage="*Please do not leave username empty." />
                            </div>
                        </div>
                        <div class="form-floating weight">
                            <asp:TextBox AutoPostBack="true" OnTextChanged="Change_TextChanged" runat="server" ID="txtWeight" class="form-control" placeholder="Weight" />
                            <label for="txtWeight">Weight</label>
                            <div class="msg">
                                <asp:Label CssClass="lblMsg" runat="server" ID="modified2" />
                                <asp:RequiredFieldValidator Display="Dynamic" runat="server" ControlToValidate="txtWeight" ForeColor="Red" ErrorMessage="*Please do not leave weight empty." />
                            </div>
                        </div>
                        <div class="form-floating height">
                            <asp:TextBox AutoPostBack="true" OnTextChanged="Change_TextChanged" runat="server" ID="txtHeight" class="form-control" placeholder="Height" />
                            <label for="txtHeight">Height</label>
                            <div class="msg">
                                <asp:Label CssClass="lblMsg" runat="server" ID="modified3" />
                                <asp:RequiredFieldValidator Display="Dynamic" runat="server" ControlToValidate="txtHeight" ForeColor="Red" ErrorMessage="*Please do not leave height empty." />
                            </div>
                        </div>

                        <div class="form-floating title">
                            <asp:DropDownList AutoPostBack="true" OnSelectedIndexChanged="Change_IndexChanged" runat="server" ID="ddlTitle" class="form-control" />
                            <label for="txtTitle">Title</label>
                            <div class="msg">
                                <asp:Label CssClass="lblMsg" runat="server" ID="modified4" />
                                <asp:RequiredFieldValidator Display="Dynamic" runat="server" ControlToValidate="ddlTitle" ForeColor="Red" ErrorMessage="*Please do not leave title empty." />
                            </div>
                        </div>
                    </div>
                </div>
                <div class="edit-btn">
                    <asp:Button OnClick="edit_Click" Enabled="false" ID="edit" PostBackUrl="~/User/EditProfile.aspx" CssClass="border btn btn-edit" runat="server" Text="Edit Profile" />
                </div>

            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
</asp:Content>
