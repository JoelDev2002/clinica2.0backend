# 🏥 Clínica Backend API

> API RESTful para la gestión de citas médicas de una clínica privada, desarrollada con **ASP.NET Core (.NET 10)** como proyecto académico del curso de Desarrollo de Servicios Web en **IDAT**.

[![.NET](https://img.shields.io/badge/.NET-10.0-512BD4?style=flat-square&logo=dotnet)](https://dotnet.microsoft.com/)
[![C#](https://img.shields.io/badge/C%23-12.0-239120?style=flat-square&logo=csharp)](https://docs.microsoft.com/en-us/dotnet/csharp/)
[![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg?style=flat-square)](https://opensource.org/licenses/MIT)

---

## 📋 Tabla de Contenidos

- [Descripción](#-descripción-del-proyecto)
- [Arquitectura y Estructura](#-arquitectura-y-estructura)
- [Tecnologías](#-tecnologías)
- [Requisitos previos](#-requisitos-previos)
- [Instalación y Ejecución](#-instalación-y-ejecución)
- [Endpoints de la API](#-endpoints-de-la-api)
- [Ejemplos de Uso](#-ejemplos-de-uso)
- [Comportamiento de la API](#-comportamiento-de-la-api)
- [Manejo de Errores](#-manejo-de-errores)
- [Pruebas con Postman](#-pruebas-con-postman)

---

## 📝 Descripción del Proyecto

Esta API RESTful gestiona de manera eficiente las **citas médicas** de una clínica privada, permitiendo:

- Registrar, consultar, actualizar y eliminar **pacientes**.
- Registrar, consultar, actualizar y eliminar **médicos**.
- Crear, consultar, reprogramar, completar y cancelar **citas médicas**.

La aplicación sigue una **arquitectura en capas** (Controladores → Servicios → Repositorio en memoria) y aplica principios **RESTful** y **programación orientada a objetos**.

> **Nota académica:** La persistencia de datos se simula mediante listas en memoria (`List<T>`) sin base de datos externa, con fines educativos. Los datos se pierden al reiniciar la aplicación.

---

## 🏗️ Arquitectura y Estructura

```
ClinicaBackend/
├── Controllers/                  # Capa de presentación – Endpoints HTTP
│   ├── CitaController.cs
│   ├── MedicoController.cs
│   └── PacienteController.cs
│
├── Services/                     # Capa de lógica de negocio
│   ├── Interfaces/               # Contratos de los servicios
│   ├── CitaService.cs
│   ├── MedicoService.cs
│   └── PacienteService.cs
│
├── Models/                       # Entidades del dominio
│   ├── Cita.cs
│   ├── Medico.cs
│   └── Paciente.cs
│
├── Dto/                          # Objetos de transferencia de datos (DTOs)
│   ├── Cita/
│   │   ├── CitaRequest.cs
│   │   ├── CitaResponse.cs
│   │   ├── CitaCompletadaRequest.cs
│   │   ├── CitaCompletadaResponse.cs
│   │   └── ReprogramarCitaRequest.cs
│   ├── Medico/
│   │   ├── MedicoRequest.cs
│   │   └── MedicoResponse.cs
│   └── Paciente/
│       ├── PacienteRequest.cs
│       └── PacienteResponse.cs
│
├── Data/                         # Capa de acceso a datos (simulada en memoria)
│   ├── Interfaces/
│   ├── CitaBd.cs
│   ├── MedicoBd.cs
│   └── PacienteBd.cs
│
├── Exception/                    # Manejo centralizado de excepciones
│   ├── GlobalExceptionHandler.cs
│   ├── NotFoundException.cs
│   ├── BadRequestException.cs
│   └── ConflictException.cs
│
├── Program.cs                    # Configuración e inyección de dependencias
├── appsettings.json
└── README.md
```

### Flujo de una petición

```
Cliente HTTP
    │
    ▼
Controller (valida entrada y enruta)
    │
    ▼
Service (lógica de negocio)
    │
    ▼
Data / Bd (persistencia en memoria)
    │
    ▼
Response DTO (devuelve solo los datos necesarios)
```

---

## 🛠️ Tecnologías

| Tecnología | Versión | Uso |
|---|---|---|
| ASP.NET Core | .NET 10 | Framework principal de la API |
| C# | 12.0 | Lenguaje de programación |
| Microsoft.AspNetCore.OpenApi | 10.0.2 | Documentación OpenAPI / Scalar |
| DataAnnotations | Built-in | Validación de datos de entrada |
| IExceptionHandler | Built-in | Manejo global de excepciones |

---

## ✅ Requisitos Previos

Antes de ejecutar el proyecto, asegúrate de tener instalado:

- [**.NET 10 SDK**](https://dotnet.microsoft.com/download/dotnet/10.0) o superior
- **IDE recomendado:** [Visual Studio 2022](https://visualstudio.microsoft.com/) o [Visual Studio Code](https://code.visualstudio.com/)
- **Postman** (opcional, para pruebas de endpoints): [Descargar Postman](https://www.postman.com/downloads/)

Verifica tu instalación de .NET con:
```bash
dotnet --version
```

---

## 🚀 Instalación y Ejecución

### 1. Clonar el repositorio

```bash
git clone https://github.com/JoelDev2002/clinica2.0backend.git
cd clinica2.0backend
```

### 2. Restaurar dependencias (paquetes NuGet)

```bash
dotnet restore
```

### 3. Ejecutar la aplicación

```bash
dotnet run
```

### 4. Acceder a la documentación interactiva

Una vez iniciada la aplicación, accede a la documentación **Scalar/OpenAPI** en:

```
https://localhost:7051/openapi/v1.json
```

> 💡 Si el puerto es diferente, revisa la consola al ejecutar `dotnet run`. El puerto se muestra como:  
> `Now listening on: https://localhost:XXXX`

---

## 📡 Endpoints de la API

> **URL base:** `https://localhost:7051`

### 👤 Pacientes — `/api/paciente`

| Método | Ruta | Descripción | Código Éxito |
|--------|------|-------------|--------------|
| `GET` | `/api/paciente` | Listar todos los pacientes | `200 OK` |
| `GET` | `/api/paciente/{id}` | Obtener un paciente por ID | `200 OK` |
| `POST` | `/api/paciente` | Registrar un nuevo paciente | `201 Created` |
| `PUT` | `/api/paciente/{id}` | Actualizar datos de un paciente | `200 OK` |
| `DELETE` | `/api/paciente/{id}` | Eliminar un paciente | `204 No Content` |

---

### 🩺 Médicos — `/api/medico`

| Método | Ruta | Descripción | Código Éxito |
|--------|------|-------------|--------------|
| `GET` | `/api/medico` | Listar todos los médicos | `200 OK` |
| `GET` | `/api/medico/{id}` | Obtener un médico por ID | `200 OK` |
| `POST` | `/api/medico` | Registrar un nuevo médico | `201 Created` |
| `PUT` | `/api/medico/{id}` | Actualizar datos de un médico | `200 OK` |
| `DELETE` | `/api/medico/{id}` | Eliminar un médico | `204 No Content` |

---

### 📅 Citas — `/api/cita`

| Método | Ruta | Descripción | Código Éxito |
|--------|------|-------------|--------------|
| `GET` | `/api/cita` | Listar todas las citas | `200 OK` |
| `GET` | `/api/cita/{id}` | Obtener una cita por ID | `200 OK` |
| `POST` | `/api/cita` | Crear una nueva cita | `201 Created` |
| `PUT` | `/api/cita/{id}` | Reprogramar la fecha de una cita | `200 OK` |
| `PUT` | `/api/cita/completar/{id}` | Completar una cita (agregar receta y observaciones) | `200 OK` |
| `DELETE` | `/api/cita/{id}` | Cancelar/eliminar una cita | `204 No Content` |

---

## 💡 Ejemplos de Uso

### 🔹 Crear un Paciente

**Request:**
```http
POST /api/paciente
Content-Type: application/json
```

```json
{
  "nombre": "Juan Pérez García",
  "edad": 35,
  "contacto": "+51987654321"
}
```

**Response `201 Created`:**
```json
{
  "pacienteId": 1,
  "nombre": "Juan Pérez García",
  "edad": 35,
  "contacto": "+51987654321"
}
```

---

### 🔹 Crear un Médico

**Request:**
```http
POST /api/medico
Content-Type: application/json
```

```json
{
  "nombre": "Dra. María López",
  "edad": 42,
  "especialidad": "Cardiología",
  "contacto": "+51912345678"
}
```

**Response `201 Created`:**
```json
{
  "medicoId": 1,
  "nombre": "Dra. María López",
  "especialidad": "Cardiología"
}
```

---

### 🔹 Crear una Cita

> ⚠️ El paciente y el médico deben existir previamente.

**Request:**
```http
POST /api/cita
Content-Type: application/json
```

```json
{
  "tipoCita": "Consulta cardiológica",
  "fecha": "2026-04-15T10:30:00",
  "pacienteId": 1,
  "medicoId": 1
}
```

**Response `201 Created`:**
```json
{
  "citaId": 1,
  "tipoCita": "Consulta cardiológica",
  "fecha": "2026-04-15T10:30:00",
  "estado": "Pendiente",
  "medicoNombre": "Dra. María López",
  "pacienteNombre": "Juan Pérez García",
  "obervaciones": "",
  "receta": ""
}
```

---

### 🔹 Reprogramar una Cita

**Request:**
```http
PUT /api/cita/1
Content-Type: application/json
```

```json
{
  "nuevaFecha": "2026-04-20T09:00:00"
}
```

**Response `200 OK`:**
```json
{
  "citaId": 1,
  "tipoCita": "Consulta cardiológica",
  "fecha": "2026-04-20T09:00:00",
  "estado": "Pendiente",
  "medicoNombre": "Dra. María López",
  "pacienteNombre": "Juan Pérez García",
  "obervaciones": "",
  "receta": ""
}
```

---

### 🔹 Completar una Cita

**Request:**
```http
PUT /api/cita/completar/1
Content-Type: application/json
```

```json
{
  "observaciones": "Paciente presenta arritmia leve. Se recomienda reposo.",
  "receta": "Atenolol 50mg — 1 tableta diaria por 30 días."
}
```

**Response `200 OK`:**
```json
{
  "citaId": 1,
  "tipoCita": "Consulta cardiológica",
  "fecha": "2026-04-20T09:00:00",
  "estado": "Completada",
  "medicoNombre": "Dra. María López",
  "pacienteNombre": "Juan Pérez García",
  "obervaciones": "Paciente presenta arritmia leve. Se recomienda reposo.",
  "receta": "Atenolol 50mg — 1 tableta diaria por 30 días."
}
```

---

### 🔹 Eliminar un Paciente

**Request:**
```http
DELETE /api/paciente/1
```

**Response `204 No Content`** (sin cuerpo de respuesta)

---

## ⚙️ Comportamiento de la API

### Validaciones de entrada

La API valida automáticamente los datos enviados mediante **Data Annotations**:

| Campo | Recurso | Validación |
|-------|---------|------------|
| `nombre` | Paciente / Médico | Requerido, máx. 100 / 50 caracteres |
| `edad` | Paciente / Médico | Requerido, rango entre 0 y 120 |
| `contacto` | Paciente / Médico | Requerido, formato de teléfono válido (ej: `+51987654321`) |
| `especialidad` | Médico | Requerido, máx. 100 caracteres |
| `tipoCita` | Cita | Requerido |
| `fecha` | Cita | Requerido, formato `ISO 8601`: `YYYY-MM-DDTHH:mm:ss` |
| `pacienteId` | Cita | Requerido, debe referirse a un paciente existente |
| `medicoId` | Cita | Requerido, debe referirse a un médico existente |
| `nuevaFecha` | Reprogramar Cita | Requerido, formato `DateTime` |
| `observaciones` | Completar Cita | Requerido |
| `receta` | Completar Cita | Requerido |

### Códigos de estado HTTP

| Código | Significado | Cuándo ocurre |
|--------|------------|---------------|
| `200 OK` | Éxito | GET, PUT exitosos |
| `201 Created` | Creado exitosamente | POST exitoso |
| `204 No Content` | Eliminado sin respuesta | DELETE exitoso |
| `400 Bad Request` | Solicitud inválida | Datos de entrada inválidos o mal formados |
| `404 Not Found` | Recurso no encontrado | ID de paciente, médico o cita no existe |
| `409 Conflict` | Conflicto de estado | Acción no permitida en el estado actual |
| `500 Internal Server Error` | Error del servidor | Error inesperado no controlado |

### Estado de las Citas

Las citas manejan un ciclo de vida basado en su campo `estado`:

```
Creada ──► Pendiente ──► Completada
               │
               ▼
           (Eliminada/Cancelada)
```

- **Pendiente:** Estado inicial al crear una cita.
- **Completada:** Luego de llamar a `PUT /api/cita/completar/{id}` con observaciones y receta.

---

## 🚨 Manejo de Errores

La API usa un **manejador global de excepciones** (`GlobalExceptionHandler`) que responde con el formato estándar [RFC 7807 Problem Details](https://datatracker.ietf.org/doc/html/rfc7807).

### Ejemplo — Recurso no encontrado (`404`)

**Request:**
```http
GET /api/paciente/999
```

**Response `404 Not Found`:**
```json
{
  "title": "No encontrado",
  "status": 404,
  "detail": "El paciente con id 999 no existe."
}
```

### Ejemplo — Validación fallida (`400`)

**Request:**
```http
POST /api/paciente
Content-Type: application/json

{
  "nombre": "",
  "edad": 200,
  "contacto": "no-es-telefono"
}
```

**Response `400 Bad Request`:**
```json
{
  "title": "Solicitud Errónea",
  "status": 400,
  "detail": "El campo nombre es obligatorio"
}
```

### Excepciones personalizadas

| Clase | Código HTTP | Uso |
|-------|-------------|-----|
| `NotFoundException` | `404` | Recurso no encontrado por ID |
| `BadRequestException` | `400` | Datos de entrada inválidos desde la lógica |
| `ConflictException` | `409` | Conflicto de estado o regla de negocio |

---

## 🧪 Pruebas con Postman

### Colección de Postman

Se adjunta la colección oficial de Postman con **todos los endpoints** preconfigurados para ejecutar pruebas funcionales de manera inmediata.

📂 **Archivo:** `ClinicaBackend.postman_collection.json` *(en la raíz del repositorio)*

> Para importar: abre Postman → **Import** → selecciona el archivo `.json`.

### Orden recomendado para las pruebas

Para garantizar la integridad referencial en la memoria, sigue este orden al ejecutar las pruebas:

```
1. POST /api/medico       → Crear médicos
2. POST /api/paciente     → Crear pacientes
3. POST /api/cita         → Crear cita (usar IDs del paso 1 y 2)
4. GET  /api/cita         → Verificar listado
5. PUT  /api/cita/{id}    → Reprogramar cita
6. PUT  /api/cita/completar/{id} → Completar cita
7. DELETE /api/cita/{id}  → Eliminar cita
```

### Resumen de pruebas funcionales realizadas

| # | Endpoint | Acción | Resultado esperado | Estado |
|---|----------|--------|--------------------|--------|
| 1 | `POST /api/paciente` | Crear paciente válido | `201 Created` con datos del paciente | ✅ |
| 2 | `POST /api/paciente` | Crear con nombre vacío | `400 Bad Request` | ✅ |
| 3 | `GET /api/paciente` | Listar todos | `200 OK` con array | ✅ |
| 4 | `GET /api/paciente/{id}` | ID existente | `200 OK` con datos | ✅ |
| 5 | `GET /api/paciente/{id}` | ID inexistente (999) | `404 Not Found` | ✅ |
| 6 | `PUT /api/paciente/{id}` | Actualizar datos | `200 OK` con datos actualizados | ✅ |
| 7 | `DELETE /api/paciente/{id}` | Eliminar existente | `204 No Content` | ✅ |
| 8 | `POST /api/medico` | Crear médico válido | `201 Created` | ✅ |
| 9 | `POST /api/medico` | Sin especialidad | `400 Bad Request` | ✅ |
| 10 | `GET /api/medico` | Listar todos | `200 OK` con array | ✅ |
| 11 | `POST /api/cita` | Cita con IDs válidos | `201 Created` estado `Pendiente` | ✅ |
| 12 | `POST /api/cita` | PacienteId inexistente | `404 Not Found` | ✅ |
| 13 | `PUT /api/cita/{id}` | Reprogramar fecha | `200 OK` con nueva fecha | ✅ |
| 14 | `PUT /api/cita/completar/{id}` | Completar con receta | `200 OK` estado `Completada` | ✅ |
| 15 | `DELETE /api/cita/{id}` | Cancelar cita | `204 No Content` | ✅ |

---

## 👤 Autor

**Joel** — Estudiante de Desarrollo de Servicios Web, IDAT  
📧 Repositorio: [github.com/JoelDev2002/clinica2.0backend](https://github.com/JoelDev2002/clinica2.0backend)

---

*Proyecto académico — IDAT · Curso: Desarrollo de Servicios Web · 2026*
