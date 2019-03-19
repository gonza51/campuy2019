using Microsoft.Azure.CognitiveServices.Vision.ComputerVision;
using Microsoft.Azure.CognitiveServices.Vision.ComputerVision.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Hosting;
using System.Web.Http;

namespace DigitalizarAPI.Controllers
{
    public class UploadController : ApiController
    {
        //string fullPath = "";
        //const string subscriptionKey = "c087eaf360db41c697aaf08d2a0289d5";
        //private const string localImagePath = @"C:\Users\Bruno\Downloads\WhatsApp Image 2019-03-17 at 16.21.17.jpg";
        //const string uriBase = "https://westcentralus.api.cognitive.microsoft.com/vision/v2.0";
        //private const TextRecognitionMode textRecognitionMode =
        //    TextRecognitionMode.Handwritten;
        //private const int numberOfCharsInOperationId = 36;

        //// POST api/<controller>
        //public IHttpActionResult Post()
        //{
        //    //var result = new HttpResponseMessage(HttpStatusCode.OK);

        //    if (Request.Content.IsMimeMultipartContent())
        //    {
        //        string uniqueId = null;
        //        Request.Content.ReadAsMultipartAsync<MultipartMemoryStreamProvider>(new MultipartMemoryStreamProvider()).ContinueWith((task) =>
        //        {
        //            MultipartMemoryStreamProvider provider = task.Result;
        //            foreach (HttpContent content in provider.Contents)
        //            {
        //                Stream stream = content.ReadAsStreamAsync().Result;
        //                Image image = Image.FromStream(stream);
        //                var testName = content.Headers.ContentDisposition.Name;
        //                string filePath = HostingEnvironment.MapPath("~/Images/");
        //                //string[] headerValues = (string[])Request.Headers.GetValues("UniqueId");
        //                //string fileName = headerValues[0] + ".jpg";

        //                uniqueId = System.Guid.NewGuid().ToString();
        //                string fileName = uniqueId + ".jpg";
        //                fullPath = Path.Combine(filePath, fileName);
        //                image.Save(fullPath);

        //                if (fullPath != null && fullPath != "")
        //                    Leer(fullPath); 
        //            }
        //        });


        //        /*Ir a api a tansaformar */

        //        return Ok();


        //    }
        //    else
        //    {
        //        throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotAcceptable, "No se recibio un request con formato correcto."));
        //    }
        //}

        //private void Leer(string args)
        //{
        //    ComputerVisionClient computerVision = new ComputerVisionClient(
        //        new ApiKeyServiceClientCredentials(subscriptionKey),
        //        new System.Net.Http.DelegatingHandler[] { });

        //    // You must use the same region as you used to get your subscription
        //    // keys. For example, if you got your subscription keys from westus,
        //    // replace "westcentralus" with "westus".
        //    //
        //    // Free trial subscription keys are generated in the "westus"
        //    // region. If you use a free trial subscription key, you shouldn't
        //    // need to change the region.

        //    // Specify the Azure region
        //    computerVision.Endpoint = "https://westcentralus.api.cognitive.microsoft.com";

        //    Console.WriteLine("Images being analyzed ...");
        //    //var t1 = ExtractRemoteTextAsync(computerVision, remoteImageUrl);
        //    var t2 = ExtractLocalTextAsync(computerVision, localImagePath);

        //    Task.WhenAll(t2).Wait(5000);
        //    Console.WriteLine("Press ENTER to exit");
        //    Console.ReadLine();
        //}

        //// Recognize text from a remote image
        //private async Task ExtractRemoteTextAsync(
        //    ComputerVisionClient computerVision, string imageUrl)
        //{
        //    if (!Uri.IsWellFormedUriString(imageUrl, UriKind.Absolute))
        //    {
        //        Console.WriteLine(
        //            "\nInvalid remoteImageUrl:\n{0} \n", imageUrl);
        //        return;
        //    }

        //    // Start the async process to recognize the text
        //    RecognizeTextHeaders textHeaders =
        //        await computerVision.RecognizeTextAsync(
        //            imageUrl, textRecognitionMode);

        //    await GetTextAsync(computerVision, textHeaders.OperationLocation);
        //}

        //// Recognize text from a local image
        //private async Task ExtractLocalTextAsync(
        //    ComputerVisionClient computerVision, string imagePath)
        //{
        //    if (!File.Exists(imagePath))
        //    {
        //        Console.WriteLine(
        //            "\nUnable to open or read localImagePath:\n{0} \n", imagePath);
        //        return;
        //    }

        //    using (Stream imageStream = File.OpenRead(imagePath))
        //    {
        //        // Start the async process to recognize the text
        //        RecognizeTextInStreamHeaders textHeaders =
        //            await computerVision.RecognizeTextInStreamAsync(
        //                imageStream, textRecognitionMode);

        //        await GetTextAsync(computerVision, textHeaders.OperationLocation);
        //    }
        //}

        //// Retrieve the recognized text
        //private async Task GetTextAsync(
        //    ComputerVisionClient computerVision, string operationLocation)
        //{
        //    // Retrieve the URI where the recognized text will be
        //    // stored from the Operation-Location header
        //    string operationId = operationLocation.Substring(
        //        operationLocation.Length - numberOfCharsInOperationId);

        //    Console.WriteLine("\nCalling GetHandwritingRecognitionOperationResultAsync()");
        //    TextOperationResult result =
        //        await computerVision.GetTextOperationResultAsync(operationId);

        //    // Wait for the operation to complete
        //    int i = 0;
        //    int maxRetries = 10;
        //    while ((result.Status == TextOperationStatusCodes.Running ||
        //            result.Status == TextOperationStatusCodes.NotStarted) && i++ < maxRetries)
        //    {
        //        Console.WriteLine(
        //            "Server status: {0}, waiting {1} seconds...", result.Status, i);
        //        await Task.Delay(1000);

        //        result = await computerVision.GetTextOperationResultAsync(operationId);
        //    }

        //    var wordsArray = result.RecognitionResult.Lines.ToArray();

        //    UploadResponse response = new UploadResponse();
        //    response.StatusCode = 0;

        //    if (wordsArray.Length > 0)
        //    {

        //        string nombre = wordsArray[3].Text.TrimEnd().TrimStart();
        //        string documento = wordsArray[5].Text.Replace(",", "").Replace(".", "").Replace(")", "").Replace(" ", "").Replace("-", "");
        //        string telefono = wordsArray[7].Text.Replace(" ", ""); 
        //        string email = wordsArray[9].Text.Replace(" ", "");
        //        string id = wordsArray[9].Text;


        //        //response.RequestId = uniqueId;
        //        response.StatusDesc = "OK";
        //        response.ImageInfo = new ImageData();
        //        response.ImageInfo.Document = documento;
        //        response.ImageInfo.ID = id;
        //        response.ImageInfo.Email = email;
        //        response.ImageInfo.Name = nombre;
        //        response.ImageInfo.Phone = telefono;

        //    }

        //}

       // POST api/<controller>
        public IHttpActionResult Post()
        {
            ////var result = new HttpResponseMessage(HttpStatusCode.OK);

            if (Request.Content.IsMimeMultipartContent())
            {
                string uniqueId = null;
                Request.Content.ReadAsMultipartAsync<MultipartMemoryStreamProvider>(new MultipartMemoryStreamProvider()).ContinueWith((task) =>
                {
                    MultipartMemoryStreamProvider provider = task.Result;
                    foreach (HttpContent content in provider.Contents)
                    {
                        Stream stream = content.ReadAsStreamAsync().Result;
                        Image image = Image.FromStream(stream);
                        var testName = content.Headers.ContentDisposition.Name;
                        string filePath = HostingEnvironment.MapPath("~/Images/");
                        //string[] headerValues = (string[])Request.Headers.GetValues("UniqueId");
                        //string fileName = headerValues[0] + ".jpg";

                        uniqueId = System.Guid.NewGuid().ToString();
                        string fileName = uniqueId + ".jpg";
                        string fullPath = Path.Combine(filePath, fileName);
                        image.Save(fullPath);
                    }
                });

                UploadResponse response = new UploadResponse();

                response.StatusCode = 0;
                response.RequestId = uniqueId;
                response.StatusDesc = "OK";
                response.ImageInfo = new ImageData();
                response.ImageInfo.Document = "12345672";
                response.ImageInfo.ID = "098127";
                response.ImageInfo.Email = "unmail@undominio.com";
                response.ImageInfo.Name = "Juan Perez";
                response.ImageInfo.Phone = "24022330";

                return Ok(response);
            }
            else
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotAcceptable, "No se recibio un request con formato correcto."));
            }
        }


    }
}