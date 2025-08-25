# Todo Application

This project is a full-stack Todo application with a .NET backend, a PostgreSQL database, and a frontend. This README provides instructions on how to build and run the application using Docker Compose.

---

## Prerequisites

Before you begin, ensure you have the following installed on your machine:

* **Docker:** The platform for building, shipping, and running containerized applications.
* **Docker Compose:** A tool for defining and running multi-container Docker applications.

---

## Project Structure

├── Backend
│   └── Todo
│       └── Todo.API
│           └── Dockerfile  <-- Dockerfile for the backend
│
├── Frontend
│   └── to-do
│       └── Dockerfile  <-- Dockerfile for the frontend
│
└── docker-compose.yml  <-- Docker compose file

---

## Instructions

### 1. Build and Run the Project

To build the Docker images and start all the services (PostgreSQL, backend, and frontend), navigate to the directory containing your `docker-compose.yml` file and run the following command:

```bash
docker compose up --build -d

### 2. Access the Application

Frontend: Open your web browser and go to http://localhost:5173
Backend API: The API is running on port 8080 and is accessible at http://localhost:8080

### 3. Shutdown the Project

To stop and remove the containers, networks, and volumes created by docker compose up, run the following command in the same directory:

```bash
docker compose down
