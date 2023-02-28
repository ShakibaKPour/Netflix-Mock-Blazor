namespace Common.DTOs;

public class FilmDTO
{
    public int Id { get; set; }
    public string? Title { get; set; }
    
    public string? Description { get; set; }
   
    public DateTime Released { get; set; }
    public int DirectorId { get; set; }   
    public bool Free { get; set; }
    public string? ImageUrl { get; set; }
    public string? FilmUrl { get; set; }

    public DirectorDTO? Director { get; set; } =null!;
    public List<GenreDTO>? Genres { get; set; }

    public List<SimilarFilmDTO>? SimilarFilms { get; set; }

    public int[] SelectedValues { get; set; } = null!;
}

public class FilmCreateDTO
{
    public string Title { get; set; }

    public string Description { get; set; }

    public DateTime Released { get; set; }
    public int DirectorId { get; set; }
    public bool Free { get; set; }
    public string ImageUrl { get; set; }
    public string FilmUrl { get; set; }
    public int[] SelectedValues { get; set; } = new int[] { };

}

public class FilmEditDTO : FilmCreateDTO
{
    public int Id { get; set; }
}

public class FilmInfoDTO : FilmEditDTO
{
    
}