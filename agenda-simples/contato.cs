using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace agenda_simples
{
    internal class contato
    {
        private string primeiroNome;
        private string sobrenome;
        private string telefone;

        public string PrimeiroNome
        { 
            get { return primeiroNome; } 
            set { primeiroNome = value; } 
        }

        public string Sobrenome
        {
            get { return sobrenome; }
            set { sobrenome = value; }
        }

        public string Telefone
        {
            get { return telefone; }
            set {
                if(value.Length == 11)
                {
                    telefone = value;
                } else
                {
                    telefone = "00-00000-0000";
                }
            }
        }

        public contato()
        {
            PrimeiroNome = "João";
            Sobrenome = "Da Silva";
            Telefone = "11988888776";
        }

        public contato(string primeiroNome, string sobrenome, string telefone)
        {
            PrimeiroNome = primeiroNome;
            Sobrenome = sobrenome;
            Telefone = telefone;
        }
        public override string ToString()
        {
            string saida = String.Empty;
            saida += String.Format("{0}, {1}", PrimeiroNome, Sobrenome);
            saida += String.Format("{0}-{1}-{2}", Telefone.Substring(0,1), Telefone.Substring(2,6), Telefone.Substring(7,10));
        }
    }
}
