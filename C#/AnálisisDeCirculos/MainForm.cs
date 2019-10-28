using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Actividad_1
{
    public partial class MainForm : Form
    {
        string rutaImagen; // Variable para guardar la ruta de la imagen seleccionada
        Process p; // Objeto para el tratado de imagen
        List<Circulo> lc = new List<Circulo>(); // Lista donde guardaremos nuestros círculos

        public MainForm()
        {
            InitializeComponent();
        }

        private void Abrir_imagen_Click(object sender, EventArgs e)
        {
            openFileSeleccionar.ShowDialog(); // Abrimos una ventana para seleccionar la imagen
            rutaImagen = openFileSeleccionar.FileName; // Guardamos la ruta de la imagen...
            p = new Process(rutaImagen); // Creamos un objeto que procese nuestra imagen...
            pictureBoxOrg.Image = Image.FromFile(rutaImagen); // Colocamos la imagen original en la parte izquierda
        }

        private void Analizar_Click(object sender, EventArgs e)
        {
            lc.Clear(); // Limpiamos la lista (Asegurar que esté vacía antes de usar)
            lc = p.FindCenters(rutaImagen); // Obtenemos los puntos y los guardamos en nuestra nueva lista
            pictureBoxFk.Image = p.GetBitmap(); // Agregamos la imagen modificada al segundo PictureBox
            listBoxPoints.DataSource = null; // Limpiamos la ListBox (En caso de que pueda tener residuos)
            listBoxPoints.DataSource = lc; // Agregamos los círculos (puntos) a la ListBox
        }                                 

        private void MainForm_Load(object sender, EventArgs e)
        {

        }
    }
}
