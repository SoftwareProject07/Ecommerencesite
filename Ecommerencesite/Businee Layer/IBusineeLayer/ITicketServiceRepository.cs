using Ecommerencesite.Model;
using Ecommerencesite.MODELDTO;
using HelpDeskAPI.Models;

namespace Ecommerencesite.Businee_Layer.IBusineeLayer
{
          public interface ITicketServiceRepository
          {
                    Task<string> RaiseTicket(CustomerTicketRaiseModel model);

                    Task<List<CustomerTicketRaiseModel>> GetAllTickets();

                    Task<CustomerTicketRaiseModel> GetTicketById(int id);

                    Task<List<CustomerTicketRaiseModel>> GetTicketByCustomer(string customerId);

                    Task<List<CustomerTicketRaiseModel>> GetTicketByStatus(string status);

                    Task<List<CustomerTicketRaiseModel>> GetTicketByIssueType(string issueType);

              
                    void Updateticket(int id ,CustomerTicketRaiseModel model);//                    //// ASSIGN TASK TEAM 

                    Task<string> DeleteTicket(int id);

                    Task<string> CloseTicket(int ticketId, string remark);


                    //MasterAddIssuecategory
                    public void  MasterAddIssuecategory(IssueCategorymasterModel issuecategory);  
                    public void  MasterUPDATEIssuecategory(IssueCategorymasterModel UPdatecategory);
                    public IssueCategorymasterModel MasterGetIssuecategoryById(int id);
                    public IssueCategorymasterModel MasterDeleteissuecategory(int id);
                    public List<IssueCategorymasterModel> MasterGetAllIssuecategory();






                    //Assign ticket master 
                    public  void MasterAddAssignticket(AssignRaiseTicketModel assignticket);
                    public void MasterUpdateAssignticket(AssignRaiseTicketModel customerTicketRaiseModel);
                    public AssignRaiseTicketModel MasterGetAssignticketById(int assgingetid);
                    public AssignRaiseTicketModel MasterDeleteAssignticket(int deleteassignid);
                    public List<AssignRaiseTicketModel> MasterAllAssignticket();         

                    //    Task<bool> SendAssignmentUpdateAsync(string mobileNumber, string ticketId, string AssignedTo);
          }
}
