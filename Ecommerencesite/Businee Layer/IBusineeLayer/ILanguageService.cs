using Ecommerencesite.Model;

namespace Ecommerencesite.Businee_Layer.IBusineeLayer
{
          public interface ILanguageService
          {
                    public List<choice_MultipleLanguageModel> AllCurrentLanguageAsync();
                   public void UpdateLanguageAsync(choice_MultipleLanguageModel model);
                    public void CreateLanguage(choice_MultipleLanguageModel createmodel);

                    public choice_MultipleLanguageModel DetailsLanguage(int id);
                    public choice_MultipleLanguageModel DeleteLanguage(int id);
          }

}
