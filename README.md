# Academico .NET

Repositorio destinado al desarrollo y gestion de una API academica, aplicando arquitectura por capas, buenas practicas de programacion y conexion con base de datos SQL Server.

## Proyecto Actual

### Academico.API

Aplicacion desarrollada con .NET y ASP.NET Core Web API para la gestion de informacion academica.

El proyecto permite trabajar con entidades principales como estudiantes, cursos y matriculas, utilizando una estructura organizada por capas para separar responsabilidades y mantener el codigo mas limpio, escalable y mantenible.

## Tecnologias

* C#
* .NET
* ASP.NET Core Web API
* SQL Server
* Entity Framework Core
* Swagger
* AutoMapper
* Git & GitHub

## Arquitectura

El proyecto sigue una arquitectura por capas:

```text
Controller
    ↓
Service
    ↓
Repository
    ↓
Database
```

Esta estructura permite separar la exposicion de endpoints, la logica de negocio, el acceso a datos y la comunicacion con la base de datos.

## Capas del proyecto

* **Academico.API** → Exposicion de endpoints y configuracion principal de la API.
* **Academico.Service** → Reglas de negocio y validaciones principales.
* **Academico.Repository** → Acceso y comunicacion con los datos.
* **Academico.Entities** → Entidades del dominio.
* **Academico.Data** → Contexto de base de datos y migraciones.
* **Academico.DTOs** → Objetos de transferencia de datos para crear, actualizar y responder informacion.
* **Academico.Common** → Interfaces, excepciones y componentes compartidos.

## Estructura

```text
Academico
│
├── Academico.API
├── Academico.Service
├── Academico.Repository
├── Academico.Entities
├── Academico.Data
├── Academico.DTOs
└── Academico.Common
```

## Objetivos

* Aplicar arquitectura por capas.
* Implementar inyeccion de dependencias.
* Utilizar Entity Framework Core.
* Trabajar con migraciones hacia SQL Server.
* Implementar Repository Pattern.
* Utilizar DTOs para controlar la entrada y salida de datos.
* Aplicar AutoMapper para transformar entidades y DTOs.
* Desarrollar endpoints REST.
* Probar la API mediante Swagger.
* Mantener una estructura ordenada, escalable y mantenible.

## Funcionalidades generales

* Gestion de estudiantes.
* Gestion de cursos.
* Gestion de matriculas.
* Validaciones de datos.
* Conexion con base de datos.
* Creacion y actualizacion de registros.
* Consulta de informacion mediante endpoints.

## Ejecucion del proyecto

Para ejecutar el proyecto se debe verificar la cadena de conexion en el archivo `appsettings.json`, aplicar las migraciones correspondientes y ejecutar el proyecto principal `Academico.API`.

Comandos principales para migraciones:

```powershell
Add-Migration InitialCreate -Project Academico.Data -StartupProject Academico.API
```

```powershell
Update-Database -Project Academico.Data -StartupProject Academico.API
```

Luego de ejecutar el proyecto, la API puede probarse desde Swagger.

## Autor

**Glenda Perez**


