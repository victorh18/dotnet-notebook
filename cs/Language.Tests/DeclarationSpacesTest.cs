using Xunit;

namespace Language.Tests;

public class DeclarationSpacesTest
{
    [Fact]
    public void TestName()
    {
        var value = true;
        //int j = 0

        if (value) 
        {
            //int i = 0;
            int j = 0;
        }

        int i = 1;

        Assert.Equal(1, i);
    }
}