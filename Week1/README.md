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

## 🔗 Version Control (Important)

Make sure to push your progress:

```bash
git init
git add .
git commit -m "Day 1: Project setup, architecture, and health endpoint"
git branch -M main
git remote add origin <your-repo-url>
git push -u origin main
```

👉 Going forward:

* Commit **daily**
* One feature per commit
* Clear commit messages

---

## 📌 Author

Yash Bhujbal
