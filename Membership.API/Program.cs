
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
    cfg.CreateMap<Film, FilmDTO>().ReverseMap();
    cfg.CreateMap<Genre, GenreDTO>().ReverseMap();
    cfg.CreateMap<SimilarFilm, SimilarFilmDTO>().ReverseMap();
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
