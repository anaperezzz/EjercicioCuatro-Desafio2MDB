# EjercicioCuatro - Desafío 2 MDB
![El Salvador](https://img.shields.io/badge/Country-El%20Salvador-0047AB?style=for-the-badge)
![C#](https://img.shields.io/badge/C%23-239120?style=for-the-badge&logo=c-sharp&logoColor=white)
![NET](https://img.shields.io/badge/.NET-5C2D91?style=for-the-badge&logo=dotnet&logoColor=white)
![Windows Forms](https://img.shields.io/badge/Windows%20Forms-0078D6?style=for-the-badge&logo=windows&logoColor=white)
![SQL Server](https://img.shields.io/badge/SQL%20Server-CC2927?style=for-the-badge&logo=microsoftsqlserver&logoColor=white)
 
Práctica desarrollada en **C# (Windows Forms)** y **SQL Server**, enfocada en la gestión de un registro de alumnos mediante operaciones CRUD y el manejo de dos formas de conexión a base de datos (`SqlConnection` y `OleDbConnection`) 
 
## Características y Puntos Agregados
 
- **Formulario único con dos secciones (`FrmPrincipal`):**
  - Una sección de **búsqueda y edición** (`textnombre1`, `textapellido1`, etc.), oculta por defecto y que solo se muestra al encontrar un registro.
  - Una sección de **inserción de nuevos alumnos** (`textnombre2`, `textapellido2`, etc.), siempre visible.
- **Búsqueda por código de alumno:**
  - Al buscar un `CodigoAlumno`, se llena dinámicamente la sección de edición y se habilita el botón **Modificar**.
- **Mantenimiento y Operaciones CRUD:**
  - **Insertar:** vía `SqlCommand` con parámetros (`@codigo`, `@pnombre`, `@snombre`, etc.) para evitar inyección SQL.
  - **Buscar:** vía `SqlDataAdapter` / `SqlDataReader` filtrando por `CodigoAlumno`.
  - **Actualizar:** vía `OleDbConnection` / `OleDbCommand`, concatenando directamente los valores en la sentencia SQL.
- **Validaciones de Interfaz:**
  - Verificación de campos obligatorios (código, primer nombre, primer apellido) antes de insertar.
  - Validación de que el campo Edad contenga únicamente valores numéricos.
- **Reseteo de formulario:**
  - Método `Reset()` que limpia y vuelve a ocultar los campos de edición tras una actualización exitosa.
## Base de datos
 
Script de creación de la base `db_tarea`, con las tablas `Materia` y `Alumno`:
 
```sql
CREATE DATABASE db_tarea
GO
 
USE db_tarea
GO
 
CREATE TABLE Materia (
    CodigoMateria CHAR(5) NOT NULL PRIMARY KEY,
    NombreMateria VARCHAR(25) NULL,
    UV INT NULL,
    Prerrequisitos VARCHAR(150) NULL
);
 
CREATE TABLE Alumno (
    CodigoAlumno CHAR(8) NOT NULL PRIMARY KEY,
    PrimerNombre VARCHAR(20) NULL,
    SegundoNombre VARCHAR(20) NOT NULL,
    PrimerApellido VARCHAR(20) NULL,
    SegundoApellido VARCHAR(20) NOT NULL,
    Edad INT NULL,
    Direccion VARCHAR(100) NULL
);
```
 
## Estructura del proyecto
 
```text
.
├── EjercicioCuatro.slnx
├── Ejercicio04.sql
└── EjercicioCuatro/
    ├── Properties/
    │   └── AssemblyInfo.cs
    ├── App.config
    ├── EjercicioCuatro.csproj
    ├── FrmPrincipal.Designer.cs
    ├── FrmPrincipal.cs
    ├── FrmPrincipal.resx
    ├── Program.cs
    └── conexion.cs
```
 
## Ejecutar el proyecto
 
### Requisitos previos
 
- **Visual Studio** con la carga de trabajo **Desarrollo de escritorio de .NET**.
- **SQL Server** con la base de datos `db_tarea` creada (ver script arriba).
### Instrucciones
 
1. Clone o descargue este repositorio.
2. Abra el archivo de solución `EjercicioCuatro.slnx`.
3. Ajuste la cadena de conexión en `conexion.cs` (usada por `SqlConnection`) y en `FrmPrincipal.cs` (usada por `OleDbConnection`) con el nombre de su servidor y credenciales.
4. Presione **F5** para compilar y ejecutar.

## Aviso
 
Esta aplicación fue desarrollada con fines académicos para la gestión de un registro de alumnos, utilizando tecnologías de escritorio basadas en **C#**, **Windows Forms** y **SQL Server**.
 
