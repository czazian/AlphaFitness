<%@ Page Title="" Language="C#" EnableEventValidation="false" MasterPageFile="~/Contents.Master" AutoEventWireup="true" CodeBehind="Post.aspx.cs" Inherits="AlphaFitness.Community.Post" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="Post.css" rel="stylesheet" />
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="home-content">

        <div class="outer">

            <div class="heading" id="target">
                <div class="backBtn">
                    <asp:LinkButton CausesValidation="false" CssClass="bt" runat="server" PostBackUrl="~/Community/Community.aspx">
                        <i class="fa-solid fa-arrow-left"></i>&nbsp;&nbsp;Back
                    </asp:LinkButton>
                </div>
            </div>

            <div class="main-title" style="justify-content: left;">
                <table style="margin-bottom: 5px;" class="lbl">
                    <tr>
                        <td class="title" style="padding-right: 10px;">
                            <b>Title:</b>
                        </td>
                        <td>
                            <b>
                                <asp:Label Style="text-align: center; max-width: 100%; word-break: break-word;" runat="server" ID="lblTitle" /></b>
                        </td>
                    </tr>
                </table>
            </div>

            <hr />

            <!--a post-->
            <div class="post">
                <div class="top-community">
                    <div class="person-image">
                        <asp:Image CausesValidation="false" runat="server" ID="postedUserImage" Width="70" Height="70" Style="border-radius: 10px;" />
                    </div>
                </div>
                <div class="middle-community" style="width: 100%;">
                    <div class="person-detail">
                        <div class="infobar">
                            <div class="person-name">
                                <asp:Label runat="server" ID="postedUser" />
                            </div>
                            <div class="title-obtain">
                                <asp:Image runat="server" ID="img" CssClass="titleImg" />
                            </div>
                        </div>
                        <div class="person-date">
                            <asp:Label runat="server" ID="postedDate" />
                        </div>
                    </div>
                    <div class="comment">
                        <asp:Label runat="server" ID="comment" />
                    </div>
                    <div class="buttons">
                        <div class="like-btn">
                            <asp:LinkButton CausesValidation="false" OnClick="LikeClick_Click" ID="LikeClick" runat="server"><i style="color:palevioletred; opacity:1.0;" class="fa-regular fa-heart"></i></asp:LinkButton>&nbsp;<asp:Label runat="server" ID="numOfLikes" />&nbsp;Likes
                        </div>
                        <div class="comment-btn">
                            <i class="fa-regular fa-comment-dots"></i>&nbsp;<asp:Label runat="server" ID="numOfComments" />&nbsp;Comments
                        </div>
                    </div>


                    <!--Write comment-->
                    <div style="display:flex;flex-flow: column nowrap;">
                        <div class="write-comment">

                            <asp:TextBox runat="server" placeholder="Comment here..." ID="txtWrite" CssClass="write-box-inside" />

                            <div class="submit-box">
                                <asp:LinkButton OnClick="btnWrite_Click" runat="server" Style="border-radius: 50%;" ID="btnWrite" CssClass="submit-box-inside">
                                <i class='bx bx-paper-plane'></i>
                                </asp:LinkButton>
                            </div>
                        </div>
                        <div style="margin-top: -5px; margin-bottom: 15px; font-size: 15px;">
                            <asp:RequiredFieldValidator Display="Dynamic" CssClass="validator" ID="RequiredFieldValidator2" runat="server" ErrorMessage="Please do not leave comment empty." ControlToValidate="txtWrite" ForeColor="Red"></asp:RequiredFieldValidator>
                        </div>
                    </div>


                    <!--One comment-->
                    <asp:Repeater runat="server" ID="commentRepeater" OnItemDataBound="commentRepeater_ItemDataBound">
                        <ItemTemplate>

                            <asp:HiddenField runat="server" ID="userID" Value='<%# Eval("UserID") %>' />

                            <div class="bottom-community">
                                <div class="commenter-image">
                                    <asp:ImageButton OnCommand="commenterImg_Command" CommandArgument='<%# Eval("UserID") %>' CausesValidation="false" ImageUrl='<%# Eval("ProfileImage") %>' runat="server" ID="commenterImg" Width="58" Height="58" Style="border-radius: 10px;" />
                                </div>
                                <div class="commenter-container">
                                    <div class="commenter-detail">
                                        <div class="infobar-comment">
                                            <div class="commenter-name">
                                                <asp:Label runat="server" Text='<%# Eval("UserName") %>' />
                                            </div>
                                            <div class="title-obtain">
                                                <asp:Image runat="server" ID="img" CssClass="titleImg" ImageUrl='<%# Eval("EquippedImageUrl") %>' />
                                            </div>
                                        </div>
                                        <div class="commenter-date">
                                            <asp:Label runat="server" Text='<%# Eval("CommentTime") %>' />
                                        </div>
                                    </div>
                                    <div class="commenter-comment">
                                        <asp:Label runat="server" ID="commenterComment" Text='<%# Eval("CommentContent") %>' />
                                    </div>
                                </div>
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>
                    <!--End of tne comment-->


                </div>
            </div>
            <!--end a post-->



            <!--Click this button back to top of the page-->
            <div class="toTop" id="toTop">
                <asp:LinkButton CausesValidation="false" OnClientClick="toTop() ;" ID="top" runat="server">
            <i style="border-radius: 50px; background-color:gold; padding: 10px 12.5px 10px 12.5px; color:black; font-size: 20px;" class="fa-solid fa-arrow-up"></i>
                </asp:LinkButton>
            </div>
        </div>
    </div>
    <script>
        window.addEventListener("scroll", function () {
            let box = document.getElementById("toTop");
            var elementTarget = document.getElementById("target");
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
            alert("You have successfully leave a comment.");
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
