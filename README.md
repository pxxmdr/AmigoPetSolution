AmigoPet API 🐾
========================
API RESTful para gerenciamento de cuidados com pets, desenvolvida em .NET 9, utilizando Entity Framework Core com banco de dados Oracle.

✅ Funcionalidades
========================

CRUD de Pets

CRUD de Cuidados (CareReminders)

CRUD de Itens de Checklist (ItemChecklists)

Integração com Banco de Dados Oracle

Documentação via Swagger

📌 Endpoints Principais
========================

📚 Pets

GET /api/Pets — Retorna todos os pets

GET /api/Pets/{id} — Retorna um pet específico

POST /api/Pets — Adiciona um novo pet

{
  "nome": "Rex",
  "tipo": "Cachorro",
  "raca": "Labrador",
  "dataNascimento": "2020-05-10T00:00:00"
}

PUT /api/Pets/{id} — Atualiza um pet existente

DELETE /api/Pets/{id} — Remove um pet

📅 Cuidados (CareReminders)

GET /api/CareReminders

GET /api/CareReminders/{id} — Retorna um cuidado específico

POST /api/CareReminders

{
  "petId": 1,
  "tipo": "Vacinação",
  "dataAgendada": "2025-05-20T00:00:00",
  "concluido": false
}

PUT /api/CareReminders/{id} — Atualiza um cuidado existente

DELETE /api/CareReminders/{id} — Remove um cuidado

📋 Checklist de Itens (ItemChecklists)

GET /api/ItemChecklists

GET /api/ItemChecklists/{id} — Retorna um item específico

POST /api/ItemChecklists

{
  "petId": 1,
  "nomeItem": "Coleira Nova",
  "comprado": false
}

PUT /api/ItemChecklists/{id} — Atualiza um item existente

DELETE /api/ItemChecklists/{id} — Remove um item

🚀 Como Executar
========================

Clone o repositório: git clone https://github.com/pxxmdr/AmigoPetSolution.git

Configure a conexão com o banco Oracle no arquivo appsettings.json: "ConnectionStrings": {
  "OracleConnection": "User Id=SEU_USUARIO;Password=SUA_SENHA;Data Source=SEU_SERVIDOR"
}

Execute a aplicação no Visual Studio (F5) e acesse a documentação Swagger:https://localhost:7065/swagger/index.html






