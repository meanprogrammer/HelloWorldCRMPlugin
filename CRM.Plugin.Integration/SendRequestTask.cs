using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace CRM.Plugin
{
    public class SendRequestTask
    {
        string baseUrl = "http://crmapi.apphb.com/";

        public string DoGet() 
        {
            var result = string.Empty;
            using (WebClient client = new WebClient())
            {
                client.Headers["Content-Type"] = "application/x-www-form-urlencoded; charset=UTF-8";
                result = client.DownloadString(string.Format("{0}api/crm/get", baseUrl));
            }
            return result;
        }

        public string DoGetWithParam() 
        {
            var result = string.Empty;
            using (WebClient client = new WebClient())
            {
                client.Headers["Content-Type"] = "application/x-www-form-urlencoded; charset=UTF-8";
                result = client.DownloadString(string.Format("{0}api/crm/get/5", baseUrl));
            }
            return result;
        }

        public string DoPost()
        {
            var result = string.Empty;
            using (WebClient client = new WebClient())
            {
                var json = "{\"RecordID\":123,\"Description\":\"This is a class converted to JSON\"}\"";
                client.Headers["Content-Type"] = "application/x-www-form-urlencoded; charset=UTF-8";
                result = client.UploadString(string.Format("{0}api/crm/post", baseUrl), json);
            }
            return result;
        }

        public string DoPut()
        {
            var result = string.Empty;
            using (WebClient client = new WebClient())
            {
                client.Headers["Content-Type"] = "application/x-www-form-urlencoded; charset=UTF-8";
                result = client.UploadString(string.Format("{0}api/crm/put", baseUrl), "PUT", "=aaaa");
            }
            return result;
        }

        public string DoDelete()
        {
            var result = string.Empty;
            using (WebClient client = new WebClient())
            {
                client.Headers["Content-Type"] = "application/x-www-form-urlencoded; charset=UTF-8";
                result = client.UploadString(string.Format("{0}api/crm/delete", baseUrl), "DELETE", "=12");
            }
            return result;
        }
    }
}
