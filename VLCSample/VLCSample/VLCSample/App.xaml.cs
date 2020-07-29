using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using VLCSample.Services;
using VLCSample.Views;

namespace VLCSample
{
	public partial class App : Application
	{
		public App()
		{
			InitializeComponent();

			DependencyService.Register<MockDataStore>();
			MainPage = new AppShell();
			//MainPage = new VideoPlayerPage();
		}

		protected override void OnStart() { }

		protected override void OnSleep() { }

		protected override void OnResume() { }
	}
}