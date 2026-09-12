# EjercicioCuatro - Desafío 2 MDB
![El Salvador](https://img.shields.io/badge/Country-El%20Salvador-0047AB?style=for-the-badge)
![C#](https://img.shields.io/badge/C%23-239120?style=for-the-badge&logo=c-sharp&logoColor=white)
![NET](https://img.shields.io/badge/.NET-5C2D91?style=for-the-badge&logo=dotnet&logoColor=white)
![Windows Forms](https://img.shields.io/badge/Windows%20Forms-0078D6?style=for-the-badge&logo=windows&logoColor=white)
![SQL Server](https://img.shields.io/badge/SQL%20Server-CC2927?style=for-the-badge&logo=microsoftsqlserver&logoColor=white)

Práctica desarrollada en **C# (Windows Forms)** y **SQL Server**, enfocada en la gestión de un registro de alumnos y materias mediante operaciones CRUD, con una pantalla de inicio que permite elegir el mantenimiento a realizar.

## Características y Puntos Agregados

- **Pantalla de inicio (`FrmInicio`):**
  - Punto de entrada de la aplicación, con botones para acceder a cada mantenimiento (`btnMantenimientoAlumnos`, `btnMantenimientoMaterias`) y para salir de la aplicación (`btnSalirApp`), con confirmación previa.
  - Cada mantenimiento se abre como ventana modal (`ShowDialog()`), devolviendo el control a la pantalla de inicio al cerrarse.
- **Mantenimiento de Alumnos (`FrmPrincipal`):**
  - Sección de **búsqueda y edición** (`textnombre1`, `textapellido1`, etc.), oculta por defecto los botones y que se muestra al encontrar un registro.
  - Sección de **inserción de nuevos alumnos**, siempre visible.
  - **DataGridView** (`dataGridView1`) con el listado completo de alumnos, con estilo de filas alternadas y encabezados traducidos (Carnet, 1er Nombre, 2do Nombre, etc.), que se refresca automáticamente tras cada inserción, actualización o eliminación.
- **Mantenimiento de Materias (`FrmMaterias`):**
  - Misma lógica que Alumnos, aplicada a la tabla `Materia`: inserción, búsqueda por código, modificación y eliminación.
  - **DataGridView** (`dataGridViewMaterias`) con estilo propio y encabezados traducidos (Código, Materia, U.V., Prerrequisitos).
- **Mantenimiento y Operaciones CRUD (ambos formularios):**
  - **Insertar:** vía `SqlCommand` con parámetros para evitar inyección SQL.
  - **Buscar:** vía `SqlDataAdapter` / `SqlDataReader` filtrando por código.
  - **Actualizar:** en Alumnos vía `OleDbConnection` / `OleDbCommand`; en Materias vía `SqlCommand` parametrizado.
  - **Eliminar:** con validación de campo obligatorio y confirmación (`MessageBox`) antes de borrar el registro.
- **Botón de actualización manual del listado**, que vuelve a consultar la base de datos y refresca el `DataGridView` bajo demanda.
- **Validaciones de Interfaz:**
  - Verificación de campos obligatorios antes de insertar (código, nombres/apellidos en Alumnos; código y nombre en Materias).
  - Validación de que los campos numéricos (Edad, UV) contengan únicamente números.
- **Reseteo de formulario:**
  - Métodos `Reset()` / `ResetTab2()` que limpian y vuelven a ocultar los campos de edición tras cada operación exitosa.

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
    ├── Referencias/
    ├── App.config
    ├── EjercicioCuatro.csproj
    ├── conexion.cs
    ├── FrmInicio.cs
    ├── FrmInicio.Designer.cs
    ├── FrmMaterias.cs
    ├── FrmMaterias.Designer.cs
    ├── FrmPrincipal.cs
    ├── FrmPrincipal.Designer.cs
    └── Program.cs
```

## Ejecutar el proyecto

### Requisitos previos

- **Visual Studio** con la carga de trabajo **Desarrollo de escritorio de .NET**.
- **SQL Server** con la base de datos `db_tarea` creada (ver script arriba).

### Instrucciones

1. Clone o descargue este repositorio.
2. Abra el archivo de solución `EjercicioCuatro.slnx`.
3. Ajuste la cadena de conexión en `conexion.cs` (usada por `SqlConnection` en ambos formularios) y en `FrmPrincipal.cs` (usada por `OleDbConnection` en la actualización de Alumnos) con el nombre de su servidor y credenciales.
4. Presione **F5** para compilar y ejecutar. La aplicación abre primero `FrmInicio`, desde donde se accede a cada mantenimiento.

## Aviso

Esta aplicación fue desarrollada con fines académicos para la gestión de un registro de alumnos y materias, utilizando tecnologías de escritorio basadas en **C#**, **Windows Forms** y **SQL Server**.
