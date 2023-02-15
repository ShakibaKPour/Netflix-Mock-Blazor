
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

    cfg.CreateMap<Film, FilmDTO>().ReverseMap()
    .ForMember(dest => dest.SimilarFilms, src=> src.Ignore())
    .ForMember(dest => dest.Director, src=> src.Ignore())
    .ForMember(dest => dest.Genres, src=> src.Ignore());
    cfg.CreateMap<Film, FilmCreateDTO>().ReverseMap()
    .ForMember(dest => dest.SimilarFilms, src => src.Ignore())
    .ForMember(dest => dest.Director, src => src.Ignore());
    cfg.CreateMap<Film, FilmEditDTO>().ReverseMap()
    .ForMember(dest => dest.SimilarFilms, src => src.Ignore())
    .ForMember(dest => dest.Director, src => src.Ignore());

    cfg.CreateMap<Genre, GenreDTO>().ReverseMap()
    .ForMember(dest => dest.Films, src => src.Ignore());
    cfg.CreateMap<Genre, GenreCreateDTO>().ReverseMap()
    .ForMember(dest => dest.Films, src => src.Ignore());
    cfg.CreateMap<Genre, GenreEditDTO>().ReverseMap()
    .ForMember(dest => dest.Films, src => src.Ignore());

    cfg.CreateMap<SimilarFilm, SimilarFilmDTO>().ReverseMap()
    .ForMember(dest => dest.Similar, src => src.Ignore());

    cfg.CreateMap<FilmGenre, FilmGenreDTO>().ReverseMap()
    .ForMember(dest => dest.Film, src => src.Ignore())
    .ForMember(dest => dest.Genre, src => src.Ignore());
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
