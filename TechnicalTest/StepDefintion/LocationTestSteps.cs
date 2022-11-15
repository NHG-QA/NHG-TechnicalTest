using NUnit.Framework;
using System;
using TechTalk.SpecFlow;
using RestSharp;
using RestSharp.Authenticators;
using NUnit.Framework;
using System.Net;

namespace TechnicalTest
{
    [Binding]
    public class LocationTestSteps
    {
        private readonly LocationClient _locationClient;
        public LocationTestSteps(LocationClient locationClient)
        {
            _locationClient = locationClient;
        }

        [Given(@"I make a request to get location information (.*),(.*)")]
        public void GivenIMakeARequestToGetLocationInformation(string countryCode, string postCode)
        {
            //Call API client
            RestClient client = new RestClient("http://api.zippopotam.us");
            // Endpoint URL
            RestRequest request = new RestRequest("http://api.zippopotam.us/"+countryCode +"/"+postCode, Method.Get);
            // Execute request and store response
            response = client.Execute(request);

        }
        
        [Then(@"I verify the request status (.*)")]
        public void ThenTheRequestShouldBeSuccessful(string isSuccessful)
        {
            //Assert as per isSuccessful value
            if(isSuccessful == "true")
            {
                Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            }
            else
            {
                Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.NotFound));
            }

        }
    }
}
