using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Omnium.Nswag.Client
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddOmniumClient(this IServiceCollection services,
            IConfiguration configuration, IWebHostEnvironment environment)
        {
            services.AddSingleton<IOmniumClientBaseSettings, OmniumClientBaseSettings>();

            services.AddHttpClient<IBusinessCustomersClient, BusinessCustomersClient>(client =>
            {
                client.BaseAddress = new Uri(configuration["Omnium:BaseAddress"]);
            });

            services.AddHttpClient<ICartClient, CartClient>(client =>
            {
                client.BaseAddress = new Uri(configuration["Omnium:BaseAddress"]);
            });

            services.AddHttpClient<IClickAndCollectClient, ClickAndCollectClient>(client =>
            {
                client.BaseAddress = new Uri(configuration["Omnium:BaseAddress"]);
            });

            services.AddHttpClient<IGiftCardClient, GiftCardClient>(client =>
            {
                client.BaseAddress = new Uri(configuration["Omnium:BaseAddress"]);
            });

            services.AddHttpClient<IGposApiClient, GposApiClient>(client =>
            {
                client.BaseAddress = new Uri(configuration["Omnium:BaseAddress"]);
            });

            services.AddHttpClient<IImagesDeliveryClient, ImagesDeliveryClient>(client =>
            {
                client.BaseAddress = new Uri(configuration["Omnium:BaseAddress"]);
            });

            services.AddHttpClient<IInventoryClient, InventoryClient>(client =>
            {
                client.BaseAddress = new Uri(configuration["Omnium:BaseAddress"]);
            });

            services.AddHttpClient<IInvoicesClient, InvoicesClient>(client =>
            {
                client.BaseAddress = new Uri(configuration["Omnium:BaseAddress"]);
            });

            services.AddHttpClient<INotificationsClient, NotificationsClient>(client =>
            {
                client.BaseAddress = new Uri(configuration["Omnium:BaseAddress"]);
            });

            services.AddHttpClient<IOrdersClient, OrdersClient>(client =>
            {
                client.BaseAddress = new Uri(configuration["Omnium:BaseAddress"]);
            });

            services.AddHttpClient<IPricesClient, PricesClient>(client =>
            {
                client.BaseAddress = new Uri(configuration["Omnium:BaseAddress"]);
            });

            services.AddHttpClient<IPrivateCustomersClient, PrivateCustomersClient>(client =>
            {
                client.BaseAddress = new Uri(configuration["Omnium:BaseAddress"]);
            });

            services.AddHttpClient<IProductCategoriesClient, ProductCategoriesClient>(client =>
            {
                client.BaseAddress = new Uri(configuration["Omnium:BaseAddress"]);
            });

            services.AddHttpClient<IProductsClient, ProductsClient>(client =>
            {
                client.BaseAddress = new Uri(configuration["Omnium:BaseAddress"]);
            });

            services.AddHttpClient<IProjectsClient, ProjectsClient>(client =>
            {
                client.BaseAddress = new Uri(configuration["Omnium:BaseAddress"]);
            });

            services.AddHttpClient<IProjectTypesClient, ProjectTypesClient>(client =>
            {
                client.BaseAddress = new Uri(configuration["Omnium:BaseAddress"]);
            });

            services.AddHttpClient<IRatingsClient, RatingsClient>(client =>
            {
                client.BaseAddress = new Uri(configuration["Omnium:BaseAddress"]);
            });

            services.AddHttpClient<IRecommendationsClient, RecommendationsClient>(client =>
            {
                client.BaseAddress = new Uri(configuration["Omnium:BaseAddress"]);
            });

            services.AddHttpClient<IReturnsClient, ReturnsClient>(client =>
            {
                client.BaseAddress = new Uri(configuration["Omnium:BaseAddress"]);
            });

            services.AddHttpClient<IStoresClient, StoresClient>(client =>
            {
                client.BaseAddress = new Uri(configuration["Omnium:BaseAddress"]);
            });

            services.AddHttpClient<ITokenClient, TokenClient>(client =>
            {
                client.BaseAddress = new Uri(configuration["Omnium:BaseAddress"]);
            });

            services.AddHttpClient<ITriggersClient, TriggersClient>(client =>
            {
                client.BaseAddress = new Uri(configuration["Omnium:BaseAddress"]);
            });


            return services;
        }
    }
}