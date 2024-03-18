<%@ Page Title="" Language="C#" EnableEventValidation="false" MasterPageFile="~/Contents.Master" AutoEventWireup="true" CodeBehind="Community.aspx.cs" Inherits="AlphaFitness.Community.Community" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="Community.css" rel="stylesheet" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="home-content">
        <div class="header-community" id="header">
            <div class="leftbox">
                <div class="numberofposts">
                    <i style="color: gold" class="fa-solid fa-signs-post">&nbsp;&nbsp;</i><asp:Label Style="font-weight: 500;" runat="server" ID="numOfPosts" />
                    Posts
                </div>
                <div class="date">
                    <i style="color: gold" class='bx bxs-calendar'></i>
                    <asp:Label runat="server" ID="currentTime" />
                </div>
            </div>
            <div class="rightbox">
                <div class="submit">
                    <button type="button" onclientclick="return false;" id="btn" class="btn submitbtn btn-warning">
                        Create Post&nbsp;<i class="fa-solid fa-pen-to-square"></i>
                    </button>
                </div>
            </div>
        </div>
        <!-- Modal -->
        <div id="myModal" class="modal">

            <div class="modal-content">
                <span class="close">&times;</span>
                <div class="post-create">
                    <div class="topic">
                        <div class="topic-title">
                            Title
                        </div>
                        <div class="topic-field">
                            <asp:TextBox runat="server" ID="txtTopic" CssClass="txtPost" />
                            <asp:RequiredFieldValidator CssClass="validator" ID="RequiredFieldValidator1" runat="server" ErrorMessage="Please do not leave topic empty." ControlToValidate="txtTopic" ForeColor="Red"></asp:RequiredFieldValidator>
                        </div>
                    </div>

                    <div class="content">
                        <div class="content-title">
                            Description
                        </div>
                        <div class="content-field">
                            <asp:TextBox runat="server" ID="txtContent" TextMode="MultiLine" CssClass="txtPost" />
                            <asp:RequiredFieldValidator CssClass="validator" ID="RequiredFieldValidator2" runat="server" ErrorMessage="Please do not leave content empty." ControlToValidate="txtContent" ForeColor="Red"></asp:RequiredFieldValidator>
                        </div>
                    </div>

                    <div class="submit-post">
                        <asp:Button runat="server" CssClass="cancel" ID="cancel" Text="Cancel" />
                        <asp:Button runat="server" OnClick="submit_Click" CssClass="submitPost" ID="submit" Text="Submit" />
                    </div>
                </div>
            </div>

        </div>


        <!--a post-->
        <asp:Repeater runat="server" ID="postRepeater" OnItemDataBound="postRepeater_ItemDataBound">
            <ItemTemplate>
                <asp:HiddenField runat="server" ID="hdnID" Value='<%# Eval("PostID") %>' />
                <asp:HiddenField runat="server" ID="UserIDD" Value='<%# Eval("UserID") %>' />
                <div class="post">
                    <div class="top-community">
                        <div class="person-image">
                            <asp:ImageButton CausesValidation="false" ID="ibProfile" OnCommand="ibProfile_Command" CommandArgument='<%# Eval("UserID") %>' ImageUrl='<%# Eval("ProfileImage") %>' runat="server" Width="70" Height="70" Style="border-radius: 10px;" />
                        </div>
                    </div>
                    <div class="middle-community">
                        <div class="person-detail">
                            <div class="infobar">
                                <div class="person-name">
                                    <asp:Label runat="server" Text='<%# Eval("UserName") %>' />
                                </div>
                                <asp:Panel runat="server" ID="titleCon" class="title-obtain">
                                    <asp:Image runat="server" ID="img" Visible="false" CssClass="titleImg" ImageUrl='<%# Eval("EquippedImageUrl") %>' />
                                </asp:Panel>
                            </div>
                            <div class="person-date">
                                <asp:Label runat="server" Text='<%# Eval("PostTime") %>' />
                            </div>
                        </div>
                        <div class="comment">
                            <table style="margin-bottom: 5px;">
                                <tr>
                                    <td class="title" style="width: 65px;">
                                        <b>Title:</b>
                                    </td>
                                    <td>
                                        <b>
                                            <asp:Label Style="width: inherit" runat="server" ID="lblTitle" Text='<%# Eval("PostTitle") %>' /></b>
                                    </td>
                                </tr>
                            </table>
                            <div style="width: 100%;">
                                <asp:Label runat="server" Style="width: inherit" ID="comment" Text='<%# Eval("PostContent") %>' />
                            </div>
                        </div>
                        <div class="buttons">
                            <div class="like-btn">
                                <asp:LinkButton CausesValidation="false" OnCommand="LikeClick_Command" CommandArgument='<%# Eval("PostID") %>' ID="LikeClick" runat="server"><i style="color:palevioletred; opacity:1.0;" class="fa-regular fa-heart"></i></asp:LinkButton>&nbsp;<asp:Label runat="server" ID="numOfLikes" Text='<%# Eval("LikeCount") %>' />&nbsp;Likes
                            </div>
                            <div class="comment-btn">
                                <i class="fa-regular fa-comment-dots"></i>&nbsp;<asp:Label runat="server" ID="numOfComments" Text='<%# Eval("CommentCount") %>' />&nbsp;Comments
                            </div>
                        </div>

                        <div class="view-more">
                            <asp:HyperLink runat="server" ID="btnview" Text="VIEW THE POST" NavigateUrl='<%# "~/Community/Post.aspx?postID=" + Eval("PostID") + "&userID=" + Eval("UserID") + "&page=com" %>' />
                        </div>
                    </div>
                </div>
            </ItemTemplate>
        </asp:Repeater>


        <!--end a post-->




        <!--Click this button back to top of the page-->
        <div class="toTop" id="toTop">
            <button style="border: none; background-color: transparent; cursor: pointer;" onclick="toTop();" id="top">
                <i style="border-radius: 50px; background-color: gold; padding: 10px 12.5px 10px 12.5px; color: black; font-size: 20px;" class="fa-solid fa-arrow-up"></i>
            </button>
        </div>

    </div>
    <script>
        window.addEventListener("scroll", function () {
            let box = document.getElementById("toTop");
            var elementTarget = document.getElementById("header");
            if (window.scrollY > (elementTarget.offsetTop + elementTarget.offsetHeight)) {
                box.style.display = "block";
            } else {
                box.style.display = "none";
            }
        });

        function toTop() {
            document.documentElement.scrollTop = 0;
        }


        //Message
        function title() {
            alert("Your post has successfully created...");
        }


        // Get the modal
        var modal = document.getElementById("myModal");

        // Get the button that opens the modal
        var btn = document.getElementById("btn");

        // Get the <span> element that closes the modal
        var span = document.getElementsByClassName("close")[0];

        // When the user clicks the button, open the modal 
        btn.onclick = function () {
            modal.style.display = "block";
        }

        // When the user clicks on <span> (x), close the modal
        span.onclick = function () {
            modal.style.display = "none";
        }

        // When the user clicks anywhere outside of the modal, close it
        window.onclick = function (event) {
            if (event.target == modal) {
                modal.style.display = "none";
            }
        }

    </script>


</asp:Content>
