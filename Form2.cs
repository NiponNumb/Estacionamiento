using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Parking
{
    public partial class Form2 : Form
    {
        private const string connectionString = "Data Source=it-orpel.com,9700;Initial Catalog=EXAMEN;User Id=sa;Password=Aidan1973.g;MultipleActiveResultSets=True;Integrated Security=False;Encrypt=False;";

        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            CargarDatosDesdeBaseDeDatos();
        }

        private void CargarDatosDesdeBaseDeDatos()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Verificar si la tabla existe, si no existe, crearla
                    if (!VerificarTablaExistente(connection))
                    {
                        CrearTabla(connection);
                    }

                    // Cargar los datos desde la tabla
                    string query = "SELECT * FROM Parking";
                    SqlCommand command = new SqlCommand(query, connection);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            // Aquí puedes recuperar los datos y usarlos como desees
                            string nombreInstitucion = reader["NombreInstitucion"].ToString();
                            string nombreAlumno = reader["NombreAlumno"].ToString();
                            string matriculaAlumno = reader["MatriculaAlumno"].ToString();
                            string carrera = reader["Carrera"].ToString();
                            int edad = Convert.ToInt32(reader["Edad"]);
                            string nivelAcademico = reader["NivelAcademico"].ToString();
                            string tipoAuto = reader["TipoAuto"].ToString();
                            // ... y así sucesivamente
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar los datos desde la base de datos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool VerificarTablaExistente(SqlConnection connection)
        {
            string query = "SELECT COUNT(*) FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'Parking'";
            SqlCommand command = new SqlCommand(query, connection);
            int count = (int)command.ExecuteScalar();
            return count > 0;
        }

        private void CrearTabla(SqlConnection connection)
        {
            string query = "CREATE TABLE Parking (NombreInstitucion VARCHAR(100), NombreAlumno VARCHAR(100), MatriculaAlumno VARCHAR(50), Carrera VARCHAR(100), Edad INT, NivelAcademico VARCHAR(50), TipoAuto VARCHAR(50))";
            SqlCommand command = new SqlCommand(query, connection);
            command.ExecuteNonQuery();
        }

        private void ActualizarValoresEnBaseDeDatos(string nombreInstitucion, string nombreAlumno, string matriculaAlumno, string carrera, string edad, string nivelAcademico, string tipoAuto)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Actualizar los valores en la tabla
                    string query = @"INSERT INTO Parking (NombreInstitucion, NombreAlumno, MatriculaAlumno, Carrera, Edad, NivelAcademico, TipoAuto) 
                             VALUES (@NombreInstitucion, @NombreAlumno, @MatriculaAlumno, @Carrera, @Edad, @NivelAcademico, @TipoAuto)";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@NombreInstitucion", nombreInstitucion);
                    command.Parameters.AddWithValue("@NombreAlumno", nombreAlumno);
                    command.Parameters.AddWithValue("@MatriculaAlumno", matriculaAlumno);
                    command.Parameters.AddWithValue("@Carrera", carrera);
                    command.Parameters.AddWithValue("@Edad", edad);
                    command.Parameters.AddWithValue("@NivelAcademico", nivelAcademico);
                    command.Parameters.AddWithValue("@TipoAuto", tipoAuto);
                    command.ExecuteNonQuery();

                    MessageBox.Show("Datos guardados correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar los datos en la base de datos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Obtener los valores de los TextBox
            string nombreInstitucion = textBox1.Text;
            string nombreAlumno = textBox2.Text;
            string matriculaAlumno = textBox3.Text;
            string carrera = textBox4.Text;
            string edad = textBox5.Text;
            string nivelAcademico = textBox6.Text;
            string tipoAuto = textBox7.Text;

            // Actualizar los valores en la base de datos
            ActualizarValoresEnBaseDeDatos(nombreInstitucion, nombreAlumno, matriculaAlumno, carrera, edad, nivelAcademico, tipoAuto);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }


}
