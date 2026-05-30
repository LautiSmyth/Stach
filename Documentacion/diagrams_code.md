# Código de Diagramas UML y DER (PlantUML / Mermaid)

Este documento contiene los códigos fuente de todos los diagramas del sistema **Stach**, organizados estrictamente en base al **Plan de Entregas de Excel** (Entrega 1 y Entrega 2).

---

# PARTE 1: ENTREGA 1 (SPRINT 1)

## T01. Arquitectura Base

### A. Diagrama de Componentes de la Arquitectura (PlantUML)
Muestra la relación de dependencias y desacoplamiento de las capas a través de la inyección de dependencias (IoC) y Abstracciones.
```plantuml
@startuml
package GUI as "GUI (Presentation Layer)"
package IoC as "IoC (Composition Root)"
package BLL as "BLL (Business Logic Layer)"
package Servicios as "Servicios (Cross-Cutting Layer)"
package Abstracciones as "Abstracciones (Contracts Layer)"
package DAL as "DAL (Data Access Layer)"
package BE as "BE (Business Entities)"

GUI ..> IoC
GUI ..> BLL
GUI ..> Abstracciones
GUI ..> BE

IoC ..> BLL
IoC ..> DAL
IoC ..> Servicios
IoC ..> Abstracciones
IoC ..> BE

BLL ..> Abstracciones
BLL ..> BE

Servicios ..> Abstracciones
Servicios ..> BE

DAL ..> Abstracciones
DAL ..> BE
@enduml
```

### B. Diagrama de Secuencia - Persistencia Genérica (Mermaid)
Representa el flujo de escritura típico del sistema.
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
Representa el flujo de lectura típico del sistema, con mapeo de tabla a entidades BE.
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

### D. Mapa Tentativo de Navegación (PlantUML)
Representa el flujo de navegación de la interfaz gráfica MDI.
```plantuml
@startuml
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
@enduml
```

---

## T02. Gestión de Login / Logout y Gestión de Usuarios

### A. Diagrama de Clases del Módulo (PlantUML)
```plantuml
@startuml
class LoginForm {
    -IUsuarioBLL _usuarioBll
    -btnIngresar_Click()
}
class SessionManager {
    -static SessionManager _instance
    +Usuario Usuario {get;}
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
LoginForm ..> UsuarioBLL
UsuarioBLL ..> SessionManager
UsuarioBLL ..> UsuarioDAL
UsuarioDAL ..> Usuario
@enduml
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

### A. Diagrama de Clases del Módulo (PlantUML)
```plantuml
@startuml
class BitacoraForm {
    -IBitacoraService _bitacora
    -btnBuscar_Click()
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
BitacoraForm ..> BitacoraService
BitacoraService ..> BitacoraDAL
BitacoraDAL ..> Bitacora
@enduml
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

### A. Diagrama de Clases del Módulo (PlantUML)
```plantuml
@startuml
interface IEncriptador {
    +string Hash(string texto)
    +bool Verificar(string texto, string hash)
}
class Encriptador {
    +string Hash(string texto)
    +bool Verificar(string texto, string hash)
}
class CifradorHelper {
    +static void CifrarArchivo(string src, string dst, string pass)
    +static void DescifrarArchivo(string src, string dst, string pass)
}
IEncriptador <|.. Encriptador
@enduml
```

---
---

# PARTE 2: ENTREGA 2 (SPRINT 2)

## T07. Gestión de Dígitos Verificadores (DV)

### A. Diagrama de Clases del Módulo (PlantUML)
```plantuml
@startuml
class Program {
    +static void Main()
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
Program ..> DigitoVerificadorService
DigitoVerificadorService ..> DigitoVerificadorDAL
@enduml
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

### A. Diagrama de Clases del Módulo - Patrón Composite (PlantUML)
```plantuml
@startuml
abstract class ComponentePermiso {
    +int IdPermiso
    +string Nombre
    +string PermisoKey
    +abstract List<ComponentePermiso> Hijos {get;}
    +abstract string NombreMostrar {get;}
    +abstract void Agregar(ComponentePermiso c)
    +abstract void Quitar(ComponentePermiso c)
    +abstract void ObtenerPatentes(List<Patente> acumulador, HashSet<int> visitados)
}
class Patente {
    +List<ComponentePermiso> Hijos {get;}
    +string NombreMostrar {get;}
    +void Agregar(ComponentePermiso c)
    +void Quitar(ComponentePermiso c)
    +void ObtenerPatentes(List<Patente> acumulador, HashSet<int> visitados)
}
class Familia {
    -List<ComponentePermiso> _hijos
    +List<ComponentePermiso> Hijos {get;}
    +string NombreMostrar {get;}
    +void Agregar(ComponentePermiso c)
    +void Quitar(ComponentePermiso c)
    +void ObtenerPatentes(List<Patente> acumulador, HashSet<int> visitados)
}
ComponentePermiso <|-- Patente
ComponentePermiso <|-- Familia
Familia "1" o-- "0..*" ComponentePermiso : Hijos
@enduml
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

### A. Diagrama de Clases del Módulo (PlantUML)
```plantuml
@startuml
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
ControlCambiosForm ..> VersionUsuarioBLL
VersionUsuarioBLL ..> VersionUsuarioDAL
VersionUsuarioDAL ..> VersionUsuario
@enduml
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

### A. Diagrama de Clases del Módulo - Patrón Observer (PlantUML)
```plantuml
@startuml
interface IObserver {
    +void ActualizarIdioma()
}
interface IManejadorIdioma {
    +void Suscribir(IObserver obs)
    +void Desuscribir(IObserver obs)
    +void Notificar()
}
class ManejadorIdioma {
    -static ManejadorIdioma _instance
    -List<IObserver> _observadores
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
@enduml
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

## G06. Diagramas de Clases por Capas (PlantUML)

A continuación, los diagramas parciales separados por capas para cumplir con la especificación de separar infraestructura de negocio.

### Capa 1: Presentación (GUI)
```plantuml
@startuml
class Program {
    +static void Main()
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
LoginForm ..> Program
MenuForm ..> LoginForm
@enduml
```

### Capa 2: Lógica de Negocio (BLL)
```plantuml
@startuml
class UsuarioBLL {
    -IUsuarioDAL _dal
    -IPermisoDAL _permisoDal
    -IDigitoVerificadorService _dvService
    +void Login()
    +void Logout()
}
class PermisoBLL {
    -IPermisoDAL _dal
    +List<Patente> ResolverPatentes()
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
@enduml
```

### Capa 3: Servicios (Aspectos Transversales)
```plantuml
@startuml
class SessionManager {
    -static SessionManager _instance
    +Usuario Usuario {get;}
    +void Login(Usuario u)
    +void Logout()
}
class Encriptador {
    +string Hash(string pwd)
}
class CifradorHelper {
    +static void CifrarArchivo()
}
class ManejadorIdioma {
    -static ManejadorIdioma _instance
    -List<IObserver> _observadores
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
@enduml
```

### Capa 4: Acceso a Datos (DAL)
```plantuml
@startuml
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
UsuarioDAL ..> Acceso
PermisoDAL ..> Acceso
@enduml
```

### Capa 5: Abstracciones (Contratos e IoC)
```plantuml
@startuml
interface IUsuarioDAL
interface IPermisoDAL
interface IIdiomaDAL
interface ITraduccionDAL
interface IBitacoraDAL
interface IVersionUsuarioDAL
interface IBackupDAL
interface IDigitoVerificadorDAL
class IoCContainer {
    -static Dictionary<Type, object> _registros
    +static void Registrar()
    +static T Resolve()
}
@enduml
```

### Capa 6: Entidades de Negocio (BE)
```plantuml
@startuml
class Usuario
class VersionUsuario
class Bitacora
class Idioma
class Traduccion
class Componente
abstract class ComponentePermiso
class Patente
class Familia
ComponentePermiso <|-- Patente
ComponentePermiso <|-- Familia
@enduml
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
