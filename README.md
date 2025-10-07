Github updates


# 🚗 Vehicle Reservation System – .NET C# with Razor

A web application built with **.NET C# and Razor Pages** that allows users to create and manage vehicle reservations.  
The system provides two main roles:  
- 👤 **User**: Create and track their own reservations  
- 🛠️ **Admin**: View and manage all reservations  

---

## 🚀 Features
- Create, view, and cancel reservations  
- Separate areas for **users** and **administrators**  
- Authentication and authorization for access control  
- Data persistence using **JSON files** (no external DB required)  
- Layered structure with focus on clean architecture  

---

## 🛠️ Tech Stack
- **Language:** C#  
- **Framework:** .NET 6 (Razor Pages)  
- **Architecture:** MVC-inspired layered design  
- **Storage:** JSON persistence  
- **UI:** Razor Pages, Bootstrap for styling  

The data files are generated in the Json directory.

> An admin user is generated on the first index run:
> * User e-mail: admin@site.com
> * User password: 123456

New users can be generated in the system.

---

## 🎯 Project Goals & Learning Outcomes
This project was an opportunity to:  
- Practice **full-stack development** with .NET  
- Implement **role-based authentication & authorization**  
- Work with **state management** without a traditional database  
- Exercise **clean architecture principles** and separation of concerns  

---

## 📸 Demo

<p align="center">
  <img src="screenshot.gif" alt="Vehicle Reservation System Demo" width="600"/>
</p>

---

## 📂 Project Structure
```text
VehicleReservationSystem/
 ├── Controllers            # Handles requests and routes
 ├── Models                 # Reservation and User models
 ├── Pages                  # Razor Pages (UI + code-behind)
 ├── Services               # Business logic & data handling
 ├── wwwroot                # Static files (CSS, JS, images)
 ├── appsettings.json       # Configurations
 ├── Program.cs             # Application entry point
 └── VehicleReservationSystem.csproj
```
---

📥 Installation & Usage
1. Clone the repository:
```bash
git clone https://github.com/rodrigobruner/car-reservation-system.git
````
2. Open the solution in Visual Studio
3. Run the project with IIS Express or dotnet run
4. Access the app at https://localhost:5001
