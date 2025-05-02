using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluxoCaixa.Application.Dto
{
    public record FluxoCaixaDto(DateOnly Data, decimal Debito, decimal Credito, decimal Saldo);
}
