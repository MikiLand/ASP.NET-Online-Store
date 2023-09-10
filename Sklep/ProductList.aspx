<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="ProductList.aspx.cs" Inherits="Sklep.ProductList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script type="text/javascript" language="javascript">
        function Func() {
            const nextURL = 'https://localhost:44305/ProductList.aspx';
            const nextTitle = 'https://localhost:44305/ProductList.aspx';
            const nextState = { additionalInformation: 'Updated the URL with JS' };

            // This will create a new entry in the browser's history, without reloading
            window.history.pushState(nextState, nextTitle, nextURL);
        }
    </script>
    <script type="text/javascript">  
        $(document).ready(function () {
            $.ajax({
                url: 'AJAXWebService.asmx/GetProducts',
                data: {
                    TBSearch: document.getElementById('<%= TBSearch.ClientID %>'),
                    CBCandle: document.getElementById('<%= CBCandle.ClientID %>'),
                    CBScent: document.getElementById('<%= CBScent.ClientID %>'),
                    CBOther: document.getElementById('<%= CBOther.ClientID %>'),
                    RadioOrder: document.getElementById('<%= RadioProductType.ClientID %>')

                },
                dataType: "json",
                method: 'post',
                success: function (data) {
                    var productTable = $('#tblProduct tbody');
                    productTable.empty();
                    $(data).each(function (index, emp) {
                        productTable.append('<tr><td>' + emp.ID + '</td><td>'
                            + emp.Name + '</td><td>' + emp.Description + '</td><td>' + emp.Type
                            + '</td><td>' + emp.Price + '</td><td>' + emp.Path + '</td></tr>');

                    });
                },
                error: function (err) {
                    alert(err);
                }
            });
        });
    </script>
    <section>
        <div class="container-fluid">
            <div class="row">
                <div class="col-md-3">
                    <div style="height: 15px;">

                    </div>
                    <div class="card">
                        <div class="card-body" DataSourceID="SqlDataProducts">
                            <center>
                                <h3>Products</h3>
                            </center>
                            
                            <br />
                            <div class="form-group">
                                <asp:TextBox class="form-control" runat="server" ID="TBSearch" placeholder="What are you looking for?"></asp:TextBox>
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
                              <input class="form-check-input" type="checkbox" value="" id="CBCandle" checked runat="server">
                              <label class="form-check-label" for="flexCheckChecked">
                                Candle
                              </label>
                            </div>
                            <div class="form-check">
                              <input class="form-check-input" type="checkbox" value="" id="CBScent" checked runat="server">
                              <label class="form-check-label" for="flexCheckChecked">
                                Scent
                              </label>
                            </div>
                            <div class="form-check">
                              <input class="form-check-input" type="checkbox" value="" id="CBOther" checked runat="server">
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


                            <input id="pi_input" onclick="myFunction()" type="range" min="0" max="3.14" step="any" runat="server" />
                            <p>Value: <output id="value"></output></p>
                            <script type="text/javascript">
                                function myFunction() {
                                    const value = document.querySelector("#value")
                                    const input = document.querySelector("#pi_input")
                                    value.textContent = input.value
                                    input.addEventListener("input", (event) => {
                                        value.textContent = event.target.value
                                    })
                                }
                            </script>


                            <label>Price up to:&nbsp;</label><label id="LblPrice"></label><label>$</label>
                            

                            <input type="range" ID="RangePrice" class="form-range" min="1" max="100" runat="server" OnClick="RangeOnChange" ondrag="RangeOnChange" onmousemove="RangeOnChange" onfocus="RangeOnChange">
                            <asp:Label ID="RangeCurrentAmount" runat="server" Text='100'></asp:Label>
                            <!--<script>
                                var slider = document.getElementById("RangePrice");
                                var output = document.getElementById("LblPrice");
                                output.innerHTML = slider.value;

                                slider.oninput = function() {
                                output.innerHTML = this.value;
                                }
                            </script>-->

                            <div class="row">
                                <div class="col">
                                    <center>
                                        <hr />
                                    </center>
                                </div>
                            </div>

                            <label>Sort by:</label>
                            <div class="form-check">
                              <input class="form-check-input" type="radio" name="flexRadioDefault" id="RadioNameAsc" checked runat="server">
                              <label class="form-check-label" for="flexRadioDefault2">
                                Name ascending
                              </label>
                            </div>
                            <div class="form-check">
                              <input class="form-check-input" type="radio" name="flexRadioDefault" id="RadioNameDesc" runat="server">
                              <label class="form-check-label" for="flexRadioDefault1">
                                Name descending
                              </label>
                            </div>
                            <div class="form-check">
                              <input class="form-check-input" type="radio" name="flexRadioDefault" id="RadioPriceAsc" runat="server">
                              <label class="form-check-label" for="flexRadioDefault1">
                                Price ascending
                              </label>
                            </div>
                            <div class="form-check">
                              <input class="form-check-input" type="radio" name="flexRadioDefault" id="RadioPriceDesc" runat="server">
                              <label class="form-check-label" for="flexRadioDefault1">
                                Price descending
                              </label>
                            </div>
                            <div class="form-check">
                              <input class="form-check-input" type="radio" name="flexRadioDefault" id="RadioProductType" runat="server">
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
                    <asp:DataList ID="DataListProduct" runat="server" DataSourceID="SqlDataProducts" RepeatColumns="3" RepeatDirection="Horizontal" OnItemCommand="DataListProduct_ItemCommand">
                        <ItemTemplate>
                            <table>
                                <tr>
                                    <td>
                                        <asp:ImageButton runat="server" ID="ImgBtnProduct" OnClick="ImgBtnProductOnClick" height="500px" src='<%# Eval("Path")%>' class="img-fluid" Commandname="ToProductPage" commandargument='<%# Eval("id") %>'/>
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
        <div class="container">  
            <h3 class="text-uppercase text-center">How to retrive data using ajax in asp.net</h3>  
            <table id="tblProduct" class="table table-bordered">  
                <thead class="bg-primary text-white">  
                    <tr>  
                        <th>ID</th>  
                        <th>Name</th>  
                        <th>Description</th>  
                        <th>Type</th>  
                        <th>Price</th>  
                        <th>Path</th>  
                    </tr>  
                </thead>  
                <tbody></tbody>  
            </table>  
        </div>  
                <div style="height: 50px;">

                </div>
            </div>
        </div>

    </section>
    <asp:SqlDataSource ID="SqlDataProducts" runat="server" ConnectionString="<%$ ConnectionStrings:ShopConnectionString2 %>" SelectCommand="select p.id, p.Name, p.Description, tp.TypeName as Type, p.Price, pic.Path
from Product p
left join ProductType tp on tp.id = p.Type
left join Pictures Pic on Pic.IDCard = P.id
Order by p.name">
    </asp:SqlDataSource>

    <asp:SqlDataSource ID="SqlDataProductsPrice" runat="server" ConnectionString="<%$ ConnectionStrings:ShopConnectionString2 %>" SelectCommand="select round(min(price),0)-1 as MinPrice, round(max(price),0)+1 as MixPrice from Product">
    </asp:SqlDataSource>
    
</asp:Content>
