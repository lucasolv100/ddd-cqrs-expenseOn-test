# ddd-cqrs-expenseOn-test

1 - Acertar a connection string no appsettings para um banco de dados SQL Server local;
2 - Rodar o comando Update-Database para atualização da base de dados via package manager console no visual studio ou rodar o seguinte comando: 
> cd .\Hotel.Data && dotnet ef --startup-project ..\Hotel.API\Hotel.API.csproj --project .\Hotel.Data.csproj database update

No diretório HotelContext.

3 - Utilizar os métodos postman abaixo para teste da aplicação;
POSTMAN para testes: https://www.getpostman.com/collections/3a3fb1e975fb2f9c49f8

4 - Ir até a pasta "front-end" em src e rodar o comando:
> npm i

5 - Após o comando executado, rodar o seguinte comando para subir o front-end local: 
> npm start

6 - Após o front-end up subir a API em "src > HotelContext > Hotel.API" execute o seguinte comando:
> dotnet run

7 - Com o back-end up é só executar os testes via front-end (leia o sobre).
