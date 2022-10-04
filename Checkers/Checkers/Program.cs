using Checkers.Models;
using Npgsql;
using Microsoft.EntityFrameworkCore;

internal static class Program
{
    // TODO: Add the rest of these.
    public static string? PsqlHostname { get; private set; }
    public static string? PsqlPort { get; private set; }
    public static string? PsqlUser { get; private set; }
    public static string? PsqlPassword { get; private set; }
    public static string? PsqlCatalogName { get; private set; }

    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // These env vars will be set by docker on the server,
        // overriding whatever is in the appsettings.json.
        builder.Configuration.AddEnvironmentVariables();

        // Add services to the container.
        builder.Services.AddControllersWithViews();

        //Set up the variables for the connection
        PsqlHostname = builder.Configuration.GetValue<string>("CHECKERS_PSQL_HOST");
        PsqlPort = builder.Configuration.GetValue<string>("CHECKERS_PSQL_PORT");
        PsqlUser = builder.Configuration.GetValue<string>("CHECKERS_PSQL_USER");
        PsqlPassword = builder.Configuration.GetValue<string>("CHECKERS_PSQL_PASSWORD");
        PsqlCatalogName = builder.Configuration.GetValue<string>("CHECKERS_PSQL_NAME");

        //Create the database context
        checkersdbContext context = new checkersdbContext();

        //Pull down the rows in the player table as a list of player objects
        //You can then modify the objects in the list just like in the below examples
        List<Player> players = context.Players.ToList();

        /***************Create a new record and save it the database***************/
        Player player = new Player(3, "Godzilla", false);
        context.Players.Add(player); //adds the new player to the programs' context
        context.SaveChanges(); //commit the change to the database

        /***************Update a player record***************/
        //You can use FirstOrDefault here since there's only one row
        //In a production app you must handle that the query may return no results
        Player? godzilla = context.Players.Where(p => p.Id == 3).FirstOrDefault(); //get the particular record
        godzilla.Name = "Dracula"; //modify the object
        context.SaveChanges(); //commit the changes to the database

        /***************Delete a player record***************/
        Player? dracula = context.Players.Where(p => p.Id == 3).FirstOrDefault(); //get the particular record
        context.Players.Remove(dracula); //remove it from the context
        context.SaveChanges(); //commit the changes to the database

        /***************Update the board***************/
        //Only one row in the table, so no where clause needed
        Board board = context.Boards.FirstOrDefault();
        board.Boardspaces = "R000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000";
        context.SaveChanges();

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