using System;

namespace ProjetoLoja.Domain.Models
{
    public class Produto
    {
        public Produto() { }

        public long Id { get; private set; }
        public string Nome { get; private set; }
        public string Marca { get; private set; }
        public decimal Valor { get; private set; }
        public DateTime DataCriacao { get; private set; }
        public DateTime DataUpdate { get; private set; }

        public Produto(string nome, string marca, decimal valor,DateTime dataCriacao)
        {
            Nome = nome;
            Marca = marca;
            DataCriacao = dataCriacao;
            Valor = valor;
        }

        public void Atualizar(string nome, string marca,decimal valor, DateTime dataUpdate)
        {
            Nome = nome;
            Marca = marca;
            DataUpdate = dataUpdate;
            Valor = valor;
        }
    }
}