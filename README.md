# BulkyBook

"Bulky Book" is an e-commerce platform for selling books, featuring a robust backend and distinct user roles for managing the online store.
The application is designed to be flexible, supporting multiple languages (Turkish and English) and can be adapted to sell other products with minor modifications.

## Project Introduction

The "Bulky Book" application allows an administrator to manage book orders and grant permissions to companies to sell their products. 
]At the same time, it provides a seamless experience for users to order books from the site.

![image](https://github.com/user-attachments/assets/dbcbffda-f51e-4836-9b0c-df891799edb9)
![image](https://github.com/user-attachments/assets/f494c064-d0d4-4309-a84b-0aebf3c67de7)


## Features

  * **Multi-lingual Support:** The website supports both Turkish and English. 
  * **Responsive Design:** The site is designed to be flexible and responsive across various devices. 
  * **Dynamic User Roles:** The application supports four distinct user roles with different levels of permissions. 
  * **Content Management:** Administrators have full control over the content, including categories, cover types, and company information.
  * **Order Management:** Users can place orders and track their status.
  * **Shopping Cart:** A fully functional shopping cart allows users to add, view, and manage items before purchasing.
  * **Secure Authentication:** The application includes secure user registration and login functionalities.

## User Roles

The application has a comprehensive user management system with the following roles:

  * **Admin (Yönetici):** The highest-level user who manages the entire site. An admin can add other administrators and companies, and has full CRUD (Create, Read, Update, Delete) permissions on users and products.
  * **Company (Şirket):** A company acts as a lower-level administrator. They cannot create other administrators but can manage products and view order statuses, similar to an admin. 
  * **Employee (Çalışan):** This user type does not have administrative privileges and cannot add admins, companies, or other employees.
  * **Individual (Bireysel):** A regular user with no site management capabilities. They can, however, place orders and track the status of their orders.

## Technologies Used

The project was built using a modern technology stack:

  * **Backend:** ASP.NET Core 6 MVC, C\# 
  * **Database:** SQL Server with Entity Framework Core ORM
  * **Frontend:** Bootstrap 5, HTML5, CSS3, JavaScript, and jQuery
  * **Libraries and Tools:**
      * Bootswatch
      * Toastr
      * Sweetalert
      * Datatables.net
      * Tinymce
  * **Social Login:** Meta (Facebook) Developer integration

## Architectural Patterns

  * **Repository Pattern:** Used to decouple the business logic and the data access layers.
  * **Unit of Work:** Coordinates the work of multiple repositories by creating a single database context that is shared by all of them. [cite: 28]

## Getting Started

To get a local copy up and running, follow these simple steps.

### Prerequisites

  * [.NET 6 SDK](https://dotnet.microsoft.com/download/dotnet/6.0)
  * [SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads)
  * A code editor like [Visual Studio](https://visualstudio.microsoft.com/) or [VS Code](https://code.visualstudio.com/)

### Installation

1.  **Clone the repo**

    ```sh
    git clone https://github.com/SEIDY-KANTE/BulkyBook.git
    ```

2.  **Navigate to the project directory**

    ```sh
    cd BulkyBook
    ```

3.  **Restore NuGet packages**

    ```sh
    dotnet restore
    ```

4.  **Update Database Connection String**
    Open `appsettings.json` and update the `DefaultConnection` string with your SQL Server details.

5.  **Apply Migrations**
    The application is designed to automatically handle database migrations on the initial run.
    When first launched, it checks if a database exists.
    If not, it will create one using migrations. It also initializes a default admin user if no admin exists.
    Alternatively, you can run the migrations manually:

    ```sh
    dotnet ef database update
    ```

7.  **Run the application**

    ```sh
    dotnet run
    ```

## Usage

Once the application is running, you can navigate to the homepage. The customer panel is displayed by default.

### Customer Panel

  * Browse the list of available books. 
  * Click on "Ayrıntılar" (Details) to view more information about a book.
  * Add books to your shopping cart.
  * Proceed to checkout and fill in your shipping details.
  * Place your order and receive a confirmation.
  * Track the status of your orders in the order management panel

### Admin Panel

  * Log in with an admin account to access the administrative features.
  * The "Content Management" dropdown will be visible, allowing access to manage:
      * Categories 
      * Cover Types
      * Companies
  * Admins can perform all CRUD operations on products, including adding, updating, and deleting them.
