# 🏍️ MotoFlow

Sistema ERP web para gestão de motoclubes, desenvolvido como Trabalho de Conclusão de Curso (TCC).

O MotoFlow centraliza o cadastro de membros, o acompanhamento de mensalidades e a organização de atividades e responsabilidades internas, reduzindo a dependência de planilhas, aplicativos de mensagem e registros manuais.

---

## 🎯 Objetivo

Oferecer uma plataforma centralizada para apoiar a administração de um motoclube, com foco no controle de membros, progressão, mensalidades e atividades da sede.

---

## ⚙️ Tecnologias

- .NET 10 / ASP.NET Core
- C#
- Blazor Server
- ASP.NET Core Web API
- Entity Framework Core
- SQL Server
- Clean Architecture
- Docker para o ambiente do SQL Server

---

## 🏗️ Arquitetura

A solução segue os princípios de Clean Architecture e está dividida em cinco projetos:

- **MotoFlow.Domain** — entidades e regras de negócio.
- **MotoFlow.Application** — casos de uso, DTOs, interfaces e exceções da aplicação.
- **MotoFlow.Infrastructure** — persistência com Entity Framework Core e SQL Server, repositórios, migrations e Unit of Work.
- **MotoFlow.Api** — API REST, Swagger e configuração de injeção de dependências.
- **MotoFlow.Web** — interface em Blazor Server que consome a API.

---

## ✅ Funcionalidades implementadas

### Gestão de membros

- Cadastro de membros com nome, e-mail e telefone.
- Validação de e-mail único.
- Edição de nome e telefone.
- Desativação e reativação de membros, preservando o histórico cadastrado.

### Progressão de membros

- Controle dos níveis de insígnia: Nenhuma Parte, Primeira Etapa, Segunda Etapa e Insígnia Completa.
- A progressão só pode ser alterada para membros ativos.
- O sistema não permite reduzir o nível de insígnia.

### Mensalidades

- Geração automática da primeira mensalidade ao cadastrar um membro.
- O mês de entrada é considerado um período de adaptação; a primeira mensalidade é criada para o mês seguinte, com valor inicial de R$ 30,00.
- Criação manual de mensalidades no detalhe do membro.
- Prevenção de mensalidades duplicadas para o mesmo membro e competência.
- Registro de pagamento e da respectiva data por meio da API.
- Exclusão lógica de mensalidades pendentes; mensalidades pagas não podem ser excluídas.

### Atividades e responsabilidades

- Cadastro de atividades com título, descrição, período e membros responsáveis.
- Associação de vários responsáveis a uma atividade.
- Visualização das atividades em calendário.
- Consulta de detalhes e exclusão de atividades.

### Dashboard

- Total de membros cadastrados.
- Quantidade de membros ativos e inativos.
- Distribuição dos membros por nível de insígnia.
- Lista dos membros cadastrados exibida no painel inicial.

---

## 🗃️ Modelo de dados

As principais entidades do sistema são:

- **Member**: representa o integrante do motoclube.
- **MembershipFee**: representa uma mensalidade vinculada a um membro.
- **Activity**: representa uma atividade ou responsabilidade interna.
- **ActivityMember**: representa a associação entre atividades e membros responsáveis.

Um membro pode possuir várias mensalidades. Atividades podem possuir vários responsáveis, e um membro pode participar de várias atividades.

---

## 🧪 Qualidade

O projeto possui testes unitários para regras de criação e progressão de membros, incluindo a geração automática da primeira mensalidade. A solução também é compilada como um todo antes das entregas.

---

## 🔮 Evoluções futuras

- Geração automática e recorrente de mensalidades para membros ativos.
- Página financeira geral para consulta e pagamento de mensalidades pela interface.
- Controle de mensalidades em atraso.
- Atualização de atividades pela interface.
- Filtros e pesquisas de membros e atividades.
- Atividades recorrentes, como escala semanal de limpeza.
- Indicadores financeiros e agenda de próximas atividades no dashboard.
- Autenticação, perfis de acesso e notificações.
