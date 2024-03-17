<%@ Page Title="" Language="C#" MasterPageFile="~/Contents.Master" AutoEventWireup="true" CodeBehind="Analysis.aspx.cs" Inherits="AlphaFitness.Analysis.Analysis" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="Analysis.css" rel="stylesheet" />
    <script src="https://cdn.jsdelivr.net/npm/chart.js"></script>
    <title>Analysis</title>
    <style>
        table {
            width:100%;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="Analysis.css" rel="stylesheet" />
    <div class="home-content">

        <div class="sales-boxes">
            <div class="recent-sales box">
                <div class="title">Welcome back <asp:Label runat="server" ID="username" /> !</div>
            </div>
        </div>

        <div class="overview-boxes">
            <div class="box">
                <div class="right-side">
                    <div class="box-topic">Calories tracker</div>
                    <div class="indicator">
                        <span id="ContentPlaceHolder1_lblCaloriesT"><asp:Label ID="calories" runat="server" Text="0"></asp:Label></span>
                        &nbsp cal
                    </div>
                </div>
                <div class="icon-pad">
                    <i class='bx bx-line-chart cart three pad'></i>
                </div>
            </div>
            <div class="box">
                <div class="right-side">
                    <div class="box-topic">Carbo tracker</div>
                    <div class="indicator">
                        <span id="ContentPlaceHolder1_lblCarboT"><asp:Label ID="carbo" runat="server" Text="0"></asp:Label></span>
                        &nbsp car
                    </div>
                </div>
                <div class="icon-pad">
                    <i class='bx bx-pie-chart-alt cart five pad'></i>
                </div>
            </div>
            <div class="box">
                <div class="right-side">
                    <div class="box-topic">Heart tracker</div>
                    <div class="indicator">
                        <span id="ContentPlaceHolder1_lblHeartT"><asp:Label ID="heart" runat="server" Text="0"></asp:Label></span>
                        &nbsp bpm
                    </div>
                </div>
                <div class="icon-pad">
                    <i class='bx bx-heart cart four pad'></i>
                </div>
            </div>
            <div class="box">
                <div class="right-side">
                    <div class="box-topic">Water tracker</div>
                    <div class="indicator">
                        <span id="ContentPlaceHolder1_lblWaterT"><asp:Label ID="water" runat="server" Text="0"></asp:Label></span>
                        &nbsp ml
                    </div>
                </div>
                <div class="icon-pad">
                    <i class='bx bx-droplet cart pad'></i>
                </div>
            </div>
            <div class="box">
                <div class="right-side">
                    <div class="box-topic">Exercise tracker</div>
                    <div class="indicator">
                        <span id="ContentPlaceHolder1_lblExerciseT"><asp:Label ID="exercise" runat="server" Text="0"></asp:Label></span>
                        &nbsp min
                    </div>
                </div>
                <div class="icon-pad">
                    <i class='bx bx-stopwatch cart two pad'></i>
                </div>
            </div>
        </div>
        <div class="sales-boxes">
            <div class="info1 box">
                <div class="title">Calories Graph<span class="smlT">on this year</span></div>
                <hr />
                <canvas id="line"></canvas>
            </div>
            <div class="info2 box">
                <div class="title">Report<span class="smlT">on this week</span></div>
                <hr />
                <canvas id="pie"></canvas>
                <asp:HiddenField ID="caloriesData" Value="" runat="server" />
                <asp:HiddenField ID="carboData" Value="" runat="server" />
                <asp:HiddenField ID="heartData" Value="" runat="server" />
                <asp:HiddenField ID="waterData" Value="" runat="server" />
                <asp:HiddenField ID="exerciseData" Value="" runat="server" />
            </div>
        </div>
        <div class="sales-boxes">
            <div class="info1 box">
                <div class="title">Meal for Today</div>
                <hr />

                <div class="sales-details">
                </div>
            </div>
            <div class="info2 box">
                <div class="title">Recommend Food</div>
                <asp:Repeater ID="Repeater1" runat="server" DataSourceID="SqlDataSource1">
                    <HeaderTemplate>
                        <table>
                            <hr />
                    </HeaderTemplate>
                    <ItemTemplate>
                        <tr>
                            <td style="padding:0px 15px 0px 20px;">
                                <asp:Image ID="Image1" runat="server" ImageUrl='<%# Eval("FoodImg") %>' />
                            </td>
                            <td align="left" style="vertical-align: middle;">
                                <%# Eval("Food") %>
                            </td>
                            <td align="right" style="vertical-align: middle;">
                                <%# Eval("FCalories") %> cal
                            </td>
                        </tr>
                    </ItemTemplate>
                    <FooterTemplate>
                        </table>
                    </FooterTemplate>
                </asp:Repeater>
            </div>
        </div>

        <div class="sales-boxes">
            <div class="info1 box">
                <div class="title">Weight Loss Analysis<span class="smlT">over 12 months</span></div>
                <hr />
                <canvas id="weightLoss"></canvas>
            </div>
            <div class="info2 box">
                <div class="title">Heart Rate</div>
                <hr />
                <canvas id="heartRate"></canvas>
            </div>
        </div>

    </div>


     <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:AlphaFitness %>"></asp:SqlDataSource>


    <script src="CaloriesGraph.js"></script>
    <script>
        const ctx2 = document.getElementById('pie');
        const d1 = document.getElementById('<%= caloriesData.ClientID %>').value;
        const d2 = document.getElementById('<%= carboData.ClientID %>').value;
        const d3 = document.getElementById('<%= heartData.ClientID %>').value;
        const d4 = document.getElementById('<%= waterData.ClientID %>').value;
        const d5 = document.getElementById('<%= exerciseData.ClientID %>').value;

        new Chart(ctx2, {
            type: 'pie',
            data: {
                labels: ['Calories', 'Carbo', 'Calories', 'Water', 'Exercise'],
                datasets: [{
                    label: 'Total Intake',
                    data: [d1, d2, d3, d4, d5],
                    borderWidth: 1
                }]
            },
        });
    </script>
    <script src="WeightLoss.js"></script>
    <script src="HeartRate.js"></script>

</asp:Content>
