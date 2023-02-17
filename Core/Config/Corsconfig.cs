namespace JobsApi.Core.Config
{
    public static class CorsConfig
    {
        public static void RegisterCors(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("_myAllowSpecificOrigins", policy =>
                {
                    policy.AllowAnyOrigin();
                });
            });
        }
    }
}