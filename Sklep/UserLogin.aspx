<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="UserLogin.aspx.cs" Inherits="Sklep.UserLogin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="">
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
                                        <div class="mt-3">
                                            <label>Password</label>
                                        </div>
                                    </center>
                                    <div class="form-group">
                                        <asp:TextBox class="form-control " ID="TBPassword" runat="server" placeholder="Your password" TextMode="Password"></asp:TextBox>
                                    </div>
                                    <center>
                                        <div class="d-grid gap-3">
                                            <center>
                                                <asp:Button Class="btn d-grid gap-2 btn-primary btn-block btn-lg mt-3" style="width: 150px" ID="BtnLogin" runat="server" Text="Login" OnClick="BtnLogin_Click" />
                                            </center>
                                            <a href="UserRegister.aspx"><input class="btn btn-primary btn-block btn-lg" style="width: 150px" id="Btnregister" type="button" value="Register" /></a>
                                        </div>
                                    </center>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
