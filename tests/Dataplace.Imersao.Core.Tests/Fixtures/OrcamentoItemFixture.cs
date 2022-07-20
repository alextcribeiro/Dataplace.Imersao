using Dataplace.Imersao.Core.Domain.Orcamentos;
using Dataplace.Imersao.Core.Domain.Orcamentos.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dataplace.Imersao.Core.Tests.Fixtures
{
    public class OrcamentoItemFixture
    {

        internal string CdEmpresa = "IMS";
        internal string CdFilial = "01";
        internal int numOrcamento = 100;
        internal OrcamentoProduto Produto = new OrcamentoProduto(Core.Domain.Orcamentos.Enums.TpRegistroEnum.ProdutoFinal,"10");
        internal decimal Quantidade = 10;
        internal int NumOrcamento = 1000;
        internal OrcamentoItemPrecoTotal Preco = new OrcamentoItemPrecoTotal(10, 15);

        public OrcamentoItem orcamentoItem()
        {
            return OrcamentoItem.Factory.AdicionarItens(
            CdEmpresa,
            CdFilial,
            NumOrcamento,
            Produto,
            Quantidade,
            Preco);



        }
    }
}
