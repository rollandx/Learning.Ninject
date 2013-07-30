using System;

using NUnit.Framework;
using SharpTestsEx;

using Ninject;
using Ninject.Activation;


namespace Learning.Ninject
{
    [TestFixture]
    public class Providers
    {
        [Test]
        public void BindIFooToFooUsingProvider_GettingIFoo_ReturnsFooInstance()
        {
            var kernel = new StandardKernel();
            kernel.Bind<IFoo>().ToProvider(new FooProvider());

            var result = kernel.Get<IFoo>();

            result.Should().Not.Be.Null();
            result.GetType().Should().Be(typeof (Foo));
        }

        [Test]
        public void BindIFooToFooUsingMethod_GettingIFoo_ReturnsFooInstance()
        {
            var kernel = new StandardKernel();
            kernel.Bind<IFoo>().ToMethod(context => new Fee());

            var result = kernel.Get<IFoo>();

            result.Should().Not.Be.Null();
            result.GetType().Should().Be(typeof(Fee));
        }
    }

    class FooProvider : Provider<IFoo>
    {
        protected override IFoo CreateInstance(IContext context)
        {
            return new Foo();
        }
    }

}