using Dataplace.Imersao.Core.Domain.Orcamentos.Enums;
using Dataplace.Imersao.Core.Domain.Orcamentos.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Dataplace.Imersao.Core.Domain.Orcamentos
{
    public class OrcamentoItem
    {

        public OrcamentoItem(string cdEmpresa, string cdFilial, int numOrcamento, OrcamentoProduto produto, decimal quantidade, OrcamentoItemPreco preco)
        {
            CdEmpresa = cdEmpresa;
            CdFilial = cdFilial;
            NumOrcamento = numOrcamento;
            Produto = produto;
            Quantidade = quantidade;
            AtrubuirPreco(preco);

        }
        public OrcamentoItemPreco Preco { get; private set; }
        public int Seq { get; private set; }
        public string CdEmpresa { get; private set; }
        public string CdFilial { get; private set; }
        public int NumOrcamento { get; private set; }
        public OrcamentoProduto Produto { get; private set; }
        public decimal Quantidade { get; private set; }
        public decimal PrecoTabela { get; private set; }
        public decimal PercAltPreco { get; private set; }
        public decimal PrecoVenda { get; private set; }
        public decimal Total { get; private set; }
        public OrcamentoItemStatusEnum OrcamentoItemStatusEnum { get; private set; }
        //public string Situacao { get; private set; }



        #region setters
        private void AtrubuirPreco(OrcamentoItemPreco preco)
        {
            PrecoTabela = preco.PrecoTabela;
            PrecoVenda = preco.PrecoVenda;
            PercAltPreco = preco.PercAltPreco;
            CalcularTotal();
        }

        private void CalcularTotal()
        {
            if (Quantidade < 0)
                throw new ArgumentOutOfRangeException(nameof(Quantidade));

            if (PrecoVenda < 0)
                new ArgumentOutOfRangeException(nameof(PrecoVenda));

            Total = Quantidade * PrecoVenda;
        }
        #endregion

        public List<string> Validations;

        public bool IsValid()
        
        {
            Validations = new List<string>();
            
            if (string.IsNullOrEmpty(CdEmpresa))
                Validations.Add("Código da empresa é requirido!");

            if (string.IsNullOrEmpty(CdFilial))
                Validations.Add("Código da filial é requirido!");

            if (Validations.Count > 0)
                return false;
            else
                return true;

        }


    }
}
