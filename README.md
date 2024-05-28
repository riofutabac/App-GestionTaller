# Sistema de Gestión de Talleres

Este proyecto es una aplicación de escritorio desarrollada en C# con Windows Forms. Está diseñada para gestionar la operación de un taller automotriz, incluyendo la administración de clientes, vehículos, empleados, reparaciones y repuestos.

## Características

- **Gestión de Clientes**: Añadir, editar y eliminar clientes.
- **Gestión de Vehículos**: Registro y mantenimiento de información de vehículos.
- **Gestión de Empleados**: Administrar los datos de los empleados, incluyendo su registro, edición y eliminación.
- **Gestión de Reparaciones**: Registrar y seguir las reparaciones realizadas en los vehículos.
- **Gestión de Repuestos**: Control de inventario de los repuestos utilizados en las reparaciones.

## Dependencias

Este proyecto requiere las siguientes dependencias para su ejecución:

- **.NET Framework**: Versión 4.7.2 o superior.
- **SQL Server**: Para la gestión de la base de datos.

## Configuración y Ejecución

### Clonar el repositorio

```bash
git clone 
cd gestion_talleres
```

### Configuración de la Base de Datos

1. Asegúrate de tener SQL Server instalado y configurado.
2. Crea la base de datos utilizando los scripts SQL proporcionados en el directorio `Database`.
3. Actualiza las cadenas de conexión en los archivos de configuración para apuntar a tu instancia de SQL Server.

### Compilación y Ejecución

Utiliza Visual Studio para abrir el archivo de solución `.sln`.

1. Abre Visual Studio.
2. Navega a `Archivo` > `Abrir` > `Proyecto/Solución`.
3. Selecciona el archivo de solución `.sln` del directorio clonado.
4. Compila el proyecto yendo a `Compilar` > `Compilar Solución`.
5. Ejecuta el proyecto presionando `F5` o haciendo clic en `Iniciar`.

## Uso de la Aplicación

La aplicación tiene una interfaz de usuario basada en formularios donde puedes seleccionar diferentes secciones como clientes, vehículos, etc., desde el menú principal.




