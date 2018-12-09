using Sample.Client.SrvLocal;
using System;
using System.ServiceModel.Security;

namespace Sample.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            using (Service1Client client = new Service1Client())
            {
                client.ClientCredentials.ServiceCertificate.Authentication.CertificateValidationMode = X509CertificateValidationMode.None;
                client.ClientCredentials.UserName.UserName = "throw";
                client.ClientCredentials.UserName.Password = "throw2";

                // See CustomValidator class in Sample.AppServer project

                // This will throw exception
                // Set username and password to different values

                try
                {
                    var call1 = client.GetData(1);
                    Console.WriteLine(call1);

                    var call2 = client.GetDataUsingDataContract(new CompositeType
                    {
                        BoolValue = true,
                        StringValue = "example"
                    });

                    Console.WriteLine($"{call2.BoolValue} | {call2.StringValue}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.WriteLine(ex.InnerException?.Message);
                }
            }

            Console.ReadKey();
        }
    }
}
