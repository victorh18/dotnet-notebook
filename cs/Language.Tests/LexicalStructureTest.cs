//#define INCLUDE_FAILING_TEST
using Xunit;
//using Language;

namespace Language.Tests;

public class LexicalStructureTest
{
    [Fact]
    public void CanUseUnicodeEscapesAsTokens()
    {
        Assert.Equal(LexicalStructure.UsingNormalCharacters(true), LexicalStructure.UsingUnicodeEscapeSequences(true));
    }

    [Fact]
    public void CanUseKeywordsAsIdentifiersWithPrefix()
    {
        Assert.True(LexicalStructure.st\u0061tic(true));
    }

    [Fact]
    public void IntegerLiterals()
    {
        var simpleLiteral = 123;
        var decoratedLiteral = 10_543;
        var unsignedLiteral = 500U;
        var longLiteral = 5669L;

        var hexLiteral = 0xFf;
        var decoratedHexLiteral = 0X1b_a0_44_fEL;

        var binaryLiteral = 0b101;
        var binaryDecoratedLiteral = 0b1111_1111_0000UL;

        Assert.IsType<int>(simpleLiteral);
        Assert.Equal(123, simpleLiteral);

        Assert.IsType<int>(decoratedLiteral);
        Assert.Equal(10543, decoratedLiteral);

        Assert.IsType<uint>(unsignedLiteral);
        Assert.Equal(500U, unsignedLiteral);

        Assert.IsType<long>(longLiteral);
        Assert.Equal(5669, longLiteral);

        Assert.IsType<int>(hexLiteral);
        Assert.Equal(255, hexLiteral);

        Assert.IsType<long>(decoratedHexLiteral);
        Assert.Equal(463488254, decoratedHexLiteral);

        Assert.IsType<int>(binaryLiteral);
        Assert.Equal(5, binaryLiteral);

        Assert.IsType<ulong>(binaryDecoratedLiteral);
        Assert.Equal(4080UL, binaryDecoratedLiteral);
    }

    [Fact]
    public void RealLiterals()
    {
        // Given
        var doubleLiteral = 123.0;
        var doubleDecoratorLiteral = 1_23.9_8;
        var doubleExponentLiteral = 43E5;
        var doubleExponentLiteralNegative = 21e-3;
        var doubleExponentValidDecorator = 98e1_2;

        var floatLiteral = 123.0F;
        var decimalLiteral = 123.0M;
        // var invalidDoubleLiteral = 123_.90;
        // var invalidDoubleLiteral = 123.9_;
        // var invalidDoubleExponentDecorator = 22e_4;

        // Then
        Assert.IsType<double>(doubleLiteral);
        Assert.Equal(123.0, doubleLiteral);

        Assert.Equal(123.98, doubleDecoratorLiteral);
        Assert.Equal(4300000, doubleExponentLiteral);
        Assert.Equal(0.021, doubleExponentLiteralNegative);
        Assert.Equal(98000000000000, doubleExponentValidDecorator);

        Assert.IsType<float>(floatLiteral);
        Assert.Equal((float)123.0, floatLiteral);
        Assert.IsType<decimal>(decimalLiteral);
        Assert.Equal((decimal)123.0,decimalLiteral);
    }

    [Fact]
    public void StringLiterals()
    {
        var regularStringLiteral = "hello world!";
        var escapedStringLiteral = "hello world\u0021";

        var verbatimStringLiteral = @"hello world\u0021";

        var stringNewLines = "1\r\n2\r\n3";
        var verbatimNewLines = @"1
2
3";
    
        Assert.Equal(regularStringLiteral, escapedStringLiteral);
        Assert.Same(escapedStringLiteral, regularStringLiteral);

        Assert.Same(stringNewLines, verbatimNewLines);

        Assert.NotEqual(escapedStringLiteral, verbatimStringLiteral);
    }
#if INCLUDE_FAILING_TEST
    [Fact]
    public void PreprocessingDirectives()
    {
        #warning This is a warning created by the programmer
        #line 69 "nice.cs"
        Assert.True(false);
    }
#endif
}