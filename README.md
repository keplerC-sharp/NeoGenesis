# Dinosaur Registration System - NeoGenesis Park

## 1. General Description

The NeoGenesis Park system is designed to register, manage, and monitor dinosaurs created through genetic engineering within the park.

Each dinosaur has a unique identity that allows tracking, study, and control.

---

## 2. System Objectives

- Register dinosaurs with required basic information
- Provide advanced query capabilities using LINQ
- Manage updates and deletion of records
- Ensure data integrity through validations
- Implement persistence using Entity Framework Core

---

## 3. System Architecture

The system follows a layered architecture:

- Entity Layer → Represents data (Dinosaur)
- Data Access Layer → (DbContext, Repository)
- Business Logic Layer → (Service)
- Query Layer → (QueryService)
- Validation Layer → (Validator)

---

## 4. Class Diagram Description

### 4.1 Class: Dinosaur

Represents the main entity of the system.

Attributes:
- Id: int
- FirstName: string (Assigned name)
- LastName: string (Species)
- Username: string (Unique identifier)
- Email: string (Registration code)
- Password: string
- Edad: int
- Tipo: string (Carnivore / Herbivore)
- Zona: string
- Sector: string
- Direccion: string
- Telefono: string
- FechaCreacion: DateTime

Methods:
- NombreCompleto(): string

---

### 4.2 Class: NeoGenesisContext

Database context using Entity Framework Core.

Properties:
- Dinosaurios: DbSet<Dinosaur>

Methods:
- OnModelCreating()

Responsibilities:
- Configure entities
- Define unique constraints (Username, Email)

---

### 4.3 Class: DinosaurRepository

Handles data access operations (CRUD).

Methods:
- GetAll()
- GetById(int id)
- GetByEmail(string email)
- Add(Dinosaur dino)
- Update(Dinosaur dino)
- Delete(int id)

---

### 4.4 Class: DinosaurService

Contains business logic.

Methods:
- Register(Dinosaur dino)
- Update(Dinosaur dino)
- DeleteById(int id)
- DeleteByEmail(string email)
- ChangePassword(int id, string password)

Responsibilities:
- Validate rules before persisting data
- Provide confirmation messages

---

### 4.5 Class: DinosaurQueryService

Implements advanced queries using LINQ.

Methods:
- GetAll()
- GetByZone(string zone)
- GetBySector(string sector)
- GetByMinimumAge(int age)
- GetByType(string type)
- GetWithoutTrackingDevice()
- GetWithoutLocation()
- GetRecentlyAdded()
- OrderBySpecies()
- GetNameAndEmail()
- CountAll()
- CountByZone()
- CountBySector()

---

### 4.6 Class: DinosaurValidator

Responsible for system validations.

Methods:
- ValidateFields(Dinosaur dino)
- ValidateEmail(string email)
- ValidateAge(int age)

Rules:
- Required fields must not be empty
- Email must have a valid format
- Age must be greater than or equal to 0
- Username must be unique
- Email must be unique

---

## 5. Relationships Between Classes

- NeoGenesisContext contains Dinosaur entities
- DinosaurRepository uses NeoGenesisContext
- DinosaurService uses Repository and Validator
- DinosaurQueryService uses NeoGenesisContext

---

## 6. System Functionalities

### 6.1 Insertion
- Register new dinosaurs
- Validate uniqueness of Username and Email
- Confirm successful creation

### 6.2 Update
- Modify dinosaur data
- Update password with confirmation

### 6.3 Deletion
- Delete by Id or Email
- Require confirmation before deletion

### 6.4 Queries (LINQ)

Basic:
- List all dinosaurs
- Filter by zone or sector
- Filter by age or type

Projections:
- Full name and email

Sorting:
- By creation date
- Alphabetically

Grouping:
- Count by zone
- Count by sector

Advanced Filters:
- Dinosaurs without tracking device
- Dinosaurs without location
- Recently registered dinosaurs

---

## 7. Technical Requirements

- Language: C#
- ORM: Entity Framework Core
- Database: SQL Server or similar

---

## 8. Migrations (EF Core)

```bash
Add-Migration InitialCreate
Update-Database
