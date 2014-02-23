using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcApplication1.Models
{
    public class Cancion
    {
        public string Nombre          { get; set; }
        public string Tipo            { get; set; }
        public DateTime UltimoDomingo { get; set; }
    }

    public class ViewModel {

        public List<Cancion> Canciones { get; set; }
     

        public ViewModel()
        {
            
        }

        public ViewModel(bool sw)
        {
            Canciones = new List<Cancion>();
            Cancion c1 = new Cancion();
            c1.Nombre = "";
            c1.Tipo = "";
            c1.UltimoDomingo = DateTime.Now;
            Cancion c2 = new Cancion();
            c2.Nombre = "";
            c2.Tipo = "";
            c2.UltimoDomingo = DateTime.Now;
            Cancion c3 = new Cancion();
            c3.Nombre = "";
            c3.Tipo = "";
            c3.UltimoDomingo = DateTime.Now;
            Cancion c4 = new Cancion();
            c4.Nombre = "";
            c4.Tipo = "";
            c4.UltimoDomingo = DateTime.Now;
            Canciones.Add(c1);
            Canciones.Add(c2);
            Canciones.Add(c3);
            Canciones.Add(c4);
        }

     

    }


   
}