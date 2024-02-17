using CRUD_BusinessLayer;
using CRUD_EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CRUD
{
    public partial class About : Page
    {
        private static int idEmpleado = 0;
        DepartamentoBL departamentoBL = new DepartamentoBL();
        EmpleadoBL empleadoBL = new EmpleadoBL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Request.QueryString["id"] != null)
                {
                    idEmpleado = int.Parse(Request.QueryString["id"].ToString());

                    if(idEmpleado != 0)
                    {
                        Empleado empleado = empleadoBL.Obtener(idEmpleado);
                        id.Text = empleado.IdEmpleado.ToString();
                        nombre.Text = empleado.NombreCompleto.ToString();
                        departamento.Text = empleado.Departamento.Nombre.ToString();
                        sueldo.Text = empleado.Sueldo.ToString();
                        fecha.Text = empleado.FechaContrato.ToString();
                    }                   

                    
                }
                else
                {
                    Response.Redirect("~/Default.aspx");
                }
            }
        }
    }
}