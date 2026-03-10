# Clinica Backend API

## Descripción del proyecto

Esta API RESTful fue desarrollada como parte del proyecto de la unidad "Desarrollo de Servicios Web" en IDAT. Su objetivo es gestionar de manera eficiente las citas médicas de una clínica privada, permitiendo registrar, consultar, actualizar y cancelar citas de pacientes. La aplicación está construida con **C#** y **.NET Core**, siguiendo buenas prácticas de arquitectura en capas (Controladores, Servicios, Modelos) y aplicando principios de diseño RESTful y programación orientada a objetos.

La persistencia de datos se simula mediante **listas en memoria** (`List<T>`), sin conexión a bases de datos externas, para propósitos educativos y de prueba.

---

## Estructura del proyecto
```
ClinicaAPI/
├── Controllers/ # Endpoints de la API
├── Services/ # Lógica de negocio
│ ├── Interfaces/ # Interfaces de servicios
├── Models/ # Clases de dominio: Paciente, Medico, Cita
├── Data/ # Simulación de persistencia (List<T>)
├── Middlewares/ # Manejo de excepciones
├── Program.cs # Configuración y arranque de la aplicación
└── README.md # Documentación del proyecto
```

---

## Funcionalidades principales

- Registrar, consultar, actualizar y eliminar citas médicas.
- Gestionar pacientes y médicos asociados a las citas.
- Validación de datos de entrada con anotaciones como `[Required]` y `[StringLength]`.
- Manejo centralizado de excepciones para respuestas consistentes.
- Simulación de persistencia usando listas en memoria (`List<T>`).

---

## Requisitos

- [.NET 10 SDK](https://dotnet.microsoft.com/download/dotnet/7.0)
- IDE recomendado: Visual Studio 2022 o Visual Studio Code

---

## Instalación y ejecución

1. Clonar el repositorio:

```bash
git clone https://github.com/tuusuario/clinica-backend.git
```

2. Abrir el proyecto en Visual Studio o Visual Studio Code.

3. Restaurar los paquetes NuGet:

```bash
dotnet restore
```

4. Ejecutar la aplicación:
```bash
dotnet run
```

5. La API estará disponible en https://localhost:7051/swagger/index.html

## Endpoints principales

| Método | Ruta | Descripción |
|--------|------|------------|
| GET    | /api/pacientes         | Listar todos los pacientes |
| GET    | /api/pacientes/{id}   | Obtener paciente por ID |
| POST   | /api/pacientes         | Registrar un nuevo paciente |
| PUT    | /api/pacientes/{id}    | Actualizar datos de paciente |
| DELETE | /api/pacientes/{id}    | Eliminar paciente |
| GET    | /api/medicos           | Listar médicos |
| GET    | /api/medicos/{id}      | Obtener médico por ID |
| POST   | /api/medicos           | Registrar nuevo médico |
| PUT    | /api/medicos/{id}      | Actualizar datos médico |
| DELETE | /api/medicos/{id}      | Eliminar médico |
| GET    | /api/citas             | Listar todas las citas |
| GET    | /api/citas/{id}        | Obtener cita por ID |
| POST   | /api/citas             | Registrar nueva cita |
| PUT    | /api/citas/{id}        | Actualizar cita |
| DELETE | /api/citas/{id}        | Cancelar cita |

> [!NOTE]
> Se recomienda probar los endpoints usando Postman o Swagger, y se incluyen ejemplos de JSON en la colección de Postman proporcionada.

## Ejemplos de uso

### Registrar un paciente:
```json
POST /api/pacientes
{
  "nombre": "Juan Perez",
  "edad": 30,
  "contacto": "juan.perez@mail.com"
}
```

### Registrar un paciente:

```json
POST /api/citas
{
  "tipoCita": "Consulta general",
  "observaciones": "Revisión anual",
  "fechaCita": "2026-02-05T10:30:00",
  "pacienteId": 1,
  "medicoId": 2
}
```

## Pruebas

- Se realizaron pruebas funcionales de todos los endpoints con Postman.

- Las capturas de las pruebas se incluyen en el informe técnico adjunto.

- Los códigos de respuesta HTTP son utilizados correctamente para cada operación (200, 201, 404, 400, etc.).
