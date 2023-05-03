<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="UserProfile.aspx.cs" Inherits="Sklep.UserProfile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
       <div style="height: 10px;">

    </div>
     <div class="container-fluid">
        <div class="row">
            <div class="col-md-4">
                <div class="card">
                    <div class="card-body">
                        <div class="row">
                            <div class="col">
                                <center>
                                    <img width="150px" src="imgs/profile.png">
                                </center>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col">
                                <center>
                                    <h3 class="card-title">Your profile</h3>
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
                                    <asp:TextBox class="form-control" ID="TBLogin" runat="server" placeholder="Your login" ReadOnly="True"></asp:TextBox>
                                </div>

                                <center>
                                    <label>Email</label>
                                </center>
                                <div class="form-group">
                                    <asp:TextBox class="form-control" ID="TBEmail" runat="server" placeholder="Your email" TextMode="Email"></asp:TextBox>
                                </div>

                                <center>
                                    <label>Name</label>
                                </center>
                                <div class="form-group">
                                    <asp:TextBox class="form-control" ID="TBName" runat="server" placeholder="Your name"></asp:TextBox>
                                </div>

                                <center>
                                    <label>Surname</label>
                                </center>
                                <div class="form-group">
                                    <asp:TextBox class="form-control" ID="TBSurname" runat="server" placeholder="Your surname"></asp:TextBox>
                                </div>

                                <div class="form-group">
                                    <center>
                                        <asp:Button Class="btn d-grid gap-2 btn-primary btn-block btn-lgmt-3 mt-3" style="width: 150px" ID="BtnUpdateEmail" runat="server" Text="Update" OnClick="BtnUpdateEmail_Click"/>
                                    </center>
                                </div>

                                <!-- Button trigger modal -->
                                <button type="button" class="btn btn-primary" data-toggle="modal" data-target="#exampleModalCenter">
                                  Launch demo modal
                                </button>
                                
                                <!-- Modal -->
                                <div class="modal fade" id="exampleModalCenter" tabindex="-1" role="dialog" aria-labelledby="exampleModalCenterTitle" aria-hidden="true">
                                  <div class="modal-dialog modal-dialog-centered" role="document">
                                    <div class="modal-content">
                                      <div class="modal-header">
                                        <h5 class="modal-title" id="exampleModalLongTitle">Modal title</h5>
                                        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                          <span aria-hidden="true">&times;</span>
                                        </button>
                                      </div>
                                      <div class="modal-body">
                                        ...
                                      </div>
                                      <div class="modal-footer">
                                        <button type="button" class="btn btn-secondary" data-dismiss="modal">Close</button>
                                        <button type="button" class="btn btn-primary">Save changes</button>
                                      </div>
                                    </div>
                                  </div>
                                </div>

                                <div class="col">
                                    <center>
                                        <hr />
                                    </center>
                                </div>

                                <center>
                                    <label>Current password</label>
                                </center>
                                <div class="form-group">
                                    <asp:TextBox class="form-control" ID="TBCurrentPassword" runat="server" placeholder="Current password" TextMode="Password"></asp:TextBox>
                                </div>

                                <center>
                                    <label>New password</label>
                                </center>
                                <div class="form-group">
                                    <asp:TextBox class="form-control" ID="TBPassword" runat="server" placeholder="New password" TextMode="Password"></asp:TextBox>
                                </div>

                                <center>
                                    <label>Repeat password</label>
                                </center>
                                <div class="form-group">
                                    <asp:TextBox class="form-control" ID="TBRepPassword" runat="server" placeholder="Repeat password" TextMode="Password"></asp:TextBox>
                                </div>

                                <div class="form-group">
                                    <center>
                                        <asp:Button Class="btn d-grid gap-2 btn-primary btn-block btn-lgmt-3 mt-3" style="width: 150px" ID="BtnUpdatePassword" runat="server" Text="Update password" OnClick="BtnUpdatePassword_Click" />
                                    </center>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="col-md-8">
                <div class="card">
                    <div class="card-body">
                        <div class="row">
                            <div class="col">
                                <center>
                                    <img width="150px" src="imgs/box.png">
                                </center>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col">
                                <center>
                                    <h3 class="card-title">Your orders</h3>
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
                            <asp:SqlDataSource ID="SqlDataOrders" runat="server" ConnectionString="<%$ ConnectionStrings:ShopConnectionString %>" SelectCommand="select id as [Order number], net as Net, gross as Gross, date as Date from [Order]"></asp:SqlDataSource>
                            <div class="col">
                                <asp:GridView class="table table-striped table-bordered" ID="GVUserOrders" runat="server" DataSourceID="SqlDataOrders"></asp:GridView>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div style="height: 50px;">

        </div>
    </div>
</asp:Content>
