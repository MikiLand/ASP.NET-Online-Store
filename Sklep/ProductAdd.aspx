<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="ProductAdd.aspx.cs" Inherits="Sklep.ProductAdd" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid">
        <hr />
        <div class="row mt-2">
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
                                    <h3 class="card-title">Add product</h3>
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
                                    <asp:TextBox class="form-control" ID="TBName" runat="server" placeholder="Product name" ></asp:TextBox>
                                </div>

                                <div class="input-group mt-1 mb-2">
                                        <asp:TextBox class="form-control" ID="TBProductType" runat="server" placeholder="Product type" ReadOnly="True"></asp:TextBox>
                                        <div class="dropdown m-1 mt-0 mb-0">
                                            <a class="btn btn-secondary dropdown-toggle" style="width: 100px" href="#" role="button" id="DDType" data-bs-toggle="dropdown" aria-expanded="false">
                                                Type
                                            </a>
                                            <ul class="dropdown-menu" aria-labelledby="dropdownMenuLink" ID="DDLProductType" onselect="DDLProductTypeOnSelect">
                                                <li><a class="dropdown-item" href="#">Candle</a></li>
                                                <li><a class="dropdown-item" href="#">Scent</a></li>
                                                <li><a class="dropdown-item" href="#">Other</a></li>
                                            </ul>
                                        </div>
                                    </div>

                                <center>
                                    <label>Description</label>
                                </center>
                                <div class="form-group mb-2">
                                    <asp:TextBox class="form-control" ID="TBDescription" runat="server" placeholder="Description"></asp:TextBox>
                                </div>

                                <center>
                                    <label>Price</label>
                                </center>
                                <div class="form-group">
                                    <asp:TextBox class="form-control" ID="TBPrice" runat="server" placeholder="Price"></asp:TextBox>
                                </div>

                                <div class="form-group">
                                    <center>
                                        <asp:Button Class="btn d-grid gap-2 btn-primary btn-block btn-lgmt-3 mt-3" style="width: 150px" ID="BtnAdd" runat="server" Text="Add" OnClick="BtnAdd_Click" />
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
                                <asp:SqlDataSource ID="SqlDataProducts" runat="server" ConnectionString="<%$ ConnectionStrings:ShopConnectionString2 %>" SelectCommand="select p.Name, p.Description, tp.TypeName as Type, p.Price
from Product p
left join ProductType tp on tp.id = p.Type
Order by p.name"></asp:SqlDataSource>
                                <asp:GridView class="table table-striped table-bordered" ID="GVProducts" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataProducts">
                                    <Columns>
                                        <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name" />
                                        <asp:BoundField DataField="Description" HeaderText="Description" SortExpression="Description" />
                                        <asp:BoundField DataField="Type" HeaderText="Type" SortExpression="Type" />
                                        <asp:BoundField DataField="Price" HeaderText="Price" SortExpression="Price" />
                                    </Columns>
                                </asp:GridView>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col">
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
