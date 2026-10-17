# Plan de ejecución — Grupo 9 · Proyecto final Programación 2

**Caso de uso:** Sistema de Gestión de Pedidos, Inventario y Finanzas para el taller de serigrafía "Cubito".
**Integrantes:**

| Nombre | Carné | Área |
|---|---|---|
| Danilo Giron | 0900-20-1087 | Base de datos y lógica |
| Elias Israel Canel Ramirez | 0900-25-7066 | Portal web y UI/UX |
| José David Moreno Najarro | 0900-25-17340 | Reportes y documentación |

**Entrega final:** sábado 24 de octubre de 2026. **Presentación del avance:** sábado 17 de octubre de 2026.

---

## 1. Enfoque

**Un sistema sencillo, completo y bien terminado**, al estilo de los ejemplos del catálogo de casos de uso del curso (tablas claras, fórmulas simples, grillas con alertas) y de las prácticas de clase.

- Arquitectura por capas y estándares de desarrollo del curso.
- Regla de oro: **si no se puede explicar en 2 minutos en la defensa, no entra.**

## 2. Validación de requerimientos con el dueño

1. Documentar **supuestos** explícitos (la consigna permite empresa real con necesidad supuesta).
2. Enviar al dueño **un solo mensaje de WhatsApp** con 5 preguntas de sí/no:
   1. ¿Cobras anticipo al recibir un pedido? (supuesto: sí, opcional)
   2. ¿Las técnicas son serigrafía, sublimación y DTF? (supuesto: sí)
   3. ¿Los estados Cotización → Aprobado → En producción → Listo → Entregado te sirven? (supuesto: sí)
   4. ¿Quieres que el cliente consulte su pedido con un código? (supuesto: sí)
   5. ¿Qué gastos son los más comunes? (supuesto: insumos, luz, renta, transporte)
3. Si no responde en 48 h, se trabaja con los supuestos y se anota en el informe.

## 3. Alcance (MVP)

### Dentro

| # | Módulo | Qué hace | Regla o fórmula |
|---|---|---|---|
| M1 | Acceso | Login de un usuario administrador | Contraseña guardada como hash SHA-256 |
| M2 | Clientes | Registrar, editar, buscar clientes | Nombre y teléfono obligatorios |
| M3 | Inventario | Artículos (prendas e insumos), entradas, salidas, ajustes, kardex | Sin stock negativo; alerta si `Stock ≤ Mínimo`; sugerido = `Máximo − Stock` |
| M4 | Cotizaciones y pedidos | Pedido con varias líneas (técnica, prenda, talla, color, cantidad, precio) y cambio de estado | `Total = Σ (Cantidad × PrecioUnitario)`; al pasar a *En producción* se descuentan las prendas del stock (transacción SQL) |
| M5 | Finanzas | Pagos/anticipos por pedido, gastos por categoría, cuentas por cobrar | `Saldo = Total − Σ Pagos`; no se acepta pago mayor al saldo; no se entrega con saldo pendiente |
| M6 | Reportes | Resumen del mes: ingresos, gastos, utilidad, pedidos por estado, artículos en alerta | `Utilidad = Ingresos − Gastos` del periodo |
| M7 | Portal web | Cliente solicita cotización y consulta estado de su pedido | Consulta con código `CUB-0001` + últimos 4 dígitos del teléfono |

### Fuera de alcance (mejoras futuras)

Facturación electrónica (FEL), pagos en línea, cuentas de cliente en el portal, adjuntar diseños, múltiples usuarios/roles, cotizador automático de precios, contabilidad completa.

## 4. Arquitectura

```text
WinCubitoDG (WinForms)      PortalWebDG (ASP.NET Core Razor Pages)
            \                      /
         CapaLogicaNegocioDG  (reglas y validaciones)
                    |
             CapaDatosDG      (ADO.NET + procedimientos almacenados)
                    |
            SQL Server Express  (CubitoDB)

CapaEntidadesDG: clases compartidas por todas las capas
```

- **Escritorio:** C# Windows Forms, .NET Framework 4.8.
- **Web:** ASP.NET Core Razor Pages (.NET 10).
- **Bibliotecas de capas** (Entidades, Lógica, Datos) en **.NET Standard 2.0**, para que escritorio y portal usen exactamente las mismas reglas sin duplicar código.
- **Datos:** SQL Server Express, ADO.NET con `Microsoft.Data.SqlClient`, consultas parametrizadas (nunca SQL en formularios ni concatenado).
- **Control de versiones:** GitHub, una rama por módulo, Pull Request revisado por Danilo antes de unir a `main`.

## 5. Base de datos (8 tablas)

| Tabla | Campos principales |
|---|---|
| UsuariosDG | IdUsuario, Usuario, HashClave, Activo |
| ClientesDG | IdCliente, Nombre, Telefono, Correo, FechaRegistro |
| ArticulosDG | IdArticulo, Codigo, Nombre, Tipo (Prenda/Insumo), Talla, Color, Unidad, Stock, StockMinimo, StockMaximo, CostoUnitario, Activo |
| MovimientosInventarioDG | IdMovimiento, IdArticulo, Tipo (Entrada/Salida/Ajuste), Cantidad, Motivo, IdPedido, Fecha |
| PedidosDG | IdPedido, Codigo, IdCliente, Estado, FechaPedido, FechaEntrega, Total, Origen (Escritorio/Portal), Observaciones |
| DetallePedidosDG | IdDetalle, IdPedido, Tecnica, IdArticulo, Descripcion, Cantidad, PrecioUnitario, Subtotal |
| PagosDG | IdPago, IdPedido, Monto, Metodo (Efectivo/Transferencia), Fecha |
| GastosDG | IdGasto, Categoria, Descripcion, Monto, Fecha |

Datos de prueba: 10 clientes, 15 artículos, 20 pedidos en distintos estados, pagos y gastos de 2 meses.

## 6. Estados del pedido

`Cotización → Aprobado → En producción → Listo → Entregado`; *Cancelado* permitido antes de *Listo*, con motivo.

- *Cotización*: creada en escritorio o desde el portal.
- *En producción*: descuenta prendas del inventario (todo o nada, transacción).
- *Entregado*: solo si el saldo es Q0.00.

## 7. Portal web — reglas de UI/UX

Uso diario desde el celular de los clientes, por eso:

1. **Mobile first**: una columna, botones de al menos 44 px de alto, texto de 16 px.
2. **Solo 2 pantallas**: *Solicitar cotización* y *Consultar mi pedido*, más la página de inicio.
3. **Formularios cortos** con etiquetas visibles, validación en línea y mensajes de error claros en español.
4. **Estado como línea de tiempo** visual (pasos con color e ícono), no solo texto.
5. **Confirmación** tras enviar: número de solicitud y qué pasa después.
6. Identidad visual de Cubito (colores y logo), contraste accesible, botón de WhatsApp como apoyo.
7. Privacidad: la consulta solo muestra estado, fecha estimada y saldo; nunca datos de otros clientes.

## 8. Reparto de responsabilidades

Cada integrante debe tener **código propio verificable** (la rúbrica asigna 3 puntos al aporte individual) y debe poder explicar el sistema completo (5 puntos de defensa).

| Integrante | Rol | Desarrollo | Documentación y otros |
|---|---|---|---|
| **Danilo Giron** | Base de datos y lógica | Script de BD, CapaEntidades, CapaDatos, CapaLógica, módulos Inventario (M3), Pedidos (M4), Pagos (M5) e integración | Arquitectura, diagramas de clases, README técnico |
| **Elias Israel Canel Ramirez** | Portal web y UI/UX | Portal web (M7): diseño, páginas, conexión a la capa lógica; formulario Clientes (M2); pruebas en celular | Manual de usuario del portal, capturas, video pitch |
| **José David Moreno Najarro** | Reportes y documentación | Formularios Gastos y Reportes (M5–M6), datos de prueba (seed SQL) | Informe técnico APA (portada, índice, anexos), casos de uso con la plantilla, plan de pruebas, bitácora y actas |

## 9. Cronograma (16 al 24 de octubre)

| Fecha | Danilo | Elias | José David | Hito |
|---|---|---|---|---|
| Vie 16 | Plan y presentación | — | — | Plan listo |
| Sáb 17 | Presentar plan; crear repo y accesos | Instalar entorno | Instalar entorno; mensaje al dueño | **Plan aprobado** |
| Dom 18 | Script de BD + solución con capas | Prototipo visual del portal (HTML/CSS) | Casos de uso CU-01 a CU-04 | Esqueleto compila |
| Lun 19 | Clientes/artículos en capas + Inventario | Formulario Clientes | Casos de uso CU-05 a CU-08; seed SQL | |
| Mar 20 | Pedidos con detalle y estados | Portal: solicitar cotización | Formulario Gastos | Flujo pedido funciona |
| Mié 21 | Pagos, saldos y entrega | Portal: consultar pedido | Formulario Reportes | **Funciones completas** |
| Jue 22 | Integración y corrección de errores | Pruebas del portal en celular | Plan de pruebas y evidencias | **Congelar código** |
| Vie 23 | Diagramas y README | Video pitch (1:30–3:00) | Informe y manuales finales | Ensayo de defensa |
| Sáb 24 | Revisión final | Publicación | Entrega de documentos | **Entrega** |

Reunión diaria de 15 minutos (llamada o WhatsApp): qué hice, qué haré, qué me bloquea.

## 10. Forma de trabajo

- **Estándares del curso:** capas, prefijos de alcance y tipo (`lStrNombre…`), `Fnc` para funciones, `Sub` para métodos, controles `frm`, `txt`, `lbl`, `gpb`, `btn`, `dgv`, `cmb`.
- **Iniciales:** cada integrante pone **sus propias iniciales** en las clases, formularios y variables que escribe (por ejemplo `frmGastosXX`); la solución y los proyectos usan `DG`. Esto evidencia el aporte individual. *Confirmar con el ingeniero.*
- **Git:** rama por módulo (`feature/inventario`, `feature/portal`…), commits pequeños con mensaje claro, PR revisado antes de unir.
- **Definición de terminado:** compila, cumple estándares, validaciones funcionando, probado con datos de prueba, documentado en el informe.

## 11. Riesgos y mitigación

| Riesgo | Mitigación |
|---|---|
| Requisitos sin confirmar por el dueño | Supuestos documentados y 5 preguntas de sí/no |
| Poco tiempo (8 días) | Alcance pequeño, congelar código el 22 |
| Integración entre módulos | Capas y BD primero; reglas comunes en la lógica; módulos separados en paralelo |
| Entornos distintos (SQL Express, .NET) | Guía de instalación el día 17 y script de BD único |
| Defensa individual | Cada uno explica su módulo y ensaya el recorrido completo el día 23 |

## 12. Entregables

1. Código fuente en GitHub + aplicación ejecutable (escritorio y portal).
2. Script SQL de creación y datos de prueba.
3. Informe técnico: problema, arquitectura, diagramas de clases y flujo, casos de uso, manual de usuario e instalación, APA.
4. Video pitch de 1:30 a 3:00 minutos.
5. Bitácora, actas, autoevaluación y coevaluación.

## 13. Demostración para la defensa

Recorrido de 3 minutos: el cliente solicita una cotización en el portal → el dueño la ve en escritorio, asigna precio y la aprueba → registra anticipo → pasa a *En producción* (baja el inventario y aparece una alerta de reorden) → el cliente consulta su pedido en el celular → se cobra el saldo y se entrega → el reporte del mes muestra ingresos, gastos y utilidad.
