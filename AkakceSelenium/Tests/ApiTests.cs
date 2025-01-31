using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;
using Xunit;
using FluentAssertions;


namespace AkakceSelenium.Tests
{
    public class ApiTests
    {
        private readonly RestClient _client;
        private const string BASE_URL = "https://jsonplaceholder.typicode.com/posts";

        public ApiTests()
        {
            _client = new RestClient(BASE_URL);
        }

        [Fact]
        public async Task StatusCode_Should_Be_200()
        {
            var request = new RestRequest("", Method.Get);
            var response = await _client.ExecuteAsync(request);

            response.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);
        }

        [Fact]
        public async Task JsonResponse_Should_Have_Required_Fields()
        {
            var request = new RestRequest("", Method.Get);
            var response = await _client.ExecuteAsync<List<Post>>(request);

            response.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);
            response.Data.Should().NotBeNullOrEmpty();
            response.Data[0].Should().NotBeNull();
            response.Data[0].UserId.Should().BeGreaterThan(0);
            response.Data[0].Id.Should().BeGreaterThan(0);
            response.Data[0].Title.Should().NotBeNullOrEmpty();
            response.Data[0].Body.Should().NotBeNullOrEmpty();
        }

        [Fact]
        public async Task Post_With_Id_1_Should_Have_Title()
        {
            var request = new RestRequest("/1", Method.Get);
            var response = await _client.ExecuteAsync<Post>(request);

            response.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);
            response.Data.Should().NotBeNull();
            response.Data.Id.Should().Be(1);
            response.Data.Title.Should().NotBeNullOrEmpty();
        }

        [Fact]
        public async Task Response_Should_Have_At_Least_10_Posts()
        {
            var request = new RestRequest("", Method.Get);
            var response = await _client.ExecuteAsync<List<Post>>(request);

            response.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);
            response.Data.Count.Should().BeGreaterThanOrEqualTo(10);
        }

        [Fact]
        public async Task All_UserIds_Should_Be_Positive()
        {
            var request = new RestRequest("", Method.Get);
            var response = await _client.ExecuteAsync<List<Post>>(request);

            response.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);
            response.Data.Should().OnlyContain(p => p.UserId > 0);
        }

    }
    public class Post
    {
        public int UserId { get; set; }
        public int Id { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
    }

}
