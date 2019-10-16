using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceTool.DAL.Model.Json
{
    public class Region
    {
        public string region_code { get; set; }
        public string region { get; set; }
        public int region_id { get; set; }
    }

    public class Address
    {
        public int id { get; set; }
        public int customer_id { get; set; }
        public Region region { get; set; }
        public int region_id { get; set; }
        public string country_id { get; set; }
        public List<string> street { get; set; }
        public string telephone { get; set; }
        public string postcode { get; set; }
        public string city { get; set; }
        public string firstname { get; set; }
        public string lastname { get; set; }
        public bool default_shipping { get; set; }
        public bool default_billing { get; set; }
    }

    public class ExtensionAttributes
    {
        public bool is_subscribed { get; set; }
    }

    public class Customer
    {
        public int id { get; set; }
        public int group_id { get; set; }
        public string default_billing { get; set; }
        public string default_shipping { get; set; }
        public string created_at { get; set; }
        public string updated_at { get; set; }
        public string created_in { get; set; }
        public string dob { get; set; }
        public string email { get; set; }
        public string firstname { get; set; }
        public string lastname { get; set; }
        public int gender { get; set; }
        public int store_id { get; set; }
        public int website_id { get; set; }
        public List<Address> addresses { get; set; }
        public int disable_auto_group_change { get; set; }
        public ExtensionAttributes extension_attributes { get; set; }
    }
}
