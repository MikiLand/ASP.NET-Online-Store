﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="ProductEdit.aspx.cs" Inherits="Sklep.ProductEdit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid">
        <div class="row">
            <div class="col-md-4">
                <div class="card">
                    <div class="card-body">
                        <div class="row">
                            <div class="col">
                                <center>
                                    <img width="150px" src="imgs/newproduct.png">
                                </center>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col">
                                <center>
                                    <h3 class="card-title">Edit product</h3>
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
                                <div class="form-group">
                                    <div class="input-group">
                                        <asp:TextBox class="form-control" ID="TextBox4" runat="server" placeholder="Name" ></asp:TextBox>
                                        <asp:Button Class="btn btn-primary" ID="Button1" runat="server" Text="Search" />                      
                                    </div>
                                    <div class="input-group">
                                        <asp:TextBox class="form-control" ID="TBProductType" runat="server" placeholder="Product type" ReadOnly="True"></asp:TextBox>
                                        <div class="dropdown">
                                            <a class="btn btn-secondary dropdown-toggle" href="#" role="button" id="dropdownMenuLink" data-bs-toggle="dropdown" aria-expanded="false">
                                                Type
                                            </a>
                                            <ul class="dropdown-menu" aria-labelledby="dropdownMenuLink">
                                                <li><a class="dropdown-item" href="#">Candle</a></li>
                                                <li><a class="dropdown-item" href="#">Scent</a></li>
                                                <li><a class="dropdown-item" href="#">Other</a></li>
                                            </ul>
                                        </div>
                                    </div>

                                    <center>
                                        <label>Description</label>
                                    </center>
                                    <div class="form-group">
                                        <asp:TextBox class="form-control" ID="TextBox3" runat="server" placeholder="Description" TextMode="Email"></asp:TextBox>
                                    </div>

                                    <center>
                                        <label>Price</label>
                                    </center>
                                    <div class="form-group">
                                        <asp:TextBox class="form-control" ID="TextBox2" runat="server" placeholder="Price" TextMode="Number"></asp:TextBox>
                                    </div>

                            <!-- Nie działa rozciągnięcie na całą szerokość pliku i robienie odstępu-->
                                    <div class="input-group">
                                        <center>
                                            <asp:Button Class="btn d-grid gap-2 btn-primary btn-block btn-lg" ID="BtnUpdateProduct" runat="server" Text="Update" />
                                        </center>
                                        <center>
                                            <asp:Button Class="btn d-grid gap-2 btn-danger btn-block btn-lg" ID="BtnDeleteProduct" runat="server" Text="Delete" />
                                        </center>
                                    </div>
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
                                    <img width="150px" src="imgs/allproducts.png">
                                </center>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col">
                                <center>
                                    <h3 class="card-title">All products</h3>
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
                                <asp:GridView class="table table-striped table-bordered" ID="GVAddProduct" runat="server"></asp:GridView>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
