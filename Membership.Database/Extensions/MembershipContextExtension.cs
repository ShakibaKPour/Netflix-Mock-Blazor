using Common.DTOs;
using Membership.Database.Services;
using Microsoft.Identity.Client;

namespace Membership.Database.Extensions;

public static class MembershipContextExtension
{
    public static async Task SeedMembershipData(this IDbService service)
    {
        var description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. In porta urna urna, eu consequat elit egestas eu."; //Fusce tincidunt, nisl aliquam porta efficitur, arcu velit auctor ipsum, non congue diam turpis in erat. Proin sapien purus, tempus sit amet leo et, faucibus sollicitudin risus. Proin non sem hendrerit, volutpat ipsum sit amet, interdum lacus. Donec dictum sagittis interdum. Mauris nec lorem et felis efficitur commodo. Suspendisse ornare augue pharetra ullamcorper porttitor. Nulla vel augue lacus. Curabitur ac commodo lorem, eget vulputate erat. Aliquam pretium elit risus, quis porta nisi lobortis id. Praesent vel luctus risus, vulputate sagittis lectus. Integer sem velit, molestie quis tincidunt eu, facilisis ac elit. Proin nisl nisl, varius vel dui non, vehicula tincidunt lacus. Nunc tincidunt sapien sed risus placerat, sodales dictum leo mattis. Ut molestie urna non risus consequat, vitae facilisis dui mollis.";
        try
        {

            await service.AddAsync<Director, DirectorDTO>(new DirectorDTO
            {
                Name = "Ridley Scott"
            });
            await service.AddAsync<Director, DirectorDTO>(new DirectorDTO
            {
                Name = "Christopher Nolan"
            });
            await service.AddAsync<Director, DirectorDTO>(new DirectorDTO
            {
                Name = "Martin Scorsese"
            });
            await service.AddAsync<Director, DirectorDTO>(new DirectorDTO
            {
                Name = "Peter Jackson"
            });
            await service.AddAsync<Director, DirectorDTO>(new DirectorDTO
            {
                Name = "Edward Zwick"
            });
            await service.SaveChangeAsync();

            await service.AddAsync<Genre, GenreDTO>(new GenreDTO
            {
                Name = "Adventure"
            });
            await service.AddAsync<Genre, GenreDTO>(new GenreDTO
            {
                Name = "Drama"
            });
            await service.AddAsync<Genre, GenreDTO>(new GenreDTO
            {
                Name = "Thriller"
            });

            await service.AddAsync<Genre, GenreDTO>(new GenreDTO
            {
                Name = "Action"
            });

            await service.AddAsync<Genre, GenreDTO>(new GenreDTO
            {
                Name = "Crime"
            });

            await service.AddAsync<Genre, GenreDTO>(new GenreDTO
            {
                Name = "Si-Fi"
            });
            await service.AddAsync<Genre, GenreDTO>(new GenreDTO
            {
                Name = "Fantasy"
            });
            await service.AddAsync<Genre, GenreDTO>(new GenreDTO
            {
                Name = "Biography"
            });
            await service.SaveChangeAsync();

            //Add Film
            var director1 = await service.SingleAsync<Director, DirectorDTO>(n => n.Name.Equals("Ridley Scott"));
            var director2 = await service.SingleAsync<Director, DirectorDTO>(n => n.Name.Equals("Christopher Nolan"));
            var director3 = await service.SingleAsync<Director, DirectorDTO>(n => n.Name.Equals("Martin Scorsese"));
            var director4 = await service.SingleAsync<Director, DirectorDTO>(n => n.Name.Equals("Peter Jackson"));
            var director5 = await service.SingleAsync<Director, DirectorDTO>(n => n.Name.Equals("Edward Zwick"));

            var genre1 = await service.SingleAsync<Genre, GenreDTO>(g => g.Name.Equals("Adventure"));
            var genre2 = await service.SingleAsync<Genre, GenreDTO>(g => g.Name.Equals("Drama"));
            var genre3 = await service.SingleAsync<Genre, GenreDTO>(g => g.Name.Equals("Thriller"));
            var genre4 = await service.SingleAsync<Genre, GenreDTO>(g => g.Name.Equals("Action"));
            var genre5 = await service.SingleAsync<Genre, GenreDTO>(g => g.Name.Equals("Crime"));
            var genre6 = await service.SingleAsync<Genre, GenreDTO>(g => g.Name.Equals("Si-Fi"));
            var genre7 = await service.SingleAsync<Genre, GenreDTO>(g => g.Name.Equals("Fantasy"));
            var genre8 = await service.SingleAsync<Genre, GenreDTO>(g => g.Name.Equals("Biography"));

            await service.AddAsync<Film, FilmDTO>(new FilmDTO
            {
                Title = "Gladiator",
                Description = description,
                Released = new DateTime(2000, 1, 1),
                Free = false,
                FilmUrl = "https://www.youtube.com/embed/uvbavW31adA",
                ImageUrl = "/Images/Gladiator.jfif",
                DirectorId = director1.Id
            });
            await service.AddAsync<Film, FilmDTO>(new FilmDTO
            {
                Title = "The Dark Knight",
                Description = description,
                Released = new DateTime(2008, 1, 1),
                Free = false,
                FilmUrl = "https://www.youtube.com/embed/EXeTwQWrcwY",
                ImageUrl = "/Images/DarkKnight.jfif",
                DirectorId = director2.Id
            });
            await service.AddAsync<Film, FilmDTO>(new FilmDTO
            {
                Title = "The Departed",
                Description = description,
                Released = new DateTime(2006, 1, 1),
                Free = true,
                FilmUrl = "https://www.youtube.com/embed/iojhqm0JTW4",
                ImageUrl = "/Images/Departed.jfif",
                DirectorId = director3.Id
            });
            await service.AddAsync<Film, FilmDTO>(new FilmDTO
            {
                Title = "Lord Of the Rings",
                Description = description,
                Released = new DateTime(2003, 1, 1),
                Free = true,
                FilmUrl = "https://www.youtube.com/embed/r5X-hFf6Bwo", //title=\"YouTube video player\" frameborder=\"0\" allow=\"accelerometer; autoplay; clipboard-write; encrypted-media; gyroscope; picture-in-picture; web-share\" allowfullscreen></iframe>",
                ImageUrl = "/Images/LOR.jfif",
                DirectorId = director4.Id
            });
            await service.AddAsync<Film, FilmDTO>(new FilmDTO
            {
                Title = "Blood Dimond",
                Description = description,
                Released = new DateTime(2006, 1, 1),
                Free = true,
                FilmUrl = "https://www.youtube.com/embed/yknIZsvQjG4", // title=\"YouTube video player\" frameborder=\"0\" allow=\"accelerometer; autoplay; clipboard-write; encrypted-media; gyroscope; picture-in-picture; web-share\" allowfullscreen></iframe>",
                ImageUrl = "/Images/BloodDimond.jfif",
                DirectorId = director5.Id
            });
            await service.SaveChangeAsync();

            var film1 = await service.SingleAsync<Film,FilmDTO>(f => f.Title.Equals("Gladiator"));
            var film2 = await service.SingleAsync<Film, FilmDTO>(f => f.Title.Equals("The Dark Knight"));
            var film3 = await service.SingleAsync<Film, FilmDTO>(f => f.Title.Equals("The Departed"));
            var film4 = await service.SingleAsync<Film, FilmDTO>(f => f.Title.Equals("Lord Of the Rings"));
            var film5 = await service.SingleAsync<Film, FilmDTO>(f => f.Title.Equals("Blood Dimond"));

            await service.AddReferenceAsync<SimilarFilm, SimilarFilmDTO>(new SimilarFilmDTO
            {
                FilmId= film1.Id,
                SimilarFilmId = film2.Id 
            });
            await service.AddReferenceAsync<SimilarFilm, SimilarFilmDTO>(new SimilarFilmDTO
            {
                FilmId = film1.Id,
                SimilarFilmId = film3.Id
            });
            await service.AddReferenceAsync<SimilarFilm, SimilarFilmDTO>(new SimilarFilmDTO
            {
                FilmId = film2.Id,
                SimilarFilmId = film1.Id
            });
            await service.AddReferenceAsync<SimilarFilm, SimilarFilmDTO>(new SimilarFilmDTO
            {
                FilmId = film2.Id,
                SimilarFilmId = film3.Id
            });
            await service.AddReferenceAsync<SimilarFilm, SimilarFilmDTO>(new SimilarFilmDTO
            {
                FilmId = film2.Id,
                SimilarFilmId = film4.Id
            });
            await service.AddReferenceAsync<SimilarFilm, SimilarFilmDTO>(new SimilarFilmDTO
            {
                FilmId = film3.Id,
                SimilarFilmId = film1.Id
            });
            await service.AddReferenceAsync<SimilarFilm, SimilarFilmDTO>(new SimilarFilmDTO
            {
                FilmId = film3.Id,
                SimilarFilmId = film2.Id
            });
            await service.AddReferenceAsync<SimilarFilm, SimilarFilmDTO>(new SimilarFilmDTO
            {
                FilmId = film4.Id,
                SimilarFilmId = film2.Id
            });
            await service.AddReferenceAsync<SimilarFilm, SimilarFilmDTO>(new SimilarFilmDTO
            {
                FilmId = film4.Id,
                SimilarFilmId = film1.Id
            });
            await service.AddReferenceAsync<SimilarFilm, SimilarFilmDTO>(new SimilarFilmDTO
            {
                FilmId = film5.Id,
                SimilarFilmId = film2.Id
            });
            await service.AddReferenceAsync<SimilarFilm, SimilarFilmDTO>(new SimilarFilmDTO
            {
                FilmId = film5.Id,
                SimilarFilmId = film3.Id
            });
            await service.AddReferenceAsync<SimilarFilm, SimilarFilmDTO>(new SimilarFilmDTO
            {
                FilmId = film5.Id,
                SimilarFilmId = film4.Id
            });

            await service.SaveChangeAsync();

            await service.AddReferenceAsync<FilmGenre, FilmGenreDTO>(new FilmGenreDTO
            {
                FilmId = film1.Id,
                GenreId = genre2.Id
            });
            await service.AddReferenceAsync<FilmGenre, FilmGenreDTO>(new FilmGenreDTO
            {
                FilmId = film1.Id,
                GenreId = genre3.Id
            });
            await service.AddReferenceAsync<FilmGenre, FilmGenreDTO>(new FilmGenreDTO
            {
                FilmId = film1.Id,
                GenreId = genre5.Id
            });
            await service.AddReferenceAsync<FilmGenre, FilmGenreDTO>(new FilmGenreDTO
            {
                FilmId = film2.Id,
                GenreId = genre1.Id
            });
            await service.AddReferenceAsync<FilmGenre, FilmGenreDTO>(new FilmGenreDTO
            {
                FilmId = film2.Id,
                GenreId = genre2.Id
            });
            await service.AddReferenceAsync<FilmGenre, FilmGenreDTO>(new FilmGenreDTO
            {
                FilmId = film3.Id,
                GenreId = genre1.Id
            });
            await service.AddReferenceAsync<FilmGenre, FilmGenreDTO>(new FilmGenreDTO
            {
                FilmId = film3.Id,
                GenreId = genre5.Id
            });
            await service.AddReferenceAsync<FilmGenre, FilmGenreDTO>(new FilmGenreDTO
            {
                FilmId = film4.Id,
                GenreId = genre2.Id
            });
            await service.AddReferenceAsync<FilmGenre, FilmGenreDTO>(new FilmGenreDTO
            {
                FilmId = film5.Id,
                GenreId = genre3.Id
            });

            await service.AddReferenceAsync<FilmGenre, FilmGenreDTO>(new FilmGenreDTO
            {
                FilmId = film5.Id,
                GenreId = genre8.Id
            });
            await service.AddReferenceAsync<FilmGenre, FilmGenreDTO>(new FilmGenreDTO
            {
                FilmId = film5.Id,
                GenreId = genre7.Id
            });
            await service.AddReferenceAsync<FilmGenre, FilmGenreDTO>(new FilmGenreDTO
            {
                FilmId = film5.Id,
                GenreId = genre6.Id
            });
            await service.SaveChangeAsync();
        }
        catch (Exception ex)
        {
            throw;
        }

    }
}
