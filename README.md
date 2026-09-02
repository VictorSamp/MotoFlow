# 🏍️ MotoFlow

Web ERP system for motorcycle club management, developed as a Final Year Project (TCC).

MotoFlow centralizes member records, membership fees, internal responsibilities, and activities that would otherwise be managed through spreadsheets, messaging apps, and manual records.

---

## 🌍 Language / Idioma

- 🇧🇷 [Leia em Português](README.pt-BR.md)
- 🇺🇸 [Read in English](README.en.md)

---

## ⚙️ Tech Stack

- .NET 10 / ASP.NET Core
- C#
- Blazor Server
- ASP.NET Core Web API
- Entity Framework Core
- SQL Server
- Clean Architecture
- Docker (SQL Server environment)

---

## 🏗️ Architecture

The solution is organized into five projects:

- **MotoFlow.Domain** — entities and business rules.
- **MotoFlow.Application** — use cases, DTOs, interfaces, and application exceptions.
- **MotoFlow.Infrastructure** — Entity Framework Core, SQL Server persistence, repositories, migrations, and Unit of Work.
- **MotoFlow.Api** — REST API, Swagger, and dependency injection configuration.
- **MotoFlow.Web** — Blazor Server interface that consumes the API.

---

## 🚀 Current Status

The MVP includes member management, member progression, membership-fee management with a general overview, an overview dashboard, and a calendar for activities and member responsibilities.

For the complete and current description, see the language-specific READMEs above.
