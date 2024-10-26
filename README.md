# Game Club Application
This repository contains a full-stack application with an ASP.NET Core backend and a Vue 3 frontend. The app allows users to create game clubs and schedule events.

## Prerequisites
Before you begin, make sure you have the following installed:
- .NET 6 SDK
- Node.js and npm (for the Vue 3 frontend)
- SQLite (optional, helpful for database inspection)

## Setting Up the Backend (ASP.NET Core)
- Configure Database ConnectionStrings
    ```sh
    {
      "ConnectionStrings": {
        "DefaultConnection": "Data Source=gameclub.db"
      }
    }
    ```
    
- Run Database Migrations
    ```sh
    dotnet ef database update
    ```
    
- Run the API
    ```sh
    dotnet run
    ```
The API will start at https://localhost:5000.

## Setting Up the Frontend (Vue 3)
- Navigate to the frontend folder
    ```sh
    cd game-club-fe
    ```
    
- Install Dependencies
    ```sh
    npm install
    ```
    
- Run the Vue App
    ```sh
    npm run serve
    ```
The frontend will be available at http://localhost:8080

## Testing the Application
- Backend API Testing

    Use Postman or curl to test endpoints, such as POST /api/clubs, GET /api/clubs, etc.
    
- Frontend Testing
  
    Open a browser and navigate to http://localhost:8080. You should be able to create clubs and events through the Vue interface.
