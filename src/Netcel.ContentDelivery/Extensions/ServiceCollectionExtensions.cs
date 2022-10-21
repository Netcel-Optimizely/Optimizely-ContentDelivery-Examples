using ContentCloud.Domain.PropertySerialization;
using EPiServer.ContentApi.Core.Serialization;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Netcel.ContentDelivery.ContentApiModelConvertors;
using Netcel.ContentDelivery.ContentConvertor;
using Netcel.ContentDelivery.ContentConvertorProviders;
using Netcel.ContentDelivery.Interfaces;

namespace Netcel.ContentDelivery.Extensions

{
    /// <summary>
    /// Adds service collection extensions
    /// </summary>
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// Add content delivery api customization
        /// </summary>
        /// <param name="services"></param>
        public static void AddContentDeliveryApiCustomization(this IServiceCollection services)
        {
            services.AddSingleton<PageContentConvertor>();
            services.AddSingleton<BlockContentConvertor>();

            services.TryAddEnumerable(ServiceDescriptor.Scoped<IContentApiModelConvertor, PageDataApiModelConvertor>());

            services.TryAddEnumerable(ServiceDescriptor.Singleton<IContentConverterProvider, PageContentConvertorProvider>());
            services.TryAddEnumerable(ServiceDescriptor.Singleton<IContentConverterProvider, BlockContentConvertorProvider>());

            services.TryAddEnumerable(ServiceDescriptor.Singleton<IPropertyConverterProvider, ListPropertyConvertorProvider>());
            services.TryAddScoped<BenefitItemListPropertyConvertor>();


        }
    }
}