using Ecommerencesite.Businee_Layer.IBusineeLayer;
using Ecommerencesite.Database;
using Microsoft.EntityFrameworkCore;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Text.RegularExpressions;


namespace Ecommerencesite.Businee_Layer.BusinessLayer
{
          public class AIService : IAIService
          {
                    private readonly HttpClient _httpClient;
                    private readonly IConfiguration _configuration;
                    private readonly Ecommerecewebstedatabase _dbContext;

                    public AIService(
                        HttpClient httpClient,
                        IConfiguration configuration,
                        Ecommerecewebstedatabase dbContext)
                    {
                              _httpClient = httpClient;
                              _configuration = configuration;
                              _dbContext = dbContext;
                    }

                    public async Task<string> GenerateAnswerAsync(string question, string orderNumber )
                    {
                              question = question.ToLower();

                              //=========================
                              // Order Status
                              //=========================

                              //if (question.Contains("order"))
                              //{
                              //          if (string.IsNullOrWhiteSpace(orderNumber))
                              //          {
                              //                    return "Please provide your Order Number.";
                              //          }

                              //          var order = await _dbContext.orderss
                              //              .FirstOrDefaultAsync(x => x.OrderNumber == orderNumber);

                              //          if (order == null)
                              //          {
                              //                    return $"Order Number '{orderNumber}' not found.";
                              //          }

                              //          return $"Order Number : {order.OrderNumber}\n" +
                              //                 $"Status : {order.OrderStatus}\n" +
                              //                 $"Order Total : ₹{order.Ordertotal}\n" +
                              //                 $"Order Date : {order.CreatedAt:dd-MM-yyyy}";
                              //}
                              if (question.ToLower().Contains("order"))
                              {
                                        // Extract order number from the question
                                        Match match = Regex.Match(question, @"\d+");

                                        if (!match.Success)
                                        {
                                                  return "Please provide your Order Number.";
                                        }

                                        string OrderNumber = match.Value.Trim();

                                        var order = await _dbContext.orderss
                                            .FirstOrDefaultAsync(x => x.OrderNumber == orderNumber);

                                        if (order == null)
                                        {
                                                  return $"Order Number '{orderNumber}' not found.";
                                        }

                                        return $"Order Number : {order.OrderNumber}\n" +
                                               $"Order Status : {order.OrderStatus}\n" +
                                               $"Order Total : ₹{order.Ordertotal}\n" +
                                               $"Order Date : {order.CreatedAt:dd-MM-yyyy}";
                              }
                              //=========================
                              // Medicine Search
                              //=========================

                              var medicine = await _dbContext.medicinesss
                                  .FirstOrDefaultAsync(x =>
                                      question.Contains(x.Name.ToLower()));

                              if (medicine != null)
                              {
                                        return $"Medicine Name : {medicine.Name}\n" +
                                               $"Manufacturer : {medicine.Manufacturer}\n" +
                                               $"Price : ₹{medicine.UnitPrice}\n" +
                                               $"Available Stock : {medicine.Quantity}\n" +
                                               $"Expiry Date : {medicine.ExpiryDate}\n" +
                                               $"Medicine Type : {medicine.MedicinesType}";
                              }

                              // AI fallback
                              return await AskOpenAI(question);
                    }
                    private async Task<string> AskOpenAI(string question)
                    {
                              try
                              {
                                        var apiKey = _configuration["OpenAI:ApiKey"];
                                        var model = _configuration["OpenAI:Model"];

                                        if (string.IsNullOrEmpty(apiKey))
                                        {
                                                  return "OpenAI API Key is missing.";
                                        }

                                        _httpClient.DefaultRequestHeaders.Clear();

                                        _httpClient.DefaultRequestHeaders.Authorization =
                                            new AuthenticationHeaderValue("Bearer", apiKey);

                                        var request = new
                                        {
                                                  model = model,
                                                  messages = new object[]
                                            {
                        new
                        {
                            role = "system",
                            content = "You are an AI assistant for an online medicine store. Answer customer questions politely. If the question is about medicines, provide general information and remind users to consult a qualified healthcare professional before taking any medicine."
                        },
                        new
                        {
                            role = "user",
                            content = question
                        }
                                            },
                                                  temperature = 0.3,
                                                  max_tokens = 300
                                        };

                                        var json = JsonSerializer.Serialize(request);

                                        var response = await _httpClient.PostAsync(
                                            "https://api.openai.com/v1/chat/completions",
                                            new StringContent(json, Encoding.UTF8, "application/json"));

                                        var result = await response.Content.ReadAsStringAsync();

                                        if (!response.IsSuccessStatusCode)
                                        {
                                                  return $"OpenAI Error : {result}";
                                        }

                                        using JsonDocument document = JsonDocument.Parse(result);

                                        return document.RootElement
                                            .GetProperty("choices")[0]
                                            .GetProperty("message")
                                            .GetProperty("content")
                                            .GetString() ?? "No response from AI.";
                              }
                              catch (Exception ex)
                              {
                                        return ex.Message;
                              }
                    }
          }
}