# Código de Diagramas UML y DER (PlantUML / Mermaid)

Este documento contiene los códigos fuente de todos los diagramas del sistema **Stach** en su arquitectura final de 6 capas, alineados con los requerimientos de la **Entrega 1 y 2 del plan de Excel**.

---

## 1. Diagramas de Clases por Capas (Requerimiento G06 - PlantUML)

Para cumplir con el requerimiento **G06 del Excel** (*"Deberá realizarse un diagrama de clases por cada capa de la arquitectura. Deberán separarse los aspectos técnicos y el negocio"*), a continuación se presentan los códigos PlantUML para cada una de las capas.

### A. Capa de Entidades de Negocio (BE) y Estructura del Patrón Composite (Negocio)
Este diagrama ilustra las entidades de datos y la implementación del patrón Composite para perfiles de usuario.
```plantuml
@startuml
class Usuario {
    +int IdUsuario
    +string Username
    +string PasswordHash
    +EstadoUsuario Estado
    +DateTime FechaAlta
    +DateTime UltimoLogin
    +string DVH
    +List<ComponentePermiso> Permisos
}

abstract class ComponentePermiso {
    +int IdPermiso
    +string Nombre
    +string PermisoKey
    +abstract List<ComponentePermiso> Hijos {get;}
    +abstract string NombreMostrar {get;}
    +abstract void Agregar(ComponentePermiso comp)
    +abstract void Quitar(ComponentePermiso comp)
    +abstract void ObtenerPatentes(List<Patente> acumulador, HashSet<int> visitados)
    +string ToString()
}

class Patente {
    +List<ComponentePermiso> Hijos {get;}
    +string NombreMostrar {get;}
    +void Agregar(ComponentePermiso comp)
    +void Quitar(ComponentePermiso comp)
    +void ObtenerPatentes(List<Patente> acumulador, HashSet<int> visitados)
}

class Familia {
    -List<ComponentePermiso> _hijos
    +List<ComponentePermiso> Hijos {get;}
    +string NombreMostrar {get;}
    +void Agregar(ComponentePermiso comp)
    +void Quitar(ComponentePermiso comp)
    +void ObtenerPatentes(List<Patente> acumulador, HashSet<int> visitados)
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

class Componente {
    +int IdComponente
    +string Nombre
}

ComponentePermiso <|-- Patente
ComponentePermiso <|-- Familia
Usuario "1" o-- "0..*" ComponentePermiso : Permisos
Familia "1" o-- "0..*" ComponentePermiso : _hijos
Usuario "1" *-- "0..*" VersionUsuario : Historial
Idioma "1" *-- "0..*" Traduccion : Traducciones
Componente "1" *-- "0..*" Traduccion : Traducciones
@enduml
```

### B. Capa de Presentación (GUI)
Esta capa es responsable de la interfaz gráfica y la interacción directa con el usuario final. Está completamente desacoplada de Servicios y de la DAL mediante contratos en Abstracciones.
```plantuml
@startuml
package GUI {
    class Program {
        +static void Main()
    }
    class LoginForm {
        -IUsuarioBLL _usuarioBll
        -ISessionManager _sessionManager
        -IManejadorIdioma _manejadorIdioma
        -btnIngresar_Click()
        -LoginForm_Load()
    }
    class MenuForm {
        -ISessionManager _sessionManager
        -IManejadorIdioma _manejadorIdioma
        -btnCerrarSesion_Click()
    }
    class UsuariosForm {
        -IUsuarioBLL _usuarioBll
        -IPermisoBLL _permisoBll
    }
    class PermisosForm {
        -IPermisoBLL _permisoBll
    }
    class BitacoraForm {
        -IBitacoraService _bitacora
    }
    class ControlCambiosForm {
        -IVersionUsuarioBLL _versionBll
    }
    class BackupForm {
        -IBackupService _backupService
    }
    class IdiomaForm {
        -IManejadorIdioma _manejadorIdioma
    }
    class RestauracionForm {
        -IBackupService _backupService
    }
}
LoginForm ..> Program
MenuForm ..> LoginForm
@enduml
```

### C. Capa de Lógica de Negocio (BLL)
Esta capa concentra las reglas del negocio. Interactúa únicamente con interfaces de la capa de Abstracciones y con las entidades BE.
```plantuml
@startuml
package BLL {
    class UsuarioBLL {
        -IUsuarioDAL _dal
        -IPermisoDAL _permisoDal
        -IDigitoVerificadorService _dvService
        -IBitacoraService _bitacora
        +void Alta()
        +void Modificar()
        +void Login()
        +void Logout()
        +static void ValidarPassword(string p)
    }
    class PermisoBLL {
        -IPermisoDAL _dal
        -IBitacoraService _bitacora
        +void CrearPatente()
        +void CrearFamilia()
        +List<Patente> ResolverPatentes()
    }
    class IdiomaBLL {
        -IIdiomaDAL _dal
        +List<Idioma> ObtenerTodos()
    }
    class TraduccionBLL {
        -ITraduccionDAL _dal
        +List<Traduccion> ObtenerTraducciones()
    }
    class VersionUsuarioBLL {
        -IVersionUsuarioDAL _dal
        -IUsuarioDAL _usuarioDal
        +void RestaurarVersion()
    }
}
@enduml
```

### D. Capa de Servicios (Aspectos Técnicos / Transversales)
Esta capa centraliza funcionalidades de seguridad, encriptación, bitácora e integridad de datos.
```plantuml
@startuml
package Servicios {
    class SessionManager {
        -static SessionManager _instance
        +Usuario Usuario {get;}
        +void Login(Usuario u)
        +void Logout()
    }
    class Encriptador {
        +string Hash(string pwd)
        +bool Verificar(string pwd, string hash)
    }
    class CifradorHelper {
        +static void CifrarArchivo()
        +static void DescifrarArchivo()
    }
    class ManejadorIdioma {
        -static ManejadorIdioma _instance
        -List<IObserver> _observadores
        +void Suscribir(IObserver obs)
        +void Desuscribir(IObserver obs)
        +void Notificar()
    }
    class BitacoraService {
        -IBitacoraDAL _dal
        +void Registrar()
        +void RegistrarSinSesion()
    }
    class DigitoVerificadorService {
        -IDigitoVerificadorDAL _dal
        -IUsuarioDAL _usuarioDal
        +bool VerificarIntegridad()
        +void InicializarDVs()
    }
    class BackupService {
        -IBackupDAL _dal
        +void RealizarBackup()
        +void RestaurarBackup()
    }
}
@enduml
```

### E. Capa de Acceso a Datos (DAL)
Esta capa es responsable de la persistencia directa en SQL Server, interactuando con la clase genérica `Acceso`.
```plantuml
@startuml
package DAL {
    class Acceso {
        -static Acceso _instance
        -string _cadenaConexion
        +DataTable Leer(string consulta, SqlParameter[] p)
        +int Escribir(string consulta, SqlParameter[] p)
    }
    class UsuarioDAL {
        -Acceso _acceso
        +List<Usuario> ObtenerTodos()
    }
    class PermisoDAL {
        -Acceso _acceso
        +List<ComponentePermiso> ObtenerTodos()
    }
    class IdiomaDAL {
        -Acceso _acceso
    }
    class TraduccionDAL {
        -Acceso _acceso
    }
    class BitacoraDAL {
        -Acceso _acceso
    }
    class VersionUsuarioDAL {
        -Acceso _acceso
    }
    class BackupDAL {
        -string _cadenaConexionMaster
        +void RealizarBackup()
    }
    class DigitoVerificadorDAL {
        -Acceso _acceso
    }
}
UsuarioDAL ..> Acceso
PermisoDAL ..> Acceso
IdiomaDAL ..> Acceso
TraduccionDAL ..> Acceso
BitacoraDAL ..> Acceso
VersionUsuarioDAL ..> Acceso
DigitoVerificadorDAL ..> Acceso
@enduml
```

### F. Capa de Abstracciones (Contratos e Inversión de Control)
Contiene las interfaces que desacoplan la solución y la clase `IoCContainer` para la Composición de dependencias.
```plantuml
@startuml
package Abstracciones {
    interface IUsuarioDAL
    interface IPermisoDAL
    interface IIdiomaDAL
    interface ITraduccionDAL
    interface IBitacoraDAL
    interface IVersionUsuarioDAL
    interface IBackupDAL
    interface IDigitoVerificadorDAL
    
    interface ISessionManager
    interface IEncriptador
    interface IManejadorIdioma
    interface IBitacoraService
    interface IDigitoVerificadorService
    interface IBackupService
    
    class IoCContainer {
        -static Dictionary<Type, object> _registros
        +static void Registrar<TInterface, TConcrete>()
        +static T Resolve<T>()
    }
}
@enduml
```

---

## 2. Diagramas de Clases por Módulos (Requerimientos Técnicos T02 - T08 - PlantUML)

### A. Gestión de Perfiles de Usuario (T04 - Patrón Composite)
*(Modela estrictamente el patrón Composite en la capa de negocio sin dependencias técnicas)*
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

### B. Gestión de Múltiples Idiomas (T05 - Patrón Observer)
*(Muestra el desacoplamiento entre el publicador y los suscriptores de traducciones)*
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
class UsuariosForm {
    +void ActualizarIdioma()
}
IManejadorIdioma <|.. ManejadorIdioma
IObserver <|.. MenuForm
IObserver <|.. UsuariosForm
ManejadorIdioma "1" o-- "0..*" IObserver : _observadores
@enduml
```

---

## 3. Diagramas de Secuencia por Procesos Clave (Formatos Mermaid)

### A. Inicio de Sesión (T02 - Login)
```mermaid
sequenceDiagram
    autonumber
    actor Admin as Usuario / Admin
    participant GUI as LoginForm
    participant IoC as IoCContainer
    participant BLL as UsuarioBLL
    participant DAL as UsuarioDAL
    participant DB as Base de Datos

    Admin->>GUI: Ingresa Credenciales (Click Ingresar)
    GUI->>IoC: Resolver<UsuarioBLL>()
    IoC-->>GUI: Instancia de UsuarioBLL
    GUI->>BLL: Login("Login", username, password)
    BLL->>DAL: ObtenerPorUsername(username)
    DAL->>DB: SELECT * FROM Usuario WHERE Username = ...
    DB-->>DAL: Fila de Usuario
    DAL-->>BLL: Objeto Usuario
    BLL->>BLL: Verificar contraseña con PBKDF2 (100k iteraciones)
    BLL->>BLL: ValidarEstado(usuario)
    BLL-->>GUI: Éxito
    GUI->>IoC: Resolver<ISessionManager>()
    IoC-->>GUI: Instancia de SessionManager
    GUI->>SessionManager: Login(usuario)
    GUI-->>Admin: Muestra Pantalla de Menú MDI
```

### B. Generación y Cifrado de Backup (T07 - Backup)
```mermaid
sequenceDiagram
    autonumber
    actor Admin as Administrador
    participant GUI as BackupForm
    participant IoC as IoCContainer
    participant Srv as BackupService
    participant DAL as BackupDAL
    participant DB as SQL Server (master)
    participant FS as FileSystem

    Admin->>GUI: Click en "Generar Copia de Seguridad" con Password
    GUI->>IoC: Resolver<IBackupService>()
    IoC-->>GUI: Instancia de BackupService
    GUI->>Srv: RealizarBackup(password, pathDestino)
    Srv->>DAL: GenerarBackupTemporal(tempPath)
    DAL->>DB: BACKUP DATABASE [Stach] TO DISK = tempPath
    DB-->>DAL: Completado
    DAL-->>Srv: Ok
    Srv->>FS: Leer tempPath (archivo .bak plano)
    Srv->>Srv: Cifrar bytes usando AES-256 (CBC)
    Srv->>FS: Escribir archivo .stachbak cifrado
    Srv->>FS: Eliminar físicamente tempPath (triturado)
    Srv-->>GUI: Éxito
    GUI-->>Admin: Mensaje "Copia de seguridad generada con éxito"
```

### C. Reversión de Cambios de Usuario (T06b - Rollback)
```mermaid
sequenceDiagram
    autonumber
    actor Admin as Administrador
    participant GUI as ControlCambiosForm
    participant IoC as IoCContainer
    participant BLL as VersionUsuarioBLL
    participant DAL as VersionUsuarioDAL
    participant UDAL as UsuarioDAL
    participant DB as Base de Datos

    Admin->>GUI: Selecciona Versión e Inicia Rollback
    GUI->>IoC: Resolver<VersionUsuarioBLL>()
    IoC-->>GUI: Instancia de VersionUsuarioBLL
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

### D. Control de Integridad en Arranque (T08 - Dígitos Verificadores)
```mermaid
sequenceDiagram
    autonumber
    participant Init as Program.cs
    participant IoC as IoCContainer
    participant Srv as DigitoVerificadorService
    participant DAL as DigitoVerificadorDAL
    participant UDAL as UsuarioDAL
    participant DB as Base de Datos
    participant GUI as RestauracionForm

    Init->>IoC: Resolver<IDigitoVerificadorService>()
    IoC-->>Init: Instancia de DigitoVerificadorService
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

## 4. Modelo de Datos Relacional - DER Pata de Gallo (Requerimiento G07 - Mermaid)

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
