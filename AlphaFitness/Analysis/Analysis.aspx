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
                <div class="title">Weight & Height Analysis<span class="smlT"> comparison from the beginning to now</span></div>
                <hr />
                <canvas id="weightLoss"></canvas>
                <asp:HiddenField ID="beginWeightData" Value="" runat="server" />
                <asp:HiddenField ID="beginHeightData" Value="" runat="server" />
                <asp:HiddenField ID="beginDateJoin" Value="" runat="server" />
                <asp:HiddenField ID="beginDateNow" Value="" runat="server" />
                <asp:HiddenField ID="nowWeightData" Value="" runat="server" />
                <asp:HiddenField ID="nowHeightData" Value="" runat="server" />
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
                <asp:Repeater ID="Repeater2" runat="server">
                    <HeaderTemplate>
                        <table>
                            <tr style="border-bottom: 1pt solid black;">
                                <td style="padding: 10px 15px 10px 20px;">No</td>
                                <td align="center" style="vertical-align: middle;">Food Name</td>
                                <td align="center" style="vertical-align: middle;">Calories</td>
                                <td align="right" style="vertical-align: middle;">Amount</td>
                            </tr>
                            <hr />
                    </HeaderTemplate>
                    <ItemTemplate>
                        <tr>
                            <td style="padding: 10px 15px 0px 20px;">
                                <%# Container.ItemIndex + 1 %>.
                            </td>
                            <td align="center" style="vertical-align: middle; padding: 10px 15px 0px 20px;">
                                <%# Eval("FoodName") %>
                            </td>
                            <td align="center" style="vertical-align: middle; padding: 10px 15px 0px 20px;">
                                <%# Eval("Calories") %> cal
                            </td>
                            <td align="right" style="vertical-align: middle; padding: 10px 15px 0px 20px;">
                                <%# Eval("Quantity") %> items
                            </td>
                        </tr>
                    </ItemTemplate>
                    <FooterTemplate>
                        </table>
                    </FooterTemplate>
                </asp:Repeater>
                <asp:Label runat="server" ID="NoConsumedFood" style="padding:30% 0% 0% 10%;" Visible="false" ForeColor="Red" />
            </div>
            <div class="info2 box">
                <div class="title">Recommend Food</div>
                <asp:Repeater ID="Repeater1" runat="server">
                    <HeaderTemplate>
                        <table>

                            <hr />
                    </HeaderTemplate>
                    <ItemTemplate>
                        <tr>
                            <td style="padding: 0px 15px 0px 20px;">
                                <asp:Image ID="Image1" runat="server" ImageUrl='<%# Eval("FoodImg") %>' />
                            </td>
                            <td align="left" style="vertical-align: middle;">
                                <%# Eval("FoodName") %>
                            </td>
                            <td align="right" style="vertical-align: middle;">
                                <%# Eval("FoodCalories") %> cal
                            </td>
                        </tr>
                    </ItemTemplate>
                    <FooterTemplate>
                        </table>
                    </FooterTemplate>
                </asp:Repeater>
                <asp:Label runat="server" ID="ExceedCaloriesLimit" style="padding-left:10%;" Visible="false" ForeColor="Red" />
            </div>
        </div>

        <div class="sales-boxes">
            <div class="info1 box">
                <div class="title">Calories Graph<span class="smlT">on last week</span></div>
                <hr />
                <canvas id="line"></canvas>
            </div>
            <div class="info2 box">
                <div class="title">Heart Rate</div>
                <hr />
                <canvas id="heartRate"></canvas>
            </div>
        </div>

    </div>

    <script>
        //calories graph
        const ctx = document.getElementById('line');

        new Chart(ctx, {
            type: 'line',
            data: {
                labels: ['Day1', 'Day2', 'Day3', 'Day4', 'Day5', 'Day6', 'Day7'],
                datasets: [{
                    label: 'Weekly Calorie Intake',
                    data: [2300, 2460, 1890, 1655, 2160, 1750,1495],
                    borderWidth: 1
                }]
            },
            options: {
                scales: {
                    y: {
                        beginAtZero: false
                    }
                }
            }
        });

        //pie chart
        const ctx2 = document.getElementById('pie');
        const d1 = document.getElementById('<%= caloriesData.ClientID %>').value;
        const d2 = document.getElementById('<%= carboData.ClientID %>').value;
        const d3 = document.getElementById('<%= heartData.ClientID %>').value;
        const d4 = document.getElementById('<%= waterData.ClientID %>').value;
        const d5 = document.getElementById('<%= exerciseData.ClientID %>').value;

        new Chart(ctx2, {
            type: 'doughnut',
            data: {
                labels: ['Water', 'HeartRate', 'Calories', 'Carbo', 'Exercise'],
                
                datasets: [{
                    label: 'Total Intake',
                    data: [d4, d3, d1, d2, d5],
                    borderWidth: 1
                }]
            },
        });


        //weight loss graph
        const ctx3 = document.getElementById('weightLoss');
        //begin data
        const dBeginWeight = document.getElementById('<%= beginWeightData.ClientID %>').value;
        const dBeginHeight = document.getElementById('<%= beginHeightData.ClientID %>').value;
        const dBeginDateJoin = document.getElementById('<%= beginDateJoin.ClientID %>').value;
        //now data
        const dNowWeight = document.getElementById('<%= nowWeightData.ClientID %>').value;
        const dNowHeight = document.getElementById('<%= nowHeightData.ClientID %>').value;
        const dBeginDateNow = document.getElementById('<%= beginDateNow.ClientID %>').value;


        new Chart(ctx3, {
            type: 'bar',
            data: {
                labels: ['Weight', 'Height'],
                datasets: [{
                    label: 'Begin (' + dBeginDateJoin + ')',
                    data: [dBeginWeight, dBeginHeight],
                    borderWidth: 2,
                    fill: false,
                    borderColor: 'rgb(5, 3, 5)',
                    tension: 0.3
                }, {
                    label: 'Now (' + dBeginDateNow + ')',
                    data: [dNowWeight, dNowHeight],
                        borderWidth: 2,
                        fill: false,
                        borderColor: 'rgb(75, 192, 192)',
                        tension: 0.3
                    }]
            },
            options: {
                scales: {
                    y: {
                         ticks: {
                            stepSize: 10, // Set the interval between ticks on the y-axis
                        }
                    }
                }
            }
        });


        //radar chart
        const ctx4 = document.getElementById('heartRate');

        const data2 = {
            labels: [
                'Swimming',
                'Drinking',
                'Sleeping',
                'Running',
                'Coding',
                'Cycling',
                'Reading'
            ],
            datasets: [{
                label: 'Heart Rate (bpm)',
                data: [126, 81, 79, 137, 94, 122, 77],
                fill: true,
                backgroundColor: [
                    'rgba(255, 99, 132, 0.2)', // Swimming
                    'rgba(54, 162, 235, 0.2)',  // Drinking
                    'rgba(255, 206, 86, 0.2)',  // Sleeping
                    'rgba(75, 192, 192, 0.2)',  // Running
                    'rgba(153, 102, 255, 0.2)', // Coding
                    'rgba(255, 159, 64, 0.2)',  // Cycling
                    'rgba(255, 0, 255, 0.2)'    // Reading
                ],
                borderColor: [
                    'rgb(255, 99, 132)',  // Swimming
                    'rgb(54, 162, 235)',   // Drinking
                    'rgb(255, 206, 86)',   // Sleeping
                    'rgb(75, 192, 192)',   // Running
                    'rgb(153, 102, 255)',  // Coding
                    'rgb(255, 159, 64)',   // Cycling
                    'rgb(255, 0, 255)'     // Reading
                ],
                pointBackgroundColor: [
                    'rgb(255, 99, 132)',  // Swimming
                    'rgb(54, 162, 235)',   // Drinking
                    'rgb(255, 206, 86)',   // Sleeping
                    'rgb(75, 192, 192)',   // Running
                    'rgb(153, 102, 255)',  // Coding
                    'rgb(255, 159, 64)',   // Cycling
                    'rgb(255, 0, 255)'     // Reading
                ],
                pointBorderColor: '#fff',
                pointHoverBackgroundColor: '#fff',
                pointHoverBorderColor: [
                    'rgb(255, 99, 132)',  // Swimming
                    'rgb(54, 162, 235)',   // Drinking
                    'rgb(255, 206, 86)',   // Sleeping
                    'rgb(75, 192, 192)',   // Running
                    'rgb(153, 102, 255)',  // Coding
                    'rgb(255, 159, 64)',   // Cycling
                    'rgb(255, 0, 255)'     // Reading
                ]
            }]
        };


        new Chart(ctx4, {
            type: 'polarArea',
            data: data2,
            options: {
                responsive: true,
                scales: {
                    r: {
                        pointLabels: {
                            display: true,
                            centerPointLabels: true,
                            font: {
                                size: 18
                            }
                        }
                    }
                }
            },
        });
    </script>

</asp:Content>
