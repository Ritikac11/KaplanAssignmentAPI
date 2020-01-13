RESTful api using .Net Core 3.1, Entity FrameworkCore and SQL Server Db to get and create assignments

API Endpoints:-

1. http://localhost:5000/swagger/index.html - Swagger UI

2. http://localhost:5000/api/Assignment/{id} - Get Assignments by Id

3. http://localhost:5000/api/Assignment/search?tags={value} - Search Assignments by tags

4. http://localhost:5000/api/Assignment - Add new assignment
Method:POST
Body: {
  "name": "string",
  "title": "string",
  "description": "string",
  "type": "string",
  "duration": 0,
  "tags": [
    "string"
  ]
}

