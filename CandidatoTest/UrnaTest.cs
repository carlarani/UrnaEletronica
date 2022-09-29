using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UrnaEletronica;
using Xunit;

namespace UrnaEletronicaTest
{
    public class UrnaTest
    {
        public Urna urnaFake = new Urna();

        [Fact]
        public void ValidaConstrutor_DadosValidos()
        {
            //Arrange
            var urna1 = new Urna();

            //Act
            var urna2 = new Urna()
            {
                VencedorEleicao = "",
                VotosVencedor = 0,
                Candidatos = new List<Candidato>(),
                EleicaoAtiva = false
            };

            //Assert
            urna1.Should()
                    .BeEquivalentTo(urna2);

        }

        [Fact]
        public void ValidaInicioEleicao_DadosValidos()
        {
            //Arrange
            var urnaTesteInicio = new Urna();


            //Act
            urnaFake.IniciarEncerrarEleicao();

            //Assert
            urnaFake.EleicaoAtiva.Should()
                .BeTrue();
        }

        [Theory]
        [InlineData(false)]
        [InlineData(true)]
        public void ValidaEncerrarEleicao_DadosValidos(bool statusAtual)
        {
            //Arrange
            if (statusAtual)
                urnaFake.EleicaoAtiva = true;

            urnaFake.IniciarEncerrarEleicao();

            //Act
            var resultado = urnaFake.EleicaoAtiva;

            //Assert
            resultado.Should()
                .Be(!statusAtual);
        }

        [Fact]
        public void ValidaCandidatoCadastradoEmLista_DadosValidos()
        {
            //Arrange
            var nomeCandidato = "Pedro Paulo";

            //act
            urnaFake.CadastrarCandidato("Candidato 1");
            urnaFake.CadastrarCandidato("Candidato 2");
            urnaFake.CadastrarCandidato(nomeCandidato);

            //assert
            urnaFake.Candidatos
                .Select(p=>p.Nome)
                .Last()
                .Should()
                .Be(nomeCandidato);

        }

        [Fact]
        public void ValidaVotar_CandidatoNãoCadatrado_RetornaFalse()
        {
            //arrange

            //act
            var resultado = urnaFake.Votar("Cujo");

            //assert
            resultado
                .Should()
                .BeFalse();
        }

        [Fact]
        public void ValidaVotar_CandidatoCadatrado_RetornaTrue()
        {
            //arrange
            urnaFake.CadastrarCandidato("Cujo");

            //act
            var resultado = urnaFake.Votar("Cujo");

            //assert
            resultado
                .Should()
                .BeTrue();
        }

        [Theory]
        [InlineData(5, 2, "Candidato 1")]
        [InlineData(0, 3, "Candidato 2")]
        [InlineData(100, 1001, "Candidato 2")]
        [InlineData(15, 1, "Candidato 1")]
        [InlineData(15, 15, "Candidato 1")]
        public void ValidaMostrarResultadoEleição_DadosValidos_RetornaVariavel(int votosCand1, int votosCand2, string nomeEleito)
        {
            //arrange
            int qtdCandidatos = 2;
            string[] nomesCandidatos = new string[qtdCandidatos];
            for (int i = 0; i < qtdCandidatos; i++)
            {
                nomesCandidatos[i] = $"Candidato {i + 1}";
            }
            foreach(var nome in nomesCandidatos)
            {
                urnaFake.CadastrarCandidato(nome);
            }
            //Votar em cada candidato
            int[] votos = new int[] { votosCand1, votosCand2};
            int maiorQtdVotos = votos.Max();
            int j = 0;
            foreach(var voto in votos)
            {
                for (int i = 0; i < voto;i++)
                {
                    urnaFake.Votar(nomesCandidatos[j]);
                }
                j++;
            }

            //act
            var resultado = urnaFake.MostrarResultadoEleicao();

            //assert
            resultado
                .Should()
                .Be($"Nome vencedor: {nomeEleito}. Votos: {maiorQtdVotos}");
        }

    }
}
