# Código de Diagramas UML y DER (Mermaid)

Este documento contiene los códigos fuente de todos los diagramas del sistema **Stach**, escritos **100% en formato Mermaid** con la incorporación explícita de la capa de **Abstracciones** (contratos/interfaces e IoCContainer) para reflejar con precisión el desacoplamiento de la arquitectura de 6 capas y garantizar total compatibilidad con [Mermaid Live Editor](https://mermaid.live).

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
Muestra cómo las llamadas fluyen a través de las abstracciones y el contenedor IoC para desacoplar la persistencia.
```mermaid
sequenceDiagram
    autonumber
    participant GUI as Form / Presentación (GUI)
    participant IoC as IoCContainer (Abstracciones)
    participant BLL as EntidadBLL (BLL)
    participant IDAL as IEntidadDAL (Abstracciones)
    participant DAL as EntidadDAL (DAL)
    participant Acc as Acceso (DAL)
    participant DB as SQL Server

    GUI->>IoC: Resolver<EntidadBLL>()
    IoC-->>GUI: Instancia de EntidadBLL
    GUI->>BLL: RegistrarEntidad(objetoBE)
    BLL->>BLL: Validar Reglas de Negocio
    BLL->>IDAL: Insertar(objetoBE)
    IDAL->>DAL: Insertar(objetoBE)
    DAL->>Acc: Escribir(consultaSQL, parametros)
    Acc->>DB: ExecuteNonQuery()
    DB-->>Acc: Filas Afectadas
    Acc-->>DAL: Entero
    DAL-->>IDAL: Ok (ID Asignado)
    IDAL-->>BLL: Ok
    BLL-->>GUI: Éxito
```

### C. Diagrama de Secuencia - Consulta Genérica (Mermaid)
```mermaid
sequenceDiagram
    autonumber
    participant GUI as Form / Presentación (GUI)
    participant IoC as IoCContainer (Abstracciones)
    participant BLL as EntidadBLL (BLL)
    participant IDAL as IEntidadDAL (Abstracciones)
    participant DAL as EntidadDAL (DAL)
    participant Acc as Acceso (DAL)
    participant DB as SQL Server

    GUI->>IoC: Resolver<EntidadBLL>()
    IoC-->>GUI: Instancia de EntidadBLL
    GUI->>BLL: ObtenerListado()
    BLL->>IDAL: ObtenerTodos()
    IDAL->>DAL: ObtenerTodos()
    DAL->>Acc: Leer(consultaSQL, parametros)
    Acc->>DB: Fill(dataTable)
    DB-->>Acc: DataTable lleno
    Acc-->>DAL: DataTable
    DAL->>DAL: Mapear DataTable a List<EntidadBE>
    DAL-->>IDAL: List<EntidadBE>
    IDAL-->>BLL: List<EntidadBE>
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
Muestra la dependencia de LoginForm y BLL hacia los contratos (Abstracciones), logrando un desacoplamiento completo de la capa de datos.
```mermaid
---
config:
  layout: elk
---
classDiagram
    class LoginForm {
        -UsuarioBLL _usuarioBll
        -IConexionService _conexionService
        -IManejadorIdioma _manejadorIdioma
        -void btnIngresar_Click()
    }
    class UsuarioBLL {
        -IUsuarioDAL _dal
        -IPermisoDAL _permisoDal
        -IDigitoVerificadorService _dvService
        -IVersionUsuarioDAL _versionDal
        -ISessionManager _sessionManager
        -IBitacoraService _bitacora
        -IEncriptador _encriptador
        -IContadorSesion _contadorSesion
        +void Login(string modulo, string username, string password)
        +List~Usuario~ ObtenerTodos()
    }
    class IUsuarioDAL {
        <<interface>>
        +List~Usuario~ ObtenerTodos()
        +Usuario ObtenerPorId(int idUsuario)
        +Usuario ObtenerPorUsername(string username)
        +void Insertar(Usuario usuario)
        +void Actualizar(Usuario usuario)
    }
    class UsuarioDAL {
        -Acceso _acceso
        +List~Usuario~ ObtenerTodos()
        +Usuario ObtenerPorId(int idUsuario)
        +Usuario ObtenerPorUsername(string username)
        +void Insertar(Usuario usuario)
        +void Actualizar(Usuario usuario)
    }
    class Usuario {
        +int IdUsuario
        +string Username
        +string PasswordHash
    }
    class IoCContainer {
        +T Resolver() static
    }

    LoginForm --> IoCContainer : "resuelve con"
    LoginForm --> UsuarioBLL : "usa"
    UsuarioBLL --> IUsuarioDAL : "usa contract"
    UsuarioDAL ..|> IUsuarioDAL : "implementa"
    UsuarioDAL --> Usuario : "mapea"
```

### B. Diagrama de Secuencia - Login (Mermaid)
Ilustra la resolución dinámica de dependencias mediante el contenedor de IoC y llamadas desacopladas vía interfaces.
```mermaid
sequenceDiagram
    autonumber
    actor Admin as Usuario / Admin
    participant GUI as LoginForm (GUI)
    participant IoC as IoCContainer (Abstracciones)
    participant BLL as UsuarioBLL (BLL)
    participant IDAL as IUsuarioDAL (Abstracciones)
    participant DAL as UsuarioDAL (DAL)
    participant DB as Base de Datos (SQL Server)

    Admin->>GUI: Ingresa Credenciales (Click Ingresar)
    GUI->>IoC: Resolver<UsuarioBLL>()
    IoC-->>GUI: Instancia de UsuarioBLL (con dependencias inyectadas)
    GUI->>BLL: Login("Login", username, password)
    BLL->>IDAL: ObtenerPorUsername(username)
    IDAL->>DAL: ObtenerPorUsername(username)
    DAL->>DB: SELECT * FROM Usuario WHERE Username = ...
    DB-->>DAL: Fila de Usuario
    DAL-->>IDAL: Objeto Usuario
    IDAL-->>BLL: Objeto Usuario
    BLL->>BLL: Verificar contraseña con PBKDF2
    BLL->>BLL: ValidarEstado(usuario)
    BLL-->>GUI: Éxito
    GUI-->>Admin: Muestra Pantalla de Menú MDI
```

### C. Diagrama de Secuencia - Logout (Mermaid)
```mermaid
sequenceDiagram
    autonumber
    actor Admin as Usuario
    participant GUI as MenuForm (GUI)
    participant IoC as IoCContainer (Abstracciones)
    participant Srv as ISessionManager (Abstracciones)
    participant Bit as IBitacoraService (Abstracciones)

    Admin->>GUI: Click en "Cerrar Sesión"
    GUI->>IoC: Resolver<IBitacoraService>()
    IoC-->>GUI: Instancia de BitacoraService
    GUI->>Bit: Registrar("Logout", "Cierre de sesión", true)
    Bit-->>GUI: Ok
    GUI->>IoC: Resolver<ISessionManager>()
    IoC-->>GUI: Instancia de SessionManager
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
    class IBitacoraService {
        <<interface>>
        +void Registrar(string modulo, string actividad, string det, bool ex)
    }
    class BitacoraService {
        -IBitacoraDAL _dal
        +void Registrar(string modulo, string actividad, string det, bool ex)
    }
    class IBitacoraDAL {
        <<interface>>
        +void Insertar(Bitacora b)
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
    BitacoraForm --> IBitacoraService
    BitacoraService ..|> IBitacoraService
    BitacoraService --> IBitacoraDAL
    BitacoraDAL ..|> IBitacoraDAL
    BitacoraDAL --> Bitacora
```

### B. Diagrama de Secuencia - Registro en Bitácora Genérico (Mermaid)
```mermaid
sequenceDiagram
    autonumber
    participant App as BLL / Servicio
    participant Srv as IBitacoraService (Abstracciones)
    participant RealSrv as BitacoraService (Servicios)
    participant Session as ISessionManager (Abstracciones)
    participant IDAL as IBitacoraDAL (Abstracciones)
    participant DAL as BitacoraDAL (DAL)
    participant DB as SQL Server

    App->>Srv: Registrar(modulo, actividad, detalle, ex)
    Srv->>RealSrv: Registrar(modulo, actividad, detalle, ex)
    RealSrv->>Session: ObtenerUsuarioLogueado()
    Session-->>RealSrv: Objeto Usuario (username)
    RealSrv->>RealSrv: Determinar criticidad por diccionario
    RealSrv->>IDAL: Insertar(entidadBitacora)
    IDAL->>DAL: Insertar(entidadBitacora)
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
    class IDigitoVerificadorService {
        <<interface>>
        +bool VerificarIntegridad()
        +void InicializarDVs()
    }
    class DigitoVerificadorService {
        -IDigitoVerificadorDAL _dal
        -IUsuarioDAL _usuarioDal
        +bool VerificarIntegridad()
        +void InicializarDVs()
    }
    class IDigitoVerificadorDAL {
        <<interface>>
        +string ObtenerDVV(string tabla)
    }
    class DigitoVerificadorDAL {
        -Acceso _acceso
        +string ObtenerDVV(string tabla)
    }
    Program --> IDigitoVerificadorService
    DigitoVerificadorService ..|> IDigitoVerificadorService
    DigitoVerificadorService --> IDigitoVerificadorDAL
    DigitoVerificadorService --> IUsuarioDAL
    DigitoVerificadorDAL ..|> IDigitoVerificadorDAL
```

### B. Diagrama de Secuencia - Verificación en Arranque (Mermaid)
```mermaid
sequenceDiagram
    autonumber
    participant Init as Program.cs (GUI)
    participant IoC as IoCContainer (Abstracciones)
    participant IDV as IDigitoVerificadorService (Abstracciones)
    participant Srv as DigitoVerificadorService (Servicios)
    participant IUDAL as IUsuarioDAL (Abstracciones)
    participant UDAL as UsuarioDAL (DAL)
    participant IDVDAL as IDigitoVerificadorDAL (Abstracciones)
    participant DAL as DigitoVerificadorDAL (DAL)
    participant DB as Base de Datos

    Init->>IoC: Resolver<IDigitoVerificadorService>()
    IoC-->>Init: Instancia de DigitoVerificadorService
    Init->>IDV: VerificarIntegridad()
    IDV->>Srv: VerificarIntegridad()
    Srv->>IUDAL: ObtenerTodos()
    IUDAL->>UDAL: ObtenerTodos()
    UDAL->>DB: SELECT * FROM Usuario
    DB-->>UDAL: Lista de Usuarios
    UDAL-->>IUDAL: Lista de Usuarios
    IUDAL-->>Srv: Lista de Usuarios
    Srv->>Srv: Recalcular y comparar DVH individual
    Srv->>IDVDAL: ObtenerDVV("Usuario")
    IDVDAL->>DAL: ObtenerDVV("Usuario")
    DAL->>DB: SELECT DVV FROM DigitoVerificador WHERE Tabla = 'Usuario'
    DB-->>DAL: Hash DVV Guardado
    DAL-->>IDVDAL: Hash DVV Guardado
    IDVDAL-->>Srv: Hash DVV Guardado
    Srv->>Srv: Calcular DVV global de la tabla y comparar
    Srv-->>IDV: Retorna false (Integridad violada)
    IDV-->>Init: Retorna false
    Init->>Init: Mostrar RestauracionForm
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
    participant GUI as PermisosForm (GUI)
    participant IoC as IoCContainer (Abstracciones)
    participant BLL as PermisoBLL (BLL)
    participant IDAL as IPermisoDAL (Abstracciones)
    participant DAL as PermisoDAL (DAL)
    participant DB as Base de Datos

    Admin->>GUI: Selecciona Permisos y hace clic en "Guardar Relaciones"
    GUI->>IoC: Resolver<PermisoBLL>()
    IoC-->>GUI: Instancia de PermisoBLL
    GUI->>BLL: GuardarRelaciones(modulo, familiaObjeto)
    BLL->>IDAL: GuardarRelaciones(familiaObjeto)
    IDAL->>DAL: GuardarRelaciones(familiaObjeto)
    DAL->>DB: DELETE FROM PermisoRelacion WHERE IdPadre = ...
    DAL->>DB: INSERT INTO PermisoRelacion (IdPadre, IdHijo) VALUES (...)
    DB-->>DAL: Ok
    BLL-->>GUI: Éxito
    GUI-->>Admin: Muestra Mensaje
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
    class IVersionUsuarioDAL {
        <<interface>>
        +VersionUsuario ObtenerPorId(int id)
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
    VersionUsuarioBLL --> IVersionUsuarioDAL
    VersionUsuarioDAL ..|> IVersionUsuarioDAL
```

### B. Diagrama de Secuencia - Recomposición / Rollback (Mermaid)
```mermaid
sequenceDiagram
    autonumber
    actor Admin as Administrador
    participant GUI as ControlCambiosForm (GUI)
    participant IoC as IoCContainer (Abstracciones)
    participant BLL as VersionUsuarioBLL (BLL)
    participant IDAL as IVersionUsuarioDAL (Abstracciones)
    participant DAL as VersionUsuarioDAL (DAL)
    participant IUDAL as IUsuarioDAL (Abstracciones)
    participant UDAL as UsuarioDAL (DAL)
    participant DB as Base de Datos

    Admin->>GUI: Selecciona Versión e Inicia Rollback
    GUI->>IoC: Resolver<VersionUsuarioBLL>()
    IoC-->>GUI: Instancia de VersionUsuarioBLL
    GUI->>BLL: RestaurarVersion("Rollback", idVersion, actor)
    BLL->>IDAL: ObtenerPorId(idVersion)
    IDAL->>DAL: ObtenerPorId(idVersion)
    DAL->>DB: SELECT * FROM VersionUsuario WHERE IdVersion = ...
    DB-->>DAL: Fila de Versión
    DAL-->>IDAL: Objeto VersionUsuario
    IDAL-->>BLL: Objeto VersionUsuario
    BLL->>IUDAL: ObtenerPorId(idUsuario)
    IUDAL->>UDAL: ObtenerPorId(idUsuario)
    UDAL-->>IUDAL: Objeto Usuario
    IUDAL-->>BLL: Objeto Usuario
    BLL->>IUDAL: Actualizar(usuarioConDatosDeVersion)
    IUDAL->>UDAL: Actualizar(usuarioConDatosDeVersion)
    UDAL->>DB: UPDATE Usuario SET Username = ..., PasswordHash = ... WHERE IdUsuario = ...
    DB-->>UDAL: Ok
    UDAL-->>IUDAL: Ok
    IUDAL-->>BLL: Ok
    BLL-->>GUI: Recomposición Exitosa
    GUI-->>Admin: Mensaje
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
    participant GUI as MenuForm (GUI)
    participant IoC as IoCContainer (Abstracciones)
    participant Srv as IManejadorIdioma (Abstracciones)
    participant RealSrv as ManejadorIdioma (Servicios)
    participant Obs as Formularios Activos (IObserver)

    Admin->>GUI: Selecciona Idioma desde Menu
    GUI->>IoC: Resolver<IManejadorIdioma>()
    IoC-->>GUI: Instancia de ManejadorIdioma
    GUI->>Srv: CambiarIdioma(nuevoIdioma)
    Srv->>RealSrv: CambiarIdioma(nuevoIdioma)
    RealSrv->>RealSrv: Cargar traducciones en memoria
    RealSrv->>Srv: Notificar()
    Srv->>RealSrv: Notificar()
    loop Por cada observador
        RealSrv->>Obs: ActualizarIdioma()
        Obs->>Srv: ObtenerTexto(leyendaKey)
        Srv->>RealSrv: ObtenerTexto(leyendaKey)
        RealSrv-->>Obs: Texto traducido
        Obs->>Obs: Modificar Text de los Controles
    end
    RealSrv-->>GUI: Completado
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
        -UsuarioBLL _usuarioBll
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
