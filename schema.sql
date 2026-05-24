IF NOT EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID('Usuario') AND name = 'DVH')
BEGIN
    ALTER TABLE Usuario ADD DVH NVARCHAR(256) NULL;
END

IF OBJECT_ID('Traduccion', 'U') IS NULL
BEGIN
    CREATE TABLE Idioma (
        IdIdioma INT IDENTITY(1,1) PRIMARY KEY,
        Nombre NVARCHAR(100) NOT NULL,
        Codigo NVARCHAR(10) NOT NULL,
        [Default] BIT NOT NULL
    );

    CREATE TABLE Componente (
        IdComponente INT IDENTITY(1,1) PRIMARY KEY,
        Nombre NVARCHAR(255) NOT NULL
    );

    CREATE TABLE Traduccion (
        IdIdioma INT NOT NULL FOREIGN KEY REFERENCES Idioma(IdIdioma) ON DELETE CASCADE,
        IdComponente INT NOT NULL FOREIGN KEY REFERENCES Componente(IdComponente) ON DELETE CASCADE,
        Texto NVARCHAR(1000) NOT NULL,
        PRIMARY KEY (IdIdioma, IdComponente)
    );

    SET IDENTITY_INSERT Idioma ON;
    INSERT INTO Idioma (IdIdioma, Nombre, Codigo, [Default]) VALUES (1, N'Español', 'es', 1);
    INSERT INTO Idioma (IdIdioma, Nombre, Codigo, [Default]) VALUES (2, N'English', 'en', 0);
    INSERT INTO Idioma (IdIdioma, Nombre, Codigo, [Default]) VALUES (3, N'Português', 'pt', 0);
    SET IDENTITY_INSERT Idioma OFF;
END

IF OBJECT_ID('PermisoRelacion', 'U') IS NULL
BEGIN
    CREATE TABLE Permiso (
        IdPermiso INT IDENTITY(1,1) PRIMARY KEY,
        Nombre NVARCHAR(100) NOT NULL,
        PermisoKey NVARCHAR(100) NULL,
        EsFamilia BIT NOT NULL
    );

    CREATE TABLE PermisoRelacion (
        IdPadre INT NOT NULL FOREIGN KEY REFERENCES Permiso(IdPermiso),
        IdHijo INT NOT NULL FOREIGN KEY REFERENCES Permiso(IdPermiso) ON DELETE CASCADE,
        PRIMARY KEY (IdPadre, IdHijo)
    );

    CREATE TABLE UsuarioPermiso (
        IdUsuario INT NOT NULL FOREIGN KEY REFERENCES Usuario(IdUsuario) ON DELETE CASCADE,
        IdPermiso INT NOT NULL FOREIGN KEY REFERENCES Permiso(IdPermiso) ON DELETE CASCADE,
        PRIMARY KEY (IdUsuario, IdPermiso)
    );

    SET IDENTITY_INSERT Permiso ON;
    INSERT INTO Permiso (IdPermiso, Nombre, PermisoKey, EsFamilia) VALUES (1, N'Gestión de Usuarios', 'Usuarios', 0);
    INSERT INTO Permiso (IdPermiso, Nombre, PermisoKey, EsFamilia) VALUES (2, N'Ver Bitácora', 'Bitacora', 0);
    INSERT INTO Permiso (IdPermiso, Nombre, PermisoKey, EsFamilia) VALUES (3, N'Gestión de Idiomas', 'Idiomas', 0);
    INSERT INTO Permiso (IdPermiso, Nombre, PermisoKey, EsFamilia) VALUES (4, N'Gestión de Permisos', 'Permisos', 0);
    INSERT INTO Permiso (IdPermiso, Nombre, PermisoKey, EsFamilia) VALUES (5, N'Control de Cambios', 'ControlCambios', 0);
    INSERT INTO Permiso (IdPermiso, Nombre, PermisoKey, EsFamilia) VALUES (6, N'Restauración DV', 'RestauracionDV', 0);
    INSERT INTO Permiso (IdPermiso, Nombre, PermisoKey, EsFamilia) VALUES (7, N'Ver Bitácora de Todos', 'BitacoraTodos', 0);

    INSERT INTO Permiso (IdPermiso, Nombre, PermisoKey, EsFamilia) VALUES (100, N'Administrador', 'FamiliaAdmin', 1);
    INSERT INTO Permiso (IdPermiso, Nombre, PermisoKey, EsFamilia) VALUES (101, N'Supervisor', 'FamiliaSupervisor', 1);
    INSERT INTO Permiso (IdPermiso, Nombre, PermisoKey, EsFamilia) VALUES (102, N'Operador', 'FamiliaOperador', 1);
    SET IDENTITY_INSERT Permiso OFF;

    INSERT INTO PermisoRelacion (IdPadre, IdHijo) VALUES (100, 1);
    INSERT INTO PermisoRelacion (IdPadre, IdHijo) VALUES (100, 2);
    INSERT INTO PermisoRelacion (IdPadre, IdHijo) VALUES (100, 3);
    INSERT INTO PermisoRelacion (IdPadre, IdHijo) VALUES (100, 4);
    INSERT INTO PermisoRelacion (IdPadre, IdHijo) VALUES (100, 5);
    INSERT INTO PermisoRelacion (IdPadre, IdHijo) VALUES (100, 6);
    INSERT INTO PermisoRelacion (IdPadre, IdHijo) VALUES (100, 7);

    INSERT INTO PermisoRelacion (IdPadre, IdHijo) VALUES (101, 2);
    INSERT INTO PermisoRelacion (IdPadre, IdHijo) VALUES (101, 3);
    INSERT INTO PermisoRelacion (IdPadre, IdHijo) VALUES (101, 5);
    INSERT INTO PermisoRelacion (IdPadre, IdHijo) VALUES (101, 7);

    INSERT INTO PermisoRelacion (IdPadre, IdHijo) VALUES (102, 2);

    INSERT INTO UsuarioPermiso (IdUsuario, IdPermiso) VALUES (1, 100);
    INSERT INTO UsuarioPermiso (IdUsuario, IdPermiso) VALUES (2, 102);
END

IF OBJECT_ID('HistorialUsuario', 'U') IS NULL
BEGIN
    CREATE TABLE HistorialUsuario (
        IdVersion INT IDENTITY(1,1) PRIMARY KEY,
        IdUsuario INT NOT NULL FOREIGN KEY REFERENCES Usuario(IdUsuario) ON DELETE CASCADE,
        Fecha DATETIME NOT NULL,
        Actor NVARCHAR(100) NOT NULL,
        Detalle NVARCHAR(500) NOT NULL,
        Username NVARCHAR(100) NOT NULL,
        PasswordHash NVARCHAR(200) NOT NULL,
        Estado INT NOT NULL
    );
END

IF OBJECT_ID('VerificacionVertical', 'U') IS NULL
BEGIN
    CREATE TABLE VerificacionVertical (
        Tabla NVARCHAR(100) PRIMARY KEY,
        DVV NVARCHAR(256) NOT NULL
    );
END
