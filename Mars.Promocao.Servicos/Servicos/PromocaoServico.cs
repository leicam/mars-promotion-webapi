using Mars.Promocao.Dominio.Interfaces;
using Mars.Promocao.DTO;
using System.Collections;

namespace Mars.Promocao.Servicos.Servicos
{
    public sealed class PromocaoServico : IPromocaoServico
    {
        private readonly Hashtable _caracteresUtilizados = new Hashtable();
        private readonly Hashtable _codigosGerados = new Hashtable();
        private readonly Random _random = new Random();
        private readonly char[] _listaDeCaracteres = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray(0, 26);

        public async Task<IEnumerable<string>> GerarAsync(CodigoPromocaoCriar dto)
        {
            if (dto.Quantidade <= 0)
                throw new ArgumentException("Quantidade de códigos a gerar inválida! Verifique.");

            if (dto.Quantidade > 1000000)
                throw new ArgumentException("Quantidade de códigos a gerar não suportada! Verifique.");

            var nomeArquivo = string.Concat(AppDomain.CurrentDomain.BaseDirectory, Guid.NewGuid(), ".txt");
            var arquivo = new StreamWriter(nomeArquivo);
            var codigo = string.Empty;

            for(int i = 0; i < dto.Quantidade; i++)
            {
                do
                {
                    codigo = ObterCodigo();
                } while (_codigosGerados.ContainsKey(codigo));

                _codigosGerados.Add(codigo, codigo);

                await arquivo.WriteLineAsync(codigo);
            }

            arquivo.Close();

            var lista = File.ReadAllLines(nomeArquivo);

            File.Delete(nomeArquivo);

            return lista;
        }

        private string ObterCodigo(string codigo = "")
        {
            char caractere;

            if (codigo.Length == 7)
            {
                _caracteresUtilizados.Clear();
                return codigo;
            }

            do
            {
                caractere = ObterCaractere();
            } while (_caracteresUtilizados.ContainsKey(caractere));

            _caracteresUtilizados.Add(caractere, caractere);

            return ObterCodigo(codigo + caractere);
        }

        private char ObterCaractere() => _listaDeCaracteres[_random.Next(26)];
    }
}