# TaskMaster API - .NET 10

Este es un proyecto de gestión de tareas desarrollado con una **Arquitectura en Capas (N-Tier)** para practicar la separación de responsabilidades y persistencia de datos con **Entity Framework Core**.

## 🚀 Tecnologías
* **ASP.NET Core Web API** (.NET 10)
* **Entity Framework Core**
* **SQLite** como motor de base de datos.
* **Swagger/OpenAPI** para documentación y pruebas.

## 🏗️ Arquitectura
El proyecto se divide en 3 capas principales:
1. **Domain**: Contiene las entidades de negocio (`TodoTask`).
2. **Data**: Maneja el contexto de la base de datos y migraciones.
3. **API**: Controladores y configuración del servidor.

## 🛠️ Cómo ejecutar
1. Clona el repositorio.
2. Ejecuta `dotnet restore` para instalar dependencias.
3. Ejecuta `dotnet run --project TaskMaster.API` para iniciar el servidor.
4. Accede a `http://localhost:5268/swagger` para probar los endpoints.