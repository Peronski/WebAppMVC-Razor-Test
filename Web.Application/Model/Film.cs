using System.ComponentModel.DataAnnotations;

namespace Test_Cinema.Models {
    public class Film {
        //[Key]
        public int Id { get; set; }
        //[Required]
        public string Titolo { get; set; }
        public string Autore { get; set; }
        public string Produttore { get; set; }
        public string Genere { get; set; }
        public TimeSpan Durata { get; set; }
    }
}
