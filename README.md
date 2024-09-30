# Crazy Musicians API

## Description
The Crazy Musicians API is a simple ASP.NET Core Web API that supports basic CRUD (Create, Read, Update, Delete) operations for managing a collection of fun and entertaining musicians. The API includes various endpoints for interacting with musician data, ensuring data validation and structured routing.

## Features
- **CRUD Operations**:
  - **GET**: Retrieve all musicians or search for musicians by name.
  - **POST**: Add a new musician to the collection.
  - **PATCH**: Update specific fields of an existing musician.
  - **PUT**: Replace an entire musician record.
  - **DELETE**: Remove a musician from the collection.

## Technologies Used
- **ASP.NET Core**: For building the Web API.
- **LINQ**: For querying data.

## Routing
The routing of the API follows a consistent pattern, inspired by the Galactic Tour application example. It utilizes `[FromQuery]` attributes for search functionality.

## Validation
Validation is implemented to ensure:
- Musician names are required and between 3 and 100 characters.
- Additional data validations as necessary.
