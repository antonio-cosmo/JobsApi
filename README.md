# Jobs API

### Rodando localmente

Tenha instalado na sua maquina o .NET 6 e o Docker

Clone o projeto

```bash
  https://github.com/antonio-cosmo/JobsApi.git
```

Entre no diretório do projeto

```bash
  cd DevToDoList

```

Instale as dependências

```bash
  dotnet restore
```
Crie o container para o banco de dados. Na raiz do projeto execute o docker-compose

```bash
  docker-compose up
```
Inicie a aplicação

```bash
  dotnet run
```

Teste a aplicação no seu localhost: http://localhost:5159/swagger/index.html
