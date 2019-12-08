<%@ Page Async="true" Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="AppReservas.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    
    <style>
		canvas{
			-moz-user-select: none;
			-webkit-user-select: none;
			-ms-user-select: none;
		}
        .chart-container {
			width: 500px;
			margin-left: 20px;
			margin-right: 20px;
		}
		.container {
			display: flex;
			flex-direction: row;
			flex-wrap: wrap;
			justify-content: center;
		}
	</style>
  
    <script src="Content/js/chart/Chart.min.js"></script>
	<script src="Content/js/chart/utils.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">



    <div class="container">
        <div class="chart-container">
            <canvas id="gra1"></canvas>
        </div>
        <div class="chart-container">
             <canvas id="gra2"></canvas>
        </div>
        <br /><br />
         <div class="chart-container">
             <canvas id="gra3"></canvas>
        </div>

<asp:Literal ID="Literal1" runat="server"></asp:Literal>
 <asp:Literal ID="Literal2" runat="server"></asp:Literal>
       





    </div>
    


</asp:Content>
