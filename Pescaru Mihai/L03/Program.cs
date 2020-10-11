using System;

namespace L03
{
    class Program
    {
        static void Main(string[] args)
        {
            init();
            Console.WriteLine("Hello World!");
        }

        static void init(){
            string[] scopes = new string[]{
                DriveService.Scope.Drive,
                DriveService.Scope.DriveFile
            };

            var clientId = "435716270694-9ns3l5d0oterjt00js0hdnpas8g6hhce.apps.googleusercontent.com";
            var clientSecret = "1Dc_22hM_Te62-noGDKfk2b6";

              var credential = GoogleWebAuthorizationBroker.AuthorizeASync(
                  new ClientSecrets
                  {
                    ClientId = clientId,
                    ClientSecret = clientSecret 
                  },
                  scopes,
                  Environment.UserName,
                  CancellationToken.None,
                  null
              ).Result;

              _service = new DriveService(new Google.Apis.Services.BaseClientService.Initializer(){
                HttpClientInitializer = credential
              });

              _token = credential.Token.AccessToken;
			  
			  Console.Write("Token: "+credential.Token.AccessToken);
        }
    }
}
