<%@ Page Title="" Language="C#" MasterPageFile="~/Contents.Master" AutoEventWireup="true" CodeBehind="FoodTracking.aspx.cs" Inherits="AlphaFitness.Food.FoodTracking" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="FoodTracking.css" rel="stylesheet" />
    <title>FoodTracking</title>
    <style type="text/css">
        .auto-style1 {
            width: 112px;
        }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="FoodTracking.css" rel="stylesheet" />
    <div class="main-content">

        <div class="main-boxes">
            <div class="recent-main box">
                <div class="title">Calory Intake of xxxxx</div>
            </div>
        </div>

        <div class="calorie-box">
            <asp:DropDownList ID="FoodList" runat="server"></asp:DropDownList><asp:DropDownList ID="FoodQuantity" runat="server">
                <asp:ListItem>1</asp:ListItem>
                <asp:ListItem>2</asp:ListItem>
                <asp:ListItem>3</asp:ListItem>
                <asp:ListItem>4</asp:ListItem>
                <asp:ListItem>5</asp:ListItem>
                <asp:ListItem>6</asp:ListItem>
            </asp:DropDownList><br />
            <asp:Button ID="FoodSelect" runat="server" Text="Add" OnClick="FoodSelect_Click" Style="height: 29px" />
        </div>

        <div class="addFood-box">
            <div class="box-topic">Food not found? Add it yourself.</div>
            <table>
                <tr>
                    <td class="auto-style1">
                        <asp:Label ID="Label1" runat="server" Text="Food Name:"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="AddFood" runat="server"></asp:TextBox><br />
                    </td>
                </tr>
                <tr>
                    <td>
                         <asp:Label ID="Label4" runat="server" Text="Food Quantity:"></asp:Label>
                    </td>
                    <td>
                         <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox><br />
                    </td>
                </tr>
                <tr>
                    <td class="auto-style1">
                        <asp:Label ID="Label2" runat="server" Text="Food Calory:"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="AddCalory" runat="server"></asp:TextBox><br />
                    </td>
                </tr>
                <tr>
                    <td class="auto-style1">
                        <asp:Button ID="AddFoodBtn" runat="server" Text="Submit" OnClick="FoodAdd_Click" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Button ID="TotalCalory" runat="server" Text="Calculate total calory" OnClick="TotalCalory_Click" />
                    </td>
                </tr>

            </table>


        </div>
    </div>




</asp:Content>
