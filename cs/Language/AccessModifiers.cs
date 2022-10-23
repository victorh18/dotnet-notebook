namespace Language.FirstSpace
{
    public class SomeClass
    {
        public void PublicMethod()
        {
            Console.WriteLine("I can execute!");
        }

        private void PrivateMethod()
        {
            Console.WriteLine("I can execute!");
        }

        protected void ProtectedMethod()
        {
            Console.WriteLine("I can execute!");
        }

        internal void InternalMethod()
        {
            Console.WriteLine("I can execute!");
        }

        protected internal void ProtectedInternalMethod()
        {
            Console.WriteLine("I can execute!");
        }

        private protected void PrivateProtectedMethod()
        {
            Console.WriteLine("I can execute!");
        }
    }
}

namespace NewLanguage.SecondSpace 
{
    public class AnotherClass : Language.FirstSpace.SomeClass
    {
        public void TestingInherintance()
        {
            PublicMethod();
            //PrivateMethod();
            InternalMethod();
            ProtectedMethod();
            ProtectedInternalMethod();
            PrivateProtectedMethod();
        }
    }

    public class AnAnotherClass
    {
        public void Test()
        {
            var someClass = new Language.FirstSpace.SomeClass();
            
            someClass.PublicMethod();
            //someClass.PrivateMethod();
            someClass.InternalMethod();
            //someClass.ProtectedMethod();
            someClass.ProtectedInternalMethod();
            //someClass.PrivateProtectedMethod();
        }
    }
}