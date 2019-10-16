using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace ServiceTool.DAL.Helper
{
    public static class JSONHelper
    {
        public static StringContent ToJson(Dictionary<string, string> Dictonary)
        {
            string json = JsonConvert.SerializeObject(Dictonary, Formatting.Indented);
            return new StringContent(json.ToString(), Encoding.UTF8, "application/json");
        }
    }
}
