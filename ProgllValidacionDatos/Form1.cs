using System;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace ProgllValidacionDatos
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void buttValidar_Click(object sender, EventArgs e)
        {
            string patente = txtPatente.Text;
            string cuil = txtCuil.Text;

            // Verificar si los TextBoxes están vacíos antes de validar
            if (string.IsNullOrWhiteSpace(patente))
            {
                lblResultado.Text = "Por favor, ingrese una patente.";
                return;
            }

            if (string.IsNullOrWhiteSpace(cuil))
            {
                lblResultado.Text = "Por favor, ingrese un CUIL.";
                return;
            }

            if (ValidarPatente(patente))
            {
                lblResultado.Text = "La patente es válida.";
            }
            else
            {
                lblResultado.Text = "La patente no es válida.";
            }

            string dni = ExtraerDniDeCuil(cuil);

            if (dni != null)
            {
                lblResultado.Text = "El DNI extraído es: " + dni;
            }
            else
            {
                lblResultado.Text = "El fórmato del CUIL no es válido";
            }
        }

        static bool ValidarPatente(string patente)
        {
            string pattern = @"^[A-Z]{2}\d{3}[A-Z]{2}$|^[A-Z]{3}\d{3}$";
            return Regex.IsMatch(patente, pattern);
        }

        static string ExtraerDniDeCuil(string cuil)
        {
            string pattern = @"^\d-\d{8}-\d$";
            if (Regex.IsMatch(cuil, pattern))
            {
                return cuil.Split('-')[1];
            }
            else
            {
                return null;
            }
        }
    }
}