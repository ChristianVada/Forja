# 📜 Anéis CRUD API com .NET 6 e Razor Pages

Este projeto consiste em uma aplicação web que gerencia um CRUD (Create, Read, Update, Delete) de anéis, utilizando .NET 6 para o backend e Razor Pages para o frontend.

## 🎯 Objetivo

O objetivo deste projeto é fornecer APIs REST para gerenciar anéis e desenvolver uma interface de usuário para visualizar e manipular essas informações.

## ⚙️ Funcionalidades

### Backend:
1. **Criar um Anel:**
   - API para registrar um novo anel com as seguintes propriedades:
     - **Nome:** Nome do anel.
     - **Poder:** Breve descrição do poder do anel.
     - **Portador:** Nome do portador atual.
     - **ForjadoPor:** Quem forjou o anel (*Elfos, Anões, Homens, Sauron*).
     - **Imagem:** URL de uma imagem representando o anel.
   - **Validações:**
     - Máximo de 3 anéis para **Elfos**.
     - Máximo de 7 anéis para **Anões**.
     - Máximo de 9 anéis para **Homens**.
     - Apenas 1 anel para **Sauron**.

2. **Listar Anéis:**
   - Retorna uma lista de todos os anéis cadastrados.

3. **Atualizar um Anel:**
   - Permite modificar as propriedades de um anel existente.

4. **Deletar um Anel:**
   - Remove um anel pelo seu identificador.

### Frontend:

**Tela de Criação/Atualização de Anel:**
   - Formulário com os campos:
     - Nome
     - Poder
     - Portador
     - ForjadoPor
     - Imagem (opcional)
   - Botões para criar e atualizar e deletaranéis.
   - Exibe todos os anéis em um grid


## 🛠️ Tecnologias Utilizadas
- **.NET 6**
- **Razor Pages**

## 🔧 Configuração do Banco de Dados

Para criar o banco de dados, execute o seguinte comando SQL:

```sql
CREATE TABLE Aneis (
    Id INT IDENTITY(1,1) PRIMARY KEY, -- Identificador único
    Nome NVARCHAR(100) NOT NULL,      -- Nome do anel
    Poder NVARCHAR(255),              -- Breve descrição do poder
    Portador NVARCHAR(100),           -- Nome do portador atual
    ForjadoPor INT NOT NULL,          -- Forjador (Elfos=1, Anoes=2, Homens=3, Sauron=4)
    Imagem NVARCHAR(MAX)              -- URL da imagem representando o anel
);
```

## 📝 Observações

Para agilizar o desenvolvimento, não utilizei o princípio de migração.
**A criação, edição e exclusão de anéis não estão funcionando na interface, devido ao tempo que fiquei sem usar Razor Pages  e o tempo limite. No entanto, essas funcionalidades estão funcionando perfeitamente via API**.
Para trocar o banco de dados, basta modificar a string de conexão no arquivo appsettings.json em DefaultConnection:

```
json
Copiar código
{
  "ConnectionStrings": {
    "DefaultConnection": "sua-string-de-conexao-aqui"
  }
}
```

## 📝 Instruções de Uso
- Clone o repositório.
- Configure a string de conexão no arquivo appsettings.json.
- Execute o comando SQL fornecido para criar o banco de dados.
- Inicie a aplicação.
