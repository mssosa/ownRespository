using MELI.WebApi.Models;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text.Json;
using Xunit;

namespace MELI.WebApi.Test
{
    public class WebApiTests
    {
        private static int port = 44353;
        //private int port = 5001;
        //// Localhost TEST
        private RestClient restSharp = new RestClient($"https://localhost:{port}/");
        //// test to api --> on azure
        //private RestClient restSharp = new RestClient($"https://melimssosa.azurewebsites.net/");

        private static RestRequest MakeRequest(string controller, Method method)
        {
            var request = new RestRequest(controller, method);
            request.AddHeader("Content-type", "application/json;");
            return request;
        }

        [Fact]
        public void StatsTests()
        {

            RestRequest request = MakeRequest("stats", Method.GET);
            var response = restSharp.Execute<dynamic>(request);
            Assert.True(response.StatusCode == HttpStatusCode.OK);
        }

        [Fact]
        public void IsMutantTest()
        {
            RestRequest request = MakeRequest("mutant", Method.POST);
            ReceiptDNA objIn = new ReceiptDNA();
            objIn.dna = new string[]
            {
                "ATGCGA",
                "CAGTGC",
                "TTATGT",
                "AGAAGG",
                "CCCCTA",
                "TCACTG"
            };
            var json = JsonSerializer.Serialize<ReceiptDNA>(objIn);
            request.AddJsonBody(json);
            var response = restSharp.Execute<dynamic>(request);
            Assert.True(response.StatusCode == HttpStatusCode.OK);
        }

        [Theory]
        [InlineData(1000)]
        [InlineData(100)]
        [InlineData(10)]
        [InlineData(6)]
        public void BigTestIsMutant(int quantityNxN)
        {
            RestRequest request = MakeRequest("mutant", Method.POST);
            ReceiptDNA objIn = new ReceiptDNA();
            int options = 4;//ATCG
            string chain = "";
            Random r1 = new Random();
            List<string> cad = new List<string>();
            for (int x = 0; x < quantityNxN; x++)
            {
                for (int y = 0; y < quantityNxN; y++)
                {
                    var num = r1.Next(options);
                    switch (num)
                    {
                        case 0:
                            chain += "A"; break;
                        case 1:
                            chain += "C"; break;
                        case 2:
                            chain += "G"; break;
                        case 3:
                            chain += "T"; break;
                        default:
                            chain += "A"; break;
                    }

                }
                cad.Add(chain);
                chain = "";
            }

             objIn.dna = cad.ToArray();

            var json = JsonSerializer.Serialize<ReceiptDNA>(objIn);
            request.AddJsonBody(json);
            var response = restSharp.Execute<dynamic>(request);
            Assert.True(response.StatusCode == HttpStatusCode.OK || response.StatusCode == HttpStatusCode.Forbidden);
        }

        [Fact]
        public void IsntMutantTest()
        {

            RestRequest request = MakeRequest("mutant", Method.POST);
            ReceiptDNA objIn = new ReceiptDNA();
            objIn.dna = new string[]
            {
               "ATGCGA", "CAGTGC", "TTATTT", "AGACGG","GCGTCA","TCACTG"
            };
            var json = JsonSerializer.Serialize<ReceiptDNA>(objIn);
            request.AddJsonBody(json);
            var response = restSharp.Execute<dynamic>(request);
            Assert.True(response.StatusCode == HttpStatusCode.Forbidden);
        }
    }
}
