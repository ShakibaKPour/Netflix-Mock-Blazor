using Membership.Database.Entities;

namespace Membership.Database.Contexts;

public class Context : DbContext
{
    public DbSet<Director> Directors => Set<Director>();
    public DbSet<Film> Films => Set<Film>();
    public DbSet<Genre> Genres => Set<Genre>();
    public DbSet<FilmGenre> FilmGenres=> Set<FilmGenre>();
    public DbSet<SimilarFilm> SimilarFilms=> Set<SimilarFilm>();
    public Context(DbContextOptions<Context> options) : base(options)
    {

    }
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        foreach (var relationship in builder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
        {
            relationship.DeleteBehavior = DeleteBehavior.Restrict;
        }
    }

}
