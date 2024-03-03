<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserLogin.aspx.cs" Inherits="AlphaFitness.User.UserLogin" %>

<!DOCTYPE html>

<html>
<head>
    <title>Alpha Fitness | A Life On the Palm of Hand</title>
    <meta charset="UTF-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <link href="UserLogin.css" rel="stylesheet" type="text/css" />
    <link href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/5.14.0/css/all.min.css" rel="stylesheet" type="text/css" />
    <link rel="icon" type="image/x-icon" href='<%= ResolveUrl("~/Image/Element/web-icon.jpg") %>'>

    <%--    <asp:ContentPlaceHolder ID="head" runat="server">
    </asp:ContentPlaceHolder>--%>
</head>

<body>
    <div class="background">
        <%--<asp:Image Style="width:100%; height : auto; left: 0; top: 0;" runat="server" ImageUrl="~/Image/Element/loginBackground.jpg" />--%>
    </div>
    <div class="container" id="main">
        <%--User Registration--%>
        <div class="sign-up">
            <form action="#">
                <h1>Create Account</h1>
                <div class="social-container">
                    <a href="#" class="social"><i class="fab fa-facebook-f"></i></a>
                    <a href="#" class="social"><i class="fab fa-google-plus-g"></i></a>
                    <a href="#" class="social"><i class="fab fa-instagram"></i></a>
                </div>
                <p>Or use your email for registration</p>
                <input type="text" name="txt" placeholder="Name" required="" />
                <input type="email" name="email" placeholder="Email" required="" />
                <input type="password" name="pswd" placeholder="Password" required="" />
                <input type="password" name="confirmPswd" placeholder="Confirm Password" required="" />
                <button>Sign Up</button>
            </form>
        </div>

        <%--User Login--%>
        <div class="sign-in">
            <form action="#">
                <h1>Sign In</h1>
                <div class="social-container">
                    <a href="#" class="social"><i class="fab fa-facebook-f"></i></a>
                    <a href="#" class="social"><i class="fab fa-google-plus-g"></i></a>
                    <a href="#" class="social"><i class="fab fa-instagram"></i></a>
                </div>
                <p>Or use your account</p>
                <input type="email" name="email" placeholder="Email" required="" />
                <input type="password" name="pswd" placeholder="Password" required="" />
                <a href="#">Forget Your Password?</a>
                <button>Sign In</button>
            </form>
        </div>

        <%--Overlay Container--%>
        <div class="overlay-container">
            <div class="overlay">
                <div class="overlay-left">
                    <h1>Welcome Back!</h1>
                    <p>To keep connected with us please login with your personal info</p>
                    <button id="signIn">Sign In</button>
                </div>

                <div class="overlay-right">
                    <h1>Hello, Friend!</h1>
                    <p>Enter your personal details and start journey with us</p>
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
    </script>

</body>
</html>


