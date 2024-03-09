<%@ Page Title="" Language="C#" MasterPageFile="~/Contents.Master" AutoEventWireup="true" CodeBehind="CoinShop.aspx.cs" Inherits="AlphaFitness.Dashboard.CoinShop" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="CoinShop.css" rel="stylesheet" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <div class="home-content">
        <div class="heading" id="header">
            <asp:Button OnClick="btnTitle_Click" runat="server" CssClass="btnTop" ID="btnTitle" Text="User Title" Style="border-bottom: 4px solid #ffbb00; background-color: #ffdc7a" />
            <asp:Button OnClick="btnContent_Click" runat="server" CssClass="btnTop" ID="btnContent" Text="Contents" />
        </div>



        <!--Should use update panel-->
        <div class="contents">
            <div class="item-container group">

                <asp:Repeater runat="server" ID="itemRepeater">
                    <ItemTemplate>
                        <!--An Item-->
                        <div class="item">
                            <div class="item-image">
                                <asp:Image runat="server" Style="border-radius: 8px;" CssClass="imgFigure" ID="img" ImageUrl='<%# Eval("Category").Equals("Title") ? Eval("ItemUrl") : "~/Image/Element/pdf.png" %>' />
                            </div>
                            <div class="detail-cont">
                                <div class="item-name">
                                    <asp:Label ID="lblName" CssClass="sentence" runat="server" Text='<%# Eval("ItemName") %>'></asp:Label>
                                </div>
                                <div class="item-price">
                                    <i class='bx bx-coin' style="color: gold; margin-top: 3px;"></i>&nbsp;<asp:Label ID="lblPrice" runat="server" Text='<%# Eval("RequireCoin") + " Coins"%>'></asp:Label>
                                </div>
                                <div class="item-details">
                                    <div class="item-buy">
                                        <asp:LinkButton runat="server" OnClientClick="return confirm('Are you sure you want to buy this item?')">
                                        <i class="fa-solid fa-cart-shopping"></i>&nbsp;Buy
                                        </asp:LinkButton>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </ItemTemplate>


                </asp:Repeater>

            </div>
        </div>

        <!--Click this button back to top of the page-->
        <div class="toTop" id="toTop">
            <asp:LinkButton OnClientClick="toTop();" ID="top" runat="server">
            <i style="border-radius: 50px; background-color:gold; padding: 10px 12.5px 10px 12.5px; color:black; font-size: 20px;" class="fa-solid fa-arrow-up"></i>
            </asp:LinkButton>
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



            //top button - title
            function title() {
                let btnTitle = document.getElementById('<%= btnTitle.ClientID %>');
                let btnContent = document.getElementById('<%= btnContent.ClientID %>');

                btnTitle.style.borderBottom = "4px solid #ffbb00";
                btnTitle.style.backgroundColor = "#ffdc7a";

                btnContent.style.borderBottom = "none";
                btnContent.style.backgroundColor = "#fff1a5";
            }


            //top button - Content
            function content() {
                let btnTitle2 = document.getElementById('<%= btnTitle.ClientID %>');
                let btnContent2 = document.getElementById('<%= btnContent.ClientID %>');

                btnContent2.style.borderBottom = "4px solid #ffbb00";
                btnContent2.style.backgroundColor = "#ffdc7a";

                btnTitle2.style.borderBottom = "none";
                btnTitle2.style.backgroundColor = "#fff1a5";
            }

        </script>

    </div>
</asp:Content>
