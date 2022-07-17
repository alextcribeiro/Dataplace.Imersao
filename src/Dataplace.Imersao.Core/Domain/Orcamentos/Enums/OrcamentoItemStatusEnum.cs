using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dataplace.Imersao.Core.Domain.Orcamentos.Enums
{

    //Criar o Enum para propriedade OrcamentoItem.Situacao  
    //    “OrcamentoItemStatusEnum” com as mesmas opções do Enum OrcamentoStatusEnum
    
        public enum OrcamentoItemStatusEnum
        {
            Aberto,
            Fechado,
            cancelado
        }



        public static class OrcamentoItemStatusEnumExtencios
        {
            public static string ToDataValue(this OrcamentoItemStatusEnum value)
            {
                return value == OrcamentoItemStatusEnum.Fechado ? "F" : "P";

            }
            public static OrcamentoItemStatusEnum To(this string value)
            {
                if (string.IsNullOrEmpty(value))
                    return OrcamentoItemStatusEnum.Aberto;

                if (value == "P")
                    return OrcamentoItemStatusEnum.Fechado;
                else
                    return OrcamentoItemStatusEnum.Aberto;

            }
        }

    }

