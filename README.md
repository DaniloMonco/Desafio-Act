
# Instruções

Na raiz do projeto existe um arquivo docker compose com todos os componentes necessários. Será necessário rodar o docker compose, configurar o RabbitMQ e database no Postgresql, e possívelmente criar um certificado local para rodar as APIs (pois tive problemas localmente com isso).

### Criação de certificado localmente
Como comentado, tive problemas de certificado ao rodar localmente as apis no docker em linux, repasso aqui os comando utilizados para resolver esse problema e seguir com o setup.
Executar no powershell 

    dotnet dev-certs https -ep "$env:USERPROFILE\.aspnet\https\fluxocaixa-api.pfx"  -p ABC123teste

E logo após,

    dotnet dev-certs https --trust
Caso não esteja rodando o docker em linux, segue abaixo documentação para container rodando no Windows.
https://learn.microsoft.com/en-us/aspnet/core/security/docker-compose-https?view=aspnetcore-9.0

Após essa etapa finaliza, vamos executar o docker compose da seguinte forma:
Acessar a pasta raiz do projeto via powershell, exemplo cd: `C:\github\Act-Desafio`
e executar
`docker compose up`

Após finalização da criação de todas as dependências, acessar:
 
### RabbitMQ
O management pelo endereço http://localhost:15672/#/  onde usuário e senha é **guest**
Criar a fila ****lancamento.efetuado.queue**** do tipo *Durability = Durable*

Criar a exchange **lancamento.efetuado** do *Type = fanout* and *Durability = Durable*
Entrar no lancamento.efetuado e na area **Add binding from this exchange**, informar **To queue = lancamento.efetuado.queue** e clicar em **Bind**

### PostgreSQL
Acessar o PostgreSQL com o management de sua preferencia. O usuário para acessar o postgresql é **postgres** e a senha é **ABC123teste**. Necessário criar o banco de dados chamado **fluxo-caixa**.
Nenhuma tabela é necessária, pois existe uma migração no projeto FluxoCaixaBackground responsável pela criação da tabela.

### Docker Desktop
Acessar o Docker Desktop, verificar se alguma API ou Background não esta rodando devido a falta de configurações, e iniciar o container com as configurações efetuadas.

ControleLancamento.API esta localizado: https://localhost:5091/swagger/index.html
FluxoCaixa.Api esta localizado: http://localhost:5080/swagger/index.html

## Ambiente de Desenvolvimento
Abaixo segue uma breve descrição das três soluções criadas para resolver o teste. Foi utilizado .Net 9, linguagem C# e Visual Studio 2022 como ferramenta de desenvolvimento


**ControleLancamento.Api** 
>API responsável pela entrada de lançamentos (débitos e créditos). Utiliza Rabbitmq para envio dos eventos e MongoDB como base de dados para armazenar os eventos.

**FluxoCaixaBackground**
>Serviço batch responsável por ler as filas do RabbitMQ (ou seja, ler os eventos gerados pelo ControleLancamento.Api), traduzir esses eventos em um modelo e inserir no banco de dados PostgreSQL que será utilizado para geração dos relatórios.

**FluxoCaixa.Api**
>API responsável por exibir o fluxo de caixa de acordo com a solicitação. Essa Api utiliza Redis para sistema de cache e lê os dados do PostgreSQL para geração dos relatórios.
