using System;

using NUnit.Framework;
using SharpTestsEx;

using Ninject;


namespace Learning.Ninject
{
    [TestFixture]
    public class PropertyMethodInjection
    {

        [Test]
        public void PropertyInjection()
        {
            var kernel = new StandardKernel();

            kernel
                .Bind<IFoo>().To<Fee>();

            var result = kernel.Get<FooPropertyInjection>();
            result.FooInstance.Should().Not.Be.Null();
            result.FooInstance.GetType().Should().Be(typeof(Fee));
        }

        [Test]
        public void MethodInjection()
        {
            var kernel = new StandardKernel();

            kernel
                .Bind<IFoo>().To<Fee>();

            var result = kernel.Get<FooMethodInjection>();
            result.GetDataType().Should().Be(typeof(Fee));
        }
    }

   class FooPropertyInjection
   {
       [Inject]
       public IFoo FooInstance { get; set; }
   }

    class FooMethodInjection
    {
        private IFoo data;

        [Inject]
        public void SetData(IFoo data)
        {
            this.data = data;
        }

        public Type GetDataType()
        {
            return data.GetType();
        }
    }
}