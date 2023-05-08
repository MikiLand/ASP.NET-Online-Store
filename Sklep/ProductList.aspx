<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="ProductList.aspx.cs" Inherits="Sklep.ProductList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section>
        <div class="container-fluid">
            <div class="row">
                <div class="col-md-3">
                    <div style="height: 15px;">

                    </div>
                    <div class="card">
                        <div class="card-body" DataSourceID="SqlDataProducts">
                            <!--<center>
                                <br /><h1>"Two words my friend<br />
                                No refunds"</h1><br />
                                <h3>September 18, 2012 ~ Marcus</h3>
                            </center>-->
                            <center>
                                <h3>Products</h3>
                            </center>
                            
                            <br />
                            <div class="form-group">
                                <asp:TextBox class="form-control" ID="TBSearch" runat="server" placeholder="What are you looking for?"></asp:TextBox>
                            </div>

                            <div class="row">
                                <div class="col">
                                    <center>
                                        <hr />
                                    </center>
                                </div>
                            </div>

                            <label>Products type:</label>
                            <div class="form-check">
                              <input class="form-check-input" type="checkbox" value="" id="flexCheckChecked" checked>
                              <label class="form-check-label" for="flexCheckChecked">
                                Candle
                              </label>
                            </div>
                            <div class="form-check">
                              <input class="form-check-input" type="checkbox" value="" id="flexCheckChecked" checked>
                              <label class="form-check-label" for="flexCheckChecked">
                                Scent
                              </label>
                            </div>
                            <div class="form-check">
                              <input class="form-check-input" type="checkbox" value="" id="flexCheckChecked" checked>
                              <label class="form-check-label" for="flexCheckChecked">
                                Other
                              </label>
                            </div>

                            <div class="row">
                                <div class="col">
                                    <center>
                                        <hr />
                                    </center>
                                </div>
                            </div>

                            <label>Price up to:&nbsp;</label><label id="LblPrice"></label><label>$</label>
                            <input type="range" ID="RangePrice" class="form-range" min="1" max="100">
                            <script>
                                var slider = document.getElementById("RangePrice");
                                var output = document.getElementById("LblPrice");
                                output.innerHTML = slider.value;

                                slider.oninput = function() {
                                output.innerHTML = this.value;
                                }
                            </script>

                            <div class="row">
                                <div class="col">
                                    <center>
                                        <hr />
                                    </center>
                                </div>
                            </div>

                            <label>Sort by:</label>
                            <div class="form-check">
                              <input class="form-check-input" type="radio" name="flexRadioDefault" id="flexRadioDefault2" checked>
                              <label class="form-check-label" for="flexRadioDefault2">
                                Name ascending
                              </label>
                            </div>
                            <div class="form-check">
                              <input class="form-check-input" type="radio" name="flexRadioDefault" id="flexRadioDefault1">
                              <label class="form-check-label" for="flexRadioDefault1">
                                Name descending
                              </label>
                            </div>
                            <div class="form-check">
                              <input class="form-check-input" type="radio" name="flexRadioDefault" id="flexRadioDefault1">
                              <label class="form-check-label" for="flexRadioDefault1">
                                Price ascending
                              </label>
                            </div>
                            <div class="form-check">
                              <input class="form-check-input" type="radio" name="flexRadioDefault" id="flexRadioDefault1">
                              <label class="form-check-label" for="flexRadioDefault1">
                                Price descending
                              </label>
                            </div>
                            <div class="form-check">
                              <input class="form-check-input" type="radio" name="flexRadioDefault" id="flexRadioDefault1">
                              <label class="form-check-label" for="flexRadioDefault1">
                                Product type
                              </label>
                            </div>

                            <br />
                            <!--<div class="row">
                                <div class="col">
                                    <center>
                                        <hr />
                                    </center>
                                </div>
                            </div>-->

                            <center>
                                <asp:Button Class="btn d-grid gap-2 btn-primary btn-block btn-lg mt-3" style="width: 150px" ID="BtnSearch" runat="server" Text="Search" OnClick="BtnSearch_Click" />
                            </center>
                        </div>
                    </div>    
                </div>

                <div class="col-md-9">
                    <asp:DataList ID="DataListProduct" runat="server" DataSourceID="SqlDataProducts" RepeatColumns="3" RepeatDirection="Horizontal">
                        <ItemTemplate>
                            <table>
                                <tr>
                                    <td>
                                        <a class="" href="HomePage.aspx">
                                            <img height="300px" src='<%# Eval("Path")%>' class="img-fluid" href="HomePage.aspx"/>
                                        </a>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="Label1" runat="server" Text='<%# Eval("Name") %>'></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="Label2" runat="server" Text='<%# Eval("Price") %>'></asp:Label>
                                    </td>
                                </tr>
                                <div style="height: 15px;">

                                </div>
                            </table>
                        </ItemTemplate>
                    </asp:DataList>
                </div>
                <div style="height: 50px;">

                </div>
            </div>
        </div>

    </section>
    <asp:SqlDataSource ID="SqlDataProducts" runat="server" ConnectionString="<%$ ConnectionStrings:ShopConnectionString2 %>" SelectCommand="select p.Name, p.Description, tp.TypeName as Type, p.Price, pic.Path
from Product p
left join ProductType tp on tp.id = p.Type
left join Pictures Pic on Pic.IDCard = P.id
Order by p.name">
    </asp:SqlDataSource>
    

    
    <asp:SqlDataSource ID="SqlDataProductsPrice" runat="server" ConnectionString="<%$ ConnectionStrings:ShopConnectionString2 %>" SelectCommand="select round(min(price),0)-1 as MinPrice, round(max(price),0)+1 as MixPrice from Product">
    </asp:SqlDataSource>
    

    
</asp:Content>
