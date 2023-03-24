<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="UserLogin.aspx.cs" Inherits="Sklep.UserLogin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="row">
            <div class="col-md-6 mx-auto">
                <div class="card">
                    <div class="card-body">
                        <div class="row">
                            <div class="col">
                                <center>
                                    <img width="150px" src="imgs/candles.png">
                                </center>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col">
                                <center>
                                    <h3 class="card-title">User login</h3>
                                </center>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col">
                                <center>
                                    <hr />
                                </center>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col">
                                <center>
                                    <label>Login</label>
                                </center>
                                <div class="form-group">
                                    <asp:TextBox class="form-control" ID="TBLogin" runat="server" placeholder="Your login"></asp:TextBox>
                                </div>

                                <center>
                                    <label>Password</label>
                                </center>
                                <div class="form-group">
                                    <asp:TextBox class="form-control" ID="TBPassword" runat="server" placeholder="Your password" TextMode="Password"></asp:TextBox>
                                </div>

                            <!-- Nie działa rozciągnięcie na całą szerokość pliku i robienie odstępu-->
                                <div class="form-group">
                                    <asp:Button Class="btn d-grid gap-2 btn-primary btn-block btn-lg" ID="BtnLogin" runat="server" Text="Login" OnClick="BtnLogin_Click" />
                                </div>
                                <div class="form-group">
                                    <a href="UserRegister.aspx"><input class="btn btn-primary btn-block btn-lg" id="Btnregister" type="button" value="Register" /></a>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    

</asp:Content>
