package md55370c373c346fd9a51cb9c24a6fbe012;


public class MessageReceiver
	extends cn.jpush.android.service.JPushMessageReceiver
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"";
		mono.android.Runtime.register ("EMOASApp.Receivers.MessageReceiver, EMOASApp", MessageReceiver.class, __md_methods);
	}


	public MessageReceiver ()
	{
		super ();
		if (getClass () == MessageReceiver.class)
			mono.android.TypeManager.Activate ("EMOASApp.Receivers.MessageReceiver, EMOASApp", "", this, new java.lang.Object[] {  });
	}

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
