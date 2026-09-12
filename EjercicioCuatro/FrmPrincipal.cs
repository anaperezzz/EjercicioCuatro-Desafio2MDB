using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EjercicioCuatro
{
    public partial class FrmPrincipal : Form
    {
        private SqlConnection conn;
        private SqlCommand insert1;
        private SqlDataAdapter da1;
        private SqlDataReader dr1;
        private string sCn;
        OleDbConnection cnn = new OleDbConnection();
        public FrmPrincipal()
        {
            InitializeComponent();
            conexion cn = new conexion();
            cn.conec();
            sCn = cn.cadena;
            conn = new SqlConnection(sCn);
            conn.Open();
            cnn.ConnectionString = @"PROVIDER=SQLOLEDB;Server=3375898HP;Database=db_tarea;Uid=sa;Pwd=123456";

            // Ocultamos los campos de búsqueda/edición
            textnombre1.Visible = false;
            textsnombre1.Visible = false;
            textapellido1.Visible = false;
            textsapellido1.Visible = false;
            textedad1.Visible = false;
            textdireccion1.Visible = false;
            modificar1.Visible = false;
            btnEliminar.Visible = false;

            CargarDatos();
        }

        private void buscar1_Click(object sender, EventArgs e)
        {

        }

        private void insertar2_Click(object sender, EventArgs e)
        {
            try
            {
                // Validar campos vacíos primero
                if (string.IsNullOrWhiteSpace(textcod2.Text) ||
                    string.IsNullOrWhiteSpace(textnombre2.Text) ||
                    string.IsNullOrWhiteSpace(textapellido2.Text))
                {
                    MessageBox.Show("Por favor, completa al menos el código, los nombres y apellidos obligatorios.", "Campos vacíos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Validar que la edad sea un número valido
                int edadValida;
                if (!string.IsNullOrEmpty(textedad2.Text) && !int.TryParse(textedad2.Text, out edadValida))
                {
                    MessageBox.Show("El campo de edad debe contener únicamente números.", "Dato inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    textedad2.Focus();
                    return;
                }
                string inserparticipante;
                inserparticipante = "INSERT INTO Alumno(CodigoAlumno, PrimerNombre, SegundoNombre, PrimerApellido, SegundoApellido, Edad, Direccion)";
                inserparticipante += " VALUES(@codigo, @pnombre, @snombre, @papellido, @sapellido, @edad, @direccion)";

                insert1 = new SqlCommand(inserparticipante, conn);

                insert1.Parameters.Add(new SqlParameter("@codigo", SqlDbType.Char));
                insert1.Parameters["@codigo"].Value = textcod2.Text;

                insert1.Parameters.Add(new SqlParameter("@pnombre", SqlDbType.VarChar));
                insert1.Parameters["@pnombre"].Value = textnombre2.Text;

                insert1.Parameters.Add(new SqlParameter("@snombre", SqlDbType.VarChar));
                insert1.Parameters["@snombre"].Value = textsnombre2.Text;

                insert1.Parameters.Add(new SqlParameter("@papellido", SqlDbType.VarChar));
                insert1.Parameters["@papellido"].Value = textapellido2.Text;

                insert1.Parameters.Add(new SqlParameter("@sapellido", SqlDbType.VarChar));
                insert1.Parameters["@sapellido"].Value = textsapellido2.Text;

                insert1.Parameters.Add(new SqlParameter("@edad", SqlDbType.Int));
                insert1.Parameters["@edad"].Value = textedad2.Text;

                insert1.Parameters.Add(new SqlParameter("@direccion", SqlDbType.VarChar));
                insert1.Parameters["@direccion"].Value = textdireccion2.Text;

                insert1.ExecuteNonQuery();

                textcod2.Text = "";
                textnombre2.Text = "";
                textsnombre2.Text = "";
                textapellido2.Text = "";
                textsapellido2.Text = "";
                textedad2.Text = "";
                textdireccion2.Text = "";

                MessageBox.Show("Registro agregado exitosamente");
                CargarDatos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al insertar: " + ex.Message);
            }
        }

        private void buscar1_Click_1(object sender, EventArgs e)
        {
            textnombre1.Visible = true;
            textsnombre1.Visible = true;
            textapellido1.Visible = true;
            textsapellido1.Visible = true;
            textedad1.Visible = true;
            textdireccion1.Visible = true;
            modificar1.Visible = true;
            btnEliminar.Visible = true;

            string seleccion;
            seleccion = "Select * From Alumno where CodigoAlumno = '" + textcod1.Text + "'";
            da1 = new SqlDataAdapter(seleccion, conn);

            SqlParameter prm = new SqlParameter("CodigoAlumno", SqlDbType.Char);
            prm.Value = textcod1.Text;
            da1.SelectCommand.Parameters.Add(prm);

            dr1 = da1.SelectCommand.ExecuteReader();
            while (dr1.Read())
            {
                textnombre1.Text = dr1["PrimerNombre"].ToString().Trim();
                textsnombre1.Text = dr1["SegundoNombre"].ToString().Trim();
                textapellido1.Text = dr1["PrimerApellido"].ToString().Trim();
                textsapellido1.Text = dr1["SegundoApellido"].ToString().Trim();
                textedad1.Text = dr1["Edad"].ToString().Trim();
                textdireccion1.Text = dr1["Direccion"].ToString().Trim();
            }

            if (dr1 != null)
            {
                MessageBox.Show("Datos Encontrados");
                dr1.Close();
            }

        }

        private void modificar1_Click(object sender, EventArgs e)
        {
            string actualizar;
            actualizar = "update Alumno set ";
            actualizar += "PrimerNombre = '" + textnombre1.Text + "', ";
            actualizar += "SegundoNombre = '" + textsnombre1.Text + "', ";
            actualizar += "PrimerApellido = '" + textapellido1.Text + "', ";
            actualizar += "SegundoApellido = '" + textsapellido1.Text + "', ";
            actualizar += "Edad = " + textedad1.Text + ", ";
            actualizar += "Direccion = '" + textdireccion1.Text + "' ";
            actualizar += "where CodigoAlumno = '" + textcod1.Text + "'";

            OleDbCommand datos = new OleDbCommand(actualizar, cnn);
            cnn.Open();
            datos.ExecuteNonQuery();
            cnn.Close();

            MessageBox.Show("REGISTRO ACTUALIZADO");
            Reset();
            CargarDatos();
        }
        private void Reset()
        {
            textcod1.Text = "";
            textnombre1.Text = "";
            textsnombre1.Text = "";
            textapellido1.Text = "";
            textsapellido1.Text = "";
            textedad1.Text = "";
            textdireccion1.Text = "";

            textnombre1.Visible = false;
            textsnombre1.Visible = false;
            textapellido1.Visible = false;
            textsapellido1.Visible = false;
            textedad1.Visible = false;
            textdireccion1.Visible = false;
            modificar1.Visible = false;
            btnEliminar.Visible = false;
        }
        private void CargarDatos()
        {
            try
            {
                using (SqlConnection connGrid = new SqlConnection(sCn))
                {
                    connGrid.Open();
                    string query = "SELECT * FROM Alumno";
                    SqlDataAdapter daGrid = new SqlDataAdapter(query, connGrid);
                    DataTable dtGrid = new DataTable();
                    daGrid.Fill(dtGrid);

                    dataGridView1.DataSource = dtGrid;
                    EstilizarGrid();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar la tabla: " + ex.Message);
            }
        }

        private void EstilizarGrid()
        {
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(240, 244, 248);

            // Renombrar encabezados (siempre y cuando las columnas existan)
            if (dataGridView1.Columns["CodigoAlumno"] != null)
            {
                dataGridView1.Columns["CodigoAlumno"].HeaderText = "Carnet";
                dataGridView1.Columns["PrimerNombre"].HeaderText = "1er Nombre";
                dataGridView1.Columns["SegundoNombre"].HeaderText = "2do Nombre";
                dataGridView1.Columns["PrimerApellido"].HeaderText = "1er Apellido";
                dataGridView1.Columns["SegundoApellido"].HeaderText = "2do Apellido";
                dataGridView1.Columns["Edad"].HeaderText = "Edad";
                dataGridView1.Columns["Direccion"].HeaderText = "Dirección";
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(textcod1.Text))
                {
                    MessageBox.Show("Por favor, ingresa o busca el código del alumno que deseas eliminar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                DialogResult resultado = MessageBox.Show("¿Estás seguro de eliminar este registro?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (resultado == DialogResult.Yes)
                {
                    string queryDelete = "DELETE FROM Alumno WHERE CodigoAlumno = @codigo";
                    using (SqlCommand cmdDelete = new SqlCommand(queryDelete, conn))
                    {
                        cmdDelete.Parameters.AddWithValue("@codigo", textcod1.Text.Trim());
                        int filas = cmdDelete.ExecuteNonQuery();

                        if (filas > 0)
                        {
                            MessageBox.Show("Registro eliminado exitosamente.");
                            Reset();
                            CargarDatos(); // Actualiza la tabla automáticamente
                        }
                        else
                        {
                            MessageBox.Show("No se encontró ningún alumno con ese código.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar: " + ex.Message);
            }
        }

        private void btnActualizarTabla_Click(object sender, EventArgs e)
        {
            CargarDatos();
            MessageBox.Show("Tabla actualizada correctamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
