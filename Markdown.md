📝 TaskMaster API - Documentación del Proyecto
📌 Descripción General
TaskMaster API es una solución robusta para la gestión de tareas, construida bajo un esquema de Arquitectura en Capas (N-Tier). La aplicación permite realizar operaciones CRUD (Crear, Leer, Actualizar, Borrar) sobre tareas, utilizando Entity Framework Core para la persistencia de datos en una base de datos SQLite.

🏗️ Arquitectura y Principios de Diseño
La aplicación sigue una organización lógica dividida en tres proyectos principales para garantizar la separación de responsabilidades:

1. Capa de Dominio (TaskMaster.Domain)
Es el corazón del sistema. Contiene las Entidades que representan los datos del negocio.

Principio: Independencia de infraestructura. Esta capa no conoce nada sobre la base de datos o la API.

Componente clave: Clase TodoTask, que define las propiedades de una tarea (Id, Título, Descripción, Fechas, Estado y UserId).

2. Capa de Datos (TaskMaster.Data)
Maneja la persistencia y la comunicación con el motor de base de datos.

Tecnología: Entity Framework Core (ORM).

Componente clave: AppDbContext, que actúa como el puente entre los objetos de C# y las tablas de SQLite.

Estrategia: Se utiliza Database.EnsureCreated() en el inicio para garantizar que el esquema de la base de datos esté siempre disponible sin intervención manual inicial.

3. Capa de Presentación (TaskMaster.API)
Es la interfaz de entrada para los usuarios y otros sistemas.

Tecnología: ASP.NET Core Web API.

Principios REST: Emplea verbos HTTP estándar (GET, POST, PUT, DELETE) y códigos de estado (200 OK, 201 Created, 404 Not Found) para una comunicación clara.

Inyección de Dependencias: El contexto de la base de datos se inyecta en los controladores, facilitando el mantenimiento y las pruebas unitarias.

🛠️ Flujo de Funcionamiento (Request Pipeline)
Petición: El cliente (Swagger/Frontend) envía una solicitud HTTP con un cuerpo en formato JSON.

Ruteo: El Middleware de ASP.NET mapea la URL (/api/Tasks) al controlador correspondiente.

Procesamiento: El TasksController recibe los datos, interactúa con el AppDbContext para realizar la operación solicitada.

Persistencia: Entity Framework traduce las acciones de C# a comandos SQL ejecutados en Tasks.db.

Respuesta: El servidor devuelve un objeto JSON y un código de estado HTTP al cliente.

🚀 Lecciones Aprendidas y Solución de Problemas
Durante el desarrollo, se aplicaron soluciones a desafíos técnicos comunes:

Gestión de Errores de Ruteo (404): Corrección de la configuración del Middleware mediante app.MapControllers() y el atributo [Route].

Manejo de Tipos de Datos: Implementación de Guid para identificadores de usuario y tipos anulables (DateTime?) para flexibilidad en las fechas.

Sincronización de Base de Datos: Resolución del error "no such table" mediante la correcta ejecución de migraciones y la validación de la existencia del esquema al arrancar el servidor.

📋 Requisitos para Ejecución Local
.NET 10 SDK instalado.

SQLite (incluido mediante paquetes NuGet).

Comandos:

dotnet build: Compila la solución.

dotnet run --project TaskMaster.API: Inicia el servidor.
