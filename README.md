# Cubito

Sistema de gestión de pedidos, inventario y finanzas para el taller de serigrafía, sublimación y DTF **Cubito**.
Proyecto final de Programación 2 · **Grupo 9**.

| Integrante | Carné | Área |
|---|---|---|
| Danilo Giron | 0900-20-1087 | Base de datos y lógica |
| Elias Israel Canel Ramirez | 0900-25-7066 | Portal web y UI/UX |
| Luis | Pendiente | Formularios y pruebas |
| José David Moreno Najarro | 0900-25-17340 | Reportes y documentación |

Plan completo: [docs/PLAN.md](docs/PLAN.md). Entrega: sábado 24 de octubre de 2026.

## Estructura

```text
CubitoDG.sln
sql/
  01-CrearBaseDG.sql        Crea la base CubitoDB y sus 8 tablas
  02-DatosInicialesDG.sql   Usuario admin y algunos registros de ejemplo
src/
  CapaEntidadesDG/          Clases de datos (ClienteDG, PedidoDG, ...)
  CapaDatosDG/              Acceso a SQL Server con consultas parametrizadas
  CapaLogicaNegocioDG/      Reglas y validaciones del negocio
  WinCubitoDG/              Aplicación de escritorio (Windows Forms, .NET Framework 4.8)
  PortalWebDG/              Portal web para clientes (ASP.NET Core Razor Pages, .NET 10)
docs/
  PLAN.md                   Plan de ejecución
```

Las tres capas usan **.NET Standard 2.0**, así el escritorio y el portal comparten exactamente las mismas reglas.

```text
WinCubitoDG ──┐
              ├──> CapaLogicaNegocioDG ──> CapaDatosDG ──> SQL Server Express (CubitoDB)
PortalWebDG ──┘
CapaEntidadesDG: la usan todas las capas
```

## Requisitos para trabajar

1. **Visual Studio 2022 o superior** con las cargas de trabajo *Desarrollo de escritorio de .NET* y *ASP.NET y desarrollo web*.
2. **.NET Framework 4.8** (viene con Windows 10/11) y el **SDK de .NET 10**.
3. **SQL Server Express** y **SQL Server Management Studio (SSMS)**.
4. **Git**.

## Primera vez: instalar y ejecutar

### 1. Clonar

```bash
git clone https://github.com/Darturo9/CubitoGrupo9.git
```

### 2. Crear la base de datos

Abre SSMS, conéctate a tu instancia de SQL Express y ejecuta **en este orden** (abrir el archivo y presionar F5):

1. `sql/01-CrearBaseDG.sql`
2. `sql/02-DatosInicialesDG.sql`

Se puede volver a ejecutar cuando quieras empezar de cero: borra y vuelve a crear las tablas.

### 3. Configurar la conexión (solo si tu instancia no se llama `SQLEXPRESS`)

Por defecto el sistema se conecta a `.\SQLEXPRESS`. Si tu instancia tiene otro nombre (por ejemplo `SQLEXPRESS01`), **no cambies** `App.config` ni `appsettings.json`, porque afectarías a tus compañeros. Crea una variable de entorno para tu usuario en PowerShell:

```powershell
setx CUBITO_SQL_DG "Server=.\SQLEXPRESS01;Database=CubitoDB;Integrated Security=True;TrustServerCertificate=True"
```

Cierra y vuelve a abrir Visual Studio para que tome el cambio.

### 4. Ejecutar

- **Escritorio:** en Visual Studio, clic derecho en `WinCubitoDG` → *Establecer como proyecto de inicio* → F5.
  Usuario de demostración: `admin`, contraseña: `Cubito2026`.
- **Portal web:** clic derecho en `PortalWebDG` → *Establecer como proyecto de inicio* → F5. Se abre en `https://localhost:7090`.
  La primera vez Visual Studio pide confiar en el certificado de desarrollo: acepta.

## Cómo agregar un módulo

`Clientes` ya tiene lista su capa de datos y de lógica y sirve de ejemplo:

1. **Entidad** en `CapaEntidadesDG` (ya existen las 8).
2. **Datos** en `CapaDatosDG`: una clase `Datos<Modulo>` con consultas parametrizadas (ver `DatosClienteDG.cs`). Nunca concatenar texto del usuario en el SQL.
3. **Lógica** en `CapaLogicaNegocioDG`: una clase `Logica<Modulo>` que valida y luego llama a datos (ver `LogicaClienteDG.cs`).
4. **Formulario** en `WinCubitoDG`, o **página** en `PortalWebDG`. El formulario solo llama a la lógica: **nada de SQL en los formularios**.
5. En `frmPrincipalDG.cs`, cambia el mensaje "en construcción" del botón por la apertura de tu formulario.

## Estándares de código

Se siguen los estándares del curso:

| Elemento | Regla | Ejemplo |
|---|---|---|
| Variables | `[alcance][tipo][nombre][iniciales]` | `lStrNombreClienteDG`, `pIntIdPedidoDG`, `gObjLogicaDG` |
| Alcance | `l` local, `g` global, `p` parámetro | |
| Tipo | `Str`, `Int`, `Dbl`, `Dcm` (decimal), `Dtm` (fecha), `Bln`, `Obj`, `Lst` (lista), `Arr` | |
| Funciones (devuelven valor) | Prefijo `Fnc` | `FncCalcularTotalDG` |
| Métodos (no devuelven valor) | Prefijo `Sub` | `SubGuardarPedidoDG` |
| Clases, formularios, proyectos | Terminan en las iniciales | `PedidoDG`, `frmPedidosDG` |
| Controles | `frm`, `txt`, `lbl`, `gpb`, `btn`, `dgv`, `cmb`, `dtp`, `nud` | `txtNombreDG`, `dgvPedidosDG` |

Cada integrante usa **sus propias iniciales** en el código que escribe (pendiente de confirmar con el ingeniero).
Montos siempre en `decimal`, nunca en `double`.

## Forma de trabajo con Git

1. Antes de empezar, actualiza: `git checkout main` y `git pull`.
2. Trabaja en la rama de tu módulo:

   | Rama | Responsable |
   |---|---|
   | `feature/portal-web` | Elias |
   | `feature/clientes` | Luis |
   | `feature/gastos-reportes` | Luis (gastos) y José David (reportes) |
   | `feature/datos-prueba` | José David |
   | `feature/pedidos`, `feature/pagos` | Danilo |

3. Haz commits pequeños con mensajes claros, por ejemplo `Agregar formulario de gastos con validaciones`.
4. Sube tu rama (`git push`) y abre un **Pull Request** hacia `main` en GitHub. Otro integrante lo revisa antes de unirlo.

**Terminado significa:** compila sin errores, cumple los estándares, las validaciones funcionan, se probó con datos y está documentado.

## Base de datos

| Tabla | Para qué sirve |
|---|---|
| UsuariosDG | Login del dueño (contraseña guardada como hash SHA-256) |
| ClientesDG | Clientes del taller |
| ArticulosDG | Prendas e insumos con stock, mínimo y máximo |
| MovimientosInventarioDG | Kardex: entradas, salidas y ajustes |
| PedidosDG | Pedidos; el código `CUB-0001` se genera solo |
| DetallePedidosDG | Líneas del pedido; el subtotal se calcula solo |
| PagosDG | Pagos y anticipos |
| GastosDG | Gastos del taller |

Estados del pedido: `Cotización → Aprobado → En producción → Listo → Entregado`, o `Cancelado` (con motivo).
