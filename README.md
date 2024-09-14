# ToDoList.Api
This API allows users to manage a to-do list by creating, updating, and deleting tasks.
It is built with ASP.NET WebAPI and uses SQLite for database management.
The API is designed to be simple and scalable.

## Features
- Create, Read, Update, and Delete tasks.
- User authentication with JWT tokens.

## Getting Started

### Prerequisites
- .NET 8 SDK
- SQLite

### Installation
1. Clone the repository:
    ```bash
    git clone https://github.com/DanitoSharp/ToDoList.Api.git
    ```
2. Navigate to the project directory:
    ```bash
    cd DanitoSharp/ToDoList.Api
    ```
3. Restore dependencies:
    ```bash
    dotnet restore
    ```
4. Run the API:
    ```bash
    dotnet run
    ```

### Configuration
- Configure the `appsettings.json` file to set up the connection string to the SQLite database.

## Authentication
This API uses JWT-based authentication. You must provide a valid token in the `Authorization` header to access protected endpoints.

### Register
**POST** `/api/auth/register`
- Body:
    ```json
    {
      
      "firstName": "string",
      "lastName": "string",
      "dateOfBirth": "1997-06-12",
      "email": "string",
      "password": "string"
      
    }
    ```
- Response:
    ```json
    {
      "User created successfully"
    }


### Login
**POST** `/api/auth/login`
- Body:
    ```json
    {
      "username": "yourusername",
      "password": "yourpassword"
    }
    ```
- Response:
    ```json
    {
      "token": "Eskdlsdmf...." ,
      "expiration": "2024-09-13T23:42:42Z"
    }

Include this token in the `Authorization` header as `Bearer <token>`

## API Endpoints

### Create a Todo Object
**POST** `/api/todo/CreateTodo <token>`
- **Headers**: 
    - `Authorization: Bearer <token>`
- **Request Body**:
    ```json
    {
        "name": "string",
        "description": "string",
        "priorityId": 0,
        "statusId": 0,
        "dueDate": "2024-09-13T22:51:44.059Z"
    }
    ```
- **Response**:
    - **201 Created**
    ```json
    {
        "id": 1,
        "name": "string",
        "description": "string",
        "priority": "Low",
        "status": "In Progress",
        "dateAdded": "0001-01-01T00:00:00",
        "dueDate": "2024-09-15T22:47:37.747"
    }
### Update a Todo Object
**POST** `/api/todo/CreateTodo <token>`
- **Headers**: 
    - `Authorization: Bearer <token>`
- **Request Body**:
    ```json
    {
        "name": "string",
        "description": "string",
        "priorityId": 0,
        "statusId": 0,
        "dueDate": "2024-09-13T22:51:44.059Z"
    }
    ```
- **Response**:
    - **201 Created**
    ```json
    {
        "id": 1,
        "name": "string",
        "description": "string",
        "priority": "Low",
        "status": "In Progress",
        "dateAdded": "0001-01-01T00:00:00",
        "dueDate": "2024-09-15T22:47:37.747"
    }
    ```

### Get All Tasks
**GET** `/api/Todo/GetAllToDo`
- **Headers**: 
    - `Authorization: Bearer <token>`
- **Response**:
    - **200 OK**
    ```json
    
    [
        {
            "id": 1,
            "name": "string",
            "description": "string",
            "priorityId": 1,
            "priority":
            {
                "id": 1,
                "name": "Low"
            },
            "statusId": 2,
            "status":
            {
                "id": 2,
                "name": "In Progress"
            },
            "dateAdded": "0001-01-01T00:00:00",
            "dueDate": "2024-09-15T22:47:37.747",
            "userId": "f36190da-5aa1-4c2f-a233-51aaf6f2bc81",
            "user": null
        },
      ...
    ]
    ```
### Get single todo item
**GET** `/api/Todo/GetTodo/{id}`
- **Headers**: 
    - `Authorization: Bearer <token>`
- **Response**:
    - **200 OK**
    ```json
    
    [
        {
            "id": 1,
            "name": "string",
            "description": "string",
            "priority": "Low",
            "status":"In Progress",
            "dateAdded": "0001-01-01T00:00:00",
            "dueDate": "2024-09-15T22:47:37.747",
        },
      ...
    ]
    ```
### Get single todo item
**GET** `/api/Todo/Delete/{id}`
- **Headers**: 
    - `Authorization: Bearer <token>`
- **Response**:
    - **200 OK**

## Error Codes

| Status Code               | Description                         |
|---------------------------|-------------------------------------|
| 200 OK                    | Request succeeded.                  |
| 201 OK                    | Created                             |
| 400 Bad Request           | Validation error or invalid data.   |
| 401 Unauthorized          | Authentication failed.              |
| 404 Not Found             | The resource was not found.         |
| 500 Internal Server Error | Unexpected server error.            |

<!-- ## Rate Limiting
This API has a rate limit of 1000 requests per hour per user. -->

<!-- ## API Versioning
You can access different versions of the API by including the version number in the URL.

- **v1**: `/api/v1/tasks`
- **v2**: `/api/v2/tasks` -->

## Support
If you have any issues or questions, please contact [Ekelemedaniel12@gmail.com].
