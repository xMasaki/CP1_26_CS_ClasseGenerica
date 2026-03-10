using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CP1
{
    /// <summary>
    /// Classe que representa Pessoa no sistema
    /// </summary>
    public class Pessoa
    {
        public string nome { get; set; }
        public int Idade { get; set; }

        /// <summary>
        /// Construtor da classe Pessoa
        /// </summary>
        /// <param name="nome">nome</param>
        /// <param name="idade">idade</param>
        public Pessoa(string nome, int idade)
        {
            this.nome = nome;
            Idade = idade;
        }

        /// <summary>
        /// Mostra dados no console
        /// </summary>
        public void Exibir()
        {
            Console.WriteLine($"Nome: {this.nome}, Idade: {Idade}");
        }

        /// <summary>
        /// Retorna dados do objeto Pessoa
        /// </summary>
        public override string ToString()
        {
            return $"Nome: {nome}, Idade: {Idade}";
        }
    }
}
