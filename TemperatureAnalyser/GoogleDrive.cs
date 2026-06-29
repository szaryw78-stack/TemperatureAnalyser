using Google.Apis.Auth.OAuth2;
using Google.Apis.Drive.v3;
using Google.Apis.Services;
using Google.Apis.Util.Store;
using RWdll;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;

namespace TemperatureAnalyser
{
    public class GoogleDrive
    {
        static string[] Scopes = { DriveService.Scope.Drive };
        static string ApplicationName = "TemperatureAnalyser";//"Drive API .NET Quickstart";
        RWdll.Uniwheels rwdll = new Uniwheels();
        public GoogleDrive()
        {

        }
        public void Connect()
        {
            UserCredential credential;
            Google.Apis.Drive.v3.Data.File copiedFile = new Google.Apis.Drive.v3.Data.File();
            using (var stream =
                new FileStream("credentials.json", FileMode.Open, FileAccess.Read))
            {
                // The file token.json stores the user's access and refresh tokens, and is created
                // automatically when the authorization flow completes for the first time.
                string credPath = "token.json";
                credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
                    GoogleClientSecrets.Load(stream).Secrets,
                    Scopes,
                    "user",
                    CancellationToken.None,
                    new FileDataStore(credPath, true)).Result;
                Console.WriteLine("Credential file saved to: " + credPath);
            }

            // Create Drive API service.
            var service = new DriveService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = ApplicationName,
            });

            // Define parameters of request.
            FilesResource.ListRequest listRequest = service.Files.List();
            //  DirectoryResource.ListRequest 
            listRequest.PageSize = 10;

            //listRequest.Q = $"mimeType = 'application/vnd.google-apps.folder' and name = '{"TemperatureAnalyser"}' ";
            listRequest.Q = $"mimeType != 'application/vnd.google-apps.folder' and name = '{"baza.db"}' ";
            listRequest.Fields = "nextPageToken, files(id, name,mimeType,parents,fileExtension)";

            //listRequest.F = $"mimeType = 'application/vnd.google-apps.file' and name = '{"baza.db"}'";

            // List files.
            IList<Google.Apis.Drive.v3.Data.File> files = listRequest.Execute()
                .Files;

            // IList<Google.Apis.Drive.v3.Data.>
            Console.WriteLine("Files:");




            if (files != null && files.Count > 0)
            {
                foreach (var file in files)
                {
                    string fn = copiedFile.Name;
                    Console.WriteLine("{0} ({1})", file.Name, file.Id);
                    rwdll.SaveLogFile(AppDomain.CurrentDomain.BaseDirectory + @"\log.csv", file.Name + ";" + file.Id + "\n");
                    //FilesResource.CopyRequest cpy = service.Files.Copy()
                    //cpy.Execute();
                    //var getRequest = service.Files.Get(file.Id);
                    //var fs = new FileStream(file.Id, FileMode.Create, FileAccess.Write);
                    //getRequest.DownloadAsync(fs);

                    //       DownloadFile(service, files, AppDomain.CurrentDomain.BaseDirectory + @"\baza_cpy.db");
                    var stream = new System.IO.MemoryStream();
                    UploadFile(stream, AppDomain.CurrentDomain.BaseDirectory + @"\log.csv", "text/plain", "root", "opis");


                }
                //var req = service.Files.List();
                //var response = req.ExecuteAsync();
                //var downloadFile = response.fi
            }
            else
            {
                Console.WriteLine("No files found.");
            }
            Console.Read();

        }
        private static void DownloadFile(Google.Apis.Drive.v3.DriveService service, IList<Google.Apis.Drive.v3.Data.File> file, string saveTo)
        {     //https://medium.com/geekculture/upload-files-to-google-drive-with-c-c32d5c8a7abc


            var request = service.Files.Get(file[0].Id);
            var stream = new System.IO.MemoryStream();

            // Add a handler which will be notified on progress changes.
            // It will notify on each chunk download and when the
            // download is completed or failed.
            request.MediaDownloader.ProgressChanged += (Google.Apis.Download.IDownloadProgress progress) =>
            {
                switch (progress.Status)
                {
                    case Google.Apis.Download.DownloadStatus.Downloading:
                        {
                            Console.WriteLine(progress.BytesDownloaded);
                            break;
                        }
                    case Google.Apis.Download.DownloadStatus.Completed:
                        {
                            Console.WriteLine("Download complete.");
                            SaveStream(stream, saveTo);
                            break;
                        }
                    case Google.Apis.Download.DownloadStatus.Failed:
                        {
                            Console.WriteLine("Download failed.");
                            break;
                        }
                }
            };
            request.Download(stream);

        }
        private static void SaveStream(System.IO.MemoryStream stream, string saveTo)
        {
            using (System.IO.FileStream file = new System.IO.FileStream(saveTo, System.IO.FileMode.Create, System.IO.FileAccess.Write))
            {
                stream.WriteTo(file);
            }
        }
        public string UploadFile(Stream file, string fileName, string fileMime, string folder, string fileDescription)
        {
            // DriveService service = GetService();
            //
            UserCredential credential;
            Google.Apis.Drive.v3.Data.File copiedFile = new Google.Apis.Drive.v3.Data.File();
            using (var stream =
                new FileStream("credentials.json", FileMode.Open, FileAccess.Read))
            {
                // The file token.json stores the user's access and refresh tokens, and is created
                // automatically when the authorization flow completes for the first time.
                string credPath = "token.json";
                credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
                    GoogleClientSecrets.Load(stream).Secrets,
                    Scopes,
                    "user",
                    CancellationToken.None,
                    new FileDataStore(credPath, true)).Result;
                Console.WriteLine("Credential file saved to: " + credPath);
            }

            // Create Drive API service.
            var service = new DriveService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = ApplicationName,
            });
            //



            var driveFile = new Google.Apis.Drive.v3.Data.File();
            driveFile.Name = fileName;
            driveFile.Description = fileDescription;
            driveFile.MimeType = fileMime;
            driveFile.Parents = new string[] { folder };


            var request = service.Files.Create(driveFile, file, fileMime);
            request.Fields = "id";

            var response = request.Upload();
            if (response.Status != Google.Apis.Upload.UploadStatus.Completed)
                throw response.Exception;

            return request.ResponseBody.Id;
        }

    }


}

