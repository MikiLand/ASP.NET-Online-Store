<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="UserRegister.aspx.cs" Inherits="Sklep.UserRegister" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="height: 50px;">

    </div>
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
                                    <h3 class="card-title">User registration</h3>
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
                                <div class="form-group mb-3">
                                    <asp:TextBox class="form-control" ID="TBLogin" runat="server" placeholder="Your login"></asp:TextBox>
                                </div>

                                <center>
                                    <label>Email</label>
                                </center>
                                <div class="form-group mb-3">
                                    <asp:TextBox class="form-control" ID="TBEmail" runat="server" placeholder="Your email" TextMode="Email"></asp:TextBox>
                                </div>

                                <center>
                                    <label>Password</label>
                                </center>
                                <div class="form-group mb-3">
                                    <asp:TextBox class="form-control" ID="TBPassword" runat="server" placeholder="Your password" TextMode="Password"></asp:TextBox>
                                </div>

                                <center>
                                    <label>Repeat password</label>
                                </center>
                                <div class="form-group mb-3">
                                    <asp:TextBox class="form-control" ID="TBRepPassword" runat="server" placeholder="Repeat password" TextMode="Password"></asp:TextBox>
                                </div>

                                <div class="mb-3 form-check">
                                    <input type="checkbox" class="form-check-input" id="CBTaC">
                                    <a href="TermsAndConditions.aspx">Terms and conditions</a>
                                </div>

                                <center>
                                    <div class="form-group">
                                        <asp:Button Class="btn d-grid gap-2 btn-primary btn-block btn-lg" style="width: 150px" ID="BtnRegister" runat="server" Text="Register" OnClick="BtnLogin_Click" />
                                    </div>
                                </center>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
