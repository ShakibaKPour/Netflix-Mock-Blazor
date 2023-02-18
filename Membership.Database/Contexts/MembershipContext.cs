using Common.DTOs;
using Membership.Database.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace Membership.Database.Contexts;

public class MembershipContext : DbContext
{
    public DbSet<Director> Directors => Set<Director>();
    public DbSet<Film> Films => Set<Film>();
    public DbSet<Genre> Genres => Set<Genre>();
    public DbSet<FilmGenre> FilmGenres => Set<FilmGenre>();
    public DbSet<SimilarFilm> SimilarFilms => Set<SimilarFilm>();

    private string description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. In porta urna urna, eu consequat elit egestas eu. Fusce tincidunt, nisl aliquam porta efficitur, arcu velit auctor ipsum, non congue diam turpis in erat. Proin sapien purus, tempus sit amet leo et, faucibus sollicitudin risus. Proin non sem hendrerit, volutpat ipsum sit amet, interdum lacus. Donec dictum sagittis interdum. Mauris nec lorem et felis efficitur commodo. Suspendisse ornare augue pharetra ullamcorper porttitor. Nulla vel augue lacus. Curabitur ac commodo lorem, eget vulputate erat. Aliquam pretium elit risus, quis porta nisi lobortis id. Praesent vel luctus risus, vulputate sagittis lectus. Integer sem velit, molestie quis tincidunt eu, facilisis ac elit. Proin nisl nisl, varius vel dui non, vehicula tincidunt lacus. Nunc tincidunt sapien sed risus placerat, sodales dictum leo mattis. Ut molestie urna non risus consequat, vitae facilisis dui mollis.";

    public MembershipContext(DbContextOptions<MembershipContext> options) : base(options)
    {

    }
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        foreach (var relationship in builder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
        {
            relationship.DeleteBehavior = DeleteBehavior.Restrict;
        }
        builder.Entity<SimilarFilm>().HasKey(sf => new { sf.FilmId, sf.SimilarFilmId });
        //builder.Entity<SimilarFilm>().HasKey(sf => sf.Id);
        builder.Entity<FilmGenre>().HasKey(fg => new { fg.FilmId, fg.GenreId });


        builder.Entity<Film>(entity =>
            {
                entity.HasMany(d => d.SimilarFilms)
                .WithOne(p => p.Film)
                .HasForeignKey(f => f.FilmId)
                .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasMany(d => d.Genres)
                .WithMany(p => p.Films)
                .UsingEntity<FilmGenre>()
                .ToTable("FilmGenre");
            });

        //builder.Entity<Film>()
        //    .HasMany(f => f.SimilarFilms)
        //    .WithOne(sf => sf.Film)
        //    .HasForeignKey(sf => sf.FilmId);

        //builder.Entity<SimilarFilm>()
        //    .HasOne(sf => sf.Similar)
        //    .WithMany(f => f.SimilarFilms)
        //    .HasForeignKey(sf => sf.SimilarFilm.Id);

        //ConfigureRelationsTable(builder);
        //SeedData(builder);

    }

    //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    //{
    //    optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=MembershipDb",
    //        sqlServerOptionsAction: sqlOptions =>
    //        {
    //            sqlOptions.EnableRetryOnFailure(
    //                maxRetryCount: 10,
    //                maxRetryDelay: TimeSpan.FromSeconds(30),
    //                errorNumbersToAdd: null);
    //        });
    //}

}


//private void ConfigureRelationsTable(ModelBuilder modelBuilder)
    //{
    //    modelBuilder.Entity<Film>(entity =>
    //    {
    //        entity.HasMany(d => d.SimilarFilms)
    //        .WithOne(p => p.Film)
    //        .HasForeignKey(f => f.FilmId)
    //        .OnDelete(DeleteBehavior.ClientSetNull);

    //        entity.HasMany(d => d.Genres)
    //        .WithMany(p => p.Films)
    //        .UsingEntity<FilmGenre>()
    //        .ToTable("FilmGenre");
    //    });
    //}


    ///* Seed Data */
    //private void SeedData(ModelBuilder modelBuilder) { 

    //    modelBuilder.Entity<Director>().HasData(
    //        new Director { Id = 1, Name = "Ridley Scott" },
    //        new Director { Id = 1, Name = "Christopher Nolan" },
    //        new Director { Id = 1, Name = "Martin Scorsese" },
    //        new Director { Id = 1, Name = "Peter Jackson" },
    //        new Director { Id = 1, Name = "Edward Zwick" });

    //    modelBuilder.Entity<Film>().HasData(
    //        new Film
    //        {
    //            Title = "Gladiator",
    //            Description = description.Substring(0, 20),
    //            Released = new DateTime(2000, 1, 1),
    //            Free = true,
    //            FilmUrl = "<iframe width=\"560\" height=\"315\" src=\"https://www.youtube.com/embed/uvbavW31adA\" title=\"YouTube video player\" frameborder=\"0\" allow=\"accelerometer; autoplay; clipboard-write; encrypted-media; gyroscope; picture-in-picture; web-share\" allowfullscreen></iframe>",
    //            ImageUrl = "/Images/Gladiator.jfif",
    //            DirectorId = 1,
    //        },
    //        new Film
    //        {
    //            Title = "The Dark Knight",
    //            Description = description,
    //            Released = new DateTime(2008, 1, 1),
    //            Free = true,
    //            FilmUrl = "<iframe width=\"560\" height=\"315\" src=\"https://www.youtube.com/embed/EXeTwQWrcwY\" title=\"YouTube video player\" frameborder=\"0\" allow=\"accelerometer; autoplay; clipboard-write; encrypted-media; gyroscope; picture-in-picture; web-share\" allowfullscreen></iframe>",
    //            ImageUrl = "/Images/DarkKnight.jfif",
    //            DirectorId = 2,
    //        },
    //        new Film
    //        {
    //            Title = "The Departed",
    //            Description = description,
    //            Released = new DateTime(2006, 1, 1),
    //            Free = true,
    //            FilmUrl = "<iframe width=\"560\" height=\"315\" src=\"https://www.youtube.com/embed/iojhqm0JTW4\" title=\"YouTube video player\" frameborder=\"0\" allow=\"accelerometer; autoplay; clipboard-write; encrypted-media; gyroscope; picture-in-picture; web-share\" allowfullscreen></iframe>",
    //            ImageUrl = "/Images/Departed.jfif",
    //            DirectorId = 3,

    //        },
    //        new Film
    //        {
    //            Title = "Lord Of the Rings",
    //            Description = description,
    //            Released = new DateTime(2003, 1, 1),
    //            Free = true,
    //            FilmUrl = "<iframe width=\"560\" height=\"315\" src=\"https://www.youtube.com/embed/r5X-hFf6Bwo\" title=\"YouTube video player\" frameborder=\"0\" allow=\"accelerometer; autoplay; clipboard-write; encrypted-media; gyroscope; picture-in-picture; web-share\" allowfullscreen></iframe>",
    //            ImageUrl = "/Images/LOR.jfif",
    //            DirectorId = 4,
    //        },
    //        new Film
    //        {
    //            Title = "Blood Dimond",
    //            Description = description,
    //            Released = new DateTime(2006, 1, 1),
    //            Free = true,
    //            FilmUrl = "<iframe width=\"560\" height=\"315\" src=\"https://www.youtube.com/embed/yknIZsvQjG4\" title=\"YouTube video player\" frameborder=\"0\" allow=\"accelerometer; autoplay; clipboard-write; encrypted-media; gyroscope; picture-in-picture; web-share\" allowfullscreen></iframe>",
    //            ImageUrl = "/Images/BloodDimond.jfif",
    //            DirectorId = 5,
    //        });

    //    modelBuilder.Entity<SimilarFilm>().HasData(
    //        new SimilarFilm { FilmId = 1, SimilarFilmId = 2 },
    //        new SimilarFilm { FilmId = 1, SimilarFilmId = 3 },
    //        new SimilarFilm { FilmId = 2, SimilarFilmId = 1 }
    //        new SimilarFilm { FilmId = 2, SimilarFilmId = 3 }
    //        new SimilarFilm { FilmId = 2, SimilarFilmId = 4 }
    //        new SimilarFilm { FilmId = 3, SimilarFilmId = 1 }
    //        new SimilarFilm { FilmId = 3, SimilarFilmId = 2 }
    //        new SimilarFilm { FilmId = 3, SimilarFilmId = 5 }
    //        new SimilarFilm { FilmId = 4, SimilarFilmId = 2 }
    //        new SimilarFilm { FilmId = 4, SimilarFilmId = 5 }
    //        new SimilarFilm { FilmId = 5, SimilarFilmId = 3 }
    //        new SimilarFilm { FilmId = 5, SimilarFilmId = 4 });

    //    modelBuilder.Entity<Genre>().HasData(
    //        new Genre { Id = 1, Name = "Adventure" },
    //        new Genre { Id = 2, Name = "Drama" },
    //        new Genre { Id = 3, Name = "Thriller" },
    //        new Genre { Id = 4, Name = "Action" },
    //        new Genre { Id = 5, Name = "Crime" },
    //        new Genre { Id = 6, Name = "Si-Fi" },
    //        new Genre { Id = 7, Name = "Fantasy" },
    //        new Genre { Id = 8, Name = "Biography" });

    //    modelBuilder.Entity<FilmGenre>().HasData(
    //        new FilmGenre { FilmId = 1, GenreId = 1 },
    //        new FilmGenre { FilmId = 1, GenreId = 2 },
    //        new FilmGenre { FilmId = 1, GenreId = 4 },
    //        new FilmGenre { FilmId = 2, GenreId = 2 }
    //        new FilmGenre { FilmId = 2, GenreId = 4 }
    //        new FilmGenre { FilmId = 2, GenreId = 5 }
    //        new FilmGenre { FilmId = 3, GenreId = 2 }
    //        new FilmGenre { FilmId = 3, GenreId = 3 }
    //        new FilmGenre { FilmId = 3, GenreId = 5 }
    //        new FilmGenre { FilmId = 4, GenreId = 1 }
    //        new FilmGenre { FilmId = 4, GenreId = 2 }
    //        new FilmGenre { FilmId = 4, GenreId = 4 }
    //        new FilmGenre { FilmId = 5, GenreId = 1 }
    //        new FilmGenre { FilmId = 5, GenreId = 2 }
    //        new FilmGenre { FilmId = 5, GenreId = 3 });
    //}

