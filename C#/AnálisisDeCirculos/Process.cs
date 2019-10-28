using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Actividad_1
{
    public class Process
    {
        readonly Bitmap bmpOriginal; // Variables para los bitmaps a utilizar
        Bitmap bmpFk; 
        List<Circulo> lc = new List<Circulo>(); // Lista para guardar los círculos
        int cont = 1; // Variable para contar los círculos

        public Process() { } // Constructor base

        public Process(string ruta_I) // Constructor parametrizado
        {    // Mandamos  la ruta como parámetro
        
            bmpOriginal = new Bitmap(ruta_I); // Creamos el bitmap con la ruta recibida
        }

        public Bitmap GetBitmap() // Regresa el bitmap modificado
        {
            return bmpFk;         // Ó a modificar
        }

        public List<Circulo> FindCenters(string ruta_I) // Búsqueda de los centros...
        {
            bmpFk = new Bitmap(ruta_I); // Inicializamos el bitmap a modificar con los valores del original
            lc.Clear(); // Limpiamos la lista (Asegurar que esté vacía antes de usar)

            for(int j = 0; j < bmpFk.Height; j++) // Rango no mayor a la altura
            {
                for(int i = 0; i < bmpFk.Width; i++) // Rango no mayor a la anchura
                {
                    Color c_act = bmpFk.GetPixel(i,j); // Variable para determinar el color del pixel

                    if(c_act.R == 0) // Verificar que el color sea negro...
                        if(c_act.G == 0)
                            if(c_act.B == 0) // Sí el pixel es negro...
                            {
                                Circulo c = FindCircleCenter(i, j, bmpFk); // Creamos un círculo y lo guardamos, trabajando sobre el bitmap secundario...
                                DrawCircle(c, bmpFk); // Dibujamos un círculo de otro color en el bitmap secundario para que ya no sea detectado...
                                DrawCenter(c.GetPoint(), bmpFk); // Dibujamos el centro de otro color para distinguirlo (sobre el bitmap secundario)...
                                lc.Add(c); // Agregamos el círculo a la lista de círculos
                                cont++; // Incremento del contador para que los ID's sean distintos
                            }
                }
            }

            return lc; // Retornamos la lista de círculos para poder imprimir los datos en la ListBox
        }

        Circulo FindCircleCenter(int x, int y, Bitmap bmpFk) // Búsqueda del centro del círculo
        {
            int x_f = x; // Variables auxiliares para encontrar el centro del círculo
            int y_f = y;
            int x_med = x, y_med = y; // Variables donde se guardarán los puntos medios
            int r = 0; // Variable para guardar el radio
            double aux = 0; // Variable auxiliar para castear valores

            for(; x_f < bmpFk.Width; x_f++) // Mientras no se exceda la anchura...
            {
                Color c_act = bmpFk.GetPixel(x_f, y); // Objeto que tomará el color del pixel a analizar...

                if (c_act.R != 0) // Si es distinto de negro...
                    break;
                if (c_act.G != 0) // Salir de la...
                    break;
                if (c_act.B != 0) // Función.
                    break;
            }

            // Tomamos x_f - x para obtener el radio y lo dividimos para obtener el punto medio en la horizontal
            aux = ((x_f - x) / 2); // Redondeamos de manera básica "NO hacia el número par".
            x_med = x + (int)aux; // Ya que el redondeo hacia el número par es la configuración básica y por ello no es recomendable.

            for (y_f = y_f + (x_med - x); y_f < bmpFk.Height; y_f++) //Mientras no se exceda la altura...
            {
                Color c_act = bmpFk.GetPixel(x_med, y_f); // Objeto que tomará el color del pixel a analizar...

                if (c_act.R != 0) // Si es distinto de negro...
                    break;
                if (c_act.G != 0) // Salir de la...
                    break;
                if (c_act.B != 0) // Función.
                    break;
            }

            // Tomamos y_f - y para obtener el radio y lo dividimos para obtener el punto medio en la vertical
            aux = ((y_f - y) / 2); // Redondeamos de manera básica "NO hacia el número par".
            y_med = y + (int)aux; // Ya que es la configuración básica y por ello no es recomendable.

            // Medición horizontal del centro a un extremo para tomar el radio más amplio y que el círculo a pintar sea del tamaño correcto (Que cubra al
            // círculo negro)

            for (x_f = x_med; x_f < bmpFk.Width; x_f++) // Mientras no se exceda la anchura...
            {
                Color c_act = bmpFk.GetPixel(x_f, y_med); // Objeto que tomará el color del pixel a analizar...

                if (c_act.R != 0) // Si es distinto de negro...
                    break;
                if (c_act.G != 0) // Salir de la...
                    break;
                if (c_act.B != 0) // Función.
                    break;
            }

            r = x_f - x_med; // El radio es igual al último punto negro menos el punto intermedio

            if (r < (y_med - y)) // Sí el radio horizontal es más chico que el vertical...
            {
                r = y_med - y; // El radio vertical pasa a ser el radio con el que dibujaremos el círculo, esto para evitar conflictos en dado caso de que un
            }                  // círculo no sea exacto

            Circulo c_c = new Circulo(x_med, y_med, r, cont); // Creamos un objeto círculo con los puntos medios y el ID...
            return c_c; // Devolvemos el Círculo antes creado
        }

        void DrawCircle(Circulo c, Bitmap bmpFk) // Dibujamos un círculo mayor para evitar analizarlo de nuevo
        {
            Graphics g = Graphics.FromImage(bmpFk); // Creamos un objeto para poder pintar en el bitmap
            Brush b = new SolidBrush(Color.DarkOrange); // Creamos una brocha (requisito para dibujar un elipse)
            g.FillEllipse(b, c.GetX()-c.GetRad() - 4, c.GetY()-c.GetRad() - 4, c.GetRad() * 2 + 8, c.GetRad() * 2 + 8); // Pintamos el elipse 
        }                                                                                                               // (Con los rangos del círculo)

        void DrawCenter(Point p, Bitmap bmpFk) // Dibujamos el centro de un color diferente para poder dintiguirlos
        {
            for (int j = -3; j < 3; j++) // Haremos que nuestro centro sea de 6 x 6 para que sea más notorio...
                for (int i = -3; i < 3; i++)
                    bmpFk.SetPixel(p.X + i, p.Y + j, Color.AntiqueWhite); // Pintamos pixel por pixel
        }
    }
}
