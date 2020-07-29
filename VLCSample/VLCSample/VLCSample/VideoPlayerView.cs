using System;
using LibVLCSharp.Forms.Shared;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace VLCSample
{
	public class VideoPlayerPage : ContentPage
	{
		public PlayerView View { get; }
		public OrientationAware Orientation { get; set; }
		public VideoPlayerViewModel ViewModel { get; set; }


		public VideoPlayerPage() : this(new Uri(VideoPlayerViewModel.BIG_BUCK_BUNNY)) { }
		public VideoPlayerPage( Uri link ) : base()
		{
			Visual = new VisualMarker.DefaultVisual();
			Orientation = new OrientationAware(Width, Height);
			View = new PlayerView();
			Content = new StackLayout()
					  {
						  Visual = new VisualMarker.DefaultVisual(),
						  HorizontalOptions = LayoutOptions.FillAndExpand,
						  VerticalOptions = LayoutOptions.FillAndExpand,
						  Children =
						  {
							  View
						  }
					  };
			BindingContext = ViewModel = new VideoPlayerViewModel()
										 {
											 Site = link
										 };
		}
		~VideoPlayerPage() => Dispose();


		private void OrientationOnOnOrientationChanged( object sender, OrientationAware.PageOrientationEventArgs e )
		{
			if ( e is null ) throw new ArgumentNullException(nameof(e));

			switch ( e.Orientation )
			{
				case DisplayOrientation.Unknown:
				case DisplayOrientation.Portrait:
					View.MediaPlayer.Fullscreen = false;
					break;

				case DisplayOrientation.Landscape:
					View.MediaPlayer.Fullscreen = true;
					break;

				default:
					throw new ArgumentOutOfRangeException(nameof(e), e, @"e.Orientation is out of range.");
			}
		}
		protected override void OnSizeAllocated( double width, double height )
		{
			base.OnSizeAllocated(width, height);
			Orientation.OnSizeAllocated(width, height);
		}


		protected override void OnAppearing()
		{
			ViewModel.OnAppearing();
			View.OnAppearing();
			Orientation.OnOrientationChanged += OrientationOnOnOrientationChanged;
			base.OnAppearing();
		}
		protected override void OnDisappearing()
		{
			base.OnDisappearing();
			Orientation.OnOrientationChanged -= OrientationOnOnOrientationChanged;
			ViewModel.OnDisappearing();
		}
		public void Dispose() => ViewModel?.Dispose();


		public class PlayerView : MediaPlayerElement
		{
			public PlayerView() : base()
			{
				HorizontalOptions = LayoutOptions.FillAndExpand;
				VerticalOptions = LayoutOptions.FillAndExpand;
				SetBinding(MediaPlayerProperty, new Binding(nameof(VideoPlayerViewModel.MediaPlayer)));
				SetBinding(LibVLCProperty, new Binding(nameof(VideoPlayerViewModel.LibVLC)));
			}
			public void OnAppearing()
			{
				PlaybackControls.IsAudioTracksSelectionButtonVisible = true;
				PlaybackControls.IsAspectRatioButtonVisible = true;
				PlaybackControls.IsCastButtonVisible = true;
				PlaybackControls.IsClosedCaptionsSelectionButtonVisible = true;
				PlaybackControls.IsPlayPauseButtonVisible = true;
				PlaybackControls.IsStopButtonVisible = true;
				PlaybackControls.IsRewindButtonVisible = true;
				PlaybackControls.IsSeekBarVisible = true;
				PlaybackControls.IsSeekButtonVisible = true;
				PlaybackControls.IsSeekEnabled = true;
				PlaybackControls.KeepScreenOn = true;
			}
		}
	}
}