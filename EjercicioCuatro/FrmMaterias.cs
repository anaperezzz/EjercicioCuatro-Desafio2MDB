using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace EjercicioCuatro
{
    public partial class FrmMaterias : Form
    {
        private SqlConnection conn;
        private string sCn;

        public FrmMaterias()
        {
            InitializeComponent();
            conexion cn = new conexion();
            cn.conec();
            sCn = cn.cadena;
            conn = new SqlConnection(sCn);
            // Ocultamos los campos de edición/búsqueda de la segunda pestaña al iniciar
            textnombremateria2.Visible = false;
            textuv2.Visible = false;
            textprerrequisitos2.Visible = false;
            btnModificarMateria.Visible = false;
            btnEliminarMateria.Visible = false;

            CargarMaterias();

        }
        private void CargarMaterias()
        {
            try
            {
                using (SqlConnection connGrid = new SqlConnection(sCn))
                {
                    connGrid.Open();
                    string query = "SELECT * FROM Materia";
                    SqlDataAdapter da = new SqlDataAdapter(query, connGrid);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dataGridViewMaterias.DataSource = dt;
                    EstilizarGrid();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar materias: " + ex.Message);
            }
        }
        private void EstilizarGrid()
        {
            dataGridViewMaterias.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewMaterias.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(240, 244, 248);


            if (dataGridViewMaterias.Columns["CodigoMateria"] != null)
            {
                dataGridViewMaterias.Columns["CodigoMateria"].HeaderText = "Código";
                dataGridViewMaterias.Columns["NombreMateria"].HeaderText = "Materia";
                dataGridViewMaterias.Columns["UV"].HeaderText = "U.V.";
                dataGridViewMaterias.Columns["Prerrequisitos"].HeaderText = "Prerrequisitos";
            }
        }

        private void btnInsertarMateria_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(textcodmateria1.Text) || string.IsNullOrWhiteSpace(textnombremateria1.Text))
                {
                    MessageBox.Show("Completa al menos el código y nombre de la materia.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                conn.Open();
                string query = "INSERT INTO Materia (CodigoMateria, NombreMateria, UV, Prerrequisitos) VALUES (@cod, @nombre, @uv, @prereq)";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@cod", textcodmateria1.Text.Trim());
                    cmd.Parameters.AddWithValue("@nombre", textnombremateria1.Text.Trim());
                    cmd.Parameters.AddWithValue("@uv", string.IsNullOrEmpty(textuv1.Text) ? (object)DBNull.Value : Convert.ToInt32(textuv1.Text));
                    cmd.Parameters.AddWithValue("@prereq", string.IsNullOrEmpty(textprerrequisitos1.Text) ? (object)DBNull.Value : textprerrequisitos1.Text.Trim());

                    cmd.ExecuteNonQuery();
                }
                conn.Close();

                MessageBox.Show("Materia agregada exitosamente.");

                // Limpiar cajas de la pestaña 1
                textcodmateria1.Text = "";
                textnombremateria1.Text = "";
                textuv1.Text = "";
                textprerrequisitos1.Text = "";

                CargarMaterias();
            }
            catch (Exception ex)
            {
                if (conn.State == ConnectionState.Open) conn.Close();
                MessageBox.Show("Error al insertar materia: " + ex.Message);
            }
        }

        private void btnBuscarMateria_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(textcodmateria2.Text))
                {
                    MessageBox.Show("Ingresa un código de materia para buscar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                conn.Open();
                string query = "SELECT * FROM Materia WHERE CodigoMateria = @cod";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@cod", textcodmateria2.Text.Trim());
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            textnombremateria2.Text = dr["NombreMateria"].ToString().Trim();
                            textuv2.Text = dr["UV"].ToString().Trim();
                            textprerrequisitos2.Text = dr["Prerrequisitos"].ToString().Trim();

                            // Mostramos los campos y botones de edición
                            textnombremateria2.Visible = true;
                            textuv2.Visible = true;
                            textprerrequisitos2.Visible = true;
                            btnModificarMateria.Visible = true;
                            btnEliminarMateria.Visible = true;

                            MessageBox.Show("Materia encontrada.");
                        }
                        else
                        {
                            MessageBox.Show("No se encontró la materia.");
                            ResetTab2();
                        }
                    }
                }
                conn.Close();
            }
            catch (Exception ex)
            {
                if (conn.State == ConnectionState.Open) conn.Close();
                MessageBox.Show("Error al buscar: " + ex.Message);
            }
        }

        private void btnModificarMateria_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                string query = "UPDATE Materia SET NombreMateria = @nombre, UV = @uv, Prerrequisitos = @prereq WHERE CodigoMateria = @cod";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@cod", textcodmateria2.Text.Trim());
                    cmd.Parameters.AddWithValue("@nombre", textnombremateria2.Text.Trim());
                    cmd.Parameters.AddWithValue("@uv", string.IsNullOrEmpty(textuv2.Text) ? (object)DBNull.Value : Convert.ToInt32(textuv2.Text));
                    cmd.Parameters.AddWithValue("@prereq", string.IsNullOrEmpty(textprerrequisitos2.Text) ? (object)DBNull.Value : textprerrequisitos2.Text.Trim());

                    cmd.ExecuteNonQuery();
                }
                conn.Close();

                MessageBox.Show("Materia actualizada correctamente.");
                ResetTab2();
                CargarMaterias();
            }
            catch (Exception ex)
            {
                if (conn.State == ConnectionState.Open) conn.Close();
                MessageBox.Show("Error al modificar: " + ex.Message);
            }
        }

        private void btnEliminarMateria_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult res = MessageBox.Show("¿Deseas eliminar esta materia?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (res == DialogResult.Yes)
                {
                    conn.Open();
                    string query = "DELETE FROM Materia WHERE CodigoMateria = @cod";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@cod", textcodmateria2.Text.Trim());
                        cmd.ExecuteNonQuery();
                    }
                    conn.Close();

                    MessageBox.Show("Materia eliminada.");
                    ResetTab2();
                    CargarMaterias();
                }
            }
            catch (Exception ex)
            {
                if (conn.State == ConnectionState.Open) conn.Close();
                MessageBox.Show("Error al eliminar: " + ex.Message);
            }
        }

        private void btnActualizarGridMateria_Click(object sender, EventArgs e)
        {
            CargarMaterias();
            MessageBox.Show("Tabla actualizada correctamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnVolverMenu_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void ResetTab2()
        {
            textcodmateria2.Text = "";
            textnombremateria2.Text = "";
            textuv2.Text = "";
            textprerrequisitos2.Text = "";

            textnombremateria2.Visible = false;
            textuv2.Visible = false;
            textprerrequisitos2.Visible = false;
            btnModificarMateria.Visible = false;
            btnEliminarMateria.Visible = false;
        }
    }
}
