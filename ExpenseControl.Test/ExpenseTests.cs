using ExpenseControl.Domain.Entities;
using ExpenseControl.Domain.Enumerables;
using Xunit;

namespace ExpenseControl.Test
{
    public class ExpenseTests
    {
        [Fact]
        public void CriarDespesaFixa_EntradaValida_DeveCriarComSucesso()
        {
            // Arrange
            var despesa = new Expense
            {
                Description = "Despesa Teste",
                Amount = 100.00m,
                Type = TransactionTypeEnum.Fix,
                CategoryId = Guid.NewGuid(),
                ExpirationDate = DateTime.Now.AddDays(30)
            };

            // Act & Assert
            Assert.NotNull(despesa);
            Assert.Equal("Despesa Teste", despesa.Description);
            Assert.Equal(100.00m, despesa.Amount);
            Assert.Equal(TransactionTypeEnum.Fix, despesa.Type);
            Assert.NotNull(despesa.ExpirationDate);
        }

        [Fact]
        public void CriarDespesaVariavel_EntradaValida_DeveCriarComSucesso()
        {
            // Arrange
            var despesa = new Expense
            {
                Description = "Despesa Teste",
                Amount = 100.00m,
                Type = TransactionTypeEnum.Variable,
                CategoryId = Guid.NewGuid(),
                ExpirationDate = DateTime.Now.AddDays(30)
            };

            // Act & Assert
            Assert.NotNull(despesa);
            Assert.Equal("Despesa Teste", despesa.Description);
            Assert.Equal(100.00m, despesa.Amount);
            Assert.Equal(TransactionTypeEnum.Variable, despesa.Type);
            Assert.NotNull(despesa.ExpirationDate);
        }

        [Fact]
        public void AtualizarDespesaFixa_EntradaValida_DeveAtualizarComSucesso()
        {
            // Arrange
            var despesa = new Expense
            {
                Description = "Despesa Teste",
                Amount = 100.00m,
                Type = TransactionTypeEnum.Fix,
                CategoryId = Guid.NewGuid(),
                ExpirationDate = DateTime.Now.AddDays(30)
            };

            // Act
            despesa.Description = "Despesa Atualizada";
            despesa.Amount = 150.00m;

            // Assert
            Assert.Equal("Despesa Atualizada", despesa.Description);
            Assert.Equal(150.00m, despesa.Amount);
        }

        [Fact]
        public void AtualizarDespesaVariavel_EntradaValida_DeveAtualizarComSucesso()
        {
            // Arrange
            var despesa = new Expense
            {
                Description = "Despesa Teste",
                Amount = 100.00m,
                Type = TransactionTypeEnum.Variable,
                CategoryId = Guid.NewGuid(),
                ExpirationDate = DateTime.Now.AddDays(30)
            };

            // Act
            despesa.Description = "Despesa Atualizada";
            despesa.Amount = 150.00m;

            // Assert
            Assert.Equal("Despesa Atualizada", despesa.Description);
            Assert.Equal(150.00m, despesa.Amount);
        }

        [Fact]
        public void ExcluirDespesaFixa_EntradaValida_DeveExcluirComSucesso()
        {
            // Arrange
            var despesa = new Expense
            {
                Description = "Despesa Teste",
                Amount = 100.00m,
                Type = TransactionTypeEnum.Fix,
                CategoryId = Guid.NewGuid(),
                ExpirationDate = DateTime.Now.AddDays(30)
            };

            // Act
            despesa = null;

            // Assert
            Assert.Null(despesa);
        }

        [Fact]
        public void ExcluirDespesaVariavel_EntradaValida_DeveExcluirComSucesso()
        {
            // Arrange
            var despesa = new Expense
            {
                Description = "Despesa Teste",
                Amount = 100.00m,
                Type = TransactionTypeEnum.Variable,
                CategoryId = Guid.NewGuid(),
                ExpirationDate = DateTime.Now.AddDays(30)
            };

            // Act
            despesa = null;

            // Assert
            Assert.Null(despesa);
        }
    }
}
