using Dataplace.Imersao.Core.Domain.Excepions;
using Dataplace.Imersao.Core.Domain.Orcamentos.Enums;
using Dataplace.Imersao.Core.Domain.Orcamentos.ValueObjects;
using System;
using System.Collections.Generic;

namespace Dataplace.Imersao.Core.Domain.Orcamentos
{
    public class Orcamento
    {
        private Orcamento(string cdEmpresa, string cdFilial, int numOrcamento, OrcamentoCliente cliente, 
           UsuarioDoOrcamento usuario, OrcamentoVendedor vendedor, OrcamentoTabelaPreco tabelaPreco)
        {

            CdEmpresa = cdEmpresa;
            CdFilial = cdFilial;
            Cliente = cliente;
            NumOrcamento = numOrcamento;
            Usuario = usuario;
            Vendedor = vendedor;
            TabelaPreco = tabelaPreco;

            // default
            Situacao = OrcamentoStatusEnum.Aberto;
            DtOrcamento = DateTime.Now;
            ValotTotal = 0;
            Itens = new List<OrcamentoItem>();

        }

        public string CdEmpresa { get; private set; }
        public string CdFilial { get; private set; }
        public int NumOrcamento { get; private set; }
        public OrcamentoCliente Cliente { get; private set; }
        public DateTime DtOrcamento { get; private set; }
        public decimal ValotTotal { get; private set; }
        public OrcamentoValidade Validade { get; private set; }
        public OrcamentoTabelaPreco TabelaPreco { get; private set; }
        public DateTime? DtFechamento { get; private set; }
        public OrcamentoVendedor Vendedor { get; private set; }
        public UsuarioDoOrcamento Usuario { get; private set;}
        public OrcamentoStatusEnum Situacao { get; private set; }
        public ICollection<OrcamentoItem> Itens { get; private set; }


        public void AdicionarItens(OrcamentoItem item)
        {
           if (item == null) throw new DomainException("O item é requerido");

                    
            Itens.Add(item);
        }

        public void FecharOrcamento()
        {
            if (Situacao == OrcamentoStatusEnum.Fechado)
                throw new DomainException("Orçamento já está fechado!");

            Situacao = OrcamentoStatusEnum.Fechado;
            DtFechamento = DateTime.Now.Date;
        }

        public void ReabrirOrcamento()
        {
            if (Situacao == OrcamentoStatusEnum.Fechado)
                throw new DomainException("Orçamento já está Fechado!");

            Situacao = OrcamentoStatusEnum.Aberto;
            DtFechamento = null;
        }

        public void CancerlarOrcamento()
        {
            if (Situacao == OrcamentoStatusEnum.Fechado)
                throw new DomainException("Orçamento já fechado, não será possivel cancelar");

            Situacao = OrcamentoStatusEnum.cancelado;
            DtFechamento = null;
        }

        public void DefinirValidade(int diasValidade)
        {
            this.Validade = new OrcamentoValidade(this, diasValidade);
        }

        #region validations

        public List<string> Validations;
        public bool IsValid()

        {
            Validations = new List<string>();

            if (string.IsNullOrEmpty(CdEmpresa))
                Validations.Add("Código da empresa é requirido!");

            if (string.IsNullOrEmpty(CdFilial))
                Validations.Add("Código da filial é requirido!");

            if (string.IsNullOrEmpty(Usuario.Nome))
                Validations.Add("Usuário é requirido!");

            if (string.IsNullOrEmpty(Vendedor.Codigo))
                Validations.Add("Codigo Vendedor é requirido!");

            if (string.IsNullOrEmpty(Cliente.Codigo))
                Validations.Add("Cliente é requirido!");

            if (string.IsNullOrEmpty(TabelaPreco.CdTabela))
                Validations.Add("Tabela de preço é requirido!");

            if (NumOrcamento == null)
                Validations.Add("Numero do Orçamento é requirido!");

            if (Validations.Count > 0)
                return false;
            else
                return true;
        }

        #endregion

        #region factory methods
        public static class Factory
        {

            public static Orcamento Orcamento(string cdEmpresa, string cdFilial, int numOrcamento, OrcamentoCliente cliente , UsuarioDoOrcamento usuario, OrcamentoVendedor vendedor, OrcamentoTabelaPreco tabelaPreco)
            {
                return new Orcamento(cdEmpresa, cdFilial, numOrcamento, cliente, usuario, vendedor, tabelaPreco);
            }
            public static Orcamento OrcamentoRapido(string cdEmpresa, string cdFilial, int numOrcamento, UsuarioDoOrcamento usuario, OrcamentoVendedor vendedor, OrcamentoTabelaPreco tabelaPreco)
            {
                return new Orcamento(cdEmpresa, cdFilial, numOrcamento, null, usuario, vendedor, tabelaPreco);
            }
        }

        #endregion
    }
}
