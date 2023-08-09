﻿using API.APIUtils;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
using RestSharp;
using System;
using System.Linq;
using System.Net;
using Core.enums;
using Core.Utils;

namespace API.Tests
{
    [TestFixture]
    public class Tests : BaseTest
    {
        [Test]
        public void GetArticlePdfRequest()
        {
            string url = "https://en.wikipedia.org/api/rest_v1/page/pdf/Mikhail_Lomonosov";
            string expectedContentType = ExpectedData.ContentType;

            logger.LogInfo(LogLevel.Info, $"Create GET request taking the endpoint {url}");
            RestRequest request = api.CreateGetRequest(url, ("accept", "application/pdf"));
            logger.LogInfo(LogLevel.Info, "Send the request and get the response");
            RestResponse response = api.GetResponse(request);
            string actualContentType = response.ContentType;

            logger.LogInfo(LogLevel.Info, "Check if the response content is compare to expected");
            Assert.That(actualContentType, Is.EqualTo(expectedContentType));
        }
    }
}
