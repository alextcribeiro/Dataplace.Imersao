using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dataplace.Imersao.Core.Domain.Orcamentos.ValueObjects
{
    public class UsuarioDoOrcamento
    {
        public UsuarioDoOrcamento(string nome)
        {
            Nome = nome;
        }
        public string Nome { get; private set; }
    }
}
