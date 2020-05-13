using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

using System.Data;
using System.Data.SqlClient;

namespace WcfServicio
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "ServicioPIT" en el código, en svc y en el archivo de configuración a la vez.
    // NOTA: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione ServicioPIT.svc o ServicioPIT.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class ServicioPIT : IServicioPIT
    {




        SqlConnection cn = new SqlConnection("server=JHOAN-LABRA\\JHOAN;database=PIT;uid=sa;pwd=sql");



        List<Ciudadano> listaCiudadano()
        {
            List<Ciudadano> lista = new List<Ciudadano>();
            SqlCommand cmd = new SqlCommand("USP_ListarCiudadano", cn);
            cn.Open();
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                Ciudadano reg = new Ciudadano();
                reg.idciudadano = dr["idciudadano"].ToString();
                reg.nombres = dr["nombres"].ToString();
                reg.nacionalidad = dr["nacionalidad"].ToString();
                reg.tipodocumento = dr["tipodocumento"].ToString(); 
                reg.numdocumento = dr["numdocumento"].ToString();
                reg.iddepartamento = dr["iddepartamento"].ToString();
                reg.idprovincia = dr["idprovincia"].ToString();
                reg.iddistrito = dr["iddistrito"].ToString();
                reg.idestado = dr["idestado"].ToString();
                lista.Add(reg);

                 
            }
            dr.Close();
            cn.Close();
            return lista;

        }

        public List<Ciudadano> Ciudadanos()
        {

            return listaCiudadano().ToList();
        }

        public string AgregarCiudadano(Ciudadano reg)
        {
            string msg = "";
            cn.Open();
            try
            {
                //SqlCommand cmd = new SqlCommand("Insert ciudadano1 values(@idciudadano,@nombres,@nacionalidad,@tipodocumento,@numdocumento,@iddepartamento,@idprovincia,@iddistrito,@idestado)", cn);
                //cmd.Parameters.AddWithValue("@idciudadano", reg.idciudadano);
                //cmd.Parameters.AddWithValue("@nombres", reg.nombres);
                //cmd.Parameters.AddWithValue("@nacionalidad", reg.nacionalidad);
                //cmd.Parameters.AddWithValue("@tipodocumento", reg.tipodocumento);
                //cmd.Parameters.AddWithValue("@numdocumento", reg.numdocumento);
                //cmd.Parameters.AddWithValue("@iddepartamento", reg.iddepartamento);
                //cmd.Parameters.AddWithValue("@idprovincia", reg.idprovincia);
                //cmd.Parameters.AddWithValue("@iddistrito", reg.iddistrito);
                //cmd.Parameters.AddWithValue("@idestado", reg.idestado);

                SqlCommand cmd = new SqlCommand("USP_AgregarCiudadano", cn);
              
                cmd.Parameters.AddWithValue("@nombres", reg.nombres);
                cmd.Parameters.AddWithValue("@nacionalidad", reg.nacionalidad);
                cmd.Parameters.AddWithValue("@tipodocumento", reg.tipodocumento);
                cmd.Parameters.AddWithValue("@numdocumento", reg.numdocumento);
                cmd.Parameters.AddWithValue("@iddepartamento", reg.iddepartamento);
                cmd.Parameters.AddWithValue("@idprovincia", reg.idprovincia);
                cmd.Parameters.AddWithValue("@iddistrito", reg.iddistrito);
                cmd.Parameters.AddWithValue("@idestado", reg.idestado); 

                int q = cmd.ExecuteNonQuery();
                msg = q.ToString() + " registro agregado";
            }
            catch (SqlException ex)
            {
                msg = ex.Message;
            }
            finally { cn.Close(); }

            return msg;
        }

        public string ActualizarCiudadano(Ciudadano reg)
        {
            string msg = "";
            cn.Open();
            try
            {
                SqlCommand cmd = new SqlCommand("update ciudadano1 set nombres=@nombres,nacionalidad=@nacionalidad,tipodocumento=@tipodocumento,numdocumento=@numdocumento,iddepartamento=@iddepartamento,idprovincia=@idprovincia,iddistrito=@iddistrito,idestado=@idestado where idciudadano=@idciudadano", cn);
                cmd.Parameters.AddWithValue("@idciudadano", reg.idciudadano);
                cmd.Parameters.AddWithValue("@nombres", reg.nombres);
                cmd.Parameters.AddWithValue("@nacionalidad", reg.nacionalidad);
                cmd.Parameters.AddWithValue("@tipodocumento", reg.tipodocumento);
                cmd.Parameters.AddWithValue("@numdocumento", reg.numdocumento);
                cmd.Parameters.AddWithValue("@iddepartamento", reg.iddepartamento);
                cmd.Parameters.AddWithValue("@idprovincia", reg.idprovincia);
                cmd.Parameters.AddWithValue("@iddistrito", reg.iddistrito);
                cmd.Parameters.AddWithValue("@idestado", reg.idestado);

                int q = cmd.ExecuteNonQuery();
                msg = q.ToString() + " registro actualizado";
            }
            catch (SqlException ex)
            {
                msg = ex.Message;
            }
            finally { cn.Close(); }

            return msg;
        }


        public Ciudadano DetalleCiudadano(string id)
        {
            //"select * from ciudadano1 where idciudadano=@idciudadano"
            SqlCommand cmd = new SqlCommand("USP_DetalleCiudadano", cn);
            cmd.Parameters.AddWithValue("@idciudadano", id);
            cn.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            Ciudadano reg = new Ciudadano();
            if (dr.Read())
            {
                reg.idciudadano = dr["idciudadano"].ToString();
                reg.nombres = dr["nombres"].ToString();
                reg.nacionalidad = dr["nacionalidad"].ToString();
                reg.tipodocumento = dr["tipodocumento"].ToString();
                reg.numdocumento = dr["numdocumento"].ToString();
                reg.iddepartamento = dr["iddepartamento"].ToString();
                reg.idprovincia = dr["idprovincia"].ToString();
                reg.iddistrito = dr["iddistrito"].ToString();
                reg.idestado = dr["idestado"].ToString();

            }
            dr.Close();
            cn.Close();
            return reg;
        }

        public string EliminarCiudadano(string id)
        {
            string msg = "";
            cn.Open();
            try
            {
                SqlCommand cmd = new SqlCommand("delete from ciudadano1 where idciudadano", cn);
                cmd.Parameters.AddWithValue("idciudadano", id);

                int q = cmd.ExecuteNonQuery();
                msg = q.ToString() + " registro eliminado";
            }
            catch (SqlException ex)
            {
                msg = ex.Message;
            }
            finally { cn.Close(); }

            return msg;
        }





        public string AgregarUsers(Ciudadano reg)
        {
            throw new NotImplementedException();
        }


        public string ActualizarUsers(Ciudadano reg)
        {
            throw new NotImplementedException();
        }
        

        public Ciudadano DetalleUsers(string id)
        {
            throw new NotImplementedException();
        }

        public void DoWork()
        {
        }

      
        public string EliminarUsers(string id)
        {
            throw new NotImplementedException();
        }


        List<Users> listaUsuario()
        {
            List<Users> lista = new List<Users>();
            SqlCommand cmd = new SqlCommand("select idcliente,nombrecia,direccion,idpais,telefono from tb_clientes", cn);
            cn.Open();
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                Users reg = new Users();
                reg.id = dr["id"].ToString();
                reg.nombre = dr["nombre"].ToString();
                reg.apellidos = dr["apellido"].ToString();
                reg.dni = dr["dni"].ToString();
                reg.direccion = dr["direccion"].ToString();
                reg.usuario = dr["usuario"].ToString();
                reg.contraseña = dr["contraseña"].ToString();
                lista.Add(reg);
            }
            dr.Close();
            cn.Close();
            return lista;

        }
        public List<Users> Users()
        {
            return listaUsuario().ToList();
        }

         
    }
}
