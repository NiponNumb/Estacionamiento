using System.Drawing;
using System.Windows.Forms;

namespace Parking
{
    public partial class Form1 : Form
    {
        private bool[] lugaresEstacionamiento = new bool[22];
        private DateTime[] tiemposInicio = new DateTime[22];
        private Label[] labelsArray;
        public Form1()
        {
            InitializeComponent();

            for (int i = 0; i < lugaresEstacionamiento.Length; i++)
            {
                lugaresEstacionamiento[i] = false;
            }
        }
        private void IniciarEstacionamiento(int indice)
        {
            lugaresEstacionamiento[indice] = true;
            tiemposInicio[indice] = DateTime.Now;
            CambiarColorPictureBox(indice);
        }
        private void FinalizarEstacionamiento(int indice)
        {
            lugaresEstacionamiento[indice] = false;
            CambiarColorPictureBox(indice);

            // Calcular la duración del estacionamiento
            TimeSpan duracion = DateTime.Now - tiemposInicio[indice];

            // Cobrar según la tarifa
            double tarifaPorMinuto = 0.1666666667; // 5 pesos por 30 minutos
            double costo = Math.Ceiling(duracion.TotalMinutes / 30) * tarifaPorMinuto;

            // Generar ticket con la información
            GenerarTicket(indice, duracion, costo);
        }
        private void GenerarTicket(int indice, TimeSpan duracion, double costo)
        {
            string mensaje = $"Ticket de estacionamiento\n" +
                             $"Lugar: {indice + 1}\n" +
                             $"Fecha y hora de inicio: {tiemposInicio[indice]}\n" +
                             $"Duración: {duracion.TotalMinutes} minutos\n" +
                             $"Costo: {costo:C}";

            MessageBox.Show(mensaje, "Ticket", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void CambiarColorPictureBox(int indice)
        {
            // Cambiar el color del PictureBox en función del estado del lugar de estacionamiento
            if (lugaresEstacionamiento[indice])
            {
                pictureBoxArray[indice].Image = Properties.Resources.Carrito; // Ocupado
            }
            else
            {
                pictureBoxArray[indice].Image = Properties.Resources.Blanco; // Libre
            }
        }
        // Crear un arreglo de PictureBox para facilitar la gestión
        private PictureBox[] pictureBoxArray;

        private void MostrarLabel(int indice)
        {
            // Mostrar el label correspondiente al lugar desocupado
            labelsArray[indice].Visible = true;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Inicializar el arreglo de PictureBox
            pictureBoxArray = new PictureBox[] { pictureBox2, pictureBox3, pictureBox4, pictureBox5, pictureBox6, pictureBox7, pictureBox8, pictureBox9, pictureBox10, pictureBox11, pictureBox12, pictureBox13, pictureBox14, pictureBox15, pictureBox16, pictureBox17, pictureBox18, pictureBox19, pictureBox20, pictureBox21, pictureBox22, pictureBox23 };
            labelsArray = new Label[] { label1, label2, label3, label4, label5, label6, label7, label8, label9, label10, label11, label12, label13, label14, label15, label16, label17, label18, label19, label20, label21, label22};
            // Asignar el mismo evento de clic a cada PictureBox
            foreach (PictureBox pictureBox in pictureBoxArray)
            {
                pictureBox.Click += PictureBox_Click;
            }

            // Inicializar colores de los PictureBox
            for (int i = 0; i < pictureBoxArray.Length; i++)
            {
                CambiarColorPictureBox(i);
                labelsArray[i].Visible = false;
            }
        }
        private void PictureBox_Click(object sender, EventArgs e)
        {
            PictureBox pictureBox = (PictureBox)sender;
            int indice = Array.IndexOf(pictureBoxArray, pictureBox);

            if (!lugaresEstacionamiento[indice])
            {
                IniciarEstacionamiento(indice);
            }
            else
            {
                FinalizarEstacionamiento(indice);
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox11_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox12_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox13_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox14_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox15_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox16_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox17_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox18_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox19_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox20_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox21_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox22_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox23_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox24_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void label16_Click(object sender, EventArgs e)
        {

        }

        private void label17_Click(object sender, EventArgs e)
        {

        }

        private void label18_Click(object sender, EventArgs e)
        {

        }

        private void label19_Click(object sender, EventArgs e)
        {

        }

        private void label20_Click(object sender, EventArgs e)
        {

        }

        private void label21_Click(object sender, EventArgs e)
        {

        }

        private void label22_Click(object sender, EventArgs e)
        {

        }
    }
}