<%@ Page Title="" Language="C#" MasterPageFile="~/Contents.Master" AutoEventWireup="true" CodeBehind="Post.aspx.cs" Inherits="AlphaFitness.Community.Post" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="Post.css" rel="stylesheet" />
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="home-content">

        <div class="outer">

            <div class="heading"  id="target">
                <div class="backBtn">
                    <asp:LinkButton CssClass="bt" runat="server" PostBackUrl="~/Community/Community.aspx">
                        <i class="fa-solid fa-arrow-left"></i>&nbsp;&nbsp;Back
                    </asp:LinkButton>
                </div>
            </div>

            <div class="main-title">
                <table style="margin-bottom: 5px;" class="lbl">
                    <tr>
                        <td class="title" style="padding-right: 10px;">
                            <b>Title:</b>
                        </td>
                        <td>
                            <b>
                                <asp:Label runat="server" ID="lblTitle" Text="I am facing a serious problem! Help!I am facing a serious problem! Help!I am facing a serious problem! Help!I am facing a serious problem! Help!" /></b>
                        </td>
                    </tr>
                </table>
            </div>

            <hr />

            <!--a post-->
            <div class="post">
                <div class="top-community">
                    <div class="person-image">

                        <asp:Image ImageUrl="~/Image/Profile/user.jpg" runat="server" ID="Image1" Width="70" Height="70" Style="border-radius: 10px;" />
                    </div>
                </div>
                <div class="middle-community">
                    <div class="person-detail">
                        <div class="infobar">
                            <div class="person-name">
                                Yiyang_0519
                            </div>
                            <div class="title-obtain" style="border: 1px solid black; background-color: gold; border-radius: 8px;">
                                <asp:Label runat="server" ID="title" Text="Sport King" />
                            </div>
                        </div>
                        <div class="person-date">
                            Mar, 10 2024 - 9:50 p.m.
                        </div>
                    </div>
                    <div class="comment">
                        <asp:Label runat="server" ID="comment" Text="Hey there! I've been sticking to my workout routine for a while, but I feel like I've hit a plateau. Any suggestions on how to spice things up and keep making progress? Also, any tips for staying motivated when things get a bit monotonous?" />
                    </div>
                    <div class="buttons">
                        <div class="like-btn">
                            <asp:LinkButton runat="server"><i style="color:palevioletred; opacity:1.0;" class="fa-regular fa-heart"></i></asp:LinkButton>&nbsp;<asp:Label runat="server" ID="numOfLikes" Text="20" />&nbsp;Likes
                        </div>
                        <div class="comment-btn">
                            <i class="fa-regular fa-comment-dots"></i>&nbsp;<asp:Label runat="server" ID="numOfComments" Text="5" />&nbsp;Comments
                        </div>
                    </div>


                    <!--Write comment-->
                    <div class="write-comment">

                        <asp:TextBox runat="server" placeholder="Comment here..." ID="txtWrite" CssClass="write-box-inside" />

                        <div class="submit-box">
                            <asp:LinkButton runat="server" Style="border-radius: 50%;" ID="btnWrite" CssClass="submit-box-inside">
                                <i class='bx bx-paper-plane'></i>
                            </asp:LinkButton>
                        </div>
                    </div>



                    <!--One comment-->
                    <div class="bottom-community">
                        <div class="commenter-image">
                            <asp:Image ImageUrl="~/Image/Profile/user.png" runat="server" ID="Image2" Width="58" Height="58" Style="border-radius: 10px;" />
                        </div>
                        <div class="commenter-container">
                            <div class="commenter-detail">
                                <div class="infobar-comment">
                                    <div class="commenter-name">
                                        AndrewYeo
                                    </div>
                                    <div class="title-obtain" style="border: 1px solid black; background-color: gold; border-radius: 8px;">
                                        <asp:Label runat="server" ID="Label2" Text="24 Hours Sport King" />
                                    </div>
                                </div>
                                <div class="commenter-date">
                                    Mar, 10 2024 - 9:55 p.m.
                                </div>
                            </div>
                            <div class="commenter-comment">
                                <asp:Label runat="server" ID="commenterComment" Text="Things it yourself stupid!Things it yourself stupid!Things it yourself stupid!Things it yourself stupid!Things it yourself stupid!Things it yourself stupid!Things it yourself stupid!Things it yourself stupid!Things it yourself stupid!Things it yourself stupid!Things it yourself stupid!Things it yourself stupid!" />
                            </div>
                        </div>
                    </div>
                    <!--End of tne comment-->

                    <!--One comment-->
                    <div class="bottom-community">
                        <div class="commenter-image">
                            <asp:Image ImageUrl="~/Image/Profile/user.png" runat="server" ID="Image3" Width="58" Height="58" Style="border-radius: 10px;" />
                        </div>
                        <div class="commenter-container">
                            <div class="commenter-detail">
                                <div class="infobar-comment">
                                    <div class="commenter-name">
                                        AndrewYeo
                                    </div>
                                    <div class="title-obtain" style="border: 1px solid black; background-color: gold; border-radius: 8px;">
                                        <asp:Label runat="server" ID="Label1" Text="24 Hours Sport King" />
                                    </div>
                                </div>
                                <div class="commenter-date">
                                    Mar, 10 2024 - 9:55 p.m.
                                </div>
                            </div>
                            <div class="commenter-comment">
                                <asp:Label runat="server" ID="Label3" Text="Things it yourself stupid!Things it yourself stupid!Things it yourself stupid!Things it yourself stupid!Things it yourself stupid!Things it yourself stupid!Things it yourself stupid!Things it yourself stupid!Things it yourself stupid!Things it yourself stupid!Things it yourself stupid!Things it yourself stupid!" />
                            </div>
                        </div>
                    </div>
                    <!--End of tne comment-->

                    <!--One comment-->
                    <div class="bottom-community">
                        <div class="commenter-image">
                            <asp:Image ImageUrl="~/Image/Profile/user.png" runat="server" ID="Image4" Width="58" Height="58" Style="border-radius: 10px;" />
                        </div>
                        <div class="commenter-container">
                            <div class="commenter-detail">
                                <div class="infobar-comment">
                                    <div class="commenter-name">
                                        AndrewYeo
                                    </div>
                                    <div class="title-obtain" style="border: 1px solid black; background-color: gold; border-radius: 8px;">
                                        <asp:Label runat="server" ID="Label4" Text="24 Hours Sport King" />
                                    </div>
                                </div>
                                <div class="commenter-date">
                                    Mar, 10 2024 - 9:55 p.m.
                                </div>
                            </div>
                            <div class="commenter-comment">
                                <asp:Label runat="server" ID="Label5" Text="Things it yourself stupid!Things it yourself stupid!Things it yourself stupid!Things it yourself stupid!Things it yourself stupid!Things it yourself stupid!Things it yourself stupid!Things it yourself stupid!Things it yourself stupid!Things it yourself stupid!Things it yourself stupid!Things it yourself stupid!" />
                            </div>
                        </div>
                    </div>
                    <!--End of tne comment-->

                    <!--One comment-->
                    <div class="bottom-community">
                        <div class="commenter-image">
                            <asp:Image ImageUrl="~/Image/Profile/user.png" runat="server" ID="Image5" Width="58" Height="58" Style="border-radius: 10px;" />
                        </div>
                        <div class="commenter-container">
                            <div class="commenter-detail">
                                <div class="infobar-comment">
                                    <div class="commenter-name">
                                        AndrewYeo
                                    </div>
                                    <div class="title-obtain" style="border: 1px solid black; background-color: gold; border-radius: 8px;">
                                        <asp:Label runat="server" ID="Label6" Text="24 Hours Sport King" />
                                    </div>
                                </div>
                                <div class="commenter-date">
                                    Mar, 10 2024 - 9:55 p.m.
                                </div>
                            </div>
                            <div class="commenter-comment">
                                <asp:Label runat="server" ID="Label7" Text="Things it yourself stupid!Things it yourself stupid!Things it yourself stupid!Things it yourself stupid!Things it yourself stupid!Things it yourself stupid!Things it yourself stupid!Things it yourself stupid!Things it yourself stupid!Things it yourself stupid!Things it yourself stupid!Things it yourself stupid!" />
                            </div>
                        </div>
                    </div>
                    <!--End of tne comment-->

                    <!--One comment-->
                    <div class="bottom-community">
                        <div class="commenter-image">
                            <asp:Image ImageUrl="~/Image/Profile/user.png" runat="server" ID="Image6" Width="58" Height="58" Style="border-radius: 10px;" />
                        </div>
                        <div class="commenter-container">
                            <div class="commenter-detail">
                                <div class="infobar-comment">
                                    <div class="commenter-name">
                                        AndrewYeo
                                    </div>
                                    <div class="title-obtain" style="border: 1px solid black; background-color: gold; border-radius: 8px;">
                                        <asp:Label runat="server" ID="Label8" Text="24 Hours Sport King" />
                                    </div>
                                </div>
                                <div class="commenter-date">
                                    Mar, 10 2024 - 9:55 p.m.
                                </div>
                            </div>
                            <div class="commenter-comment">
                                <asp:Label runat="server" ID="Label9" Text="Things it yourself stupid!Things it yourself stupid!Things it yourself stupid!Things it yourself stupid!Things it yourself stupid!Things it yourself stupid!Things it yourself stupid!Things it yourself stupid!Things it yourself stupid!Things it yourself stupid!Things it yourself stupid!Things it yourself stupid!" />
                            </div>
                        </div>
                    </div>
                    <!--End of tne comment-->
                </div>
            </div>
            <!--end a post-->



            <!--Click this button back to top of the page-->
            <div class="toTop" id="toTop">
                <asp:LinkButton OnClientClick="toTop() ;" ID="top" runat="server">
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
