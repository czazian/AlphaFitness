<%@ Page Title="" Language="C#" MasterPageFile="~/Contents.Master" AutoEventWireup="true" CodeBehind="Analysis.aspx.cs" Inherits="AlphaFitness.Analysis.Analysis" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="Analysis.css" rel="stylesheet" />
<title>Analysis</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="Analysis.css" rel="stylesheet" />
    <div class="home-content">

    <div class="sales-boxes">
        <div class="recent-sales box">
            <div class="title">Welcome back xxxxxx!</div>
        </div>
    </div>

        <div class="overview-boxes">
            <div class="box">
                <div class="right-side">
                    <div class="box-topic">Calories tracker</div>
                    <div class="indicator">
                        <span id="ContentPlaceHolder1_lblCaloriesT">0</span>
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
                        <span id="ContentPlaceHolder1_lblCarboT">0</span>
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
                        <span id="ContentPlaceHolder1_lblHeartT">0</span>
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
                        <span id="ContentPlaceHolder1_lblWaterT">0</span>
                        &nbsp oz
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
                        <span id="ContentPlaceHolder1_lblExerciseT">0</span>
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
                <div class="title">Report<span class="smlT">on this month</span></div>
                <hr />
                <canvas id="pie"></canvas>
            </div>
        </div>
        <div class="sales-boxes">
    <div class="info1 box">
        <div class="title">Meal for today</div>
        <hr />
       
        <div class="sales-details">

            
        </div>
    </div>
    <div class="info2 box">
        <div class="title">Recommend food</div>
        <hr />
        
    </div>
</div>
   
</div>

    <script src="https://cdn.jsdelivr.net/npm/chart.js"></script>
    <script src="CaloriesGraph.js"></script>
    <script src="ReportPieChart.js"></script>

</asp:Content>
