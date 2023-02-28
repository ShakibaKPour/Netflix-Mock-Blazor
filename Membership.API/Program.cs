
using Membership.Database.Contexts;
using Membership.Database.Entities;
using Membership.Database.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using static System.Collections.Specialized.BitVector32;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddCors(policy =>
{
    policy.AddPolicy("CorsAllAccessPolicy", opt =>
    opt.AllowAnyOrigin()
    .AllowAnyHeader()
    .AllowAnyMethod()
    );
});
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<MembershipContext>(
    options => options.UseSqlServer(
        builder.Configuration.GetConnectionString("NetflixConnection")));

builder.Services.AddScoped<IDbService, DbService>();

var config = new AutoMapper.MapperConfiguration(cfg =>
{
    cfg.CreateMap<Director, DirectorDTO>().ReverseMap();
    cfg.CreateMap<Director, DirectorCreateDTO>().ReverseMap();
    cfg.CreateMap<Director, DirectorEditDTO>().ReverseMap();
    cfg.CreateMap<Director, DirectorInfoDTO>();

    cfg.CreateMap<Film, FilmDTO>()
    /*.ForMember(dest => dest.SimilarFilms, opt => opt.MapFrom(src => src.SimilarFilms))
    .ForMember(dest => dest.Genres, opt => opt.MapFrom(src => src.Genres))
    .ForMember(dest => dest.Director, opt => opt.MapFrom(src => src.Director))*/
    .ReverseMap();

    cfg.CreateMap<Film, FilmCreateDTO>().ReverseMap();
    
    cfg.CreateMap<Film, FilmEditDTO>().ReverseMap();

    cfg.CreateMap<Film, FilmInfoDTO>();

    cfg.CreateMap<Genre, GenreDTO>().ReverseMap();

    cfg.CreateMap<Genre, GenreCreateDTO>().ReverseMap();

    cfg.CreateMap<Genre, GenreEditDTO>().ReverseMap();

    cfg.CreateMap<Genre, GenreInfoDTO>();

    cfg.CreateMap<SimilarFilm, SimilarFilmDTO>().ReverseMap();

    cfg.CreateMap<SimilarFilm, FilmInfoDTO>();

    cfg.CreateMap<FilmGenre, FilmGenreDTO>().ReverseMap();
    
});
var mapper = config.CreateMapper();
builder.Services.AddSingleton(mapper);



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("CorsAllAccessPolicy");

app.UseAuthorization();

app.MapControllers();

app.Run();
