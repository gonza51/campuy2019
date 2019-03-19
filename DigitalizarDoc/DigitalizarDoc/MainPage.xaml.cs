using Newtonsoft.Json;
using Plugin.Media;
using Plugin.Media.Abstractions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace DigitalizarDoc
{
    public partial class MainPage : ContentPage
    {

        private const string API_URL = "http://152.156.136.158:45455/api/upload";

        public MainPage()
        {
            InitializeComponent();

            uploadPhoto.IsVisible = false;
            repeatPhoto.IsVisible = false;

            string filePath = null;

            takePhoto.Clicked += async (sender, args) =>
            {

                if (!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakePhotoSupported)
                {
                    await DisplayAlert("No Camera", ":( No camera available.", "OK");
                    return;
                }

                var file = await CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions
                {
                    Directory = "Test",
                    SaveToAlbum = true,
                    CompressionQuality = 75,
                    CustomPhotoSize = 50,
                    PhotoSize = PhotoSize.MaxWidthHeight,
                    MaxWidthHeight = 2000,
                    DefaultCamera = CameraDevice.Front
                });

                if (file == null)
                    return;

                filePath = file.Path;
                //para debug
                //DisplayAlert("File Location", file.Path, "OK");

                takePhoto.IsVisible = false;
                uploadPhoto.IsVisible = true;
                repeatPhoto.IsVisible = true;

                image.Source = ImageSource.FromStream(() =>
                {
                    var stream = file.GetStream();
                    file.Dispose();
                    
                    return stream;
                });

            };

            repeatPhoto.Clicked += (sender, args) =>
            {
                image.Source = null;
                takePhoto.IsVisible = true;
                uploadPhoto.IsVisible = false;
                repeatPhoto.IsVisible = false;
            };

            uploadPhoto.Clicked += async (sender, args) =>
            {
                try
                {
                    byte[] imageBytes = System.IO.File.ReadAllBytes(filePath);

                    await SendImage(imageBytes);
                }
                catch (Exception)
                {
                    await DisplayAlert("Error", "Error enviando foto a servidor", "OK");
                }
                
            };
        }

        

        public async Task<string> SendImage(byte[] imageBytes)
        {
            try
            {
                var client = new HttpClient();
                var form = new MultipartFormDataContent();
                
                form.Add(new ByteArrayContent(imageBytes), "foto", "foto.jpg");

                string uniqueId = System.Guid.NewGuid().ToString();

                client.DefaultRequestHeaders.Add("UniqueId", uniqueId);

                HttpResponseMessage response =  await client.PostAsync(API_URL, form);

                var result = await response.Content.ReadAsStringAsync();

                if(!string.IsNullOrEmpty(result))
                {
                    UploadResponse responseObj = JsonConvert.DeserializeObject<UploadResponse>(result);
                    //await DisplayAlert("Server Response: ", result, "OK");


                    var navigation = Application.Current.MainPage as Views.CustomNavigationPage;
                    if (navigation != null)
                    {
                        await navigation.PushAsync(new ResultPage(responseObj), true);
                    }
                }

                return "OK";
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", "Error enviando foto a servidor", "OK");
                //return ex.Message;
                return "Error";
            }
        }
    }
}
