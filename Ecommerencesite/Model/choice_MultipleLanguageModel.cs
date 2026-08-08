using System.ComponentModel.DataAnnotations;

namespace Ecommerencesite.Model
{
          public class choice_MultipleLanguageModel
          {
                    [Key]
                    public int Id { get; set; }
                    public string PreferredLanguage { get; set; } = " "; // 'en', 'hi', 'ur'
                    public string? SessionId { get; set; } // For guest users without login
          }
}