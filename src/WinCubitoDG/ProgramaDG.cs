using System;
using System.Configuration;
using System.Windows.Forms;
using CapaDatosDG;
using CapaEntidadesDG;

namespace WinCubitoDG
{
    internal static class ProgramaDG
    {
        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // La variable de entorno permite que cada integrante use su propia instancia de SQL
            string lStrCadenaDG = Environment.GetEnvironmentVariable("CUBITO_SQL_DG");
            if (string.IsNullOrWhiteSpace(lStrCadenaDG))
                lStrCadenaDG = ConfigurationManager.ConnectionStrings["CubitoDG"].ConnectionString;
            ConexionDG.gStrCadenaConexionDG = lStrCadenaDG;

            UsuarioDG lObjUsuarioDG;
            using (frmLoginDG lObjLoginDG = new frmLoginDG())
            {
                if (lObjLoginDG.ShowDialog() != DialogResult.OK) return;
                lObjUsuarioDG = lObjLoginDG.gObjUsuarioDG;
            }
            Application.Run(new frmPrincipalDG(lObjUsuarioDG));
        }
    }
}
