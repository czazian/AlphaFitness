<%@ Page Title="" Language="C#" MasterPageFile="~/Contents.Master" AutoEventWireup="true" CodeBehind="FoodTracking.aspx.cs" Inherits="AlphaFitness.Food.FoodTracking" %>

<%--<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>--%>

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
    <div class="home-content">

        <div class="main-content">

            <div class="main-boxes">
                <div class="recent-main box">
                    <div class="title"><i class="fa-solid fa-utensils"></i>&nbsp;&nbsp;Calculate your calory Intake</div>
                </div>
            </div>

            <asp:Panel runat="server" ID="pnlPredifined">
                <table class="calorie-box">
                    <tr>
                        <td style="width: 25%; color: #f7c520;">
                            <i class="fa-solid fa-burger"></i>&nbsp;Kindly select your food : 
                        </td>
                        <td style="display: flex; flex-flow: row nowrap; gap: 8px; width: 80%;">
                            <asp:DropDownList CssClass="txtFOOD" Style="padding: 10px; width: 40%;" ID="FoodList" runat="server"></asp:DropDownList>
                            <asp:TextBox CssClass="txtQty" Style="padding: 10px; width: 100px; text-align: center;" TextMode="Number" runat="server" ID="FoodQuantity" placeholder="Quantity" />
                            <asp:Button CssClass="btnAdd" ID="FoodSelect" runat="server" Text="Add" OnClick="FoodSelect_Click" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <asp:RequiredFieldValidator CssClass="validate" Display="Dynamic" runat="server" ForeColor="Red" ErrorMessage="Please do not leave quantity empty." ControlToValidate="FoodQuantity" />
                            <asp:RangeValidator ID="rangevalidator" Type="Integer" SetFocusOnError="true" ForeColor="Red" ErrorMessage="Quantity must be within 0 to 100." runat="server" ControlToValidate="FoodQuantity" MinimumValue="1" MaximumValue="100" />
                        </td>
                    </tr>
                </table>
            </asp:Panel>

            <div class="addFood-box">
                <div style="color: #f7c520; display: flex; align-items: center; font-size: 18px; gap: 8px; margin-left: 10px;" class="box-topic">
                    <i class="fa-solid fa-circle-question"></i>Food not found?
                    <asp:CheckBox AutoPostBack="true" runat="server" Style="accent-color: #fca503; padding-right: 5px; color: black; font-size: 14px;" ID="cbxAddYourself" Text="Yes" OnCheckedChanged="cbxAddYourself_CheckedChanged" />
                </div>
                <asp:Panel runat="server" ID="pnlAddOwn" Visible="false">
                    <table style="width: contain; margin: 25px;">
                        <tr>
                            <td style="font-weight: 500; font-size: 17px; padding-bottom: 10px;">Add it yourself</td>
                        </tr>
                        <tr style="padding-left: 10px;">
                            <td class="auto-style1" style="width: 20%;">
                                <asp:Label ID="Label1" runat="server" Text="Food Name:"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox Style="padding: 5px; width: 50%" CssClass="txtAddOwn" ID="AddFood" runat="server"></asp:TextBox><br />
                                <asp:RequiredFieldValidator Display="Dynamic" runat="server" ForeColor="Red" ErrorMessage="Please do not leave empty." ControlToValidate="AddFood" />
                            </td>
                        </tr>
                        <tr style="padding-left: 10px;">
                            <td style="width: 20%;">
                                <asp:Label ID="Label4" runat="server" Text="Food Quantity:"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox Style="padding: 5px; width: 50%" CssClass="txtAddOwn" ID="TextBox2" runat="server"></asp:TextBox><br />
                                <asp:RequiredFieldValidator Display="Dynamic" runat="server" ForeColor="Red" ErrorMessage="Please do not leave empty." ControlToValidate="TextBox2" />
                            </td>
                        </tr>
                        <tr style="padding-left: 10px;">
                            <td class="auto-style1" style="width: 20%;">
                                <asp:Label ID="Label2" runat="server" Text="Food Calory:"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox Style="padding: 5px; width: 50%;" CssClass="txtAddOwn" ID="AddCalory" runat="server"></asp:TextBox><br />
                                <asp:RequiredFieldValidator Display="Dynamic" runat="server" ForeColor="Red" ErrorMessage="Please do not leave empty." ControlToValidate="AddCalory" />
                            </td>
                        </tr>
                        <tr style="padding-left: 10px;">
                            <td colspan="2" class="auto-style1">
                                <asp:Button CssClass="btnBTM" ID="AddFoodBtn" runat="server" Text="Submit" OnClick="FoodAdd_Click" />
<%--                                <asp:Button CssClass="btnBTM" ID="TotalCalory" runat="server" Text="Calculate total calory" OnClick="TotalCalory_Click" />--%>
                            </td>
                        </tr>


                    </table>
                </asp:Panel>


                <%--                <asp:Chart ID="Chart1" runat="server" Width="400px" Height="400px">
                    <Series>
                        <asp:Series Name="Series1" ChartType="Pie"></asp:Series>
                    </Series>
                    <ChartAreas>
                        <asp:ChartArea Name="ChartArea1"></asp:ChartArea>
                    </ChartAreas>
                </asp:Chart>--%>


                <br />
                <div id="DetailedInformationDiv" runat="server"></div>



            </div>

            <div class="calorie-info-box">
                <h2>What is Calorie?</h2>
                <p>A calorie is a unit of energy. In nutrition, calories refer to the energy people get from the food and drink they consume, and the energy they use in physical activity. Understanding calories is an important part of managing a balanced diet and maintaining a healthy weight.</p>
            </div>
        </div>

    </div>

</asp:Content>
