using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.IdGenerators;
using MongoDB.Driver;
using System.Text.RegularExpressions;
using Newtonsoft.Json;

namespace EnvioCanciones
{
    class Program
    {
        static void Main(string[] args)
        {
            //string s = Console.ReadLine();

            //Console.WriteLine(GetMD5(s));

            string ss = getTest();

            Cancion c=JsonConvert.DeserializeObject<Cancion>(ss);


            /*
            string s = "mongodb://pagiel:pagiel@kratos.zeitgeist.com.co:27017/alabanza";
            MongoClient mc = new MongoClient(s);
            MongoServer server = mc.GetServer();
            MongoDatabase db = server.GetDatabase("alabanza");
            MongoCollection<Cancion> _evento = db.GetCollection<Cancion>("canciones");
            _evento.InsertBatch(GetList());


            */


            //List<Cancion> q = GetList();

            //var qq = q.Where(x => x.Letra.Contains("Cristo")).Count();

            //MongoCollection<Persona> _evento = db.GetCollection<Persona>("Personas");
            
            //Persona p= new Persona();
            //p.User = "ddo88@hotmail.com";
            //p.Pass = GetMD5("value");
            //p.Roles= new List<string>(){"root"};
            //_evento.InsertBatch(GetList());

            //foreach (var a in GetList())
            //{
            //    _evento.Insert(a);
            //}

//            string s= @"{title:SEÑOR MI DIOS}
//
//
//[Dm]SEÑOR MI DIOS
//DIGNO TU [Bb]ERES
//DE SU[C]BLIME ADORA[Dm]CIÓN 
//
//[Dm]A TI MIS LABIOS 
//NO CESEN [Bb]NUNCA
//[C]JAMAS DE PROCLA[Dm]MAR
//
//
//{start_chorus}
//TÚ ERES [F]EXCELSO
//DIOS PODE[C]ROSO
//REY DE [Bb]REYES Y SE[Gm]ÑOR DE SE[A]ÑORES
//TU NOMBRE ES [F]GRANDE
//AQUÍ EN LA [C]TIERRA
//EN EL [Bb]CIELO Y [Gm]TAMBIÉN EL
//[A]UNIVERSO
//{end_chorus}
//
//
//[Dm]TODAS LAS LENGUAS
//Y LAS [Bb]NACIONES CON[C]FIESEN AL [Dm]SEÑOR
//
//[Dm]TAMBIÉN LA LUNA
//Y LAS [Bb]ESTRELLAS Y EL [C]SOL
//TE ALABA[Dm]RAN
//
//";
//            var ch=Chord.parseChord(s);
            Console.ReadLine();

        }

        public static List<Cancion> GetList()
        {
            List<Cancion> c = new List<Cancion>();
            //c.Add(new Cancion() {Nombre = "A cristo solo acristo", Tipo = "Adoracion", UltimaVez = DateTime.Now});
            c.Add(new Cancion() { Nombre = "A cristo", Tipo = "Adoracion", UltimaVez = DateTime.Now });
            c.Add(new Cancion() { Nombre = "A jehova", Tipo = "Alabanza", UltimaVez = DateTime.Now });
            c.Add(new Cancion() { Nombre = "A nadie mas que a ti", Tipo = "Adoracion", UltimaVez = DateTime.Now });
            c.Add(new Cancion() { Nombre = "A nuestro dios", Tipo = "Adoracion", UltimaVez = DateTime.Now });
            c.Add(new Cancion() { Nombre = "A ti atribumos", Tipo = "Adoracion", UltimaVez = DateTime.Now });
            c.Add(new Cancion() { Nombre = "A ti", Tipo = "Adoracion", UltimaVez = DateTime.Now });
            c.Add(new Cancion() { Nombre = "A él sea la gloria", Tipo = "Adoracion", UltimaVez = DateTime.Now });
            c.Add(new Cancion() { Nombre = "Abba padre", Tipo = "Adoracion", UltimaVez = DateTime.Now });
            c.Add(new Cancion() { Nombre = "Abre mis ojos", Tipo = "Alabanza", UltimaVez = DateTime.Now });
            c.Add(new Cancion() { Nombre = "Aclamad a dios", Tipo = "Alabanza", UltimaVez = DateTime.Now });
            c.Add(new Cancion() { Nombre = "Adorad al cordero santo", Tipo = "Adoracion", UltimaVez = DateTime.Now });
            c.Add(new Cancion() { Nombre = "Adoramos", Tipo = "Adoracion", UltimaVez = DateTime.Now });
            c.Add(new Cancion() { Nombre = "Al borde", Tipo = "Adoracion", UltimaVez = DateTime.Now });
            c.Add(new Cancion() { Nombre = "Al cristo vivo sirvo", Tipo = "Adoracion", UltimaVez = DateTime.Now });
            c.Add(new Cancion() { Nombre = "Al estar ante ti", Tipo = "Adoracion", UltimaVez = DateTime.Now });
            c.Add(new Cancion() { Nombre = "Al estar aqui", Tipo = "Adoracion", UltimaVez = DateTime.Now });
            c.Add(new Cancion() { Nombre = "Alabare en mosaico", Tipo = "Alabanza", UltimaVez = DateTime.Now });
            c.Add(new Cancion() { Nombre = "Alabare", Tipo = "Alabanza", UltimaVez = DateTime.Now });
            c.Add(new Cancion() { Nombre = "Alabemos", Tipo = "Alabanza", UltimaVez = DateTime.Now });
            c.Add(new Cancion() { Nombre = "Amarte solo a ti", Tipo = "Adoracion", UltimaVez = DateTime.Now });
            c.Add(new Cancion() { Nombre = "Amor sin condición", Tipo = "Alabanza", UltimaVez = DateTime.Now });
            c.Add(new Cancion() { Nombre = "Aqui estoy", Tipo = "Adoracion", UltimaVez = DateTime.Now });
            c.Add(new Cancion() { Nombre = "Aquí estoy hillsong", Tipo = "Alabanza", UltimaVez = DateTime.Now });
            c.Add(new Cancion() { Nombre = "Aunque el gigante", Tipo = "Alabanza", UltimaVez = DateTime.Now });
            c.Add(new Cancion() { Nombre = "Aunque otros canten", Tipo = "Alabanza", UltimaVez = DateTime.Now });
            c.Add(new Cancion() { Nombre = "Bajo tu control", Tipo = "Alabanza", UltimaVez = DateTime.Now });
            c.Add(new Cancion() { Nombre = "Bajo tus alas", Tipo = "Adoracion", UltimaVez = DateTime.Now });
            c.Add(new Cancion() { Nombre = "Bendecire", Tipo = "Adoracion", UltimaVez = DateTime.Now });
            c.Add(new Cancion() { Nombre = "Bendito sea aquel", Tipo = "Adoracion", UltimaVez = DateTime.Now });
            c.Add(new Cancion() { Nombre = "Bendito sea el señor", Tipo = "Adoracion", UltimaVez = DateTime.Now });
            c.Add(new Cancion() { Nombre = "Bendito sea jehova la roca", Tipo = "Alabanza", UltimaVez = DateTime.Now });
            c.Add(new Cancion() { Nombre = "Bienvenido", Tipo = "Alabanza", UltimaVez = DateTime.Now });
            c.Add(new Cancion() { Nombre = "Bueno es alabarte jehova", Tipo = "Alabanza", UltimaVez = DateTime.Now });
            c.Add(new Cancion() { Nombre = "Bueno es alabarte", Tipo = "Alabanza", UltimaVez = DateTime.Now });
            c.Add(new Cancion() { Nombre = "Cada dia", Tipo = "Adoracion", UltimaVez = DateTime.Now });
            c.Add(new Cancion() { Nombre = "Cantemos a jesus", Tipo = "Alabanza", UltimaVez = DateTime.Now });
            c.Add(new Cancion() { Nombre = "Celebra victorioso", Tipo = "Alabanza", UltimaVez = DateTime.Now });
            c.Add(new Cancion() { Nombre = "Celebrad a cristo", Tipo = "Alabanza", UltimaVez = DateTime.Now });
            c.Add(new Cancion() { Nombre = "Celebrare", Tipo = "Alabanza", UltimaVez = DateTime.Now });
            c.Add(new Cancion() { Nombre = "Cerca de ti", Tipo = "Adoracion", UltimaVez = DateTime.Now });
            c.Add(new Cancion() { Nombre = "Confiad", Tipo = "Alabanza", UltimaVez = DateTime.Now });
            c.Add(new Cancion() { Nombre = "Como el ciervo", Tipo = "Adoracion", UltimaVez = DateTime.Now });
            c.Add(new Cancion() { Nombre = "Como el siervo brama", Tipo = "Adoracion", UltimaVez = DateTime.Now });
            c.Add(new Cancion() { Nombre = "Como la brisa", Tipo = "Adoracion", UltimaVez = DateTime.Now });
            c.Add(new Cancion() { Nombre = "Con mi dios", Tipo = "Alabanza", UltimaVez = DateTime.Now });
            //c.Add(new Cancion() {Nombre = "Confiad", Tipo = "Adoracion", UltimaVez = DateTime.Now});
            c.Add(new Cancion() { Nombre = "Conozco", Tipo = "Adoracion", UltimaVez = DateTime.Now });
            c.Add(new Cancion() { Nombre = "Consume con tu fuego", Tipo = "Adoracion", UltimaVez = DateTime.Now });
            c.Add(new Cancion() { Nombre = "Correre", Tipo = "Alabanza", UltimaVez = DateTime.Now });
            c.Add(new Cancion() { Nombre = "Cristo es la peña de horeb", Tipo = "Adoracion", UltimaVez = DateTime.Now });
            c.Add(new Cancion() { Nombre = "Cristo es mi señor", Tipo = "Alabanza", UltimaVez = DateTime.Now });
            c.Add(new Cancion() { Nombre = "Cristo no esta muerto", Tipo = "Alabanza", UltimaVez = DateTime.Now });
            c.Add(new Cancion() { Nombre = "Cuan bello es el señor", Tipo = "Alabanza", UltimaVez = DateTime.Now });
            c.Add(new Cancion() { Nombre = "Cuando veo tu amor", Tipo = "Adoracion", UltimaVez = DateTime.Now });
            c.Add(new Cancion() { Nombre = "Cuidare de ti", Tipo = "Adoracion", UltimaVez = DateTime.Now });
            c.Add(new Cancion() { Nombre = "Dame de beber", Tipo = "Adoracion", UltimaVez = DateTime.Now });
            c.Add(new Cancion() { Nombre = "Dame tus ojos", Tipo = "Adoracion", UltimaVez = DateTime.Now });
            c.Add(new Cancion() { Nombre = "Danzad", Tipo = "Alabanza", UltimaVez = DateTime.Now });
            c.Add(new Cancion() { Nombre = "David danzaba", Tipo = "Alabanza", UltimaVez = DateTime.Now });
            c.Add(new Cancion() { Nombre = "De gloria en gloria", Tipo = "Adoracion", UltimaVez = DateTime.Now });
            c.Add(new Cancion() { Nombre = "Delante de tu trono", Tipo = "Adoracion", UltimaVez = DateTime.Now });
            c.Add(new Cancion() { Nombre = "Demos gracias al señor demos gracias", Tipo = "Alabanza", UltimaVez = DateTime.Now });
            c.Add(new Cancion() { Nombre = "Derrama de tu fuego", Tipo = "Alabanza", UltimaVez = DateTime.Now });
            c.Add(new Cancion() { Nombre = "Derramando", Tipo = "Alabanza", UltimaVez = DateTime.Now });
            c.Add(new Cancion() { Nombre = "Desde mi interior", Tipo = "Adoracion", UltimaVez = DateTime.Now });
            c.Add(new Cancion() { Nombre = "Digno", Tipo = "N/S", UltimaVez = DateTime.Now });
            c.Add(new Cancion() { Nombre = "Dios de pactos", Tipo = "Adoracion", UltimaVez = DateTime.Now });
            c.Add(new Cancion() { Nombre = "Dios esta llamando", Tipo = "Alabanza", UltimaVez = DateTime.Now });
            c.Add(new Cancion() { Nombre = "Dios hermoso", Tipo = "Adoracion", UltimaVez = DateTime.Now });
            c.Add(new Cancion() { Nombre = "Dios toma tu trono hoy", Tipo = "N/S", UltimaVez = DateTime.Now });
            c.Add(new Cancion() { Nombre = "Dulce compañia", Tipo = "Adoracion", UltimaVez = DateTime.Now });
            c.Add(new Cancion() { Nombre = "Dulce refugio", Tipo = "Adoracion", UltimaVez = DateTime.Now });
            c.Add(new Cancion() { Nombre = "El amor de dios", Tipo = "Alabanza", UltimaVez = DateTime.Now });
            c.Add(new Cancion() { Nombre = "El camino del señor", Tipo = "Alabanza", UltimaVez = DateTime.Now });
            c.Add(new Cancion() { Nombre = "El es el gran yosoy", Tipo = "Adoracion", UltimaVez = DateTime.Now });
            c.Add(new Cancion() { Nombre = "El es el rey", Tipo = "Adoracion", UltimaVez = DateTime.Now });
            c.Add(new Cancion() { Nombre = "El espiritu de dios", Tipo = "Adoracion", UltimaVez = DateTime.Now });
            c.Add(new Cancion() { Nombre = "El evangelio de dios", Tipo = "Adoracion", UltimaVez = DateTime.Now });
            c.Add(new Cancion() { Nombre = "El gozo que tengo yo", Tipo = "Adoracion", UltimaVez = DateTime.Now });
            c.Add(new Cancion() { Nombre = "El mas grande de todos", Tipo = "Alabanza", UltimaVez = DateTime.Now });
            c.Add(new Cancion() { Nombre = "El me ha vestido de alegria", Tipo = "N/S", UltimaVez = DateTime.Now });
            c.Add(new Cancion() { Nombre = "El milagro", Tipo = "Adoracion", UltimaVez = DateTime.Now });
            c.Add(new Cancion() { Nombre = "El motivo de mi cancion", Tipo = "Adoracion", UltimaVez = DateTime.Now });
            c.Add(new Cancion() { Nombre = "El poderoso de israel", Tipo = "Alabanza", UltimaVez = DateTime.Now });
            c.Add(new Cancion() { Nombre = "El restaurador", Tipo = "Adoracion", UltimaVez = DateTime.Now });
            c.Add(new Cancion() { Nombre = "El señor es mi pastor", Tipo = "Adoracion", UltimaVez = DateTime.Now });
            c.Add(new Cancion() { Nombre = "El señor es mi rey", Tipo = "Adoracion", UltimaVez = DateTime.Now });
            c.Add(new Cancion() { Nombre = "El señor es mi roca y mi fortaleza", Tipo = "N/S", UltimaVez = DateTime.Now });
            c.Add(new Cancion() { Nombre = "El señor es my rey", Tipo = "Adoracion", UltimaVez = DateTime.Now });
            c.Add(new Cancion() { Nombre = "El victorioso", Tipo = "Alabanza", UltimaVez = DateTime.Now });
            c.Add(new Cancion() { Nombre = "En el principio", Tipo = "Alabanza", UltimaVez = DateTime.Now });
            c.Add(new Cancion() { Nombre = "En lo suave", Tipo = "Adoracion", UltimaVez = DateTime.Now });
            c.Add(new Cancion() { Nombre = "En los montes", Tipo = "Alabanza", UltimaVez = DateTime.Now });
            c.Add(new Cancion() { Nombre = "En mi corazon", Tipo = "Adoracion", UltimaVez = DateTime.Now });
            c.Add(new Cancion() { Nombre = "En ti", Tipo = "Adoracion", UltimaVez = DateTime.Now });
            c.Add(new Cancion() { Nombre = "En tu precencia", Tipo = "Adoracion", UltimaVez = DateTime.Now });
            c.Add(new Cancion() { Nombre = "En tu presencia pertenezco yo", Tipo = "Adoracion", UltimaVez = DateTime.Now });
            c.Add(new Cancion() { Nombre = "Enseñame", Tipo = "Adoracion", UltimaVez = DateTime.Now });
            c.Add(new Cancion() { Nombre = "Entra en la presencia del señor", Tipo = "Adoracion", UltimaVez = DateTime.Now });
            c.Add(new Cancion() { Nombre = "Entrare a jerusalen", Tipo = "N/S", UltimaVez = DateTime.Now });
            c.Add(new Cancion() { Nombre = "Eres mi protector", Tipo = "Adoracion", UltimaVez = DateTime.Now });
            c.Add(new Cancion() { Nombre = "Eres todo para mi", Tipo = "Alabanza", UltimaVez = DateTime.Now });
            c.Add(new Cancion() { Nombre = "Eres todo poderoso", Tipo = "Alabanza", UltimaVez = DateTime.Now });
            c.Add(new Cancion() { Nombre = "Eres tu", Tipo = "Alabanza", UltimaVez = DateTime.Now });
            c.Add(new Cancion() { Nombre = "Eres", Tipo = "Adoracion", UltimaVez = DateTime.Now });
            c.Add(new Cancion() { Nombre = "Es más que una canción", Tipo = "Adoracion", UltimaVez = DateTime.Now });
            c.Add(new Cancion() { Nombre = "Esperame", Tipo = "Adoracion", UltimaVez = DateTime.Now });
            c.Add(new Cancion() { Nombre = "Esperar en ti", Tipo = "Adoracion", UltimaVez = DateTime.Now });
            c.Add(new Cancion() { Nombre = "Espiritu santo de dios", Tipo = "Adoracion", UltimaVez = DateTime.Now });
            c.Add(new Cancion() { Nombre = "Estoy confiando. Himno", Tipo = "N/S", UltimaVez = DateTime.Now });
            c.Add(new Cancion() { Nombre = "Estoy firme", Tipo = "N/S", UltimaVez = DateTime.Now });
            c.Add(new Cancion() { Nombre = "Examiname", Tipo = "Adoracion", UltimaVez = DateTime.Now });
            c.Add(new Cancion() { Nombre = "Fuego de dios", Tipo = "Adoracion", UltimaVez = DateTime.Now });
            c.Add(new Cancion() { Nombre = "Gloria aleluya", Tipo = "Alabanza", UltimaVez = DateTime.Now });
            c.Add(new Cancion() { Nombre = "Gloria y honor", Tipo = "Alabanza", UltimaVez = DateTime.Now });
            c.Add(new Cancion() { Nombre = "Gloria", Tipo = "Adoracion", UltimaVez = DateTime.Now });
            c.Add(new Cancion() { Nombre = "Glorias y alabanzas", Tipo = "N/S", UltimaVez = DateTime.Now });
            c.Add(new Cancion() { Nombre = "Glorificad a jehova", Tipo = "Adoracion", UltimaVez = DateTime.Now });
            c.Add(new Cancion() { Nombre = "Glorificate señor", Tipo = "Alabanza", UltimaVez = DateTime.Now });
            c.Add(new Cancion() { Nombre = "Glorioso rey", Tipo = "Alabanza", UltimaVez = DateTime.Now });
            c.Add(new Cancion() { Nombre = "Glorioso salvador", Tipo = "Adoracion", UltimaVez = DateTime.Now });
            c.Add(new Cancion() { Nombre = "Golpe de espada", Tipo = "Alabanza", UltimaVez = DateTime.Now });
            c.Add(new Cancion() { Nombre = "Gozate delante del señor", Tipo = "Alabanza", UltimaVez = DateTime.Now });
            c.Add(new Cancion() { Nombre = "Gozo", Tipo = "Alabanza", UltimaVez = DateTime.Now });
            c.Add(new Cancion() { Nombre = "Gracias señor", Tipo = "N/S", UltimaVez = DateTime.Now });
            c.Add(new Cancion() { Nombre = "Gracias", Tipo = "Adoracion", UltimaVez = DateTime.Now });
            c.Add(new Cancion() { Nombre = "Grande es el señor creador del universo", Tipo = "Alabanza", UltimaVez = DateTime.Now });
            c.Add(new Cancion() { Nombre = "Grande es el señor", Tipo = "Alabanza", UltimaVez = DateTime.Now });
            c.Add(new Cancion() { Nombre = "Grandes y maravillosas", Tipo = "Alabanza", UltimaVez = DateTime.Now });
            c.Add(new Cancion() { Nombre = "Grita con jubilo", Tipo = "N/S", UltimaVez = DateTime.Now });
            c.Add(new Cancion() { Nombre = "Grita y danza", Tipo = "Alabanza", UltimaVez = DateTime.Now });
            c.Add(new Cancion() { Nombre = "Hacemos hoy", Tipo = "Adoracion", UltimaVez = DateTime.Now });
            c.Add(new Cancion() { Nombre = "Hay momentos", Tipo = "Adoracion", UltimaVez = DateTime.Now });
            c.Add(new Cancion() { Nombre = "Hay una fuente en mi", Tipo = "Adoracion", UltimaVez = DateTime.Now });
            c.Add(new Cancion() { Nombre = "Hay una patria que cristo nos ofrece", Tipo = "Alabanza", UltimaVez = DateTime.Now });
            c.Add(new Cancion() { Nombre = "Hay una uncion", Tipo = "Adoracion", UltimaVez = DateTime.Now });
            c.Add(new Cancion() { Nombre = "Haz cambiado", Tipo = "Alabanza", UltimaVez = DateTime.Now });
            c.Add(new Cancion() { Nombre = "Haz ganado", Tipo = "Alabanza", UltimaVez = DateTime.Now });
            c.Add(new Cancion() { Nombre = "Heme aqui 2", Tipo = "Alabanza", UltimaVez = DateTime.Now });
            c.Add(new Cancion() { Nombre = "Heme aqui", Tipo = "Adoracion", UltimaVez = DateTime.Now });
            c.Add(new Cancion() { Nombre = "Hermoso eres", Tipo = "Adoracion", UltimaVez = DateTime.Now });
            c.Add(new Cancion() { Nombre = "Hosana", Tipo = "Alabanza", UltimaVez = DateTime.Now });
            c.Add(new Cancion() { Nombre = "Hosanna hillsong", Tipo = "Adoracion", UltimaVez = DateTime.Now });
            c.Add(new Cancion() { Nombre = "Hossana - marco barrientos", Tipo = "Alabanza", UltimaVez = DateTime.Now });
            c.Add(new Cancion() { Nombre = "Hoy es tiempo", Tipo = "", UltimaVez = DateTime.Now });
            c.Add(new Cancion() { Nombre = "Hoy ha nacido en belén", Tipo = "Alabanza", UltimaVez = DateTime.Now });
            c.Add(new Cancion() { Nombre = "Hoy quiero agradecerte", Tipo = "Adoracion", UltimaVez = DateTime.Now });
            c.Add(new Cancion() { Nombre = "Jardín de rosas", Tipo = "Adoracion", UltimaVez = DateTime.Now });
            c.Add(new Cancion() { Nombre = "Jehova es mi guerrero", Tipo = "Alabanza", UltimaVez = DateTime.Now });
            c.Add(new Cancion() { Nombre = "Jesus Señor de la creacion", Tipo = "Adoracion", UltimaVez = DateTime.Now });
            c.Add(new Cancion() { Nombre = "Jesus quiero vivir en santidad", Tipo = "Adoracion", UltimaVez = DateTime.Now });
            c.Add(new Cancion() { Nombre = "Jesus vive en mi", Tipo = "Adoracion", UltimaVez = DateTime.Now });
            c.Add(new Cancion() { Nombre = "Los enemigos de jehova", Tipo = "Alabanza", UltimaVez = DateTime.Now });
            c.Add(new Cancion() { Nombre = "La cosecha", Tipo = "Alabanza", UltimaVez = DateTime.Now });
            c.Add(new Cancion() { Nombre = "La higuera", Tipo = "Adoracion", UltimaVez = DateTime.Now });
            c.Add(new Cancion() { Nombre = "La mañana gloriosa", Tipo = "Adoracion", UltimaVez = DateTime.Now });
            c.Add(new Cancion() { Nombre = "La mies es mucha", Tipo = "Adoracion", UltimaVez = DateTime.Now });
            c.Add(new Cancion() { Nombre = "La salvacion", Tipo = "Adoracion", UltimaVez = DateTime.Now });
            c.Add(new Cancion() { Nombre = "Lavame con tu sangre", Tipo = "Adoracion", UltimaVez = DateTime.Now });
            c.Add(new Cancion() { Nombre = "Le amo en todo tiempo", Tipo = "Adoracion", UltimaVez = DateTime.Now });
            c.Add(new Cancion() { Nombre = "Levantate", Tipo = "Alabanza", UltimaVez = DateTime.Now });
            c.Add(new Cancion() { Nombre = "Llévame al lugar santísimo", Tipo = "Adoracion", UltimaVez = DateTime.Now });
            //c.Add(new Cancion() {Nombre = "Los enemigos de jehova", Tipo = "Alabanza", UltimaVez = DateTime.Now});
            c.Add(new Cancion() { Nombre = "Majestuoso", Tipo = "Adoracion", UltimaVez = DateTime.Now });
            c.Add(new Cancion() { Nombre = "Magnifico dios", Tipo = "Adoracion", UltimaVez = DateTime.Now });
            c.Add(new Cancion() { Nombre = "Majestad", Tipo = "Adoracion", UltimaVez = DateTime.Now });
            c.Add(new Cancion() { Nombre = "Maravilloso dios", Tipo = "Adoracion", UltimaVez = DateTime.Now });
            c.Add(new Cancion() { Nombre = "Mas como tu", Tipo = "N/S", UltimaVez = DateTime.Now });
            c.Add(new Cancion() { Nombre = "Mas de ti", Tipo = "N/S", UltimaVez = DateTime.Now });
            c.Add(new Cancion() { Nombre = "Mas el dios", Tipo = "Adoracion", UltimaVez = DateTime.Now });
            c.Add(new Cancion() { Nombre = "Mas que un ahnelo", Tipo = "Adoracion", UltimaVez = DateTime.Now });
            c.Add(new Cancion() { Nombre = "Mas yo por la abundancia", Tipo = "Adoracion", UltimaVez = DateTime.Now });
            c.Add(new Cancion() { Nombre = "Me gozare en tu presencia jehova", Tipo = "Alabanza", UltimaVez = DateTime.Now });
            c.Add(new Cancion() { Nombre = "Me gozare", Tipo = "Alabanza", UltimaVez = DateTime.Now });
            c.Add(new Cancion() { Nombre = "Me robaste el corazon", Tipo = "Adoracion", UltimaVez = DateTime.Now });
            c.Add(new Cancion() { Nombre = "Me sedujiste", Tipo = "Adoracion", UltimaVez = DateTime.Now });
            c.Add(new Cancion() { Nombre = "Mi  primer  amor", Tipo = "Adoracion", UltimaVez = DateTime.Now });
            c.Add(new Cancion() { Nombre = "Mi mejor adoración", Tipo = "Adoracion", UltimaVez = DateTime.Now });
            c.Add(new Cancion() { Nombre = "Ni ojo vio ni oido oyo", Tipo = "N/S", UltimaVez = DateTime.Now });
            c.Add(new Cancion() { Nombre = "No basta", Tipo = "Adoracion", UltimaVez = DateTime.Now });
            c.Add(new Cancion() { Nombre = "No hay argumento", Tipo = "Alabanza", UltimaVez = DateTime.Now });
            c.Add(new Cancion() { Nombre = "No hay dios tan grande", Tipo = "Alabanza", UltimaVez = DateTime.Now });
            c.Add(new Cancion() { Nombre = "No hay nada mejor", Tipo = "Adoracion", UltimaVez = DateTime.Now });
            c.Add(new Cancion() { Nombre = "No puedo parar", Tipo = "Alabanza", UltimaVez = DateTime.Now });
            c.Add(new Cancion() { Nombre = "Nuestra alabanza", Tipo = "N/S", UltimaVez = DateTime.Now });
            c.Add(new Cancion() { Nombre = "Oh jesús", Tipo = "Alabanza", UltimaVez = DateTime.Now });
            c.Add(new Cancion() { Nombre = "Oh moradora", Tipo = "Alabanza", UltimaVez = DateTime.Now });
            c.Add(new Cancion() { Nombre = "Oh que bueno es mi jesus", Tipo = "Alabanza", UltimaVez = DateTime.Now });
            c.Add(new Cancion() { Nombre = "Oh ven", Tipo = "Alabanza", UltimaVez = DateTime.Now });
            c.Add(new Cancion() { Nombre = "Padre de misericordia", Tipo = "Adoracion", UltimaVez = DateTime.Now });
            c.Add(new Cancion() { Nombre = "Padre del cielo", Tipo = "Adoracion", UltimaVez = DateTime.Now });
            c.Add(new Cancion() { Nombre = "Paz en la tormenta", Tipo = "Adoracion", UltimaVez = DateTime.Now });
            c.Add(new Cancion() { Nombre = "Poderoso", Tipo = "Adoracion", UltimaVez = DateTime.Now });
            c.Add(new Cancion() { Nombre = "Pon aceite", Tipo = "Alabanza", UltimaVez = DateTime.Now });
            c.Add(new Cancion() { Nombre = "Mas yo Por la abundancia de tu misericordia", Tipo = "Adoracion", UltimaVez = DateTime.Now });
            c.Add(new Cancion() { Nombre = "Por un momento en tu presencia", Tipo = "Adoracion", UltimaVez = DateTime.Now });
            //c.Add(new Cancion() {Nombre = "Porque tu eres el gozo", Tipo = "Alabanza", UltimaVez = DateTime.Now});
            c.Add(new Cancion() { Nombre = "Porque  grande  es  jehova", Tipo = "Alabanza", UltimaVez = DateTime.Now });
            c.Add(new Cancion() { Nombre = "Porque para siempre", Tipo = "Adoracion", UltimaVez = DateTime.Now });
            c.Add(new Cancion() { Nombre = "Porque tu eres el gozo", Tipo = "Alabanza", UltimaVez = DateTime.Now });
            c.Add(new Cancion() { Nombre = "Preparare un santuario", Tipo = "Adoracion", UltimaVez = DateTime.Now });
            c.Add(new Cancion() { Nombre = "Proclamemos con gozo", Tipo = "Alabanza", UltimaVez = DateTime.Now });
            c.Add(new Cancion() { Nombre = "Puedo imaginarme", Tipo = "N/S", UltimaVez = DateTime.Now });
            c.Add(new Cancion() { Nombre = "Pues tu glorioso", Tipo = "Alabanza", UltimaVez = DateTime.Now });
            c.Add(new Cancion() { Nombre = "Que dulce es  estar", Tipo = "Adoracion", UltimaVez = DateTime.Now });
            c.Add(new Cancion() { Nombre = "Que seria de mí", Tipo = "Adoracion", UltimaVez = DateTime.Now });
            c.Add(new Cancion() { Nombre = "Queremos darte gloria", Tipo = "Adoracion", UltimaVez = DateTime.Now });
            c.Add(new Cancion() { Nombre = "Quien como el señor", Tipo = "N/S", UltimaVez = DateTime.Now });
            c.Add(new Cancion() { Nombre = "Quiero levantar mi manos", Tipo = "Adoracion", UltimaVez = DateTime.Now });
            c.Add(new Cancion() { Nombre = "Quiero llenar", Tipo = "Adoracion", UltimaVez = DateTime.Now });
            c.Add(new Cancion() { Nombre = "Quiero más de ti", Tipo = "Adoracion", UltimaVez = DateTime.Now });
            c.Add(new Cancion() { Nombre = "Remoliniando", Tipo = "Alabanza", UltimaVez = DateTime.Now });
            c.Add(new Cancion() { Nombre = "Rendido a tus pies", Tipo = "Adoracion", UltimaVez = DateTime.Now });
            c.Add(new Cancion() { Nombre = "Renuévame", Tipo = "Adoracion", UltimaVez = DateTime.Now });
            c.Add(new Cancion() { Nombre = "Restauraras el santo lugar", Tipo = "N/S", UltimaVez = DateTime.Now });
            c.Add(new Cancion() { Nombre = "Resucito", Tipo = "Alabanza", UltimaVez = DateTime.Now });
            c.Add(new Cancion() { Nombre = "Rodeas la eternidad", Tipo = "Alabanza", UltimaVez = DateTime.Now });
            c.Add(new Cancion() { Nombre = "Sana nuestra tierra", Tipo = "Adoracion", UltimaVez = DateTime.Now });
            c.Add(new Cancion() { Nombre = "Saname", Tipo = "Adoracion", UltimaVez = DateTime.Now });
            c.Add(new Cancion() { Nombre = "Santo es el señor", Tipo = "Adoracion", UltimaVez = DateTime.Now });
            c.Add(new Cancion() { Nombre = "Santo santo santo dicen los querubines", Tipo = "Alabanza", UltimaVez = DateTime.Now });
            c.Add(new Cancion() { Nombre = "Santo santo santo2", Tipo = "N/S", UltimaVez = DateTime.Now });
            c.Add(new Cancion() { Nombre = "Santo santo tu eres", Tipo = "Alabanza", UltimaVez = DateTime.Now });
            c.Add(new Cancion() { Nombre = "Saturame señor", Tipo = "Adoracion", UltimaVez = DateTime.Now });
            c.Add(new Cancion() { Nombre = "Sendas", Tipo = "Adoracion", UltimaVez = DateTime.Now });
            c.Add(new Cancion() { Nombre = "Señor de las huestes", Tipo = "Alabanza", UltimaVez = DateTime.Now });
            c.Add(new Cancion() { Nombre = "Señor llevame a tus atrios", Tipo = "Adoracion", UltimaVez = DateTime.Now });
            c.Add(new Cancion() { Nombre = "Señor mi dios al contemplar los cielo", Tipo = "Adoracion", UltimaVez = DateTime.Now });
            c.Add(new Cancion() { Nombre = "Señor mi dios(himno)", Tipo = "Adoracion", UltimaVez = DateTime.Now });
            c.Add(new Cancion() { Nombre = "Señor mi dios", Tipo = "Adoracion", UltimaVez = DateTime.Now });
            c.Add(new Cancion() { Nombre = "Señor quien entrara", Tipo = "Adoracion", UltimaVez = DateTime.Now });
            c.Add(new Cancion() { Nombre = "Señor yo quíero construir", Tipo = "Adoracion", UltimaVez = DateTime.Now });
            c.Add(new Cancion() { Nombre = "Shalom sea la paz", Tipo = "Alabanza", UltimaVez = DateTime.Now });
            c.Add(new Cancion() { Nombre = "Sion", Tipo = "Alabanza", UltimaVez = DateTime.Now });
            c.Add(new Cancion() { Nombre = "Sobrenatural", Tipo = "Alabanza", UltimaVez = DateTime.Now });
            c.Add(new Cancion() { Nombre = "Solo tu", Tipo = "Adoracion", UltimaVez = DateTime.Now });
            c.Add(new Cancion() { Nombre = "Somos pueblo", Tipo = "Alabanza", UltimaVez = DateTime.Now });
            c.Add(new Cancion() { Nombre = "Somos un pueblo de dios", Tipo = "Alabanza", UltimaVez = DateTime.Now });
            c.Add(new Cancion() { Nombre = "Soy tuyo hoy", Tipo = "Adoracion", UltimaVez = DateTime.Now });
            c.Add(new Cancion() { Nombre = "Su nombre de guerra", Tipo = "Alabanza", UltimaVez = DateTime.Now });
            c.Add(new Cancion() { Nombre = "Sumérgeme", Tipo = "Adoracion", UltimaVez = DateTime.Now });
            c.Add(new Cancion() { Nombre = "Tal como soy", Tipo = "Adoracion", UltimaVez = DateTime.Now });
            c.Add(new Cancion() { Nombre = "Te adoramos", Tipo = "Adoracion", UltimaVez = DateTime.Now });
            c.Add(new Cancion() { Nombre = "Te alabaran oh jehova", Tipo = "N/S", UltimaVez = DateTime.Now });
            c.Add(new Cancion() { Nombre = "Te alabare oh señor", Tipo = "Alabanza", UltimaVez = DateTime.Now });
            c.Add(new Cancion() { Nombre = "Te alabare", Tipo = "Alabanza", UltimaVez = DateTime.Now });
            c.Add(new Cancion() { Nombre = "Te amo", Tipo = "Adoracion", UltimaVez = DateTime.Now });
            c.Add(new Cancion() { Nombre = "Te dare lo mejor", Tipo = "Alabanza", UltimaVez = DateTime.Now });
            c.Add(new Cancion() { Nombre = "Te daré lo mejor del trigo", Tipo = "Adoracion", UltimaVez = DateTime.Now });
            c.Add(new Cancion() { Nombre = "Te daré lo mejor de mi vida", Tipo = "Alabanza", UltimaVez = DateTime.Now });
            c.Add(new Cancion() { Nombre = "Te exaltamos", Tipo = "Alabanza", UltimaVez = DateTime.Now });
            c.Add(new Cancion() { Nombre = "Te pido la paz", Tipo = "Adoracion", UltimaVez = DateTime.Now });
            c.Add(new Cancion() { Nombre = "Te quiero te quiero", Tipo = "Adoracion", UltimaVez = DateTime.Now });
            c.Add(new Cancion() { Nombre = "Temprano yo te buscare", Tipo = "Adoracion", UltimaVez = DateTime.Now });
            c.Add(new Cancion() { Nombre = "Tengo sed", Tipo = "Alabanza", UltimaVez = DateTime.Now });
            c.Add(new Cancion() { Nombre = "Tocar tu manto señor", Tipo = "N/S", UltimaVez = DateTime.Now });
            c.Add(new Cancion() { Nombre = "Toda la casa de isrrael", Tipo = "N/S", UltimaVez = DateTime.Now });
            c.Add(new Cancion() { Nombre = "Toma el pandero", Tipo = "Alabanza", UltimaVez = DateTime.Now });
            c.Add(new Cancion() { Nombre = "Toma mi vida", Tipo = "Adoracion", UltimaVez = DateTime.Now });
            c.Add(new Cancion() { Nombre = "Torre fuerte", Tipo = "Adoracion", UltimaVez = DateTime.Now });
            c.Add(new Cancion() { Nombre = "Tu amor por mi", Tipo = "Adoracion", UltimaVez = DateTime.Now });
            c.Add(new Cancion() { Nombre = "Tu eres dios ,tu eres rey", Tipo = "Alabanza", UltimaVez = DateTime.Now });
            c.Add(new Cancion() { Nombre = "Tu eres dios", Tipo = "Adoracion", UltimaVez = DateTime.Now });
            c.Add(new Cancion() { Nombre = "Tu eres mi roca fuerte", Tipo = "N/S", UltimaVez = DateTime.Now });
            c.Add(new Cancion() { Nombre = "Tu estas aquí", Tipo = "Adoracion", UltimaVez = DateTime.Now });
            c.Add(new Cancion() { Nombre = "Tu fidelidad", Tipo = "Adoracion", UltimaVez = DateTime.Now });
            c.Add(new Cancion() { Nombre = "Tu mirada", Tipo = "Adoracion", UltimaVez = DateTime.Now });
            c.Add(new Cancion() { Nombre = "Tu misericordia", Tipo = "Adoracion", UltimaVez = DateTime.Now });
            c.Add(new Cancion() { Nombre = "Tu nombre levantare", Tipo = "Adoracion", UltimaVez = DateTime.Now });
            c.Add(new Cancion() { Nombre = "Tu nombre oh dios", Tipo = "Alabanza", UltimaVez = DateTime.Now });
            c.Add(new Cancion() { Nombre = "Tu palabra", Tipo = "Alabanza", UltimaVez = DateTime.Now });
            c.Add(new Cancion() { Nombre = "Tu trono oh dios", Tipo = "Adoracion", UltimaVez = DateTime.Now });
            c.Add(new Cancion() { Nombre = "Tu y yo", Tipo = "Alabanza", UltimaVez = DateTime.Now });
            c.Add(new Cancion() { Nombre = "Una vez mas", Tipo = "Adoracion", UltimaVez = DateTime.Now });
            c.Add(new Cancion() { Nombre = "Uno de nosotros", Tipo = "Alabanza", UltimaVez = DateTime.Now });
            c.Add(new Cancion() { Nombre = "Vamos a la ciudad", Tipo = "Adoracion", UltimaVez = DateTime.Now });
            c.Add(new Cancion() { Nombre = "Vamos escalando", Tipo = "Alabanza", UltimaVez = DateTime.Now });
            c.Add(new Cancion() { Nombre = "Ven espiritu ven", Tipo = "Adoracion", UltimaVez = DateTime.Now });
            c.Add(new Cancion() { Nombre = "Vengo a ti", Tipo = "Adoracion", UltimaVez = DateTime.Now });
            c.Add(new Cancion() { Nombre = "Venid adoremos", Tipo = "Adoracion", UltimaVez = DateTime.Now });
            c.Add(new Cancion() { Nombre = "Venid todos", Tipo = "Alabanza", UltimaVez = DateTime.Now });
            c.Add(new Cancion() { Nombre = "Venimos ante ti ii", Tipo = "Adoracion", UltimaVez = DateTime.Now });
            c.Add(new Cancion() { Nombre = "Venimos ante ti señor para adorarte", Tipo = "Adoracion", UltimaVez = DateTime.Now });
            c.Add(new Cancion() { Nombre = "Vine adorar a dios", Tipo = "Adoracion", UltimaVez = DateTime.Now });
            c.Add(new Cancion() { Nombre = "Y vendra sobre ti", Tipo = "Adoracion", UltimaVez = DateTime.Now });
            c.Add(new Cancion() { Nombre = "Yeshua", Tipo = "Adoracion", UltimaVez = DateTime.Now });
            c.Add(new Cancion() { Nombre = "Yo celebrare", Tipo = "Alabanza", UltimaVez = DateTime.Now });
            c.Add(new Cancion() { Nombre = "Yo quiero mas de ti", Tipo = "Adoracion", UltimaVez = DateTime.Now });
            c.Add(new Cancion() { Nombre = "Yo quiero ser un adorador", Tipo = "Alabanza", UltimaVez = DateTime.Now });
            c.Add(new Cancion() { Nombre = "Yo solo quiero estar", Tipo = "Adoracion", UltimaVez = DateTime.Now });
            c.Add(new Cancion() { Nombre = "Yo te alabo", Tipo = "Adoracion", UltimaVez = DateTime.Now });
            c.Add(new Cancion() { Nombre = "Yo te necesito jesucristo", Tipo = "Adoracion", UltimaVez = DateTime.Now });
            c.Add(new Cancion() { Nombre = "Yo tengo gozo", Tipo = "Alabanza", UltimaVez = DateTime.Now });
            c.Add(new Cancion() { Nombre = "Yo tengo un amigo", Tipo = "Alabanza", UltimaVez = DateTime.Now });
            c.Add(new Cancion() { Nombre = "Yo tengo un nuevo amor", Tipo = "Alabanza", UltimaVez = DateTime.Now });
            return c;
        }

        public static string GetMD5(string value)
        {

            value = value + "salt";
            MD5 md = MD5.Create();
            StringBuilder sBuilder = new StringBuilder();
            byte[] data = md.ComputeHash(System.Text.Encoding.ASCII.GetBytes(value));
            // Loop through each byte of the hashed data 
            // and format each one as a hexadecimal string.
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }
            return sBuilder.ToString();

        }

        public static string getTest()
        {
            return @"{
    '_id' : '538a939fe3f6ce1efc850e39',
    'Nombre' : 'Venimos ante ti señor para adorarte',
    'Tipo' : 'Adoracion',
    'UltimaVez' : ISODate('2014-06-01T02:44:44.802Z'),
    'Letra' : ''}";
        }

        public static string GetJson()
        {
            return @"[{
    '_id' : '538a939fe3f6ce1efc850e39',
    'Nombre' : 'Venimos ante ti señor para adorarte',
    'Tipo' : 'Adoracion',
    'UltimaVez' : ISODate('2014-06-01T02:44:44.802Z'),
    'Letra' : ''
},
{
    '_id' : '538a939fe3f6ce1efc850d24',
    'Nombre' : 'A nadie mas que a ti',
    'Tipo' : 'Adoracion',
    'UltimaVez' : ISODate('2014-06-01T02:44:44.802Z'),
    'Letra' : ''
},
{
    '_id' : '538a939fe3f6ce1efc850d25',
    'Nombre' : 'A nuestro Dios',
    'Tipo' : 'Adoracion',
    'Letra' : '',
    'UltimaVez' : ISODate('2014-06-01T02:44:44.802Z')
},
{
    '_id' : '538a939fe3f6ce1efc850d2f',
    'Nombre' : 'Al cristo vivo sirvo',
    'Tipo' : 'Adoracion',
    'UltimaVez' : ISODate('2014-06-01T02:44:44.802Z'),
    'Letra' : ''
},
{
    '_id' : '538a939fe3f6ce1efc850d32',
    'Nombre' : 'Alabare en mosaico',
    'Tipo' : 'Alabanza',
    'UltimaVez' : ISODate('2014-06-01T02:44:44.802Z'),
    'Letra' : ''
},
{
    '_id' : '538a939fe3f6ce1efc850d33',
    'Nombre' : 'Alabare',
    'Tipo' : 'Alabanza',
    'UltimaVez' : ISODate('2014-06-01T02:44:44.802Z'),
    'Letra' : ''
},
{
    '_id' : '538a939fe3f6ce1efc850d3f',
    'Nombre' : 'Bendito sea el señor',
    'Tipo' : 'Adoracion',
    'UltimaVez' : ISODate('2014-06-01T02:44:44.802Z'),
    'Letra' : ''
},
{
    '_id' : '538a939fe3f6ce1efc850d40',
    'Nombre' : 'Bendito sea jehova la roca',
    'Tipo' : 'Alabanza',
    'UltimaVez' : ISODate('2014-06-01T02:44:44.802Z'),
    'Letra' : ''
},
{
    '_id' : '538a939fe3f6ce1efc850d41',
    'Nombre' : 'Bienvenido',
    'Tipo' : 'Alabanza',
    'UltimaVez' : ISODate('2014-06-01T02:44:44.802Z'),
    'Letra' : ''
},
{
    '_id' : '538a939fe3f6ce1efc850d42',
    'Nombre' : 'Bueno es alabarte jehova',
    'Tipo' : 'Alabanza',
    'UltimaVez' : ISODate('2014-06-01T02:44:44.802Z'),
    'Letra' : ''
}, 
{
    '_id' : '538a939fe3f6ce1efc850d47',
    'Nombre' : 'Celebrad a cristo',
    'Tipo' : 'Alabanza',
    'UltimaVez' : ISODate('2014-06-01T02:44:44.802Z'),
    'Letra' : ''
},

 
{
    '_id' : '538a939fe3f6ce1efc850d48',
    'Nombre' : 'Celebrare',
    'Tipo' : 'Alabanza',
    'UltimaVez' : ISODate('2014-06-01T02:44:44.802Z'),
    'Letra' : ''
},

 
{
    '_id' : '538a939fe3f6ce1efc850d4a',
    'Nombre' : 'Confiad',
    'Tipo' : 'Alabanza',
    'UltimaVez' : ISODate('2014-06-01T02:44:44.802Z'),
    'Letra' : ''
},

 
{
    '_id' : '538a939fe3f6ce1efc850d4c',
    'Nombre' : 'Como el siervo brama',
    'Tipo' : 'Adoracion',
    'UltimaVez' : ISODate('2014-06-01T02:44:44.802Z'),
    'Letra' : ''
},

 
{
    '_id' : '538a939fe3f6ce1efc850d50',
    'Nombre' : 'Consume con tu fuego',
    'Tipo' : 'Adoracion',
    'UltimaVez' : ISODate('2014-06-01T02:44:44.802Z'),
    'Letra' : ''
},

 
{
    '_id' : '538a939fe3f6ce1efc850d51',
    'Nombre' : 'Correre',
    'Tipo' : 'Alabanza',
    'UltimaVez' : ISODate('2014-06-01T02:44:44.802Z'),
    'Letra' : ''
},

 
{
    '_id' : '538a939fe3f6ce1efc850d52',
    'Nombre' : 'Cristo es la peña de horeb',
    'Tipo' : 'Adoracion',
    'UltimaVez' : ISODate('2014-06-01T02:44:44.802Z'),
    'Letra' : ''
},

 
{
    '_id' : '538a939fe3f6ce1efc850d55',
    'Nombre' : 'Cuan bello es el señor',
    'Tipo' : 'Alabanza',
    'UltimaVez' : ISODate('2014-06-01T02:44:44.802Z'),
    'Letra' : ''
},

 
{
    '_id' : '538a939fe3f6ce1efc850d57',
    'Nombre' : 'Cuidare de ti',
    'Tipo' : 'Adoracion',
    'UltimaVez' : ISODate('2014-06-01T02:44:44.802Z'),
    'Letra' : ''
},

 
{
    '_id' : '538a939fe3f6ce1efc850d58',
    'Nombre' : 'Dame de beber',
    'Tipo' : 'Adoracion',
    'UltimaVez' : ISODate('2014-06-01T02:44:44.802Z'),
    'Letra' : ''
},

 
{
    '_id' : '538a939fe3f6ce1efc850d59',
    'Nombre' : 'Dame tus ojos',
    'Tipo' : 'Adoracion',
    'UltimaVez' : ISODate('2014-06-01T02:44:44.802Z'),
    'Letra' : ''
},

 
{
    '_id' : '538a939fe3f6ce1efc850d5a',
    'Nombre' : 'Danzad',
    'Tipo' : 'Alabanza',
    'UltimaVez' : ISODate('2014-06-01T02:44:44.802Z'),
    'Letra' : ''
},

 
{
    '_id' : '538a939fe3f6ce1efc850d5b',
    'Nombre' : 'David danzaba',
    'Tipo' : 'Alabanza',
    'UltimaVez' : ISODate('2014-06-01T02:44:44.802Z'),
    'Letra' : ''
},

 
{
    '_id' : '538a939fe3f6ce1efc850d5c',
    'Nombre' : 'De gloria en gloria',
    'Tipo' : 'Adoracion',
    'UltimaVez' : ISODate('2014-06-01T02:44:44.802Z'),
    'Letra' : ''
},

 
{
    '_id' : '538a939fe3f6ce1efc850d5d',
    'Nombre' : 'Delante de tu trono',
    'Tipo' : 'Adoracion',
    'UltimaVez' : ISODate('2014-06-01T02:44:44.802Z'),
    'Letra' : ''
},

 
{
    '_id' : '538a939fe3f6ce1efc850d5e',
    'Nombre' : 'Demos gracias al señor demos gracias',
    'Tipo' : 'Alabanza',
    'UltimaVez' : ISODate('2014-06-01T02:44:44.802Z'),
    'Letra' : ''
},

 
{
    '_id' : '538a939fe3f6ce1efc850d5f',
    'Nombre' : 'Derrama de tu fuego',
    'Tipo' : 'Alabanza',
    'UltimaVez' : ISODate('2014-06-01T02:44:44.802Z'),
    'Letra' : ''
},

 
{
    '_id' : '538a939fe3f6ce1efc850d61',
    'Nombre' : 'Desde mi interior',
    'Tipo' : 'Adoracion',
    'UltimaVez' : ISODate('2014-06-01T02:44:44.802Z'),
    'Letra' : ''
},

 
{
    '_id' : '538a939fe3f6ce1efc850d62',
    'Nombre' : 'Digno',
    'Tipo' : 'N/S',
    'UltimaVez' : ISODate('2014-06-01T02:44:44.802Z'),
    'Letra' : ''
}, 
{
    '_id' : '538a939fe3f6ce1efc850d63',
    'Nombre' : 'Dios de pactos',
    'Tipo' : 'Adoracion',
    'UltimaVez' : ISODate('2014-06-01T02:44:44.802Z'),
    'Letra' : ''
},

 
{
    '_id' : '538a939fe3f6ce1efc850d64',
    'Nombre' : 'Dios esta llamando',
    'Tipo' : 'Alabanza',
    'UltimaVez' : ISODate('2014-06-01T02:44:44.802Z'),
    'Letra' : ''
},
{
    '_id' : '538a939fe3f6ce1efc850d66',
    'Nombre' : 'Dios toma tu trono hoy',
    'Tipo' : 'N/S',
    'UltimaVez' : ISODate('2014-06-01T02:44:44.802Z'),
    'Letra' : ''
},
{
    '_id' : '538a939fe3f6ce1efc850d67',
    'Nombre' : 'Dulce compañia',
    'Tipo' : 'Adoracion',
    'UltimaVez' : ISODate('2014-06-01T02:44:44.802Z'),
    'Letra' : ''
},
{
    '_id' : '538a939fe3f6ce1efc850d68',
    'Nombre' : 'Dulce refugio',
    'Tipo' : 'Adoracion',
    'UltimaVez' : ISODate('2014-06-01T02:44:44.802Z'),
    'Letra' : ''
},
{
    '_id' : '538a939fe3f6ce1efc850d69',
    'Nombre' : 'El amor de dios',
    'Tipo' : 'Alabanza',
    'UltimaVez' : ISODate('2014-06-01T02:44:44.802Z'),
    'Letra' : ''
},

 
{
    '_id' : '538a939fe3f6ce1efc850d6a',
    'Nombre' : 'El camino del señor',
    'Tipo' : 'Alabanza',
    'UltimaVez' : ISODate('2014-06-01T02:44:44.802Z'),
    'Letra' : ''
},

 
{
    '_id' : '538a939fe3f6ce1efc850d6b',
    'Nombre' : 'El es el gran yosoy',
    'Tipo' : 'Adoracion',
    'UltimaVez' : ISODate('2014-06-01T02:44:44.802Z'),
    'Letra' : ''
},
{
    '_id' : '538a939fe3f6ce1efc850d6d',
    'Nombre' : 'El espiritu de dios',
    'Tipo' : 'Adoracion',
    'UltimaVez' : ISODate('2014-06-01T02:44:44.802Z'),
    'Letra' : ''
},
{
    '_id' : '538a939fe3f6ce1efc850d6f',
    'Nombre' : 'El gozo que tengo yo',
    'Tipo' : 'Adoracion',
    'UltimaVez' : ISODate('2014-07-06T20:24:16.505Z'),
    'Letra' : ''
},
{
    '_id' : '538a939fe3f6ce1efc850d70',
    'Nombre' : 'El mas grande de todos',
    'Tipo' : 'Alabanza',
    'UltimaVez' : ISODate('2014-06-01T02:44:44.802Z'),
    'Letra' : ''
},

 
{
    '_id' : '538a939fe3f6ce1efc850d71',
    'Nombre' : 'El me ha vestido de alegria',
    'Tipo' : 'N/S',
    'UltimaVez' : ISODate('2014-06-01T02:44:44.802Z'),
    'Letra' : ''
},

 
{
    '_id' : '538a939fe3f6ce1efc850d72',
    'Nombre' : 'El milagro',
    'Tipo' : 'Adoracion',
    'UltimaVez' : ISODate('2014-06-01T02:44:44.802Z'),
    'Letra' : ''
},

 
{
    '_id' : '538a939fe3f6ce1efc850d73',
    'Nombre' : 'El motivo de mi cancion',
    'Tipo' : 'Adoracion',
    'UltimaVez' : ISODate('2014-06-01T02:44:44.802Z'),
    'Letra' : ''
},

 
{
    '_id' : '538a939fe3f6ce1efc850d75',
    'Nombre' : 'El restaurador',
    'Tipo' : 'Adoracion',
    'UltimaVez' : ISODate('2014-06-01T02:44:44.802Z'),
    'Letra' : ''
},

 
{
    '_id' : '538a939fe3f6ce1efc850d76',
    'Nombre' : 'El señor es mi pastor',
    'Tipo' : 'Adoracion',
    'UltimaVez' : ISODate('2014-06-01T02:44:44.802Z'),
    'Letra' : ''
},

 
{
    '_id' : '538a939fe3f6ce1efc850d77',
    'Nombre' : 'El señor es mi rey',
    'Tipo' : 'Adoracion',
    'UltimaVez' : ISODate('2014-06-01T02:44:44.802Z'),
    'Letra' : ''
},

 
{
    '_id' : '538a939fe3f6ce1efc850d78',
    'Nombre' : 'El señor es mi roca y mi fortaleza',
    'Tipo' : 'N/S',
    'UltimaVez' : ISODate('2014-06-01T02:44:44.802Z'),
    'Letra' : ''
},
{
    '_id' : '538a939fe3f6ce1efc850d79',
    'Nombre' : 'El señor es my rey',
    'Tipo' : 'Adoracion',
    'UltimaVez' : ISODate('2014-06-01T02:44:44.802Z'),
    'Letra' : ''
},
{
    '_id' : '538a939fe3f6ce1efc850d7a',
    'Nombre' : 'El victorioso',
    'Tipo' : 'Alabanza',
    'UltimaVez' : ISODate('2014-06-01T02:44:44.802Z'),
    'Letra' : ''
},
{
    '_id' : '538a939fe3f6ce1efc850d7b',
    'Nombre' : 'En el principio',
    'Tipo' : 'Alabanza',
    'UltimaVez' : ISODate('2014-06-01T02:44:44.802Z'),
    'Letra' : ''
},
{
    '_id' : '538a939fe3f6ce1efc850d7d',
    'Nombre' : 'En los montes',
    'Tipo' : 'Alabanza',
    'UltimaVez' : ISODate('2014-06-01T02:44:44.802Z'),
    'Letra' : ''
},

 
{
    '_id' : '538a939fe3f6ce1efc850d7e',
    'Nombre' : 'En mi corazon',
    'Tipo' : 'Adoracion',
    'UltimaVez' : ISODate('2014-06-01T02:44:44.802Z'),
    'Letra' : ''
},

 
{
    '_id' : '538a939fe3f6ce1efc850d7f',
    'Nombre' : 'En ti',
    'Tipo' : 'Adoracion',
    'UltimaVez' : ISODate('2014-06-01T02:44:44.802Z'),
    'Letra' : ''
},

 
{
    '_id' : '538a939fe3f6ce1efc850d80',
    'Nombre' : 'En tu precencia',
    'Tipo' : 'Adoracion',
    'UltimaVez' : ISODate('2014-06-01T02:44:44.802Z'),
    'Letra' : ''
},

 
{
    '_id' : '538a939fe3f6ce1efc850d81',
    'Nombre' : 'En tu presencia pertenezco yo',
    'Tipo' : 'Adoracion',
    'UltimaVez' : ISODate('2014-06-01T02:44:44.802Z'),
    'Letra' : ''
},

 
{
    '_id' : '538a939fe3f6ce1efc850d82',
    'Nombre' : 'Enseñame',
    'Tipo' : 'Adoracion',
    'UltimaVez' : ISODate('2014-06-01T02:44:44.802Z'),
    'Letra' : ''
},

 
{
    '_id' : '538a939fe3f6ce1efc850d83',
    'Nombre' : 'Entra en la presencia del señor',
    'Tipo' : 'Adoracion',
    'UltimaVez' : ISODate('2014-06-01T02:44:44.802Z'),
    'Letra' : ''
},

 
{
    '_id' : '538a939fe3f6ce1efc850d84',
    'Nombre' : 'Entrare a jerusalen',
    'Tipo' : 'N/S',
    'UltimaVez' : ISODate('2014-06-01T02:44:44.802Z'),
    'Letra' : ''
},

 
{
    '_id' : '538a939fe3f6ce1efc850d85',
    'Nombre' : 'Eres mi protector',
    'Tipo' : 'Adoracion',
    'UltimaVez' : ISODate('2014-06-01T02:44:44.802Z'),
    'Letra' : ''
},

 
{
    '_id' : '538a939fe3f6ce1efc850d87',
    'Nombre' : 'Eres todo poderoso',
    'Tipo' : 'Alabanza',
    'UltimaVez' : ISODate('2014-06-01T02:44:44.802Z'),
    'Letra' : ''
},

 
{
    '_id' : '538a939fe3f6ce1efc850d88',
    'Nombre' : 'Eres tu',
    'Tipo' : 'Alabanza',
    'UltimaVez' : ISODate('2014-06-01T02:44:44.802Z'),
    'Letra' : ''
},

 
{
    '_id' : '538a939fe3f6ce1efc850d89',
    'Nombre' : 'Eres',
    'Tipo' : 'Adoracion',
    'UltimaVez' : ISODate('2014-06-01T02:44:44.802Z'),
    'Letra' : ''
},

 
{
    '_id' : '538a939fe3f6ce1efc850d8a',
    'Nombre' : 'Es más que una canción',
    'Tipo' : 'Adoracion',
    'UltimaVez' : ISODate('2014-06-01T02:44:44.802Z'),
    'Letra' : ''
},

 
{
    '_id' : '538a939fe3f6ce1efc850d8b',
    'Nombre' : 'Esperame',
    'Tipo' : 'Adoracion',
    'UltimaVez' : ISODate('2014-06-28T00:40:07.980Z'),
    'Letra' : ''
},

 
{
    '_id' : '538a939fe3f6ce1efc850d8c',
    'Nombre' : 'Esperar en ti',
    'Tipo' : 'Adoracion',
    'UltimaVez' : ISODate('2014-06-01T02:44:44.802Z'),
    'Letra' : ''
},

 
{
    '_id' : '538a939fe3f6ce1efc850d8d',
    'Nombre' : 'Espiritu santo de dios',
    'Tipo' : 'Adoracion',
    'UltimaVez' : ISODate('2014-06-01T02:44:44.802Z'),
    'Letra' : ''
},

 
{
    '_id' : '538a939fe3f6ce1efc850d8e',
    'Nombre' : 'Estoy confiando. Himno',
    'Tipo' : 'N/S',
    'UltimaVez' : ISODate('2014-06-01T02:44:44.802Z'),
    'Letra' : ''
},

 
{
    '_id' : '538a939fe3f6ce1efc850d8f',
    'Nombre' : 'Estoy firme',
    'Tipo' : 'N/S',
    'UltimaVez' : ISODate('2014-06-01T02:44:44.802Z'),
    'Letra' : ''
},

 
{
    '_id' : '538a939fe3f6ce1efc850d90',
    'Nombre' : 'Examiname',
    'Tipo' : 'Adoracion',
    'UltimaVez' : ISODate('2014-06-01T02:44:44.802Z'),
    'Letra' : ''
},

 
{
    '_id' : '538a939fe3f6ce1efc850d91',
    'Nombre' : 'Fuego de dios',
    'Tipo' : 'Adoracion',
    'UltimaVez' : ISODate('2014-06-01T02:44:44.802Z'),
    'Letra' : ''
},

 
{
    '_id' : '538a939fe3f6ce1efc850d92',
    'Nombre' : 'Gloria aleluya',
    'Tipo' : 'Alabanza',
    'UltimaVez' : ISODate('2014-06-01T02:44:44.802Z'),
    'Letra' : ''
},

 
{
    '_id' : '538a939fe3f6ce1efc850d93',
    'Nombre' : 'Gloria y honor',
    'Tipo' : 'Alabanza',
    'UltimaVez' : ISODate('2014-06-01T02:44:44.802Z'),
    'Letra' : ''
},

 
{
    '_id' : '538a939fe3f6ce1efc850d94',
    'Nombre' : 'Gloria',
    'Tipo' : 'Adoracion',
    'UltimaVez' : ISODate('2014-06-01T02:44:44.802Z'),
    'Letra' : ''
},

 
{
    '_id' : '538a939fe3f6ce1efc850d95',
    'Nombre' : 'Glorias y alabanzas',
    'Tipo' : 'N/S',
    'UltimaVez' : ISODate('2014-06-01T02:44:44.802Z'),
    'Letra' : ''
},

 
{
    '_id' : '538a939fe3f6ce1efc850d96',
    'Nombre' : 'Glorificad a jehova',
    'Tipo' : 'Adoracion',
    'UltimaVez' : ISODate('2014-06-28T00:40:07.981Z'),
    'Letra' : ''
},

 
{
    '_id' : '538a939fe3f6ce1efc850d97',
    'Nombre' : 'Glorificate señor',
    'Tipo' : 'Alabanza',
    'UltimaVez' : ISODate('2014-06-01T02:44:44.802Z'),
    'Letra' : ''
},

 
{
    '_id' : '538a939fe3f6ce1efc850d99',
    'Nombre' : 'Glorioso salvador',
    'Tipo' : 'Adoracion',
    'UltimaVez' : ISODate('2014-06-28T00:40:07.982Z'),
    'Letra' : ''
},

 
{
    '_id' : '538a939fe3f6ce1efc850d9b',
    'Nombre' : 'Gozate delante del señor',
    'Tipo' : 'Alabanza',
    'UltimaVez' : ISODate('2014-06-28T00:40:07.983Z'),
    'Letra' : ''
},

 
{
    '_id' : '538a939fe3f6ce1efc850d9c',
    'Nombre' : 'Gozo',
    'Tipo' : 'Alabanza',
    'UltimaVez' : ISODate('2014-06-01T02:44:44.802Z'),
    'Letra' : ''
},

 
{
    '_id' : '538a939fe3f6ce1efc850d9d',
    'Nombre' : 'Gracias señor',
    'Tipo' : 'N/S',
    'UltimaVez' : ISODate('2014-06-01T02:44:44.802Z'),
    'Letra' : ''
},

 
{
    '_id' : '538a939fe3f6ce1efc850d9e',
    'Nombre' : 'Gracias',
    'Tipo' : 'Adoracion',
    'UltimaVez' : ISODate('2014-06-01T02:44:44.802Z'),
    'Letra' : ''
},

 
{
    '_id' : '538a939fe3f6ce1efc850d9f',
    'Nombre' : 'Grande es el señor creador del universo',
    'Tipo' : 'Alabanza',
    'UltimaVez' : ISODate('2014-06-08T04:50:22.662Z'),
    'Letra' : ''
},

 
{
    '_id' : '538a939fe3f6ce1efc850da2',
    'Nombre' : 'Grita con jubilo',
    'Tipo' : 'N/S',
    'UltimaVez' : ISODate('2014-06-01T02:44:44.802Z'),
    'Letra' : ''
},

 
{
    '_id' : '538a939fe3f6ce1efc850da3',
    'Nombre' : 'Grita y danza',
    'Tipo' : 'Alabanza',
    'UltimaVez' : ISODate('2014-06-01T02:44:44.802Z'),
    'Letra' : ''
},

 
{
    '_id' : '538a939fe3f6ce1efc850da4',
    'Nombre' : 'Hacemos hoy',
    'Tipo' : 'Adoracion',
    'UltimaVez' : ISODate('2014-06-01T02:44:44.802Z'),
    'Letra' : ''
},

 
{
    '_id' : '538a939fe3f6ce1efc850da5',
    'Nombre' : 'Hay momentos',
    'Tipo' : 'Adoracion',
    'UltimaVez' : ISODate('2014-06-28T00:40:07.981Z'),
    'Letra' : ''
},

 
{
    '_id' : '538a939fe3f6ce1efc850da6',
    'Nombre' : 'Hay una fuente en mi',
    'Tipo' : 'Adoracion',
    'UltimaVez' : ISODate('2014-06-01T02:44:44.802Z'),
    'Letra' : ''
},

 
{
    '_id' : '538a939fe3f6ce1efc850da7',
    'Nombre' : 'Hay una patria que cristo nos ofrece',
    'Tipo' : 'Alabanza',
    'UltimaVez' : ISODate('2014-06-01T02:44:44.802Z'),
    'Letra' : ''
},

 
{
    '_id' : '538a939fe3f6ce1efc850da8',
    'Nombre' : 'Hay una uncion',
    'Tipo' : 'Adoracion',
    'UltimaVez' : ISODate('2014-06-01T02:44:44.802Z'),
    'Letra' : ''
},

 
{
    '_id' : '538a939fe3f6ce1efc850da9',
    'Nombre' : 'Haz cambiado',
    'Tipo' : 'Alabanza',
    'UltimaVez' : ISODate('2014-06-01T02:44:44.802Z'),
    'Letra' : ''
},

 
{
    '_id' : '538a939fe3f6ce1efc850daa',
    'Nombre' : 'Haz ganado',
    'Tipo' : 'Alabanza',
    'UltimaVez' : ISODate('2014-06-01T02:44:44.802Z'),
    'Letra' : ''
},

 
{
    '_id' : '538a939fe3f6ce1efc850dab',
    'Nombre' : 'Heme aqui 2',
    'Tipo' : 'Alabanza',
    'UltimaVez' : ISODate('2014-06-01T02:44:44.802Z'),
    'Letra' : ''
},

 
{
    '_id' : '538a939fe3f6ce1efc850dac',
    'Nombre' : 'Heme aqui',
    'Tipo' : 'Adoracion',
    'UltimaVez' : ISODate('2014-06-01T02:44:44.802Z'),
    'Letra' : ''
},

 
{
    '_id' : '538a939fe3f6ce1efc850dad',
    'Nombre' : 'Hermoso eres',
    'Tipo' : 'Adoracion',
    'UltimaVez' : ISODate('2014-06-01T02:44:44.802Z'),
    'Letra' : ''
},

 
{
    '_id' : '538a939fe3f6ce1efc850dae',
    'Nombre' : 'Hosana',
    'Tipo' : 'Alabanza',
    'UltimaVez' : ISODate('2014-06-01T02:44:44.802Z'),
    'Letra' : ''
},

 
{
    '_id' : '538a939fe3f6ce1efc850daf',
    'Nombre' : 'Hosanna hillsong',
    'Tipo' : 'Adoracion',
    'UltimaVez' : ISODate('2014-06-01T02:44:44.802Z'),
    'Letra' : ''
},

 
{
    '_id' : '538a939fe3f6ce1efc850db0',
    'Nombre' : 'Hossana - marco barrientos',
    'Tipo' : 'Alabanza',
    'UltimaVez' : ISODate('2014-07-06T20:24:17.297Z'),
    'Letra' : ''
},

 
{
    '_id' : '538a939fe3f6ce1efc850db1',
    'Nombre' : 'Hoy es tiempo',
    'Tipo' : '',
    'UltimaVez' : ISODate('2014-06-01T02:44:44.802Z'),
    'Letra' : ''
},

 
{
    '_id' : '538a939fe3f6ce1efc850db2',
    'Nombre' : 'Hoy ha nacido en belén',
    'Tipo' : 'Alabanza',
    'UltimaVez' : ISODate('2014-06-01T02:44:44.802Z'),
    'Letra' : ''
},

 
{
    '_id' : '538a939fe3f6ce1efc850db3',
    'Nombre' : 'Hoy quiero agradecerte',
    'Tipo' : 'Adoracion',
    'UltimaVez' : ISODate('2014-06-01T02:44:44.802Z'),
    'Letra' : ''
},

 
{
    '_id' : '538a939fe3f6ce1efc850db4',
    'Nombre' : 'Jardín de rosas',
    'Tipo' : 'Adoracion',
    'UltimaVez' : ISODate('2014-06-01T02:44:44.802Z'),
    'Letra' : ''
},

 
{
    '_id' : '538a939fe3f6ce1efc850db5',
    'Nombre' : 'Jehova es mi guerrero',
    'Tipo' : 'Alabanza',
    'UltimaVez' : ISODate('2014-06-01T02:44:44.802Z'),
    'Letra' : ''
},

 
{
    '_id' : '538a939fe3f6ce1efc850db7',
    'Nombre' : 'Jesus quiero vivir en santidad',
    'Tipo' : 'Adoracion',
    'UltimaVez' : ISODate('2014-06-01T02:44:44.802Z'),
    'Letra' : ''
},

 
{
    '_id' : '538a939fe3f6ce1efc850db8',
    'Nombre' : 'Jesus vive en mi',
    'Tipo' : 'Adoracion',
    'UltimaVez' : ISODate('2014-06-01T02:44:44.802Z'),
    'Letra' : ''
},

 
{
    '_id' : '538a939fe3f6ce1efc850db9',
    'Nombre' : 'Los enemigos de jehova',
    'Tipo' : 'Alabanza',
    'UltimaVez' : ISODate('2014-06-01T02:44:44.802Z'),
    'Letra' : ''
},

 
{
    '_id' : '538a939fe3f6ce1efc850dba',
    'Nombre' : 'La cosecha',
    'Tipo' : 'Alabanza',
    'UltimaVez' : ISODate('2014-06-01T02:44:44.802Z'),
    'Letra' : ''
},

 
{
    '_id' : '538a939fe3f6ce1efc850dbb',
    'Nombre' : 'La higuera',
    'Tipo' : 'Adoracion',
    'UltimaVez' : ISODate('2014-06-01T02:44:44.802Z'),
    'Letra' : ''
},

 
{
    '_id' : '538a939fe3f6ce1efc850dbc',
    'Nombre' : 'La mañana gloriosa',
    'Tipo' : 'Adoracion',
    'UltimaVez' : ISODate('2014-06-01T02:44:44.802Z'),
    'Letra' : ''
},

 
{
    '_id' : '538a939fe3f6ce1efc850dbd',
    'Nombre' : 'La mies es mucha',
    'Tipo' : 'Adoracion',
    'UltimaVez' : ISODate('2014-06-28T00:40:07.982Z'),
    'Letra' : ''
},

 
{
    '_id' : '538a939fe3f6ce1efc850dbe',
    'Nombre' : 'La salvacion',
    'Tipo' : 'Adoracion',
    'UltimaVez' : ISODate('2014-06-01T02:44:44.802Z'),
    'Letra' : ''
},

 
{
    '_id' : '538a939fe3f6ce1efc850dbf',
    'Nombre' : 'Lavame con tu sangre',
    'Tipo' : 'Adoracion',
    'UltimaVez' : ISODate('2014-06-01T02:44:44.802Z'),
    'Letra' : ''
},

 
{
    '_id' : '538a939fe3f6ce1efc850dc0',
    'Nombre' : 'Le amo en todo tiempo',
    'Tipo' : 'Adoracion',
    'UltimaVez' : ISODate('2014-07-06T20:24:15.376Z'),
    'Letra' : ''
},

 
{
    '_id' : '538a939fe3f6ce1efc850dc2',
    'Nombre' : 'Llévame al lugar santísimo',
    'Tipo' : 'Adoracion',
    'UltimaVez' : ISODate('2014-06-01T02:44:44.802Z'),
    'Letra' : ''
},

 
{
    '_id' : '538a939fe3f6ce1efc850dc3',
    'Nombre' : 'Majestuoso',
    'Tipo' : 'Adoracion',
    'UltimaVez' : ISODate('2014-06-01T02:44:44.802Z'),
    'Letra' : ''
},

 
{
    '_id' : '538a939fe3f6ce1efc850dc4',
    'Nombre' : 'Magnifico dios',
    'Tipo' : 'Adoracion',
    'UltimaVez' : ISODate('2014-06-01T02:44:44.802Z'),
    'Letra' : ''
},

 
{
    '_id' : '538a939fe3f6ce1efc850dc5',
    'Nombre' : 'Majestad',
    'Tipo' : 'Adoracion',
    'UltimaVez' : ISODate('2014-06-01T02:44:44.802Z'),
    'Letra' : ''
},

 
{
    '_id' : '538a939fe3f6ce1efc850dc6',
    'Nombre' : 'Maravilloso dios',
    'Tipo' : 'Adoracion',
    'UltimaVez' : ISODate('2014-06-01T02:44:44.802Z'),
    'Letra' : ''
},

 
{
    '_id' : '538a939fe3f6ce1efc850dc7',
    'Nombre' : 'Mas como tu',
    'Tipo' : 'N/S',
    'UltimaVez' : ISODate('2014-06-01T02:44:44.802Z'),
    'Letra' : ''
},

 
{
    '_id' : '538a939fe3f6ce1efc850dc8',
    'Nombre' : 'Mas de ti',
    'Tipo' : 'N/S',
    'UltimaVez' : ISODate('2014-06-01T02:44:44.802Z'),
    'Letra' : ''
},

 
{
    '_id' : '538a939fe3f6ce1efc850dc9',
    'Nombre' : 'Mas el dios',
    'Tipo' : 'Adoracion',
    'UltimaVez' : ISODate('2014-06-01T02:44:44.802Z'),
    'Letra' : ''
},

 
{
    '_id' : '538a939fe3f6ce1efc850dca',
    'Nombre' : 'Mas que un ahnelo',
    'Tipo' : 'Adoracion',
    'UltimaVez' : ISODate('2014-07-06T20:24:15.977Z'),
    'Letra' : ''
},

 
{
    '_id' : '538a939fe3f6ce1efc850dcb',
    'Nombre' : 'Mas yo por la abundancia',
    'Tipo' : 'Adoracion',
    'UltimaVez' : ISODate('2014-06-01T02:44:44.802Z'),
    'Letra' : ''
},

 
{
    '_id' : '538a939fe3f6ce1efc850dcc',
    'Nombre' : 'Me gozare en tu presencia jehova',
    'Tipo' : 'Alabanza',
    'UltimaVez' : ISODate('2014-06-01T02:44:44.802Z'),
    'Letra' : ''
},

 
{
    '_id' : '538a939fe3f6ce1efc850dcd',
    'Nombre' : 'Me gozare',
    'Tipo' : 'Alabanza',
    'UltimaVez' : ISODate('2014-06-01T02:44:44.802Z'),
    'Letra' : ''
},

 
{
    '_id' : '538a939fe3f6ce1efc850dce',
    'Nombre' : 'Me robaste el corazon',
    'Tipo' : 'Adoracion',
    'UltimaVez' : ISODate('2014-06-01T02:44:44.802Z'),
    'Letra' : ''
},

 
{
    '_id' : '538a939fe3f6ce1efc850dcf',
    'Nombre' : 'Me sedujiste',
    'Tipo' : 'Adoracion',
    'UltimaVez' : ISODate('2014-06-01T02:44:44.802Z'),
    'Letra' : ''
},

 
{
    '_id' : '538a939fe3f6ce1efc850dd0',
    'Nombre' : 'Mi  primer  amor',
    'Tipo' : 'Adoracion',
    'UltimaVez' : ISODate('2014-06-01T02:44:44.802Z'),
    'Letra' : ''
},

 
{
    '_id' : '538a939fe3f6ce1efc850dd1',
    'Nombre' : 'Mi mejor adoración',
    'Tipo' : 'Adoracion',
    'UltimaVez' : ISODate('2014-06-01T02:44:44.802Z'),
    'Letra' : ''
},

 
{
    '_id' : '538a939fe3f6ce1efc850dd2',
    'Nombre' : 'Ni ojo vio ni oido oyo',
    'Tipo' : 'N/S',
    'UltimaVez' : ISODate('2014-06-01T02:44:44.802Z'),
    'Letra' : ''
},

 
{
    '_id' : '538a939fe3f6ce1efc850dd3',
    'Nombre' : 'No basta',
    'Tipo' : 'Adoracion',
    'UltimaVez' : ISODate('2014-06-01T02:44:44.802Z'),
    'Letra' : ''
},

 
{
    '_id' : '538a939fe3f6ce1efc850dd4',
    'Nombre' : 'No hay argumento',
    'Tipo' : 'Alabanza',
    'UltimaVez' : ISODate('2014-06-01T02:44:44.802Z'),
    'Letra' : ''
},

 
{
    '_id' : '538a939fe3f6ce1efc850dd5',
    'Nombre' : 'No hay dios tan grande',
    'Tipo' : 'Alabanza',
    'UltimaVez' : ISODate('2014-06-01T02:44:44.802Z'),
    'Letra' : ''
},

 
{
    '_id' : '538a939fe3f6ce1efc850dd6',
    'Nombre' : 'No hay nada mejor',
    'Tipo' : 'Adoracion',
    'UltimaVez' : ISODate('2014-06-01T02:44:44.802Z'),
    'Letra' : ''
},

 
{
    '_id' : '538a939fe3f6ce1efc850dd7',
    'Nombre' : 'No puedo parar',
    'Tipo' : 'Alabanza',
    'UltimaVez' : ISODate('2014-06-01T02:44:44.802Z'),
    'Letra' : ''
},

 
{
    '_id' : '538a939fe3f6ce1efc850dd8',
    'Nombre' : 'Nuestra alabanza',
    'Tipo' : 'N/S',
    'UltimaVez' : ISODate('2014-06-01T02:44:44.802Z'),
    'Letra' : ''
},

 
{
    '_id' : '538a939fe3f6ce1efc850dd9',
    'Nombre' : 'Oh jesús',
    'Tipo' : 'Alabanza',
    'UltimaVez' : ISODate('2014-06-01T02:44:44.802Z'),
    'Letra' : ''
},

 
{
    '_id' : '538a939fe3f6ce1efc850dda',
    'Nombre' : 'Oh moradora',
    'Tipo' : 'Alabanza',
    'UltimaVez' : ISODate('2014-06-01T02:44:44.802Z'),
    'Letra' : ''
},

 
{
    '_id' : '538a939fe3f6ce1efc850ddb',
    'Nombre' : 'Oh que bueno es mi jesus',
    'Tipo' : 'Alabanza',
    'UltimaVez' : ISODate('2014-06-01T02:44:44.802Z'),
    'Letra' : ''
},

 
{
    '_id' : '538a939fe3f6ce1efc850ddc',
    'Nombre' : 'Oh ven',
    'Tipo' : 'Alabanza',
    'UltimaVez' : ISODate('2014-06-01T02:44:44.802Z'),
    'Letra' : ''
},

 
{
    '_id' : '538a939fe3f6ce1efc850ddd',
    'Nombre' : 'Padre de misericordia',
    'Tipo' : 'Adoracion',
    'UltimaVez' : ISODate('2014-06-01T02:44:44.802Z'),
    'Letra' : ''
},

 
{
    '_id' : '538a939fe3f6ce1efc850dde',
    'Nombre' : 'Padre del cielo',
    'Tipo' : 'Adoracion',
    'UltimaVez' : ISODate('2014-06-01T02:44:44.802Z'),
    'Letra' : ''
},

 
{
    '_id' : '538a939fe3f6ce1efc850de0',
    'Nombre' : 'Poderoso',
    'Tipo' : 'Adoracion',
    'UltimaVez' : ISODate('2014-06-01T02:44:44.802Z'),
    'Letra' : ''
},

 
{
    '_id' : '538a939fe3f6ce1efc850de1',
    'Nombre' : 'Pon aceite',
    'Tipo' : 'Alabanza',
    'UltimaVez' : ISODate('2014-06-01T02:44:44.802Z'),
    'Letra' : ''
},

 
{
    '_id' : '538a939fe3f6ce1efc850de2',
    'Nombre' : 'Mas yo Por la abundancia de tu misericordia',
    'Tipo' : 'Adoracion',
    'UltimaVez' : ISODate('2014-06-01T02:44:44.802Z'),
    'Letra' : ''
},

 
{
    '_id' : '538a939fe3f6ce1efc850de3',
    'Nombre' : 'Por un momento en tu presencia',
    'Tipo' : 'Adoracion',
    'UltimaVez' : ISODate('2014-06-01T02:44:44.802Z'),
    'Letra' : ''
},

 
{
    '_id' : '538a939fe3f6ce1efc850de4',
    'Nombre' : 'Porque  grande  es  jehova',
    'Tipo' : 'Alabanza',
    'UltimaVez' : ISODate('2014-06-01T02:44:44.802Z'),
    'Letra' : ''
},

 
{
    '_id' : '538a939fe3f6ce1efc850de5',
    'Nombre' : 'Porque para siempre',
    'Tipo' : 'Adoracion',
    'UltimaVez' : ISODate('2014-06-01T02:44:44.802Z'),
    'Letra' : ''
},

 
{
    '_id' : '538a939fe3f6ce1efc850de6',
    'Nombre' : 'Porque tu eres el gozo',
    'Tipo' : 'Alabanza',
    'UltimaVez' : ISODate('2014-06-01T02:44:44.802Z'),
    'Letra' : ''
},

 
{
    '_id' : '538a939fe3f6ce1efc850de8',
    'Nombre' : 'Proclamemos con gozo',
    'Tipo' : 'Alabanza',
    'UltimaVez' : ISODate('2014-06-01T02:44:44.802Z'),
    'Letra' : ''
},

 
{
    '_id' : '538a939fe3f6ce1efc850de9',
    'Nombre' : 'Puedo imaginarme',
    'Tipo' : 'N/S',
    'UltimaVez' : ISODate('2014-06-01T02:44:44.802Z'),
    'Letra' : ''
},

 
{
    '_id' : '538a939fe3f6ce1efc850dea',
    'Nombre' : 'Pues tu glorioso',
    'Tipo' : 'Alabanza',
    'UltimaVez' : ISODate('2014-06-01T02:44:44.802Z'),
    'Letra' : ''
},

 
{
    '_id' : '538a939fe3f6ce1efc850deb',
    'Nombre' : 'Que dulce es  estar',
    'Tipo' : 'Adoracion',
    'UltimaVez' : ISODate('2014-06-01T02:44:44.802Z'),
    'Letra' : ''
},

 
{
    '_id' : '538a939fe3f6ce1efc850dec',
    'Nombre' : 'Que seria de mí',
    'Tipo' : 'Adoracion',
    'UltimaVez' : ISODate('2014-06-08T04:50:21.722Z'),
    'Letra' : ''
},

 
{
    '_id' : '538a939fe3f6ce1efc850ded',
    'Nombre' : 'Queremos darte gloria',
    'Tipo' : 'Adoracion',
    'UltimaVez' : ISODate('2014-06-01T02:44:44.802Z'),
    'Letra' : ''
},

 
{
    '_id' : '538a939fe3f6ce1efc850dee',
    'Nombre' : 'Quien como el señor',
    'Tipo' : 'N/S',
    'UltimaVez' : ISODate('2014-06-01T02:44:44.802Z'),
    'Letra' : ''
},

 
{
    '_id' : '538a939fe3f6ce1efc850def',
    'Nombre' : 'Quiero levantar mi manos',
    'Tipo' : 'Adoracion',
    'UltimaVez' : ISODate('2014-06-01T02:44:44.802Z'),
    'Letra' : ''
},

 
{
    '_id' : '538a939fe3f6ce1efc850df0',
    'Nombre' : 'Quiero llenar',
    'Tipo' : 'Adoracion',
    'UltimaVez' : ISODate('2014-06-01T02:44:44.802Z'),
    'Letra' : ''
},

 
{
    '_id' : '538a939fe3f6ce1efc850df1',
    'Nombre' : 'Quiero más de ti',
    'Tipo' : 'Adoracion',
    'UltimaVez' : ISODate('2014-06-01T02:44:44.802Z'),
    'Letra' : ''
},

 
{
    '_id' : '538a939fe3f6ce1efc850df2',
    'Nombre' : 'Remoliniando',
    'Tipo' : 'Alabanza',
    'UltimaVez' : ISODate('2014-07-06T20:24:16.772Z'),
    'Letra' : ''
},

 
{
    '_id' : '538a939fe3f6ce1efc850df3',
    'Nombre' : 'Rendido a tus pies',
    'Tipo' : 'Adoracion',
    'UltimaVez' : ISODate('2014-06-01T02:44:44.802Z'),
    'Letra' : ''
},

 
{
    '_id' : '538a939fe3f6ce1efc850df4',
    'Nombre' : 'Renuévame',
    'Tipo' : 'Adoracion',
    'UltimaVez' : ISODate('2014-06-01T02:44:44.802Z'),
    'Letra' : ''
},

 
{
    '_id' : '538a939fe3f6ce1efc850df5',
    'Nombre' : 'Restauraras el santo lugar',
    'Tipo' : 'N/S',
    'UltimaVez' : ISODate('2014-06-01T02:44:44.802Z'),
    'Letra' : ''
},

 
{
    '_id' : '538a939fe3f6ce1efc850df6',
    'Nombre' : 'Resucito',
    'Tipo' : 'Alabanza',
    'UltimaVez' : ISODate('2014-06-01T02:44:44.802Z'),
    'Letra' : ''
},

 
{
    '_id' : '538a939fe3f6ce1efc850df7',
    'Nombre' : 'Rodeas la eternidad',
    'Tipo' : 'Alabanza',
    'UltimaVez' : ISODate('2014-06-01T02:44:44.802Z'),
    'Letra' : ''
},

 
{
    '_id' : '538a939fe3f6ce1efc850df8',
    'Nombre' : 'Sana nuestra tierra',
    'Tipo' : 'Adoracion',
    'UltimaVez' : ISODate('2014-06-01T02:44:44.802Z'),
    'Letra' : ''
},

 
{
    '_id' : '538a939fe3f6ce1efc850df9',
    'Nombre' : 'Saname',
    'Tipo' : 'Adoracion',
    'UltimaVez' : ISODate('2014-06-01T02:44:44.802Z'),
    'Letra' : ''
},

 
{
    '_id' : '538a939fe3f6ce1efc850dfa',
    'Nombre' : 'Santo es el señor',
    'Tipo' : 'Adoracion',
    'UltimaVez' : ISODate('2014-06-01T02:44:44.802Z'),
    'Letra' : ''
},

 
{
    '_id' : '538a939fe3f6ce1efc850dfb',
    'Nombre' : 'Santo santo santo dicen los querubines',
    'Tipo' : 'Alabanza',
    'UltimaVez' : ISODate('2014-06-01T02:44:44.802Z'),
    'Letra' : ''
},

 
{
    '_id' : '538a939fe3f6ce1efc850dfc',
    'Nombre' : 'Santo santo santo2',
    'Tipo' : 'N/S',
    'UltimaVez' : ISODate('2014-06-01T02:44:44.802Z'),
    'Letra' : ''
},

 
{
    '_id' : '538a939fe3f6ce1efc850dfd',
    'Nombre' : 'Santo santo tu eres',
    'Tipo' : 'Alabanza',
    'UltimaVez' : ISODate('2014-06-01T02:44:44.802Z'),
    'Letra' : ''
},

 
{
    '_id' : '538a939fe3f6ce1efc850dfe',
    'Nombre' : 'Saturame señor',
    'Tipo' : 'Adoracion',
    'UltimaVez' : ISODate('2014-06-01T02:44:44.802Z'),
    'Letra' : ''
},

 
{
    '_id' : '538a939fe3f6ce1efc850dff',
    'Nombre' : 'Sendas',
    'Tipo' : 'Adoracion',
    'UltimaVez' : ISODate('2014-06-01T02:44:44.802Z'),
    'Letra' : ''
},

 
{
    '_id' : '538a939fe3f6ce1efc850e00',
    'Nombre' : 'Señor de las huestes',
    'Tipo' : 'Alabanza',
    'UltimaVez' : ISODate('2014-06-28T00:40:07.984Z'),
    'Letra' : ''
},

 
{
    '_id' : '538a939fe3f6ce1efc850e01',
    'Nombre' : 'Señor llevame a tus atrios',
    'Tipo' : 'Adoracion',
    'UltimaVez' : ISODate('2014-06-01T02:44:44.802Z'),
    'Letra' : ''
},

 
{
    '_id' : '538a939fe3f6ce1efc850e02',
    'Nombre' : 'Señor mi dios al contemplar los cielo',
    'Tipo' : 'Adoracion',
    'UltimaVez' : ISODate('2014-06-01T02:44:44.802Z'),
    'Letra' : ''
},

 
{
    '_id' : '538a939fe3f6ce1efc850e03',
    'Nombre' : 'Señor mi dios(himno)',
    'Tipo' : 'Adoracion',
    'UltimaVez' : ISODate('2014-06-01T02:44:44.802Z'),
    'Letra' : ''
},

 
{
    '_id' : '538a939fe3f6ce1efc850e05',
    'Nombre' : 'Señor quien entrara',
    'Tipo' : 'Adoracion',
    'UltimaVez' : ISODate('2014-06-01T02:44:44.802Z'),
    'Letra' : ''
},

 
{
    '_id' : '538a939fe3f6ce1efc850e06',
    'Nombre' : 'Señor yo quíero construir',
    'Tipo' : 'Adoracion',
    'UltimaVez' : ISODate('2014-06-01T02:44:44.802Z'),
    'Letra' : ''
},

 
{
    '_id' : '538a939fe3f6ce1efc850e07',
    'Nombre' : 'Shalom sea la paz',
    'Tipo' : 'Alabanza',
    'UltimaVez' : ISODate('2014-06-01T02:44:44.802Z'),
    'Letra' : ''
},

 
{
    '_id' : '538a939fe3f6ce1efc850e08',
    'Nombre' : 'Sion',
    'Tipo' : 'Alabanza',
    'UltimaVez' : ISODate('2014-06-15T13:21:06.891Z'),
    'Letra' : ''
},

 
{
    '_id' : '538a939fe3f6ce1efc850e09',
    'Nombre' : 'Sobrenatural',
    'Tipo' : 'Alabanza',
    'UltimaVez' : ISODate('2014-06-01T02:44:44.802Z'),
    'Letra' : ''
},

 
{
    '_id' : '538a939fe3f6ce1efc850e0a',
    'Nombre' : 'Solo tu',
    'Tipo' : 'Adoracion',
    'UltimaVez' : ISODate('2014-06-01T02:44:44.802Z'),
    'Letra' : ''
},

 
{
    '_id' : '538a939fe3f6ce1efc850e0b',
    'Nombre' : 'Somos pueblo',
    'Tipo' : 'Alabanza',
    'UltimaVez' : ISODate('2014-06-01T02:44:44.802Z'),
    'Letra' : ''
},

 
{
    '_id' : '538a939fe3f6ce1efc850e0c',
    'Nombre' : 'Somos un pueblo de dios',
    'Tipo' : 'Alabanza',
    'UltimaVez' : ISODate('2014-06-01T02:44:44.802Z'),
    'Letra' : ''
},

 
{
    '_id' : '538a939fe3f6ce1efc850e0d',
    'Nombre' : 'Soy tuyo hoy',
    'Tipo' : 'Adoracion',
    'UltimaVez' : ISODate('2014-06-01T02:44:44.802Z'),
    'Letra' : ''
},

 
{
    '_id' : '538a939fe3f6ce1efc850e0e',
    'Nombre' : 'Su nombre de guerra',
    'Tipo' : 'Alabanza',
    'UltimaVez' : ISODate('2014-06-01T02:44:44.802Z'),
    'Letra' : ''
},

 
{
    '_id' : '538a939fe3f6ce1efc850e0f',
    'Nombre' : 'Sumérgeme',
    'Tipo' : 'Adoracion',
    'UltimaVez' : ISODate('2014-06-01T02:44:44.802Z'),
    'Letra' : ''
},

 
{
    '_id' : '538a939fe3f6ce1efc850e10',
    'Nombre' : 'Tal como soy',
    'Tipo' : 'Adoracion',
    'UltimaVez' : ISODate('2014-06-01T02:44:44.802Z'),
    'Letra' : ''
},

 
{
    '_id' : '538a939fe3f6ce1efc850e11',
    'Nombre' : 'Te adoramos',
    'Tipo' : 'Adoracion',
    'UltimaVez' : ISODate('2014-06-01T02:44:44.802Z'),
    'Letra' : ''
},

 
{
    '_id' : '538a939fe3f6ce1efc850e12',
    'Nombre' : 'Te alabaran oh jehova',
    'Tipo' : 'N/S',
    'UltimaVez' : ISODate('2014-06-01T02:44:44.802Z'),
    'Letra' : ''
},

 
{
    '_id' : '538a939fe3f6ce1efc850e13',
    'Nombre' : 'Te alabare oh señor',
    'Tipo' : 'Alabanza',
    'UltimaVez' : ISODate('2014-06-01T02:44:44.802Z'),
    'Letra' : ''
},

 
{
    '_id' : '538a939fe3f6ce1efc850e14',
    'Nombre' : 'Te alabare',
    'Tipo' : 'Alabanza',
    'UltimaVez' : ISODate('2014-06-01T02:44:44.802Z'),
    'Letra' : ''
},

 
{
    '_id' : '538a939fe3f6ce1efc850e15',
    'Nombre' : 'Te amo',
    'Tipo' : 'Adoracion',
    'UltimaVez' : ISODate('2014-06-01T02:44:44.802Z'),
    'Letra' : ''
},

 
{
    '_id' : '538a939fe3f6ce1efc850e16',
    'Nombre' : 'Te dare lo mejor',
    'Tipo' : 'Alabanza',
    'UltimaVez' : ISODate('2014-06-01T02:44:44.802Z'),
    'Letra' : ''
},

 
{
    '_id' : '538a939fe3f6ce1efc850e17',
    'Nombre' : 'Te daré lo mejor del trigo',
    'Tipo' : 'Adoracion',
    'UltimaVez' : ISODate('2014-06-01T02:44:44.802Z'),
    'Letra' : ''
},

 
{
    '_id' : '538a939fe3f6ce1efc850e18',
    'Nombre' : 'Te daré lo mejor de mi vida',
    'Tipo' : 'Alabanza',
    'UltimaVez' : ISODate('2014-06-01T02:44:44.802Z'),
    'Letra' : ''
},

 
{
    '_id' : '538a939fe3f6ce1efc850e19',
    'Nombre' : 'Te exaltamos',
    'Tipo' : 'Alabanza',
    'UltimaVez' : ISODate('2014-06-01T02:44:44.802Z'),
    'Letra' : ''
},

 
{
    '_id' : '538a939fe3f6ce1efc850e1a',
    'Nombre' : 'Te pido la paz',
    'Tipo' : 'Adoracion',
    'UltimaVez' : ISODate('2014-06-01T02:44:44.802Z'),
    'Letra' : ''
},

 
{
    '_id' : '538a939fe3f6ce1efc850e1b',
    'Nombre' : 'Te quiero te quiero',
    'Tipo' : 'Adoracion',
    'UltimaVez' : ISODate('2014-06-01T02:44:44.802Z'),
    'Letra' : ''
},

 
{
    '_id' : '538a939fe3f6ce1efc850e1c',
    'Nombre' : 'Temprano yo te buscare',
    'Tipo' : 'Adoracion',
    'UltimaVez' : ISODate('2014-06-01T02:44:44.802Z'),
    'Letra' : ''
},

 
{
    '_id' : '538a939fe3f6ce1efc850e1d',
    'Nombre' : 'Tengo sed',
    'Tipo' : 'Alabanza',
    'UltimaVez' : ISODate('2014-06-01T02:44:44.802Z'),
    'Letra' : ''
},

 
{
    '_id' : '538a939fe3f6ce1efc850e1e',
    'Nombre' : 'Tocar tu manto señor',
    'Tipo' : 'N/S',
    'UltimaVez' : ISODate('2014-06-01T02:44:44.802Z'),
    'Letra' : ''
},

 
{
    '_id' : '538a939fe3f6ce1efc850e1f',
    'Nombre' : 'Toda la casa de isrrael',
    'Tipo' : 'N/S',
    'UltimaVez' : ISODate('2014-06-01T02:44:44.802Z'),
    'Letra' : ''
},

 
{
    '_id' : '538a939fe3f6ce1efc850e20',
    'Nombre' : 'Toma el pandero',
    'Tipo' : 'Alabanza',
    'UltimaVez' : ISODate('2014-06-28T00:40:07.982Z'),
    'Letra' : ''
},

 
{
    '_id' : '538a939fe3f6ce1efc850e21',
    'Nombre' : 'Toma mi vida',
    'Tipo' : 'Adoracion',
    'UltimaVez' : ISODate('2014-06-01T02:44:44.802Z'),
    'Letra' : ''
},

 
{
    '_id' : '538a939fe3f6ce1efc850e22',
    'Nombre' : 'Torre fuerte',
    'Tipo' : 'Adoracion',
    'UltimaVez' : ISODate('2014-06-01T02:44:44.802Z'),
    'Letra' : ''
},

 
{
    '_id' : '538a939fe3f6ce1efc850e23',
    'Nombre' : 'Tu amor por mi',
    'Tipo' : 'Adoracion',
    'UltimaVez' : ISODate('2014-06-01T02:44:44.802Z'),
    'Letra' : ''
},

 
{
    '_id' : '538a939fe3f6ce1efc850e24',
    'Nombre' : 'Tu eres dios ,tu eres rey',
    'Tipo' : 'Alabanza',
    'UltimaVez' : ISODate('2014-06-01T02:44:44.802Z'),
    'Letra' : ''
},

 
{
    '_id' : '538a939fe3f6ce1efc850e25',
    'Nombre' : 'Tu eres dios',
    'Tipo' : 'Adoracion',
    'UltimaVez' : ISODate('2014-07-06T20:24:16.238Z'),
    'Letra' : ''
},

 
{
    '_id' : '538a939fe3f6ce1efc850e26',
    'Nombre' : 'Tu eres mi roca fuerte',
    'Tipo' : 'N/S',
    'UltimaVez' : ISODate('2014-06-01T02:44:44.802Z'),
    'Letra' : ''
},

 
{
    '_id' : '538a939fe3f6ce1efc850e27',
    'Nombre' : 'Tu estas aquí',
    'Tipo' : 'Adoracion',
    'UltimaVez' : ISODate('2014-06-01T02:44:44.802Z'),
    'Letra' : ''
},

 
{
    '_id' : '538a939fe3f6ce1efc850e28',
    'Nombre' : 'Tu fidelidad',
    'Tipo' : 'Adoracion',
    'UltimaVez' : ISODate('2014-06-01T02:44:44.802Z'),
    'Letra' : ''
},

 
{
    '_id' : '538a939fe3f6ce1efc850e2a',
    'Nombre' : 'Tu misericordia',
    'Tipo' : 'Adoracion',
    'UltimaVez' : ISODate('2014-06-01T02:44:44.802Z'),
    'Letra' : ''
},

 
{
    '_id' : '538a939fe3f6ce1efc850e2b',
    'Nombre' : 'Tu nombre levantare',
    'Tipo' : 'Adoracion',
    'UltimaVez' : ISODate('2014-06-01T02:44:44.802Z'),
    'Letra' : ''
},

 
{
    '_id' : '538a939fe3f6ce1efc850e2c',
    'Nombre' : 'Tu nombre oh dios',
    'Tipo' : 'Alabanza',
    'UltimaVez' : ISODate('2014-06-01T02:44:44.802Z'),
    'Letra' : ''
},

 
{
    '_id' : '538a939fe3f6ce1efc850e2d',
    'Nombre' : 'Tu palabra',
    'Tipo' : 'Alabanza',
    'UltimaVez' : ISODate('2014-06-01T02:44:44.802Z'),
    'Letra' : ''
},

 
{
    '_id' : '538a939fe3f6ce1efc850e2e',
    'Nombre' : 'Tu trono oh dios',
    'Tipo' : 'Adoracion',
    'UltimaVez' : ISODate('2014-06-01T02:44:44.802Z'),
    'Letra' : ''
},

 
{
    '_id' : '538a939fe3f6ce1efc850e2f',
    'Nombre' : 'Tu y yo',
    'Tipo' : 'Alabanza',
    'UltimaVez' : ISODate('2014-06-01T02:44:44.802Z'),
    'Letra' : ''
},

 
{
    '_id' : '538a939fe3f6ce1efc850e30',
    'Nombre' : 'Una vez mas',
    'Tipo' : 'Adoracion',
    'UltimaVez' : ISODate('2014-06-01T02:44:44.802Z'),
    'Letra' : ''
},

 
{
    '_id' : '538a939fe3f6ce1efc850e31',
    'Nombre' : 'Uno de nosotros',
    'Tipo' : 'Alabanza',
    'UltimaVez' : ISODate('2014-06-01T02:44:44.802Z'),
    'Letra' : ''
},

 
{
    '_id' : '538a939fe3f6ce1efc850e32',
    'Nombre' : 'Vamos a la ciudad',
    'Tipo' : 'Adoracion',
    'UltimaVez' : ISODate('2014-06-01T02:44:44.802Z'),
    'Letra' : ''
},

 
{
    '_id' : '538a939fe3f6ce1efc850e34',
    'Nombre' : 'Ven espiritu ven',
    'Tipo' : 'Adoracion',
    'UltimaVez' : ISODate('2014-06-01T02:44:44.802Z'),
    'Letra' : ''
},

 
{
    '_id' : '538a939fe3f6ce1efc850e35',
    'Nombre' : 'Vengo a ti',
    'Tipo' : 'Adoracion',
    'UltimaVez' : ISODate('2014-06-01T02:44:44.802Z'),
    'Letra' : ''
},

 
{
    '_id' : '538a939fe3f6ce1efc850e36',
    'Nombre' : 'Venid adoremos',
    'Tipo' : 'Adoracion',
    'UltimaVez' : ISODate('2014-06-01T02:44:44.802Z'),
    'Letra' : ''
},

 
{
    '_id' : '538a939fe3f6ce1efc850e37',
    'Nombre' : 'Venid todos',
    'Tipo' : 'Alabanza',
    'UltimaVez' : ISODate('2014-06-01T02:44:44.802Z'),
    'Letra' : ''
},

 
{
    '_id' : '538a939fe3f6ce1efc850e38',
    'Nombre' : 'Venimos ante ti ii',
    'Tipo' : 'Adoracion',
    'UltimaVez' : ISODate('2014-06-01T02:44:44.802Z'),
    'Letra' : ''
},

 
{
    '_id' : '538a939fe3f6ce1efc850e3a',
    'Nombre' : 'Vine adorar a dios',
    'Tipo' : 'Adoracion',
    'UltimaVez' : ISODate('2014-06-01T02:44:44.802Z'),
    'Letra' : ''
},

 
{
    '_id' : '538a939fe3f6ce1efc850e3b',
    'Nombre' : 'Y vendra sobre ti',
    'Tipo' : 'Adoracion',
    'UltimaVez' : ISODate('2014-06-01T02:44:44.802Z'),
    'Letra' : ''
},

 
{
    '_id' : '538a939fe3f6ce1efc850e3c',
    'Nombre' : 'Yeshua',
    'Tipo' : 'Adoracion',
    'UltimaVez' : ISODate('2014-06-01T02:44:44.802Z'),
    'Letra' : ''
},

 
{
    '_id' : '538a939fe3f6ce1efc850e3d',
    'Nombre' : 'Yo celebrare',
    'Tipo' : 'Alabanza',
    'UltimaVez' : ISODate('2014-06-01T02:44:44.802Z'),
    'Letra' : ''
},

 
{
    '_id' : '538a939fe3f6ce1efc850e3e',
    'Nombre' : 'Yo quiero mas de ti',
    'Tipo' : 'Adoracion',
    'UltimaVez' : ISODate('2014-06-01T02:44:44.802Z'),
    'Letra' : ''
},

 
{
    '_id' : '538a939fe3f6ce1efc850e3f',
    'Nombre' : 'Yo quiero ser un adorador',
    'Tipo' : 'Alabanza',
    'UltimaVez' : ISODate('2014-06-01T02:44:44.802Z'),
    'Letra' : ''
},

 
{
    '_id' : '538a939fe3f6ce1efc850e40',
    'Nombre' : 'Yo solo quiero estar',
    'Tipo' : 'Adoracion',
    'UltimaVez' : ISODate('2014-07-06T20:24:15.717Z'),
    'Letra' : ''
},

 
{
    '_id' : '538a939fe3f6ce1efc850e41',
    'Nombre' : 'Yo te alabo',
    'Tipo' : 'Adoracion',
    'UltimaVez' : ISODate('2014-06-01T02:44:44.802Z'),
    'Letra' : ''
},

 
{
    '_id' : '538a939fe3f6ce1efc850e42',
    'Nombre' : 'Yo te necesito jesucristo',
    'Tipo' : 'Adoracion',
    'UltimaVez' : ISODate('2014-06-01T02:44:44.802Z'),
    'Letra' : ''
},

 
{
    '_id' : '538a939fe3f6ce1efc850e43',
    'Nombre' : 'Yo tengo gozo',
    'Tipo' : 'Alabanza',
    'UltimaVez' : ISODate('2014-06-01T02:44:44.802Z'),
    'Letra' : ''
},

 
{
    '_id' : '538a939fe3f6ce1efc850e44',
    'Nombre' : 'Yo tengo un amigo',
    'Tipo' : 'Alabanza',
    'UltimaVez' : ISODate('2014-06-01T02:44:44.802Z'),
    'Letra' : ''
},

 
{
    '_id' : '538a939fe3f6ce1efc850e45',
    'Nombre' : 'Yo tengo un nuevo amor',
    'Tipo' : 'Alabanza',
    'UltimaVez' : ISODate('2014-06-01T02:44:44.802Z'),
    'Letra' : ''
},

 
{
    '_id' : '538a939fe3f6ce1efc850e04',
    'Nombre' : 'Señor mi dios',
    'Tipo' : 'Adoracion',
    'UltimaVez' : ISODate('2014-05-01T19:11:56.755Z'),
    'Letra' : '{title:SEÑOR MI DIOS},\n\n\n[Dm]SEÑOR MI DIOS\nDIGNO TU [Bb]ERES\nDE SU[C]BLIME ADORA[Dm]CIÓN \n\n[Dm]A TI MIS LABIOS \nNO CESEN [Bb]NUNCA\n[C]JAMAS DE PROCLA[Dm]MAR\n\n\n{start_chorus},\nTÚ ERES [F]EXCELSO\nDIOS PODE[C]ROSO\nREY DE [Bb]REYES Y SE[Gm]ÑOR DE SE[A]ÑORES\nTU NOMBRE ES [F]GRANDE\nAQUÍ EN LA [C]TIERRA\nEN EL [Bb]CIELO Y [Gm]TAMBIÉN EL\n[A]UNIVERSO\n{end_chorus},\n\n\n[Dm]TODAS LAS LENGUAS\nY LAS [Bb]NACIONES CON[C]FIESEN AL [Dm]SEÑOR\n\n[Dm]TAMBIÉN LA LUNA\nY LAS [Bb]ESTRELLAS Y EL [C]SOL\nTE ALABA[Dm]RAN'
},

 
{
    '_id' : '538a939fe3f6ce1efc850d43',
    'Nombre' : 'Bueno es alabarte',
    'Tipo' : 'Alabanza',
    'UltimaVez' : ISODate('2014-05-01T19:11:56.755Z'),
    'Letra' : '{title:Bueno es Alabarte},\n\n//bue[F]no es alab[Bb]arte S[C]eñor, tu nombre\nDar[F]te gloria, ho[Bb]nra y ho[C]nor, por siempre\nBu[F]eno es alab[Bb]arte Je[C]sus \nY go[F]zarme en [Bb]tu pod[C]er//\n\n{start_chorus},\n//porque gra[F]nde er[Bb]es t[C]u\nGra[F]ndes so[Bb]n tus o[C]bras\nPorque gr[F]ande e[Bb]res t[C]u, gra[C#]nde es tu am[D]or\nGrande es tu glo[C]ria//\n{end_chorus},\n'
},

 
{
    '_id' : '538a939fe3f6ce1efc850d3e',
    'Nombre' : 'Bendito sea aquel',
    'Tipo' : 'Adoracion',
    'UltimaVez' : ISODate('2014-05-01T19:11:56.755Z'),
    'Letra' : '{title: Bendito sea aquel},\n//Ben[d]dito sea aqu[G]el \nQue esta sent[F#/a]ado en el trono[Bm][G][A]//\n//A É[D]l sea el hon[g]or a É[D/F#]l sea la maj[bm]estad\nA É[D]l sea el po[G]der y la glo[Bm]ria// [C/E][D/F#]\n\n{start_chorus},\nBen[G]dito sea jeh[A]ova y digno de supr[F#/A]ema alab[Bb]anza\nBend[G]ito sea jeh[A]ova nuestro r[Bm]ey\nTe exa[G]lto oh o[A]h oh o[d]h\n{end_chorus},\n'
},

 
{
    '_id' : '538a939fe3f6ce1efc850d3d',
    'Nombre' : 'Bendecire',
    'Tipo' : 'Adoracion',
    'UltimaVez' : ISODate('2014-05-01T19:11:56.755Z'),
    'Letra' : '{title: Bendeciré},\n\nBende[Dm]ciré al señor por sie[C]mpre\nSu die[Bb]stra es to[A]do pod[Dm]er//\n//echo a la m[C]ar quien los perseg[Dm]uía jinete\nCab[C]allo echo a la m[Dm]ar//\nEc[C]ho a la m[F]ar\nLos ca[Gm]rros de fara[A]ón oh,oh\n\n{start_chorus},\nLa,[Dm] la[C], la[Bb][A],la[Dm] ,la\n//mi padre es Di[C]os\nY yo le ex[Dm]alto\nMi padre es Di[C]os y le exal[Dm]tare//\n{end_chorus},\n'
},

 
{
    '_id' : '538a939fe3f6ce1efc850d3b',
    'Nombre' : 'Bajo tu control',
    'Tipo' : 'Alabanza',
    'UltimaVez' : ISODate('2014-05-01T19:11:56.755Z'),
    'Letra' : '{title: Bajo tu Control},\n\n[F#m]si[D] pudiera y[C#]o subir al cielo, ah[F#]í te enc[D]entrar[C#]ía\n[F#m]si baja[D]ra a L[C#]o profundo de La tierra [D]también ahí te encontraría\n[F#m]si vo[D]lara y[C#]o hacia el este, [F#m]tu ma[D]no de[C#]recha me guiaría\n[F#m]Y si me que[D]dara a v[C#]ivir en el oeste tam[D]bién ahí me darías tu ayuda\n\n{start_chorus},\n[A]Me tienes rodeado,[E] por completo\n[F#m]Estoy bajo tu con[D]trol\n[A]Me tienes rodeado,[E] por completo\n[F#m]Estoy bajo tu con[D]trol\nNa[F#m]rana narana na[D]ranarana[A] bajo tu con[E]trol\nNa[F#m]rana narana na[D]ranarana[A] bajo tu con[E]trol\n\n{end_chorus},\n[F#m]para t[D]i no ha[C#]y diferencia[F#] entre la[D] oscurid[C#]ad y la luz\n[F#m]para ti[D] hasta la no[C#]che brilla co[D]mo la luz del sol\n\nDios[F#m] mío que difícil me resulta\nEnte[D]nder tus pensamientos\npero más difícil tod[A]avía me seria\ntra[E]tar de contarlos\n[F#m]seria más que la arena del mar\ny au[D]n así si pudiera contarlos\nme dorm[A]iría y al despertar\ntodavía, tod[E]avía estarías conmigo\n'
},

 
{
    '_id' : '538a939fe3f6ce1efc850d3c',
    'Nombre' : 'Bajo tus alas',
    'Tipo' : 'Adoracion',
    'Letra' : '{title: Bajo tus Alas},\nCuando y[C]o esté angusti[Em]ado y vací[Am]o, \nEspíritu [F]v[Dm]en sobre[F] m[G]í.\nHaz[C]me na[Em]cer, te lo supli[Am]co,\nNecesi[F]to estar ju[G]nto a t[C]i\n\n{start_chorus},\nProteg[C]ido ba[Em]jo tus al[Am]as\nMi am[F]or, señ[Dm]or, yo te dar[F]é[G] \nCon go[C]zo elevaré[Em] un nuevo can[Am]tico\nY tú [F]transforma[G]rás mi se[C]r.\n{end_chorus},\nMi al[C]ma tiene s[Em]ed, mi ser te an[Am]hela. \nEn desi[F]erto, en sole[Dm]dad allí esta[F]rá[G]s. \nY po[C]dré ver tu po[Em]der, veré tu glo[Am]ría\nY en tu nom[F]bre yo mis ma[G]nos alz[C]aré\n',
    'UltimaVez' : ISODate('2014-05-01T19:11:56.755Z')
},

 
{
    '_id' : '538a939fe3f6ce1efc850d2d',
    'Nombre' : 'Adoramos',
    'Tipo' : 'Adoracion',
    'UltimaVez' : ISODate('2014-05-01T19:11:56.755Z'),
    'Letra' : '{title:ADORAMOS},\n\nIntro\n[F#][E][D][Bm][E][A]\n\nADO[C#]RAMOS  POR  SIE[D]MPRE \nAL CRE[E]ADOR\n[A]A TI SEÑ[D]OR ALZA[Bm]MOS\nNUESTRA[E] VOZ\n\n// TU [F#m]NOMBRE SAN[E]TO ES[D]  //[A]\n\nCORO:\nCUAN SANTO ERES[C#m] TÚ\nSAN[D]TA TRINI[Bm]DAD\nRE[A]Y DE REYES Y[D] EL SEÑO[Bm]R[A]\n\nT[D]U NOMBRE[E] ES\nT[C#m]U NOMBRE[F#m] ES\nTU NO[D]MBRE SAN[E]TO ES.[A]'
},

 
{
    '_id' : '538a939fe3f6ce1efc850d2b',
    'Nombre' : 'Aclamad a dios',
    'Tipo' : 'Alabanza',
    'UltimaVez' : ISODate('2014-05-18T13:40:47.246Z'),
    'Letra' : '{title:ACLAMAD A DIOS},\n\nAclamad a Di[Am]os \ncon alegría toda[G] la[F] tierra\ncan[G]tad la gloria de su No[Am]mbre\nponed gloria en [G]su ala[F]banza\ndecid a Di[G]os \n//cuan asom[G]brosas son tus o[Am]bras// \n\n{start_chorus},\nTo[Am]da la tierra te adora[F]ra \n//[G]toda la tierra canta tu Nom[Am]bre//\n{end_chorus},'
},

 
{
    '_id' : '538a939fe3f6ce1efc850d29',
    'Nombre' : 'Abba padre',
    'Tipo' : 'Adoracion',
    'UltimaVez' : ISODate('2014-05-04T17:55:25.993Z'),
    'Letra' : '{title:ABBA PADRE},\n\nU[D]NA VEZ MÁS\nME[Bm] ACERCO A TI  \nCON  LIBE[G]RTAD\nEN [Em]ADORA[A]CIÓN\n\nTU[D] ERES MI DIOS\nTU[Bm] HIJO SOY\nMI COMU[G]NIÓN CON[Em]TIGO\nES UNA DU[G]LCE BENDI[A]CIÓN\n\n{start_chorus},\n//A[D]BBA  PA[G]DRE, A[D]BBA PA[G]DRE\nES[D]TAR CON[Bm]TIGO\nES UNA DU[G},LCE BEN[A]DICIÓN \nAB[D]BA  PA[G]DRE  TE [F#m] AMO  SE[Bm]ÑOR\nQU[G]IERO ESTAR  EN COM[D]UNIÓN\n[Em]QUIER[F#m]O EST[G]AR[A] CONTI[D]GO.\n//\n{end_chorus},'
},

 
{
    '_id' : '538a939fe3f6ce1efc850d28',
    'Nombre' : 'A él sea la gloria',
    'Tipo' : 'Adoracion',
    'UltimaVez' : ISODate('2014-05-04T17:49:17.881Z'),
    'Letra' : '{title:A ÉL SEA LA GLORIA},\n\n// [Fm] TODO ES DE MI [C#]CRISTO,//\nPOR[D#] ÉL Y PARA [Fm]ÉL.\n\n\n{start_chorus},\nA ÉL SEA LA[C#] GLORIA,[D#]\nA ÉL SEA LA [Cm]GLORIA,[Fm]\nA ÉL SEA LA[C#] GLORIA[D#], POR SIEMPRE [Fm]AMÉN.\n{end_chorus},\n\nOH, PROFUNDAS [C#] RIQUEZAS\nDE[D#] LA SABIDURÍA DE [Fm] DIOS;\nINSONDABLES SUS [C#]JUICIOS\nY [D#] SUS CAMINOS [Fm]SON.'
},

 
{
    '_id' : '538a939fe3f6ce1efc850d26',
    'Nombre' : 'A ti atribumos',
    'Tipo' : 'Adoracion',
    'UltimaVez' : ISODate('2014-05-04T06:11:17.835Z'),
    'Letra' : '{title:A TI ATRIBUIMOS},\n \n// A T[G]I ATRIBUIMOS LA GLO[C]RIA\n\nA TI [Am] ATRIBUIMOS LA HO[D]NRA      [C/E] [D/F#]\n\nA TI ATRI[G]BUIMOS PO[C]DER Y MAJES[Am]TAD\n\nSAN[G]TO ES [D] EL SEÑ[G]OR //'
},

 
{
    '_id' : '538a939fe3f6ce1efc850d27',
    'Nombre' : 'A ti',
    'Tipo' : 'Adoracion',
    'UltimaVez' : ISODate('2014-05-01T19:11:56.755Z'),
    'Letra' : '{title:A TI},\n\nA T[D]I EL AL[G]FA Y LA OME[D]GA\nEL PRIN[F#m]CIPIO [F#] Y EL F[Bm]IN\nY EL  GRA[Em]N  YO SOY\nME R[G]INDO[A] \n\nA [D]TI EL TO[G]DO  PODE[D]ROSO  \nEL QUE[F#m] ES[F#] Y QUE SE[Bm]RA\nY EL GRA[Em]N YO  SOY\nME ENTR[G]EGO[A]\n\n{start_chorus},\n//YO QUIE[G]RO QUE GOBIER[A]NES MI  VI[F#m]DA [Bm]\nME D[G]OY EN SACRIFI[A]CIO A T[D]I\nYO QUIE[G]RO QUE TU ORD[A]ENES \nMI CAMI[F#m]NAR\nQUE SIEM[Em]PRE VI[F#]VA E[G]N TU VO[A]LUNTA[D]D  //\n{end_chorus},'
},
{
    '_id' : '538a939fe3f6ce1efc850d22',
    'Nombre' : 'A cristo',
    'Tipo' : 'Adoracion',
    'UltimaVez' : ISODate('2014-05-04T06:11:18.073Z'),
    'Letra' : '{title:A CRISTO SOLO A CRISTO},\n// A [G]CRISTO SOLO A [Em]CRISTO[C]\n[Am]YO EXALTARÉ[D] Y [G]ADORARÉ //\n\n \n[Am]PORQUE ÉL ME HA DADO VIDA [D]ETERNA\n[Am]PORQUE ÉL ME HA DADO EL [D]PODER\n[Am]PORQUE ÉL ME HA DADO LA [D]VICTORIA\nÉL ES MI REY.[G] [B] [Em]\nA [C]CRISTO HE [D] PROCLAMADO[C] [D] REY.[G]'
},

 
{
    '_id' : '538a939fe3f6ce1efc850da1',
    'Nombre' : 'Grandes y maravillosas',
    'Tipo' : 'Alabanza',
    'Letra' : '{title:GRANDES Y MARAVILLOSAS},\n\nGRA[Cm]NDES Y MARAVILLOSAS SON TUS OB[G]RAS        \nSEÑ[Cm]OR DIOS TODO PODE[G]ROSO\nDUL[Fm]CES Y VERDADEROS SON TUS CAM[Bb]INOS\nREY DE LOS SAN[Eb]TOS, REY DE LOS SAN[Dm]TOS [Cm]\n\nQUI[Cm]EN NO TE TEMERÁ  OH SE[G]ÑOR\nY GLO[Cm]RIFICARÁ TU NOM[G]BRE\nPU[Fm]ES SOLO TÚ ERES SA[G]NTO\nPOR LO CU[Eb]AL TODAS LAS NACI[Dm]ONES\nVEN[Cm]DRÁN Y TE ADOR[G]ARAN\nY TE ADORARAN\n////AL[Cm]ELUYA  AMEN[G]////\n\nTE[Cm]MED A DIOS Y DADLE GLO[G]RIA \nPOR[Cm]QUE SUS JUICIOS HAN LLE[G]GADO \nY [Fm]ADORAD AQUEL QUE HI[Bb]ZO\nEL CI[Eb]ELO, Y LA TIE[Dm]RRA Y EL MA[Cm]R \nY LAS FUE[G]NTES DE LAS AGU[Cm]AS   \n ////AL[Cm]ELUYA  AMEN[G]////\n ',
    'UltimaVez' : ISODate('2014-06-01T16:52:48.100Z')
},

 
{
    '_id' : '538a939fe3f6ce1efc850d6c',
    'Nombre' : 'El es el rey',
    'Tipo' : 'Adoracion',
    'Letra' : '{title:ÉL ES EL REY},\n\nINTRO[Dm][Bb][F][C]\n\nÉL[Dm] ES EL REY DE INFIN[Bb]ITO EN PODER\nÉL [Dm]ES EL REY DE LOS CIE[Bb]LOS\nSE[Dm]RÉ PARA É[Bb]L SIERVO FIEL\nPU[F]ES MI VIDA COMPRÓ CON SU AM[C]OR\n\nÉL [Dm]ES EL REY LO CONFI[Bb]ESA MI SER\nÉL [Dm]ES EL REY DE LOS SI[Bb]GLOS\nM[Dm]I VIDA LA RI[Bb]NDO A SUS PIES\nÉL ES R[F]EY SOBRE MI COR[C]AZÓN\n \n{start_chorus},\nÉ[Dm]L ES EL REY\nÉ[Bb]L ES EL REY\nÉL[F] ES EL REY DE MI VI[C]DA\n\nÉ[Dm]L ES EL REY\nÉ[Bb]L ES EL REY\nRE[F]INA CON AUTO[C]RIDAD\nSU RE[Bb]INO ETERNO E[C]S\nSU TRO[Dm]NO EL CIELO E[Bb]S\nÉ[Gm]L ES EL REY QUE VIE[C]NE A SU PUEBLO A LLE[Dm]VAR\n{end_chorus},',
    'UltimaVez' : ISODate('2014-06-01T16:52:48.099Z')
},

 
{
    '_id' : '538a939fe3f6ce1efc850d9a',
    'Nombre' : 'Golpe de espada',
    'Tipo' : 'Alabanza',
    'Letra' : '{title:GOLPE DE ESPADA},\n\nGOLPE DE ESP[E]ADA\n ES LA ALAB[D]ANZA \nGOLPE DE GUER[C]RA QUE SA[D]LE DE DI[E]OS\n\nCANTOS DE GLO[E]RIA\nDAN LA VICT[D]ORIA\nEN LA BATA[C]LLA DEL PUE[D]BLO DE DI[E]OS\n\n{start_chorus},\n//Y CADA GOL[G]PE DE LA ESP[C]CADA DE DI[D]OS\nES CON PAN[G]DERO CON TROM[C]PETA Y TAM[D]BOR//\n\nCA[C]NTOS DE J[D]UBILO[E]\nCA[C]NTOS DE J[D]UBILO[B]\n{end_chorus},\n',
    'UltimaVez' : ISODate('2014-06-01T16:52:48.100Z')
},

 
{
    '_id' : '538a939fe3f6ce1efc850d86',
    'Nombre' : 'Eres todo para mi',
    'Tipo' : 'Alabanza',
    'Letra' : '{title:ERES TODO PARA MI},\n\nT[Dm]U ME DISTE AL[C]AS PARA VO[Dm]LAR \nCU[Bb]ANDO NI SIQUIERA POD[C]IA RES[Dm]PIRAR\nT[Dm]E ME APAREC[C]ISTE EN LA TEMPE[Dm]STAD\nU[Bb]N LUGAR QUE NUNCA NAD[C]IE PUDO HAL[Dm]LAR\t\n\nSO[F]LO TU AM[C/E]OR Y TU PO[Dm]DER\nHIC[F]IERON REA[Bb]LIDAD LO QUE BUS[C]QUE\n\n{start_chorus},\n\nER[Bb]ES TO[C]DO PA[Dm]RA MI\nER[Bb]ES M[C]I RA[Dm]ZON\nY[Bb]A NO QUI[C]ERO ES[Dm]TAR SIN TI \nV[Bb]IVO PO[C]R TU AM[Dm]OR\n\nCO[Dm]NTIGO ADELA[C]NTE YO SEGU[Dm]IRE \nMU[Bb]Y SEGURO EN EL CAM[C]INO QUE TO[Dm]ME\nNO H[Dm]AY MONTAÑA QU[C]E NO PUEDA SUB[Dm]IR\nTEN[Bb]GO MI ESPERANZA PUE[C]STA SOLO EN T[Dm]I\n{end_chorus},',
    'UltimaVez' : ISODate('2014-06-01T16:52:48.098Z')
},

 
{
    '_id' : '538a939fe3f6ce1efc850d56',
    'Nombre' : 'Cuando veo tu amor',
    'Tipo' : 'Adoracion',
    'Letra' : '{title:CUANDO VEO TU AMOR},\n\nCUANDO VE[C]O TU AM[Am]OR\nCUANDO ESCU[F]CHO TU VER[G]DAD \nCUANDO SIE[C]NTO TU CA[Am]LOR \nY ADM[F]IRO TU BON[G]DAD\n\nME DEL[Em]EITO EN T[Am]I SEÑOR \nYO ME PO[Em]STRO SOLO EN T[Am]I\nME SUSTE[Em]NTO EN TU AM[Am]OR\nPOR SIEM[F]PRE TE [G]ALAB[F]ARE SO[G]LO A T[C]I\n\n{start_chorus},\n//YO ME POS[Am]TRO EN TU PRES[Em]ENCIA \nTE ADO[F]RO EN SANT[G]IDAD\nTE BEN[Am]DIGO CON MI VI[Em]DA\nY  YO QUI[F]ERO OFREN[G]DARME A T[F]I\n[G]EN SANT[C]IDAD//\n{end_chorus},',
    'UltimaVez' : ISODate('2014-06-01T16:52:48.095Z')
},

 
{
    '_id' : '538a939fe3f6ce1efc850d65',
    'Nombre' : 'Dios hermoso',
    'Tipo' : 'Adoracion',
    'Letra' : '{title:DIOS HERMOSO},\n\nD[F]IOS HERMO[Bb]SO ERE[F]S  [Bb]\nSOBER[C]ANO EN GLO[F]RIA  [Bb]\nERES INC[C]OMPARA[F]BLE [Bb]\nEN TU HERMO[F]SURA  [Bb]\nERES INCO[C]MPARA[F]BLE [Bb]\nEN TU MA[C]JESTA[F]D\n\n{start_chorus},\n\nNO HAY OTRO DI[Bb]OS\nCO[C]MO EL NO H[F]AY\nNO HAY OTRO DI[Bb]OS\nCO[C]MO EL SEÑ[F]OR\n\nN[Dm]O LO HAY EN EL CI[Bb]ELO \nN[C]O LO HAY EN LA TI[F]ERRA \nN[Dm]O LO HAY EN EL M[Bb]AR [C], \nDIOS CO[Bb]MO EL SEÑ[F]OR\n{end_chorus},\n',
    'UltimaVez' : ISODate('2014-06-01T16:52:48.098Z')
},

 
{
    '_id' : '538a939fe3f6ce1efc850d4f',
    'Nombre' : 'Conozco',
    'Tipo' : 'Adoracion',
    'Letra' : '{title:CONOZCO},\n\nCON[F]OZCO QUE TODO LO PUE[Bb]DES\nEN MI PENSAM[C]IENTO [Bb/C]\nNO LO PUEDO ES[F]CONDER[Bb/C]\nHAB[F]LABA LO QUE NO ENTE[Bb]NDIA\nY DE OID[Gm]AS TE HABIA OI[C]DO\n\n{start_chorus},\nMAS AH[F]ORA MIS OJ[Am]OS TE VE[D]N\n[F/C]YO TE PREGU[Gm]NTARE\nY TU ME ENSEÑARAS[Bb/C]\nMAS AH[F]ORA MIS OJ[Am]OS TE V[Dm]EN\nME RIN[F/C]DO A TUS PI[Gm]ES\nY ME AR[Bb]REPIENTO[C] SEÑ[F]OR.\n{end_chorus},',
    'UltimaVez' : ISODate('2014-06-01T16:52:48.097Z')
},

 
{
    '_id' : '538a939fe3f6ce1efc850d44',
    'Nombre' : 'Cada dia',
    'Tipo' : 'Adoracion',
    'Letra' : '{title:CADA DIA},\n\nMI CORA[D]ZÓN CONFIADO ES[A]TA POR QUE YO TE CON[Bm]OZCO\nY EN MED[F#m]IO DE LA TEMP[G]ESTAD NUNCA ESTOY SO[A]LA\nY PU[D]EDO TU SILUETA V[A]ER EN MEDIO DE LA NIE[Bm]BLA\nTU GRA[F#m]CIA ES SUFICIENTE EN M[G]I SI EL MUNDO TIE[A]MBLA\n\n{start_chorus},\nCADA DÍ[D]A DESPI[G]ERTO Y TU MISERIC[A]ORDIA ESTA CONM[Bm]IGO\nPUE[F#m]DO DESCAN[G]SAR TU ERES EL MIS[A]MO\nCADA D[D]ÍA ME ENS[G]EÑAS A CONFIAR EN T[A]I\nCON TU PALA[Bm]BRA\nMI F[F#m]E SE AUMENTA MA[G]S CADA MAÑA[A]NA\n//CA[G]DA DÍ[A]A.// [D]\n{end_chorus},',
    'UltimaVez' : ISODate('2014-06-01T16:52:48.097Z')
},

 
{
    '_id' : '538a939fe3f6ce1efc850d2e',
    'Nombre' : 'Al borde',
    'Tipo' : 'Adoracion',
    'Letra' : '{title:AL BORDE},\n\nAL BOR[G]DE DE[Bm] TU GRAN TR[Em]ONO \nME POS[C]TRARE[Am] HOY A T[D]I\nTU REI[G]NAS SO[Bm]BRE PRINCI[Em]PADOS\nSENT[C]ADO[Am] A LA DIESTRA DE DI[D]OS\n\n{start_chorus},\nEXÁL[G]TATE [Bm]OH GRAN COR[Em]DERO\nTÚ VI[C]VES HO[Am]Y Y VIVI[D]RÁS\nCORÓ[G]NATE [Bm]CON MI ALA[Em]BANZA \nTU NO[C]MBRE [D]ES EL VEN[G]CEDOR\n{end_chorus},\n\n[G]DELANTE DE TU TRO[Bm]NO \nSE[Em]ÑOR YO QUIERO ESTAR \nPA[C]RA CONTEMP[Am]LAR \nTU HER[D]MOSURA Y SANTIDAD\n\nCORO\nY DE[G]CIRT[Bm]E TE AM[Em]O [D][Em]\nY DE[D]CIRT[Am]E TE A[D]DORO\nY DE[G]CIRT[Bm]E TE AM[Em]O\nY QUE E[C]RES TODO P[D]ARA M[G]I\n',
    'UltimaVez' : ISODate('2014-06-15T13:21:06.890Z')
},

 
{
    '_id' : '538a939fe3f6ce1efc850d35',
    'Nombre' : 'Amarte solo a ti',
    'Tipo' : 'Adoracion',
    'Letra' : '{title:AMARTE SOLO A TI},\n\n///AMA[Dm]RTE SOLO A T[A]I SEÑOR///\nY NO MIRAR ATR[D7]ÁS\n\n{start_chorus},\nSEGUIR TU CAMI[Gm]NAR SEÑOR \n[C]SEGUIR SIN DES[D]MAYAR SEÑOR \n[Dm]POSTR[Bb]ARME ANTE TU AL[Gm]TAR SEÑ[A]OR \nY NO MIRAR AT[Dm]RÁS. [D7]\n{end_chorus},\n\n///ADOR[Dm]ARTE SOLO A T[A]I SEÑOR/// Y NO MIRAR ATR[D7]ÁS\n///SERVI[Dm]RTE SOLO A T[A]I SEÑOR///\nY NO MIRAR ATR[D7]ÁS\n',
    'UltimaVez' : ISODate('2014-06-01T02:44:44.802Z')
},

 
{
    '_id' : '538a939fe3f6ce1efc850d36',
    'Nombre' : 'Amor sin condición',
    'Tipo' : 'Alabanza',
    'Letra' : '{title:AMOR SIN CONDICIÓN},\n\nINTRO\n[F][Gm][Am][Bb]\nDE [F]TAL MANERA AL MUNDO TU AMA[C]STE\nQUE HASTA TU VIDA ENTREG[Dm]ASTE\nTU COST[Bb]ADO ABIERTO FU[C]E\n\nFU[F]ERON ESAS GOTAS DE TU SAN[C]GRE\nQUE MI CORAZÓN LIMPI[Dm]ARON\nME HIC[Bb]ISTE UN NUEVO S[C]ER\n\n{start_chorus},\nGRA[F]CIAS, TE DOY GRA[C]CIAS\nPOR TU AM[Dm]OR SIN CON[Bb]DICIÓN EN ESA CR[C]UZ\nGRA[F]CIAS, TE DOY GRA[C]CIAS\nPOR TU PER[Dm]DÓN LA SALV[Bb]ACION EN ESA CR[C]UZ\n\n//AM[F]OR SI[Bb]N CO[Dm]NDICI[C]ÓN//\n{end_chorus},\n',
    'UltimaVez' : ISODate('2014-06-01T02:44:44.802Z')
},

 
{
    '_id' : '538a939fe3f6ce1efc850d2a',
    'Nombre' : 'Abre mis ojos',
    'Tipo' : 'Alabanza',
    'Letra' : '{title:Abre mis ojos },\n\n//Ab[D]re mis ojos oh Cristo,\nAb[A/C#m]re mis ojos te pido,\nYo quiero ve[G/D]rte,\nyo quiero ve[D]rte//\n\n{start_chorus},\nY contem[A]plar tu majes[Bm]tad\nY[G] el resplandor de tu glo[Asus]ria\nD[A]errama tu amor y pod[Bm]er\nmientras can[G]tamos Sa[Asus4]nto, Sa[A]nto\n{end_chorus},\n\nSa[D]nto, Santo, Santo\nSa[A/C#m]nto, Santo, Santo\nSa[G/D]nto, Santo, Santo\nY[D]o quiero verte.\n',
    'UltimaVez' : ISODate('2014-06-01T02:44:44.802Z')
},

 
{
    '_id' : '538a939fe3f6ce1efc850d30',
    'Nombre' : 'Al estar ante ti',
    'Tipo' : 'Adoracion',
    'Letra' : '{title:AL ESTAR ANTE TI},\n\nAL ES[D]TAR ANTE TI[A]\nADOR[Em]ANDO FRENTE AL MAR DE CRI[Bm]STAL\n[A][C#m]ENTRE L[D]A MULTIT[A]UD\nEN ASO[Em]MBRO ALLI ME ABRE DE POST[Bm]RAR\n\n[A][C#m]Y MI [D]CANTO UN[A]IRE\nA MILL[Em]ONES PROCLAMANDOTE RE[Bm]Y\n[A][C#m]Y MI V[D]OZ OIR[A]AS\nEN[Em]TRE LAS MULTITUDES CAN[Bm]TAR [Asus4][A]\n\n[Dadd2/F#]DIGNO ES EL CORD[G]ERO DE DI[Dadd2/F#]OS\nEL QUE FUE INMO[G]LADO E[F#/A#]N LA CRU[Bm]Z\nDI[A]GNO DE LA HO[G]NRA Y[A/C#] EL POD[D]ER\nLA SA[Em]BIDURIA S[Dadd2]UYA ES [A]\n\n[Dadd2/F#]Y AL QUE ESTA EN EL TRO[G]NO SEA EL HON[Dadd2/F#]OR\nSANTO SANTO SA[G]NTO ES E[F#/A#]L SEÑ[Bm]OR\nRE[A]INA POR LOS SIG[G]LOS CO[A/C#]N POD[D]ER\nTODO LO QUE EXI[Em]STE E[Dadd2]S POR EL[Cadd2] [Asus4][A]\n[Em] [A] [D]',
    'UltimaVez' : ISODate('2014-06-01T02:44:44.802Z')
},

 
{
    '_id' : '538a939fe3f6ce1efc850d31',
    'Nombre' : 'Al estar aqui',
    'Tipo' : 'Adoracion',
    'Letra' : '{title:AL ESTAR AQUÍ},\n\nAL ES[G]TAR EN LA PRESENCIA[B7] DE TU DIVI[Em]NIDAD\nY AL CONTE[C]MPLAR LA HERMO[Am]SURA DE TU SAN[D]TIDAD[D7]\nMI ESPÍ[G]RITU SE ALE[Bm]GRA DE TU MAJE[Em]STAD\nTE ADO[C]RO A TI[Am], TE ADO[D]RO A TI\n\nCUANDO VE[G]O LA GRAND[Bm][B7]EZA\nDE TU DULCE[Em] AMOR\nY COMPR[C]UEBO LA PUR[Am]EZA\nDE TU CORA[D]ZÓN[D7]\nMI ESPÍ[G]RITU SE ALE[B7]GRA\nEN TU MAJE[Em]STAD\nTE  ADO[C]RO A TI[Am], TE ADORO A.[D] TI\n\n{start_chorus},\n// Y AL ES[G]TAR AQUÍ DELA[B7]NTE DE TI TE ADOR[Em]ARE\nPOSTRADO AN[C]TE TI MI CORA[Am]ZÓN TE ADORO D[D]IOS [D7]\nY SIEMPRE QUI[G]ERO ESTAR PARA ADO[B7]RAR \nY CON[Em]TEMPLAR TU SANTIDAD \nTE AD[C]ORO A TI SE[D]ÑOR, TE ADO[C]RO A T[G]I.//\n{end_chorus},',
    'UltimaVez' : ISODate('2014-06-01T02:44:44.802Z')
},

 
{
    '_id' : '538a939fe3f6ce1efc850d37',
    'Nombre' : 'Aqui estoy',
    'Tipo' : 'Adoracion',
    'Letra' : '{title:AQUI ESTOY},\n\nA[A]QUÍ EST[E]OY TE OFRE[D]ZCO\nTODO L[E]O QUE SO[A]Y\nA[A]QUÍ EST[E]OY\nUN SA[D]CRIFICIO QUIE[E]RO SE[A]R\nTOMA MI SE[E]R\nMI V[D]IDA ENTRE[Bm]GO A T[E]I\n\n{start_chorus},\n//PORQUE T[A]U ER[D]ES MI DI[E]OS \nTÚ ERES DIG[E]NO DE A[D]DORA[E]CIÓN \nUNA OFRE[A]NDA DE AM[D]OR SE[E]RÉ PA[D]RA T[E]I//\n{end_chorus},\n\n',
    'UltimaVez' : ISODate('2014-06-01T02:44:44.802Z')
},

 
{
    '_id' : '538a939fe3f6ce1efc850d38',
    'Nombre' : 'Aquí estoy hillsong',
    'Tipo' : 'Alabanza',
    'Letra' : '{title:Aquí Estoy},\n\nT[A]ú eres el principio,\nTu[D]ya es la eternidad,\nL[A/C#]lamaste el mundo a exist[F#m]encia\nme hacer[D]co a ti.\n\nMo[A]riste por mis fracasos,\nLlev[D]aste mi culpa en la cruz,\nCarg[A/C#]aste en tus hombros mi ca[F#]rga,\nme ace[D]rco a ti.\n\n¿Qué puedo ha[Bm]cer, qué puedo de[F#m]cir?\nTe o[D]frezco mi corazó[E]n completamente a [F#m]ti.\n\nEn tu s[A]alvación camino, tu esp[D]íritu vive en mí,\nD[A/C#m]eclara  en tus prom[F#m]esas, me acerco a [D]ti\n.\n¿Qué puedo ha[Bm]cer, qué puedo de[F#m]cir?\nTe o[D]frezco mi corazó[E]n completamente a [F#m]ti. [D]\n\t\t\t\n{start_chorus},\nA[A]quí estoy, con man[E]os alz[F#m]adas ven[D]go,\nPues t[A]odo l[E]o dist[F#m]e por m[D]í.\nA[A]quí estoy, mi al[E]ma a t[F#m]i entrego,\nTu[D]yo s[A]oy, Señ[E]or.\n{end_chorus},',
    'UltimaVez' : ISODate('2014-06-08T04:50:22.189Z')
},

 
{
    '_id' : '538a939fe3f6ce1efc850d3a',
    'Nombre' : 'Aunque otros canten',
    'Tipo' : 'Alabanza',
    'Letra' : '{title:AUNQUE OTROS CANTEN},\n\nAun[Dm]que otros canten para otros dioses\t\nHechos de metal de mad[Gm]era ó de bro[Dm]nce\nY[Gm]o alab[Dm]aré, el no[Gm]mbre de Jeh[Dm]ová\nEl no[Gm]mbre de Jeh[A]ová alab[Dm]aré.\n\n{start_chorus},\n//Porque s[Gm]oy un sace[Dm]rdote\nLla[A]mado a ministrar en su pres[Dm]encia\nY ah[Gm]ora alab[Dm]aré,\nEl santo nom[Am]bre bendito de Jeh[Dm]ová.//\n{end_chorus},',
    'UltimaVez' : ISODate('2014-06-01T02:44:44.802Z')
},

 
{
    '_id' : '538a939fe3f6ce1efc850d39',
    'Nombre' : 'Aunque el gigante',
    'Tipo' : 'Alabanza',
    'Letra' : '{title:AUNQUE EL GIGANTE},\n\n//DIOS NO NOS TRA[Dm]JO HASTA AQ[A]UÍ\nPARA VOL[Dm]VER ATRÁS\nNOS TRAJO AQ[Gm]UÍ A PO[A]SEER LA TIERRA QUE NOS DI[Dm]O//\n\n{start_chorus},\n[D]AUNQUE EL GI[Gm]GANTE ENCUENTRE AL[C]LÁ\nYO NUNCA [F]TEMERÉ [C/E] [Dm]\nNOS TRAJO AQ[Gm]UÍ A POSE[A]ER\nLA TIERRA QUE N[Am]OS DIO\n{end_chorus},',
    'UltimaVez' : ISODate('2014-06-01T02:44:44.802Z')
},

 
{
    '_id' : '538a939fe3f6ce1efc850d2c',
    'Nombre' : 'Adorad al cordero santo',
    'Tipo' : 'Adoracion',
    'Letra' : '{title:ADORAD AL CORDERO SANTO},\n\nADO[D]RAD AL COR[A]DERO SANTO \nADO[D]RAD AL SUPR[A]EMO RE[F#/A#]Y  [Bm7]\nADORAD AL COR[Em/G#]DERO SAN[G]TO \nADOR[A]AD A JES[D]ÚS.\n\n{start_chorus},\nY VUESTRAS MANOS AL[A]ZAD\nY CON CAN[G]TO ADO[A]RAD[D]\nY VUESTRAS MANOS ALZ[A]AD\nANTE SU TRO[G]NO CO[A]N GO[D]ZO\nHACIA EL CIELO LAS MA[G]NOS AL[A/G]ZAD\nTODO P[F#]UEBLO[F#/A#] SABR[Bm7]Á\nQUE UN[Em]IDOS AMA[A]MOS AL R[D]EY.\n{end_chorus},\n',
    'UltimaVez' : ISODate('2014-06-01T02:44:44.802Z')
},

 
{
    '_id' : '538a939fe3f6ce1efc850d34',
    'Nombre' : 'Alabemos',
    'Tipo' : 'Alabanza',
    'Letra' : '{title:ALABEMOS},\n\nALABE[Em]MOS, EX[C]ALTEMOS\nAL SE[D]ÑOR, FUER[Em]TE DIOS\nY HONREMOS, DEM[C]OS GLORIA\nDIG[D]NO ES DE LO[Em]OR.\n\nCAN[C]TAD LA GLO[D]RIA DE SU NOM[Em]BRE, \nEXAL[C]TAD  AL RE[D]Y DE LA CREA[Em]CIÓN \nCAN[G]TAD LA GLO[D]RIA DE SU NOM[Em]BRE,\nADO[C]RAD AL CO[D]RDERO DE DI[Em]OS\n\n{start_chorus},\nEL SEÑOR ES DIG[Am]NO DE TO[D]DA LA GLO[Em]RIA\nNUESTRO DIOS E[Am]S DIGNO D[D]E TODO HO[Em]NOR\nACLAMÉM[Am]OSLE CON G[D]OZO,\nCELEBR[G]EMOS SU POD[Em]ER,\t\nPONED GLO[Am]RIA EN SU ALAB[D]ANZA,\nCAN[C]TAD  AN[D]TE EL R[Em]EY\n{end_chorus},',
    'UltimaVez' : ISODate('2014-06-01T02:44:44.802Z')
},

 
{
    '_id' : '538a939fe3f6ce1efc850d45',
    'Nombre' : 'Cantemos a jesus',
    'Tipo' : 'Alabanza',
    'Letra' : '{title:CANTEMOS A JESUS},\n\nC[E]ANTEMOS A JES[A]US\nCANTEMOS A JES[B]US\nSE[C#m]ÑOR DE TODA CREA[G#m]CIÓN \nRE[A]Y DE MI CORA[B]ZÓN\n\nC[E]ANTEMOS A JES[A]US\nCANTEMOS A JES[B]US\nVI[C#m]CTORIOSO MÁS QUE\nVEN[G#m]CEDOR RE[A]Y SOBRE TODA NACI[B]ÓN\n\n{start_chorus},\nTU E[E]RES DIGNO DE LO[A]OR\nTU ERES DIGNO DE LO[B]OR\n R[C#m]EY DE MI COR[G#m]AZÓN\nR[A]EY DE MI CORA[B]ZÓN\n{end_chorus},',
    'UltimaVez' : ISODate('2014-06-01T02:44:44.802Z')
},

 
{
    '_id' : '538a939fe3f6ce1efc850d49',
    'Nombre' : 'Cerca de ti',
    'Tipo' : 'Adoracion',
    'Letra' : '{title:CERCA DE TI},\n\n[F]SI DECIDIERA NEGAR MI FE\nY NO CONFIAR NUNCA MAS EN E[Dm]L\nNO TENGO A DON[Bb]DE IR[Gm]\nNO TENGO A DONDE I[C]R\n\n[F]SI DESPRECIARA MI CORAZÓN\nLA SANTA GRACIA QUE ME SAL[Dm]VO \nNO TENGO A DON[Bb]DE I[Gm]R \nNO TENGO A DON[C]DE IR\n\nCON[Dm]VENCIDO ESTO QUE SIN TU AMOR \nSE ACABARÍAN MIS FUE[C]RZAS\nY SIN TI MI[Gm] CORAZÓN SEDI[Dm]ENTO SE MUERE Y SE SE[C]CA\n\n{start_chorus},\n[F]CERCA DE T[C]I[Gm] YO QUIERO EST[Dm]AR [Bb]\nDE TU PR[F]ESENCIA NO ME QUIERO ALE[C]JAR\n[F]CERCA DE T[C]I [Gm]JESÚS YO QUIERO EST[Dm]AR [Bb]\nDE TU PRE[F]SENCIA NO ME QUIERO ALE[C]JAR\n{end_chorus},',
    'UltimaVez' : ISODate('2014-06-01T02:44:44.802Z')
},

 
{
    '_id' : '538a939fe3f6ce1efc850d4e',
    'Nombre' : 'Con mi Dios',
    'Tipo' : 'Alabanza',
    'Letra' : '{title:CON MI DIOS},\n\nCON MI[Dm] DIOS YO SAL[C]TARE LOS MUR[Dm]OS [Bb] [C] [Dm]\nCON MI[Dm] DIOS EJÉR[C]CITOS DERR[Dm]IBARE [Bb][A]\n\n[D][E][F]\nEL ADIESTRA MIS MA[C]NOS PARA LA BAT[Dm]ALLA\nPUE[C]DO TOMAR CON MIS MANOS EL ARCO DE BR[Dm]ONCE \n\nEL ES[C] MI ESCUDO LA RO[F]CA MÍA\nEL ES[C] LA FUERZA DE MI SAL[F]VACIÓN \nMI ALTO REF[A]UGIO MI FOR[Dm]TALEZA\n[Bb]EL ES [A]MI LIBERTAD[Dm]OR\n',
    'UltimaVez' : ISODate('2014-06-01T02:44:44.802Z')
},

 
{
    '_id' : '538a939fe3f6ce1efc850d54',
    'Nombre' : 'Cristo no esta muerto',
    'Tipo' : 'Alabanza',
    'Letra' : '{title:CRISTO NO ESTA MUERTO},\n\nCRI[G]STO  NO ESTA MUERTO\nEL ESTA VI[C]VO///\nLO SIE[G]NTO EN MIS MANOS\nLO SIE[G]NTO EN MIS PIES\nLO SIE[G]NTO EN TO[C]DO M[D]I SE[G]R\n\nL[G]A TENGO[C]/// [G] [D]\nLA UN[G]CIÓN ESTA SOBRE MI[G][D][C]\nGLORIA    A   DI[D]OS    PORQUE LA TEN[G]GO\n',
    'UltimaVez' : ISODate('2014-06-01T02:44:44.802Z')
},

 
{
    '_id' : '538a939fe3f6ce1efc850d4b',
    'Nombre' : 'Como el ciervo',
    'Tipo' : 'Adoracion',
    'Letra' : '{title:COMO EL CIERVO},\n\n[G]COMO EL CIER[D]VO BUS[Em]CA POR LAS AG[Bm]UAS\nASÍ CLA[C]MA MI AL[G/B]MA POR T[Am7]I SEÑ[D]OR\n[G]DÍA Y NO[D]CHE YO TE[Em]NGO SED DE T[Bm]I\nS[C]OLO A T[Am]I BUSCA[D]RE\n\n{start_chorus},\nL[G]LÉNAM[D]E L[C]LÉNAME SEÑ[D]OR \nD[G]AME M[D]AS M[C]AS DE TU AM[D]OR \nY[Am]O TE[G/B]NGO S[C]ED SO[Am]LO DE T[D]I\nL[C]LÉNAM[D]E SEÑ[G]OR\n{end_chorus},',
    'UltimaVez' : ISODate('2014-06-01T02:44:44.802Z')
},

 
{
    '_id' : '538a939fe3f6ce1efc850d46',
    'Nombre' : 'Celebra victorioso',
    'Tipo' : 'Alabanza',
    'Letra' : '{title:CELEBRA VICTORIOSO},\n\nCE[Am]LEBRA VICTORIOSO[F]\nEL TRIUNFO DE CRISTO\n[Dm]ME HA HECHO M[F]AS QUE V[G]ENCEDO[Am]R[E]\n\nMA[Am]YOR ES EL QUE ESTA EN M[F]I\nQUE EL QUE ESTA EN EL MUNDO\n[Dm]ME HA HECHO M[D]AS QUE V[G]ENCEDO[Am]R[E]\n\n{start_chorus},\nTO[Am]DO LO PUEDO EN CRISTO QUE ME FORT[Dm]ALECE\nM[F]ÁS QUE V[G]ENCEDO[Am]R\nSI    DIOS    ESTA   CONMIGO    QUIEN CONTRA M[Dm]I\nMÁ[F]S QUE VE[G]NCEDO[Am]R\nSOY    MAS    QUE    VENCEDOR    EN CRI[Dm]STO\nMÁ[F]S QUE VEN[G]CEDO[Am]R\n{end_chorus},\n',
    'UltimaVez' : ISODate('2014-06-01T02:44:44.802Z')
},

 
{
    '_id' : '538a939fe3f6ce1efc850d53',
    'Nombre' : 'Cristo es mi señor',
    'Tipo' : 'Alabanza',
    'Letra' : '{title:CRISTO ES MI SEÑOR},\n\nCR[Cm]ISTO ES MI SEÑ[Bb]OR\nNO[Cm] ME DA TE[Bb]MOR\nDECLAR[Fm]ARLE AL MUNDO ENTERO\nDE SU GR[Bb]AN PO[Cm]DER\nEN MI VI[Fm]DA PERMITIRLE QUE EL SE\nDE[Bb]JE VE[G]R\n\nCR[Cm]ISTO ES MI SEÑ[Bb]OR\nNO[Cm] ME DA TE[Bb]MOR\nDEM[Fm]OSTRAR CON MIS ACCIONES\nQUE EL PUE[Bb]DE REI[Cm]NAR\nEN LA VI[Fm]DA DE CUALQUIERA QUE\nSE QUI[Bb]ERA ENTR[G]EGAR.\n\n{start_chorus},\n[Cm]JESUCRIS[Bb/Gm]TO, [Cm]NO ME DETEN[Bb/Gm]DRÉ \nDE DOB[Fm]LAR MI RODILLA Y MI S[G#]ER ANTE TU MAJES[Bb]TAD[G] \n[Cm]JESUCRIS[Bb/Gm]TO, T[Cm]E CONFESA[Bb/Gm]RE\nCON MIS LA[Fm]BIOS DECLAR[G]ARE\nQUE TU ERES SEÑ[C]OR[Bb].\n{end_chorus},',
    'UltimaVez' : ISODate('2014-06-01T02:44:44.802Z')
},

 
{
    '_id' : '538a939fe3f6ce1efc850d4d',
    'Nombre' : 'Como la brisa',
    'Tipo' : 'Adoracion',
    'Letra' : '{title:Como la brisa},\n\nAb[F#m]ro el corazón y las ven[D]tanas\nCuando empieza la mañ[Bm]ana   \nPor si quieres hoy ven[E]ir         \n\nEr[F#m]es como el viento que no av[D]isa\nCuando sopla y trae la br[Bm]isa  \nVen y sopla sobre m[E]í\n           \nY[Bm] mi corazón vue[A/C#]lve a la[D]tir         \nY se renu[A]eva si estas aqu[E]í       \nY m[Bm]i corazón vel[A/C#]a por t[D]i       \nPorque te esp[A]era vuelve a ven[E]ir\n\n{start_chorus},\nEspí[A]ritu de Dios ven a mi vi[Em]da\nComo lluvia que tar[D]do           \nY al desierto v[A/C#m]ida di[Bm]o [E]         \nDesci[A]ende sobre mí como la br[Em]isa                  \nQue destile sobre m[Bm]í \nTú poder en mi h[A/C#m]az flui[D]r    \n{end_chorus},\n',
    'UltimaVez' : ISODate('2014-06-01T02:44:44.802Z')
},

 
{
    '_id' : '538a939fe3f6ce1efc850d6e',
    'Nombre' : 'El evangelio de Dios',
    'Tipo' : 'Alabanza',
    'Letra' : '{title:EL EVANGELIO DE DIOS},\n\nPARA DEST[D]RUIR TODO POT[A]ESTA[D]D \nY TRAE[D]R LUZ EN LA OSCURI[A]DAD\nPARA RES[D]CATAR AL HOMBR[A]E DE PEC[D]AR\nES EL EVA[G]NGELIO[A] DE DI[D]OS\n\n{start_chorus},\n//Y A DI[G]OS SEA L[A]A GLORI[D]A\t\nY A DI[G]OS SEA L[A]A GLOR[D]IA\nY A DI[G]OS SEA L[A]A GLOR[Bm]IA\nES EL EVA[G]NGELIO D[A]E DI[D]OS //\n{end_chorus},\n\nPARA PROCL[D]AMAR AL POBRE L[A]IBERTA[D]D \nNUEVA VI[D]DA AL QUE NO PUEDE M[A]AS\nPARA L[D]OS QUE LLORAN NAC[A]IO JES[D]US \nES E[G]L EVANGE[A]LIO DE DI[D]OS\n\nPARA RE[D]DIMIR A SU P[A]UEBL[D]O\nDE TODA LE[D]NGUA TRIBU Y NACI[A]ON \nDERRAM[D]O SU SANGRE POR SU[A] AM[D]OR\nES E[D]L EVANGE[A]LIO DE DI[D]OS\n\nEL RESUCITO LA MUERTE VENCIO\nCOMO LADRON EN LA NOCHE VENDRA\nY PARA SIEMPRE CON SU ESPOSA REINARA \nES EL EVANGELIO DE DIOS',
    'UltimaVez' : ISODate('2014-06-08T04:50:23.112Z')
},

 
{
    '_id' : '538a939fe3f6ce1efc850dc1',
    'Nombre' : 'Levantate',
    'Tipo' : 'Alabanza',
    'Letra' : '{title:LEVÁNTATE},\n\n//LE[Am]VÁNTATE, LE[G]VÁNTATE SEÑ[Am]OR//[F][G][Am]\n\n\nY HU[Dm]YAN DELANTE DE TI\nTU[G]S ENE[Am]MIGOS\nSE DISP[Dm]ERSEN DELANTE DE TI\nTOD[E]OS AQUELLOS QUE ABORR[Am]ECEN\nTU PRESE[Am]NCIA\n\n{start_chorus},\nTU PRES[F]ENCIA REINARA SOB[G]RE TODO IMP[Am]ERIO \nTU PRES[F]ENCIA REINARA GOBER[E]NARA SOBRE\nTODO PRICI[Am]PADO\n{end_chorus},',
    'UltimaVez' : ISODate('2014-06-08T04:50:22.879Z')
},

 
{
    '_id' : '538a939fe3f6ce1efc850da0',
    'Nombre' : 'Grande es el señor',
    'Tipo' : 'Alabanza',
    'Letra' : '{title:GRANDE ES EL SEÑOR},\n\nGRA[Dm]NDE ES EL SEÑ[C]OR MARAVILLO[Dm]SOS SUS PROD[C]IGIOS\n//Y EN LA FUE[Gm]RZA DE SU MA[Dm]NO HAY PODER// \nPA[A]RA VENCER[Bb][C][Dm]\n\nUN R[C]IO DE ALAB[Dm]ANZA DARE Y SO[C]LO ANTE E[Dm]L DANZARE\n//PUES A CAMB[Gm]IADO MI LAMENTO EN B[Dm]AILE// \nGRA[A]NDE[Bb][C][Dm] ES EL SEÑOR\n\nGRANDE ES EL SEÑOR\nGRA[Dm]NDE ES EL SEÑOR CREADOR DEL UNIVERSO,\nCAN[C]TA Y DANZA A AQUEL QUE VIENE PRONTO\nDE FEL[Dm]ICIDAD EL CORAZÓN NOS LLENA\nGRA[A]NDE ES EL SEÑOR//\n\nCORO:\nO[Dm]H OH OH OH HOSANNA AL ALTÍSIMO[C]//\nGRA[A]NDE ES EL SEÑOR[Bb][C][Dm]',
    'UltimaVez' : ISODate('2014-06-01T02:44:44.802Z')
},

 
{
    '_id' : '538a939fe3f6ce1efc850d98',
    'Nombre' : 'Glorioso rey',
    'Tipo' : 'Alabanza',
    'Letra' : '{title:Glorioso Rey},\nIntro:\n[F#m7][D][Bm7]\n\nLa t[F#m7]ierra tiembla ante el am[D]or de Di[Bm]os\nRe[F#m7]y glorioso todos c[D]anten y[Bm]a\nT[D]u renovarás\nLo v[A]iejo cambiarás\nTo[Bm7]dos creemos que es\n\nDi[A]os más grande qu[E]e\nMi res[F#m7]pirar y mi vi[Esus4][E]vir\nDi[A]os él triunf[E]ará\nTodos dir[F#m7]án\nGlo[Esus4][E]rioso Rey\n\nL[F#m7]os cielos se abren tu rei[D]no ven[Bm]drá\nLos c[F#m7]orazones hoy despe[D]rtará[Bm]n\n\nT[D]u renovarás\nLo v[A]iejo cambiarás\nTo[Bm7]dos creemos que es\n\nDi[A]os más grande qu[E]e\nMi res[F#m7]pirar y mi vi[Esus4][E]vir\nDi[A]os él triunf[E]ará\nTodos dir[F#m7]án\nGlo[Esus4][E]rioso Rey\n////Gl[D]orioso R[E]ey, Glor[D]ioso Re[E]y////\nGlorioso Rey\n\n//G[D]loria, gloria en[Esus4][E]vía tu gloria\nGlo[D/F#]ria, gloria env[Esus4][E]ía tu gloria//',
    'UltimaVez' : ISODate('2014-06-08T04:50:22.430Z')
},
{
    '_id' : '538a939fe3f6ce1efc850db6',
    'Nombre' : 'Jesus Señor de la creacion',
    'Tipo' : 'Adoracion',
    'Letra' : '{title:JESUS SEÑOR DE LA CREACIÓN},\n\nJES[D]ÚS SEÑ[C]OR DE LA CREA[Bb]CIÓN     \nSIE[F]NDO EN FORMA DE DI[C]OS\nDE D[Bb]ESPOJO DE SI MIS[C]MO\n\nTO[D]MO LA SEM[C]EJANZA DE HOM[Bb]BRE\nY[F] SIENDO PURO Y SIN MAN[C]CHA\nEN[Bb]TRE NOSOTROS VIV[C]IÓ\n\nY A[Bb]SI MISMO SE HUM[C]ILLO\nTOM[Gm]ANDO FORMA DE SIE[Dm]RVO\nHA[Bb]STA SU VIDA ENTR[F]EGAR\nY[Bb] EN UNA CRUZ TERM[C]INAR\n\n{start_chorus},\nMAS DI[F]OS A LO SU[C]MO LO EXA[Bb]LTO\nY SU NOM[Gm]BRE ENGRAN[Dm]DECIÓ\nPARA Q[Bb]UE ANTE SU AUT[C]ORIDAD\nTO[Bb]DA RODILLA SE DO[F]BLE\nY T[Bb]ODA LENGUA CON[F]FIESE QUE\nJE[C]SÚS ES EL SEÑ[F]OR\n{end_chorus},\n[C#][Eb][F]El Señor',
    'UltimaVez' : ISODate('2014-06-08T04:50:21.942Z')
},

 
{
    '_id' : '538a939fe3f6ce1efc850e29',
    'Nombre' : 'Tu mirada',
    'Tipo' : 'Adoracion',
    'Letra' : '{title:TU MIRADA},\n\nTUS OJ[F]OS REVELAN QUE YO\n[C]NA[Dm]DA PUEDO ESCONDER\nQUE NO SOY NA[Bb]DA SIN TI[Gm]\nOH BUEN SEÑ[C]OR.[Bb][C]\n\nTO[F]DO LO SABES DE MI\n[C]CUANDO MI[Dm]RAS EL CORAZÓN \nTO[Bb]DO LO PUEDES VER[Gm]\nMUY DENTRO DE M[C]I \n\nLLEVAS MI VI[Bb]DA \n[A]A UNA SOLA VER[Bb]DAD \n[A]QUE CUANDO ME MI[Bb]RAS \nNA[Gm]DA PUEDO OCUL[C]TAR[Bb][C]\n\n{start_chorus},\nS[F]E QUE ES T[C/E]U FIDELIDA[Dm]D\nQ[C/Dm]UIEN LLEVA MI VIDA MAS AL[Bb]LÁ\nDE LO PU[Gm]EDO IMAGIN[C]AR[Bb][C]\n\nS[F]E QUE NO PU[C/]EDO NE[Dm]GAR \nQ[C/Dm]UE TU MIRADA PUESTA EN M[Bb]I\nME LLE[C]NA DE TU P[F]AZ.\n{end_chorus},',
    'UltimaVez' : ISODate('2014-06-08T04:50:21.484Z')
},

 
{
    '_id' : '538a939fe3f6ce1efc850de7',
    'Nombre' : 'Preparare un santuario',
    'Tipo' : 'Adoracion',
    'Letra' : '{title:PREPARARE UN SANTUARIO},\n\n////P[Em]REPARAR[D]E UN SANTU[Em]ARIO \nY EL CA[D]MINO PARA EL SE[Em]ÑOR////\n\n{start_chorus},\nTE ALABARE PORQUE ERES DI[Am]GNO\nT[D]E ALABARE PORQUE ERES FI[G]EL[B]\nT[Em]E ALABARE  PORQUE  ERES SA[Am]NTO\nS[C]ANTO ERES T[B]Ú [Em]\n{end_chorus},',
    'UltimaVez' : ISODate('2014-06-15T13:21:06.887Z')
},

 
{
    '_id' : '538a939fe3f6ce1efc850e33',
    'Nombre' : 'Vamos Escalando',
    'Tipo' : 'Alabanza',
    'Letra' : '{title:VAMOS ESCALANDO},\n\nVA[Dm]MOS ESCALANDO PELDAÑOS \nVAMOS SIGUIENDO A JE[A]SÚS \nSIGAMOS EL CAMINO ANGOSTO \nQUE CON CRISTO SIEMPRE ES ME[Dm]JOR\n\n{start_chorus},\nYA VIENE LA RECO[Gm]MPENSA\nY[C]A NO VOY A LL[F]ORAR\nSI TE[Gm]NGO A CRISTO EN MI VI[A]DA\nCON EL YO VOY A ESC[Dm]ALAR\n{end_chorus},\n\nA VE[Dm]CES ME SIENTO DEBIL \nQUE YA NO PUEDO ESC[A]ALAR\nALZO MIS OJOS AL CIELO \nY LE PIDO Y FUERZAS ME D[Dm]A\n\nNO TEMERÉ SEÑOR AL ENE[A]MIGO\nNO TEMERÉ SEÑOR TU ESTAS CON[Dm]MIGO\nNO TEMERÉ SEÑOR AL ENE[G]MIGO\nPORQUE EL ANGEL DE JEH[Dm]OVA\nPORQUE EL ANGEL DE JEH[A]OVA\nESTA CON[Dm]MIGO\n',
    'UltimaVez' : ISODate('2014-06-15T13:21:06.891Z')
},

 
{
    '_id' : '538a939fe3f6ce1efc850ddf',
    'Nombre' : 'Paz en la Tormenta',
    'Tipo' : 'Adoracion',
    'Letra' : 'PAZ EN LA TORMENTA\n\nCUANDO LL[G]ORAS POR LAS VE[C/G]CES QUE INTENTASTE\n Y  TRA[G]TAS DE OLVIDAR LAS LA[C]GRIMAS QUE LLO[D]RASTE\nSOLO VE[C]Z PENA Y TRI[Bsus4][B]STEZA\n Y EL FU[Em7]TURO INCIERTO ESP[A/C#m]ERAS     \nPUEDES TE[C]NER P[D]AZ EN LA TOR[G]MENTA\n\nCORO:\nPUEDES TENER P[C]AZ EN LA TORMENTA\nFE Y ESPER[G]ANZA CUANDO N[C]O PUEDAS SE[D]GUIR\nAUN CON TU MU[C]NDO HECHOS PED[Bsus4][B]AZOS\nEL SE[Em7]ÑOR GUIARA TUS PA[A/C#m]SOS\t\nEN P[C]AZ EN ME[D]DIO DE LA TOR[G]MENTA\n\nMUC[G]HAS VECES YO ME SIE[C/G]NTO IGUAL QUE TU\nY MI COR[G]AZÓN AN[C]HELA ALGO RE[D]AL\nEL SE[C]ÑOR VIENE A M[Bsus4][B]I Y ME AY[Em7]UDA A SEG[A/C#m]UIR\nEN P[C]AZ EN ME[D]DIO DE LA TOR[G]MENTA',
    'UltimaVez' : ISODate('2014-06-15T13:21:06.889Z')
},

 
{
    '_id' : '538a939fe3f6ce1efc850d7c',
    'Nombre' : 'En lo Suave',
    'Tipo' : 'Adoracion',
    'Letra' : '{title:EN LO SUAVE},\n\n//EN LO SU[D]AVE DE TU PRESENCIA, QUIERO VI[F#m]VIR\nEN LO SU[D]AVE DE TU PRES[G]ENCIA, QUIERO MO[A]RAR//\n\n{start_chorus},\n//Y PERM[G]ANECER EL TI[A]EMPO \nQUE ME S[F#m]EA NEC[Bm]ESARIO [G]\nHASTA QUE TE FOR[A]MES TU EN M[D]I\nY PERM[G]ANECER EL TI[A]EMPO \nQUE ME S[F#m]EA NECE[Bm]SARIO [G]\nHASTA QUE TE VE[A]AS SOLO T[D]U//\n{end_chorus},\n',
    'UltimaVez' : ISODate('2014-06-15T13:21:06.889Z')
},

 
{
    '_id' : '538a939fe3f6ce1efc850d60',
    'Nombre' : 'Derramando',
    'Tipo' : 'Alabanza',
    'Letra' : '{title:DERRAMANDO},\n\nDERR[Am]AMANDO NUESTROS \nCORAZ[G]ONES DEL[F]ANTE DEL TRO[Am]NO\nCANTEMOS COMO ESTR[G]UENDO \nDE GRA[F]NDES AG[E]UAS\n\n{start_chorus},\n//PORQ[F]UE EL SEÑOR TODOPO[G]DEROSO REI[Am]NA//\n{end_chorus},\n\nY LA TI[Am]ERRA SE ESTRE[G]MEZCA \nCOMO UN RI[F]O DE ALAB[Am]ANZA\nCANTANDO ALEL[G]UYA \nPOSTRA[F]DOS ANTE EL TRO[E]NO.\n\nCORO\nAL[Am]ELUYA, ALE[F]LUYA, PE[G]QUEÑOS Y GRANDES\nAL[A]ELUYA, ALE[F]LUYA, LE[G]VANTEN SU VOZ\nAL[A]ELUYA, ALE[F]LUYA, JES[G]UCRISTO REINA\nAL[A]ELUYA AL[F]ELUYA, DE[G]N GLORIA AL SEÑOR\n',
    'UltimaVez' : ISODate('2014-06-15T13:21:06.890Z')
},

 
{
    '_id' : '538a939fe3f6ce1efc850d74',
    'Nombre' : 'El Poderoso de Israel',
    'Tipo' : 'Alabanza',
    'Letra' : '{title:EL PODEROSO DE ISRAEL},\n\nEL SE[Am]ÑOR HARÁ OÍR\nLA MAJESTAD DE SU VOZ\n Y TENDREMOS EN LA NOCHE\n UNA CAN[E]CIÓN VENDREMOS CON GOZO AL MONTE DEL SEÑOR \nY VE[F]REMOS SU GLO[G]RIA Y SU PO[Am]DER\nLOS OJ[Am]OS DE LOS CIEGOS\nSE  ABRIRÁN Y ELLOS VERÁN\nLOS OÍDOS DE LOS SORDOS OI[E]RÁN\nEL COJO SALTARA CON EL ARPA DANZARA\nLA LEN[F]GUA DE LOS M[G]UDOS CANT[Am]ARA.\n\n{start_chorus},\n//EL PODE[Am]ROSO DE ISRAEL//[E]\nSU   VOZ SE OIRÁ NADIE LO DETENDRÁ AL\nPODE[F]ROSO D[G]E ISR[Am]AEL\n{end_chorus},\n\n Y DE NO[Am]CHE CANTAREMOS CELEBRANDO SU PODER\nCAN ALEGRÍA DE COR[E]AZÓN\nCOMO EL QUE VA CON LA FLAUTA\nAL MONTE DE JEHOVÁ \nCEL[F]EBRAREMOS S[G]U PO[Am]DER\n',
    'UltimaVez' : ISODate('2014-06-15T13:21:06.892Z')
},

 
{
    '_id' : '53b9afb7e3f6ce19702b74d3',
    'Nombre' : 'Cantad a Jehova',
    'Tipo' : 'Alabanza',
    'Letra' : '',
    'UltimaVez' : ISODate('2014-07-06T20:24:17.032Z')
},
{
    '_id' : '53bd4ae89df59d4cbc032cae',
    'Nombre' : 'Hacedor de milagros',
    'Tipo' : 'Alabanza',
    'Letra' : '',
    'UltimaVez' : Date(-62135596800000)
},

 
{
    '_id' : '53bd4b0b9df59d4cbc032caf',
    'Nombre' : 'Poderoso para salvar',
    'Tipo' : 'Alabanza',
    'Letra' : '',
    'UltimaVez' : Date(-62135596800000)
},

 
{
    '_id' : '53bd4b739df59d4cbc032cb0',
    'Nombre' : 'Amor Inexplicable',
    'Tipo' : 'Alabanza',
    'Letra' : '',
    'UltimaVez' : Date(-62135596800000)
},
{
    '_id' : '53cb38539df59d5ea35f7829',
    'Nombre' : 'mirame señor',
    'Tipo' : 'Adoracion',
    'Letra' : '',
    'Observaciones' : null,
    'UltimaVez' : Date(-62135596800000)
}, 
{
    '_id' : '53f800269df59d7ef937123e',
    'Nombre' : 'por la mañana al despetar',
    'Tipo' : 'Alabanza',
    'Letra' : 'por la mañana al despertar\ny por la noche al descansar\nagradezco tus bondades a mi vida\npor todo lo  que me permites disfrutar\n\ncoro:\n\naleluya/// agradecido estoy por tu bondad',
    'Observaciones' : null,
    'UltimaVez' : Date(-62135596800000)
},
{
    '_id' : '538a939fe3f6ce1efc850d23',
    'Nombre' : 'A jehova',
    'Tipo' : 'Alabanza',
    'UltimaVez' : ISODate('2014-05-01T19:11:56.755Z'),
    'Letra' : '{title:A JEHÓVA},\n\n// [Em]A  [D]JEHOVA [Em]SIEMPRE [D]CANTARE\nY [G]EN SU [D]PRESENCIA MI [C]ALMA SE [D]DELEITARA[Em]  [D]\n[Em]EL [D]LIBERTO MI [Em]VIDA DEL [D]MAL\nY [G]UN CANTO [D]NUEVO  EL [C]PUSO EN [D]MI [Em]CORAZÓN //\n\nCON  [Em]CANTO  Y  CON  [D]DANZA                                                  \nYO [Em] LE [D]ALABARE[D]\nSEA [Em] DE [D]NOCHE O DE [Em] DÍA[D]\n[Em]COMO [D]COLUMNA DE [Em]FUEGO [D]ALUMBRARA[D]\n[Em]Y MIS [D]PASOS EL [Em]GUIARA[A]\n \n\n// [Em]LAILAI [D]ALIARA [Em]LARA LAI \n[G] LAILAI LA LA [D]LA LA LA LA[Em] LA LAI LAI\n[Em] LARA [D] LARA[Em] LARA [C]LARA LAI[D] LAI [Em]LAI  //\nJESHUA HAMA SHI'
}]";

        }
    }
    public enum Item
    { 
        Etiqueta,
        Acorde
    }
    public class Pos
    {
        public Pos(int x, int y, int linea,string text)
        {
            X = x;
            Y = y;
            Linea = linea;
            Text = text;
        }
        public int    X { get; set; }
        public int    Y { get; set; }
        public int    Linea { get; set; }
        public string Text { get; set; }
    }

    public static class Chord
    {

        public static string GetTitle (string s)
        {
            return GetRegex(RegexList.Title).Match(s).Value.Replace("{title:", "").Replace("}", "");
        }
        public static string GetLyrics(string s)
        {
            string a = GetRegex(RegexList.Title).Replace(s, String.Empty);
            return GetRegex(RegexList.Chords).Replace(a, String.Empty);
        }
        public static string GetChords(string s) {

            s = Clean(s);

            string ss = GetRegex(RegexList.Chords).Replace(s, "*");
            
            Queue<string> notas = ChordsToQueue(s);
            Queue<int> pos = new Queue<int>();
            
            string[]  w= ss.Replace("\r\n", "+").Split('+');
            StringBuilder result = new StringBuilder();
            foreach (string i in w)
            {
                var ch = i.ToCharArray();
                int j=ch.Count(z => z == '*');
                if (j > 0) 
                {
                    result.AppendLine(GetLineWithChords(notas, pos, i, j));                    
                    result.AppendLine(i.Replace("*",""));
                }
                else
                    result.AppendLine(i);
                
            }
            return result.ToString();
        }

        private static string GetLineWithChords(Queue<string> notas, Queue<int> pos, string i, int j)
        {
            int idx = -1;
            for (int p = 0; p < j; p++)
            {
                idx = i.IndexOf('*', idx + 1);
                pos.Enqueue(idx);
            }
            string line = "";
            int ant = 0;
            int act = 0;
            while (pos.Count > 0)
            {
                //ant = pos.Dequeue() - ant;
                //line += notas.Dequeue().PadLeft(ant);
                act = pos.Dequeue();
                line += notas.Dequeue().PadLeft(act - ant);
                ant = act;
            }
            return line;
        }

        private static string Clean(string s)
        {
            s = GetRegex(RegexList.Title).Replace(s, GetTitle(s)).Replace("{start_chorus}", "Coro:").Replace("{end_chorus}", "");
            return s;
        }

        private static Queue<string> ChordsToQueue(string s)
        {
            Queue<string> notas = new Queue<string>();
            MatchCollection q = GetRegex(RegexList.Chords).Matches(s);
            foreach (Match a in q)
            {
                notas.Enqueue(a.Value.Replace("[", "").Replace("]", ""));
            }
            return notas;
        }


        //public static string GetChord(string s)
        //{
        //    return "";
        //}
                
        //public static string parseChord(string s)
        //{
        //    //s=s.Replace("\r\n", "*");
        //    string[]  w= s.Replace("\r\n", "*").Split('*');
        //    //
            
        //    //hallar etiquetas {

        //    Dictionary<Item, List<Pos>> dictionary = new Dictionary<Item, List<Pos>>();
        //    dictionary.Add(Item.Etiqueta, new List<Pos>());
        //    dictionary.Add(Item.Acorde, new List<Pos>());
        //    int line = 0;
        //    foreach (var a in w)
        //    {
        //        if (a.Contains('{'))
        //        {
        //            GetEtiqueta(dictionary, line, a);
        //        }

        //        if (a.Contains('['))
        //        {
        //            GetAcordes(dictionary, line, a);
        //        }
        //        line++;
        //    }
        //    line=0;
        //    var lst = dictionary[Item.Etiqueta];
        //    var acd = dictionary[Item.Acorde];
            
        //    StringBuilder sb = new StringBuilder();
        //    foreach (var a in w)
        //    {
        //        var etiqueta=lst.Where(x => x.Linea == line).ToList();
        //        var acorde = acd.Where(x => x.Linea == line).ToList();
        //        foreach (var etq in etiqueta)
        //        {
        //            sb.Append(etq.Text);
        //        }
        //        bool sw = false;
        //        int idx=0;
        //        string textt = a;
        //        foreach (var crd in acorde)
        //        {
        //            if(sw!=true)
        //            {
        //                sb.AppendLine();
        //            }
        //            sb.Append(crd.Text.PadLeft(crd.X - idx, ' '));
        //            textt = a.Remove(crd.X, crd.Y - crd.X);
        //            idx=crd.X;
        //        }
        //        if(acorde.Count>0)
        //            sb.Append(textt);

        //        sb.Append("\r\n");
        //        line++;
        //    }
        //    //hallar acordes y la linea en la que estan posicionados

            
        //    string chord = "";

        //    return s;
        //}

        //private static void GetAcordes(Dictionary<Item, List<Pos>> dictionary, int line, string a)
        //{
        //    int i = 0;
        //ini:
        //    int p = a.IndexOf('[', i);
        //    int q = a.IndexOf(']', p);
        //    i = q;
        //    p++;
        //    dictionary[Item.Acorde].Add(new Pos(p, q, line,a.Substring(p,q-p)));
        //    int j = a.IndexOf('[', q);
        //    if (j != -1)
        //        goto ini;
        //}

        //private static void GetEtiqueta(Dictionary<Item, List<Pos>> dictionary, int line, string a)
        //{
        //    int i = 0;
        //    ini:
        //    int p = a.IndexOf('{', i);
        //    int q = a.IndexOf('}', p);
        //    i = q;
        //    int pp=p;
        //    if(a.Contains("title:"))
        //    pp= p + 7;

        //    dictionary[Item.Etiqueta].Add(new Pos(p, q, line, a.Substring(pp, q - pp)));
        //    int j = a.IndexOf('{', q);
        //    if (j != -1)
        //        goto ini;
        //}
        static Regex GetRegex(RegexList r)
        {
            string s = "";
            switch(r)
            {
                case RegexList.Title:
                    s = @"(?<title>\{title:[\w\s]*\})";
                    break;
                case RegexList.Chords:
                    s = @"(?<acordes>\[[C|D|E|F|G|A|B]{1}[maj|m|b|#|0-9]*(\/[C|D|E|F|G|A|B][maj|m|b|#|0-9]*)*\])";
                    break;
                case RegexList.Chorus:
                    s = @"(?<chorus>\{start_chorus\}[\w\W\s]*\{end_chorus\})";
                    break;
            }
            return new Regex(s);
        }
        internal static object parseChord(string s)
        {
            //string title   = @"(?<title>\{title:[\w\s]*\})";
            ////string chords1 = @"(?<acordes>\[[C|D|E|F|G|A|B]{1}[m|b|#|0-9]*\])";
            //string chords2 = @"(?<acordes>\[[C|D|E|F|G|A|B]{1}[maj|m|b|#|0-9]*(\/[C|D|E|F|G|A|B][maj|m|b|#|0-9]*)*\])";
            //string chorus  = @"(?<chorus>\{start_chorus\}[\w\W\s]*\{end_chorus\})";

            //Regex r1   = new Regex(title);
            //var match1 = r1.Match(s);
            //Regex r2   = new Regex(chords2);
            //var match2 = r2.Matches(s);

            //Regex r3 = new Regex(chorus);
            //var match3 = r3.Match(s);

            //Regex r4 = new Regex(chords2);
            //string sololetra=r4.Replace(s,String.Empty);

            //int j=0;

            Console.WriteLine(GetTitle(s));

            Console.WriteLine(GetLyrics(s));
            Console.WriteLine("----");
            Console.WriteLine(GetChords(s));
            return new object();
        }
    }

    public enum RegexList
    {
        Title,Chords,Chorus
    }
    public class Cancion
    {
        public Cancion()
        {
            // TODO: Complete member initialization
            Letra = "";
            Nombre = "";
        }
        [BsonId(IdGenerator = typeof(StringObjectIdGenerator))]
        public string   Id        { get; set; }
        public string   Nombre    { get; set; }
        public string   Tipo      { get; set; }
        public DateTime UltimaVez { get; set; }
        public string Letra { get; set; }       
        
    }

    public class Persona
    {
        [BsonId(IdGenerator = typeof(StringObjectIdGenerator))]
        public string Id { get; set; }
        public string User { get; set; }
        public string Pass { get; set; }
        public List<string> Roles { get; set; }
    }
}
