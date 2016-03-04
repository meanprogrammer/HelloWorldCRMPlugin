using Microsoft.Xrm.Sdk;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Plugin.HelloWorld
{
    public class HelloWorld : IPlugin
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
                    // An accountnumber attribute should not already exist because
                    // it is system generated.

                    if (entity.Attributes.Contains("new_log") == false)
                    {
                        entity.Attributes.Add("new_log", string.Empty);
                    }



                    /*
                    string verb = string.Empty;

                    if (entity.FormattedValues["new_verb"].Equals("GET W/ PARAM"))
                    {
                        verb = "GET";
                    }
                    else
                    { 
                        verb = entity.Attributes["new_verb"].ToString();
                    }
                    */
                    var callValue = "";
                    OptionSetValue selected = entity.GetAttributeValue<OptionSetValue>("new_verb");

                    
                   
                    
                    entity.Attributes["new_log"] = callValue;

                    
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