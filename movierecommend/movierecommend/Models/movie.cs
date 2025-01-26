using System.ComponentModel.DataAnnotations;

namespace movierecommend.Models
{
   
     public class movie

     {
        public int Id { get; set; } 
        public string Title { get; set; }
        public string Description { get; set; }

        [MinLength(1, ErrorMessage = "At least one genre must be selected.")]
        [MaxLength(3, ErrorMessage = "You can select up to 3 genres.")]
        public List<int> Genres { get; set; } = new List<int>(); // selected genres

        public static List<Genre> GenresList => new List<Genre>
        {
        new Genre { Id = 1, Name = "Action" },
        new Genre { Id = 2, Name = "Comedy" },
        new Genre { Id = 3, Name = "Drama" },
        new Genre { Id = 4, Name = "Fantasy" },
        new Genre { Id = 5, Name = "Horror" },
        new Genre { Id = 6, Name = "Romance" },
        new Genre { Id = 7, Name = "Science Fiction" },
        new Genre { Id = 8, Name = "Thriller" },
        new Genre { Id = 9, Name = "Adventure" }
        };
    }
    public class Genre
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

}
