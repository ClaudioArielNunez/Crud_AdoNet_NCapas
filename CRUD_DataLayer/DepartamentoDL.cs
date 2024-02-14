using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CRUD_EntityLayer; //AGREGADA A REFERENCIAS
using System.Data;
using System.Data.SqlClient;

namespace CRUD_DataLayer
{
    public class DepartamentoDL
    {
        public List<Departamento> Lista()
        {
            List<Departamento> lista = new List<Departamento>();

            using (SqlConnection oConexion = new SqlConnection(Conexion.cadena))
            {
                SqlCommand cmd = new SqlCommand( "Select * from FN_Departamentos()", oConexion);
                cmd.CommandType = CommandType.Text;
                try
                {
                    oConexion.Open();
                    using (SqlDataReader dr = cmd.ExecuteReader()) 
                    {
                        while (dr.Read())
                        {
                            lista.Add(new Departamento
                            {
                                IdDepartamento = int.Parse(dr["IdDepartamento"].ToString()),
                                Nombre = dr["Nombre"].ToString()
                            }) ;
                        }
                    }
                    return lista;
                }
                catch (Exception ex)
                {

                    throw ex;
                }
            }
        }
        
    }
}
