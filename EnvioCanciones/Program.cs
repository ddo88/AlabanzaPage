using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.IdGenerators;
using MongoDB.Driver;
using System.Text.RegularExpressions;

namespace EnvioCanciones
{
    class Program
    {
        static void Main(string[] args)
        {

            string s = "mongodb://pagiel:pagiel@127.0.0.1:27017/alabanza";
            MongoClient mc = new MongoClient(s);
            MongoServer server = mc.GetServer();
            MongoDatabase db = server.GetDatabase("alabanza");
            MongoCollection<Cancion> _evento = db.GetCollection<Cancion>("canciones");
            _evento.InsertBatch(GetList());

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

        //private static string GetMD5(string value)
        //{
        //    MD5 md = MD5.Create();
        //    StringBuilder sBuilder = new StringBuilder();
        //    byte[] data = md.ComputeHash(value.GetBytesFromASCII());
        //    // Loop through each byte of the hashed data 
        //    // and format each one as a hexadecimal string.
        //    for (int i = 0; i < data.Length; i++)
        //    {
        //        sBuilder.Append(data[i].ToString("x2"));
        //    }
        //    return sBuilder.ToString();

        //}
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
