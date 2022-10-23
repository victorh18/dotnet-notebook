using Xunit;
using Language.FirstSpace;
using NewLanguage.SecondSpace;

namespace Language.Tests {
    public class AccessModifierTests
    {
        [Fact]
        public void TestingAccessModifiers()
        {
            var someClass = new SomeClass();
            
            someClass.PublicMethod();
            //someClass.PrivateMethod();
            //someClass.InternalMethod();
            //someClass.ProtectedMethod();
            //someClass.ProtectedInternalMethod();
            //someClass.PrivateProtectedMethod();
        }
    }

    public class NewClass : SomeClass
    {
        public void Testing() 
        {
            PublicMethod();
            //PrivateMethod();
            //InternalMethod();
            ProtectedMethod();
            ProtectedInternalMethod();
            //PrivateProtectedMethod();
            
            Assert.True(true);
        }
    }
}