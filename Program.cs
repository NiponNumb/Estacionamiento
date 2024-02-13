namespace Parking
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false); // Establece los estilos visuales y de texto compatibles


            // Inicializa los formularios deseados
            Form1 form1 = new Form1();//Borrar para despues
            Form2 form2 = new Form2();
            Form3 form3 = new Form3();

            // Inicia un hilo para ejecutar form1 borrar para despues
            Thread threadForm1 = new Thread(() =>
            {
                Application.Run(form1);
            });
            threadForm1.Start();
            // Inicia un hilo para ejecutar form2
            Thread threadForm2 = new Thread(() =>
            {
                Application.Run(form2);
            });
            threadForm2.Start();

            // Inicia un hilo para ejecutar form3
            Thread threadForm3 = new Thread(() =>
            {
                Application.Run(form3);
            });
            threadForm3.Start();
        }
    }
}