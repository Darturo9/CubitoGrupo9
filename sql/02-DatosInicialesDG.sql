-- =============================================================
-- Cubito - Datos iniciales mínimos
-- Ejecutar después de 01-CrearBaseDG.sql.
-- Los datos de prueba completos (10 clientes, 15 artículos,
-- 20 pedidos, pagos y gastos) van en 03-DatosPruebaDG.sql.
-- =============================================================

-- Opciones requeridas por las columnas calculadas (SSMS ya las usa por defecto)
SET ANSI_NULLS ON;
SET QUOTED_IDENTIFIER ON;
GO

USE CubitoDB;
GO

-- Usuario administrador para la demostración.
-- Usuario: admin   Contraseña: Cubito2026
-- La contraseña se guarda como hash SHA-256, nunca en texto plano.
INSERT INTO dbo.UsuariosDG (UsuarioDG, HashClaveDG)
VALUES (N'admin', CONVERT(CHAR(64), HASHBYTES('SHA2_256', CAST('Cubito2026' AS VARCHAR(50))), 2));

-- Algunos registros para probar las primeras pantallas
INSERT INTO dbo.ClientesDG (NombreDG, TelefonoDG, CorreoDG) VALUES
(N'Ana López', '55551234', N'ana.lopez@correo.com'),
(N'Colegio San José', '22334455', NULL),
(N'Carlos Pérez', '41239876', NULL);

INSERT INTO dbo.ArticulosDG (CodigoDG, NombreDG, TipoDG, TallaDG, ColorDG, UnidadDG, StockDG, StockMinimoDG, StockMaximoDG, CostoUnitarioDG) VALUES
('PLA-BL-M', N'Playera algodón', N'Prenda', 'M', N'Blanco', N'Unidad', 40, 15, 80, 25.00),
('PLA-NE-L', N'Playera algodón', N'Prenda', 'L', N'Negro', N'Unidad', 10, 15, 60, 27.00),
('TIN-PLA-BL', N'Tinta plastisol blanca', N'Insumo', NULL, N'Blanco', N'ml', 2500, 1000, 5000, 0.20);

PRINT N'Datos iniciales cargados. Usuario: admin';
