# TaskManagement_Back
This is a **TaskManagement** and **Chat** application built with **.NET Core 8 Web API**, designed using the principles of **Clean Architecture**. The project is structured to support maintainable, testable, and scalable code, following the separation of concerns and layered architecture.

## Features:
  - Task Management:
      - Create, update, delete, and list tasks.
      - Set task deadlines and priorities.
  - Chat Functionality:(not completed)
      - Real-time chat between users.
      - Private and group chats.
      - Message history and notifications.

## Clean Architecture:
  The project follows the **Clean Architecture** principles:
    - **Core**: Contains the domain models, interfaces, and application logic.
    - **Application**: Contains the business logic and use cases for the task management .
    - **Infrastructure**: Handles data access, external services, and integrations such as repositories and API communication.
    - **Web API**: Contains the controllers and the entry points for the application (the API layer).

## Prerequisites:
  - [.NET Core 8 SDK](https://dotnet.microsoft.com/download/dotnet) or later.
  - [Visual Studio](https://visualstudio.microsoft.com/) or any IDE with .NET support.
  - [SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads) or any database you plan to use.

## Project Setup:

### 1. Clone the repository:
```bash
git clone https://github.com/MohamedElsayedAbdAlaty/TaskManagementAndChat.git
### 2. Run migration of database
