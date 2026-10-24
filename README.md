# StudentsApp - ASP.NET Core MVC (.NET 8)

A full-featured web application built with **ASP.NET Core MVC (.NET 8)** featuring complete **User Authentication & Account Management** using **ASP.NET Core Identity** and student management with full **CRUD operations** and **validation**, using **Entity Framework Core (Code First)** with SQL Server LocalDB and Bootstrap.

---

## 🚀 Features

### 1. User Authentication & Account Management (ASP.NET Core Identity)
- **Register**: Create a new account with email, password (minimum 6 characters), and password confirmation validation. Automatically signs in the user upon successful registration.
- **Sign In (Login)**: Secure authentication with email, password, "Remember Me" checkbox, and invalid credentials feedback.
- **Sign Out (Logout)**: Secure CSRF-protected sign-out clearing authentication cookies and updating navigation state.
- **Reset Password**: Complete 2-step password recovery workflow:
  1. **Forgot Password**: Request a password reset by providing the registered email.
  2. **Reset Password**: Enter a new password with confirmation and secure token verification via `UserManager.ResetPasswordAsync`.

### 2. Student Management (CRUD)
- **Index**: View all students in a responsive table with Edit and Delete actions and an "Add New" button.
- **Create**: Add a new student with a department dropdown and form validation.
- **Edit**: Update existing student data with pre-filled inputs.
- **Delete**: Dedicated confirmation page showing student details before deletion.

### 3. Validation & Security
- **Data Annotations**: `[Required]`, `[StringLength]`, `[EmailAddress]`, `[Range]`, `[Compare]`.
- **Predefined Departments**: `CS`, `IT`, `AI`, `IS` validated on both client side and server side.
- **CSRF Protection**: All POST actions protected with `[ValidateAntiForgeryToken]`.
- **Client & Server Validation**: jQuery Unobtrusive Validation and `ModelState.IsValid`.

---

## 🛠️ Technologies Used

- **Framework**: ASP.NET Core MVC (.NET 8)
- **Authentication**: ASP.NET Core Identity 8.0
- **ORM**: Entity Framework Core 8.0 (Code First)
- **Database**: Microsoft SQL Server (LocalDB)
- **UI & Styling**: Bootstrap 5, Bootstrap Icons, Razor Views
- **Validation**: Data Annotations, jQuery Validation

---

## 📁 Project Structure

```text
StudentsApp/
├── Controllers/
│   ├── AccountController.cs         # Register, Login, Logout, Reset Password
│   ├── HomeController.cs
│   └── StudentsController.cs        # CRUD operations for Students
├── Models/
│   ├── ViewModels/
│   │   ├── ForgotPasswordViewModel.cs
│   │   ├── LoginViewModel.cs
│   │   ├── RegisterViewModel.cs
│   │   └── ResetPasswordViewModel.cs
│   ├── ApplicationDbContext.cs      # Inherits IdentityDbContext<IdentityUser>
│   └── Student.cs
├── Views/
│   ├── Account/
│   │   ├── AccessDenied.cshtml
│   │   ├── ForgotPassword.cshtml
│   │   ├── Login.cshtml
│   │   ├── Register.cshtml
│   │   ├── ResetPassword.cshtml
│   │   └── ResetPasswordConfirmation.cshtml
│   ├── Shared/
│   │   ├── _Layout.cshtml
│   │   ├── _LoginPartial.cshtml     # Auth state navbar links
│   │   └── _ValidationScriptsPartial.cshtml
│   └── Students/
│       ├── Create.cshtml
│       ├── Delete.cshtml
│       ├── Edit.cshtml
│       └── Index.cshtml
├── Migrations/                      # EF Core Code First Migrations
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
