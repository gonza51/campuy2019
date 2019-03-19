using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Net.Http;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace DigitalizarDoc
{
    public class ResponseViewModel : INotifyPropertyChanged
    {
        private const string API_URL = "http://152.156.136.158:45455/api/save";

        public ResponseViewModel(UploadResponse response, ResultPage invocator)
        {
            this.ResponseData = response.ImageInfo;
            this.Invocator = invocator;
        }

        public ResponseViewModel()
        {

        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private ResultPage Invocator;

        private ImageData _responseData;
        public ImageData ResponseData
        {
            get { return _responseData; }
            set
            {
                _responseData = value;
                OnPropertyChanged("ResponseData");
            }
        }

        public ICommand SaveCommand
        {
            get
            {
                return new Command(() =>
                {
                    try
                    {
                        var client = new HttpClient();

                        var requestData = JsonConvert.SerializeObject(ResponseData);

                        var content = new StringContent(requestData.ToString(), Encoding.UTF8, "application/json");

                        HttpResponseMessage response = client.PostAsync(API_URL, content).Result;

                        if(Invocator != null)
                        {
                            if(response.IsSuccessStatusCode)
                                Invocator.DisplayAlert("", "Datos guardados correctamente.", "OK");
                            else
                                Invocator.DisplayAlert("", "Error guardando datos.", "Regresar");

                            Application.Current.MainPage.Navigation.PopAsync();
                        }

                    }
                    catch (Exception ex)
                    {
                        
                    }
                });
            }
        }


    }
}
