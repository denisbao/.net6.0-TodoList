# TodoList

### Descrição
<p>API de uma lista de tarefas simples utilizando ASP.NET6, SQLite e Entity Framework.</p>

### Features
- [x] Cadastro de tarefas
- [x] Listagem de tarefas
- [x] Atualização de tarefas
- [x] Remoção de tarefas

### Requisitos
EF Tools: 
``` 
dotnet tool install --global dotnet-ef 
```
EF Sqlite: 
``` 
add package Microsoft.EntityFrameworkCore.Sqlite --version 6.0.1
```
EF Design: 
``` 
add package Microsoft.EntityFrameworkCore.Design --version 6.0.1
```

### Exemplo: JSON de uma tarefa
```
{
    "id": 5,
    "title": "testar api",
    "done": true,
    "createdAt": "2022-01-26T08:00:00"
}
```
