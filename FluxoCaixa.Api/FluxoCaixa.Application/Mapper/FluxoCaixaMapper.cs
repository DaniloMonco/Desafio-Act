using FluxoCaixa.Application.Dto;
using FluxoCaixa.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluxoCaixa.Application.Mapper
{
    public static class FluxoCaixaMapper
    {
        public static FluxoCaixaDto ToDto(this Domain.Model.FluxoCaixaItem model)
            =>  new FluxoCaixaDto(model.Data, model.Debito, model.Credito, model.Saldo);
        

        public static IEnumerable<FluxoCaixaDto> ToDto(this Domain.Model.FluxoCaixa model)
            => model.Items?.Select(i => new FluxoCaixaDto(i.Data, i.Debito, i.Credito, i.Saldo));
        
    }
}
