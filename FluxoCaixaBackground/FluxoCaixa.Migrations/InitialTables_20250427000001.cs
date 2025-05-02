using FluentMigrator;

namespace FluxoCaixa.Migrations
{
    [Migration(20250427000001)]
    public class InitialTables_20250427000001 : Migration
    {
        public override void Down()
        {
            Delete.Table("Lancamentos");
        }

        public override void Up()
        {

            Create.Table("Lancamentos")
                .WithColumn("Id").AsGuid().NotNullable().PrimaryKey()
                .WithColumn("DataHora").AsDateTime().Nullable()
                .WithColumn("Valor").AsDecimal().NotNullable()
                .WithColumn("Descricao").AsString(250).NotNullable()
                .WithColumn("TipoLancamento").AsString().NotNullable();
        }
    }
}
