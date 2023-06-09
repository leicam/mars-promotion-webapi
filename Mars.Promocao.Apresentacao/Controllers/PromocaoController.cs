using Mars.Promocao.Dominio.Interfaces;
using Mars.Promocao.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Mars.Promocao.Apresentacao.Controllers
{
    [ApiController]
    [Route("v1/gerar-codigo-promocional")]
    public sealed class PromocaoController : AbstractController
    {
        private readonly IPromocaoServico _servico;

        public PromocaoController(IPromocaoServico servico) => _servico = servico;

        [HttpPost]
        [Authorize(Roles = "basic,admin,super")]
        public async Task<IActionResult> GerarCodigoAsync([FromBody] CodigoPromocaoCriar dto)
            => await InvokeMethosAsync(_servico.GerarAsync, dto);
    }
}