using ExpenseControl.Domain.Entities;
using ExpenseControl.Domain.Enumerables;
using Xunit;

namespace ExpenseControl.Test
{
    public class IncomeTests
    {
        [Fact]
        public void CriarReceitaFixa_EntradaValida_DeveCriarComSucesso()
        {
            // Arrange
            var receita = new Income
            {
                Description = "Receita Teste",
                Amount = 500.00m,
                Type = TransactionTypeEnum.Fix,
                CategoryId = Guid.NewGuid(),
                EntryDate = DateTime.Now
            };

            // Act & Assert
            Assert.NotNull(receita);
            Assert.Equal("Receita Teste", receita.Description);
            Assert.Equal(500.00m, receita.Amount);
            Assert.Equal(TransactionTypeEnum.Fix, receita.Type);
            Assert.Equal(DateTime.Now.Date, receita.EntryDate.Date); // Verifica se a data de entrada é hoje
        }

        [Fact]
        public void CriarReceitaVariavel_EntradaValida_DeveCriarComSucesso()
        {
            // Arrange
            var receita = new Income
            {
                Description = "Receita Teste",
                Amount = 500.00m,
                Type = TransactionTypeEnum.Variable,
                CategoryId = Guid.NewGuid(),
                EntryDate = DateTime.Now
            };

            // Act & Assert
            Assert.NotNull(receita);
            Assert.Equal("Receita Teste", receita.Description);
            Assert.Equal(500.00m, receita.Amount);
            Assert.Equal(TransactionTypeEnum.Variable, receita.Type);
            Assert.Equal(DateTime.Now.Date, receita.EntryDate.Date); // Verifica se a data de entrada é hoje
        }

        [Fact]
        public void AtualizarReceitaFixa_EntradaValida_DeveAtualizarComSucesso()
        {
            // Arrange
            var receita = new Income
            {
                Description = "Receita Teste",
                Amount = 500.00m,
                Type = TransactionTypeEnum.Fix,
                CategoryId = Guid.NewGuid(),
                EntryDate = DateTime.Now
            };

            // Act
            receita.Description = "Receita Atualizada";
            receita.Amount = 600.00m;

            // Assert
            Assert.Equal("Receita Atualizada", receita.Description);
            Assert.Equal(600.00m, receita.Amount);
        }

        [Fact]
        public void AtualizarReceitaVariavel_EntradaValida_DeveAtualizarComSucesso()
        {
            // Arrange
            var receita = new Income
            {
                Description = "Receita Teste",
                Amount = 500.00m,
                Type = TransactionTypeEnum.Variable,
                CategoryId = Guid.NewGuid(),
                EntryDate = DateTime.Now
            };

            // Act
            receita.Description = "Receita Atualizada";
            receita.Amount = 600.00m;

            // Assert
            Assert.Equal("Receita Atualizada", receita.Description);
            Assert.Equal(600.00m, receita.Amount);
        }

        [Fact]
        public void ExcluirReceitaFixa_EntradaValida_DeveExcluirComSucesso()
        {
            // Arrange
            var receita = new Income
            {
                Description = "Receita Teste",
                Amount = 500.00m,
                Type = TransactionTypeEnum.Fix,
                CategoryId = Guid.NewGuid(),
                EntryDate = DateTime.Now
            };

            // Act
            receita = null;

            // Assert
            Assert.Null(receita);
        }

        [Fact]
        public void ExcluirReceitaVariavel_EntradaValida_DeveExcluirComSucesso()
        {
            // Arrange
            var receita = new Income
            {
                Description = "Receita Teste",
                Amount = 500.00m,
                Type = TransactionTypeEnum.Variable,
                CategoryId = Guid.NewGuid(),
                EntryDate = DateTime.Now
            };

            // Act
            receita = null;

            // Assert
            Assert.Null(receita);
        }
    }
}
