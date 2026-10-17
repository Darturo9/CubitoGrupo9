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

            if (pObjClienteDG.gIntIdClienteDG == 0)
                pObjClienteDG.gIntIdClienteDG = gObjDatosClienteDG.FncInsertarClienteDG(pObjClienteDG);
            else
                gObjDatosClienteDG.SubActualizarClienteDG(pObjClienteDG);

            pStrMensajeDG = "Cliente guardado correctamente.";
            return true;
        }
    }
}
