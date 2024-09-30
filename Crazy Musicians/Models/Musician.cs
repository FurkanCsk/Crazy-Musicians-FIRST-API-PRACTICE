using System.ComponentModel.DataAnnotations;

namespace Crazy_Musicians.Models
{
    public class Musician
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Musician name is required.")]
        [StringLength(50,MinimumLength =3,ErrorMessage = "The name must be between 3 and 50 characters.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Musician Career is required.")]
        [StringLength(50, MinimumLength = 10, ErrorMessage = "The Career must be between 10 and 50 characters.")]
        public string Career { get; set; }

        [Required(ErrorMessage = "Musician Funny Property is required.")]
        [StringLength(240, MinimumLength = 10, ErrorMessage = "The Funny Property must be between 3 and 100 characters.")]
        public string FunnyProperty { get; set; }
    }
}
