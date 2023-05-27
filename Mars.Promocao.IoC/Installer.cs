using Mars.Promocao.Dominio.Interfaces;
using Mars.Promocao.Servicos.Servicos;
using SimpleInjector;

namespace Mars.Promocao.IoC
{
    public static class Installer
    {
        public static void Set(ref Container container)
        {
            container.Register<IPromocaoServico, PromocaoServico>(Lifestyle.Scoped);
        }
    }
}