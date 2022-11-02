using System;
using System.Linq;
using AutoFixture;
using AutoFixture.AutoMoq;
using Moq;

namespace Sat.Recruitment.Test.Tests
{
    /// <summary>
    /// Test base con funcionalidad común para todos los tests.
    /// </summary>
    /// <typeparam Name="TSut">System Under Test type.</typeparam>
    public class BaseTest<TSut>
        where TSut : class
    {
        /// <summary>
        /// Instancia de autofixture utilizable por todos las instancias de test que hereden de esta clase.
        /// </summary>
        private readonly Fixture fixture;

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseTest{TSut}"/> class.
        /// </summary>
        public BaseTest()
        {
            fixture = new Fixture();
            fixture.Behaviors.OfType<ThrowingRecursionBehavior>()
                    .ToList()
                    .ForEach(b => fixture.Behaviors.Remove(b));
            fixture.Behaviors.Add(new OmitOnRecursionBehavior());
            fixture.Customize(new AutoMoqCustomization { ConfigureMembers = true });
        }

        /// <summary>
        /// Permite crear la instancia del SUT (System Under Test)
        /// </summary>
        /// <typeparam Name="TSut">Tipo SUT que se instanciará. </typeparam>
        /// <returns>Deveulve una instancia con un SUT para testear.</returns>
        protected TSut CreateSUT() => Create<TSut>();

        /// <summary>
        /// Permite inyectar un objeto en el contexto del test.
        /// </summary>
        /// <param Name="target">Instancia a inyectar.</param>
        /// <typeparam Name="TInjectable">Tipo de dato a inyectar.</typeparam>
        /// <returns>Deveulve la instancia TInjectable que se desea agregar.</returns>
        protected TInjectable AddInstance<TInjectable>(TInjectable target)
        {
            fixture.Inject(target);
            return target;
        }

        /// <summary>
        /// Permite crear un Mock y agregarlo al SUT.
        /// </summary>
        /// <typeparam Name="TInjectable">Tipo de dato del cual se va a crear el Mock. Debe ser una interfaz.</typeparam>
        /// <returns>Instancia de Mock con el el tipo TInjectable.</returns>
        /// <see cref="Mock"/>
        protected Mock<TInjectable> AddFromInterface<TInjectable>()
            where TInjectable : class
        {
            Mock<TInjectable> mock = new Mock<TInjectable>();
            fixture.Inject(mock);
            return mock;
        }

        /// <summary>
        /// Permite crear un Mock de una clase concreta e inyecarla a SUT y su contexto.
        /// </summary>
        /// <returns>Instancia de Mock con el el tipo TInjectable. Debe ser una clase.</returns>
        /// <see cref="Mock"/>
        protected Mock<TInjectable> AddFromClass<TInjectable>()
           where TInjectable : class
        {
            Mock<TInjectable> mock = Create<Mock<TInjectable>>();
            fixture.Inject(mock.Object);
            return mock;
        }

        /// <summary>
        /// Permite crear un Mock con sus dependencias mockeadas. 
        /// </summary>
        /// <typeparam Name="TMock">Tipo de dato del Mock.</typeparam>
        /// <returns>Una instancia Mock con sus dependencias.</returns>
        protected TMock Create<TMock>()
            where TMock : class => Fixture.Create<TMock>();

        /// <summary>
        /// Instancia de autofixture utilizable por todos las instancias de test que hereden de esta clase.
        /// </summary>
        protected Fixture Fixture => fixture;
    }
}
