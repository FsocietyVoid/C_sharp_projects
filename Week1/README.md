# 💸 Smart Expense Tracker API

A production-oriented FinTech backend built using ASP.NET Core, following clean architecture principles. This project is part of a structured 5-week sprint to master backend engineering, cloud readiness, and DevSecOps practices.

---

## 🚀 Week 1: Smart Expense Tracker (Day 1)

### ✅ Objective

Set up the foundational architecture for a scalable and maintainable backend system.

---

## 🧠 What Was Implemented

### 🏗️ Clean Architecture Setup

* Layered architecture:

  * **Core (Domain Layer)** → Entities, Interfaces
  * **Infrastructure (Data Layer)** → Future EF Core + Repositories
  * **API (Presentation Layer)** → Controllers, DTOs, Services

---

### 🧩 Domain Modeling

Defined core entities:

* `User`
* `Transaction`
* `Category`

With relationships:

* One User → Many Transactions
* One Category → Many Transactions

---

### 📦 Interfaces (Abstraction)

Created repository contracts:

* `IUserRepository`
* `ITransactionRepository`

👉 Ensures loose coupling and testability.

---

### 🌐 API Setup

* ASP.NET Core Web API initialized
* Cleaned default template
* Added a **Health Check Endpoint**

#### Endpoint:

```http
GET /api/health
```

#### Sample Response:

```json
{
  "status": "Smart Expense Tracker API is running 🚀"
}
```

---

### 🧪 Swagger Integration

* Swagger UI enabled for API testing
* Accessible at:

```
https://localhost:5001/swagger
```

---

### ⚙️ Engineering Practices Applied

* Dependency Injection (DI) ready
* Nullable reference handling (C# strict mode)
* Proper folder structuring
* Separation of concerns enforced

---

## 📁 Project Structure

```text
SmartExpenseTracker/
│
├── ExpenseTracker.API/
│   ├── Controllers/
│   ├── Services/
│   ├── DTOs/
│
├── ExpenseTracker.Core/
│   ├── Entities/
│   ├── Interfaces/
│
├── ExpenseTracker.Infrastructure/
│   ├── Data/
│   ├── Repositories/
```

---

## ▶️ How to Run

```bash
dotnet build
dotnet run --project ExpenseTracker.API
```

Then open:

```
https://localhost:5001/swagger
```

---

## 🎯 Day 1 Outcome

* Clean architecture established
* Domain layer defined
* API bootstrapped and running
* Swagger integrated
* Health endpoint validated

---

## ⚡ What’s Next (Day 2)

* Entity Framework Core setup
* DbContext configuration
* SQL Server integration
* Migrations and database creation

---

## 🧠 Key Learnings

* Importance of layered architecture
* Separation of concerns in backend systems
* Designing domain-first before database
* Clean API structuring

---

## 🚀 Week 1: Smart Expense Tracker (Day 2)

### ✅ Objective

Integrate a real database using Entity Framework Core and enable persistent storage for application data.

---

## 🧠 What Was Implemented

### 🗄️ Entity Framework Core Setup

- Installed EF Core packages:
  - Microsoft.EntityFrameworkCore
  - Microsoft.EntityFrameworkCore.SqlServer
  - Microsoft.EntityFrameworkCore.Tools
- Configured ORM to map C# entities → SQL tables

---

### 🧱 DbContext Implementation

Created `AppDbContext` as the central bridge between application and database.

Key configurations:

- `DbSet<User>`
- `DbSet<Transaction>`
- `DbSet<Category>`

---

### 🔗 Relationship Mapping

Defined relationships using Fluent API:

- User → Transactions (1-to-many, Cascade delete)
- Category → Transactions (1-to-many, Restrict delete)

Additional constraints:

- Unique index on `User.Email`
- Required `Category.Name` with max length

---

### ⚙️ Database Configuration

Added connection string in:

📄 `appsettings.json`

```json
"ConnectionStrings": {
  "DefaultConnection": "Server=(localdb)\\MSSQLLocalDB;Database=ExpenseTrackerDb;Trusted_Connection=True;"
}

```
Registered DbContext in Dependency Injection:
```bash
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
```

### 🧬 Migrations (Code → Database)
Generated initial schema using EF Core migrations:
```bash
dotnet ef migrations add InitialCreate \
--project ExpenseTracker.Infrastructure \
--startup-project ExpenseTracker.API
```
Applied migration to database:
```bash
dotnet ef database update \
--project ExpenseTracker.Infrastructure \
--startup-project ExpenseTracker.API
```

### 🧪 Database Verification
Verified database using Azure Data Studio / SSMS.
Expected structure:
```bash
ExpenseTrackerDb
 ├── Users
 ├── Transactions
 ├── Categories
```

### ⚙️ Engineering Practices Applied
- Code First Approach (schema from code)
- Fluent API for relationship control
- Strong typing between application and database
- Secure query generation (no raw SQL)

### 🎯 Day 2 Outcome
- Database successfully created
- Tables generated from domain entities
- Relationships enforced at DB level
- EF Core fully integrated into project

👉 Going forward:

* Commit **daily**
* One feature per commit
* Clear commit messages

---

## 📌 Author

Yash Bhujbal
