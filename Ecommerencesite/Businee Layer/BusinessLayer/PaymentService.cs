//using Ecommerencesite.Businee_Layer.IBusineeLayer;
//using Ecommerencesite.Database;
//using Ecommerencesite.Model;
//using Razorpay.Api;

//namespace Ecommerencesite.Businee_Layer.BusinessLayer
//{
//          public class PaymentService : IPaymentService
//          {
//                    public readonly Ecommerecewebstedatabase _dbcontext;
//                    private readonly IConfiguration _configuration;

//                    public PaymentService(Ecommerecewebstedatabase dbcontext, IConfiguration configuration)
//                    {
//                              this._dbcontext = dbcontext;
//                              this._configuration = configuration;
//                    }

//                    public Task<UpiPaymentVPAResponse> CreateUpiPaymentAsync(UpiPaymentVPARequest request)
//                    {
//                              throw new NotImplementedException();
//                    }

//                    public async Task<bool> ValidateVpaAsync(string vpa)
//                    {
//                              try
//                              {
//                                        // appsettings.json se keys fetch karein
//                                        string keyId = _configuration["Razorpay:KeyId"];
//                                        string keySecret = _configuration["Razorpay:KeySecret"];

//                                        RazorpayClient client = new RazorpayClient(keyId, keySecret);
//                                        var vpaData = client.Payment.ValidateVpa(vpa);
//                                        return Convert.ToBoolean(vpaData["valid"]);
//                              }
//                              catch (Exception ex)
//                              {
//                                        // Error debugging ke liye console mein print kar sakte hain
//                                        Console.WriteLine("Razorpay Error: " + ex.Message);
//                                        return false;
//                              }
//                    }
//          }
//}




using System;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using Ecommerencesite.Businee_Layer.IBusineeLayer;
using Ecommerencesite.Database;
using Ecommerencesite.Model;

namespace Ecommerencesite.Businee_Layer.BusinessLayer
{
          public class PaymentService : IPaymentService
          {
                    public readonly Ecommerecewebstedatabase _dbcontext;
                    private readonly IConfiguration _configuration;
                    private readonly IHttpClientFactory _httpClientFactory;

                    public PaymentService(Ecommerecewebstedatabase dbcontext, IConfiguration configuration, IHttpClientFactory httpClientFactory)
                    {
                              _dbcontext = dbcontext;
                              _configuration = configuration;
                              _httpClientFactory = httpClientFactory;
                    }

                    // 1. Create UPI Payment Link using Direct Razorpay REST API
                    public async Task<UpiPaymentVPAResponse> CreateUpiPaymentAsync(UpiPaymentVPARequest request)
                    {
                              try
                              {
                                        bool isValid = await ValidateVpaAsync(request.Vpa);
                                        if (!isValid)
                                        {
                                                  return new UpiPaymentVPAResponse
                                                  {
                                                            IsValidVpa = false,
                                                            Message = "Invalid UPI ID / VPA. Kripya sahi UPI ID dalein."
                                                  };
                                        }

                                        string keyId = _configuration["Razorpay:KeyId"];
                                        string keySecret = _configuration["Razorpay:KeySecret"];

                                        var client = _httpClientFactory.CreateClient();

                                        // Basic Auth Header (Razorpay uses KeyId as Username and KeySecret as Password)
                                        var byteArray = Encoding.ASCII.GetBytes($"{keyId}:{keySecret}");
                                        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArray));

                                        // Payment Link Payload
                                        var payload = new Dictionary<object, object>
                {
                    { "amount", Convert.ToInt32(request.Amount * 100) },
                    { "currency", "INR" },
                    { "description", "Payment for Order via UPI" },
                    { "customer", new Dictionary<string, string>
                        {
                            { "name", request.CustomerName ?? "Customer" },
                            { "contact", request.CustomerContact ?? "9999999999" }
                        }
                    }
                };

                                        var jsonContent = new StringContent(JsonSerializer.Serialize(payload), Encoding.UTF8, "application/json");

                                        // Razorpay Payment Links Endpoint
                                        var response = await client.PostAsync("https://api.razorpay.com/v1/payment_links", jsonContent);
                                        var responseString = await response.Content.ReadAsStringAsync();

                                        if (!response.IsSuccessStatusCode)
                                        {
                                                  return new UpiPaymentVPAResponse
                                                  {
                                                            IsValidVpa = false,
                                                            Message = "Razorpay API Error: " + responseString
                                                  };
                                        }

                                        using var jsonDoc = JsonDocument.Parse(responseString);
                                        string shortUrl = jsonDoc.RootElement.GetProperty("short_url").GetString();
                                        string orderId = jsonDoc.RootElement.GetProperty("id").GetString();

                                        return new UpiPaymentVPAResponse
                                        {
                                                  IsValidVpa = true,
                                                  OrderId = orderId,
                                                  PaymentUrl = shortUrl,
                                                  Message = "Payment Link successfully generated."
                                        };
                              }
                              catch (Exception ex)
                              {
                                        return new UpiPaymentVPAResponse
                                        {
                                                  IsValidVpa = false,
                                                  Message = "Error: " + ex.Message
                                        };
                              }
                    }

                    // 2. Validate VPA using Direct HTTP Request (Optional: Skip if strict verification not required on backend)
                    public async Task<bool> ValidateVpaAsync(string vpa)
                    {
                              try
                              {
                                        // Basic syntax check: must contain '@' and have characters before/after
                                        if (string.IsNullOrWhiteSpace(vpa) || !vpa.Contains("@"))
                                        {
                                                  return false;
                                        }

                                        // Agar aap Razorpay ki official VPA validation API hit nahi karna chahte, 
                                        // toh yahan true return karke front-end format check par bharosa kar sakte hain.
                                        return true;
                              }
                              catch
                              {
                                        return false;
                              }
                    }
          }
}