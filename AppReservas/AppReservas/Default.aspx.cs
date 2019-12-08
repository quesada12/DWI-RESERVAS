using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Collections.ObjectModel;
using System.Drawing;
using AppReservas.Models;
using AppReservas.Controllers;
using System.Text;

namespace AppReservas
{
    public partial class Default : System.Web.UI.Page
    {
        VistasManager manager = new VistasManager();
        IEnumerable<V1> reservasUsuario = new ObservableCollection<V1>();
        IEnumerable<V2> habitacionesHotel = new ObservableCollection<V2>();
        IEnumerable<V3> reservasMes = new ObservableCollection<V3>();

        protected void Page_Load(object sender, EventArgs e)
        {
            InicializarControles();
        }

        async void InicializarControles()
        {
            reservasUsuario = await manager.ObtenerV1(VG.usuarioActual.CadenaToken);
            habitacionesHotel = await manager.ObtenerV2(VG.usuarioActual.CadenaToken);
            reservasMes = await manager.ObtenerV3(VG.usuarioActual.CadenaToken);

            Graficos();
       


        }


        public void Graficos()
        {
            //v1
            StringBuilder nombresUsuario = new StringBuilder();
            StringBuilder cantidadReservas = new StringBuilder();

            foreach (var item in reservasUsuario)
            {
                nombresUsuario.Append("'" + item.NombreUsuario + "'" + ",");
                cantidadReservas.Append(item.CantidadReservas + ",");
            }

            //v2
            StringBuilder nombresHotel = new StringBuilder();
            StringBuilder cantidadHabitaciones = new StringBuilder();

            foreach (var item in habitacionesHotel)
            {
                nombresHotel.Append("'" + item.NombreHotel + "'" + ",");
                cantidadHabitaciones.Append(item.CantidadHabitaciones + ",");
            }

            //v3
            StringBuilder mes = new StringBuilder();
            StringBuilder reservas = new StringBuilder();

            foreach (var item in reservasMes)
            {
                mes.Append("'" + item.Mes + "'" + ",");
                reservas.Append(item.CantidadReservas + ",");
            }


            string html = @"<script>
		    var config1 = {
			type: 'line',
			data: {
				labels: ["+ nombresUsuario.ToString().Substring(0, nombresUsuario.ToString().Length - 1) + @"],
				datasets: [{
					label: 'Reservas',
					backgroundColor: window.chartColors.red,
					borderColor: window.chartColors.red,
					data: ["+ cantidadReservas.ToString().Substring(0, cantidadReservas.ToString().Length-1)+ @"],
					fill: false,
				}]
			},
			options: {
				responsive: true,
				title: {
					display: true,
					text: 'Cantidad de Reservas por Usuario'
				},
				scales: {
					yAxes: [{
						ticks: {
							min: 0,
							max: 6
						}
					}]
				}
			}
		};





     
		var config2 = {
			type: 'pie',
			data: {
				datasets: [{
					data: [" + cantidadHabitaciones.ToString().Substring(0, cantidadHabitaciones.ToString().Length - 1) + @"
					],
					backgroundColor: [
						window.chartColors.red,
						window.chartColors.orange,
						window.chartColors.yellow,
						window.chartColors.green,
						window.chartColors.blue,
					],
					label: 'Dataset 1'
				}],
				labels: [
					" + nombresHotel.ToString().Substring(0, nombresHotel.ToString().Length - 1) + @"
				]
			},
			options: {
				responsive: true,
title: {
					display: true,
					text: 'Cantidad de Habitaciones por Hotel'
				}
			}
		};





    var config3 = {
			type: 'horizontalBar',
			data: {
				labels: [" + mes.ToString().Substring(0, mes.ToString().Length - 1) + @"],
				datasets: [{
					label: 'Reservas',
					backgroundColor: window.chartColors.blue,
					borderColor: window.chartColors.blue,
					data: [" + reservas.ToString().Substring(0, reservas.ToString().Length - 1) + @"],
					fill: false,
				}]
			},
			options: {
				responsive: true,
				title: {
					display: true,
					text: 'Cantidad de Reservas por Mes'
				},
				scales: {
					yAxes: [{
						ticks: {
							min: 0,
							max: 6
						}
					}]
				}
			}
		};






		window.onload = function() {
			var ctx = document.getElementById('gra1').getContext('2d');
			window.myLine = new Chart(ctx, config1);
            var ctx2 = document.getElementById('gra2').getContext('2d');
			window.myPie = new Chart(ctx2, config2);
            var ctx3 = document.getElementById('gra3').getContext('2d');
			window.myPie = new Chart(ctx3, config3);
		};
	</script>";

            Literal1.Text = html;
        }

        

    }
}