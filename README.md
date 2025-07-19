# 🏥 Medical Record Dashboard

A fully functional **Medical Record Dashboard** built using **ASP.NET MVC (Entity Framework)** and **SQL Server (MSSQL)**. This project includes user authentication, profile editing, secure file upload, and file previews — all handled within a robust MVC architecture.

---

## 🎯 Objective

Build a clean and simple Medical Dashboard with:

- 👤 **Sign-Up** with Full Name, Email, Gender, Phone Number, and Password
- 🧑‍⚕️ **User Profile Management** (edit email, phone, gender, and upload profile picture)
- 📁 **Medical File Uploads** (with type, name, and file selection)
- 🖼️ **File Preview & Management** (view or delete uploaded medical files)

✅ All core functionalities are implemented and validated **via MVC pattern (not Web API)**.



## 📂 Folder Structure
<pre> ``` MedicalDashboard/ │ ├── Controllers/ # MVC Controllers (Auth, Dashboard) ├── Models/ # User model and related EF entities ├── Views/ │ ├── Auth/ # Login, Register, ForgotPassword │ └── Dashboard/ # Profile + Upload + Preview │ ├── Content/ # CSS, uploaded profile images ├── Scripts/ # JS files (if any) ├── App_Data/ # SQL Database (if local .mdf used) ├── Web.config # DB connection string └── README.md ``` </pre>



📌 **Local Path:**  
`D:\MVC\MedicalDashboard\MedicalDashboard\`

---

## ✅ Features Implemented

### 🔐 Authentication
- Register, Login, Logout (Session-Based)
- Passwords securely hashed using SHA-256

### 🧑 Profile Management
- View & edit email, gender, and phone number
- Upload and update profile image
- Default profile image if none uploaded

### 📤 File Upload (Medical Records)
- Upload files of types:
  - Lab Report
  - Prescription
  - X-Ray
  - Blood Report
  - MRI Scan
  - CT Scan
- Input for custom file name
- Supports PDF, JPG, PNG

### 📋 Uploaded File Preview
- Preview uploaded files with:
  - File name
  - File type
  - View (modal or new tab)
  - Delete file

### ✅ Validations & Checks
- Backend file type and field validation
- File stored securely on server
- Duplicate email check on registration
- Responsive UI using Bootstrap

---

## 🧰 Tech Stack

### Backend
- ASP.NET MVC (.NET Framework)
- Entity Framework (Code-First)
- SQL Server (MSSQL)

### Frontend
- Razor Views + Bootstrap 5 (Responsive)
- JavaScript (Optional for preview modal)

---
###Note
I'm new to Next.js, but actively learning it. This MVC version serves as a complete and functional submission, and I plan to integrate APIs and a Next.js frontend in the next iteration using a monorepo structure.

## 🚀 Getting Started

### 1. Clone the Repository

```bash
git clone https://github.com/<Vaibhavredekar02>/MedDashboard.git

2. Open in Visual Studio
    D:\MVC\MedicalDashboard\MedicalDashboard.sln


3. Configure DB in Web.config

    Replace with your SQL Server config:
    
    <connectionStrings>
      <add name="DefaultConnection"
           connectionString="Data Source=.\SQLEXPRESS;Initial Catalog=MedicalDashboardDB;Integrated Security=True"
           providerName="System.Data.SqlClient" />
    </connectionStrings>


4. Run the App
    Press F5 or run without debugging
    
    Database will be auto-created if Code First is enabled

5 Sample User (If Seeded)

    Email: xyz@gmail.com
    Password: 1212

 
