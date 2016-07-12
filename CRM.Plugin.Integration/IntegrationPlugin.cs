using Microsoft.Xrm.Sdk;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Plugin
{
    public class IntegrationPlugin : IPlugin
    {
        public void Execute(IServiceProvider serviceProvider)
        {
            // Obtain the execution context from the service provider.
            IPluginExecutionContext context =
                (IPluginExecutionContext)serviceProvider.GetService(typeof(IPluginExecutionContext));

            // Get a reference to the Organization service.
            IOrganizationServiceFactory factory =
                (IOrganizationServiceFactory)serviceProvider.GetService(typeof(IOrganizationServiceFactory));
            IOrganizationService service = factory.CreateOrganizationService(context.UserId);


            ITracingService tracingService = (ITracingService)serviceProvider.GetService(typeof(ITracingService));

            tracingService.Trace("Tracing Service Execute");

            if (context.InputParameters.Contains("Target") &&
                context.InputParameters["Target"] is Entity)
            {

                // Obtain the target entity from the input parameters.
                Entity entity = (Entity)context.InputParameters["Target"];
                //</snippetAccountNumberPlugin2>

                // Verify that the target entity represents an account.
                // If not, this plug-in was not registered correctly.
                if (entity.LogicalName == "incident")
                {
                    Random rand = new Random();

                    if (entity.Attributes.Contains("new_resultlog") == false)
                    {
                        entity.Attributes.Add("new_resultlog", string.Empty);
                    }

                    

                    

                    var callValue = "";
                    OptionSetValue selected = entity.GetAttributeValue<OptionSetValue>("new_verb");

                    SendRequestTask task = new SendRequestTask();
                    
                    switch (selected.Value)
                    {
                        case 100000000:
                            callValue = task.DoPost();
                            break;
                        case 100000001:
                            callValue = task.DoGet();
                            break;
                        case 100000002:
                            callValue = task.DoGetWithParam();
                            break;
                        case 100000003:
                            callValue = task.DoPut();
                            break;
                        case 100000004:
                            callValue = task.DoDelete();
                            break;
                        default:
                            break;
                    }


                    entity.Attributes["new_resultlog"] = callValue;
                        //rand.Next(111111, 999999).ToString();

                    //service.Update(entity);
                    
                }
            }
        }
    }
}


/*
 *                     using (WebClient client = new WebClient())
                    {
                        string json = "{\"employees\":[{\"firstName\":\"John\", \"lastName\":\"Doe\"},{\"firstName\":\"Anna\", \"lastName\":\"Smith\"},{\"firstName\":\"Peter\", \"lastName\":\"Jones\"}]}";
                        string url = "http://dudzapi.apphb.com/api/values/";
                        client.Headers[HttpRequestHeader.ContentType] = "application/json";
                        client.UploadString(url, "POST", json);
                        // Download data.
                        callValue = client.DownloadString("http://dudzapi.apphb.com/api/values/5");

                    }
*/