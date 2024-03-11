<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserLogin.aspx.cs" Inherits="AlphaFitness.User.UserLogin" %>

<!DOCTYPE html>

<html>
<head>
    <title>Alpha Fitness | A Life On the Palm of Hand</title>
    <meta charset="UTF-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">

    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.7.1/jquery.min.js"></script>
    <link href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/5.14.0/css/all.min.css" rel="stylesheet" type="text/css" />

    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0-alpha1/dist/css/bootstrap.min.css" rel="stylesheet">
    <link href="https://getbootstrap.com/docs/5.3/assets/css/docs.css" rel="stylesheet">
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.6.3/jquery.min.js"></script>
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/6.0.0-beta2/css/all.min.css"
        integrity="sha512-YWzhKL2whUzgiheMoBFwW8CKV4qpHQAEuvilg9FAn5VJUDwKZZxkJNuGM4XkWuk94WCrrwslk8yWNGmY1EduTA=="
        crossorigin="anonymous" referrerpolicy="no-referrer" />
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0-alpha1/dist/js/bootstrap.bundle.min.js"></script>

    <link href="UserLogin.css" rel="stylesheet" type="text/css" />

    <link rel="icon" type="image/x-icon" href='<%= ResolveUrl("~/Image/Element/web-icon.jpg") %>'>
</head>

<body>
    <form runat="server" id="form1">
        <div class="background">
        </div>
        <div class="container" id="main">
            <%--User Registration--%>
            <div class="sign-up">
                <div class="aform">
                    <h1>Create Account</h1>
                    <div class="social-container">
                        <a href="#" class="social"><i class="fab fa-facebook-f"></i></a>
                        <a href="#" class="social"><i class="fab fa-google-plus-g"></i></a>
                        <a href="#" class="social"><i class="fab fa-instagram"></i></a>
                    </div>
                    <p>Or use your email for registration</p>
                    <asp:TextBox CausesValidation="true" runat="server" ID="regName" placeholder="Enter your name" />
                    <asp:RequiredFieldValidator CssClass="validator" ID="RequiredFieldValidator1" runat="server" ErrorMessage="*Please enter your registration name." ControlToValidate="regName" ForeColor="Red"></asp:RequiredFieldValidator>

                    <asp:TextBox CausesValidation="true" runat="server" ID="regEmail" placeholder="Enter your email" />
                    <asp:CustomValidator CssClass="validator" OnServerValidate="CustomValidator1_ServerValidate" ID="CustomValidator1" ForeColor="red" ControlToValidate="regEmail" runat="server"></asp:CustomValidator>
                    <asp:Label Style="color: red; width: 100%; display: flex; flex-flow: row nowrap; justify-content: right;" runat="server" ID="error1" />

                    <asp:TextBox CausesValidation="true" TextMode="Password" runat="server" ID="pass1" CssClass="password" placeholder="Create a password" />
                    <i class="uil uil-eye-slash showHidePw" style="color: black;"></i>

                    <asp:TextBox CausesValidation="true" runat="server" TextMode="Password" ID="pass2" CssClass="password" placeholder="Confirm a password" />
                    <asp:CustomValidator ValidateEmptyText="True" CssClass="validator" ID="CustomValidator2" OnServerValidate="CustomValidator2_ServerValidate" ForeColor="red" ControlToValidate="pass2" runat="server"></asp:CustomValidator>
                    <i class="fa-solid fa-eye-slash showHidePw"></i>
                    <asp:Label Style="color: red; width: 100%; display: flex; flex-flow: row nowrap; justify-content: right;" runat="server" ID="error2" />

                    <asp:Button OnClientClick="return true;" runat="server" ID="register" OnClick="register_Click" Text="Register" />
                </div>
            </div>

            <%--User Login--%>
            <div class="sign-in">
                <div class="aform">
                    <h1>Sign In</h1>
                    <div class="social-container">
                        <a href="#" class="social"><i class="fab fa-facebook-f"></i></a>
                        <a href="#" class="social"><i class="fab fa-google-plus-g"></i></a>
                        <a href="#" class="social"><i class="fab fa-instagram"></i></a>
                    </div>
                    <p>Or use your account</p>
                    <asp:TextBox CausesValidation="true" runat="server" ID="email" CssClass="email" placeholder="Enter your email" />
                    <asp:TextBox CssClass="password" TextMode="Password" CausesValidation="false" runat="server" ID="password" placeholder="Enter your password" />
                    <i class="uil uil-lock icon"></i>
                    <i class="fa-solid fa-eye-slash showHidePw"></i>
                    <div class="loginerr">
                        <asp:Label Style="color: red; margin-bottom: -10px; align-items: center; display: flex; width: 100%; flex-flow: row nowrap; justify-content: right;" runat="server" ID="loginerr" />
                    </div>


                    <div class="forget-password">
                        <asp:Button Style="margin-left: -5px; text-align: center; color: #fa4d4d; border: none; background-color: transparent; text-decoration: underline;" OnClientClick="return false;" runat="server" CausesValidation="false" data-bs-toggle="modal" data-bs-target="#staticBackdrop" Text="Forgot Password" />


                        <div class="modal fade" id="staticBackdrop" data-bs-backdrop="static" data-bs-keyboard="false" tabindex="-1" aria-labelledby="staticBackdropLabel" aria-hidden="true">
                            <div class="modal-dialog modal-dialog-centered">
                                <div class="modal-content">
                                    <div class="modal-header">
                                        <h1 class="modal-title fs-5" id="staticBackdropLabel" style="font-weight: bold;">Password Recovery</h1>
                                        <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
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

                                    <asp:UpdatePanel runat="server" ID="upEmail" UpdateMode="Conditional">
                                        <Triggers>
                                            <asp:AsyncPostBackTrigger ControlID="btnSendEmail" />
                                        </Triggers>
                                        <ContentTemplate>
                                            <table class="modal-body">
                                                <tr class="emailRecover">
                                                    <td class="tt" style="font-weight: bold;">Email:&nbsp;</td>
                                                    <td class="ti">
                                                        <asp:TextBox CausesValidation="false" ID="txtRecoverEmail" TextMode="Email" runat="server" />
                                                        <asp:Button CausesValidation="false" runat="server" Text="Send" ID="btnSendEmail" CssClass="border btn" Style="background-color: #ff7e29; height: inherit; color: white; font-size: 13px;" OnClick="btnSendEmail_Click" />

                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="tt"></td>
                                                    <td class="ti" style="padding: 5px 15px 5px 15px;">
                                                        <asp:Label ID="message1" runat="server" />
                                                    </td>
                                                </tr>

                                                <tr class="verification">
                                                    <td class="tt">
                                                        <div style="font-weight: bold;">Verification Code:&nbsp;</div>
                                                    </td>
                                                    <td class="ti">
                                                        <asp:TextBox CausesValidation="false" runat="server" ID="verificationCode" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="tt"></td>
                                                    <td class="ti" style="padding: 5px 15px 5px 15px;">
                                                        <asp:Label ID="message2" runat="server" />
                                                    </td>
                                                </tr>

                                            </table>



                                            <div class="modal-footer">
                                                <asp:Button Enabled="false" runat="server" CausesValidation="false" Text="Resend" CssClass="btn btn-secondary" OnClick="resendbtn_Click" ID="resendbtn" />
                                                <asp:Button ID="recBtn" Enabled="false" OnClientClick="return ture;" runat="server" CausesValidation="false" OnClick="Unnamed_Click" Style="background-color: #ff7e29; height: inherit; color: white;" CssClass="btn" Text="Recover" />
                                            </div>

                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </div>
                            </div>
                        </div>


                    </div>
                    <asp:Button OnClientClick="return true;" OnClick="login_Click" runat="server" ID="login" Text="Login" />
                </div>
            </div>

            <%--Overlay Container--%>
            <div class="overlay-container">
                <div class="overlay">
                    <div class="overlay-left">
                        <h1>Hello, Friend!</h1>
                        <p>Enter your personal details and start journey with us</p>
                        <button id="signIn">Sign In</button>
                    </div>

                    <div class="overlay-right">
                        <h1>Welcome Back!</h1>
                        <p>To keep connected with us please login with your personal info</p>
                        <button id="signUp">Sign Up</button>
                    </div>
                </div>
            </div>
        </div>


        <script type="text/javascript">
            const tooltipTriggerList = document.querySelectorAll('[data-bs-toggle="tooltip"]');
            const tooltipList = [...tooltipTriggerList].map(tooltipTriggerEl => new bootstrap.Tooltip(tooltipTriggerEl));

            const signUpButton = document.getElementById('signUp');
            const signInButton = document.getElementById('signIn');
            const main = document.getElementById('main');

            signUpButton.addEventListener('click', () => {
                main.classList.add("right-panel-active");
            });
            signInButton.addEventListener('click', () => {
                main.classList.remove("right-panel-active");
            });

            $(document).ready(function () {
                var main = document.getElementById('main');
                var action = window.location.hash.split('#')[1];
                if (action === "login") {
                    main.classList.remove("right-panel-active");
                } else if (action === "register") {
                    main.classList.add("right-panel-active");
                }
            });


            function registered() {
                alert("Your account has been successfully registered!");
            }

            function error() {
                alert("Something wrong with your input!");
            }

            $('#<%= email.ClientID %>').keypress(function (event) {
                if (event.keyCode == 13) {
                    event.preventDefault();
                }
            });

            $('#<%= password.ClientID %>').keypress(function (event) {
                if (event.keyCode == 13) {
                    event.preventDefault();
                }
            });


        </script>

    </form>
</body>
</html>


