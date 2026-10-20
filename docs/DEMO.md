# Recorrido de la demostración

Guion para el ensayo (#21) y la defensa. Usa los datos de `sql/03-DatosPruebaDG.sql`, así los números de abajo coinciden con lo que se ve en pantalla.

Duración estimada: 12 a 15 minutos. Cada integrante presenta el módulo que hizo.

## Antes de empezar

1. En SSMS ejecutar, en orden: `sql/01-CrearBaseDG.sql`, `sql/02-DatosInicialesDG.sql` y `sql/03-DatosPruebaDG.sql`.
   Debe terminar con *Datos de prueba cargados: 10 clientes, 15 artículos, 11 pedidos, 9 pagos y 15 gastos.*
2. Abrir la aplicación de escritorio (`WinCubitoDG`).
3. Tener a mano: usuario `admin`, contraseña `Cubito2026`.

> Los pasos que crean datos (pedido nuevo, pagos, gasto) cambian los números. Para repetir el ensayo, vuelva a ejecutar los tres scripts.
> Las fechas de los datos se calculan desde el día en que se ejecuta el script. Los números de *Gastos* y *Reportes* son los de octubre de 2026, siguiendo los pasos en este orden.

## 1. Inicio de sesión y panel (Danilo)

| Paso | Qué se ve |
|---|---|
| Ingresar con una contraseña incorrecta | *Usuario o contraseña incorrectos.* No dice cuál de los dos falló |
| Ingresar con `admin` / `Cubito2026` | Panel de inicio con la marca y el saludo |
| Explicar los indicadores | **5** pedidos activos (2 cotizaciones pendientes) · **Q2,135.00** por cobrar (cobrado hoy Q250.00) · **2** para entregar · **1** alerta de stock |

Punto a resaltar: la contraseña se guarda como hash SHA-256, nunca en texto.

## 2. Inventario (Danilo)

| Paso | Qué se ve |
|---|---|
| Inicio → **Inventario** | PLA-NE-L en rojo: stock 6, mínimo 15, *Reordenar*, comprar **54** (hasta el máximo de 60) |
| Seleccionar PLA-BL-M → **Ver kardex** | Stock inicial 40 → salida de 12 por CUB-0001 → salida de 8 por CUB-0005 = **20**. Cada salida dice de qué pedido viene |
| PLA-NE-L → **Entrada / salida** → Entrada de 54, motivo "Compra a proveedor" | Stock 60; la alerta desaparece |
| Intentar una salida mayor al stock | La aplicación no la deja: el stock nunca queda negativo |

## 3. Pedidos (Danilo)

| Paso | Qué se ve |
|---|---|
| Inicio → **Pedidos** | 11 pedidos con colores por estado; cotizaciones y cancelados muestran saldo "—" |
| **Nuevo pedido**: Carlos Pérez, Serigrafía, *Playera algodón M Blanco* × 5 a Q50, "Logo al frente" → **Guardar** | Se crea **CUB-0012** en *Cotización*, total Q250.00 |
| **Aprobar** | Pasa a *Aprobado* |
| **Enviar a producción** | Pide confirmación porque descuenta 5 playeras. PLA-BL-M baja de 20 a **15** y entra en alerta (15 ≤ mínimo 15) |
| Abrir **CUB-0009** (cotización sin precio) → **Aprobar** | *Para aprobar, todas las líneas deben tener precio.* |
| Abrir **CUB-0007** → **Cancelar pedido** sin escribir motivo | No se puede: el motivo es obligatorio |

## 4. Pagos (Danilo)

| Paso | Qué se ve |
|---|---|
| Inicio → **Pagos** | Cuentas por cobrar: primero los *Listos*. CUB-0005 con la entrega en rojo porque está atrasada |
| CUB-0012 → **Registrar pago** de Q300 | *El monto es mayor al saldo pendiente (Q250.00)* |
| Registrar Q100 como anticipo en efectivo | Saldo Q150.00; *Cobrado hoy* sube a Q350.00 |
| Abrir **CUB-0005** (Listo) → **Entregar** | Avisa que faltan Q200.00 y ofrece cobrar. Cobrar Q200 → **Entregar** → *Entregado* |
| Volver al inicio | Los indicadores se actualizan solos |

## 5. Clientes

| Paso | Qué se ve |
|---|---|
| Inicio → **Clientes** | 10 clientes. Buscar "colegio" filtra por nombre; también se puede buscar por teléfono |
| Seleccionar **Colegio San José** | Historial: CUB-0006 (*En producción*) y CUB-0001 (*Entregado*). *2 pedidos · Comprado: Q3,390.00 · Debe: Q1,275.00* en rojo |
| **Nuevo** con teléfono `55551234` | *Ya hay otro cliente con el teléfono 55551234.* (es de Ana López) |
| Escribir un teléfono con letras o de menos de 8 dígitos | *El teléfono debe tener entre 8 y 15 dígitos, sin espacios ni guiones.* |
| Colegio San José → **Desactivar** | No se puede: *tiene 1 pedido en curso. Entréguelo o cancélelo antes de desactivarlo.* |

Punto a resaltar: desactivar no borra al cliente; su historial y sus pedidos se conservan.

## 6. Gastos

| Paso | Qué se ve |
|---|---|
| Inicio → **Gastos** | Mes actual: *7 gastos en octubre 2026 · Total: Q2,586.75 · Mayor gasto: Alquiler* |
| Cambiar el mes a septiembre | 8 gastos, total Q2,969.90 |
| **Nuevo** con monto 0 o fecha de mañana | *El monto debe ser mayor a cero.* / *La fecha no puede ser futura.* |
| Registrar Q150.00, *Insumos y materiales*, "Tinta blanca plastisol" | *Gasto de Q150.00 guardado.* Octubre: 8 gastos, total **Q2,736.75** |
| Filtrar por *Servicios básicos* | Solo luz e internet |

Punto a resaltar: las categorías son una lista fija para que el reporte agrupe bien.

## 7. Reportes

| Paso | Qué se ve |
|---|---|
| Inicio → **Reportes** (octubre) | **Ventas Q4,590.00** (7 pedidos, ▲ 114 % vs septiembre) · **Cobrado Q3,575.00** · **Gastos Q2,736.75** (▼ 8 %) · **Ganancia Q838.25** |
| Explicar la ganancia | Ganancia = lo cobrado − los gastos del mes (dinero que realmente entró y salió) |
| Grillas | Por técnica: DTF Q2,930.00, Serigrafía Q1,390.00, Sublimación Q270.00 · Mejores clientes: Colegio San José primero · Gastos por categoría: Alquiler primero |
| Cambiar a septiembre | Ganancia **−Q1,899.90**: ese mes se gastó más de lo que se cobró |
| **Exportar CSV** | Se abre en Excel con el resumen y las tres tablas |

Los números de octubre ya incluyen lo hecho en los pasos 3, 4 y 6 (CUB-0012, los pagos de Q100 y Q200 y el gasto de Q150).

## 8. Cierre

- Arquitectura en capas y diagramas: `docs/diagramas/` (mostrar `01-arquitectura.png` y `06-estados-pedido.png`).
- Las reglas viven en la capa de lógica y la base las vuelve a proteger (CHECK, transacciones), así ningún formulario puede saltárselas.
