package md515a1aace5b5a71a8988f27fe49597439;


public class Receiver_test
	extends cn.jpush.android.service.WakedResultReceiver
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onWake:(Landroid/content/Context;I)V:GetOnWake_Landroid_content_Context_IHandler\n" +
			"n_onWake:(I)V:GetOnWake_IHandler\n" +
			"";
		mono.android.Runtime.register ("EMOASApp.Receiver_test, EMOASApp", Receiver_test.class, __md_methods);
	}


	public Receiver_test ()
	{
		super ();
		if (getClass () == Receiver_test.class)
			mono.android.TypeManager.Activate ("EMOASApp.Receiver_test, EMOASApp", "", this, new java.lang.Object[] {  });
	}


	public void onWake (android.content.Context p0, int p1)
	{
		n_onWake (p0, p1);
	}

	private native void n_onWake (android.content.Context p0, int p1);


	public void onWake (int p0)
	{
		n_onWake (p0);
	}

	private native void n_onWake (int p0);

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
