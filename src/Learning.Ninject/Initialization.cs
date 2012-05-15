using System;

using NUnit.Framework;
using SharpTestsEx;

using Ninject;


namespace Learning.Ninject
{
    [TestFixture]
    public class Initialization
    {

        [Test]
        public void SingleCtor()
        {
            var kernel = new StandardKernel();

            kernel
                .Bind<IFoo>().To<Fee>();

            var result = kernel.Get<Writer>();

            result.Should().Not.Be.Null();
            result.Source.GetType().Should().Be(typeof(Fee));
        }

        [Test]
        public void TwoCtors()
        {
            var kernel = new StandardKernel();

            kernel
                .Bind<IFoo>().To<Fee>();

            kernel
                .Bind<Writer>().ToSelf();

            var result = kernel.Get<Writer2>();


            result.Should().Not.Be.Null();
            result.Source.GetType().Should().Be(typeof(Fee));
        }
    }

    public class Writer
    {
        public readonly IFoo Source;
        public Writer(IFoo source)
        {
            Source = source;
        }
    }

    public class Writer2
    {
        public readonly IFoo Source;
        [Inject]
        public Writer2(IFoo source)
        {
            Source = source;
        }

        public Writer2(Writer writer)
        {
            throw new NotImplementedException();
        }
    }
}