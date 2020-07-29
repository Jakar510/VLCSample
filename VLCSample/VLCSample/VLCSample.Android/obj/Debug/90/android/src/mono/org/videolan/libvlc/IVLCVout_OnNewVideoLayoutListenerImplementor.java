package mono.org.videolan.libvlc;


public class IVLCVout_OnNewVideoLayoutListenerImplementor
	extends java.lang.Object
	implements
		mono.android.IGCUserPeer,
		org.videolan.libvlc.IVLCVout.OnNewVideoLayoutListener
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onNewVideoLayout:(Lorg/videolan/libvlc/IVLCVout;IIIIII)V:GetOnNewVideoLayout_Lorg_videolan_libvlc_IVLCVout_IIIIIIHandler:Org.Videolan.Libvlc.IVLCVoutOnNewVideoLayoutListenerInvoker, LibVLCSharp.Android.AWindow\n" +
			"";
		mono.android.Runtime.register ("Org.Videolan.Libvlc.IVLCVoutOnNewVideoLayoutListenerImplementor, LibVLCSharp.Android.AWindow", IVLCVout_OnNewVideoLayoutListenerImplementor.class, __md_methods);
	}


	public IVLCVout_OnNewVideoLayoutListenerImplementor ()
	{
		super ();
		if (getClass () == IVLCVout_OnNewVideoLayoutListenerImplementor.class)
			mono.android.TypeManager.Activate ("Org.Videolan.Libvlc.IVLCVoutOnNewVideoLayoutListenerImplementor, LibVLCSharp.Android.AWindow", "", this, new java.lang.Object[] {  });
	}


	public void onNewVideoLayout (org.videolan.libvlc.IVLCVout p0, int p1, int p2, int p3, int p4, int p5, int p6)
	{
		n_onNewVideoLayout (p0, p1, p2, p3, p4, p5, p6);
	}

	private native void n_onNewVideoLayout (org.videolan.libvlc.IVLCVout p0, int p1, int p2, int p3, int p4, int p5, int p6);

	private java.util.ArrayList refList;
	public void monodroidAddReference (java.lang.Object obj)
	{
		if (refList == null)
			refList = new java.util.ArrayList ();
		refList.add (obj);
	}

	public void monodroidClearReferences ()
	{
		if (refList != null)
			refList.clear ();
	}
}
