<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CreateFirstEvent.aspx.cs" Inherits="AlphaFitness.User.CreateFirstEvent" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="UTF-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />

    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0-alpha1/dist/css/bootstrap.min.css" rel="stylesheet" />
    <link href="https://getbootstrap.com/docs/5.3/assets/css/docs.css" rel="stylesheet" />
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.6.3/jquery.min.js"></script>
    <link rel="stylesheet" href="https://www.w3schools.com/w3css/4/w3.css" />
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css" />
    <link href='https://fonts.googleapis.com/css?family=Poppins' rel='stylesheet' />
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/6.0.0-beta2/css/all.min.css"
        integrity="sha512-YWzhKL2whUzgiheMoBFwW8CKV4qpHQAEuvilg9FAn5VJUDwKZZxkJNuGM4XkWuk94WCrrwslk8yWNGmY1EduTA=="
        crossorigin="anonymous" referrerpolicy="no-referrer" />
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/font-awesome/4.7.0/css/font-awesome.min.css" />
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/6.5.1/css/brands.min.css" />
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0-alpha1/dist/js/bootstrap.bundle.min.js"></script>

    <style>
        html,
        body {
            min-height: 100vh;
            max-width: 100%;
            font-family: 'Poppins';
            background-color: #f2f2f2;
            display: flex;
            flex-flow: row nowrap;
            justify-content: center;
            align-items: center;
            z-index: -1;
        }

        html {
            overflow-y: hidden;
        }

        /*Scrollbar*/
        ::-webkit-scrollbar {
            width: 12px;
        }

        ::-webkit-scrollbar-track {
            background: #ffece3;
        }

        ::-webkit-scrollbar-thumb {
            background: #212121;
        }

            ::-webkit-scrollbar-thumb:hover {
                background: #fc5f5f;
            }

        .container {
            border-radius: 10px;
            padding: 10px;
            width: 700px;
            height: 454px;
            background-color: white;
            position: relative;
            margin-top: -10px;
            display: flex;
            flex-flow: column nowrap;
            justify-content: space-between;
        }

            .container:before {
                content: "";
                z-index: -1;
                position: absolute;
                top: 0;
                right: 0;
                bottom: 0;
                left: 0;
                background: linear-gradient(-103deg, #f89b29 0%, #ff0f7b 100% );
                transform: translate3d(-3px, -1px, 0) scale(0.99);
                filter: blur(20px);
                opacity: var(0.51);
                transition: opacity 0.3s;
                border-radius: inherit;
            }

            .container::after {
                content: "";
                z-index: -1;
                position: absolute;
                top: 0;
                right: 0;
                bottom: 0;
                left: 0;
                background: inherit;
                border-radius: inherit;
            }

        .mainmessage, .submessage {
            text-align: center;
        }

        .mainmessage {
            font-weight: bold;
            font-size: 22px;
        }

        .submessage {
            margin-top: 7px;
            color: #a8a8a8;
            font-size: 14px;
        }

        .btn-container {
            display: flex;
            flex-flow: row nowrap;
            justify-content: center;
            width: 100%;
            padding-top: 25px;
            gap: 10px;
        }

        .btn {
            font-size: 12px;
            padding: 10px 60px 10px 60px;
            font-weight: bold;
        }

        .real-content {
            padding: 40px;
            height: 100%;
        }

        .continue-btn {
            background-color: #ff7e29;
            color: white;
        }

            .continue-btn:hover, .continue-btn:active {
                background-color: #f56a0f;
                color: white;
            }

        .btn-view:hover {
            background-color: #f7f7f5;
        }
    </style>

    <title>Alpha Fitness</title>
    <link rel="icon" type="image/x-icon" href="~/Image/Element/web-icon.jpg" />
</head>
<body>

    <form id="form1" runat="server">

        <div class="container" id="container" style="height: 100%;">
            <div class="real-content" id="real" style="gap: 20px;">
                <div class="mainmessage" style="margin-bottom: 20px;">
                    Let's do a simple quiz !
                </div>
                <div class="submessage">
                    <div class="form-floating mb-3">
                        <asp:TextBox runat="server" CssClass="form-control" ID="txtHeight" placeholder="Height (CM)" />
                        <label for="txtHeight">Height (CM)</label>
                    </div>
                    <asp:CompareValidator Display="Dynamic" Operator="DataTypeCheck" Type="Integer" runat="server" ErrorMessage="Please enter the correct value." ForeColor="red" ControlToValidate="txtHeight" />
                    <asp:CompareValidator Display="Dynamic" Operator="DataTypeCheck" Type="Double" runat="server" ErrorMessage="Please enter the correct value." ForeColor="red" ControlToValidate="txtHeight" />
                    <asp:RequiredFieldValidator Display="Dynamic" runat="server" ControlToValidate="txtHeight" ErrorMessage="Please do not leave empty." ForeColor="red" />


                    <div class="form-floating mb-3">
                        <asp:TextBox runat="server" CssClass="form-control" ID="txtWeight" placeholder="Weight (KG)" />
                        <label for="txtWeight">Weight (KG)</label>
                    </div>
                    <asp:CompareValidator Display="Dynamic" Operator="DataTypeCheck" Type="Integer" runat="server" ErrorMessage="Please enter the correct value." ForeColor="red" ControlToValidate="txtWeight" />
                    <asp:CompareValidator Display="Dynamic" Operator="DataTypeCheck" Type="Double" runat="server" ErrorMessage="Please enter the correct value." ForeColor="red" ControlToValidate="txtWeight" />
                    <asp:RequiredFieldValidator Display="Dynamic" runat="server" ControlToValidate="txtWeight" ErrorMessage="Please do not leave empty." ForeColor="red" />

                    <div class="form-floating mb-3">
                        <asp:TextBox runat="server" CssClass="form-control" ID="txtAge" placeholder="Age" />
                        <label for="txtAge">Age</label>
                    </div>
                    <asp:CompareValidator Display="Dynamic" Operator="DataTypeCheck" Type="Integer" runat="server" ErrorMessage="Please enter the correct value." ForeColor="red" ControlToValidate="txtAge" />
                    <asp:RequiredFieldValidator Display="Dynamic" runat="server" ControlToValidate="txtAge" ErrorMessage="Please do not leave empty." ForeColor="red" />

                    <div class="form-floating">
                        <asp:DropDownList runat="server" CssClass="form-select mb-3" ID="ddlGender">
                            <asp:ListItem Selected="True" Text="Male" Value="M"></asp:ListItem>
                            <asp:ListItem Text="Female" Value="F"></asp:ListItem>
                        </asp:DropDownList>
                        <label for="ddlGender">Gender</label>
                    </div>

                    <div class="form-floating">
                        <asp:DropDownList runat="server" CssClass="form-select" ID="ddlActive">
                            <asp:ListItem Selected="True" Text="Sedentary (little or no exercise)" Value="Sedentary"></asp:ListItem>
                            <asp:ListItem Text="Lightly active (light exercise/sports 1-3 days​/week)" Value="Lightly"></asp:ListItem>
                            <asp:ListItem Text="Moderately active (moderate exercise/sports 3-5 days/week)" Value="Moderately"></asp:ListItem>
                            <asp:ListItem Text="Very active (hard exercise/sports 6-7 days a week)" Value="Very"></asp:ListItem>
                            <asp:ListItem Text="Extra active (very hard exercise/sports & physical job or 2x training)" Value="Extra"></asp:ListItem>
                        </asp:DropDownList>
                        <label for="floatingSelect">Your Activity</label>
                    </div>
                </div>
                <div class="btn-container">
                    <div class="continue" style="width: 100%;">
                        <asp:Button OnClick="done_Click" Style="width: 100%;" CssClass="btn continue-btn" ID="done" runat="server" Text="Let's Get Started!" />
                    </div>
                </div>
            </div>
        </div>
    </form>

</body>
</html>
