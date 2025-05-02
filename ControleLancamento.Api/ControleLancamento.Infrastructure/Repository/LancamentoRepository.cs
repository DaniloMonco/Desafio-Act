using ControleLancamento.Domain.Model;
using ControleLancamento.Domain.Repository;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ControleLancamento.Infrastructure.Repository
{
    public class LancamentoRepository : ILancamentoRepository
    {
        private readonly IMongoCollection<LancamentoBase> _lancamentoCollection;
        public LancamentoRepository(MongoClient mongoClient)
        {
            var mongoDatabase = mongoClient.GetDatabase("LancamentoDatabase");
            _lancamentoCollection = mongoDatabase.GetCollection<LancamentoBase>("Lancamentos");
        }

        public async Task Salvar(LancamentoBase lancamento)
        {
            await _lancamentoCollection.InsertOneAsync(lancamento);
        }
    }
}
