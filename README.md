# StudentsApp - ASP.NET Core MVC (.NET 8)

A web application built with **ASP.NET Core MVC (.NET 8)** to manage students with full **CRUD operations** and **validation**, using **Entity Framework Core (Code First)** with SQL Server LocalDB and Bootstrap.

---

## 🚀 Features

1. **Student Management (CRUD)**:
   - **Index**: View all students in a responsive table with Edit and Delete actions and an "Add New" button.
   - **Create**: Add a new student with a department dropdown and form validation.
   - **Edit**: Update existing student data with pre-filled inputs.
   - **Delete**: Dedicated confirmation page showing student details before deletion.

2. **Validation**:
   - **Name**: Required, between 3 and 50 characters.
   - **Email**: Required, valid email format.
   - **Age**: Required, between 18 and 100.
   - **Department**: Required, restricted to predefined departments (`CS`, `IT`, `AI`, `IS`) both on the client side and the server side.
   - Client-side validation enabled via jQuery Validation and Unobtrusive Validation.
   - Server-side validation via `ModelState.IsValid` and custom business rules.
   - CSRF protection enabled with `[ValidateAntiForgeryToken]`.

---

## 🛠️ Technologies Used

- **Framework**: ASP.NET Core MVC (.NET 8)
- **ORM**: Entity Framework Core 8.0 (Code First)
- **Database**: Microsoft SQL Server (LocalDB)
- **UI & Styling**: Bootstrap 5, Bootstrap Icons, Razor Views
- **Validation**: Data Annotations, jQuery Validation

---

## 📁 Project Structure

```text
StudentsApp/
├── Controllers/
│   └── StudentsController.cs
├── Models/
│   ├── ApplicationDbContext.cs
│   └── Student.cs
├── Views/
│   ├── Shared/
│   │   ├── _Layout.cshtml
│   │   └── _ValidationScriptsPartial.cshtml
│   └── Students/
│       ├── Create.cshtml
│       ├── Delete.cshtml
│       ├── Edit.cshtml
│       └── Index.cshtml
├── Migrations/
├── appsettings.json
└── Program.cs
```

---

## ⚙️ How to Run

1. **Clone the repository**:
   ```bash
   git clone https://github.com/foxelhadad812-design/StudentsApp.git
   cd StudentsApp
   ```

2. **Update Database (apply migrations)**:
   ```bash
   dotnet ef database update
   ```

3. **Run the project**:
   ```bash
   dotnet run
   ```

4. **Open in browser**:
   Navigate to `http://localhost:5218` or `https://localhost:7074`.
