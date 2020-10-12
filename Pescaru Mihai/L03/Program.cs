using Google.Apis.Auth.OAuth2;
using Google.Apis.Drive.v3;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading;

namespace L03
{
    class Program
    {
        private static DriveService _service;
        private static string _token;

        static void Main(string[] args)
        {
            init();
            readAllData();
        }

        static void init()
        {
            string[] scopes = new string[]{
                DriveService.Scope.Drive,
                DriveService.Scope.DriveFile
            };

            var clientId = "435716270694-9ns3l5d0oterjt00js0hdnpas8g6hhce.apps.googleusercontent.com";
            var clientSecret = "1Dc_22hM_Te62-noGDKfk2b6";

            var credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
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

            _service = new DriveService(new Google.Apis.Services.BaseClientService.Initializer()
            {
                HttpClientInitializer = credential
            });

            _token = credential.Token.AccessToken;
             
            
        }

        static void readAllData()
        {
            Console.WriteLine("Token: " + _token);

            var request = (HttpWebRequest)WebRequest.Create("https://www.googleapis.com/drive/v3/files");
                 //request.PreAuthenticate = true;
                request.Headers.Add("Authorization", "Bearer " + _token);
                request.Accept = "application/json";

            var response = (HttpWebResponse)request.GetResponse();

            var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();


            Console.WriteLine(responseString);
        }

        static async void readDataOfFile(string fileId)
        {
            HttpClient client = new HttpClient();
            var responseString = await client.GetStringAsync("https://www.googleapis.com/drive/v3/files/"+fileId);

            Console.WriteLine(responseString);
        }

/*        static async void writeInFile(string fileName, string message)
        {

                         HttpClient client = new HttpClient();
              var values = new Dictionary<string, string>
            {
                { "fileId",fileId }
            };

            var content = new FormUrlEncodedContent(values);
            var response = await client.PostAsync("http://www.example.com/recepticle.aspx", content);

            var responseString = await response.Content.ReadAsStringAsync();
        }*/
    }
}
