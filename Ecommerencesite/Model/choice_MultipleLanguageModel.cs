using System.ComponentModel.DataAnnotations;

namespace Ecommerencesite.Model
{
          public class choice_MultipleLanguageModel
          {
                    [Key]
                    public int Id { get; set; }
                    public string? PreferredLanguage { get; set; } = null; // 'en', 'hi', 'ur'
                    public string? SessionId { get; set; } = null; // For guest users without login
          }
}