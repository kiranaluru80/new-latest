using System.IO;
using System.Reflection;
using Newtonsoft.Json;
using Xamarin.Forms;

namespace ReadDataFromJson
{
	public partial class ReadDataFromJsonPage : ContentPage
	{
		protected ReadDataViewModel vm;
		public ReadDataFromJsonPage()
		{
			InitializeComponent();

			vm = new ReadDataViewModel();
			this.BindingContext = vm;
			searchRef.TextChanged += (object sender, TextChangedEventArgs e) =>
			{
				vm.textChangedMethod(e.NewTextValue);
			};
		}
	}
}
