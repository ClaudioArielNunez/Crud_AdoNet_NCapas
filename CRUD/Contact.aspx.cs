using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CRUD_EntityLayer;
using CRUD_BusinessLayer;
using System.Globalization; //para convertir decimales a una region

namespace CRUD
{
    public partial class Contact : Page
    {
        private static int idEmpleado = 0;
        DepartamentoBL departamentoBL = new DepartamentoBL();   
        EmpleadoBL empleadoBL = new EmpleadoBL();


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                //Si no se volvio a cargar Entra la primera vez
                if (Request.QueryString["idEmpleado"] != null)
                {
                    idEmpleado = Convert.ToInt32(Request.QueryString["idEmpleado"]);

                    if(idEmpleado != 0)
                    {
                        lblTitulo.Text = "Editar Empleado";
                        btnSubmit.Text = "Actualizar";

                        Empleado empleado = empleadoBL.Obtener(idEmpleado);
                        txtNombreCompleto.Text = empleado.NombreCompleto;
                        CargarDepartamentos(empleado.Departamento.IdDepartamento.ToString());                        
                        txtSueldo.Text = empleado.Sueldo.ToString();//no necesita textmode en contacto.aspx
                        //Si en fecha se cambia "yyyy-MM-dd" por "dd-MM-yyyy" no se muestra ,esto puede deberse a un tema de CultureInfo
                        txtFechaContrato.Text = Convert.ToDateTime(empleado.FechaContrato).ToString("yyyy-MM-dd");
                    }
                    else
                    {
                        //si es id= 0 es porque es un nuevo usuario
                        lblTitulo.Text = "Nuevo Empleado";
                        btnSubmit.Text = "Agregar";
                        CargarDepartamentos();
                    }
                }
                else
                {
                    Response.Redirect("~/Default.aspx");
                }
            }
        }

        private void CargarDepartamentos(string idDepartamento = "")
        {
            List<Departamento> lista = departamentoBL.Lista();
            ddlDepartamento.DataTextField = "Nombre";
            ddlDepartamento.DataValueField = "IdDepartamento";
            ddlDepartamento.DataSource = lista;
            ddlDepartamento.DataBind();

            if(idDepartamento != "")
            {
                ddlDepartamento.SelectedValue = idDepartamento;
            }
        }


        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            Empleado entidad = new Empleado();
            entidad.IdEmpleado = idEmpleado;
            entidad.NombreCompleto = txtNombreCompleto.Text;
            entidad.Departamento = new Departamento();
            entidad.Departamento.IdDepartamento = Convert.ToInt32(ddlDepartamento.SelectedValue);
            entidad.Sueldo = Convert.ToDecimal(txtSueldo.Text);
            entidad.FechaContrato = txtFechaContrato.Text;

            bool respuesta;

            if(idEmpleado != 0)
            {
                respuesta = empleadoBL.Editar(entidad);
            }
            else
            {
                respuesta = empleadoBL.Crear(entidad);
            }

            if(respuesta)
            {
                Response.Redirect("~/Default.aspx");
            }
            else
            {
                ScriptManager.RegisterStartupScript(this,this.GetType(),"script","alert('No se pudo realizar la operacion')",true);
            }
        }
    }
}