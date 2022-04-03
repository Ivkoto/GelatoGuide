﻿using System;
using System.Net;
using System.Net.Http;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;

namespace GelatoGuide.Tests.IntegrationTests
{
    [TestClass]
    public class HomeControllerTests
    {
        private static WebApplicationFactory<Startup> factory;
        private static HttpClient client;

        [ClassInitialize]
        public static void Initialization(TestContext testContext)
        {
            factory = new WebApplicationFactory<Startup>();

            var clientOptions = new WebApplicationFactoryClientOptions
            {
                BaseAddress = new Uri("https://localhost:44320/")
            };

            client = factory.CreateClient(clientOptions);
            
        }

        [TestMethod]
        public async Task HomeIndex_ShouldReturnSuccessResponse()
        {
            //assert

            //act
            var response = await client.GetAsync("Home/Index");
            
            //arrange
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            Assert.IsTrue(response.IsSuccessStatusCode);
            Assert.AreEqual("text/html; charset=utf-8", response.Content.Headers.ContentType?.ToString());
        }

        [TestMethod]
        public async Task HomePrivacy_ShouldReturnSuccessResponse()
        {
            //assert

            //act
            var response = await client.GetAsync("Home/Privacy");

            //arrange
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            Assert.IsTrue(response.IsSuccessStatusCode);
            Assert.AreEqual("text/html; charset=utf-8", response.Content.Headers.ContentType?.ToString());
        }

        [TestMethod]
        public async Task HomeAbout_ShouldReturnSuccessResponse()
        {
            //assert

            //act
            var response = await client.GetAsync("Home/About");

            //arrange
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            Assert.IsTrue(response.IsSuccessStatusCode);
            Assert.AreEqual("text/html; charset=utf-8", response.Content.Headers.ContentType?.ToString());
        }

        [ClassCleanup]
        public static void Cleanup()
        {
            factory.Dispose();
        }
    }
}
