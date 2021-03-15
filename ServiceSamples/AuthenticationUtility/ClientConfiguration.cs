using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthenticationUtility
{
    public partial class ClientConfiguration
    {
        public static ClientConfiguration Default { get { return ClientConfiguration.OneBox; } }

        public static ClientConfiguration OneBox = new ClientConfiguration()
        {
            // You only need to populate this section if you are logging on via a native app. For Service to Service scenarios in which you e.g. use a service principal you don't need that.
            UriString = "https://litdev01638b941a282a7c8fdevaos.cloudax.dynamics.com/",
            UserName = "AxInt",
            // Insert the correct password here for the actual test.
            //Password = "",


            // You need this only if you logon via service principal using a client secret. See: https://docs.microsoft.com/en-us/dynamics365/unified-operations/dev-itpro/data-entities/services-home-page to get more data on how to populate those fields.
            // You can find that under AAD in the azure portal
            ActiveDirectoryResource = "https://litdev01638b941a282a7c8fdevaos.cloudax.dynamics.com", // Don't have a trailing "/". Note: Some of the sample code handles that issue.
            //Address of Authority to issue token
            ActiveDirectoryTenant="https://login.microsoftonline.com/bc96e740-06af-4e71-844e-5dd7b4a26d4b",// microsoftonline login + Tenant Id
            ActiveDirectoryClientAppId = "1c57f19e-a85e-49ba-a2bf-6c270cd6dab0",
            // Insert here the application secret when authenticate with AAD by the application
            ActiveDirectoryClientAppSecret = "~k86IyMDxB1VLy3D_TgG8fB1y-EDh8.f_G",

            // Change TLS version of HTTP request from the client here
            // Ex: TLSVersion = "1.2"
            // Leave it empty if want to use the default version
            //TLSVersion = "",
        };

        public string TLSVersion { get; set; }
        public string UriString { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string ActiveDirectoryResource { get; set; }
        public String ActiveDirectoryTenant { get; set; }
        public String ActiveDirectoryClientAppId { get; set; }
        public string ActiveDirectoryClientAppSecret { get; set; }
    }
}
