using System;
using Xunit;

public class StringCalculatorAddTests
{
    [Fact]
    public void ShouldReturnZero_ForEmptyString()
    {
        // Arrange
        var calculator = new StringCalculator();

        // Act
        var result = calculator.Add("");

        // Assert
        Assert.Equal(0, result);
    }

    [Fact]
    public void ShouldReturnZero_ForSingleZeroInput()
    {
        // Arrange
        var calculator = new StringCalculator();

        // Act
        var result = calculator.Add("0");

        // Assert
        Assert.Equal(0, result);
    }

    [Fact]
    public void ShouldReturnSum_ForTwoCommaSeparatedNumbers()
    {
        // Arrange
        var calculator = new StringCalculator();

        // Act
        var result = calculator.Add("1,2");

        // Assert
        Assert.Equal(3, result);
    }

    [Fact]
    public void ShouldThrowException_ForNegativeNumbers()
    {
        // Arrange
        var calculator = new StringCalculator();

        // Act & Assert
        var ex = Assert.Throws<Exception>(() => calculator.Add("-1,2"));
        Assert.Contains("Negatives not allowed", ex.Message);
    }

    [Fact]
    public void ShouldReturnSum_ForNumbersWithNewlineDelimiter()
    {
        // Arrange
        var calculator = new StringCalculator();

        // Act
        var result = calculator.Add("1\n2,3");

        // Assert
        Assert.Equal(6, result);
    }

    [Fact]
    public void ShouldIgnoreNumbersGreaterThan1000()
    {
        // Arrange
        var calculator = new StringCalculator();

        // Act
        var result = calculator.Add("1,1001");

        // Assert
        Assert.Equal(1, result);
    }

    [Fact]
    public void ShouldHandleCustomDelimiter_ForInputString()
    {
        // Arrange
        var calculator = new StringCalculator();

        // Act
        var result = calculator.Add("//;\n1;2");

        // Assert
        Assert.Equal(3, result);
    }
}
