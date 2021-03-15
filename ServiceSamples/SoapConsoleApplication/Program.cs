using AuthenticationUtility;
using SoapConsoleApplication.CnaAbrmIntigrationServiceReference;
using SoapUtility.UserSessionServiceReference;
using System;
using System.ServiceModel;
using System.ServiceModel.Channels;

namespace SoapConsoleApplication
{
    class Program
    {
        public const string UserSessionServiceName = "cnaABRMIntegrationServiceGroup";

        [STAThread]
        static void Main(string[] args)
        {
            serviceTest();
            Console.Read();
        }

       

        public static void serviceTest()
        {

            ABRMClient client = new ABRMClient();

            // Use the 'client' variable to call operations on the service.


            Console.WriteLine(client.State);
            // Always close the client.
            client.Close();
        }

        public static void GetToken()
        {
            var aosUriString = ClientConfiguration.Default.UriString;

            var oauthHeader = OAuthHelper.GetAuthenticationHeader(true);
            var serviceUriString = SoapUtility.SoapHelper.GetSoapServiceUriString(UserSessionServiceName, aosUriString);

            var endpointAddress = new System.ServiceModel.EndpointAddress(serviceUriString);
            var binding = SoapUtility.SoapHelper.GetBinding();

            var client = new UserSessionServiceClient(binding, endpointAddress);
            var channel = client.InnerChannel;

            UserSessionInfo sessionInfo = null;

            using (OperationContextScope operationContextScope = new OperationContextScope(channel))
            {
                HttpRequestMessageProperty requestMessage = new HttpRequestMessageProperty();
                requestMessage.Headers[OAuthHelper.OAuthHeader] = oauthHeader;
                OperationContext.Current.OutgoingMessageProperties[HttpRequestMessageProperty.Name] = requestMessage;
                sessionInfo = ((UserSessionService)channel).GetUserSessionInfo(new GetUserSessionInfo()).result;
            }

            Console.WriteLine();
            Console.WriteLine("User ID: {0}", sessionInfo.UserId);
            Console.WriteLine("Is Admin: {0}", sessionInfo.IsSysAdmin);
            Console.ReadLine();
        }
    }
}

