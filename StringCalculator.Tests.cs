using System;
using System.Collections.Generic;
using Xunit;

public class StringCalculatorTests
{
    [Fact]
    public void Add_ShouldReturnZero_WhenInputIsEmpty()
    {
        // Arrange
        var calculator = new StringCalculator();

        // Act
        var result = calculator.Add(string.Empty);

        // Assert
        Assert.Equal(0, result);
    }

    [Fact]
    public void Add_ShouldReturnZero_WhenInputIsSingleZero()
    {
        // Arrange
        var calculator = new StringCalculator();

        // Act
        var result = calculator.Add("0");

        // Assert
        Assert.Equal(0, result);
    }

    [Fact]
    public void Add_ShouldReturnSum_WhenTwoNumbersProvided()
    {
        // Arrange
        var calculator = new StringCalculator();

        // Act
        var result = calculator.Add("1,2");

        // Assert
        Assert.Equal(3, result);
    }

    [Fact]
    public void Add_ShouldThrowException_WhenNegativeNumbersProvided()
    {
        // Arrange
        var calculator = new StringCalculator();

        // Act & Assert
        var exception = Assert.Throws<Exception>(() => calculator.Add("-1,2"));
        Assert.Contains("Negatives not allowed", exception.Message);
    }

    [Fact]
    public void Add_ShouldReturnSum_WhenNewlineDelimiterUsed()
    {
        // Arrange
        var calculator = new StringCalculator();

        // Act
        var result = calculator.Add("1\n2,3");

        // Assert
        Assert.Equal(6, result);
    }

    [Fact]
    public void Add_ShouldIgnoreNumbersGreaterThan1000()
    {
        // Arrange
        var calculator = new StringCalculator();

        // Act
        var result = calculator.Add("1,1001");

        // Assert
        Assert.Equal(1, result);
    }

    [Fact]
    public void Add_ShouldReturnSum_WhenCustomDelimiterUsed()
    {
        // Arrange
        var calculator = new StringCalculator();

        // Act
        var result = calculator.Add("//;\n1;2");

        // Assert
        Assert.Equal(3, result);
    }
}
