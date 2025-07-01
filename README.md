# Job Application Tracker (WIP)

⚙️ **Work in Progress** — This is a learning project where I'm building a full-stack job application tracker using ASP.NET Core (backend) and React (frontend).  
I’m experimenting and learning React, so expect some rough edges and updates!

---

## What it does so far

- Simple backend API to store and fetch jobs
- React frontend that fetches and displays job listings
- Basic filtering and status display (more features coming!)

---

## Tech stack

- Backend: ASP.NET Core Web API + EF Core (SQLite)
- Frontend: React (functional components, hooks)
- Swagger for API docs

---

## How to run it

### Backend

```bash
cd JobTracker.API
dotnet restore
dotnet run
```
The backend API will start running at https://localhost:7054 (or another port, check your output).

### Frontend

Make sure you have Node.js and npm installed. Then run:
```bash
cd jobtracker-frontend
npm install
npm start
```
This will start the React development server at http://localhost:3000.

The React app fetches job data from the backend API, so make sure the backend is running first.

### Future improvements
Add authentication

Improve UI with better design and more filters

Add more CRUD operations for jobs

Deploy to cloud services

### Notes
This is a learning project, so things may change as I improve the code.

Feel free to open issues or contribute!
Thanks for checking this out! 😊
