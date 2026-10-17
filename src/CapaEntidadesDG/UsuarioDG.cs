namespace CapaEntidadesDG
{
    // Usuario que puede iniciar sesión en el sistema de escritorio
    public class UsuarioDG
    {
        public int gIntIdUsuarioDG { get; set; }
        public string gStrUsuarioDG { get; set; }
        public string gStrHashClaveDG { get; set; }
        public bool gBlnActivoDG { get; set; }

        public UsuarioDG()
        {
            gStrUsuarioDG = string.Empty;
            gStrHashClaveDG = string.Empty;
            gBlnActivoDG = true;
        }
    }
}
