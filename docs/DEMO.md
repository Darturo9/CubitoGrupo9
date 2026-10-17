# Recorrido de la demostración

Guion para el ensayo (#21) y la defensa. Usa los datos de `sql/03-DatosPruebaDG.sql`, así los números de abajo coinciden con lo que se ve en pantalla.

Duración estimada: 12 a 15 minutos. Cada integrante presenta el módulo que hizo.

## Antes de empezar

1. En SSMS ejecutar, en orden: `sql/01-CrearBaseDG.sql`, `sql/02-DatosInicialesDG.sql` y `sql/03-DatosPruebaDG.sql`.
   Debe terminar con *Datos de prueba cargados: 11 pedidos y 9 pagos.*
2. Abrir la aplicación de escritorio (`WinCubitoDG`) y dejar el portal (`PortalWebDG`) corriendo en otra ventana.
3. Tener a mano: usuario `admin`, contraseña `Cubito2026`.

> Los pasos que crean datos (pedido nuevo, pagos) cambian los números. Para repetir el ensayo, vuelva a ejecutar los tres scripts.

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
| Abrir **CUB-0009** (cotización del portal sin precio) → **Aprobar** | *Para aprobar, todas las líneas deben tener precio.* |
| Abrir **CUB-0007** → **Cancelar pedido** sin escribir motivo | No se puede: el motivo es obligatorio |

## 4. Pagos (Danilo)

| Paso | Qué se ve |
|---|---|
| Inicio → **Pagos** | Cuentas por cobrar: primero los *Listos*. CUB-0005 con la entrega en rojo porque está atrasada |
| CUB-0012 → **Registrar pago** de Q300 | *El monto es mayor al saldo pendiente (Q250.00)* |
| Registrar Q100 como anticipo en efectivo | Saldo Q150.00; *Cobrado hoy* sube a Q350.00 |
| Abrir **CUB-0005** (Listo) → **Entregar** | Avisa que faltan Q200.00 y ofrece cobrar. Cobrar Q200 → **Entregar** → *Entregado* |
| Volver al inicio | Los indicadores se actualizan solos |

## 5. Clientes (Luis)

> Se completa al integrar el formulario de Clientes (#7).

## 6. Gastos (Luis)

> Se completa al integrar el formulario de Gastos (#11).

## 7. Reportes (José David)

> Se completa al integrar el formulario de Reportes (#14). Con los datos de prueba ya hay ventas y cobros de varias semanas para mostrar.

## 8. Portal web (Elias)

> Se completa al integrar *Solicitar cotización* (#10) y *Consultar mi pedido* (#13).
> Idea para la demo: pedir una cotización desde el celular y mostrar que aparece en **Pedidos** del escritorio como *Cotización* con origen *Portal*.

## 9. Cierre

- Arquitectura en capas y diagramas: `docs/diagramas/` (mostrar `01-arquitectura.png` y `06-estados-pedido.png`).
- Las reglas viven en la capa de lógica y la base las vuelve a proteger (CHECK, transacciones), así el escritorio y el portal no pueden saltárselas.
