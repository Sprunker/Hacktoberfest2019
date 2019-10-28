using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Actividad_1
{
    public class Circulo
    {
        Point p; // Variable tipo Point para guardar el centro del círculo
        readonly int r; // Variable para guardar el radio del círculo (Sólo lectura)
        int ID; // VAriable para guardar el identificador de cada círculo

        public Circulo() { } // Constructor base

        public Circulo(int x, int y, int r, int ID) // Constructor parametrizado
        {
            p.X = x; // Guardamos X y Y en el objeto tipo Point
            p.Y = y; // En su parte correspondiente
            this.r = r; // Guardamos el radio
            this.ID = ID;
        }

        public int GetX() // Regresa el valor del punto medio.X
        {
            return p.X;
        }

        public int GetY() // Regresa el valor del punto medio.Y
        {
            return p.Y;
        }

        public Point GetPoint() // Regresa el centro (En objeto tipo Point)
        {
            return p;
        }

        public int GetRad() // Regresa el radio
        {
            return r;
        }

        public override string ToString() // Regresa una cadena a la ListBox con los centros y el radio de cada círculo
        {
            return string.Format("[Centro: {0}, radio: {1}, ID: {2}]", p, r, ID); // Regresa en forma de cadena los datos pedidos
        }
    }
}
