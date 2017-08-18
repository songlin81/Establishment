using StructureMap;

namespace Structure
{
    public class FoundationService : IService
    {
        public void init()
        {
            IContainer container = ConfigureDependencies();
            IAppEngine appEngine = container.GetInstance<IAppEngine>();
            appEngine.Run();
        }

        private static IContainer ConfigureDependencies()
        {
            return new Container(x =>
            {
                x.For<IAppEngine>().Use<AppEngine>();
                x.For<ITransform>().Use<MaxtrixTransform>();
                x.For<IOutputDisplay>().Use<ConsoleOutputDisplay>();
            });
        }
    }
}
