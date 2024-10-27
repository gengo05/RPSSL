# Rock Paper Scissors Spock Lizard

## Overview

This is a web application for playing the classic game "Rock Paper Scissors Spock Lizard." The application is built using Angular for the frontend and .NET for the backend, with a Swagger API for easy interaction.

## Technologies Used

- **Frontend:** Angular
- **Backend:** .NET 8
- **API Documentation:** Swagger

## API Endpoints

The application provides the following API endpoints:

### Choices

- **GET** `/api/choice/choices`

  - Description: Retrieve all possible choices.

- **GET** `/api/choice/choice`
  - Description: Retrieve a random choice.

### Game

- **POST** `/api/game`
  - Request Body: `GameRequestDto`
  - Description: Play a game round with the user's chosen move.

### Scoreboard

- **GET** `/api/scoreboard`

  - Description: Retrieve the current scoreboard.

- **POST** `/api/scoreboard/reset`
  - Description: Reset the scoreboard (available only to logged-in users).

### User

- **POST** `/api/user/login`
  - Request Body: `User`
  - Description: Log in a user.

## Swagger Documentation

The API is documented using Swagger. You can access it by navigating to `https://localhost:44344/swagger` after starting the backend application.

## Running the Application

### Frontend

1. Navigate to the Angular project directory:
   ```bash
   cd client
    ```

2. Install the necessary dependencies:

   ```bash
   npm install
   ```

3. Start the development server:
   ```bash
   npm start
   ```
   or
   ```bash
   ng serve
   ```

The frontend will be available at `http://localhost:4200/`.

### Backend

1. Open the .NET project in your IDE (e.g., Visual Studio).
2. Start the application, which will be available at `https://localhost:44344/index.html`.

## How to Play the Game

1. Log in: Use one of the following users:

   - Admin: Password
   - User1: Password
   - User2: Password
   - User3: Password
   - User4: Password

2. Choose your move: After logging in, select your move from the options:

   - Rock
   - Paper
   - Scissors
   - Spock
   - Lizard

3. Random Choice: You can also use the "Play Random Choice" button.

4. Reset Scoreboard: You can reset the scoreboard, but only if you are logged in.
