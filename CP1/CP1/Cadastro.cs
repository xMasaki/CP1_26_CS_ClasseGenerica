using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CP1
{
    /// <summary>
    /// Classe Genérica que gerencia o sistema de cadastro
    /// </summary>
    public class Cadastro<T>
    {
        /// <summary>
        /// Armazena itens cadastrados
        /// </summary>
        private Dictionary<int, T> dados = new Dictionary<int, T>();

        /// <summary>
        /// Adiciona dado cadastrado
        /// </summary>
        /// <param name="id">Id</param>
        /// <param name="item">objeto armazenado</param> 
        public bool Adicionar(int id, T item)
        {
            if (!dados.ContainsKey(id))
            {
                dados.Add(id, item);
                return true;
            }
            return false;

        }

        /// <summary>
        /// Retorna dados cadastrados
        /// </summary>
        public Dictionary<int, T> Listar()
        {
            return dados;

        }

        /// <summary>
        /// Busca item pelo Id
        /// </summary>
        /// <param name="id">Id</param>
        public T Buscar(int id)
        {

            if (dados.ContainsKey(id))
            {
                return dados[id];
            }

            return default(T);

        }

        /// <summary>
        /// Remove item pelo Id
        /// </summary>
        /// <param name="id">Id</param>
        public bool Remover(int id)
        {

            return dados.Remove(id);

        }
    }
}
