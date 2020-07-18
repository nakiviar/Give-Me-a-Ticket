using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using WCF_Servicio.Models;



namespace WCF_Servicio
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "Service1" en el código, en svc y en el archivo de configuración.
    // NOTE: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione Service1.svc o Service1.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class Service1 : IService1
    {
        public string agregar_asiento(Pasaje reg)
        {
            string mensaje = "";
            using (SqlConnection cn = new SqlConnection("server=.;database=BDFinal; integrated security=true"))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand(
                     "sp_agregar_asiento", cn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@idHorario", reg.idHorario);
                    cmd.Parameters.AddWithValue("@dniper", reg.dniper);
                    cmd.Parameters.AddWithValue("@nomper", reg.nomper);
                    cmd.Parameters.AddWithValue("@nasiento", reg.nasiento);
                    cmd.Parameters.AddWithValue("@precio", reg.precio);
                    cn.Open();
                    cmd.ExecuteNonQuery();
                    mensaje = "Pasaje Registrado";
                }
                catch (SqlException ex) { mensaje = ex.Message; }
                finally { cn.Close(); }
            }
            return mensaje;

        }

        public List<Horario> listado_Horarios(int idCiudad)
        {

            List<Horario> temporal = new List<Horario>();
            using (SqlConnection cn = new SqlConnection(
                "server=.;database=BDFinal;integrated security=true"))
            {
                SqlCommand cmd = new SqlCommand("sp_listar_horarios", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@cod", idCiudad);
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    // etDateTime(1).ToString("yyyy-MM-dd h:m:s"),
                    Horario reg = new Horario()
                    {
                        idHorario = dr.GetInt32(0),
                        idCiudad =idCiudad,
                        fechasalida =dr.GetDateTime(1),
                        horasalida = dr.GetString(2),
                        placa = dr.GetString(3),
                        costo=dr.GetDecimal(4)
                    };
                    temporal.Add(reg);
                }
                dr.Close(); cn.Close();
            }
            return temporal;

        }
        public List<Ciudad> listadoCiudad()
        {

                List<Ciudad> temporal = new List<Ciudad>();
                using (SqlConnection cn = new SqlConnection(
                    "server=.;database=BDFinal;integrated security=true"))
                {
                SqlCommand cmd = new SqlCommand("sp_listar_ciudades", cn); 
                cmd.CommandType = CommandType.StoredProcedure;  
                cn.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                    Ciudad reg = new Ciudad()
                    {
                        idCiudad = dr.GetInt32(0),
                        nomCiudad = dr.GetString(1)
                    };
                    temporal.Add(reg);
                    }
                    dr.Close(); cn.Close();
                }
                return temporal;
            
        }
        public List<Pasaje> listado_Pasajes(int idHorario)
        {

            List<Pasaje> temporal = new List<Pasaje>();
            using (SqlConnection cn = new SqlConnection(
                "server=.;database=BDFinal;integrated security=true"))
            {
                SqlCommand cmd = new SqlCommand("sp_listar_pasajes", cn);

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@hor", idHorario);
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Pasaje reg = new Pasaje()
                    {
                        npasaje = dr.GetInt32(0),
                        idHorario=dr.GetInt32(1),
                        dniper=dr.GetString(2),
                        nomper=dr.GetString(3),
                        nasiento=dr.GetInt32(4),
                        precio=dr.GetDouble(5)
                    };
                   
                    temporal.Add(reg);
                }
                dr.Close(); cn.Close();
            }
            return temporal;

        }

        public Horario horario_Esp(int idHorario)
        {
            return Horarios().Where(x => x.idHorario == idHorario).FirstOrDefault();
        }

        public List<Horario> Horarios()
        {

            List<Horario> temporal = new List<Horario>();
            using (SqlConnection cn = new SqlConnection(
                "server=.;database=BDFinal;integrated security=true"))
            {
                SqlCommand cmd = new SqlCommand("select * from tb_horario", cn);
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    // etDateTime(1).ToString("yyyy-MM-dd h:m:s"),
                    Horario reg = new Horario()
                    {
                        idHorario = dr.GetInt32(0),
                        idCiudad = dr.GetInt32(1),
                        fechasalida = dr.GetDateTime(2),
                        horasalida = dr.GetString(3),
                        placa = dr.GetString(4),
                        costo = dr.GetDecimal(5)
                    };
                    temporal.Add(reg);
                }
                dr.Close(); cn.Close();
            }
            return temporal;
        }

        //FINAL

    }
}
