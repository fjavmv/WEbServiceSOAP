using Ejemplmagen;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Windows;
using User;

namespace EjemploSOAP
{
    /// <summary>
    /// Descripción breve de WebServiceEjemplo
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class WebServiceEjemplo : System.Web.Services.WebService
    {
        DbPostgresql dbPostgresql = new DbPostgresql();
        
        [WebMethod]
        public int numeroAleatorio()
        {
            Random random = new Random();
            int numero = random.Next(1, 5000);
            return numero;
        }

        [WebMethod]
        public int suma(int val1, int val2)
        {
            return val1 + val2;
        }

        //convierte grados Fahrenheit a Celsius y viceversar
        [WebMethod]
        public double convertirFtoC(double temperatura)
        {
            double resultado = (temperatura - 32) / 1.8;
            return resultado;
        }

        [WebMethod]
        public double convertirCtoF(double temperatura)
        {
            double resultado = 1.8 * temperatura + 32;
            return resultado;
        }


        [WebMethod]
        public Usuario getData(string sid)
        {
            Usuario data = new Usuario();
            if ( sid.Length != 0)
            {
                int id = Convert.ToInt16(sid);
                data = dbPostgresql.consultaId(id);

            }
            else
            {
                MessageBox.Show("El campo no puede esta vacío");
            }
            return data;
        }

        [WebMethod]
        public List<Usuario> getDataAll()
        {
            List<Usuario> data = new List<Usuario>();
            data = dbPostgresql.consultaTodo();
            return data;
        }


    }
}
