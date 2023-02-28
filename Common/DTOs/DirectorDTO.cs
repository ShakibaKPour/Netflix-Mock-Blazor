namespace Common.DTOs;

public class DirectorDTO
{
    public int Id { get; set; }
    public string? Name { get; set; }

    //public List<FilmDTO>? Films { get; set; }
}

public class DirectorCreateDTO
{
    public string? Name { get; set; }
}

public class DirectorEditDTO : DirectorCreateDTO
{
    public int Id { get; set; }
}

public class DirectorInfoDTO : DirectorDTO
{
    public List<FilmDTO>? Films { get; set; }
}
