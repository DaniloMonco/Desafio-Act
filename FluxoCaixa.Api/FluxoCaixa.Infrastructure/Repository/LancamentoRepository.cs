using Dapper;
using FluxoCaixa.Domain.Model;
using FluxoCaixa.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace FluxoCaixa.Infrastructure.Repository
{
    public class LancamentoRepository : ILancamentoRepository
    {
        public readonly DapperContext _context;
        public LancamentoRepository(DapperContext context)
        {
            _context = context;
        }

        public Task<IEnumerable<Lancamento>> RecuperarLancamentos(int ano, int mes, int dia)
        {
            var sql = @"select * from public.""Lancamentos"" 
                        where extract('YEAR' from ""DataHora"") = @ano
                        and extract('MONTH' from ""DataHora"") = @mes
                        and extract('DAY' from ""DataHora"") = @dia";
            var connection = _context.CreateConnection();
            return connection.QueryAsync<Lancamento>(sql, new { ano, mes, dia });
        }

        public Task<IEnumerable<Lancamento>> RecuperarLancamentos(int ano, int mes)
        {
            var sql = @"select * from public.""Lancamentos"" 
                        where extract('YEAR' from ""DataHora"") = @ano
                        and extract('MONTH' from ""DataHora"") = @mes";
            var connection = _context.CreateConnection();
            return connection.QueryAsync<Lancamento>(sql, new { ano, mes});
        }
    }
}
