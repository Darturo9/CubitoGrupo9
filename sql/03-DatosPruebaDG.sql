-- =============================================================
-- Cubito - Datos de prueba
-- Ejecutar después de 01-CrearBaseDG.sql y 02-DatosInicialesDG.sql,
-- sobre una base recién creada.
--
-- Las fechas son relativas al día en que se ejecuta el script, así
-- siempre hay entregas atrasadas, pedidos para hoy y cobros de hoy.
--
-- Secciones:
--   1. Clientes        (José David completa hasta 10 clientes)
--   2. Artículos       (José David completa hasta 15 artículos)
--   3. Pedidos y pagos (Danilo)
--   4. Gastos          (José David)
-- Los pedidos buscan clientes y artículos por nombre/código, no por Id,
-- así agregar registros en las secciones 1 y 2 no los afecta.
-- =============================================================

SET ANSI_NULLS ON;
SET QUOTED_IDENTIFIER ON;
SET NOCOUNT ON;
SET XACT_ABORT ON;   -- si algo falla, se deshace todo
GO

USE CubitoDB;
GO

IF EXISTS (SELECT 1 FROM dbo.PedidosDG)
BEGIN
    PRINT N'La base ya tiene pedidos. Vuelva a crearla con 01 y 02 antes de cargar los datos de prueba.';
    SET NOEXEC ON;
END
GO

BEGIN TRANSACTION;

-- -------------------------------------------------------------
-- 1. Clientes
-- -------------------------------------------------------------
INSERT INTO dbo.ClientesDG (NombreDG, TelefonoDG, CorreoDG, FechaRegistroDG) VALUES
(N'Academia de Fútbol Los Pumas', '47781122', N'pumas.academia@correo.com', DATEADD(DAY, -40, SYSDATETIME())),
(N'Café La Esquina', '23456789', N'cafelaesquina@correo.com', DATEADD(DAY, -35, SYSDATETIME())),
(N'Iglesia Vida Nueva', '58904433', NULL, DATEADD(DAY, -30, SYSDATETIME()));

-- -------------------------------------------------------------
-- 2. Artículos
-- -------------------------------------------------------------
-- (José David)

-- El stock inicial del script 02 se registra hace 30 días para que el kardex
-- quede en orden: primero el stock inicial y después las salidas por producción.
UPDATE dbo.MovimientosInventarioDG
SET FechaDG = DATEADD(DAY, -30, FechaDG)
WHERE MotivoDG = N'Stock inicial';

-- -------------------------------------------------------------
-- 3. Pedidos y pagos
-- -------------------------------------------------------------
-- 11 pedidos, al menos uno en cada estado:
--   Entregado: 3 · Listo: 2 (uno atrasado) · En producción: 1 · Aprobado: 2
--   Cotización: 2 (una del portal sin precio) · Cancelado: 1
-- Reglas que se respetan, igual que en la aplicación:
--   - Los pagos solo existen desde Aprobado y nunca pasan del total.
--   - Entregado = pagado por completo.
--   - Las prendas del taller se descuentan del stock al pasar a En producción,
--     con su salida en el kardex.

DECLARE @AhoraDG DATETIME2(0) = SYSDATETIME();
DECLARE @HoyDG DATE = CAST(@AhoraDG AS DATE);

DECLARE @IdAnaDG INT = (SELECT IdClienteDG FROM dbo.ClientesDG WHERE NombreDG = N'Ana López');
DECLARE @IdColegioDG INT = (SELECT IdClienteDG FROM dbo.ClientesDG WHERE NombreDG = N'Colegio San José');
DECLARE @IdCarlosDG INT = (SELECT IdClienteDG FROM dbo.ClientesDG WHERE NombreDG = N'Carlos Pérez');
DECLARE @IdPumasDG INT = (SELECT IdClienteDG FROM dbo.ClientesDG WHERE NombreDG = N'Academia de Fútbol Los Pumas');
DECLARE @IdCafeDG INT = (SELECT IdClienteDG FROM dbo.ClientesDG WHERE NombreDG = N'Café La Esquina');
DECLARE @IdIglesiaDG INT = (SELECT IdClienteDG FROM dbo.ClientesDG WHERE NombreDG = N'Iglesia Vida Nueva');

DECLARE @IdBlancaDG INT = (SELECT IdArticuloDG FROM dbo.ArticulosDG WHERE CodigoDG = 'PLA-BL-M');
DECLARE @IdNegraDG INT = (SELECT IdArticuloDG FROM dbo.ArticulosDG WHERE CodigoDG = 'PLA-NE-L');

DECLARE @IdPedidoDG INT;

-- Pedido 1: Colegio San José · Entregado · playeras del taller
INSERT INTO dbo.PedidosDG (IdClienteDG, EstadoDG, FechaPedidoDG, FechaEntregaDG, ObservacionesDG, FechaActualizacionDG)
VALUES (@IdColegioDG, N'Entregado', DATEADD(DAY, -25, @AhoraDG), DATEADD(DAY, -18, @HoyDG), N'Uniformes de educación física', DATEADD(DAY, -18, @AhoraDG));
SET @IdPedidoDG = SCOPE_IDENTITY();
INSERT INTO dbo.DetallePedidosDG (IdPedidoDG, TecnicaDG, IdArticuloDG, DescripcionDG, CantidadDG, PrecioUnitarioDG) VALUES
(@IdPedidoDG, N'Serigrafía', @IdBlancaDG, N'Escudo del colegio al frente, 2 tintas', 12, 55.00),
(@IdPedidoDG, N'DTF', NULL, N'Nombre del alumno en la espalda', 12, 15.00);
INSERT INTO dbo.MovimientosInventarioDG (IdArticuloDG, TipoDG, CantidadDG, MotivoDG, IdPedidoDG, FechaDG)
VALUES (@IdBlancaDG, N'Salida', 12, N'Producción del pedido CUB-' + RIGHT('0000' + CAST(@IdPedidoDG AS VARCHAR(10)), 4), @IdPedidoDG, DATEADD(DAY, -22, @AhoraDG));
UPDATE dbo.ArticulosDG SET StockDG = StockDG - 12 WHERE IdArticuloDG = @IdBlancaDG;
INSERT INTO dbo.PagosDG (IdPedidoDG, MontoDG, MetodoDG, FechaDG) VALUES
(@IdPedidoDG, 420.00, N'Transferencia', DATEADD(DAY, -25, @AhoraDG)),
(@IdPedidoDG, 420.00, N'Efectivo', DATEADD(DAY, -18, @AhoraDG));

-- Pedido 2: Academia Los Pumas · Entregado · camisolas del cliente
INSERT INTO dbo.PedidosDG (IdClienteDG, EstadoDG, FechaPedidoDG, FechaEntregaDG, ObservacionesDG, FechaActualizacionDG)
VALUES (@IdPumasDG, N'Entregado', DATEADD(DAY, -20, @AhoraDG), DATEADD(DAY, -12, @HoyDG), N'Camisolas de torneo, el cliente trae las prendas', DATEADD(DAY, -12, @AhoraDG));
SET @IdPedidoDG = SCOPE_IDENTITY();
INSERT INTO dbo.DetallePedidosDG (IdPedidoDG, TecnicaDG, IdArticuloDG, DescripcionDG, CantidadDG, PrecioUnitarioDG) VALUES
(@IdPedidoDG, N'Sublimación', NULL, N'Diseño completo de camisola con número', 20, 65.00);
INSERT INTO dbo.PagosDG (IdPedidoDG, MontoDG, MetodoDG, FechaDG) VALUES
(@IdPedidoDG, 650.00, N'Transferencia', DATEADD(DAY, -20, @AhoraDG)),
(@IdPedidoDG, 650.00, N'Transferencia', DATEADD(DAY, -12, @AhoraDG));

-- Pedido 3: Café La Esquina · Entregado · pagado en una sola vez
INSERT INTO dbo.PedidosDG (IdClienteDG, EstadoDG, FechaPedidoDG, FechaEntregaDG, FechaActualizacionDG)
VALUES (@IdCafeDG, N'Entregado', DATEADD(DAY, -14, @AhoraDG), DATEADD(DAY, -10, @HoyDG), DATEADD(DAY, -10, @AhoraDG));
SET @IdPedidoDG = SCOPE_IDENTITY();
INSERT INTO dbo.DetallePedidosDG (IdPedidoDG, TecnicaDG, IdArticuloDG, DescripcionDG, CantidadDG, PrecioUnitarioDG) VALUES
(@IdPedidoDG, N'Serigrafía', @IdNegraDG, N'Logo del café al frente', 4, 60.00),
(@IdPedidoDG, N'DTF', NULL, N'Gorras con logo', 4, 35.00);
INSERT INTO dbo.MovimientosInventarioDG (IdArticuloDG, TipoDG, CantidadDG, MotivoDG, IdPedidoDG, FechaDG)
VALUES (@IdNegraDG, N'Salida', 4, N'Producción del pedido CUB-' + RIGHT('0000' + CAST(@IdPedidoDG AS VARCHAR(10)), 4), @IdPedidoDG, DATEADD(DAY, -13, @AhoraDG));
UPDATE dbo.ArticulosDG SET StockDG = StockDG - 4 WHERE IdArticuloDG = @IdNegraDG;
INSERT INTO dbo.PagosDG (IdPedidoDG, MontoDG, MetodoDG, FechaDG) VALUES
(@IdPedidoDG, 380.00, N'Efectivo', DATEADD(DAY, -10, @AhoraDG));

-- Pedido 4: Ana López · Listo · con anticipo, entrega mañana
INSERT INTO dbo.PedidosDG (IdClienteDG, EstadoDG, FechaPedidoDG, FechaEntregaDG, ObservacionesDG, FechaActualizacionDG)
VALUES (@IdAnaDG, N'Listo', DATEADD(DAY, -6, @AhoraDG), DATEADD(DAY, 1, @HoyDG), N'Regalo de cumpleaños', DATEADD(DAY, -1, @AhoraDG));
SET @IdPedidoDG = SCOPE_IDENTITY();
INSERT INTO dbo.DetallePedidosDG (IdPedidoDG, TecnicaDG, IdArticuloDG, DescripcionDG, CantidadDG, PrecioUnitarioDG) VALUES
(@IdPedidoDG, N'Sublimación', NULL, N'Tazas con foto familiar', 6, 45.00);
INSERT INTO dbo.PagosDG (IdPedidoDG, MontoDG, MetodoDG, FechaDG) VALUES
(@IdPedidoDG, 100.00, N'Efectivo', DATEADD(DAY, -6, @AhoraDG));

-- Pedido 5: Iglesia Vida Nueva · Listo · entrega atrasada y con saldo
INSERT INTO dbo.PedidosDG (IdClienteDG, EstadoDG, FechaPedidoDG, FechaEntregaDG, ObservacionesDG, FechaActualizacionDG)
VALUES (@IdIglesiaDG, N'Listo', DATEADD(DAY, -8, @AhoraDG), DATEADD(DAY, -1, @HoyDG), N'Playeras para retiro juvenil', DATEADD(DAY, -2, @AhoraDG));
SET @IdPedidoDG = SCOPE_IDENTITY();
INSERT INTO dbo.DetallePedidosDG (IdPedidoDG, TecnicaDG, IdArticuloDG, DescripcionDG, CantidadDG, PrecioUnitarioDG) VALUES
(@IdPedidoDG, N'Serigrafía', @IdBlancaDG, N'Versículo al frente, 1 tinta', 8, 50.00);
INSERT INTO dbo.MovimientosInventarioDG (IdArticuloDG, TipoDG, CantidadDG, MotivoDG, IdPedidoDG, FechaDG)
VALUES (@IdBlancaDG, N'Salida', 8, N'Producción del pedido CUB-' + RIGHT('0000' + CAST(@IdPedidoDG AS VARCHAR(10)), 4), @IdPedidoDG, DATEADD(DAY, -5, @AhoraDG));
UPDATE dbo.ArticulosDG SET StockDG = StockDG - 8 WHERE IdArticuloDG = @IdBlancaDG;
INSERT INTO dbo.PagosDG (IdPedidoDG, MontoDG, MetodoDG, FechaDG) VALUES
(@IdPedidoDG, 200.00, N'Transferencia', DATEADD(DAY, -8, @AhoraDG));

-- Pedido 6: Colegio San José · En producción · pedido grande con anticipo del 50 %
INSERT INTO dbo.PedidosDG (IdClienteDG, EstadoDG, FechaPedidoDG, FechaEntregaDG, ObservacionesDG, FechaActualizacionDG)
VALUES (@IdColegioDG, N'En producción', DATEADD(DAY, -4, @AhoraDG), DATEADD(DAY, 3, @HoyDG), N'Sudaderos de la promoción 2026', DATEADD(DAY, -3, @AhoraDG));
SET @IdPedidoDG = SCOPE_IDENTITY();
INSERT INTO dbo.DetallePedidosDG (IdPedidoDG, TecnicaDG, IdArticuloDG, DescripcionDG, CantidadDG, PrecioUnitarioDG) VALUES
(@IdPedidoDG, N'DTF', NULL, N'Logo de la promoción en la espalda', 30, 85.00);
INSERT INTO dbo.PagosDG (IdPedidoDG, MontoDG, MetodoDG, FechaDG) VALUES
(@IdPedidoDG, 1275.00, N'Transferencia', DATEADD(DAY, -4, @AhoraDG));

-- Pedido 7: Carlos Pérez · Aprobado · sin anticipo todavía
INSERT INTO dbo.PedidosDG (IdClienteDG, EstadoDG, FechaPedidoDG, FechaEntregaDG, FechaActualizacionDG)
VALUES (@IdCarlosDG, N'Aprobado', DATEADD(DAY, -2, @AhoraDG), DATEADD(DAY, 5, @HoyDG), DATEADD(DAY, -2, @AhoraDG));
SET @IdPedidoDG = SCOPE_IDENTITY();
INSERT INTO dbo.DetallePedidosDG (IdPedidoDG, TecnicaDG, IdArticuloDG, DescripcionDG, CantidadDG, PrecioUnitarioDG) VALUES
(@IdPedidoDG, N'DTF', NULL, N'Sudadero con diseño personalizado', 2, 120.00);

-- Pedido 8: Academia Los Pumas · Aprobado · anticipo cobrado hoy
INSERT INTO dbo.PedidosDG (IdClienteDG, EstadoDG, FechaPedidoDG, FechaEntregaDG, ObservacionesDG, FechaActualizacionDG)
VALUES (@IdPumasDG, N'Aprobado', DATEADD(DAY, -1, @AhoraDG), DATEADD(DAY, 10, @HoyDG), N'Números para la categoría infantil', @AhoraDG);
SET @IdPedidoDG = SCOPE_IDENTITY();
INSERT INTO dbo.DetallePedidosDG (IdPedidoDG, TecnicaDG, IdArticuloDG, DescripcionDG, CantidadDG, PrecioUnitarioDG) VALUES
(@IdPedidoDG, N'Serigrafía', NULL, N'Número en la espalda', 20, 25.00);
INSERT INTO dbo.PagosDG (IdPedidoDG, MontoDG, MetodoDG, FechaDG) VALUES
(@IdPedidoDG, 250.00, N'Efectivo', @AhoraDG);

-- Pedido 9: Café La Esquina · Cotización del portal, todavía sin precio
INSERT INTO dbo.PedidosDG (IdClienteDG, EstadoDG, FechaPedidoDG, FechaEntregaDG, OrigenDG, ObservacionesDG, FechaActualizacionDG)
VALUES (@IdCafeDG, N'Cotización', DATEADD(HOUR, -20, @AhoraDG), DATEADD(DAY, 7, @HoyDG), N'Portal', N'Solicitado desde el portal', DATEADD(HOUR, -20, @AhoraDG));
SET @IdPedidoDG = SCOPE_IDENTITY();
INSERT INTO dbo.DetallePedidosDG (IdPedidoDG, TecnicaDG, IdArticuloDG, DescripcionDG, CantidadDG, PrecioUnitarioDG) VALUES
(@IdPedidoDG, N'DTF', NULL, N'Delantales con logo del café', 6, 0);

-- Pedido 10: Ana López · Cotización con precio, esperando respuesta
INSERT INTO dbo.PedidosDG (IdClienteDG, EstadoDG, FechaPedidoDG, FechaEntregaDG, FechaActualizacionDG)
VALUES (@IdAnaDG, N'Cotización', DATEADD(HOUR, -3, @AhoraDG), DATEADD(DAY, 6, @HoyDG), DATEADD(HOUR, -3, @AhoraDG));
SET @IdPedidoDG = SCOPE_IDENTITY();
INSERT INTO dbo.DetallePedidosDG (IdPedidoDG, TecnicaDG, IdArticuloDG, DescripcionDG, CantidadDG, PrecioUnitarioDG) VALUES
(@IdPedidoDG, N'Sublimación', NULL, N'Cojines con foto', 10, 40.00);

-- Pedido 11: Carlos Pérez · Cancelado antes de aprobar
INSERT INTO dbo.PedidosDG (IdClienteDG, EstadoDG, FechaPedidoDG, FechaEntregaDG, MotivoCancelacionDG, FechaActualizacionDG)
VALUES (@IdCarlosDG, N'Cancelado', DATEADD(DAY, -9, @AhoraDG), DATEADD(DAY, -4, @HoyDG), N'El cliente decidió no hacer el pedido', DATEADD(DAY, -8, @AhoraDG));
SET @IdPedidoDG = SCOPE_IDENTITY();
INSERT INTO dbo.DetallePedidosDG (IdPedidoDG, TecnicaDG, IdArticuloDG, DescripcionDG, CantidadDG, PrecioUnitarioDG) VALUES
(@IdPedidoDG, N'Serigrafía', NULL, N'Playeras para reunión familiar', 5, 50.00);

-- El total de cada pedido es la suma de sus líneas (igual que lo calcula la aplicación)
UPDATE p SET TotalDG = d.TotalDG
FROM dbo.PedidosDG p
JOIN (SELECT IdPedidoDG, SUM(SubtotalDG) AS TotalDG FROM dbo.DetallePedidosDG GROUP BY IdPedidoDG) d ON d.IdPedidoDG = p.IdPedidoDG;

-- -------------------------------------------------------------
-- 4. Gastos
-- -------------------------------------------------------------
-- (José David)

COMMIT TRANSACTION;
GO

-- Comprobaciones: si alguna regla no se cumple, el script lo avisa
IF EXISTS (SELECT 1 FROM dbo.PedidosDG p
           OUTER APPLY (SELECT SUM(MontoDG) AS PagadoDG FROM dbo.PagosDG WHERE IdPedidoDG = p.IdPedidoDG) pg
           WHERE ISNULL(pg.PagadoDG, 0) > p.TotalDG
              OR (p.EstadoDG = N'Entregado' AND ISNULL(pg.PagadoDG, 0) <> p.TotalDG)
              OR (p.EstadoDG IN (N'Cotización', N'Cancelado') AND ISNULL(pg.PagadoDG, 0) > 0))
    PRINT N'ATENCIÓN: hay pedidos con pagos que no cumplen las reglas.';
ELSE IF EXISTS (SELECT 1 FROM dbo.ArticulosDG a
                WHERE a.StockDG <> (SELECT SUM(CASE WHEN TipoDG = N'Salida' THEN -CantidadDG ELSE CantidadDG END)
                                    FROM dbo.MovimientosInventarioDG WHERE IdArticuloDG = a.IdArticuloDG))
    PRINT N'ATENCIÓN: el stock no coincide con el kardex.';
ELSE
BEGIN
    DECLARE @IntPedidosDG INT = (SELECT COUNT(*) FROM dbo.PedidosDG);
    DECLARE @IntPagosDG INT = (SELECT COUNT(*) FROM dbo.PagosDG);
    PRINT N'Datos de prueba cargados: ' + CAST(@IntPedidosDG AS NVARCHAR(10)) + N' pedidos y ' + CAST(@IntPagosDG AS NVARCHAR(10)) + N' pagos.';
END
GO

SET NOEXEC OFF;
GO
