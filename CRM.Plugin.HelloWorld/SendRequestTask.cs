﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Plugin.HelloWorld
{
    public class SendRequestTask
    {
        string baseUrl = "http://dudzapi.apphb.com/";

        public string DoGet() 
        {
            var result = string.Empty;
            using (WebClient client = new WebClient())
            {
                client.Headers["Content-Type"] = "application/x-www-form-urlencoded; charset=UTF-8";
                result = client.DownloadString(string.Format("{0}api/values/get", baseUrl));
            }
            return result;
        }

        public string DoGetWithParam() 
        {
            var result = string.Empty;
            using (WebClient client = new WebClient())
            {
                client.Headers["Content-Type"] = "application/x-www-form-urlencoded; charset=UTF-8";
                result = client.DownloadString(string.Format("{0}/api/values/get/5", baseUrl));
            }
            return result;
        }

        public string DoPost()
        {
            var result = string.Empty;
            using (WebClient client = new WebClient())
            {
                client.Headers["Content-Type"] = "application/x-www-form-urlencoded; charset=UTF-8";
                result = client.UploadString(string.Format("{0}api/values/post", baseUrl), "=test test test");
            }
            return result;
        }

        public string DoPut()
        {
            var result = string.Empty;
            using (WebClient client = new WebClient())
            {
                client.Headers["Content-Type"] = "application/x-www-form-urlencoded; charset=UTF-8";
                result = client.UploadString(string.Format("{0}api/values/put", baseUrl), "PUT", "=aaaa");
            }
            return result;
        }

        public string DoDelete()
        {
            var result = string.Empty;
            using (WebClient client = new WebClient())
            {
                client.Headers["Content-Type"] = "application/x-www-form-urlencoded; charset=UTF-8";
                result = client.UploadString(string.Format("{0}api/values/delete", baseUrl), "DELETE", "=12");
            }
            return result;
        }
    }
}