using System;
using System.Collections.Generic;
using System.Text;

namespace NFuncoes
{
    public static class Funcoes
    {
        private static Dictionary<Type, object> CacheFuncoes = new Dictionary<Type, object>();

        private static T Funcao<T>()
        { 
            object funcao;
            if (!CacheFuncoes.TryGetValue(typeof(T), out funcao))
            {
                funcao = Activator.CreateInstance<T>();
            }
            return (T)funcao;
        }
                
        public static string Alfabeto(Alfabeto.Tipos tipo, string entrada)
        {
            return Funcao<Alfabeto>().Converter(tipo, entrada);
        }

        public static string SemAcento(string entrada)
        {
            return Funcao<SemAcento>().Converter(entrada);
        }

        public static string NumeroExtenso(long numero)
        {
            return Funcao<NumeroExtenso>().DescreverNumero(numero);
        }
        
        
    }
}
