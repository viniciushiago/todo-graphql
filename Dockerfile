# Utilize a imagem oficial do SDK do .NET 6 para construir o aplicativo
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /app

# Copie os arquivos do projeto para o contêiner
COPY . .

# Restaurar dependências e compilar o aplicativo
RUN dotnet restore
RUN dotnet publish -c Release -o out

# Utilize a imagem oficial do ASP.NET Core Runtime para executar o aplicativo
FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS runtime
WORKDIR /app

# Copie os arquivos publicados do estágio de compilação para o contêiner
COPY --from=build /app/out .

# Exponha a porta em que a aplicação vai rodar
EXPOSE 7212

# Defina a variável de ambiente ASPNETCORE_ENVIRONMENT
ENV ASPNETCORE_ENVIRONMENT Production

# Comando para executar a aplicação quando o contêiner for iniciado
ENTRYPOINT ["dotnet", "todo-graphql.dll"]
