using System;
using System.Security.Cryptography;
using System.Text;
using CapaDatosDG;
using CapaEntidadesDG;

namespace CapaLogicaNegocioDG
{
    // Reglas del inicio de sesión
    public class LogicaUsuarioDG
    {
        private readonly DatosUsuarioDG gObjDatosUsuarioDG = new DatosUsuarioDG();

        // La contraseña nunca se guarda: solo su hash SHA-256 en hexadecimal
        public string FncCalcularHashDG(string pStrClaveDG)
        {
            using (SHA256 lObjSha256DG = SHA256.Create())
            {
                byte[] lArrBytesDG = lObjSha256DG.ComputeHash(Encoding.UTF8.GetBytes(pStrClaveDG ?? string.Empty));
                StringBuilder lObjTextoDG = new StringBuilder();
                foreach (byte lBytValorDG in lArrBytesDG) lObjTextoDG.Append(lBytValorDG.ToString("X2"));
                return lObjTextoDG.ToString();
            }
        }

        // Devuelve el usuario si las credenciales son correctas; si no, null y un mensaje
        public UsuarioDG FncIniciarSesionDG(string pStrUsuarioDG, string pStrClaveDG, out string pStrMensajeDG)
        {
            pStrMensajeDG = string.Empty;
            if (string.IsNullOrWhiteSpace(pStrUsuarioDG) || string.IsNullOrEmpty(pStrClaveDG))
            {
                pStrMensajeDG = "Ingrese usuario y contraseña.";
                return null;
            }

            UsuarioDG lObjUsuarioDG = gObjDatosUsuarioDG.FncBuscarUsuarioActivoDG(pStrUsuarioDG.Trim());
            bool lBlnValidoDG = lObjUsuarioDG != null &&
                string.Equals(lObjUsuarioDG.gStrHashClaveDG, FncCalcularHashDG(pStrClaveDG), StringComparison.OrdinalIgnoreCase);

            if (!lBlnValidoDG)
            {
                // Mismo mensaje en ambos casos para no revelar qué usuarios existen
                pStrMensajeDG = "Usuario o contraseña incorrectos.";
                return null;
            }
            return lObjUsuarioDG;
        }
    }
}
