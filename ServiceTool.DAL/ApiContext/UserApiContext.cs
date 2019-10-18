using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Http;
using ServiceTool.DAL.ContextInterfaces;
using ServiceTool.DAL.Interface;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using ServiceTool.DAL.Helper;
using System.Threading.Tasks;
using ServiceTool.DAL.Model.Json;

namespace ServiceTool.DAL.ApiContext
{
    public class UserApiContext : IUserContext, IAdminUserContext
    {
        private readonly HttpClient _httpClient;
        //private readonly string _remoteServiceBaseUrl; TODO: make use of this (set it in startup)

        private readonly string Apiurl = "http://127.0.0.1/magento/index.php/rest/V1";

        public UserApiContext()
        {}

        public UserApiContext(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<CompanyUserStruct> ApiGetCompanyuserAsync()
        {
            var response = await _httpClient.GetAsync(Apiurl + "/customers/me");
            var cms =  JsonConvert.DeserializeObject<Customer>(await response.Content.ReadAsStringAsync());
            return new CompanyUserStruct(
                cms.firstname,
                cms.lastname,
                cms.email,
                true
                );
        }

        public async Task<string> ApiGetCompanyUserToken(string Mail, string Password, int? Pin)
        {
            var test = new Dictionary<string, string>
             {
                { "username", Mail },
                { "password", Password },
                { "pin", Pin.ToString() }
            };

            var response = await _httpClient.PostAsync(Apiurl + "/integration/customer/token", JSONHelper.ToJson(test));
            var responseString = await response.Content.ReadAsStringAsync();
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", responseString.Replace('"', ' ').Trim());
            return responseString;
        }

        public Task<string> ApiLoginAdminAsync(string Mail, string Password)
        {
            throw new NotImplementedException();
        }

        public Task<string> ApiLoginAdminAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<CompanyUserStruct> ApiGetCustomerTokenAsync()
        {
            var response = await _httpClient.GetAsync(Apiurl + "/customers/me");
            var cms = JsonConvert.DeserializeObject<Customer>(await response.Content.ReadAsStringAsync());
            return new CompanyUserStruct(
                cms.firstname,
                cms.lastname,
                cms.email,
                true
                );
        }

        public Task<string> ApiGetAdminTokenAsync(string UserName, string Password)
        {
            throw new NotImplementedException();
        }

        public Task<AdminUserStruct> ApiGetAdminAsync()
        {
            throw new NotImplementedException();
        }

        //public Task<CompanyUserStruct> ApiGetCompanyUser()
        //{
        //    throw new NotImplementedException();
        //}
    }
}
