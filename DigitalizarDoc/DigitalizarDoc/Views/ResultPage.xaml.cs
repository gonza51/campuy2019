using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DigitalizarDoc
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ResultPage : ContentPage
	{

        

        public ResultPage()
        {
            InitializeComponent();

        }

       
        public ResultPage (UploadResponse response)
		{
			InitializeComponent ();
            this.BindingContext = new ResponseViewModel(response, this);

        }
	}
}