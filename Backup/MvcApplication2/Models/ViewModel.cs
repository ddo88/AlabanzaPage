using System;
using System.Collections.Generic;
using MongoDB.Driver;

namespace MvcApplication2.Models
{
    public class ViewModel
    {

        public List<Cancion> Canciones      { get; set; }
        public List<Cancion> Seleccionadas  { get; set; }

        public ViewModel()
        {

        }

        public ViewModel(bool sw)
        {
            try
            {
                Canciones = new Db().GetCanciones();
            }
            catch (Exception ex)
            {
                
            }
        }
        public ViewModel(Lista l)
        {
            try
            {
                Canciones     = new Db().GetCanciones();
                Seleccionadas = l.Canciones;
            }
            catch (Exception ex)
            {

            }
        }



    }
}