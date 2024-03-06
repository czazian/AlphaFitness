<%@ Page Title="" Language="C#" MasterPageFile="~/Contents.Master" AutoEventWireup="true" CodeBehind="CoinShop.aspx.cs" Inherits="AlphaFitness.Dashboard.CoinShop" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="CoinShop.css" rel="stylesheet" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <div class="home-content">
        <div class="heading" id="header">
            <asp:Button runat="server" CssClass="btnTop" ID="btnTitle" Text="User Title" Style="border-bottom:4px solid #ffbb00; background-color:#ffdc7a"/>
            <asp:Button runat="server" CssClass="btnTop" ID="btnContent" Text="Contents" />
        </div>



        <!--Should use update panel-->
        <div class="contents">
            <div class="item-container group">

                <!--An Item-->
                <div class="item">
                    <div class="item-image">
                        <asp:Image runat="server" CssClass="imgFigure" ID="Image8" ImageUrl="~/Image/Element/logo2.png" />
                    </div>
                    <div class="detail-cont">
                        <div class="item-name">
                            <asp:Label ID="lblName" CssClass="sentence" runat="server" Text='TITLE'></asp:Label>
                        </div>
                        <div class="item-price">
                            <asp:Label ID="lblPrice" runat="server" Text='1000 Coins'></asp:Label>
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

                <!--An Item-->
                <div class="item">
                    <div class="item-image">
                        <asp:Image runat="server" CssClass="imgFigure" ID="Image1" ImageUrl="~/Image/Element/logo1.png" />
                    </div>
                    <div class="detail-cont">
                        <div class="item-name">
                            <asp:Label ID="Label1" CssClass="sentence" runat="server" Text='TITLE'></asp:Label>
                        </div>
                        <div class="item-price">
                            <asp:Label ID="Label2" runat="server" Text='1000 Coins'></asp:Label>
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

                <!--An Item-->
                <div class="item">
                    <div class="item-image">
                        <asp:Image runat="server" CssClass="imgFigure" ID="Image2" ImageUrl="~/Image/Element/logo2.png" />
                    </div>
                    <div class="detail-cont">
                        <div class="item-name">
                            <asp:Label ID="lblTitle" CssClass="sentence" runat="server" Text='TITLE'></asp:Label>
                        </div>
                        <div class="item-price">
                            <asp:Label ID="lblCoin" runat="server" Text='1000 Coins'></asp:Label>
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

                <!--An Item-->
                <div class="item">
                    <div class="item-image">
                        <asp:Image runat="server" CssClass="imgFigure" ID="Image3" ImageUrl="~/Image/Element/logo2.png" />
                    </div>
                    <div class="detail-cont">
                        <div class="item-name">
                            <asp:Label ID="Label5" CssClass="sentence" runat="server" Text='TITLE'></asp:Label>
                        </div>
                        <div class="item-price">
                            <asp:Label ID="Label6" runat="server" Text='1000 Coins'></asp:Label>
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

                <!--An Item-->
                <div class="item">
                    <div class="item-image">
                        <asp:Image runat="server" CssClass="imgFigure" ID="Image4" ImageUrl="~/Image/Element/logo2.png" />
                    </div>
                    <div class="detail-cont">
                        <div class="item-name">
                            <asp:Label ID="Label7" CssClass="sentence" runat="server" Text='TITLE'></asp:Label>
                        </div>
                        <div class="item-price">
                            <asp:Label ID="Label8" runat="server" Text='1000 Coins'></asp:Label>
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

                <!--An Item-->
                <div class="item">
                    <div class="item-image">
                        <asp:Image runat="server" CssClass="imgFigure" ID="Image5" ImageUrl="~/Image/Element/logo2.png" />
                    </div>
                    <div class="detail-cont">
                        <div class="item-name">
                            <asp:Label ID="Label9" CssClass="sentence" runat="server" Text='TITLE'></asp:Label>
                        </div>
                        <div class="item-price">
                            <asp:Label ID="Label10" runat="server" Text='1000 Coins'></asp:Label>
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

                <!--An Item-->
                <div class="item">
                    <div class="item-image">
                        <asp:Image runat="server" CssClass="imgFigure" ID="Image6" ImageUrl="~/Image/Element/pdf.png" />
                    </div>
                    <div class="detail-cont">
                        <div class="item-name">
                            <asp:Label ID="Label11" CssClass="sentence" runat="server" Text='TITLE'></asp:Label>
                        </div>
                        <div class="item-price">
                            <asp:Label ID="Label12" runat="server" Text='1000 Coins'></asp:Label>
                        </div>
                        <div class="item-buy">
                            <asp:LinkButton runat="server" OnClientClick="return confirm('Are you sure you want to buy this item?')">
                                   <i class="fa-solid fa-cart-shopping"></i>&nbsp;Buy
                            </asp:LinkButton>
                        </div>
                    </div>
                </div>

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

            //top button
            let btnTitle = document.getElementById('<%= btnTitle.ClientID %>');
            let btnContent = document.getElementById('<%= btnContent.ClientID %>');

            btnTitle.addEventListener("click", function () {
                btnTitle.style.borderBottom = "4px solid #ffbb00";
                btnTitle.style.backgroundColor = "#ffdc7a";

                btnContent.style.borderBottom = "none";
                btnContent.style.backgroundColor = "#fff1a5";
            });

            btnContent.addEventListener("click", function () {
                btnContent.style.borderBottom = "4px solid #ffbb00";
                btnContent.style.backgroundColor = "#ffdc7a";

                btnTitle.style.borderBottom = "none";
                btnTitle.style.backgroundColor = "#fff1a5";
            });

        </script>

    </div>
</asp:Content>
