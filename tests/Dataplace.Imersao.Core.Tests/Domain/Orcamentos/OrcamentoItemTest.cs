using Dataplace.Imersao.Core.Tests.Fixtures;
using Xunit;

namespace Dataplace.Imersao.Core.Tests.Domain.Orcamentos
{
    [Collection(nameof(OrcamentoCollection))]
    public class OrcamentoItemTest
    {
        private readonly OrcamentoItemFixture _fixtureItem;
        public OrcamentoItemTest(OrcamentoItemFixture fixtureItem)
        {
            _fixtureItem = fixtureItem;
        }

        [Fact]
        public void AdicionarItensNoOrcamento()
        {
            // Arrange Act
            var item = _fixtureItem.orcamentoItem();


            //Assert
            Assert.True(item.CdEmpresa == _fixtureItem.CdEmpresa);
            Assert.True(item.CdFilial == _fixtureItem.CdFilial);
            Assert.Equal(_fixtureItem.NumOrcamento, item.NumOrcamento);
            Assert.Equal(_fixtureItem.Preco.PrecoVenda, item.PrecoVenda);
            Assert.Equal(_fixtureItem.Preco.PrecoTabela, item.PrecoTabela);
            Assert.True(item.Quantidade == _fixtureItem.Quantidade);
            Assert.Equal(_fixtureItem.Produto.CdProduto, item.Produto.CdProduto);
           
            
        }
    }
}
