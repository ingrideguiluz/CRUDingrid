using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
//importamos 
using MySql.Data.MySqlClient;

namespace CRUDingrid
{
    public partial class Inicio : System.Web.UI.Page
    {
        //Cadena de conexion
        string conexion = @"Server=localhost;Database=dbcrudingrid;Uid=root;Pwd=;";
        //Agregamos la referencia MySql.Data
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                limpiar();
                llenarGF();
            }

        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                using (MySqlConnection mysqlconexion = new MySqlConnection(conexion))
                {
                    mysqlconexion.Open();
                    MySqlCommand mysqlcmd = new MySqlCommand("CrearOActualizar", mysqlconexion);
                    mysqlcmd.CommandType = CommandType.StoredProcedure;
                    mysqlcmd.Parameters.AddWithValue("_iddisco", Convert.ToInt32(HFiddisco.Value == "" ? "0" : HFiddisco.Value));
                    mysqlcmd.Parameters.AddWithValue("_nombre", txtNombre.Text.Trim());
                    mysqlcmd.Parameters.AddWithValue("_precio", Convert.ToDecimal(txtPrecio.Text.Trim()));
                    mysqlcmd.Parameters.AddWithValue("_cantidad", Convert.ToInt32(txtCantidad.Text.Trim()));
                    mysqlcmd.Parameters.AddWithValue("_descripcion", txtDescripcion.Text.Trim());
                    mysqlcmd.ExecuteNonQuery();
                    llenarGF();
                    limpiar();
                    lbExito.Text = "Se ha realizado correctamente el registro";
                }
            }
            catch (Exception exc)
            {

                lbError.Text = "Error: " + exc.Message;
            }
        }

        void limpiar()
        {
            HFiddisco.Value = "";
            txtNombre.Text = "";
            txtPrecio.Text = "";
            txtCantidad.Text = "";
            txtDescripcion.Text = "";
            btnGuardar.Text = "Guardar";
            btnEliminar.Enabled = false;
            lbExito.Text = "";
            lbError.Text = "";
        }
        void llenarGF()
        {
            using (MySqlConnection mysqlconexion = new MySqlConnection(conexion))
            {
                mysqlconexion.Open();
                MySqlDataAdapter mysqlDA = new MySqlDataAdapter("VerTodos", mysqlconexion);
                mysqlDA.SelectCommand.CommandType = CommandType.StoredProcedure;
                DataTable dt = new DataTable();
                mysqlDA.Fill(dt);
                gvDiscos.DataSource = dt;
                gvDiscos.DataBind();

            }
        }

        protected void lnkSeleccionar_OnClick(object sender, EventArgs e)
        {
            limpiar();
            int iddisco = Convert.ToInt32((sender as LinkButton).CommandArgument);
            using (MySqlConnection mysqlconexion = new MySqlConnection(conexion))
            {
                mysqlconexion.Open();
                MySqlDataAdapter mysqlDA = new MySqlDataAdapter("VerPorId", mysqlconexion);
                mysqlDA.SelectCommand.Parameters.AddWithValue("_iddisco", iddisco);
                mysqlDA.SelectCommand.CommandType = CommandType.StoredProcedure;
                DataTable dt = new DataTable();
                mysqlDA.Fill(dt);
                //Enviamos los datos a los txt
                txtNombre.Text = dt.Rows[0][1].ToString();
                txtPrecio.Text = dt.Rows[0][2].ToString();
                txtCantidad.Text = dt.Rows[0][3].ToString();
                txtDescripcion.Text = dt.Rows[0][4].ToString();

                HFiddisco.Value = dt.Rows[0][0].ToString();
                btnGuardar.Text = "Actualizar";
              //  lbExito.Text = "Se ha actualizado correctamente el registro";
                btnEliminar.Enabled = true;
                
            }
      
        }
        protected void btnLimpiar_Click(object sender, EventArgs e)
        {
            limpiar();
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            using (MySqlConnection mysqlconexion = new MySqlConnection(conexion))
            {
                mysqlconexion.Open();
                MySqlCommand mysqlcmd = new MySqlCommand("Eliminar", mysqlconexion);
                mysqlcmd.CommandType = CommandType.StoredProcedure;
                mysqlcmd.Parameters.AddWithValue("_iddisco", Convert.ToInt32(HFiddisco.Value == "" ? "0" : HFiddisco.Value));
                mysqlcmd.ExecuteNonQuery();
                llenarGF();
                limpiar();
                lbError.Text = "Se ha eliminado correctamente el registro";
            }

        }

    }
}