<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ChangePassword.aspx.cs" Inherits="AlphaFitness.User.ChangePassword" %>

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
    <div class="background">
        <form runat="server" id="form1">
            <div class="container" id="main">
                <div class="sign-in" style="width:100%;">
                        <h1 style="text-align:center; padding:20px 20px;">Change Your Password</h1>

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

                        <asp:UpdatePanel runat="server" ID="UpdatePanel1">
                            <Triggers>
                                <asp:AsyncPostBackTrigger ControlID="changePW" />
                            </Triggers>
                            <ContentTemplate>
                                <div>
                                    <div class="input-field" style="text-align:center;">
                                        <asp:TextBox TextMode="Password" CssClass="password" runat="server" ID="pass1" placeholder="Enter Password 1" />
                                        <i class="uil uil-user"></i>
                                    </div>
                                    <div class="input-field" style="text-align:center;">
                                        <asp:TextBox TextMode="Password" CssClass="password" runat="server" ID="pass2" placeholder="Enter Password 2" />
                                        <i class="fa-solid fa-eye-slash showHidePw"></i>
                                        <asp:Label Style="color: red; width: 100%; display: flex; flex-flow: row nowrap; justify-content: right;" runat="server" ID="error2" />
                                    </div>

                                    <div class="input-field button">
                                        <asp:Button ID="changePW" runat="server" Text="Change Password" OnClick="Unnamed_Click" />
                                    </div>
                                </div>

                            </ContentTemplate>
                        </asp:UpdatePanel>

                </div>
            </div>
        </form>
    </div>

</body>
</html>
