 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace AgencyManager.Models
{
    public class Agency(string numero, string nome, string telefone, string descricao, string endereco)
    {
        public int Id { get; set; }
        public string Numero { get; set; } = numero;
        public string Nome { get; set; } = nome;
        public string Telefone { get; set; } = telefone;
        public string Descricao { get; set; } = descricao;
        public string Endereco { get; set; } = endereco;
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public override string ToString()
            => $"{Numero} - {Nome}".Trim();
    }
}
