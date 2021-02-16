# Api Produtos

Uma api simples data driven que retorna os dados de produtos.


# Coisas que serao vistas

[ ] Autenticacao com  JWT
[ ] Compressao
[ ] Versionamento
[ ] EF Core 3

# Notas
Self-Hosting (Auto hospedada)
Essa aplicação se auto gerencia ela ja consegue receber, manipular requisições não precisa da intervenção do IIS

Data Driven  (Um espelho do banco de dados)
Read https://homepage.cs.uri.edu/~thenry/resources/unix_art/ch09s01.html

Data Annotation -> Ajuda a gerar os schema e também na validação do que vem para a controller.

Controller => Manipulam as requisições
Endpoint => URL

DataContext => Representação do banco de dados em memória, permite fazer o mapeamento da nossa aplicação em relação ao banco

DbSet => Representa uma tabela no banco

DI -  is a technique in which an object receives other objects that it depends on. These other objects are called dependencies. In the typical "using" relationship the receiving object is called a client and the passed object is called a service

AddTransiente - Transient objects are always different; a new instance is provided to every controller and every service.

AddScoped - Scoped objects are the same within a request, but different across different requests

AddSingleton  - Singleton objects are the same for every object and every request (regardless of whether an instance is provided in ConfigureServices)

EF Core - ORM
Command
dotnet add package Microsoft.EntityFrameworkCore.InMemory;
dotnet add package Microsoft.EntityFrameworkCore.SqlServer;
dotnet tool install --global dotnet-ef //Install Ef Core tool para executar migrations
dotnet add package Microsoft.EntityFrameworkCore.Design //adicionar para gerar as migrations

