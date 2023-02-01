using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.DTOs
{
    public class SimilarFilms
    {
        public int ParentFilmId { get; set; } = default;

        public int SimilarFilmId { get; set; } = default;

        public SimilarFilms(int parentId, int similarId)
        {
            ParentFilmId= parentId;
            SimilarFilmId= similarId;
        }
    }
}
