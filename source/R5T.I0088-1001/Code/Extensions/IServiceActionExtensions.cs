using System;

using R5T.D1001;
using R5T.T0062;
using R5T.T0063;


namespace R5T.I0088_1001
{
    public static class IServiceActionExtensions
    {
        /// <summary>
        /// Adds the <see cref="HostStartupBase"/> operation as a <see cref="ServiceLifetime.Singleton"/>.
        /// </summary>
        public static IServiceAction<THostStartup> AddHostStartupAction<THostStartup>(this IServiceAction _,
            IServiceAction<IServiceY> serviceYAction)
            where THostStartup : HostStartupBase
        {
            var serviceAction = _.New<THostStartup>(services => services.AddHostStartup<THostStartup>(
                serviceYAction));

            return serviceAction;
        }
    }
}
