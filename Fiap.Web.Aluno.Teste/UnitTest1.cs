namespace Fiap.Web.Aluno.Teste
{
    public class UnitTest1
    {
        [Fact]
        public void VerificaMaioridade_DeveRetornarTrueSeMaior()
        {
            // Arrange
            var dataNascimento = new DateTime(2000, 1, 1);
            var hoje = DateTime.Now;
            var maioridade = hoje.Year - dataNascimento.Year;
            if (dataNascimento > hoje.AddYears(-maioridade)) maioridade--;

            // Act
            var ehMaiorDeIdade = maioridade >= 18;

            // Assert
            Assert.True(ehMaiorDeIdade);
        }

        [Fact]
        public void VerificaMaioridade_DeveRetornarTrueSeMenor()
        {
            // Arrange
            var dataNascimento = new DateTime(2020, 1, 1);
            var hoje = DateTime.Now;
            var maioridade = hoje.Year - dataNascimento.Year;
            if (dataNascimento > hoje.AddYears(-maioridade)) maioridade--;

            // Act
            var ehMenorDeIdade = maioridade < 18;

            // Assert
            Assert.True(ehMenorDeIdade);
        }

    }
}