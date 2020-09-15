using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entities.Notifications
{
   public class Notifies
    {
        public Notifies()
        {
            Notitycoes = new List<Notifies>();
        }

        [NotMapped]
        public string NomePropiedade { get; set; }

        [NotMapped]
        public string Mensagem { get; set; }

        [NotMapped]
        public List<Notifies> Notitycoes;


        public bool ValidarPropiedadeString(string valor, string nomePropiedade)
        {
            if (string.IsNullOrWhiteSpace(valor) || string.IsNullOrWhiteSpace(nomePropiedade))
            {
                Notitycoes.Add(new Notifies
                {
                    Mensagem = "Campo Obrigatario",
                    NomePropiedade = nomePropiedade
                });
                return false;
            }

            return true; 
        }

        public bool ValidarPropiedadeInt(int valor, string nomePropiedade)
        {
            if (valor < 1 || string.IsNullOrWhiteSpace(nomePropiedade))
            {
                Notitycoes.Add(new Notifies
                {
                    Mensagem = "Valor deve ser maior que 0",
                    NomePropiedade = nomePropiedade
                });
                return false;
            }

            return true;
        }

        public bool ValidarPropiedadeDecimal(decimal valor, string nomePropiedade)
        {
            if (valor < 1 || string.IsNullOrWhiteSpace(nomePropiedade))
            {
                Notitycoes.Add(new Notifies
                {
                    Mensagem = "Valor deve ser maior que 0",
                    NomePropiedade = nomePropiedade
                });
                return false;
            }

            return true;
        }
    }
}
