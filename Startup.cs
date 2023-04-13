using Microsoft.EntityFrameworkCore;
using webservice_api.repositories;

public class Startup 
{
    private string serverName;
    private string databaseName;
    private string user;
    private string password;
    public IConfiguration configuration { get; }

    public Startup(IConfiguration configuration) 
    {
        this.configuration = configuration;
        this.serverName = this.configuration["dbms:server"];
        this.databaseName = this.configuration["dbms:database"];
        this.user = this.configuration["dbms:user"];
        this.password = this.configuration["dbms:password"];
    }

    public void ConfigureServices(IServiceCollection services) {
        string connection = $"Server={serverName};Database={databaseName};User Id={user};Password={password};Port=3306";
        services.AddDbContext<SemFilasContext>(options => options.UseSqlServer(connection));
        //services.AddControllers();
        //services.AddEndpointsApiExplorer();
    }
}