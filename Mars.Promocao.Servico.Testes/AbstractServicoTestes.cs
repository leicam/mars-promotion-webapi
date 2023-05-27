using Mars.Promocao.Dominio.Interfaces;
using Mars.Promocao.Servicos.Servicos;

namespace Mars.Promocao.Servico.Testes
{
    public abstract class AbstractServicoTestes
    {
        protected IPromocaoServico ObterPromocaoServico() => new PromocaoServico();
    }
}