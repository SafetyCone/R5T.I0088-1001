using System;

using Microsoft.Extensions.DependencyInjection;

using R5T.D1001;
using R5T.T0063;


namespace R5T.I0088_1001
{
    public static class IServiceCollectionExtensions
    {
        /// <summary>
        /// Adds the <see cref="HostStartupBase"/> operation as a <see cref="ServiceLifetime.Singleton"/>.
        /// </summary>
        public static IServiceCollection AddHostStartup<THostStartup>(this IServiceCollection services,
            IServiceAction<IServiceY> serviceYAction)
            where THostStartup : HostStartupBase
        {
            services.AddSingleton<THostStartup>()
                .Run(serviceYAction)
                ;

            return services;
        }
    }
}
