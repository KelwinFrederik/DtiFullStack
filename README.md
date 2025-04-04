# 📌 FullStackApp

Este projeto é uma aplicação FullStack que utiliza **.NET 6** no backend e **Angular** no frontend, implementando CQRS com Event Sourcing e um sistema de notificações por meio de arquivos `.txt` simulando e-mails.

---

## 🛠 Requisitos

### 🔧 **Backend (.NET 6 API)**
- .NET 6 SDK ([Download](https://dotnet.microsoft.com/download))
- SQL Server
- Visual Studio ou VS Code

### 🌐 **Frontend (Angular)**
- Node.js ([Download](https://nodejs.org/))
- Angular CLI (`npm install -g @angular/cli`)
- VS Code ou qualquer editor de sua preferência

---

## 🚀 Como Executar

### 📌 **1. Configurar o Banco de Dados**
- Rodar o script SQL disponível (`CREATE_DATABASE_TABLES_INITIAL`) no **SQL Server**.
- Isso criará o banco, tabelas e registros iniciais.

### 🔄 **2. Backend (.NET 6 API)**
```bash
# Clonar o repositório
git clone https://github.com/seu-usuario/FullStackApp.git

# Restaurar pacotes, após estar no diretorio da solution
dotnet restore

# Configurar o arquivo appsettings.json (conexão com o SQL Server)
# Rodar a aplicação
dotnet run
```
> A API estará disponível em `https://localhost:7038/api`.

### 🖥 **3. Frontend (Angular)**
```bash
# Instalar dependências, após estar no diretorio.
npm install

# Rodar o projeto
ng serve -o
```
> O frontend estará acessível em `http://localhost:4200/`.

---

## 📡 **Endpoints da API**
### 🔹 **Ordens de Serviço**
- `GET /api/orders?status={status}` → Obter ordens por status (Pendente, Aceito)
- `PUT /api/orders/status` → Alterar status da ordem

> **Nota:** Se a ordem for aceita e o valor for maior que R$500, um **desconto de 10%** é aplicado automaticamente.

---

## 📬 **Simulação de E-mail**
Ao aceitar uma ordem, ao invés de um e-mail real, um arquivo `.txt` será criado na pasta `EmailsSimulados` dentro do diretório da aplicação backend.

📂 **Exemplo:** `/EmailsSimulados/Email_Order_123.txt`
```
To: cliente@email.com
From: no-reply@fullstackapp.com
Subject: 🚀 Sua ordem foi aceita!
--------------------------------------------------
Olá João Silva,
Sua ordem #123 foi **ACEITA** com sucesso.
📅 Data Criação: 2024-04-03 14:30
📍 Bairro: Centro
📦 Categoria: Manutenção
💰 Valor: R$ 450,00
✉️ Descrição: Reparação de ar-condicionado.
--------------------------------------------------
Atenciosamente,
🚀 FullStackApp Team
```

---

## 🎨 **Interface Angular**
A aplicação web contém **duas abas**:
1. **Invited** → Mostra ordens pendentes, com botões de "Aceitar" e "Recusar".
2. **Accepted** → Lista ordens aceitas com informações detalhadas.

✅ **Aceitar**: Atualiza o status, aplica desconto (se aplicável) e gera um arquivo `.txt`.
❌ **Recusar**: Apenas altera o status para "Recusado".


