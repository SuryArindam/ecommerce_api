namespace ecommerce_api.Config
{
    public class AppConfig:IAppConfig
    {
        public string ConnectionString { get; private set; }
        public AppConfig(IConfiguration configuration)
        {
            this.ConnectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public string GetConnectionString()
        {
            return this.ConnectionString;
        }
    }
}
