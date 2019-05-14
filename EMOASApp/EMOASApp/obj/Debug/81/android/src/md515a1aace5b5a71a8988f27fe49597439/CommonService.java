package md515a1aace5b5a71a8988f27fe49597439;


public class CommonService
	extends cn.jpush.android.service.JCommonService
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"";
		mono.android.Runtime.register ("EMOASApp.CommonService, EMOASApp", CommonService.class, __md_methods);
	}


	public CommonService ()
	{
		super ();
		if (getClass () == CommonService.class)
			mono.android.TypeManager.Activate ("EMOASApp.CommonService, EMOASApp", "", this, new java.lang.Object[] {  });
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
