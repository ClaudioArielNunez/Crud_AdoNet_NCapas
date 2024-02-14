using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CRUD_EntityLayer;
using System.Data.SqlClient;
using System.Security.Cryptography.X509Certificates;
using System.Data;
using CRUD_DataLayer;

namespace CRUD_EntityLayer
{
    public class EmpleadoDL
    {
        public List<Empleado> Lista()
        {
           List<Empleado> lista = new List<Empleado>();

            using (SqlConnection oConexion = new SqlConnection(Conexion.cadena))
            {
                SqlCommand cmd = new SqlCommand( "Select * from FN_Empleados()", oConexion);
                cmd.CommandType = CommandType.Text;
                try
                {
                    oConexion.Open();
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            var empleado = new Empleado();
                            empleado.IdEmpleado = int.Parse(dr["IdEmpleado"].ToString());
                            empleado.NombreCompleto = dr["NombreCompleto"].ToString();
                            empleado.Departamento = new Departamento();
                            empleado.Departamento.IdDepartamento = int.Parse(dr["IdDepartamento"].ToString());
                            empleado.Departamento.Nombre = dr["Nombre"].ToString();
                            empleado.Sueldo = (decimal)dr["Sueldo"];
                            empleado.FechaContrato = dr["FechaContrato"].ToString();

                            lista.Add(empleado);
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

        public Empleado Obtener(int id)
        {
            Empleado empleado = new Empleado();

            using (SqlConnection oConexion = new SqlConnection(Conexion.cadena))
            {
                SqlCommand cmd = new SqlCommand("Select * from FN_Empleado(@IdEmpleado)", oConexion);
                cmd.Parameters.AddWithValue("@IdEmpleado", id);
                cmd.CommandType = CommandType.Text;

                try
                {
                    oConexion.Open();
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if(dr.Read())
                        {
                            empleado.IdEmpleado = (int)dr["IdEmpleado"];
                            empleado.NombreCompleto = (string)dr["NombreCompleto"];
                            empleado.Departamento = new Departamento();
                            empleado.Departamento.IdDepartamento = (int)dr["IdDepartamento"];
                            empleado.Departamento.Nombre = (string)dr["Nombre"];
                            empleado.Sueldo = (decimal)dr["Sueldo"];
                            empleado.FechaContrato = (string)dr["FechaContrato"];
                        }
                    }
                    return empleado;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }        

        public bool Crear(Empleado empleado)
        {
            bool respuesta = false;

            using (SqlConnection oconexion = new SqlConnection(Conexion.cadena))
            {
                SqlCommand cmd = new SqlCommand("SP_CrearEmpleado", oconexion);
                cmd.Parameters.AddWithValue("@NombreCompleto", empleado.NombreCompleto);
                cmd.Parameters.AddWithValue("@IdDepartamento", empleado.Departamento.IdDepartamento);
                cmd.Parameters.AddWithValue("@Sueldo", empleado.Sueldo);
                cmd.Parameters.AddWithValue("@FechaContrato", empleado.FechaContrato);
                cmd.CommandType = CommandType.StoredProcedure;

                try
                {
                    oconexion.Open();
                    int filasAfectadas = cmd.ExecuteNonQuery();
                    if(filasAfectadas > 0)
                    {
                        respuesta = true;
                    }

                    return respuesta;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

    }

}
