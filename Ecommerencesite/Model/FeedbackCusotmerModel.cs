using System.ComponentModel.DataAnnotations;

namespace Ecommerencesite.Model
{
          public class FeedbackCusotmerModel
          {
                    [Key]
                    public int Freedbackcustomerid { get; set; }
                    public string? Name { get; set; }= null;
                    public string? Email { get; set; }= null;
                    public string?  starStatus { get; set; }= null; 
                                                                    
                    public string? Message { get; set; }= null;                                       
             

          }
}
