using Ecommerencesite.Model.HAPPYCLIENT;

namespace Ecommerencesite.Businee_Layer.IBusineeLayer
{
          public interface IHappyClientRepository
          {
                   public List<HappyClient> AllClientsAsync();
               public  HappyClient DetailsHappyClient(int id);
                    public void AddClientAsync(HappyClient client);
                   public  void  UpdateClientAsync( HappyClient client);//
                   public  HappyClient DeleteClientAsync(int id);
          }
}
