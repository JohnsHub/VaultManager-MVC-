**Vault Manager**  
An ASP.NET Core MVC application inspired by Fallout Shelter, allowing you to create and manage vaults and dwellers with a retro Pip‑Boy interface.

---

## Project Overview
Vault Manager is a demonstration web application that showcases:

- **Vault Management**: Create, edit, and delete multiple vaults.
- **Dweller Management**: Add, edit, and remove dwellers; assign them to vaults.
- **Themed User Interface**: A Fallout‑inspired "Pip‑Boy" look and feel, complete with neon accents and retro fonts.
- **Authentication**: User registration, login, logout, email confirmation, and password reset via ASP.NET Core Identity (using an in‑memory database for demonstration).
- **Help and FAQ**: Guided support and contact information for users.
- **Responsive Design**: Built with Bootstrap for mobile-friendly layouts.

This project demonstrates the ability to build a full-stack, secure, themed web application using modern .NET technologies.

---

## Tech Stack

| Layer            | Technology                                 |
|------------------|--------------------------------------------|
| Framework        | ASP.NET Core MVC (NET 6 or later)         |
| Authentication   | ASP.NET Core Identity                      |
| Data Access      | Entity Framework Core (In-Memory Provider) |
| Front-end        | Bootstrap 5, custom CSS (Pip‑Boy theme)    |
| Templating       | Razor Views                                |
| Fonts & Icons    | Google Fonts (Bebas Neue), Bootstrap Icons |

---

## Features & Usage

1. **Homepage & Navigation**  
   Quick links to Vaults, Dwellers, Help/FAQ, Login/Sign Up.

2. **Vaults Page**  
   View all vaults, see total count, add, edit, and delete vaults.

3. **Dwellers Page**  
   List of dwellers with roles and assigned vaults, inline edit form, add and delete functionality.

4. **Authentication**  
   - Register: Email and password signup with email confirmation.
   - Login/Logout: Secure sign-in and sign-out.
   - Forgot Password: Request reset link; reset via emailed token.
   - Account Management: Update email and password in the Manage section.

5. **Help / FAQ**  
   Themed FAQ section and contact information for support.

6. **About & Privacy**  
   Informational pages with consistent branding.

---

## Future Enhancements

- **Persistent Storage**: Swap in SQL Server or SQLite provider for production.
- **Resource Simulation**: Track vault resources (food, water, power).
- **Event System**: Simulate random challenges (radroaches, power failures).
- **API Layer**: Expose RESTful endpoints for integration.
- **Automated Testing**: Add unit and integration tests for controllers and services.
