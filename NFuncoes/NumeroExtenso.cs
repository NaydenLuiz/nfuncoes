using System;
using System.Collections.Generic;
using System.Text;

namespace NFuncoes
{
    public class NumeroExtenso
    {

        private static readonly string[] Unidade = {"","um","dois","três","quatro","cinco","seis","sete","oito","nove","dez",
                                                    "onze","doze","treze","quatorze","quinze","dezesseis","dezessete",
                                                    "dezoito","dezenove"};

        private static readonly string[] Dezena = {"","","vinte","trinta","quarenta","cinquenta","sessenta","setenta","oitenta",
                                                    "noventa"};

        private static readonly string[] Centena = {"", "cento","duzentos","trezentos","quatrocentos","quinhentos","seiscentos",
                                                    "setecentos","oitocentos","novecentos"};

        private static readonly string[] Milhares = { "", "mil", "milhão", "bilhão", "trilhão" };

        private static readonly string[] MilharesPlural = { "", "mil", "milhões", "bilhões", "trilhões" };

        public string DescreverNumero(long numero)
        {
            List<string> descricoes = new List<string>();
            long divisor;

            for (int i = 4; i >= 0; i--)
            {
                divisor = (long)Math.Pow(1000, i);
                long resto;
                long quociente;
                quociente = Math.DivRem(numero, divisor, out resto);

                string descricao = DescreverNumeroMenorMil((int)quociente);
                if (quociente > 0)
                {
                    descricao = string.Format("{0} {1}", descricao, quociente == 1 ? Milhares[i] : MilharesPlural[i]);
                }

                descricoes.Add(descricao);
                numero = resto;
            }

            return String.Join(", ", descricoes.FindAll(PredicadoStringNaoVazia).ToArray());
        }

        private string DescreverNumeroMenorMil(int numero)
        {
            StringBuilder sb = new StringBuilder();

            int centena = numero / 100;
            int dezenaUnidade = numero % 100;
            int dezena = dezenaUnidade / 10;
            int unidade = numero % 10;
            List<string> descricoes = new List<string>();

            descricoes.Add(Centena[centena]);

            if (dezenaUnidade < 20)
            {
                descricoes.Add(String.Empty);
                descricoes.Add(Unidade[dezenaUnidade]);
            }
            else
            {
                descricoes.Add(Dezena[dezena]);
                descricoes.Add(Unidade[unidade]);
            }

            string t = String.Join(" e ", descricoes.FindAll(PredicadoStringNaoVazia).ToArray());

            return t;
        }

        private bool PredicadoStringNaoVazia(string s)
        {
            return !String.IsNullOrEmpty(s);
        }
    }
}
