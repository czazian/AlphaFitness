<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserLogin.aspx.cs" Inherits="AlphaFitness.User.UserLogin" %>

<!DOCTYPE html>

<html>
<head>
    <title>Alpha Fitness | A Life On the Palm of Hand</title>
    <meta charset="UTF-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <link href="UserLogin.css" rel="stylesheet" type="text/css" />
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.7.1/jquery.min.js"></script>
    <link href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/5.14.0/css/all.min.css" rel="stylesheet" type="text/css" />

    <link rel="icon" type="image/x-icon" href='<%= ResolveUrl("~/Image/Element/web-icon.jpg") %>'>

    <%--    <asp:ContentPlaceHolder ID="head" runat="server">
    </asp:ContentPlaceHolder>--%>
</head>

<body>
    <form runat="server" id="form1">
        <div class="background">
            <%--<asp:Image Style="width:100%; height : auto; left: 0; top: 0;" runat="server" ImageUrl="~/Image/Element/loginBackground.jpg" />--%>
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
                    <input type="text" name="txt" placeholder="Name"  />
                    <input type="email" name="email" placeholder="Email" />
                    <input type="password" name="pswd" placeholder="Password"  />
                    <input type="password" name="confirmPswd" placeholder="Confirm Password" />
                    <asp:Button CssClass="button" runat="server" Text="Sign Up" />
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
                    <input type="email" name="email" placeholder="Email"/>
                    <input type="password" name="pswd" placeholder="Password" />
                    <a href="#">Forget Your Password?</a>
                    <asp:Button CssClass="button" runat="server" Text="Sign In" PostBackUrl="~/Dashboard/Dashboard.aspx" />
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
        </script>
    </form>
</body>
</html>


