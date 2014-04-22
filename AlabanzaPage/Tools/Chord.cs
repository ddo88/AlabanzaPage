using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;

namespace AlabanzaPage.Tools
{
    public static class Chord
    {

        public static string GetTitle(string s)
        {
            return GetRegex(RegexList.Title).Match(s).Value.Replace("{title:", "").Replace("}", "");
        }
        public static string GetLyrics(string s)
        {
            //string a = GetRegex(RegexList.Title).Replace(s, String.Empty);
            string a = Clean(s);
            string ss = GetRegex(RegexList.Chords).Replace(a, String.Empty);
            ss = ss.Replace("\r", "");
            string[] w = ss.Replace("\n", "+").Split('+');
            StringBuilder result = new StringBuilder();
            foreach (string i in w)
            {
                result.AppendLine(i + "</br>");
            }
            return result.ToString();
        }
        public static string GetChords(string s)
        {

            s = Clean(s);

            string ss = GetRegex(RegexList.Chords).Replace(s, "*");

            Queue<string> notas = ChordsToQueue(s);
            Queue<int> pos = new Queue<int>();
            ss = ss.Replace("\r", "");
            string[] w = ss.Replace("\n", "+").Split('+');
            StringBuilder result = new StringBuilder();
            foreach (string i in w)
            {
                var ch = i.ToCharArray();
                int j = ch.Count(z => z == '*');
                if (j > 0)
                {
                    result.AppendLine(GetLineWithChords(notas, pos, i, j)+"</br>");
                    result.AppendLine(i.Replace("*", "")+"</br>");
                }
                else
                    result.AppendLine(i+"</br>");
                    

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
                //line += "<span class=\"chord\">" + notas.Dequeue().PadLeft(act - ant) + "</span>";
                line += "<span class=\"chord\" style=\"padding-left:" + ((act - ant)*4) + "px;\">" + notas.Dequeue() + "</span>";
                ant = act;
            }
            return line;
        }

        private static string Clean(string s)
        {
            s = GetRegex(RegexList.Title).Replace(s,"<b>"+GetTitle(s)+"</b>").Replace("{start_chorus}", "<b>Coro:</b>").Replace("{end_chorus}", "");
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

        static Regex GetRegex(RegexList r)
        {
            string s = "";
            switch (r)
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
        Title, Chords, Chorus
    }
}