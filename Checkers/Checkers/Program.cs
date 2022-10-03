internal static class Program
{
    // TODO: Add the rest of these.
    public static string? PsqlHostname { get; private set; }

    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // These env vars will be set by docker on the server,
        // overriding whatever is in the appsettings.json.
        builder.Configuration.AddEnvironmentVariables();

        // Add services to the container.
        builder.Services.AddControllersWithViews();

        // TODO: Add the rest of these.
        PsqlHostname = builder.Configuration.GetValue<string>("CHECKERS_PSQL_HOST");
        // "CHECKERS_PSQL_HOST": "Put hostname here!",
        // "CHECKERS_PSQL_PORT": 5432,
        // "CHECKERS_PSQL_USER": "Put username here!",
        // "CHECKERS_PSQL_PASSWORD": "Put password here!",
        // "CHECKERS_PSQL_NAME": "Put catalog name here!",
        // "CHECKERS_PSQL_SCHEMA": "Put schema here!"

        // TODO: After all of these are added you can create a DbContext class
        // the DbContext will be what connects to PSQL and will reference this 
        // class Program.PsqlHostname

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (!app.Environment.IsDevelopment())
        {
        }

        app.UseStaticFiles();
        app.UseRouting();


        app.MapControllerRoute(
            name: "default",
            pattern: "{controller}/{action=Index}/{id?}");

        app.MapFallbackToFile("index.html"); ;

        app.Run();
    }
}