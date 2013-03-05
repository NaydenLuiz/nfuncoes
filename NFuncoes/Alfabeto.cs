using System;
using System.Collections.Generic;
using System.Text;

namespace NFuncoes
{
    public class Alfabeto
    {

        public Alfabeto()
        {
            _letras = new Dictionary<char, string[]>();
            foreach (string linha in Dados.Split(new string[] { "\r\n", "\n" }, StringSplitOptions.RemoveEmptyEntries))
            {
                string[] split = linha.Trim().Split(':');
                _letras.Add(split[0][0], split);
            }
        }

        public enum Tipos
        {
            Militar = 1, Radio = 1, Fone = 1, Otan = 1, Icao = 1, Ansi = 1,
            Romano = 0, Latino = 0, RoyalNavy = 2, SignalEse = 3,
            RAF24 = 4, RAF42 = 5, RAF = 6, US = 7, Portugal = 8, Names = 9,
            LAPD = 10, Morse = 11
        }

        private static readonly string Dados = @"
            A:Alpha:Apples:Ack:Ace:Apple:Able/Affirm:Able:Aveiro:Alan:Adam:.-
            B:Bravo:Butter:Beer:Beer:Beer:Baker:Baker:Bragança:Bobby:Boy:-...
            C:Charlie:Charlie:Charlie:Charlie:Charlie:Charlie:Charlie:Coimbra:Charlie:Charles:-.-.
            D:Delta:Duff:Don:Don:Dog:Dog:Dog:Dafundo:David:David:-..
            E:Echo:Edward:Edward:Edward:Edward:Easy:Easy:Évora:Edward:Edward:.
            F:Foxtrot:Freddy:Freddie:Freddie:Freddy:Fox:Fox:Faro:Frederick:Frank:..-.
            G:Golf:George:Gee:George:George:George:George:Guarda:George:George:--.
            H:Hotel:Harry:Harry:Harry:Harry:How:How:Horta:Howard:Henry:....
            I:India:Ink:Ink:Ink:In:Item/Interrogatory:Item:Itália:Isaac:Ida:..
            J:Juliet:Johnnie:Johnnie:Johnnie:Jug/Johnny:Jig/Johnny:Jig:José:James:John:.---
            K:Kilo:King:King:King:King:King:King:Kilograma:Kevin:King:-.-
            L:Lima:London:London:London:Love:Love:Love:Lisboa:Larry:Lincoln:.-..
            M:Mike:Monkey:Emma:Monkey:Mother:Mike:Mike:Maria:Michael:Mary:--
            N:November:Nuts:Nuts:Nuts:Nuts:Nab/Negat:Nan:Nazaré:Nicholas:Nora:-.
            O:Oscar:Orange:Oranges:Orange:Orange:Oboe:Oboe:Ovar:Oscar:Ocean:---
            P:Papa:Pudding:Pip:Pip:Peter:Peter/Prep:Peter:Porto:Peter:Paul:.--.
            Q:Quebec:Queenie:Queen:Queen:Queen:Queen:Queen:Queluz:Quincy:Queen:--.-
            R:Romeo:Robert:Robert:Robert:Roger/Robert:Roger:Roger:Rossio:Robert:Robert:.-.
            S:Sierra:Sugar:Esses:Sugar:Sugar:Sugar:Sugar:Setúbal:Stephen:Sam:...
            T:Tango:Tommy:Toc:Toc:Tommy:Tare:Tare:Tavira:Trevor:Tom:-
            U:Uniform:Uncle:Uncle:Uncle:Uncle:Uncle:Uncle:Unidade:Ulysses:Union:..-
            V:Victor:Vinegar:Vic:Vic:Vic:Victor:Victor:Viseu:Vincent:Victor:...-
            W:Whiskey:Willie:William:William:William:William:William:Washington:William:William:.--
            X:X-ray/Xadrez:Xerxes:X-ray:X-ray:X-ray:X-ray:X-ray:Xavier:Xavier:X-ray:-..-
            Y:Yankee:Yellow:Yorker:Yorker:Yoke/Yorker:Yoke:Yoke:York:Yaakov:Young:-.--
            Z:Zulu:Zebra:Zebra:Zebra:Zebra:Zebra:Zebra:Zulmira:Zebedee:Zebra:--..";
        
        private Dictionary<char, string[]> _letras;

        private Dictionary<char, string[]> Letras
        {
            get
            {
                return _letras;
            }
        }

        public string Converter(Tipos tipo, string palavra)
        {
            StringBuilder sb = new StringBuilder();
            foreach (char letra in palavra.ToUpper())
            {
                sb.AppendLine(Letras[letra][(int)tipo]);
            }

            return sb.ToString();
        }


    }
}
