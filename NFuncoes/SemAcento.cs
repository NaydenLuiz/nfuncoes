using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace NFuncoes
{
    public class SemAcento
    {

        public SemAcento()
        {
            _mapaCaracteres = new Dictionary<char, string>();
            List<string> caracteres = new List<string>();

            foreach (string linha in Dados.Split(new string[] { "\r\n", "\n" }, StringSplitOptions.RemoveEmptyEntries))
            {
                string[] split = linha.Trim().Split(':');
                foreach (char c in split[0])
                {
                    _mapaCaracteres.Add(c, split[1]);
                    caracteres.Add(new string(c, 1));
                }
            }

            _regexReplacePattern = String.Join("|", caracteres.ToArray());
        }

        private static readonly string Dados = @"
            éèëêğ:e
            ÉÈËÊ:E
            ÀÁÂÃÄÅ:A
            àáâãäå:a
            ÙÚÛÜ:U
            ùúûüµ:u
            òóôõöø:o
            ÒÓÔÕÖØ:O
            ìíîï:i
            ÌÍÎÏ:I
            š:s
            Š:S
            ñ:n
            Ñ:N
            ç:c
            Ç:C
            ÿ:y
            Ÿ:Y
            :z
            :Z
            Ğ:D
            œ:oe
            Œ:Oe";


        private Dictionary<char, string> _mapaCaracteres;
        private string _regexReplacePattern;

        private string RegexReplacePattern
        {
            get
            {
                return _regexReplacePattern;
            }
        }

        private Dictionary<char, string> MapaCaracteres
        {
            get
            {
                return _mapaCaracteres;
            }
        }

        public string Converter(string palavra)
        {
            return Regex.Replace(palavra, RegexReplacePattern, Evaluator);
        }

        private string Evaluator(Match m)
        {
            return MapaCaracteres[m.Value[0]];
        }





    }
}
