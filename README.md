<div align="center">
  <h1>Tasa de Cambio SAP</h1>
  <p>La aplicación <strong>Tasa de Cambio SAP<strong> está diseñada para gestionar y actualizar las tasas de cambio en diferentes sociedades de SAP Business One de manera automatizada. Permite la validación y actualización de tasas de cambio de manera global para múltiples empresas, optimizando los procesos financieros y reduciendo el tiempo empleado en tareas manuales.</p>
  <img src="https://img.shields.io/badge/versión-1.0.0-blue">
  <img src="https://img.shields.io/github/languages/top/tommysvs/tasa-cambio-sap">
</div>

---

## Tabla de Contenido
- [Características principales](#características-principales)
- [Requisitos previos](#requisitos-previos)
- [Instalación](#instalación)
- [Uso](#uso)
- [Arquitectura del proyecto](#arquitectura-del-proyecto)
  - [Backend (`BE`)](#1-backend-be)
  - [Lógica de negocio (`LN`)](#2-lógica-de-negocio-ln)
  - [Interfaz gráfica (`GUI`)](#3-interfaz-gráfica-gui)
- [Detalles técnicos](#detalles-técnicos)
  - [Métodos clave](#métodos-clave)

## Características principales
- **Gestión centralizada:** Actualización de tasas de cambio para varias empresas desde una única interfaz.
- **Validación en tiempo real:** Verifica las tasas de cambio existentes antes de realizar actualizaciones.
- **Registros auditables:** Registro detallado de todas las operaciones realizadas en el sistema.
- **Interfaz intuitiva:** Una experiencia de usuario sencilla y accesible para usuarios no técnicos.
- **Generación de credenciales:** Uso de un aplicativo adicional para configurar y almacenar credenciales de manera segura.

## Requisitos previos
Antes de ejecutar la aplicación, asegúrate de contar con los siguientes requisitos:
- **.NET Framework:** Versión 4.7.
- **SAP Business One:** Instalado con las credenciales necesarias para acceso.
- **Controladores ODBC:** Configurados para conectarse a bases de datos HANA.
- **Visual Studio:** Para compilar y ejecutar el proyecto.
- **Aplicativo para generar credenciales:** 
  - Antes de usar esta aplicación, es necesario ejecutar un aplicativo adicional encargado de generar y almacenar las credenciales de manera segura en el Administrador de Credenciales de Windows.
  - Este aplicativo es esencial para que la aplicación principal funcione correctamente y no requiere que las credenciales se configuren manualmente en el proyecto.

## Instalación
Sigue estos pasos para instalar y configurar el proyecto:

1. **Clona este repositorio**:
   ```bash
   git clone https://github.com/tommysvs/tasa-cambio-sap.git
   cd tasa-cambio-sap
   ```

2. **Abre la solución en Visual Studio**:
   - Navega al archivo `TasaCambioSAP.sln` y ábrelo en Visual Studio.

3. **Restaura los paquetes NuGet**:
   - En Visual Studio, abre la Consola del Administrador de Paquetes y ejecuta:
     ```bash
     dotnet restore
     ```

4. **Ejecuta el aplicativo adicional para generar credenciales**:
   - Ejecuta el aplicativo proporcionado que genera y guarda las credenciales necesarias en el Administrador de Credenciales de Windows.
   - Este paso es obligatorio y asegura que las credenciales se manejen de manera segura.

5. **Compila la solución**:
   - Asegúrate de que no haya errores y compila el proyecto.

6. **Ejecuta la aplicación**:
   - Inicia el proyecto desde Visual Studio.

## Uso
Una vez que la aplicación esté en funcionamiento, sigue estos pasos:

1. **Inicio de sesión**:
   - Ingresa tus credenciales de SAP válidas. La aplicación recuperará automáticamente las credenciales almacenadas en el Administrador de Credenciales de Windows.
  
2. **Validación de tasas existentes**:
   - Revisa las tasas de cambio actuales para garantizar que estén actualizadas.

3. **Selección de empresas**:
   - Marca las empresas a las que deseas aplicar las actualizaciones de tasas de cambio.

4. **Actualización de tasas**:
   - Ingresa la nueva tasa de cambio y selecciona la fecha de vigencia.
   - Presiona el botón de "Actualizar" para aplicar los cambios.

5. **Seguimiento**:
   - Consulta los logs generados para verificar las operaciones realizadas.

## Arquitectura del proyecto
El proyecto utiliza una arquitectura de tres capas para garantizar modularidad y mantenibilidad:

### 1. **Backend (`BE`)**
   Contiene las entidades y modelos principales:
   - `csCompany.cs`: Modelo que representa los datos de conexión a una empresa en SAP.
   - `csORTT.cs`: Modelo que encapsula los datos relacionados con las tasas de cambio.

### 2. **Lógica de negocio (`LN`)**
   Implementa la lógica central del proyecto:
   - `csConnection.cs`: Maneja las conexiones con bases de datos HANA utilizando ODBC.
   - `csSAP.cs`: Proporciona métodos para interactuar con SAP Business One, como la conexión, validación de usuarios y actualización de tasas.
   - `csCompanies.cs`: Administra las empresas disponibles y sus configuraciones.

### 3. **Interfaz gráfica (`GUI`)**
   Proporciona la experiencia de usuario:
   - `Program.cs`: Punto de entrada principal de la aplicación.
   - `RateScreen.cs`: Pantalla principal para la gestión de tasas de cambio.
   - `VerticalSeparator.cs`: Control personalizado para separar visualmente secciones en la interfaz.

## Detalles técnicos
### Métodos clave
A continuación, se destacan algunos métodos importantes implementados en el proyecto:

#### `csSAP.cs`
- **`ConnectSAP(csCompany objCompany)`**:
  - Establece una conexión con SAP utilizando los datos de la compañía.
  - Verifica la validez de las credenciales y retorna un `true` si la conexión es exitosa.

- **`AddRate(ref csORTT objORTT)`**:
  - Agrega una nueva tasa de cambio en SAP para una moneda y fecha específicas.
 
- **`GetRate(string currency, DateTime date)`**:
  - Recupera la tasa de cambio actual para una moneda específica y una fecha determinada desde SAP.

- **`ValidateUser(string usersap)`**:
  - Verifica si el usuario especificado tiene permisos para acceder a la aplicación.

#### `RateScreen.cs`
- **`LoadCredentials()`**:
  - Recupera automáticamente las credenciales almacenadas en el Administrador de Credenciales de Windows.

- **`GetRate(string bd)`**:
  - Recupera la tasa de cambio actual para la base de datos especificada.

- **`UpdateRate(string bd)`**:
  - Actualiza la tasa de cambio en la base de datos seleccionada basándose en la entrada del usuario.

- **Eventos**:
  - `btnLogin_Click`: Controla el inicio de sesión del usuario.
  - `btnValidate_Click`: Valida las tasas actuales para las empresas seleccionadas.
  - `btnUpdate_Click`: Realiza la actualización de las tasas ingresadas por el usuario.
