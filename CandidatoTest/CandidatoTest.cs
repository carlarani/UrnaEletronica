using Xunit;
using FluentAssertions;
using UrnaEletronica;

namespace UrnaEletronicaTest
{
    public class CandidatoTest
    {
        //Unidade_Context_ResultadoEsperado
        //EXEMPLO: ValidarPalavra_PalavraValida_ResultadoEsperado


        public Candidato candidatoFake = new Candidato("Carla Rani");
        public Urna urnaFake = new Urna();

        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(10)]
        [InlineData(100)]
        public void ValidaQuantidadeDeVotos_QuantidadeCorreta_RetornaVerdadeiro(int votos)
        {
            //Arrange
            for (int i = 1; i <= votos; i++)
            {
                candidatoFake.AdicionarVoto();
            }

            //Act
            var retorno = candidatoFake.RetornaVoto();
            var resultado = retorno == votos;

            //Assert
            resultado
                .Should()
                .BeTrue(); //FLUENT
        }

        [Fact]
        public void ValidaNomeDoCandidato_NomeValido_RetornaVerdadeiro()
        {
            //Arrange
            var nome = "Mia Wallace";
            urnaFake.CadastrarCandidato(nome);

            //Act
            var achado = urnaFake.Candidatos.Where(c => c.Nome == nome).FirstOrDefault();

            //Assert
            Assert.Equal(nome, achado.Nome);
        }

    }
}