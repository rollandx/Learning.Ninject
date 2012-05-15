using System;

using NUnit.Framework;
using SharpTestsEx;

using Ninject;
using Ninject.Modules;


namespace Learning.Ninject
{
    [TestFixture]
    public class Modules
    {
        [Test]
        public void BindIFooToFooUsingModules_GettingIFoo_ReturnsFooInstance()
        {
            var kernel = new StandardKernel(new LearningTestModule());

            var result = kernel.Get<IFoo>();

            result.Should().Not.Be.Null();
            result.GetType().Should().Be(typeof (Foo));
        }
    }

    public class LearningTestModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IFoo>().To<Foo>();
        }
    }

}