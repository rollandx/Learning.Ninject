using System;

using NUnit.Framework;
using SharpTestsEx;

using Ninject;


namespace Learning.Ninject
{
    [TestFixture]
    public class GettingStarted
    {
       
        [Test]
        public void BindIFooToFoo_GettingIFoo_ReturnsFooInstance()
        {
            var kernel = new StandardKernel();

            kernel
                .Bind<IFoo>().To<Foo>();

            var result = kernel.Get<IFoo>();

            result.Should().Not.Be.Null();
            result.GetType().Should().Be(typeof (Foo));
        }

        [Test]
        public void BindIFooToFee_GettingIFoo_ReturnsFeeInstance()
        {
            var kernel = new StandardKernel();

            kernel
                .Bind<IFoo>().To<Fee>();

            var result = kernel.Get<IFoo>();

            result.Should().Not.Be.Null();
            result.GetType().Should().Be(typeof(Fee));
        }

        [Test]
        [TestCase(typeof(IFoo), typeof(Foo))]
        [TestCase(typeof(IFoo), typeof(Fee))]
        public void BindingInterfaceToType_GettingInterface_ReturnsTypeInstance
            (Type @interface, Type concreteType)
        {
            var kernel = new StandardKernel();

            kernel
                .Bind(@interface).To(concreteType);

            var result = kernel.Get(@interface);

            result.Should().Not.Be.Null();
            result.GetType().Should().Be(concreteType);            
        }
    }

    public interface IFoo
    {
        string GetMessage();
    }

    class Foo : IFoo
    {
        public string GetMessage()
        {
            return "Hello from Foo";
        }
    }

    class Fee : IFoo
    {
        public string GetMessage()
        {
            return "Hello from Fee";
        }
    }
}