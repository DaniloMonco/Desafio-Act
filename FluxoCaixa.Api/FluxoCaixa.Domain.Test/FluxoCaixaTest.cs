using FluxoCaixa.Domain.Model;

namespace FluxoCaixa.Domain.Test
{
    public class FluxoCaixaTest
    {
        private const int _ano = 2024;
        private const int _mes = 8;
        private const int _dia10 = 10;
        private const int _dia11 = 11;

        [Fact]
        public void Montar_FluxoCaixa_Com_Lancamentos()
        {
            var dataHora10 = new DateTime(_ano, _mes, _dia10);
            var dataHora11 = new DateTime(_ano, _mes, _dia11);
            var lancamentos = new List<Lancamento>
            {
                new Lancamento(Guid.NewGuid(), dataHora10, 10, "Debito 1", TipoLancamento.D),
                new Lancamento(Guid.NewGuid(), dataHora10, 20, "Debito 2", TipoLancamento.D),
                new Lancamento(Guid.NewGuid(), dataHora10, 20, "Credito 1", TipoLancamento.C),
                new Lancamento(Guid.NewGuid(), dataHora11, 100, "Credito 2", TipoLancamento.C),
                new Lancamento(Guid.NewGuid(), dataHora11, 50, "Debito 3", TipoLancamento.D),
            };

            var fluxoCaixa = Model.FluxoCaixa.Criar(_ano, _mes);
            fluxoCaixa.MontarFluxoCaixa(lancamentos);

            Assert.Equal(_ano, fluxoCaixa.Ano);
            Assert.Equal(_mes, fluxoCaixa.Mes);
            Assert.Equal(40, fluxoCaixa.Saldo);
            Assert.Equal(2, fluxoCaixa.Items.Count);
            Assert.Equal(new DateOnly(_ano, _mes, _dia10), fluxoCaixa.Items[0].Data);
            Assert.Equal(30, fluxoCaixa.Items[0].Debito);
            Assert.Equal(20, fluxoCaixa.Items[0].Credito);
            Assert.Equal(-10, fluxoCaixa.Items[0].Saldo);
            Assert.Equal(new DateOnly(_ano, _mes, _dia11), fluxoCaixa.Items[1].Data);
            Assert.Equal(50, fluxoCaixa.Items[1].Debito);
            Assert.Equal(100, fluxoCaixa.Items[1].Credito);
            Assert.Equal(50, fluxoCaixa.Items[1].Saldo);
        }
    }
}