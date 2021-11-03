using System;
using System.Threading.Tasks;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using R5T.D0088;
using R5T.D1001;
using R5T.D1001.A001;
using R5T.T0064;


namespace R5T.I0088_1001
{
    [ServiceImplementationMarker]
    public abstract class HostStartupBase : IHostStartup
    {
        protected IServiceY ServiceY { get; }


        public HostStartupBase(
            IServiceY serviceY)
        {
            this.ServiceY = serviceY;
        }

        public abstract Task ConfigureConfiguration(IConfigurationBuilder configurationBuilder);

        public async Task ConfigureServices(IServiceCollection services)
        {
            Console.WriteLine($"In {nameof(HostStartupBase)}.{nameof(ConfigureServices)}.");

            await this.ServiceY.RunY();

            var serviceZActionAggregation = Instances.ServiceAction.AddServiceZActionAggregation();

            await this.ConfigureServicesAdditional(services, serviceZActionAggregation);
        }

        protected abstract Task ConfigureServicesAdditional(IServiceCollection services,
            IServiceZActionAggregation serviceZActionAggregation);
    }
}
