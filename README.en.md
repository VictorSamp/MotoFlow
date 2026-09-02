# 🏍️ MotoFlow

Web ERP system for motorcycle club management, developed as a Final Year Project (TCC).

MotoFlow centralizes member records, membership-fee tracking, and internal activities and responsibilities, reducing the use of spreadsheets, messaging applications, and manual records.

---

## 🎯 Purpose

Provide a centralized platform to support motorcycle club administration, focusing on member management, progression, membership fees, and club-house activities.

---

## ⚙️ Tech Stack

- .NET 10 / ASP.NET Core
- C#
- Blazor Server
- ASP.NET Core Web API
- Entity Framework Core
- SQL Server
- Clean Architecture
- Docker for the SQL Server environment

---

## 🏗️ Architecture

The solution follows Clean Architecture principles and is organized into five projects:

- **MotoFlow.Domain** — entities and business rules.
- **MotoFlow.Application** — use cases, DTOs, interfaces, and application exceptions.
- **MotoFlow.Infrastructure** — Entity Framework Core and SQL Server persistence, repositories, migrations, and Unit of Work.
- **MotoFlow.Api** — REST API, Swagger, and dependency injection configuration.
- **MotoFlow.Web** — Blazor Server interface that consumes the API.

---

## ✅ Implemented Features

### Member Management

- Create members with name, email, and phone number.
- Unique-email validation.
- Update name and phone number.
- Deactivate and reactivate members while preserving their records.

### Member Progression

- Patch-level tracking: No Patch, First Patch, Second Patch, and Full Patch.
- Patch level can only be updated for active members.
- Patch-level downgrades are not allowed.

### Membership Fees

- Automatic creation of the first membership fee when a member is registered.
- The joining month is considered an adaptation period; the first fee is created for the following month, with an initial value of BRL 30.00.
- Manual creation of membership fees from the member details page.
- Prevention of duplicate fees for the same member and reference period.
- Payment registration and payment-date tracking through the API.
- Soft deletion of pending fees; paid fees cannot be deleted.

### Activities and Responsibilities

- Create activities with title, description, period, and assigned members.
- Assign multiple responsible members to an activity.
- Calendar view for activities.
- Activity details and deletion.

### Dashboard

- Total registered members.
- Active and inactive member counts.
- Member distribution by patch level.
- Registered-member list on the initial dashboard.

---

## 🗃️ Data Model

The main system entities are:

- **Member**: represents a motorcycle club member.
- **MembershipFee**: represents a membership fee linked to a member.
- **Activity**: represents an internal activity or responsibility.
- **ActivityMember**: represents the association between activities and responsible members.

A member can have multiple membership fees. Activities can have multiple assigned members, and each member can participate in multiple activities.

---

## 🧪 Quality

The project includes unit tests for member-creation and progression rules, including automatic first-fee generation. The complete solution is also built before deliveries.

---

## 🔮 Future Improvements

- Automated recurring monthly-fee generation for active members.
- General financial page for fee review and payment through the interface.
- Overdue-fee tracking.
- Activity updates through the interface.
- Member and activity search and filters.
- Recurring activities, such as a weekly cleaning schedule.
- Financial indicators and upcoming activities on the dashboard.
- Authentication, access roles, and notifications.
