using System.ComponentModel.DataAnnotations;

namespace Ecommerencesite.Model
{
          public class IssueCategorymasterModel
          {
                    [Key]
                    public int issuecategorymasterid { get; set; }
                    public string IssueCategory
                    {
                              get; set;
                    }
          }
}
