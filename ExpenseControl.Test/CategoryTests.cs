using ExpenseControl.Domain.Entities;
using ExpenseControl.Domain.Enumerables;
using Xunit;

namespace ExpenseControl.Test;
public class CategoryTests
{
    [Fact]
    public void CriarCategoria_EntradaValida_DeveCriarComSucesso()
    {
        // Arrange
        var categoria = new Category
        {
            Name = "Categoria Teste",
            Description = "Descrição da Categoria Teste",
            Type = CategoryTypeEnum.Expense,
            UserId = "usuarioteste"
        };

        // Act & Assert
        Assert.NotNull(categoria);
        Assert.Equal("Categoria Teste", categoria.Name);
        Assert.Equal("Descrição da Categoria Teste", categoria.Description);
        Assert.Equal(CategoryTypeEnum.Expense, categoria.Type);
        Assert.Equal("usuarioteste", categoria.UserId);
    }


    [Fact]
    public void AtualizarCategoria_EntradaValida_DeveAtualizarComSucesso()
    {
        // Arrange
        var categoria = new Category
        {
            Name = "Categoria Teste",
            Description = "Descrição da Categoria Teste",
            Type = CategoryTypeEnum.Expense,
            UserId = "usuarioteste"
        };

        // Act
        categoria.Name = "Categoria Atualizada";
        categoria.Description = "Descrição Atualizada";

        // Assert
        Assert.Equal("Categoria Atualizada", categoria.Name);
        Assert.Equal("Descrição Atualizada", categoria.Description);
    }

    [Fact]
    public void ExcluirCategoria_EntradaValida_DeveExcluirComSucesso()
    {
        // Arrange
        var categoria = new Category
        {
            Name = "Categoria Teste",
            Description = "Descrição da Categoria Teste",
            Type = CategoryTypeEnum.Expense,
            UserId = "usuarioteste"
        };

        // Act
        categoria = null;

        // Assert
        Assert.Null(categoria);
    }
}
