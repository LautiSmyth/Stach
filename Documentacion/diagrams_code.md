# Código de Diagramas UML y DER (Mermaid)

Este documento contiene los códigos fuente de todos los diagramas del sistema **Stach**, escritos **100% en formato Mermaid** para garantizar total compatibilidad con visualizadores gratuitos en línea como [Mermaid Live Editor](https://mermaid.live).

---

# PARTE 1: ENTREGA 1 (SPRINT 1)

## T01. Arquitectura Base

### A. Diagrama de Componentes de la Arquitectura (Mermaid Flowchart)
Representa la relación de dependencias y el flujo transversal de llamadas entre las 6 capas con estilo de colores y bordes.
```mermaid
---
config:
  layout: elk
---
graph TD
    GUI["GUI.exe<br/>(executable)"]
    IoC["IoC.dll<br/>(library)"]
    BLL["BLL.dll<br/>(library)"]
    DAL["DAL.dll<br/>(library)"]
    Servicios["Servicios.dll<br/>(library)"]
    Abstracciones["Abstracciones.dll<br/>(library)"]
    BE["BE.dll<br/>(library)"]
    
    GUI -.->|Referencia| BLL
    GUI -.->|Referencia| IoC
    GUI -.->|Referencia| Abstracciones
    GUI -.->|Referencia| BE
    IoC -.->|Referencia| BLL
    IoC -.->|Referencia| DAL
    IoC -.->|Referencia| Servicios
    IoC -.->|Referencia| Abstracciones
    IoC -.->|Referencia| BE
    BLL -.->|Referencia| Abstracciones
    BLL -.->|Referencia| BE
    DAL -.->|Referencia| Abstracciones
    DAL -.->|Referencia| BE
    Servicios -.->|Referencia| Abstracciones
    Servicios -.->|Referencia| BE
    Abstracciones -.->|Referencia| BE
    
    classDef executable fill:#eef2ff,stroke:#818cf8,color:#1e1b4b
    classDef library fill:#f0fdf4,stroke:#4ade80,color:#1b3a1b
    classDef core fill:#f5f3ff,stroke:#a78bfa,color:#2e1065
    
    class GUI executable
    class IoC,BLL,DAL,Servicios library
    class Abstracciones,BE core
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
---
config:
  layout: elk
---
graph TD
    Login["LoginForm<br/>(Login)"]
    Menu["MenuForm<br/>(Menú MDI)"]
    Usuarios["UsuariosForm<br/>(Gestión Usuarios)"]
    Permisos["PermisosForm<br/>(Gestión Permisos)"]
    Bitacora["BitacoraForm<br/>(Consulta Bitácora)"]
    Cambios["ControlCambiosForm<br/>(Control Cambios)"]
    Backup["BackupForm<br/>(Resguardo/Restauración)"]
    Idioma["IdiomaForm<br/>(Gestión Idiomas)"]
    Restaurar["RestauracionForm<br/>(Restauración Obligatoria)"]

    Login -->|Login Exitoso| Menu
    Menu -->|Cerrar Sesión| Login
    Menu --> Usuarios
    Menu --> Permisos
    Menu --> Bitacora
    Menu --> Cambios
    Menu --> Backup
    Menu --> Idioma
    Restaurar -->|Restauración Exitosa| Login
```

---

## T02. Gestión de Login / Logout y Gestión de Usuarios

### A. Diagrama de Clases del Módulo (Mermaid Class)
```mermaid
---
config:
  layout: elk
---
classDiagram
    class LoginForm {
        -IUsuarioBLL _usuarioBll
        -void btnIngresar_Click()
    }
    class SessionManager {
        -static SessionManager _instance
        +Usuario Usuario
        +void Login(Usuario u)
        +void Logout()
    }
    class UsuarioBLL {
        -IUsuarioDAL _dal
        +void Login(string user, string pass)
    }
    class UsuarioDAL {
        -Acceso _acceso
        +Usuario ObtenerPorUsername(string u)
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
---
config:
  layout: elk
---
classDiagram
    class BitacoraForm {
        -IBitacoraService _bitacora
        -void btnBuscar_Click()
    }
    class BitacoraService {
        -IBitacoraDAL _dal
        +void Registrar(string modulo, string actividad, string det, bool ex)
    }
    class BitacoraDAL {
        -Acceso _acceso
        +void Insertar(Bitacora b)
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
---
config:
  layout: elk
---
classDiagram
    class IEncriptador {
        <<interface>>
        +string Hash(string texto)
        +bool Verificar(string texto, string hash)
    }
    class Encriptador {
        +string Hash(string texto)
        +bool Verificar(string texto, string hash)
    }
    class CifradorHelper {
        +void CifrarArchivo(string src, string dst, string pass) static
        +void DescifrarArchivo(string src, string dst, string pass) static
    }
    IEncriptador <|.. Encriptador
```

---
---

# PARTE 2: ENTREGA 2 (SPRINT 2)

## T07. Gestión de Dígitos Verificadores (DV)

### A. Diagrama de Clases del Módulo (Mermaid Class)
```mermaid
---
config:
  layout: elk
---
classDiagram
    class Program {
        +void Main() static
    }
    class DigitoVerificadorService {
        -IDigitoVerificadorDAL _dal
        -IUsuarioDAL _usuarioDal
        +bool VerificarIntegridad()
        +void InicializarDVs()
    }
    class DigitoVerificadorDAL {
        -Acceso _acceso
        +string ObtenerDVV(string tabla)
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
---
config:
  layout: elk
---
classDiagram
    class ComponentePermiso {
        <<abstract>>
        +int IdPermiso
        +string Nombre
        +string PermisoKey
        +List~ComponentePermiso~ Hijos
        +string NombreMostrar
        +void Agregar(ComponentePermiso c)
        +void Quitar(ComponentePermiso c)
        +void ObtenerPatentes(List~Patente~ acumulador, HashSet~int~ visitados)
    }
    class Patente {
        -List~ComponentePermiso~ _hijos
        +List~ComponentePermiso~ Hijos
        +string NombreMostrar
        +void Agregar(ComponentePermiso c)
        +void Quitar(ComponentePermiso c)
        +void ObtenerPatentes(List~Patente~ acumulador, HashSet~int~ visitados)
    }
    class Familia {
        -List~ComponentePermiso~ _hijos
        +List~ComponentePermiso~ Hijos
        +string NombreMostrar
        +void Agregar(ComponentePermiso c)
        +void Quitar(ComponentePermiso c)
        +void ObtenerPatentes(List~Patente~ acumulador, HashSet~int~ visitados)
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
---
config:
  layout: elk
---
classDiagram
    class ControlCambiosForm {
        -IVersionUsuarioBLL _versionBll
    }
    class VersionUsuarioBLL {
        -IVersionUsuarioDAL _dal
        -IUsuarioDAL _usuarioDal
        +void RestaurarVersion(int idVersion)
    }
    class VersionUsuarioDAL {
        -Acceso _acceso
        +VersionUsuario ObtenerPorId(int id)
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
---
config:
  layout: elk
---
classDiagram
    class IObserver {
        <<interface>>
        +void ActualizarIdioma()
    }
    class IManejadorIdioma {
        <<interface>>
        +void Suscribir(IObserver obs)
        +void Desuscribir(IObserver obs)
        +void Notificar()
    }
    class ManejadorIdioma {
        -static ManejadorIdioma _instance
        -List~IObserver~ _observadores
        +void Suscribir(IObserver obs)
        +void Desuscribir(IObserver obs)
        +void Notificar()
    }
    class MenuForm {
        +void ActualizarIdioma()
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
---
config:
  layout: elk
---
classDiagram
    class Program {
        +void Main() static
    }
    class LoginForm {
        -IUsuarioBLL _usuarioBll
        -void LoginForm_Load()
        -void btnIngresar_Click()
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
---
config:
  layout: elk
---
classDiagram
    class UsuarioBLL {
        -IUsuarioDAL _dal
        -IPermisoDAL _permisoDal
        -IDigitoVerificadorService _dvService
        +void Login()
        +void Logout()
    }
    class PermisoBLL {
        -IPermisoDAL _dal
        +List~Patente~ ResolverPatentes()
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
---
config:
  layout: elk
---
classDiagram
    class SessionManager {
        -static SessionManager _instance
        +Usuario Usuario
        +void Login(Usuario u)
        +void Logout()
    }
    class Encriptador {
        +string Hash(string pwd) static
    }
    class CifradorHelper {
        +void CifrarArchivo() static
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
---
config:
  layout: elk
---
classDiagram
    class Acceso {
        -static Acceso _instance
        +DataTable Leer()
        +int Escribir()
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
---
config:
  layout: elk
---
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
        -static Dictionary~Type-object~ _registros
        +void Registrar() static
        +T Resolve() static
    }
```

### Capa 6: Entidades de Negocio (BE) y Composite Pattern (Negocio)
```mermaid
---
config:
  layout: elk
---
classDiagram
    class Usuario {
        +int IdUsuario
        +string Username
        +string PasswordHash
        +EstadoUsuario Estado
        +DateTime FechaAlta
        +DateTime UltimoLogin
        +string DVH
        +List~ComponentePermiso~ Permisos
    }

    class ComponentePermiso {
        +int IdPermiso
        +string Nombre
        +string PermisoKey
        +List~ComponentePermiso~ Hijos
        +string NombreMostrar
        +void Agregar(ComponentePermiso comp)
        +void Quitar(ComponentePermiso comp)
    }

    class Patente {
        +List~ComponentePermiso~ Hijos
        +void Agregar(ComponentePermiso comp)
        +void Quitar(ComponentePermiso comp)
    }

    class Familia {
        -List~ComponentePermiso~ _hijos
        +List~ComponentePermiso~ Hijos
        +void Agregar(ComponentePermiso comp)
        +void Quitar(ComponentePermiso comp)
    }

    class VersionUsuario {
        +int IdVersion
        +int IdUsuario
        +string Username
        +EstadoUsuario Estado
        +DateTime FechaModificacion
        +string ModificadoPor
        +string DetalleCambios
    }

    class Bitacora {
        +int IdBitacora
        +DateTime Fecha
        +int IdUsuario
        +string Username
        +string Modulo
        +string Actividad
        +NivelCriticidad Criticidad
        +bool Exitoso
        +string Detalle
        +string Error
    }

    class Idioma {
        +int IdIdioma
        +string Nombre
        +string Codigo
        +bool Default
    }

    class Traduccion {
        +int IdIdioma
        +int IdComponente
        +string Texto
    }

    ComponentePermiso <|-- Patente
    ComponentePermiso <|-- Familia
    Usuario "1" o-- "0..*" ComponentePermiso : Permisos
    Familia "1" o-- "0..*" ComponentePermiso : Hijos
    Usuario "1" *-- "0..*" VersionUsuario : Historial
    Idioma "1" *-- "0..*" Traduccion : Traducciones
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
