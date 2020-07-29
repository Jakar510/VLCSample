using System;
using System.Threading.Tasks;
using LibVLCSharp.Shared;
using VLCSample.ViewModels;

namespace VLCSample
{
	public class VideoPlayerViewModel : BaseViewModel
	{
		internal const string ELEPHANTS_DREAM = "http://commondatastorage.googleapis.com/gtv-videos-bucket/sample/ElephantsDream.mp4";
		internal const string XAMARIN_SHOW = "https://sec.ch9.ms/ch9/5d93/a1eab4bf-3288-4faf-81c4-294402a85d93/XamarinShow_mid.mp4";
		internal const string BIG_BUCK_BUNNY = "http://clips.vorwaerts-gmbh.de/big_buck_bunny.mp4";


		public Uri Site { get; set; }

		public VideoPlayerViewModel() { }


		private LibVLC _libVlc;

		public LibVLC LibVLC
		{
			get => _libVlc;
			private set => SetProperty(ref _libVlc, value);
		}


		private MediaPlayer _mediaPlayer;

		public MediaPlayer MediaPlayer
		{
			get => _mediaPlayer;
			private set => SetProperty(ref _mediaPlayer, value);
		}


		public void OnAppearing()
		{
			Core.Initialize();
			Dispose();
			LibVLC = new LibVLC();

			using var media = new Media(LibVLC, Site);

			MediaPlayer = new MediaPlayer(media)
						  {
							  EnableHardwareDecoding = true,
							  Fullscreen = true,
						  };
			MediaPlayer.Play();
		}
		public void OnDisappearing() { MediaPlayer?.Stop(); }

		public void Dispose()
		{
			LibVLC?.Dispose();
			LibVLC = null;
			MediaPlayer?.Dispose();
			MediaPlayer = null;
		}
	}
}