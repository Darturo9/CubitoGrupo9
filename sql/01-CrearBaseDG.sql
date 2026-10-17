-- =============================================================
-- Cubito - Script de creación de la base de datos
-- Grupo 9 - Programación 2
-- Ejecutar en SQL Server Express (SSMS: abrir y presionar F5).
-- Se puede ejecutar varias veces: elimina y vuelve a crear las tablas.
-- =============================================================

-- Opciones requeridas por las columnas calculadas (SSMS ya las usa por defecto)
SET ANSI_NULLS ON;
SET QUOTED_IDENTIFIER ON;
GO

IF DB_ID(N'CubitoDB') IS NULL
    CREATE DATABASE CubitoDB;
GO

USE CubitoDB;
GO

-- Se eliminan en orden inverso por las llaves foráneas
IF OBJECT_ID(N'dbo.PagosDG') IS NOT NULL DROP TABLE dbo.PagosDG;
IF OBJECT_ID(N'dbo.MovimientosInventarioDG') IS NOT NULL DROP TABLE dbo.MovimientosInventarioDG;
IF OBJECT_ID(N'dbo.DetallePedidosDG') IS NOT NULL DROP TABLE dbo.DetallePedidosDG;
IF OBJECT_ID(N'dbo.PedidosDG') IS NOT NULL DROP TABLE dbo.PedidosDG;
IF OBJECT_ID(N'dbo.ArticulosDG') IS NOT NULL DROP TABLE dbo.ArticulosDG;
IF OBJECT_ID(N'dbo.ClientesDG') IS NOT NULL DROP TABLE dbo.ClientesDG;
IF OBJECT_ID(N'dbo.GastosDG') IS NOT NULL DROP TABLE dbo.GastosDG;
IF OBJECT_ID(N'dbo.UsuariosDG') IS NOT NULL DROP TABLE dbo.UsuariosDG;
GO

-- 1. Usuarios del sistema (login del dueño)
CREATE TABLE dbo.UsuariosDG (
    IdUsuarioDG     INT IDENTITY(1,1) NOT NULL CONSTRAINT PK_UsuariosDG PRIMARY KEY,
    UsuarioDG       NVARCHAR(50)  NOT NULL CONSTRAINT UQ_UsuariosDG_Usuario UNIQUE,
    HashClaveDG     CHAR(64)      NOT NULL,  -- SHA-256 en hexadecimal
    ActivoDG        BIT           NOT NULL CONSTRAINT DF_UsuariosDG_Activo DEFAULT 1
);

-- 2. Clientes del taller
CREATE TABLE dbo.ClientesDG (
    IdClienteDG      INT IDENTITY(1,1) NOT NULL CONSTRAINT PK_ClientesDG PRIMARY KEY,
    NombreDG         NVARCHAR(120) NOT NULL,
    TelefonoDG       VARCHAR(15)   NOT NULL,
    CorreoDG         NVARCHAR(120) NULL,
    FechaRegistroDG  DATETIME2(0)  NOT NULL CONSTRAINT DF_ClientesDG_Fecha DEFAULT SYSDATETIME(),
    ActivoDG         BIT           NOT NULL CONSTRAINT DF_ClientesDG_Activo DEFAULT 1,
    CONSTRAINT CK_ClientesDG_Nombre CHECK (LEN(LTRIM(RTRIM(NombreDG))) > 0),
    CONSTRAINT CK_ClientesDG_Telefono CHECK (LEN(TelefonoDG) >= 8)
);

-- 3. Artículos: prendas e insumos (tintas, vinil, papel, etc.)
CREATE TABLE dbo.ArticulosDG (
    IdArticuloDG     INT IDENTITY(1,1) NOT NULL CONSTRAINT PK_ArticulosDG PRIMARY KEY,
    CodigoDG         VARCHAR(20)   NOT NULL CONSTRAINT UQ_ArticulosDG_Codigo UNIQUE,
    NombreDG         NVARCHAR(100) NOT NULL,
    TipoDG           NVARCHAR(10)  NOT NULL,
    TallaDG          VARCHAR(10)   NULL,
    ColorDG          NVARCHAR(30)  NULL,
    UnidadDG         NVARCHAR(15)  NOT NULL,
    StockDG          DECIMAL(12,2) NOT NULL CONSTRAINT DF_ArticulosDG_Stock DEFAULT 0,
    StockMinimoDG    DECIMAL(12,2) NOT NULL,
    StockMaximoDG    DECIMAL(12,2) NOT NULL,
    CostoUnitarioDG  DECIMAL(12,2) NOT NULL CONSTRAINT DF_ArticulosDG_Costo DEFAULT 0,
    ActivoDG         BIT           NOT NULL CONSTRAINT DF_ArticulosDG_Activo DEFAULT 1,
    CONSTRAINT CK_ArticulosDG_Tipo CHECK (TipoDG IN (N'Prenda', N'Insumo')),
    CONSTRAINT CK_ArticulosDG_Stock CHECK (StockDG >= 0),
    CONSTRAINT CK_ArticulosDG_Minimo CHECK (StockMinimoDG >= 0),
    CONSTRAINT CK_ArticulosDG_Maximo CHECK (StockMaximoDG >= StockMinimoDG),
    CONSTRAINT CK_ArticulosDG_Costo CHECK (CostoUnitarioDG >= 0)
);

-- 4. Pedidos (empiezan como cotización)
CREATE TABLE dbo.PedidosDG (
    IdPedidoDG            INT IDENTITY(1,1) NOT NULL CONSTRAINT PK_PedidosDG PRIMARY KEY,
    CodigoDG              AS ('CUB-' + RIGHT('0000' + CAST(IdPedidoDG AS VARCHAR(10)), 4)) PERSISTED,
    IdClienteDG           INT           NOT NULL CONSTRAINT FK_PedidosDG_Cliente REFERENCES dbo.ClientesDG (IdClienteDG),
    EstadoDG              NVARCHAR(15)  NOT NULL CONSTRAINT DF_PedidosDG_Estado DEFAULT N'Cotización',
    FechaPedidoDG         DATETIME2(0)  NOT NULL CONSTRAINT DF_PedidosDG_Fecha DEFAULT SYSDATETIME(),
    FechaEntregaDG        DATE          NULL,
    TotalDG               DECIMAL(12,2) NOT NULL CONSTRAINT DF_PedidosDG_Total DEFAULT 0,
    OrigenDG              NVARCHAR(10)  NOT NULL CONSTRAINT DF_PedidosDG_Origen DEFAULT N'Escritorio',
    ObservacionesDG       NVARCHAR(300) NULL,
    MotivoCancelacionDG   NVARCHAR(200) NULL,
    FechaActualizacionDG  DATETIME2(0)  NOT NULL CONSTRAINT DF_PedidosDG_Actualizacion DEFAULT SYSDATETIME(),
    CONSTRAINT CK_PedidosDG_Estado CHECK (EstadoDG IN (N'Cotización', N'Aprobado', N'En producción', N'Listo', N'Entregado', N'Cancelado')),
    CONSTRAINT CK_PedidosDG_Origen CHECK (OrigenDG IN (N'Escritorio', N'Portal')),
    CONSTRAINT CK_PedidosDG_Total CHECK (TotalDG >= 0),
    CONSTRAINT CK_PedidosDG_Cancelacion CHECK (EstadoDG <> N'Cancelado' OR LEN(LTRIM(RTRIM(MotivoCancelacionDG))) > 0)
);
CREATE UNIQUE INDEX UX_PedidosDG_Codigo ON dbo.PedidosDG (CodigoDG);

-- 5. Líneas de cada pedido
CREATE TABLE dbo.DetallePedidosDG (
    IdDetalleDG       INT IDENTITY(1,1) NOT NULL CONSTRAINT PK_DetallePedidosDG PRIMARY KEY,
    IdPedidoDG        INT           NOT NULL CONSTRAINT FK_DetalleDG_Pedido REFERENCES dbo.PedidosDG (IdPedidoDG),
    TecnicaDG         NVARCHAR(15)  NOT NULL,
    IdArticuloDG      INT           NULL CONSTRAINT FK_DetalleDG_Articulo REFERENCES dbo.ArticulosDG (IdArticuloDG), -- NULL si el cliente trae la prenda
    DescripcionDG     NVARCHAR(200) NOT NULL,
    CantidadDG        INT           NOT NULL,
    PrecioUnitarioDG  DECIMAL(12,2) NOT NULL CONSTRAINT DF_DetalleDG_Precio DEFAULT 0, -- 0 mientras el dueño no cotiza
    SubtotalDG        AS (CAST(CantidadDG * PrecioUnitarioDG AS DECIMAL(12,2))) PERSISTED,
    CONSTRAINT CK_DetalleDG_Tecnica CHECK (TecnicaDG IN (N'Serigrafía', N'Sublimación', N'DTF')),
    CONSTRAINT CK_DetalleDG_Cantidad CHECK (CantidadDG > 0),
    CONSTRAINT CK_DetalleDG_Precio CHECK (PrecioUnitarioDG >= 0)
);

-- 6. Kardex: entradas, salidas y ajustes de inventario
CREATE TABLE dbo.MovimientosInventarioDG (
    IdMovimientoDG  INT IDENTITY(1,1) NOT NULL CONSTRAINT PK_MovimientosDG PRIMARY KEY,
    IdArticuloDG    INT           NOT NULL CONSTRAINT FK_MovimientosDG_Articulo REFERENCES dbo.ArticulosDG (IdArticuloDG),
    TipoDG          NVARCHAR(10)  NOT NULL,
    CantidadDG      DECIMAL(12,2) NOT NULL,  -- un ajuste puede ser negativo
    MotivoDG        NVARCHAR(200) NOT NULL,
    IdPedidoDG      INT           NULL CONSTRAINT FK_MovimientosDG_Pedido REFERENCES dbo.PedidosDG (IdPedidoDG),
    FechaDG         DATETIME2(0)  NOT NULL CONSTRAINT DF_MovimientosDG_Fecha DEFAULT SYSDATETIME(),
    CONSTRAINT CK_MovimientosDG_Tipo CHECK (TipoDG IN (N'Entrada', N'Salida', N'Ajuste')),
    CONSTRAINT CK_MovimientosDG_Cantidad CHECK ((TipoDG = N'Ajuste' AND CantidadDG <> 0) OR (TipoDG <> N'Ajuste' AND CantidadDG > 0))
);

-- 7. Pagos y anticipos de cada pedido
CREATE TABLE dbo.PagosDG (
    IdPagoDG    INT IDENTITY(1,1) NOT NULL CONSTRAINT PK_PagosDG PRIMARY KEY,
    IdPedidoDG  INT           NOT NULL CONSTRAINT FK_PagosDG_Pedido REFERENCES dbo.PedidosDG (IdPedidoDG),
    MontoDG     DECIMAL(12,2) NOT NULL,
    MetodoDG    NVARCHAR(15)  NOT NULL,
    FechaDG     DATETIME2(0)  NOT NULL CONSTRAINT DF_PagosDG_Fecha DEFAULT SYSDATETIME(),
    CONSTRAINT CK_PagosDG_Monto CHECK (MontoDG > 0),
    CONSTRAINT CK_PagosDG_Metodo CHECK (MetodoDG IN (N'Efectivo', N'Transferencia'))
);

-- 8. Gastos del taller
CREATE TABLE dbo.GastosDG (
    IdGastoDG      INT IDENTITY(1,1) NOT NULL CONSTRAINT PK_GastosDG PRIMARY KEY,
    CategoriaDG    NVARCHAR(30)  NOT NULL,
    DescripcionDG  NVARCHAR(200) NULL,
    MontoDG        DECIMAL(12,2) NOT NULL,
    FechaDG        DATE          NOT NULL CONSTRAINT DF_GastosDG_Fecha DEFAULT CAST(SYSDATETIME() AS DATE),
    CONSTRAINT CK_GastosDG_Monto CHECK (MontoDG > 0),
    CONSTRAINT CK_GastosDG_Categoria CHECK (LEN(LTRIM(RTRIM(CategoriaDG))) > 0)
);
GO

PRINT N'Base de datos CubitoDB creada con 8 tablas.';
