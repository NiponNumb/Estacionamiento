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
    public partial class Form3 : Form
    {
        private const string connectionString = "Data Source=it-orpel.com,9700;Initial Catalog=EXAMEN;User Id=sa;Password=Aidan1973.g;MultipleActiveResultSets=True;Integrated Security=False;Encrypt=False;";
        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        private bool BuscarAlumnoPorMatricula(string matricula)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string query = "SELECT COUNT(*) FROM Parking WHERE MatriculaAlumno = @Matricula";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@Matricula", matricula);
                    int count = (int)command.ExecuteScalar();

                    return count > 0; // Devuelve true si se encuentra al menos un registro con la matrícula especificada
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al buscar la matrícula del alumno: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            string matricula = textBox1.Text.Trim();

            if (BuscarAlumnoPorMatricula(matricula))
            {
                // La matrícula del alumno existe, abrir el Form1
                Form1 form1 = new Form1();
                form1.Show();
                this.Hide(); // Ocultar el Form3
            }
            else
            {
                MessageBox.Show("La matrícula del alumno no existe.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
    
}
