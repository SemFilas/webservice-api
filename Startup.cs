using Microsoft.EntityFrameworkCore;
using webservice_api.repositories;

public class Startup 
{
    private string serverName;
    private string port;
    private string databaseName;
    private string user;
    private string password;
    public IConfiguration configuration { get; }

    public Startup(IConfiguration configuration) 
    {
        this.configuration = configuration;
        this.serverName = this.configuration["dbms:server"] ?? "localhost";
        this.port = this.configuration["dbms:port"] ?? "1433";
        this.databaseName = this.configuration["dbms:database"] ?? "SemFilas";
        this.user = this.configuration["dbms:user"] ?? "sa";
        this.password = this.configuration["dbms:password"] ?? "Ke@S3mfilas";
    }

    public void ConfigureServices(IServiceCollection services) {
        string connection = $"Server={serverName}, {port};Initial Catalog={databaseName};User Id={user};Password={password};TrustServerCertificate=True";
        services.AddDbContext<SemFilasContext>(options => options.UseSqlServer(connection));
        //services.AddControllers();
        //services.AddEndpointsApiExplorer();
    }
}