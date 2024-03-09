<%@ Page Title="" Language="C#" MasterPageFile="~/Contents.Master" AutoEventWireup="true" CodeBehind="Community.aspx.cs" Inherits="AlphaFitness.Community.Community" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="Community.css" rel="stylesheet" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="home-content">
        <div class="header-community" id="header">
            <div class="leftbox">
                <div class="numberofposts">
                    <i style="color: gold" class="fa-solid fa-signs-post">&nbsp;&nbsp;</i><asp:Label Style="font-weight: 500;" runat="server" ID="numOfPosts" Text="4" />
                    Posts
                </div>
                <div class="date">
                    <i style="color: gold" class='bx bxs-calendar'></i>
                    <asp:Label runat="server" ID="currentTime" Text="Mar, 10 2024" />
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
                        </div>
                    </div>

                    <div class="content">
                        <div class="content-title">
                            Description
                        </div>
                        <div class="content-field">
                            <asp:TextBox runat="server" ID="txtContent" TextMode="MultiLine" CssClass="txtPost" />
                        </div>
                    </div>

                    <div class="submit-post">
                        <asp:Button runat="server" CssClass="cancel" ID="cancel" Text="Cancel" />
                        <asp:Button runat="server" CssClass="submitPost" ID="submit" Text="Submit" />
                    </div>
                </div>
            </div>

        </div>




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
                        <div class="title-obtain">
                            <asp:Image runat="server" ID="img" CssClass="titleImg" ImageUrl="~/Image/Title/9.png" />
                        </div>
                    </div>
                    <div class="person-date">
                        Mar, 10 2024 - 9:50 p.m.
                    </div>
                </div>
                <div class="comment">
                    <table style="margin-bottom: 5px;">
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
                <hr />
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
                                <div class="title-obtain">
                                    <asp:Image runat="server" ID="Image9" CssClass="titleImgComment" ImageUrl="~/Image/Title/4.png" />
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
                <div class="view-more">
                    <asp:HyperLink runat="server" ID="btnview" Text="VIEW THE POST" NavigateUrl="~/Community/Post.aspx" />
                </div>
            </div>
        </div>
        <!--end a post-->



        <!--a post-->
        <div class="post">
            <div class="top-community">
                <div class="person-image">
                    <asp:Image ImageUrl="~/Image/Profile/user.jpg" runat="server" ID="Image3" Width="70" Height="70" Style="border-radius: 10px;" />
                </div>
            </div>
            <div class="middle-community">
                <div class="person-detail">
                    <div class="infobar">
                        <div class="person-name">
                            Yiyang_0519
                        </div>
                        <div class="title-obtain">
                            <asp:Image runat="server" ID="Image4" CssClass="titleImg" ImageUrl="~/Image/Title/5.png" />
                        </div>
                    </div>
                    <div class="person-date">
                        Mar, 10 2024 - 9:50 p.m.
                    </div>
                </div>
                <div class="comment">
                    <table style="margin-bottom: 5px;">
                        <tr>
                            <td class="title" style="padding-right: 10px;">
                                <b>Title:</b>
                            </td>
                            <td>
                                <b>
                                    <asp:Label runat="server" ID="Label1" Text="I am facing a serious problem! Help!I am facing a serious problem! Help!I am facing a serious problem! Help!I am facing a serious problem! Help!" /></b>
                            </td>
                        </tr>
                    </table>
                    <asp:Label runat="server" ID="Label2" Text="Hey there! I've been sticking to my workout routine for a while, but I feel like I've hit a plateau. Any suggestions on how to spice things up and keep making progress? Also, any tips for staying motivated when things get a bit monotonous?" />
                </div>
                <div class="buttons">
                    <div class="like-btn">
                        <asp:LinkButton runat="server"><i style="color:palevioletred; opacity:1.0;" class="fa-regular fa-heart"></i></asp:LinkButton>&nbsp;<asp:Label runat="server" ID="Label3" Text="20" />&nbsp;Likes
                    </div>
                    <div class="comment-btn">
                        <i class="fa-regular fa-comment-dots"></i>&nbsp;<asp:Label runat="server" ID="Label4" Text="5" />&nbsp;Comments
                    </div>
                </div>
                <hr />
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
                                <div class="title-obtain">
                                    <asp:Image runat="server" ID="Image6" CssClass="titleImgComment" ImageUrl="~/Image/Title/4.png" />
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
                <div class="view-more">
                    <asp:HyperLink runat="server" ID="HyperLink1" Text="VIEW THE POST" NavigateUrl="~/Community/Post.aspx" />
                </div>
            </div>
        </div>
        <!--end a post-->

        <!--a post-->
        <div class="post">
            <div class="top-community">
                <div class="person-image">
                    <asp:Image ImageUrl="~/Image/Profile/user.jpg" runat="server" ID="Image7" Width="70" Height="70" Style="border-radius: 10px;" />
                </div>
            </div>
            <div class="middle-community">
                <div class="person-detail">
                    <div class="infobar">
                        <div class="person-name">
                            Yiyang_0519
                        </div>
                        <div class="title-obtain">
                            <asp:Image runat="server" ID="Image8" CssClass="titleImg" ImageUrl="~/Image/Title/5.png" />
                        </div>
                    </div>
                    <div class="person-date">
                        Mar, 10 2024 - 9:50 p.m.
                    </div>
                </div>
                <div class="comment">
                    <table style="margin-bottom: 5px;">
                        <tr>
                            <td class="title" style="padding-right: 10px;">
                                <b>Title:</b>
                            </td>
                            <td>
                                <b>
                                    <asp:Label runat="server" ID="Label6" Text="I am facing a serious problem! Help!I am facing a serious problem! Help!I am facing a serious problem! Help!I am facing a serious problem! Help!" /></b>
                            </td>
                        </tr>
                    </table>
                    <asp:Label runat="server" ID="Label7" Text="Hey there! I've been sticking to my workout routine for a while, but I feel like I've hit a plateau. Any suggestions on how to spice things up and keep making progress? Also, any tips for staying motivated when things get a bit monotonous?" />
                </div>
                <div class="buttons">
                    <div class="like-btn">
                        <asp:LinkButton runat="server"><i style="color:palevioletred; opacity:1.0;" class="fa-regular fa-heart"></i></asp:LinkButton>&nbsp;<asp:Label runat="server" ID="Label8" Text="20" />&nbsp;Likes
                    </div>
                    <div class="comment-btn">
                        <i class="fa-regular fa-comment-dots"></i>&nbsp;<asp:Label runat="server" ID="Label9" Text="5" />&nbsp;Comments
                    </div>
                </div>
                <hr />
                <div class="bottom-community">
                    <div class="commenter-image">
                        <asp:Image ImageUrl="~/Image/Profile/user.png" runat="server" ID="Image10" Width="58" Height="58" Style="border-radius: 10px;" />
                    </div>
                    <div class="commenter-container">
                        <div class="commenter-detail">
                            <div class="infobar-comment">
                                <div class="commenter-name">
                                    AndrewYeo
                                </div>
                                <div class="title-obtain">
                                    <asp:Image runat="server" ID="Image11" CssClass="titleImgComment" ImageUrl="~/Image/Title/4.png" />
                                </div>
                            </div>
                            <div class="commenter-date">
                                Mar, 10 2024 - 9:55 p.m.
                            </div>
                        </div>
                        <div class="commenter-comment">
                            <asp:Label runat="server" ID="Label10" Text="Things it yourself stupid!Things it yourself stupid!Things it yourself stupid!Things it yourself stupid!Things it yourself stupid!Things it yourself stupid!Things it yourself stupid!Things it yourself stupid!Things it yourself stupid!Things it yourself stupid!Things it yourself stupid!Things it yourself stupid!" />
                        </div>
                    </div>
                </div>
                <div class="view-more">
                    <asp:HyperLink runat="server" ID="HyperLink2" Text="VIEW THE POST" NavigateUrl="~/Community/Post.aspx" />
                </div>
            </div>
        </div>
        <!--end a post-->

        <!--a post-->
        <div class="post">
            <div class="top-community">
                <div class="person-image">
                    <asp:Image ImageUrl="~/Image/Profile/user.jpg" runat="server" ID="Image12" Width="70" Height="70" Style="border-radius: 10px;" />
                </div>
            </div>
            <div class="middle-community">
                <div class="person-detail">
                    <div class="infobar">
                        <div class="person-name">
                            Yiyang_0519
                        </div>
                        <div class="title-obtain">
                            <asp:Image runat="server" ID="Image13" CssClass="titleImg" ImageUrl="~/Image/Title/5.png" />
                        </div>
                    </div>
                    <div class="person-date">
                        Mar, 10 2024 - 9:50 p.m.
                    </div>
                </div>
                <div class="comment">
                    <table style="margin-bottom: 5px;">
                        <tr>
                            <td class="title" style="padding-right: 10px;">
                                <b>Title:</b>
                            </td>
                            <td>
                                <b>
                                    <asp:Label runat="server" ID="Label11" Text="I am facing a serious problem! Help!I am facing a serious problem! Help!I am facing a serious problem! Help!I am facing a serious problem! Help!" /></b>
                            </td>
                        </tr>
                    </table>
                    <asp:Label runat="server" ID="Label12" Text="Hey there! I've been sticking to my workout routine for a while, but I feel like I've hit a plateau. Any suggestions on how to spice things up and keep making progress? Also, any tips for staying motivated when things get a bit monotonous?" />
                </div>
                <div class="buttons">
                    <div class="like-btn">
                        <asp:LinkButton runat="server"><i style="color:palevioletred; opacity:1.0;" class="fa-regular fa-heart"></i></asp:LinkButton>&nbsp;<asp:Label runat="server" ID="Label13" Text="20" />&nbsp;Likes
                    </div>
                    <div class="comment-btn">
                        <i class="fa-regular fa-comment-dots"></i>&nbsp;<asp:Label runat="server" ID="Label14" Text="5" />&nbsp;Comments
                    </div>
                </div>
                <hr />
                <div class="bottom-community">
                    <div class="commenter-image">
                        <asp:Image ImageUrl="~/Image/Profile/user.png" runat="server" ID="Image14" Width="58" Height="58" Style="border-radius: 10px;" />
                    </div>
                    <div class="commenter-container">
                        <div class="commenter-detail">
                            <div class="infobar-comment">
                                <div class="commenter-name">
                                    AndrewYeo
                                </div>
                                <div class="title-obtain">
                                    <asp:Image runat="server" ID="Image15" CssClass="titleImgComment" ImageUrl="~/Image/Title/4.png" />
                                </div>
                            </div>
                            <div class="commenter-date">
                                Mar, 10 2024 - 9:55 p.m.
                            </div>
                        </div>
                        <div class="commenter-comment">
                            <asp:Label runat="server" ID="Label15" Text="Things it yourself stupid!Things it yourself stupid!Things it yourself stupid!Things it yourself stupid!Things it yourself stupid!Things it yourself stupid!Things it yourself stupid!Things it yourself stupid!Things it yourself stupid!Things it yourself stupid!Things it yourself stupid!Things it yourself stupid!" />
                        </div>
                    </div>
                </div>
                <div class="view-more">
                    <asp:HyperLink runat="server" ID="HyperLink3" Text="VIEW THE POST" NavigateUrl="~/Community/Post.aspx" />
                </div>
            </div>
        </div>
        <!--end a post-->

        <!--a post-->
        <div class="post">
            <div class="top-community">
                <div class="person-image">
                    <asp:Image ImageUrl="~/Image/Profile/user.jpg" runat="server" ID="Image16" Width="70" Height="70" Style="border-radius: 10px;" />
                </div>
            </div>
            <div class="middle-community">
                <div class="person-detail">
                    <div class="infobar">
                        <div class="person-name">
                            Yiyang_0519
                        </div>
                        <div class="title-obtain">
                            <asp:Image runat="server" ID="Image17" CssClass="titleImg" ImageUrl="~/Image/Title/5.png" />
                        </div>
                    </div>
                    <div class="person-date">
                        Mar, 10 2024 - 9:50 p.m.
                    </div>
                </div>
                <div class="comment">
                    <table style="margin-bottom: 5px;">
                        <tr>
                            <td class="title" style="padding-right: 10px;">
                                <b>Title:</b>
                            </td>
                            <td>
                                <b>
                                    <asp:Label runat="server" ID="Label16" Text="I am facing a serious problem! Help!I am facing a serious problem! Help!I am facing a serious problem! Help!I am facing a serious problem! Help!" /></b>
                            </td>
                        </tr>
                    </table>
                    <asp:Label runat="server" ID="Label17" Text="Hey there! I've been sticking to my workout routine for a while, but I feel like I've hit a plateau. Any suggestions on how to spice things up and keep making progress? Also, any tips for staying motivated when things get a bit monotonous?" />
                </div>
                <div class="buttons">
                    <div class="like-btn">
                        <asp:LinkButton runat="server"><i style="color:palevioletred; opacity:1.0;" class="fa-regular fa-heart"></i></asp:LinkButton>&nbsp;<asp:Label runat="server" ID="Label18" Text="20" />&nbsp;Likes
                    </div>
                    <div class="comment-btn">
                        <i class="fa-regular fa-comment-dots"></i>&nbsp;<asp:Label runat="server" ID="Label19" Text="5" />&nbsp;Comments
                    </div>
                </div>
                <hr />
                <div class="bottom-community">
                    <div class="commenter-image">
                        <asp:Image ImageUrl="~/Image/Profile/user.png" runat="server" ID="Image18" Width="58" Height="58" Style="border-radius: 10px;" />
                    </div>
                    <div class="commenter-container">
                        <div class="commenter-detail">
                            <div class="infobar-comment">
                                <div class="commenter-name">
                                    AndrewYeo
                                </div>
                                <div class="title-obtain">
                                    <asp:Image runat="server" ID="Image19" CssClass="titleImgComment" ImageUrl="~/Image/Title/4.png" />
                                </div>
                            </div>
                            <div class="commenter-date">
                                Mar, 10 2024 - 9:55 p.m.
                            </div>
                        </div>
                        <div class="commenter-comment">
                            <asp:Label runat="server" ID="Label20" Text="Things it yourself stupid!Things it yourself stupid!Things it yourself stupid!Things it yourself stupid!Things it yourself stupid!Things it yourself stupid!Things it yourself stupid!Things it yourself stupid!Things it yourself stupid!Things it yourself stupid!Things it yourself stupid!Things it yourself stupid!" />
                        </div>
                    </div>
                </div>
                <div class="view-more">
                    <asp:HyperLink runat="server" ID="HyperLink4" Text="VIEW THE POST" NavigateUrl="~/Community/Post.aspx" />
                </div>
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
