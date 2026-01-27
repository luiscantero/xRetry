using Reqnroll.Generator.Plugins;
using Reqnroll.Generator.UnitTestProvider;
using Reqnroll.Infrastructure;
using Reqnroll.UnitTestProvider;
using xRetry.Reqnroll.v3;
using xRetry.Reqnroll.v3.Parsers;

[assembly: GeneratorPlugin(typeof(GeneratorPlugin))]

namespace xRetry.Reqnroll.v3
{
    public class GeneratorPlugin : IGeneratorPlugin
    {
        
        private const string XUnit3UnitTestProviderName = "xunit3";
        
        public void Initialize(GeneratorPluginEvents generatorPluginEvents, GeneratorPluginParameters generatorPluginParameters,
            UnitTestProviderConfiguration unitTestProviderConfiguration)
        {
            unitTestProviderConfiguration.UseUnitTestProvider(XUnit3UnitTestProviderName);
            generatorPluginEvents.CustomizeDependencies += CustomiseDependencies;
        }

        private static void CustomiseDependencies(object sender, CustomizeDependenciesEventArgs eventArgs)
        {
            eventArgs.ObjectContainer.RegisterTypeAs<RetryTagParser, IRetryTagParser>();
            eventArgs.ObjectContainer.RegisterTypeAs<TestGeneratorProvider, IUnitTestGeneratorProvider>();
        }
        
    }
}