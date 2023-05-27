using Mars.Promocao.DTO;
using System.Collections;

namespace Mars.Promocao.Servico.Testes
{
    [TestClass]
    public sealed class PromocaoServicoTestes : AbstractServicoTestes
    {
        private const string C_OWNER = "Juliano Ribeiro de Souza Maciel";
        private const string C_CATEGORY = "Promocao";

        [TestMethod]
        [Owner(C_OWNER)]
        [TestCategory(C_CATEGORY)]
        public async Task CodigoPromocao_QuantidadeCaracteres_Sucesso()
        {
            var servico = ObterPromocaoServico();
            var codigo = (await servico.GerarAsync(new CodigoPromocaoCriar() { Quantidade = 1, })).FirstOrDefault();

            Assert.IsNotNull(codigo);
            Assert.AreEqual(7, codigo.Length);
        }

        [TestMethod]
        [Owner(C_OWNER)]
        [TestCategory(C_CATEGORY)]
        public async Task CodigoPromocao_CaracteresNaoRepedidos_Sucesso()
        {
            var servico = ObterPromocaoServico();
            var codigo = (await servico.GerarAsync(new CodigoPromocaoCriar() { Quantidade = 1, })).FirstOrDefault();
            var hashtable = new Hashtable();

            foreach (var caractere in codigo ?? string.Empty)
            {
                if (hashtable.ContainsKey(caractere))
                    Assert.Fail($"Caractere {caractere} duplicado para o código {codigo}! Verifique");

                hashtable.Add(caractere, caractere);
            }
        }

        [TestMethod]
        [Owner(C_OWNER)]
        [TestCategory(C_CATEGORY)]
        [DataRow(-1)]
        [DataRow(0)]
        [DataRow(1000001)]
        public async Task CodigoPromocao_ValidarQuandidade_ArgumentException(int quantidade)
        {
            var servico = ObterPromocaoServico();
            var dto = new CodigoPromocaoCriar() { Quantidade = quantidade, };

            await Assert.ThrowsExceptionAsync<ArgumentException>(() => servico.GerarAsync(dto), "Validação não executada corretamente! Verifique.");
        }
    }
}