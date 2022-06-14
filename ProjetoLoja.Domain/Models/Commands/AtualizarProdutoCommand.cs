using System;

namespace ProjetoLoja.Domain.Models.Commands
{
    public class AtualizarProdutoCommand
    {
        public long Id { get; set; }
        public string Nome { get; set; }
        public string Marca { get; set; }
        public decimal Valor { get; set; }
        public DateTime DataUpdate { get; set; }
    }
}