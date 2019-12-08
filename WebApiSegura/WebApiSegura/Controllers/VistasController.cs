using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApiSegura.Models;
using System.Data.SqlClient;

namespace WebApiSegura.Controllers
{
    [AllowAnonymous]
    [RoutePrefix("api/vistas")]
    public class VistasController : ApiController
    {

        [HttpGet]
        [Route("vista1")]
        public IHttpActionResult GetAllV1()
        {
            List<V1> reservasUsuario = new List<V1>();

            try
            {
                using (SqlConnection connection =
                    new SqlConnection(
                        System.Configuration.ConfigurationManager.ConnectionStrings["RESERVAS"].ConnectionString))
                {
                    SqlCommand sqlCommand = new SqlCommand("SELECT *" +

                        "FROM CantidadReservasUsuario", connection);

                    connection.Open();

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

                    while (sqlDataReader.Read())
                    {
                        V1 result = new V1()
                        {
                            NombreUsuario = sqlDataReader.GetString(0),
                            CantidadReservas = sqlDataReader.GetInt32(1),
                        

                        };
                        reservasUsuario.Add(result);
                    }

                    connection.Close();
                }
            }
            catch (Exception)
            {

                throw;
            }

            return Ok(reservasUsuario);
        }

        [HttpGet]
        [Route("vista2")]
        public IHttpActionResult GetAllV2()
        {
            List<V2> habitacionesHotel = new List<V2>();

            try
            {
                using (SqlConnection connection =
                    new SqlConnection(
                        System.Configuration.ConfigurationManager.ConnectionStrings["RESERVAS"].ConnectionString))
                {
                    SqlCommand sqlCommand = new SqlCommand("SELECT *" +

                        "FROM HabitacionesPorHotel", connection);

                    connection.Open();

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

                    while (sqlDataReader.Read())
                    {
                        V2 result = new V2()
                        {
                            NombreHotel = sqlDataReader.GetString(0),
                            CantidadHabitaciones = sqlDataReader.GetInt32(1),


                        };
                        habitacionesHotel.Add(result);
                    }

                    connection.Close();
                }
            }
            catch (Exception)
            {

                throw;
            }

            return Ok(habitacionesHotel);
        }


        [HttpGet]
        [Route("vista3")]
        public IHttpActionResult GetAllV3()
        {
            List<V3> reservasMes = new List<V3>();

            try
            {
                using (SqlConnection connection =
                    new SqlConnection(
                        System.Configuration.ConfigurationManager.ConnectionStrings["RESERVAS"].ConnectionString))
                {
                    SqlCommand sqlCommand = new SqlCommand("SELECT *" +

                        "FROM ReservasPorMesHotel ORDER BY Mes DESC", connection);

                    connection.Open();

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

                    while (sqlDataReader.Read())
                    {
                        V3 result = new V3()
                        {
                            NombreHotel = sqlDataReader.GetString(0),
                            Mes = sqlDataReader.GetString(1),
                            CantidadReservas = sqlDataReader.GetInt32(2),


                        };
                        reservasMes.Add(result);
                    }

                    connection.Close();
                }
            }
            catch (Exception)
            {

                throw;
            }

            return Ok(reservasMes);
        }

    }
}
