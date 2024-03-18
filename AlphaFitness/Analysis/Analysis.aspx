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
                <div class="title">Calories Graph<span class="smlT">on this week</span></div>
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
                <asp:Repeater ID="Repeater1" runat="server">
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
                <asp:Label runat="server" ID="ExceedCaloriesLimit" Visible="false" ForeColor="Red"/>
            </div>
        </div>

        <div class="sales-boxes">
            <div class="info1 box">
                <div class="title">Weight Loss Analysis<span class="smlT">over this week</span></div>
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

    <script>
        //calories graph
        const ctx = document.getElementById('line');

        new Chart(ctx, {
            type: 'line',
            data: {
                labels: ['Day1', 'Day2', 'Day3', 'Day4', 'Day5', 'Day6', 'Day7'],
                datasets: [{
                    label: 'Monthly Calorie Intake',
                    data: [2000, 3000, 1500, 3550, 2200, 1750,2500],
                    borderWidth: 1
                }]
            },
            options: {
                scales: {
                    y: {
                        beginAtZero: true
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


        //weight loss graph
        const ctx3 = document.getElementById('weightLoss');

        new Chart(ctx3, {
            type: 'line',
            data: {
                labels: ['Jan', 'Feb', 'Mac', 'Apr', 'May', 'Jun', 'Jul', 'Aug'],
                datasets: [{
                    label: 'Monthly Weight loss',
                    data: [81, 79, 75, 73, 70, 72, 68, 65],
                    borderWidth: 2,
                    fill: false,
                    borderColor: 'rgb(75, 192, 192)',
                    tension: 0.3
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
                label: '26 Mac 2024 (Tues)',
                data: [126, 81, 79, 137, 94, 122, 77],
                fill: true,
                backgroundColor: 'rgba(255, 99, 132, 0.2)',
                borderColor: 'rgb(255, 99, 132)',
                pointBackgroundColor: 'rgb(255, 99, 132)',
                pointBorderColor: '#fff',
                pointHoverBackgroundColor: '#fff',
                pointHoverBorderColor: 'rgb(255, 99, 132)'
            }, {
                label: '27 Mac 2024 (Wed)',
                data: [119, 91, 83, 146, 86, 133, 79],
                fill: true,
                backgroundColor: 'rgba(54, 162, 235, 0.2)',
                borderColor: 'rgb(54, 162, 235)',
                pointBackgroundColor: 'rgb(54, 162, 235)',
                pointBorderColor: '#fff',
                pointHoverBackgroundColor: '#fff',
                pointHoverBorderColor: 'rgb(54, 162, 235)'
            }]
        };

        new Chart(ctx4, {
            type: 'radar',
            data: data2,
            options: {
                elements: {
                    line: {
                        borderWidth: 3
                    }
                }
            },
        });
    </script>

</asp:Content>
