using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AlabanzaPage.Tools;
using AlabanzaPage.Models;

namespace AlabanzaPageTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
        }


        [TestMethod]
        public void Test()
        {
            MailClass mc = new MailClass("alabanza.iglesiapagiel@hotmail.com", "@@gato01");
            Lista l = new Lista();
            
            l.Canciones= new List<Cancion>();
            l.Canciones.Add(new Cancion(){Id="",Letra="",Nombre="Hola soy una prueba"});
            l.Sugerencias= new List<Cancion>();
            l.Sugerencias.Add(new Cancion(){ Nombre="Prueba Sugerencia"});
            mc.Send("ddo88@hotmail.com,livingdeathD@gmail.com", l, "http://alabanza.iglesiapagiel.com/Lista/Index");
            Assert.IsFalse(false);
        }
    }
}
