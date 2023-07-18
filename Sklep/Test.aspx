<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Test.aspx.cs" Inherits="Sklep.WebForm2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/css/bootstrap.min.css">  
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>  
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/js/bootstrap.min.js"></script>  

    <script type="text/javascript">  
        $(document).ready(function () {  
            $.ajax({  
                url: 'AJAXWebService.asmx/GetAllEmployee',  
                dataType: "json",  
                method: 'post',  
                success: function (data) {  
                    var employeeTable = $('#tblEmployee tbody');  
                    employeeTable.empty();  
                    $(data).each(function (index, emp) {  
                        employeeTable.append('<tr><td>' + emp.ID + '</td><td>'  
                            + emp.Name + '</td><td>' + emp.Position + '</td><td>' + emp.Office  
                            + '</td><td>' + emp.Age + '</td><td>' + emp.Salary + '</td></tr>');  
                    });  
                },  
                error: function (err) {  
                    alert(err);  
                }  
            });  
        });  
    </script>  


    <script type="text/javascript">  
        $(document).ready(function () {
            $.ajax({
                url: 'AJAXWebService.asmx/GetProducts',
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
</head>
<body>  
    <form id="form1" runat="server"> 
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



        <div class="container">  
            <h3 class="text-uppercase text-center">How to retrive data using ajax in asp.net</h3>  
            <table id="tblEmployee" class="table table-bordered">  
                <thead class="bg-primary text-white">  
                    <tr>  
                        <th>ID</th>  
                        <th>Name</th>  
                        <th>Position</th>  
                        <th>Office</th>  
                        <th>Age</th>  
                        <th>Salary</th>  
                    </tr>  
                </thead>  
                <tbody></tbody>  
            </table>  
        </div>  
    </form>  
</body>  
</html>
