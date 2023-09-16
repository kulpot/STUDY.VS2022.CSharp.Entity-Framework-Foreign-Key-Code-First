using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Remoting.Contexts;

//ref link:https://www.youtube.com/watch?v=oJxkj1QODTA&list=PLRwVmtr-pp06bXl6mbwDfK1eW9sAIvWUZ&index=7
// EntityFramework - is a object relational mapping(ORM) data tool
// Nuget Installed --EntityFramework-- Entity Framework 6 (EF6) is a tried and tested object-relational mapper for .NET with many years of feature development and stabilization.
// SQL Server Management Studio - Database app
// SQL Server Profiler - app for tracing SQL Database

// CRUD - Create, Read, Update, Delete


/*  AppConfig
 *  
 *  <?xml version="1.0" encoding="utf-8" ?>
<configuration>
	<configSections>
		<section name="entityFramework" type="System.Data.Entity.Internal.ConfigFile.EntityFrameworkSection, EntityFramework, Version=6.4.4, Culture=neutral"/>
	</configSections>
	<entityFramework>
		<defaultConnectionFactory type="System.Data.Entity.Infrastructure.SqlConnectionFactory, EntityFramework"/>
		<providers>
			<provider invariantName="System.Data.SqlClient" type="System.Data.Entity.SqlServer.SqlProviderServices, EntityFramework.SqlServer"/>
		</providers>
	</entityFramework>
<connectionStrings>
	<add name="MeContext" connectionString="Data Source=.;Initial Catalog=MyTestDb;Integrated Security=True" providerName="System.Data.SqlClient"/>
</connectionStrings>
</configuration>
 * 
 * 
 * 
 *      ------ SQLServer - New Query CMD --------
 *      use MyTestDb

 *      select *
        from Videos

        select *
        from PlayLists
        
        use master          // switch database
 * 
 * 
 */



class PlayList
{
    public int ID { get; set; }
    public string Title { get; set; }
    public List<Video> Videos { get; set; }
}

class Video
{
    public int ID { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
}

class MeContext : DbContext     // PipeLine --SQLServer and VS-- Schema
{
    //public MeContext() : base(@"Data Source=.;Initial Catalog=MyTestDb;username = whateverUsername;password = yadayadayada")
    public MeContext() : base(@"Data Source=.;Initial Catalog=MyTestDb;Integrated Security=True")
    {
    }
    public DbSet<Video> Videos { get; set; }
    public DbSet<PlayList> Playlists { get; set; }

}

class MainClass
{
    static void Main()
    {
        MeContext db = new MeContext(); // Pipeline to VS and EntityFramework SQLServer app

        db.Database.Delete();
        Video meVideo = new Video
        {
            Title = "Hello World Entity Framework",
            Description = "Learn the entity framework"
        };
        db.Videos.Add(meVideo);
        PlayList mePlaylist = new PlayList();
        mePlaylist.Title = "Entity Framework";

        mePlaylist.Videos = new List<Video> { meVideo };
        db.SaveChanges();



        //// CRUD - Create, Read, Update, Delete
        //var meContext = new MeContext();
        //Video vid = meContext.Videos.FirstOrDefault();
        //
        //meContext.Videos.Remove(vid);   // --- Delete ---
        //meContext.SaveChanges();

        //vid.Title = "Beggining CRUD"; // --- Update ---
        //meContext.SaveChanges();


        //Console.WriteLine(vid.Title);   // --- Read ----
        //Console.WriteLine(vid.Description); // --- Read ----

        //Video vid = new Video     // ---- Create ----
        //{
        //    Title = "Entity Framework CRUD Operations",
        //    Description = "Learn the meaning of CRUD."
        //};
        //meContext.Videos.Add(vid);
        //meContext.SaveChanges();




        //var vid = new Video
        //{
        //    Title = "Hello World Entity Framework",
        //    Description = "Learn about the entity framework"
        //};
        //var meContext = new MeContext();


        //Video meVideo = meContext.Videos.Single();    // ----Read----
        //Console.WriteLine(meVideo.ID);
        //Console.WriteLine(meVideo.Title);
        //Console.WriteLine(meVideo.Description);



        //meContext.Database.Delete();  // ----Delete---

        //meContext.Videos.Add(vid);    // ----Create---
        //meContext.SaveChanges();
    }
}