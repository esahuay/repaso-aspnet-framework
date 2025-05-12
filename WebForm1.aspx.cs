using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Repaso
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        string cadena = ConfigurationManager.ConnectionStrings["TestConnectionString"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) Cargar();

        }

        void Cargar()
        {
            DDL_USR_DEPTO.Items.Clear();
            DDL_MUN_DEPTO.Items.Clear();
            DDL_USR_DEPTO.Items.Insert(0, new ListItem("-- Selecciona un municipio --", "0"));
            DDL_MUN_DEPTO.Items.Insert(0, new ListItem("-- Selecciona un municipio --", "0"));
            CargarMunicipios(0);
            SqlDSDepartamentos.DataBind(); // Esto vuelve a ejecutar el SELECT
            DDL_USR_DEPTO.DataBind();  // Esto vuelve a llenar el DropDownList
            DDL_MUN_DEPTO.DataBind();
        }

        void CargarMunicipios(int idDepartamento)
        {
            using (SqlConnection con = new SqlConnection(cadena))
            {
                DDL_USR_MUN.Items.Clear();

                SqlCommand cmd = new SqlCommand("SELECT IDMunicipio, Nombre FROM Municipio WHERE IDDepartamento = @idDepto", con);
                cmd.Parameters.AddWithValue("@idDepto", idDepartamento);
                con.Open();

                DDL_USR_MUN.DataSource = cmd.ExecuteReader();
                DDL_USR_MUN.DataTextField = "Nombre";
                DDL_USR_MUN.DataValueField = "IDMunicipio";
                DDL_USR_MUN.DataBind();
            }

            // Insertar opción inicial
            DDL_USR_MUN.Items.Insert(0, new ListItem("-- Selecciona un municipio --", "0"));
        }

        void limpiar()
        {
            TB_Depto.Text = string.Empty;
            TB_MUN.Text = string.Empty;
            TB_USR.Text = string.Empty;
            TB_TELUSR.Text = string.Empty;
            Cargar();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(cadena))
            {
                SqlCommand cmd = new SqlCommand("INSERT INTO Departamento (Nombre) VALUES (@Nombre)", con);
                cmd.Parameters.AddWithValue("@Nombre", TB_Depto.Text);
                con.Open();
                cmd.ExecuteNonQuery();
                limpiar();
            }
        }

        protected void BTN_MUN_Click(object sender, EventArgs e)
        {
            if(int.Parse(DDL_MUN_DEPTO.SelectedValue) > 0)
            {
                using (SqlConnection con = new SqlConnection(cadena))
                {
                    SqlCommand cmd = new SqlCommand("INSERT INTO Municipio (Nombre, IDDepartamento) VALUES (@Nombre, @IDDepartamento)", con);
                    cmd.Parameters.AddWithValue("@Nombre", TB_MUN.Text);
                    cmd.Parameters.AddWithValue("@IDDepartamento", DDL_MUN_DEPTO.SelectedValue);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    limpiar();
                }
            }
            string script = "alert('Por favor, seleccione un departamento válido.');";
            ClientScript.RegisterStartupScript(this.GetType(), "Alerta", script, true);
        }

        protected void BTN_USR_Click(object sender, EventArgs e)
        {
            if (int.Parse(DDL_USR_MUN.SelectedValue) > 0 && int.Parse(DDL_USR_DEPTO.SelectedValue) > 0)
            {
                using (SqlConnection con = new SqlConnection(cadena))
                {
                    SqlCommand cmd = new SqlCommand("INSERT INTO Municipio (Nombre, telefono) VALUES (@Nombre, @telefono, IDMunicipio, IDDepartamento)", con);
                    cmd.Parameters.AddWithValue("@Nombre", TB_USR.Text);
                    cmd.Parameters.AddWithValue("@telefono", TB_TELUSR.Text);
                    cmd.Parameters.AddWithValue("@IDMunicipio", DDL_USR_MUN.SelectedValue);
                    cmd.Parameters.AddWithValue("@IDDepartamento", DDL_USR_DEPTO.SelectedValue);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    limpiar();
                }
            }
            string script = "alert('Por favor, seleccione un departamento/municipio válido.');";
            ClientScript.RegisterStartupScript(this.GetType(), "Alerta", script, true);
        }

        protected void DDL_MUN_DEPTO_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void DDL_USR_DEPTO_SelectedIndexChanged(object sender, EventArgs e)
        {
            int idDepto;
            if (int.TryParse(DDL_USR_DEPTO.SelectedValue, out idDepto) && idDepto > 0)
            {
                CargarMunicipios(idDepto);
            }
            else
            {
                string script = "alert('Por favor, seleccione un departamento válido.');";
                ClientScript.RegisterStartupScript(this.GetType(), "Alerta", script, true);

                DDL_USR_MUN.Items.Clear();
                DDL_USR_MUN.Items.Add(new ListItem("-- Selecciona un Departamento --", "0"));
            }
        }
    }
}