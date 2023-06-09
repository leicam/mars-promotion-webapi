using System.Text;

namespace Mars.Promocao.Dominio.Classes
{
    public static class Configuracoes
    {
        private static string ObterSegredo() => "yuvek6RfOFFQqIGYSdkLZ8ZsbLQf2E3a";
        public static byte[] ObterChave() => Encoding.ASCII.GetBytes(ObterSegredo());
    }
}