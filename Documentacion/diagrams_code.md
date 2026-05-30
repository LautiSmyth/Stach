# Código de Diagramas UML y DER (Mermaid)

Este documento contiene los códigos fuente de todos los diagramas del sistema **Stach**, escritos **100% en formato Mermaid** para garantizar total compatibilidad con visualizadores gratuitos en línea como [Mermaid Live Editor](https://mermaid.live).

---

# PARTE 1: ENTREGA 1 (SPRINT 1)

## T01. Arquitectura Base

### A. Diagrama de Componentes de la Arquitectura (Mermaid Flowchart)
Representa la relación de dependencias y el flujo transversal de llamadas entre las 6 capas.
```mermaid
flowchart TD
    GUI[GUI - Presentación]
    IoC[IoC - Composición]
    BLL[BLL - Negocio]
    Servicios[Servicios - Transversal]
    Abstracciones[Abstracciones - Contratos]
    DAL[DAL - Persistencia]
    BE[BE - Entidades]

    GUI --> IoC
    GUI --> BLL
    GUI --> Abstracciones
    GUI --> BE

    IoC --> BLL
    IoC --> DAL
    IoC --> Servicios
    IoC --> Abstracciones
    IoC --> BE

    BLL --> Abstracciones
    BLL --> BE

    Servicios --> Abstracciones
    Servicios --> BE

    DAL --> Abstracciones
    DAL --> BE
```

### B. Diagrama de Secuencia - Persistencia Genérica (Mermaid)
```mermaid
sequenceDiagram
    autonumber
    participant GUI as Form / Presentación
    participant BLL as Logic (BLL)
    participant DAL as Repository (DAL)
    participant Acc as Acceso (Singleton)
    participant DB as SQL Server

    GUI->>BLL: RegistrarEntidad(objetoBE)
    BLL->>BLL: Validar Reglas de Negocio
    BLL->>DAL: Insertar(objetoBE)
    DAL->>Acc: Escribir(consultaSQL, parametros)
    Acc->>DB: ExecuteNonQuery()
    DB-->>Acc: Filas Afectadas
    Acc-->>DAL: Entero
    DAL-->>BLL: Ok (ID Asignado)
    BLL-->>GUI: Éxito
```

### C. Diagrama de Secuencia - Consulta Genérica (Mermaid)
```mermaid
sequenceDiagram
    autonumber
    participant GUI as Form / Presentación
    participant BLL as Logic (BLL)
    participant DAL as Repository (DAL)
    participant Acc as Acceso (Singleton)
    participant DB as SQL Server

    GUI->>BLL: ObtenerListado()
    BLL->>DAL: ObtenerTodos()
    DAL->>Acc: Leer(consultaSQL, parametros)
    Acc->>DB: Fill(dataTable)
    DB-->>Acc: DataTable lleno
    Acc-->>DAL: DataTable
    DAL->>DAL: Mapear DataTable a List<EntidadBE>
    DAL-->>BLL: List<EntidadBE>
    BLL-->>GUI: List<EntidadBE>
```

### D. Mapa Tentativo de Navegación (Mermaid State)
```mermaid
stateDiagram-v2
    [*] --> PantallaLogin : Iniciar Aplicación
    PantallaLogin --> MenuPrincipal : Login Exitoso (SessionManager)
    PantallaLogin --> [*] : Salir / Cancelar

    state MenuPrincipal {
        [*] --> FormularioMDI
        FormularioMDI --> GestionUsuarios : Click Usuarios
        FormularioMDI --> GestionPermisos : Click Permisos
        FormularioMDI --> VerBitacora : Click Bitácora
        FormularioMDI --> ControlCambios : Click Auditoría
        FormularioMDI --> GestionBackup : Click Resguardo
        FormularioMDI --> CambiarIdioma : Click Config. Idioma
    }

    MenuPrincipal --> PantallaLogin : Cerrar Sesión (Logout)
```

---

## T02. Gestión de Login / Logout y Gestión de Usuarios

### A. Diagrama de Clases del Módulo (Mermaid Class)
```mermaid
classDiagram
    class LoginForm {
        -IUsuarioBLL _usuarioBll
        -btnIngresar_Click()
    }
    class SessionManager {
        -static SessionManager _instance
        +Usuario Usuario
        +Login(Usuario u) void
        +Logout() void
    }
    class UsuarioBLL {
        -IUsuarioDAL _dal
        +Login(string user, string pass) void
    }
    class UsuarioDAL {
        -Acceso _acceso
        +ObtenerPorUsername(string u) Usuario
    }
    class Usuario {
        +int IdUsuario
        +string Username
        +string PasswordHash
    }
    LoginForm --> UsuarioBLL
    UsuarioBLL --> SessionManager
    UsuarioBLL --> UsuarioDAL
    UsuarioDAL --> Usuario
```

### B. Diagrama de Secuencia - Login (Mermaid)
```mermaid
sequenceDiagram
    autonumber
    actor Admin as Usuario / Admin
    participant GUI as LoginForm
    participant BLL as UsuarioBLL
    participant DAL as UsuarioDAL
    participant DB as Base de Datos

    Admin->>GUI: Ingresa Credenciales (Click Ingresar)
    GUI->>BLL: Login("Login", username, password)
    BLL->>DAL: ObtenerPorUsername(username)
    DAL->>DB: SELECT * FROM Usuario WHERE Username = ...
    DB-->>DAL: Fila de Usuario
    DAL-->>BLL: Objeto Usuario
    BLL->>BLL: Verificar contraseña con PBKDF2 (100k iteraciones)
    BLL->>BLL: ValidarEstado(usuario)
    BLL-->>GUI: Éxito
    GUI->>SessionManager: Login(usuario)
    GUI-->>Admin: Muestra Pantalla de Menú MDI
```

### C. Diagrama de Secuencia - Logout (Mermaid)
```mermaid
sequenceDiagram
    autonumber
    actor Admin as Usuario
    participant GUI as MenuForm
    participant Srv as SessionManager
    participant Bit as BitacoraService

    Admin->>GUI: Click en "Cerrar Sesión"
    GUI->>Bit: Registrar("Logout", "Cierre de sesión", true)
    Bit-->>GUI: Ok
    GUI->>Srv: Logout()
    Srv-->>GUI: Ok (Usuario seteado en null)
    GUI->>GUI: Reiniciar Aplicación (Abre LoginForm)
```

---

## T06a. Gestión de Bitácora

### A. Diagrama de Clases del Módulo (Mermaid Class)
```mermaid
classDiagram
    class BitacoraForm {
        -IBitacoraService _bitacora
        -btnBuscar_Click()
    }
    class BitacoraService {
        -IBitacoraDAL _dal
        +Registrar(string modulo, string actividad, string det, bool ex) void
    }
    class BitacoraDAL {
        -Acceso _acceso
        +Insertar(Bitacora b) void
    }
    class Bitacora {
        +int IdBitacora
        +DateTime Fecha
        +string Username
        +string Modulo
        +string Actividad
        +NivelCriticidad Criticidad
    }
    BitacoraForm --> BitacoraService
    BitacoraService --> BitacoraDAL
    BitacoraDAL --> Bitacora
```

### B. Diagrama de Secuencia - Registro en Bitácora Genérico (Mermaid)
```mermaid
sequenceDiagram
    autonumber
    participant App as BLL / Servicio
    participant Srv as BitacoraService
    participant Session as SessionManager
    participant DAL as BitacoraDAL
    participant DB as SQL Server

    App->>Srv: Registrar(modulo, actividad, detalle, ex)
    Srv->>Session: ObtenerUsuarioLogueado()
    Session-->>Srv: Objeto Usuario (username)
    Srv->>Srv: Determinar criticidad por diccionario
    Srv->>DAL: Insertar(entidadBitacora)
    DAL->>DB: INSERT INTO Bitacora VALUES (...)
    DB-->>DAL: Ok
```

---

## T03. Gestión de Encriptado

### A. Diagrama de Clases del Módulo (Mermaid Class)
```mermaid
classDiagram
    class IEncriptador {
        <<interface>>
        +Hash(string texto) string
        +Verificar(string texto, string hash) bool
    }
    class Encriptador {
        +Hash(string texto) string
        +Verificar(string texto, string hash) bool
    }
    class CifradorHelper {
        +CifrarArchivo(string src, string dst, string pass) static void
        +DescifrarArchivo(string src, string dst, string pass) static void
    }
    IEncriptador <|.. Encriptador
```

---
---

# PARTE 2: ENTREGA 2 (SPRINT 2)

## T07. Gestión de Dígitos Verificadores (DV)

### A. Diagrama de Clases del Módulo (Mermaid Class)
```mermaid
classDiagram
    class Program {
        +Main() static void
    }
    class DigitoVerificadorService {
        -IDigitoVerificadorDAL _dal
        -IUsuarioDAL _usuarioDal
        +VerificarIntegridad() bool
        +InicializarDVs() void
    }
    class DigitoVerificadorDAL {
        -Acceso _acceso
        +ObtenerDVV(string tabla) string
    }
    Program --> DigitoVerificadorService
    DigitoVerificadorService --> DigitoVerificadorDAL
```

### B. Diagrama de Secuencia - Verificación en Arranque (Mermaid)
```mermaid
sequenceDiagram
    autonumber
    participant Init as Program.cs
    participant Srv as DigitoVerificadorService
    participant UDAL as UsuarioDAL
    participant DAL as DigitoVerificadorDAL
    participant DB as Base de Datos
    participant GUI as RestauracionForm

    Init->>Srv: VerificarIntegridad()
    Srv->>UDAL: ObtenerTodos()
    UDAL->>DB: SELECT * FROM Usuario
    DB-->>UDAL: Lista de Usuarios
    UDAL-->>Srv: Lista de Usuarios
    Srv->>Srv: Recalcular y comparar DVH individual
    Srv->>DAL: ObtenerDVV("Usuario")
    DAL->>DB: SELECT DVV FROM DigitoVerificador WHERE Tabla = 'Usuario'
    DB-->>DAL: Hash DVV Guardado
    DAL-->>Srv: Hash DVV Guardado
    Srv->>Srv: Calcular DVV global de la tabla y comparar
    Srv-->>Init: Retorna false (Integridad violada)
    Init->>GUI: new RestauracionForm(errores).ShowDialog()
    GUI-->>Init: Abre panel de restauración obligatoria
```

---

## T04. Gestión de Perfiles de Usuario (Patrón Composite)

### A. Diagrama de Clases del Módulo - Patrón Composite (Mermaid Class)
```mermaid
classDiagram
    class ComponentePermiso {
        <<abstract>>
        +int IdPermiso
        +string Nombre
        +string PermisoKey
        +abstract List~ComponentePermiso~ Hijos
        +abstract string NombreMostrar
        +abstract Agregar(ComponentePermiso c) void
        +abstract Quitar(ComponentePermiso c) void
        +abstract ObtenerPatentes(List~Patente~ ac, HashSet~int~ vis) void
    }
    class Patente {
        +List~ComponentePermiso~ Hijos
        +string NombreMostrar
        +Agregar(ComponentePermiso c) void
        +Quitar(ComponentePermiso c) void
        +ObtenerPatentes(List~Patente~ ac, HashSet~int~ vis) void
    }
    class Familia {
        -List~ComponentePermiso~ _hijos
        +List~ComponentePermiso~ Hijos
        +string NombreMostrar
        +Agregar(ComponentePermiso c) void
        +Quitar(ComponentePermiso c) void
        +ObtenerPatentes(List~Patente~ ac, HashSet~int~ vis) void
    }
    ComponentePermiso <|-- Patente
    ComponentePermiso <|-- Familia
    Familia "1" o-- "0..*" ComponentePermiso : Hijos
```

### B. Diagrama de Secuencia - Asignación de Permisos (Mermaid)
```mermaid
sequenceDiagram
    autonumber
    actor Admin as Administrador
    participant GUI as PermisosForm
    participant BLL as PermisoBLL
    participant DAL as PermisoDAL
    participant DB as Base de Datos

    Admin->>GUI: Selecciona Permisos y hace clic en "Guardar Relaciones"
    GUI->>BLL: GuardarRelaciones(modulo, familiaObjeto)
    BLL->>DAL: GuardarRelaciones(familiaObjeto)
    DAL->>DB: DELETE FROM PermisoRelacion WHERE IdPadre = ...
    DAL->>DB: INSERT INTO PermisoRelacion (IdPadre, IdHijo) VALUES (...)
    DB-->>DAL: Ok
    BLL-->>GUI: Éxito
    GUI-->>Admin: Muestra Mensaje "Permisos guardados con éxito"
```

---

## T06b. Control de Cambios

### A. Diagrama de Clases del Módulo (Mermaid Class)
```mermaid
classDiagram
    class ControlCambiosForm {
        -IVersionUsuarioBLL _versionBll
    }
    class VersionUsuarioBLL {
        -IVersionUsuarioDAL _dal
        -IUsuarioDAL _usuarioDal
        +RestaurarVersion(int idVersion) void
    }
    class VersionUsuarioDAL {
        -Acceso _acceso
        +ObtenerPorId(int id) VersionUsuario
    }
    class VersionUsuario {
        +int IdVersion
        +int IdUsuario
        +string Username
        +EstadoUsuario Estado
        +DateTime FechaModificacion
    }
    ControlCambiosForm --> VersionUsuarioBLL
    VersionUsuarioBLL --> VersionUsuarioDAL
    VersionUsuarioDAL --> VersionUsuario
```

### B. Diagrama de Secuencia - Recomposición / Rollback (Mermaid)
```mermaid
sequenceDiagram
    autonumber
    actor Admin as Administrador
    participant GUI as ControlCambiosForm
    participant BLL as VersionUsuarioBLL
    participant DAL as VersionUsuarioDAL
    participant UDAL as UsuarioDAL
    participant DB as Base de Datos

    Admin->>GUI: Selecciona Versión e Inicia Rollback
    GUI->>BLL: RestaurarVersion("Rollback", idVersion, actor)
    BLL->>DAL: ObtenerPorId(idVersion)
    DAL->>DB: SELECT * FROM VersionUsuario WHERE IdVersion = ...
    DB-->>DAL: Fila de Versión
    DAL-->>BLL: Objeto VersionUsuario
    BLL->>UDAL: ObtenerPorId(idUsuario)
    UDAL-->>BLL: Objeto Usuario
    BLL->>UDAL: Actualizar(usuarioConDatosDeVersion)
    UDAL->>DB: UPDATE Usuario SET Username = ..., PasswordHash = ... WHERE IdUsuario = ...
    DB-->>UDAL: Ok
    BLL-->>GUI: Recomposición Exitosa
    GUI-->>Admin: Mensaje "Usuario restaurado a versión histórica"
```

---

## T05. Gestión de Múltiples Idiomas

### A. Diagrama de Clases del Módulo - Patrón Observer (Mermaid Class)
```mermaid
classDiagram
    class IObserver {
        <<interface>>
        +ActualizarIdioma() void
    }
    class IManejadorIdioma {
        <<interface>>
        +Suscribir(IObserver obs) void
        +Desuscribir(IObserver obs) void
        +Notificar() void
    }
    class ManejadorIdioma {
        -static ManejadorIdioma _instance
        -List~IObserver~ _observadores
        +Suscribir(IObserver obs) void
        +Desuscribir(IObserver obs) void
        +Notificar() void
    }
    class MenuForm {
        +ActualizarIdioma() void
    }
    IManejadorIdioma <|.. ManejadorIdioma
    IObserver <|.. MenuForm
    ManejadorIdioma "1" o-- "0..*" IObserver : _observadores
```

### B. Diagrama de Secuencia - Cambio Dinámico de Idioma (Mermaid)
```mermaid
sequenceDiagram
    autonumber
    actor Admin as Administrador
    participant GUI as MenuForm
    participant Srv as ManejadorIdioma
    participant Obs as Formularios Activos (IObserver)

    Admin->>GUI: Selecciona Idioma desde Menu
    GUI->>Srv: CambiarIdioma(nuevoIdioma)
    Srv->>Srv: Cargar traducciones del idioma en memoria
    Srv->>Srv: Notificar()
    loop Por cada observador en _observadores
        Srv->>Obs: ActualizarIdioma()
        Obs->>Srv: ObtenerTexto(leyendaKey)
        Srv-->>Obs: Texto traducido
        Obs->>Obs: Modificar Text de los Controles (Labels/Buttons)
    end
    Srv-->>GUI: Completado
```

---
---

# PARTE 3: INTEGRACIONES GENERALES (G06 Y G07)

## G06. Diagramas de Clases por Capas (Mermaid Class)

A continuación, los diagramas parciales separados por capas para cumplir con la especificación de separar infraestructura de negocio.

### Capa 1: Presentación (GUI)
```mermaid
classDiagram
    class Program {
        +Main() static void
    }
    class LoginForm {
        -IUsuarioBLL _usuarioBll
        -LoginForm_Load()
        -btnIngresar_Click()
    }
    class MenuForm {
        -ISessionManager _sessionManager
        -IManejadorIdioma _manejadorIdioma
    }
    class UsuariosForm
    class PermisosForm
    class BitacoraForm
    class ControlCambiosForm
    class BackupForm
    class IdiomaForm
    class RestauracionForm
    LoginForm --> Program
    MenuForm --> LoginForm
```

### Capa 2: Lógica de Negocio (BLL)
```mermaid
classDiagram
    class UsuarioBLL {
        -IUsuarioDAL _dal
        -IPermisoDAL _permisoDal
        -IDigitoVerificadorService _dvService
        +Login() void
        +Logout() void
    }
    class PermisoBLL {
        -IPermisoDAL _dal
        +ResolverPatentes() List~Patente~
    }
    class IdiomaBLL {
        -IIdiomaDAL _dal
    }
    class TraduccionBLL {
        -ITraduccionDAL _dal
    }
    class VersionUsuarioBLL {
        -IVersionUsuarioDAL _dal
        -IUsuarioDAL _usuarioDal
    }
```

### Capa 3: Servicios (Aspectos Transversales)
```mermaid
classDiagram
    class SessionManager {
        -static SessionManager _instance
        +Usuario Usuario
        +Login(Usuario u) void
        +Logout() void
    }
    class Encriptador {
        +Hash(string pwd) string
    }
    class CifradorHelper {
        +CifrarArchivo() static void
    }
    class ManejadorIdioma {
        -static ManejadorIdioma _instance
        -List~IObserver~ _observadores
    }
    class BitacoraService {
        -IBitacoraDAL _dal
    }
    class DigitoVerificadorService {
        -IDigitoVerificadorDAL _dal
    }
    class BackupService {
        -IBackupDAL _dal
    }
```

### Capa 4: Acceso a Datos (DAL)
```mermaid
classDiagram
    class Acceso {
        -static Acceso _instance
        +Leer() DataTable
        +Escribir() int
    }
    class UsuarioDAL
    class PermisoDAL
    class IdiomaDAL
    class TraduccionDAL
    class BitacoraDAL
    class VersionUsuarioDAL
    class BackupDAL
    class DigitoVerificadorDAL
    UsuarioDAL --> Acceso
    PermisoDAL --> Acceso
```

### Capa 5: Abstracciones (Contratos e IoC)
```mermaid
classDiagram
    class IUsuarioDAL { <<interface>> }
    class IPermisoDAL { <<interface>> }
    class IIdiomaDAL { <<interface>> }
    class ITraduccionDAL { <<interface>> }
    class IBitacoraDAL { <<interface>> }
    class IVersionUsuarioDAL { <<interface>> }
    class IBackupDAL { <<interface>> }
    class IDigitoVerificadorDAL { <<interface>> }
    class IoCContainer {
        -static Dictionary~Type_object~ _registros
        +Registrar() static void
        +Resolve() static T
    }
```

### Capa 6: Entidades de Negocio (BE)
```mermaid
classDiagram
    class Usuario
    class VersionUsuario
    class Bitacora
    class Idioma
    class Traduccion
    class Componente
    class ComponentePermiso { <<abstract>> }
    class Patente
    class Familia
    ComponentePermiso <|-- Patente
    ComponentePermiso <|-- Familia
```

---

## G07. Modelo de Datos Relacional - DER Pata de Gallo (Mermaid)

```mermaid
erDiagram
    Usuario ||--o{ HistorialUsuario : "tiene historial"
    Usuario ||--o{ Bitacora : "registra acciones"
    Idioma ||--o{ Traduccion : "tiene"
    Componente ||--o{ Traduccion : "traducido en"
    Usuario ||--o{ UsuarioPermiso : "asignado"
    Permiso ||--o{ UsuarioPermiso : "contiene"
    Permiso ||--o{ PermisoRelacion : "es padre de"
    Permiso ||--o{ PermisoRelacion : "es hijo de"

    Usuario {
        int IdUsuario PK
        string Username
        string PasswordHash
        int Estado
        datetime FechaAlta
        datetime UltimoLogin
        string DVH
    }

    HistorialUsuario {
        int IdVersion PK
        int IdUsuario FK
        string Username
        int Estado
        datetime FechaModificacion
        string ModificadoPor
        string DetalleCambios
    }

    Bitacora {
        int IdBitacora PK
        datetime Fecha
        int IdUsuario FK
        string Username
        string Modulo
        string Actividad
        int Criticidad
        bool Exitoso
        string Detalle
        string Error
    }

    Idioma {
        int IdIdioma PK
        string Nombre
        string Codigo
        bool Default
    }

    Componente {
        int IdComponente PK
        string Nombre
    }

    Traduccion {
        int IdIdioma PK, FK
        int IdComponente PK, FK
        string Texto
    }

    Permiso {
        int IdPermiso PK
        string Nombre
        string PermisoKey
        bool EsFamilia
    }

    PermisoRelacion {
        int IdPermisoPadre PK, FK
        int IdPermisoHijo PK, FK
    }

    UsuarioPermiso {
        int IdUsuario PK, FK
        int IdPermiso PK, FK
    }

    DigitoVerificador {
        string Tabla PK
        string DVV
    }
```
