# Bookworm Society - Backend

## Description

Bookworm Society is a platform for book enthusiasts to connect, discuss, and explore books with other readers. Users can create or join book clubs, participate in discussions, vote on the next book to read, and track their reading progress. The platform offers a rich social experience where users can leave reviews, interact through posts and comments, and share their love of reading with others.

## Table of Contents

- [Technologies](#technologies)
- [Get Started](#get-started)
- [API Endpoints](#api-endpoints)
- [Postman Documentation](#postman-documentation)
- [Frontend Repository Link](#link-to-frontend)
- [Maintainers](#maintainers)

## Technologies

- **Programming Language:** C#
- **Framework:** ASP.NET Core (.NET 8.0)
- **Object-Relational Mapper:** Entity Framework Core
- **Database:** PostgreSQL
- **Database Management Tool:** pgAdmin
- **Testing Frameworks:**
  - xUnit
  - Moq
- **API Documentation and Testing Tools:**
  - Postman
  - Swagger
  
## Get Started

#### For this project to run successfully, you'll need the following:

- [Visual Studio](https://visualstudio.microsoft.com/downloads/?cid=learn-onpage-download-install-visual-studio-page-cta)
- [.NET](https://dotnet.microsoft.com/en-us/)
- [pgAdmin](https://www.pgadmin.org/)
- [PostgreSQL](https://www.postgresql.org/download/)

Follow these steps to set up the **Fan Fusion API**:
#### 1. Fork and Clone the Repository
Fork the repository, then clone it to your local machine.
```bash
git@github.com:yarelismartin/Bookworm-Society-BE.git
```
#### 2. Open in Visual Studio 2022
Open the solution file (`.sln`) in **Visual Studio 2022**.

#### 3. Restore Dependencies
Run the following command to restore project dependencies:

```bash
dotnet restore
```

#### 4. Configure User Secrets
Initialize user secrets and set your PostgreSQL connection string:

```bash
dotnet user-secrets init
dotnet user-secrets set "Bookworm-SocietyDbConnectionString" "Host=localhost;Port=5432;Username=postgres;Password=<your-password>;Database=BookwormSociety"
```
Replace `<your_postgresql_password>` with your actual database password.

#### 5. Apply Migrations and Create the Database
Run the following command to apply the existing migrations and create the database:

```bash
dotnet ef database update
```

#### 6. Start Debugging
Run the project in debug mode by selecting the **Start Debugging** option in Visual Studio. This will launch the API, and you can access Swagger to test the endpoints.

#### 7. Test the API
Use **Postman** or Swagger UI to interact with the API and test CRUD operations for books and authors.

## API Endpoints

### Book Clubs
| Method | Endpoint                             | Description                   |
|--------|--------------------------------------|-------------------------------|
| GET    | `/bookclubs/{userId}`                | Get all book clubs for a user |
| POST   | `/bookclubs`                         | Create a new book club        |
| GET    | `/bookclubs/{bookClubId}`            | Retrieve a specific book club |
| PUT    | `/bookclubs/{bookClubId}`            | Update a specific book club   |
| DELETE | `/bookclubs/{bookClubId}`            | Delete a book club            |
| GET    | `/bookclubs`                         | Get all book clubs            |

### Books
| Method | Endpoint                             | Description                   |
|--------|--------------------------------------|-------------------------------|
| GET    | `/books`                             | Retrieve all books            |
| POST   | `/books`                             | Create a new book             |
| GET    | `/books/{bookId}`                    | Retrieve a specific book      |
| PUT    | `/books/{bookId}`                    | Update a specific book        |
| DELETE | `/books/{bookId}`                    | Delete a specific book        |

### Posts
| Method | Endpoint                             | Description                   |
|--------|--------------------------------------|-------------------------------|
| GET    | `/posts/{postId}`                    | Retrieve a specific post      |
| POST   | `/posts`                             | Create a new post             |
| PUT    | `/posts/{postId}`                    | Update a post                 |
| DELETE | `/posts/{postId}`                    | Delete a post                 |

### Comments
| Method | Endpoint                             | Description                   |
|--------|--------------------------------------|-------------------------------|
| GET    | `/comments`                          | Retrieve all comments         |
| POST   | `/comments`                          | Create a new comment          |
| DELETE | `/comments/{commentId}`              | Delete a comment              |

### Reviews
| Method | Endpoint                             | Description                   |
|--------|--------------------------------------|-------------------------------|
| POST   | `/reviews`                           | Create a new review           |
| PUT    | `/reviews/{reviewId}`                | Update a review               |
| DELETE | `/reviews/{reviewId}`                | Delete a review               |

### Users
| Method | Endpoint                             | Description                   |
|--------|--------------------------------------|-------------------------------|
| GET    | `/users/{userId}`                    | Retrieve a specific user      |
| POST   | `/users`                             | Create a new user             |
| PUT    | `/users/{userId}`                    | Update a user                 |

## Postman Documentation
The API documentation is available in Postman, providing a detailed guide on how to interact with the Bookworm Society API.

- [Bookworm Society API Documentation](<Insert_Postman_Link_Here>)

## Link to Frontend
Here is the link to our frontend repo: [Bookworm Society FE](<Insert_Frontend_Repo_Link_Here>)

## Maintainers
- [Yarelis Martin](https://github.com/yarelismartin)
