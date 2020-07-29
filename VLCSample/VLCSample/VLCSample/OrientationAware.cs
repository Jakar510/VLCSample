using System;
using Xamarin.Essentials;

namespace VLCSample
{
	public class OrientationAware
	{
		public const double SIZE_NOT_ALLOCATED = -1;
		protected double _Width { get; set; }
		protected double _Height { get; set; }

		public event EventHandler<PageOrientationEventArgs> OnOrientationChanged;
		internal DisplayOrientation Orientation { get; set; }


		public OrientationAware( double width, double height )
		{
			_Width = width;
			_Height = height;
		}
		public void OnSizeAllocated( double width, double height )
		{
			double oldWidth = _Width;

			if ( Equals(_Width, width) && Equals(_Height, height) )
				return;

			_Width = width;
			_Height = height;

			// ignore if the previous height was size unallocated
			if ( Equals(oldWidth, SIZE_NOT_ALLOCATED) )
				return;

			// Has the device been rotated ?
			if ( Equals(width, oldWidth) )
				return;

			Orientation = ( width < height ) ? DisplayOrientation.Portrait : DisplayOrientation.Landscape;
			OnOrientationChanged?.Invoke(this, new PageOrientationEventArgs(Orientation));
		}
		public class PageOrientationEventArgs : EventArgs
		{
			public DisplayOrientation Orientation { get; }
			public PageOrientationEventArgs( DisplayOrientation orientation )
			{
				Orientation = orientation;
			}
		}
	}
	//public class OrientationContentPage : ContentPage
	//{
	//	public OrientationAware Orientation { get; set; }
	//	protected OrientationContentPage() : base()
	//	{
	//		Orientation = new OrientationAware(Width, Height);
	//	}
	//	protected override void OnSizeAllocated( double width, double height )
	//	{
	//		Orientation.OnSizeAllocated(width, height);
	//	}
	//}


}
