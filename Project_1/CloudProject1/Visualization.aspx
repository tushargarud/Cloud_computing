<%@ Page Title="" Language="C#" AutoEventWireup="true" CodeBehind="Visualization.aspx.cs" Inherits="CloudAssignment4.Visualization" %>
<html>
    <head>
        <title>

        </title>

        <script src="http://code.jquery.com/jquery-1.11.1.min.js"></script>

    <!--Load the AJAX API-->
    <script type="text/javascript" src="https://www.gstatic.com/charts/loader.js"></script>

        <script type="text/javascript" >

        // Load the Visualization API and the corechart package.
        google.charts.load('current', { 'packages': ['corechart'] });

        // Set a callback to run when the Google Visualization API is loaded.
        google.charts.setOnLoadCallback(drawChart);

        // Callback that creates and populates a data table,
        // instantiates the pie chart, passes in the data and
        // draws it.
        function drawChart() {

            $.ajax({
                type: "POST",
                //Page Name (in which the method should be called) and method name
                url: "Visualization.aspx/GetData",
                //else If you don't want to pass any value to server side function leave the data to blank line below
                data: "{}",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (chartdata) {

                    // Set chart options
                    var options = {
                        'title': 'How Much Pizza I Ate Last Night',
                        'width': 400,
                        'height': 300
                    };

                    // Instantiate and draw our chart, passing in some options.
                  //  var chart = new google.visualization.PieChart(document.getElementById('chart_div'));
                    //  chart.draw(chartdata, options);
                    document.getElementById('test_span').textContent = chartdata;
                }
            });       
        }
    </script>

    </head>
    <body>

            <div id="chart_div"></div>
        <span id="test_span"></span>

<form runat="server">
<asp:Literal ID="lit_NewDataTable" runat="server" />
<asp:DataGrid ID="DataGrid1" runat="server" Width="350px" AutoGenerateColumns="False">
<Columns>
<asp:BoundColumn DataField="StateName" HeaderText="State Name" />
<asp:BoundColumn DataField="TotalPop" HeaderText="Total Pop" />
<asp:BoundColumn DataField="VotePop" HeaderText="Vote Pop" />
<asp:BoundColumn DataField="Registered" HeaderText="Registered" />
<asp:BoundColumn DataField="PercentReg" HeaderText="Percent Reg" />
<asp:BoundColumn DataField="Voted" HeaderText="Voted" />
<asp:BoundColumn DataField="PercentVote" HeaderText="Percent Vote" />
</Columns>
</asp:DataGrid>
</form>
    </body>

    </html>
