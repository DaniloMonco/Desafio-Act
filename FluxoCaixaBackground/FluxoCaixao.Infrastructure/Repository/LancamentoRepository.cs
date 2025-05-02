using Dapper;
using FluxoCaixa.Domain.Model;
using FluxoCaixa.Domain.Repository;
using Microsoft.Extensions.Configuration;
using System.Data.Common;

namespace FluxoCaixa.Infrastructure.Repository
{
    public class LancamentoRepository : ILancamentoRepository
    {
        private readonly DapperContext _context;

        public LancamentoRepository(DapperContext context)
        {
            _context = context;
        }

        public async Task<int> Gravar(Lancamento lancamento)
        {
            var connection = _context.CreateConnection();

            var sql = @"INSERT INTO public.""Lancamentos"" values (@Id, @DataHora, @Valor, @Descricao, @TipoLancamento)";
            var rowsAffected = await connection.ExecuteAsync(sql, new
            {
                lancamento.Id,
                lancamento.DataHora,
                lancamento.Valor,
                lancamento.Descricao,
                TipoLancamento = lancamento.TipoLancamento.ToString()
            });

            return rowsAffected;
        }

    }
}
