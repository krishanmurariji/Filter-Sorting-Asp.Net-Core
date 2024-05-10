using System.ComponentModel.DataAnnotations;

namespace TodayTest.Users.Dto
{
    public class ChangeUserLanguageDto
    {
        [Required]
        public string LanguageName { get; set; }
    }
}