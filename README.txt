Para rodar o projeto é necessário alterar o arquivo \Keyworks\DataAppDbContext.cs e alterar o a string de conexão com o banco de dados no método OnConfiguring(). 
Em seguida basta basta abrir a pasta Keyworks com CMD e executar dotnet run, em seguida, será necessário criar um usuário ou efetuar login com o usuário inserido na seed inicial:
"userName": "admin",
"password": "Senhaforte456!"

Para rodar os testes, basta abrir a pasta KeyWork.test com o CMD e executar dotnet test.