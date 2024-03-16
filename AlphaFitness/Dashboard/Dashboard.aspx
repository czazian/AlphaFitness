<%@ Page Title="" Language="C#" MasterPageFile="~/Contents.Master" AutoEventWireup="true" CodeBehind="Dashboard.aspx.cs" Inherits="AlphaFitness.Dashboard.Dashboard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="Dashboard.css" rel="stylesheet" />
    <title>Dashboard</title>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="home-content">
        <div class="top-box">
            <div class="top-left">
                Days of Login:&nbsp;<asp:Label runat="server" ID="lblNumberOfDays" Text="8" />&nbsp;
            </div>
            <div class="top-right">
                <div class="dayButtons">
                    <div class="week-no">
                        Week&nbsp;<asp:Label runat="server" ID="weekNo" />
                    </div>
                </div>
                <div class="days">
                    <asp:Panel runat="server" CssClass="day" ID="one">
                        DAY 1
                    </asp:Panel>
                    <asp:Panel runat="server" CssClass="day" ID="two">
                        DAY 2
                    </asp:Panel>
                    <asp:Panel runat="server" CssClass="day" ID="three">
                        DAY 3
                    </asp:Panel>
                    <asp:Panel runat="server" CssClass="day" ID="four">
                        DAY 4
                    </asp:Panel>
                    <asp:Panel runat="server" CssClass="day" ID="five">
                        DAY 5
                    </asp:Panel>
                    <asp:Panel runat="server" CssClass="day" ID="six">
                        DAY 6
                    </asp:Panel>
                    <asp:Panel runat="server" CssClass="day" ID="seven">
                        DAY 7
                    </asp:Panel>
                </div>
            </div>
        </div>


        <div class="upper-cont" id="upper-cont">
            <div class="mission-cont" id="mission-cont">
                <div class="mission-main-title">
                    Daily Missions
                </div>
                <div class="mission-list">

                    <asp:Panel runat="server" CssClass="m" ID="m1">
                        <div class="m-top">
                            <div class="m-icon">
                                <i class='i bx bx-run'></i>
                            </div>
                            <asp:LinkButton runat="server" OnClientClick="return confirm('Are you sure you have done?');" CssClass="doneBtn" ID="runDone" OnClick="runDone_Click">
                            <i class='bx bx-check'></i>
                            </asp:LinkButton>
                        </div>
                        <div class="m-mid">
                            <p class="m-title">Sport Session</p>
                            <p class="m-description">1 Hour</p>
                        </div>
                        <div class="m-bottom">
                            <i class='bx bxs-coin'></i>100
                        </div>
                    </asp:Panel>

                    <asp:Panel runat="server" CssClass="m" ID="m3">
                        <div class="m-top">
                            <div class="m-icon">
                                <i class="fa-regular fa-heart"></i>
                            </div>
                            <asp:LinkButton OnClientClick="return confirm('Are you sure you have done?');" runat="server" CssClass="doneBtn" ID="mediDone" OnClick="mediDone_Click">
                            <i class='bx bx-check'></i>
                            </asp:LinkButton>
                        </div>
                        <div class="m-mid">
                            <p class="m-title">Meditation</p>
                            <p class="m-description">30 Minutes</p>
                        </div>
                        <div class="m-bottom">
                            <i class='bx bxs-coin'></i>50
                        </div>
                    </asp:Panel>


                    <asp:Panel runat="server" CssClass="m" ID="m2">
                        <div class="m-top">
                            <div class="m-icon">
                                <i class='i bx bx-droplet'></i>
                            </div>
                        </div>
                        <div class="m-mid">
                            <p class="m-title">Water</p>
                            <p class="m-description">2 Liters/day</p>
                        </div>
                        <div class="m-bottom">
                            <i class='bx bxs-coin'></i>150
                        </div>
                    </asp:Panel>


                    <asp:Panel runat="server" CssClass="m" ID="m4">
                        <div class="m-top">
                            <div class="m-icon">
                                <i class='i bx bx-check-square'></i>
                            </div>
                        </div>
                        <div class="m-mid">
                            <p class="m-title">All Complete</p>
                            <p class="m-description">
                                <asp:Label runat="server" ID="completedMission" Text="0" />/3 Missions
                            </p>
                        </div>
                        <div class="m-bottom">
                            <i class='bx bxs-coin'></i>200
                        </div>
                    </asp:Panel>

                </div>
            </div>

            <div class="calories-tracker" id="calories-tracker">
                <div class="calories-tt">
                    You Consumed
                </div>
                <div class="calories-content">
                    <asp:Label CssClass="calories" runat="server" ID="caloriesValue" Text="2000" />&nbsp<span style="color: grey; font-size: 16px;">calories</span>
                </div>
            </div>
        </div>


        <div class="box-cont">
            <div class="left-box">
                <div class="box-title">
                    Today's Contents
                </div>
                <div class="left-content">
                    <div class="video">
                        <video controls class="video" style="width: 100%;" poster="../Image/Video/poster.png">
                            <source src='<%= ResolveUrl("~/Image/Video/fitness.mp4") %>' type="video/mp4" />
                        </video>
                    </div>
                    <div class="encouragement">
                        <p>"Every drop of sweat is a step closer to your goals – embrace the challenge, stay dedicated, and let your determination be the driving force in your fitness journey!"</p>
                    </div>
                </div>
            </div>
            <div class="right-box">
                <div class="box-title">
                    Wellness Tracker
                </div>

                <!--An instance for update panel-->
                <asp:ScriptManager ID="ScriptManager1" runat="server">
                </asp:ScriptManager>

                <script type="text/javascript" language="javascript">
                    Sys.WebForms.PageRequestManager.getInstance().add_endRequest(EndRequestHandler);
                    function EndRequestHandler(sender, args) {
                        if (args.get_error() != undefined) {
                            args.set_errorHandled(true);
                        }
                    }
                </script>

                <asp:UpdatePanel runat="server" ID="UpdatePanel1" UpdateMode="Conditional">
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="lbnClear" />
                        <asp:AsyncPostBackTrigger ControlID="lbnSubmit" />
                    </Triggers>
                    <ContentTemplate>

                        <div class="right-content">
                            <table>
                                <tr>
                                    <td>
                                        <label for="txtWeight">Weight (KG)</label>
                                    </td>
                                    <td>
                                        <asp:TextBox placeholder="Example : 50" runat="server" ID="txtWeight" class="form-control" /><br />
                                        <asp:CompareValidator Display="Dynamic" Operator="DataTypeCheck" Type="Double" runat="server" ErrorMessage="Please enter the correct value." ForeColor="red" ControlToValidate="txtWeight" />
                                        <asp:CompareValidator Display="Dynamic" Operator="DataTypeCheck" Type="Integer" runat="server" ErrorMessage="Please enter the correct value." ForeColor="red" ControlToValidate="txtWeight" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <label for="txtHeight">Height (CM)</label>
                                    </td>
                                    <td>
                                        <asp:TextBox runat="server" placeholder="Example : 170" ID="txtHeight" class="form-control" /><br />
                                        <asp:CompareValidator Display="Dynamic" Operator="DataTypeCheck" Type="Integer" runat="server" ErrorMessage="Please enter the correct value." ForeColor="red" ControlToValidate="txtHeight" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <label for="txtCarbo">Carbo (g)</label>
                                    </td>
                                    <td>
                                        <asp:TextBox placeholder="Example : 123.00" runat="server" ID="txtCarbo" class="form-control" /><br />
                                        <asp:CompareValidator Display="Dynamic" Operator="DataTypeCheck" Type="Double" runat="server" ErrorMessage="Please enter the correct value." ForeColor="red" ControlToValidate="txtCarbo" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <label for="txtHeartRate">Heart Rate (bpm)</label>
                                    </td>
                                    <td>
                                        <asp:TextBox placeholder="Example : 110" runat="server" ID="txtHeartRate" class="form-control" /><br />
                                        <asp:CompareValidator Display="Dynamic" Operator="DataTypeCheck" Type="Double" runat="server" ErrorMessage="Please enter the correct value." ForeColor="red" ControlToValidate="txtHeartRate" />
                                        <asp:CompareValidator Display="Dynamic" Operator="DataTypeCheck" Type="Integer" runat="server" ErrorMessage="Please enter the correct value." ForeColor="red" ControlToValidate="txtHeartRate" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <label for="txtWater">Water Drink (ml)</label>
                                    </td>
                                    <td>
                                        <asp:TextBox placeholder="Example : 500" runat="server" ID="txtWater" class="form-control" /><br />
                                        <asp:CompareValidator Display="Dynamic" Operator="DataTypeCheck" Type="Double" runat="server" ErrorMessage="Please enter the correct value." ForeColor="red" ControlToValidate="txtWater" />
                                        <asp:CompareValidator Display="Dynamic" Operator="DataTypeCheck" Type="Integer" runat="server" ErrorMessage="Please enter the correct value." ForeColor="red" ControlToValidate="txtWater" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <label for="txtExercise">Time Exercised (minutes)</label>
                                    </td>
                                    <td>
                                        <asp:TextBox placeholder="Example : 60" runat="server" ID="txtExercise" class="form-control" /><br />
                                        <asp:CompareValidator Display="Dynamic" Operator="DataTypeCheck" Type="Integer" runat="server" ErrorMessage="Please enter the correct value." ForeColor="red" ControlToValidate="txtExercise" />
                                    </td>
                                </tr>
                            </table>
                            <div class="btn-group">
                                <asp:LinkButton CausesValidation="false" OnClick="lbnClear_Click" CssClass="btb" runat="server" ID="lbnClear">
                            Clear All&nbsp;<i class="fa-solid fa-trash"></i>
                                </asp:LinkButton>
                                <asp:LinkButton OnClick="lbnSubmit_Click" CssClass="btb" runat="server" ID="lbnSubmit">
                            Submit&nbsp;<i class="fa-solid fa-circle-check"></i>
                                </asp:LinkButton>
                            </div>


                            <div style="color: red; margin-top:10px; line-height: 20px; text-align: center;">
                                <asp:Label Style="margin: 20px 0px;" runat="server" ID="atleastOne" Visible="false" />
                            </div>
                        </div>

                    </ContentTemplate>
                </asp:UpdatePanel>

                <div style="color: red; line-height: 20px; text-align: center;">
                    *When submitting the form, any empty input fields will be assumed to have a value of 0.*
                </div>

            </div>
        </div>


    </div>

    <script>
        function insertSuccessful() {
            alert("Body metrics successfully inserted!");
        }
    </script>
</asp:Content>
