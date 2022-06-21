using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace User
{
    public class Usuario
    {
        public string nombre { get; set; }
        public string apellidoP { get; set; }
        public string apellidoM { get; set; }

        public Usuario(string nombre, string apellidoP, string apellidoM)
        {
            this.nombre = nombre;
            this.apellidoP = apellidoP;
            this.apellidoM = apellidoM;
        }

        public Usuario()
        {

        }

        public override string ToString()
        {
            return "Nombre: " + nombre +"\n"+ "Apellido Paterno: " + apellidoP + "\n" + "Apellido Materno: " + apellidoM;
        }

    }
}
