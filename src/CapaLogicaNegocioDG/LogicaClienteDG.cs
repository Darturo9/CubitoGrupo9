using System.Collections.Generic;
using System.Linq;
using CapaDatosDG;
using CapaEntidadesDG;

namespace CapaLogicaNegocioDG
{
    // Validaciones y operaciones de clientes.
    // Patrón para los demás módulos: validar aquí, guardar con la capa de datos.
    public class LogicaClienteDG
    {
        private readonly DatosClienteDG gObjDatosClienteDG = new DatosClienteDG();
        private readonly DatosPedidoDG gObjDatosPedidoDG = new DatosPedidoDG();

        public List<ClienteDG> FncBuscarClientesDG(string pStrFiltroDG)
        {
            return gObjDatosClienteDG.FncListarClientesDG(pStrFiltroDG);
        }

        // Antes de guardar revisamos que los datos tengan sentido
        public bool FncValidarClienteDG(ClienteDG pObjClienteDG, out string pStrMensajeDG)
        {
            pStrMensajeDG = string.Empty;
            if (pObjClienteDG == null) { pStrMensajeDG = "No se recibió información del cliente."; return false; }
            if (string.IsNullOrWhiteSpace(pObjClienteDG.gStrNombreDG)) { pStrMensajeDG = "Ingrese el nombre del cliente."; return false; }
            if (pObjClienteDG.gStrNombreDG.Trim().Length > 120) { pStrMensajeDG = "El nombre no puede tener más de 120 caracteres."; return false; }

            string lStrTelefonoDG = (pObjClienteDG.gStrTelefonoDG ?? string.Empty).Trim();
            if (lStrTelefonoDG.Length < 8 || lStrTelefonoDG.Length > 15 || !lStrTelefonoDG.All(char.IsDigit))
            {
                pStrMensajeDG = "El teléfono debe tener entre 8 y 15 dígitos, sin espacios ni guiones.";
                return false;
            }

            string lStrCorreoDG = (pObjClienteDG.gStrCorreoDG ?? string.Empty).Trim();
            if (lStrCorreoDG.Length > 0 && (!lStrCorreoDG.Contains("@") || !lStrCorreoDG.Contains(".")))
            {
                pStrMensajeDG = "El correo no tiene un formato válido.";
                return false;
            }
            return true;
        }

        // Inserta si es nuevo o actualiza si ya existe; devuelve false con mensaje si no es válido
        public bool FncGuardarClienteDG(ClienteDG pObjClienteDG, out string pStrMensajeDG)
        {
            if (!FncValidarClienteDG(pObjClienteDG, out pStrMensajeDG)) return false;
            if (gObjDatosClienteDG.FncExisteTelefonoDG(pObjClienteDG.gStrTelefonoDG, pObjClienteDG.gIntIdClienteDG))
            {
                pStrMensajeDG = "Ya hay otro cliente con el teléfono " + pObjClienteDG.gStrTelefonoDG.Trim() + ".";
                return false;
            }

            if (pObjClienteDG.gIntIdClienteDG == 0)
                pObjClienteDG.gIntIdClienteDG = gObjDatosClienteDG.FncInsertarClienteDG(pObjClienteDG);
            else
                gObjDatosClienteDG.SubActualizarClienteDG(pObjClienteDG);

            pStrMensajeDG = "Cliente guardado correctamente.";
            return true;
        }

        // Pedidos del cliente, del más reciente al más antiguo
        public List<PedidoDG> FncHistorialClienteDG(int pIntIdClienteDG)
        {
            return gObjDatosPedidoDG.FncListarPedidosDG(string.Empty, string.Empty)
                .Where(lObjPedidoDG => lObjPedidoDG.gIntIdClienteDG == pIntIdClienteDG)
                .ToList();
        }

        // No se desactiva un cliente con pedidos en curso: primero se entregan o cancelan
        public bool FncDesactivarClienteDG(ClienteDG pObjClienteDG, out string pStrMensajeDG)
        {
            pStrMensajeDG = string.Empty;
            if (pObjClienteDG == null || pObjClienteDG.gIntIdClienteDG <= 0) { pStrMensajeDG = "Seleccione el cliente."; return false; }

            int lIntActivosDG = FncHistorialClienteDG(pObjClienteDG.gIntIdClienteDG)
                .Count(lObjPedidoDG => lObjPedidoDG.gStrEstadoDG != PedidoDG.EstadoEntregadoDG && lObjPedidoDG.gStrEstadoDG != PedidoDG.EstadoCanceladoDG);
            if (lIntActivosDG > 0)
            {
                pStrMensajeDG = pObjClienteDG.gStrNombreDG.Trim() + (lIntActivosDG == 1
                    ? " tiene 1 pedido en curso. Entréguelo o cancélelo antes de desactivarlo."
                    : " tiene " + lIntActivosDG + " pedidos en curso. Entréguelos o cancélelos antes de desactivarlo.");
                return false;
            }

            gObjDatosClienteDG.SubDesactivarClienteDG(pObjClienteDG.gIntIdClienteDG);
            pStrMensajeDG = "Se desactivó a " + pObjClienteDG.gStrNombreDG.Trim() + ". Su historial se conserva.";
            return true;
        }
    }
}
