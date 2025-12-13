//using Ecommerencesite.Model;
//using Microsoft.Data.SqlClient;
//using System.Data;

//namespace Ecommerencesite.DAL
//{
//          public class DALMODEL
//          {
//                    //public ResponseModel CREATERegisterUser(UserMedicine userMedicine, SqlConnection connection)
//                    //{
//                    //          ResponseModel response = new ResponseModel();
//                    //          UserMedicine userMed = new UserMedicine();
//                    //          SqlCommand sqlCommand = new SqlCommand("sp_CREATERegisterUser", connection);
//                    //          sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
//                    //          sqlCommand.Parameters.AddWithValue("@FirstName", userMedicine.FirstName);
//                    //          sqlCommand.Parameters.AddWithValue("@MiddleName", userMedicine.MiddleName);
//                    //          sqlCommand.Parameters.AddWithValue("@LastName", userMedicine.LastName);
//                    //          sqlCommand.Parameters.AddWithValue("@Password", userMedicine.Password);
//                    //          sqlCommand.Parameters.AddWithValue("@Email", userMedicine.Email);
//                    //          sqlCommand.Parameters.AddWithValue("@Fund", 0);
//                    //          sqlCommand.Parameters.AddWithValue("@type", "UserMedicine");
//                    //          sqlCommand.Parameters.AddWithValue("@CreateOn", userMedicine.CreateOn);
//                    //          //SqlDataReader reader = sqlCommand.ExecuteReader();
//                    //          //  if (reader.HasRows)
//                    //          //  {
//                    //          //            while (reader.Read())
//                    //          //            {
//                    //          //                      response.statusCode = Convert.ToInt32(reader["statusCode"]);
//                    //          //                        response.responseMessage = reader["responseMessage"].ToString();
//                    //          //            }
//                    //          //  }
//                    //          //    reader.Close();


//                    //          connection.Open();
//                    //          int result = sqlCommand.ExecuteNonQuery();
//                    //          connection.Close();


//                    //          if (result > 0)
//                    //          {
//                    //                    response.statusCode = 200;
//                    //                    response.responseMessage = "User registered successfully.";
//                    //                    response.userMedicine = userMed;
//                    //          }
//                    //          else
//                    //          {
//                    //                    response.statusCode = 100;
//                    //                    response.responseMessage = "User registration failed.";
//                    //                    response.userMedicine = null;
//                    //          }

//                    //          // Database interaction logic to register user goes here
//                    //          return response;
//                    //}


//                    public ResponseModel CREATERegisterUser(UserMedicine userMedicine, SqlConnection connection)
//                    {
//                              ResponseModel response = new ResponseModel();
//                              UserMedicine userMed = new UserMedicine();

//                              try
//                              {
//                                        using (connection)
//                                        {
//                                                  connection.Open();

//                                                  using (SqlCommand sqlCommand = new SqlCommand("sp_CREATERegisterUser", connection))
//                                                  {
//                                                            sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
//                                                            sqlCommand.Parameters.AddWithValue("@FirstName", userMedicine.FirstName);
//                                                            sqlCommand.Parameters.AddWithValue("@MiddleName", userMedicine.MiddleName);
//                                                            sqlCommand.Parameters.AddWithValue("@LastName", userMedicine.LastName);
//                                                            sqlCommand.Parameters.AddWithValue("@Password", userMedicine.Password);
//                                                            sqlCommand.Parameters.AddWithValue("@Email", userMedicine.Email);
//                                                            sqlCommand.Parameters.AddWithValue("@Fund", 0);
//                                                            sqlCommand.Parameters.AddWithValue("@type", "UserMedicine");
//                                                            sqlCommand.Parameters.AddWithValue("@CreateOn", userMedicine.CreateOn);

//                                                            int result = sqlCommand.ExecuteNonQuery();

//                                                            if (result > 0)
//                                                            {
//                                                                      response.statusCode = 200;
//                                                                      response.responseMessage = "User registered successfully.";
//                                                                      response.userMedicine = userMed;
//                                                            }
//                                                            else
//                                                            {
//                                                                      response.statusCode = 100;
//                                                                      response.responseMessage = "User registration failed.";
//                                                                      response.userMedicine = null;
//                                                            }
//                                                  }
//                                        }
//                              }
//                              catch (Exception ex)
//                              {
//                                        response.statusCode = 500;
//                                        response.responseMessage = "An error occurred: " + ex.Message;
//                                        response.userMedicine = null;
//                              }

//                              return response;
//                    }
//                    public ResponseModel LOGINUserMedicine(UserMedicine userMedicine, SqlConnection connection)
//                    {
//                              //ResponseModel response = new ResponseModel();
//                              //// Database interaction logic to login user goes here
//                              //return response;

//                              SqlDataAdapter da = new SqlDataAdapter("sp_LOGINUserMedicine", connection);
//                              da.SelectCommand.CommandType = System.Data.CommandType.StoredProcedure;
//                              da.SelectCommand.Parameters.AddWithValue("@Email", userMedicine.Email);
//                              da.SelectCommand.Parameters.AddWithValue("@Password", userMedicine.Password);
//                              DataTable dt = new DataTable();
//                              da.Fill(dt);
//                              ResponseModel response = new ResponseModel();
//                              UserMedicine userMed = new UserMedicine();
//                              if (dt.Rows.Count > 0)
//                              {
//                                        userMed.id = Convert.ToInt32(dt.Rows[0]["id"]);
//                                        userMed.FirstName = dt.Rows[0]["FirstName"].ToString();
//                                        //userMed.MiddleName = dt.Rows[0]["MiddleName"].ToString();
//                                        userMed.LastName = dt.Rows[0]["LastName"].ToString();
//                                        userMed.Email = dt.Rows[0]["Email"].ToString();
//                                        //userMed.Fund = Convert.ToDecimal(dt.Rows[0]["Fund"]);
//                                        userMed.type = dt.Rows[0]["type"].ToString();
//                                        //userMed.CreateOn = Convert.ToDateTime(dt.Rows[0]["CreateOn"]);
//                                        response.statusCode = 200;
//                                        response.responseMessage = "User Is valid ";
//                                        response.userMedicine = userMed;
//                                        //if (response.statusCode == 200)
//                                        //{
//                                        //          response.userMedicine = new UserMedicine
//                                        //          {
//                                        //                    id = Convert.ToInt32( dt.Rows[0]["id"]),
//                                        //                      FirstName = dt.Rows[0]["FirstName"].ToString(),
//                                        //                        MiddleName = dt.Rows[0]["MiddleName"].ToString(),
//                                        //                          LastName = dt.Rows[0]["LastName"].ToString(),
//                                        //                            Email = dt.Rows[0]["Email"].ToString(),
//                                        //                              Fund = Convert.ToDecimal( dt.Rows[0]["Fund"]),
//                                        //                                type = dt.Rows[0]["type"].ToString(),
//                                        //                                  CreateOn = Convert.ToDateTime( dt.Rows[0]["CreateOn"])
//                                        //          };
//                                        //}
//                              }
//                              else
//                              {
//                                        response.statusCode = 100;
//                                        response.responseMessage = "User Is Invalid.. ";
//                                        response.userMedicine = null;

//                              }
//                              return response;

//                    }

//                    public ResponseModel ViewUser(UserMedicine userMedicine, SqlConnection connection)
//                    {

//                              SqlDataAdapter da = new SqlDataAdapter("sp_ViewUser", connection);
//                              da.SelectCommand.CommandType = System.Data.CommandType.StoredProcedure;
//                              da.SelectCommand.Parameters.AddWithValue("@id", userMedicine.id);
//                              DataTable dt = new DataTable();
//                              da.Fill(dt);
//                              ResponseModel response = new ResponseModel();
//                              UserMedicine userMed = new UserMedicine();
//                              if (dt.Rows.Count > 0)
//                              {
//                                        userMed.id = Convert.ToInt32(dt.Rows[0]["id"]);
//                                        userMed.FirstName = dt.Rows[0]["FirstName"].ToString();
//                                        userMed.MiddleName = dt.Rows[0]["MiddleName"].ToString();
//                                        userMed.LastName = dt.Rows[0]["LastName"].ToString();
//                                        userMed.Email = dt.Rows[0]["Email"].ToString();
//                                        userMed.Fund = Convert.ToDecimal(dt.Rows[0]["Fund"]);
//                                        userMed.type = dt.Rows[0]["type"].ToString();
//                                        userMed.CreateOn = Convert.ToDateTime(dt.Rows[0]["CreateOn"]);
//                                        userMed.Password = Convert.ToString(dt.Rows[0]["Password"]); ; // Do not expose password


//                                        response.statusCode = 200;
//                                        response.responseMessage = "User EXISTS ";
//                                        //if (response.statusCode == 200)
//                                        //{
//                                        //          response.userMedicine = new UserMedicine
//                                        //          {
//                                        //                    id = Convert.ToInt32(dt.Rows[0]["id"]),
//                                        //                      FirstName = dt.Rows[0]["FirstName"].ToString(),
//                                        //                        MiddleName = dt.Rows[0]["MiddleName"].ToString(),
//                                        //                          LastName = dt.Rows[0]["LastName"].ToString(),
//                                        //                            Email = dt.Rows[0]["Email"].ToString(),
//                                        //                              Fund = Convert.ToDecimal(dt.Rows[0]["Fund"]),
//                                        //                                type = dt.Rows[0]["type"].ToString(),
//                                        //                                  CreateOn = Convert.ToDateTime(dt.Rows[0]["CreateOn"])
//                                        //          };
//                                        //}
//                              }
//                              else
//                              {
//                                        response.statusCode = 100;
//                                        response.responseMessage = "User DOES Not EXISTS.. ";
//                                        response.userMedicine = userMed;
//                              }
//                              return response;

//                    }
//                    public ResponseModel UpdateUserMedicine(UserMedicine userMedicine, SqlConnection connection)
//                    {
//                              ResponseModel response = new ResponseModel();
//                              UserMedicine userMed = new UserMedicine();
//                              SqlCommand sqlCommand = new SqlCommand("sp_UpdateUserFund", connection);
//                              sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
//                              sqlCommand.Parameters.AddWithValue("@id", userMedicine.id);
//                              sqlCommand.Parameters.AddWithValue("@FirstName", userMedicine.FirstName);
//                              sqlCommand.Parameters.AddWithValue("@MiddleName", userMedicine.MiddleName);
//                              sqlCommand.Parameters.AddWithValue("@LastName", userMedicine.LastName);

//                              sqlCommand.Parameters.AddWithValue("@Password", userMedicine.Password);
//                              sqlCommand.Parameters.AddWithValue("@Email", userMedicine.Email);
//                              sqlCommand.Parameters.AddWithValue("@type", userMedicine.type);
//                              sqlCommand.Parameters.AddWithValue("@Fund", userMedicine.Fund);
//                              sqlCommand.Parameters.AddWithValue("@CreateOn", userMedicine.CreateOn);
//                              connection.Open();
//                              int result = sqlCommand.ExecuteNonQuery();
//                              connection.Close();
//                              if (result > 0)
//                              {
//                                        response.statusCode = 200;
//                                        response.responseMessage = "User fund updated successfully.";
//                                        response.userMedicine = userMed;
//                              }
//                              else
//                              {
//                                        response.statusCode = 100;
//                                        response.responseMessage = "User fund update failed.";
//                                        response.userMedicine = null;
//                              }
//                              return response;
//                    }
//                    public ResponseModel DELETEUserMedicine(UserMedicine userMedicine, SqlConnection connection)
//                    {
//                              ResponseModel response = new ResponseModel();
//                              UserMedicine userMed = new UserMedicine();
//                              SqlCommand sqlCommand = new SqlCommand("sp_DELETEUserMedicine", connection);
//                              sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
//                              sqlCommand.Parameters.AddWithValue("@id", userMedicine.id);
//                              connection.Open();
//                              int result = sqlCommand.ExecuteNonQuery();
//                              connection.Close();
//                              if (result > 0)
//                              {
//                                        response.statusCode = 200;
//                                        response.responseMessage = "User deleted successfully.";
//                                        response.userMedicine = userMed;
//                              }
//                              else
//                              {
//                                        response.statusCode = 100;
//                                        response.responseMessage = "User deletion failed.";
//                                        response.userMedicine = null;
//                              }
//                              return response;
//                    }
//                    //public ResponseModel RESETPassword(UserMedicine userMedicine, SqlConnection connection)
//                    //{
//                    //          ResponseModel response = new ResponseModel();
//                    //          UserMedicine userMed = new UserMedicine();
//                    //          SqlCommand sqlCommand = new SqlCommand("sp_RESETPassword", connection);
//                    //          sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
//                    //          sqlCommand.Parameters.AddWithValue("@Email", userMedicine.Email);
//                    //          sqlCommand.Parameters.AddWithValue("@Password", userMedicine.Password);
//                    //          connection.Open();
//                    //          int result = sqlCommand.ExecuteNonQuery();
//                    //          connection.Close();
//                    //          if (result > 0)
//                    //          {
//                    //                    response.statusCode = 200;
//                    //                    response.responseMessage = "Password reset successfully.";
//                    //                    response.userMedicine = userMed;
//                    //          }
//                    //          else
//                    //          {
//                    //                    response.statusCode = 100;
//                    //                    response.responseMessage = "Password reset failed.";
//                    //                    response.userMedicine = null;
//                    //          }
//                    //          return response;
//                    //}



//                    //AddToCART method
//                    public ResponseModel AddToCART(Cart carts, SqlConnection sqlConnection)
//                    {
//                              ResponseModel response = new ResponseModel();
//                              Cart cartss = new Cart();
//                              SqlCommand sqlCommand = new SqlCommand("sp_AddToCART", sqlConnection);
//                              sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
//                              sqlCommand.Parameters.AddWithValue("@UserId", carts.UserId);
//                              sqlCommand.Parameters.AddWithValue("@UnitPrice", carts.UnitPrice);
//                              sqlCommand.Parameters.AddWithValue("@Discount", carts.Discount);
//                              sqlCommand.Parameters.AddWithValue("@Quantity", carts.Quantity);
//                              sqlCommand.Parameters.AddWithValue("@Totalprice", carts.Totalprice);
//                              sqlCommand.Parameters.AddWithValue("@MedicineId", carts.MedicineId);


//                              sqlConnection.Open();
//                              int result = sqlCommand.ExecuteNonQuery();
//                              sqlConnection.Close();
//                              if (result > 0)
//                              {
//                                        response.statusCode = 200;
//                                        response.responseMessage = "Carts added to cart successfully.";
//                                        response.cart = cartss;
//                              }
//                              else
//                              {
//                                        response.statusCode = 100;
//                                        response.responseMessage = "Failed to add Carts ";
//                                        response.cart = null;
//                              }
//                              return response;


//                    }
//                    public ResponseModel PlaceOrder(UserMedicine user, SqlConnection sqlConnection)
//                    {
//                              ResponseModel response = new ResponseModel();
//                              //  ordrer orders = new Order();
//                              UserMedicine userMed = new UserMedicine();
//                              SqlCommand sqlCommand = new SqlCommand("sp_PlaceOrder", sqlConnection);
//                              sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
//                              sqlCommand.Parameters.AddWithValue("@Id", user.id);
//                              //sqlCommand.Parameters.AddWithValue("@TotalAmount", user.TotalAmount);
//                              //sqlCommand.Parameters.AddWithValue("@OrderDate", order.OrderDate);


//                              sqlConnection.Open();
//                              int i = sqlCommand.ExecuteNonQuery();
//                              sqlConnection.Close();
//                              if (i > 0)
//                              {
//                                        response.statusCode = 200;
//                                        response.responseMessage = "Order placed successfully.";
//                                        response.userMedicine = userMed;
//                                        //  response.order = orders;
//                              }
//                              else
//                              {
//                                        response.statusCode = 100;
//                                        response.responseMessage = "Failed to place order.";
//                                        response.userMedicine = null;
//                                        //  response.order = null;
//                              }
//                              return response;
//                    }

//                    public ResponseModel OrderList(UserMedicine userMedicine, SqlConnection connection)
//                    {
//                              SqlDataAdapter da = new SqlDataAdapter("sp_OrderList", connection);
//                              da.SelectCommand.CommandType = System.Data.CommandType.StoredProcedure;
//                              da.SelectCommand.Parameters.AddWithValue("@type", userMedicine.type);

//                              da.SelectCommand.Parameters.AddWithValue("@id", userMedicine.id);
//                              DataTable dt = new DataTable();
//                              da.Fill(dt);
//                              ResponseModel response = new ResponseModel();
//                              List<Order> orderList = new List<Order>();
//                              if (dt.Rows.Count > 0)
//                              {

//                                        for (int i = 0; i < dt.Rows.Count; i++)
//                                        {
//                                                  Order order = new Order();
//                                                  order.id = Convert.ToInt32(dt.Rows[i]["Id"]);
//                                                  order.UserId = Convert.ToInt32(dt.Rows[i]["UserId"]);
//                                                  order.OrderNumber = dt.Rows[i]["OrderNumber"].ToString();
//                                                  order.Ordertotal = Convert.ToDecimal(dt.Rows[i]["Ordertotal"]);
//                                                  order.OrderStatus = Convert.ToDateTime(dt.Rows[i]["OrderStatus"]);
//                                                  orderList.Add(order);
//                                        }
//                                        if (orderList.Count > 0)
//                                        {
//                                                  response.statusCode = 200;
//                                                  response.responseMessage = "Order list retrieved successfully.";
//                                                  response.LSTorders = orderList;
//                                        }
//                                        else
//                                        {
//                                                  response.statusCode = 100;
//                                                  response.responseMessage = "No orders found.";
//                                                  response.LSTorders = null;
//                                        }
//                              }
//                              else
//                              {
//                                        response.statusCode = 100;
//                                        response.responseMessage = "No orders found.";
//                                        response.LSTorders = null;
//                              }

//                              return response;
//                    }

//                    public ResponseModel AddUpdateMedicine(Medicine medicine, SqlConnection sqlConnection)
//                    {
//                              ResponseModel response = new ResponseModel();
//                              Medicine med = new Medicine();
//                              SqlCommand sqlCommand = new SqlCommand("sp_AddUpdateMedicine", sqlConnection);
//                              sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
//                              sqlCommand.Parameters.AddWithValue("@id", medicine.id);
//                              sqlCommand.Parameters.AddWithValue("@MedicineName", medicine.Name);
//                              sqlCommand.Parameters.AddWithValue("@Description", medicine.Manufacturer);
//                              sqlCommand.Parameters.AddWithValue("@UnitPrice", medicine.UnitPrice);
//                              sqlCommand.Parameters.AddWithValue("@Discount", medicine.Discount);
//                              sqlCommand.Parameters.AddWithValue("@Quantity", medicine.Quantity);
//                              sqlCommand.Parameters.AddWithValue("@ExpiryDate", medicine.ExpiryDate);
//                              sqlCommand.Parameters.AddWithValue("@IMAGEURL", medicine.IMAGEURL);
//                              sqlCommand.Parameters.AddWithValue("@STATUS", medicine.STATUS);
//                              sqlCommand.Parameters.AddWithValue("@Type", medicine.Type);

//                              sqlConnection.Open();
//                              int result = sqlCommand.ExecuteNonQuery();
//                              sqlConnection.Close();
//                              if (result > 0)
//                              {
//                                        response.statusCode = 200;
//                                        response.responseMessage = "Medicine added/updated successfully.";
//                                        response.medicine = med;
//                              }
//                              else
//                              {
//                                        response.statusCode = 100;
//                                        response.responseMessage = "Failed to add/update medicine.";
//                                        response.medicine = null;
//                              }
//                              return response;
//                    }

//                    public ResponseModel UserList(UserMedicine userMedicine, SqlConnection connection)
//                    {
//                              SqlDataAdapter da = new SqlDataAdapter("sp_UserList", connection);
//                              List<UserMedicine> userList = new List<UserMedicine>();

//                              da.SelectCommand.CommandType = System.Data.CommandType.StoredProcedure;
//                              //da.SelectCommand.Parameters.AddWithValue("@type", userMedicine.type);

//                              //da.SelectCommand.Parameters.AddWithValue("@id", userMedicine.id);
//                              DataTable dt = new DataTable();
//                              da.Fill(dt);
//                              ResponseModel response = new ResponseModel();
//                              if (dt.Rows.Count > 0)
//                              {

//                                        for (int i = 0; i < dt.Rows.Count; i++)
//                                        {
//                                                  UserMedicine usermedic = new UserMedicine();
//                                                  usermedic.id = Convert.ToInt32(dt.Rows[i]["Id"]);
//                                                  usermedic.FirstName = dt.Rows[i]["FirstName"].ToString();
//                                                  usermedic.MiddleName = dt.Rows[i]["MiddleName"].ToString();
//                                                  usermedic.LastName = dt.Rows[i]["LastName"].ToString();
//                                                  usermedic.Password = dt.Rows[i]["Password"].ToString();
//                                                  usermedic.Email = dt.Rows[i]["Email"].ToString();
//                                                  usermedic.Fund = Convert.ToDecimal(dt.Rows[i]["Fund"]);
//                                                  usermedic.type = dt.Rows[i]["type"].ToString();
//                                                  usermedic.CreateOn = Convert.ToDateTime(dt.Rows[i]["CreateOn"]);

//                                                  //usermedic.Email = Convert.ToDecimal(dt.Rows[i]["Ordertotal"]);
//                                                  //usermedic.OrderStatus = Convert.ToDateTime(dt.Rows[i]["OrderStatus"]);
//                                                  userList.Add(usermedic);
//                                        }
//                                        if (userList.Count > 0)
//                                        {
//                                                  response.statusCode = 200;
//                                                  response.responseMessage = "Order list retrieved successfully.";
//                                                  response.LSTuserMedicines = userList;
//                                        }
//                                        else
//                                        {
//                                                  response.statusCode = 100;
//                                                  response.responseMessage = "No orders found.";
//                                                  response.LSTorders = null;
//                                        }
//                              }
//                              else
//                              {
//                                        response.statusCode = 100;
//                                        response.responseMessage = "No orders found.";
//                                        response.LSTorders = null;
//                              }

//                              return response;
//                    }

//          }
//}