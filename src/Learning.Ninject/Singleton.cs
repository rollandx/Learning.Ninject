using System;

using NUnit.Framework;
using SharpTestsEx;

using Ninject;


namespace Learning.Ninject
{
    [TestFixture]
    public class Singleton
    {

        [Test]
        public void BindIFooToFooInSingletonScope_GettingIFooTwoTimes_ReturnsSameFooInstance()
        {
            var kernel = new StandardKernel();

            kernel
                .Bind<IFoo>().To<Foo>().InSingletonScope();

            var resultA = kernel.Get<IFoo>();
            var resultB = kernel.Get<IFoo>();

            resultA.Should().Not.Be.Null();
            resultB.Should().Not.Be.Null();
            resultA.Should().Be.SameInstanceAs(resultB);
        }

        [Test]
        public void BindIFooToFooInstance_GettingIFooTwoTimes_ReturnsSameFooInstance()
        {
            var kernel = new StandardKernel();

            var source = new Foo();

            kernel
                .Bind<IFoo>().ToConstant(source);

            var resultA = kernel.Get<IFoo>();
            var resultB = kernel.Get<IFoo>();

            resultA.Should().Not.Be.Null();
            resultB.Should().Not.Be.Null();
            resultA.Should().Be.SameInstanceAs(resultB);
            source.Should().Be.SameInstanceAs(resultA);
        }
    }
}