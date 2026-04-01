# Employee Leave Management System

A simple web application for managing employee leaves, built with Angular (frontend) and ASP.NET Core (backend).

---

## Features

- **User Authentication:**  
  Employees can log in using their Associate ID and password.

- **Navigation Bar:**  
  Dynamic navigation links for Apply Leave, Team View, and Add Employee, visible only to logged-in users.  
  Login/Logout button toggles based on authentication state.

- **Leave Request:**  
  - Employees can submit leave requests through an Apply Leave form.
  - Validates required fields (dates, leave type, etc.).
  - Displays success or error messages after submission.
  - (Backend endpoint and frontend form required.)

- **Add Employee:**  
  - Accessible via the navigation bar.
  - Form to add new employees with fields: Associate ID, Name, Password, Role, and Location.
  - Validates required fields and handles duplicate/invalid entries.
  - Displays success or error messages after submission.

- **Backend API:**  
  - **Login:** Validates credentials and returns user info.
  - **Add Employee:** Adds a new employee after validation.
  - **Get All Employees:** Retrieves all employee records.
  - **Leave Request:** Accepts and stores leave requests from employees.

---

## Getting Started

### Prerequisites

- Node.js & npm (for Angular frontend)
- .NET 6+ SDK (for ASP.NET Core backend)

### Setup

#### 1. Backend

```bash
cd Backend/EmployeeLeaveManagement
dotnet restore
dotnet build
dotnet run
```
- The backend will run on `https://localhost:7068/` by default.

#### 2. Frontend

```bash
cd leave-management-ui
npm install
ng serve
```
- The frontend will run on `http://localhost:4200/` by default.

---

## Project Structure

```
Backend/
  EmployeeLeaveManagement/
    Controllers/
      AuthController.cs
      LeaveController.cs
    Data/
    Models/
    ...
leave-management-ui/
  src/
    app/
      Components/
        login/
        add-employee/
        apply-leave/
      Services/
        leave.ts
      app.component.ts
      ...
```

---

## API Endpoints

- `POST /api/Auth/login` — User login
- `POST /api/Auth/add` — Add new employee
- `GET /api/Auth/all` — Get all employees
- `POST /api/Leave/apply` — Submit a leave request

---

## Customization

- Add more fields to the employee or leave models as needed.
- Extend navigation and features (e.g., leave approval, team management).

---

## License

This project is for educational/demo purposes.
