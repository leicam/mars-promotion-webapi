using Mars.Promocao.DTO;

namespace Mars.Promocao.Dominio.Interfaces
{
    public interface IPromocaoServico
    {
        Task<IEnumerable<string>> GerarAsync(CodigoPromocaoCriar dto);
    }
}