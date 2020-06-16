using MELI.WebApi.Models;
using RestSharp;
using System;
using System.Net;
using System.Text.Json;
using Xunit;

namespace MELI.WebApi.Test
{
    public class WebApiTests
    {
        private static int port = 44353;
        //private int port = 5001;
        private RestClient restSharp = new RestClient($"https://localhost:{port}/");

        private static RestRequest MakeRequest(string controller, Method method)
        {
            var request = new RestRequest(controller, method);
            //request.AddHeader("Content-type", "application/json; charset=utf-8");
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
