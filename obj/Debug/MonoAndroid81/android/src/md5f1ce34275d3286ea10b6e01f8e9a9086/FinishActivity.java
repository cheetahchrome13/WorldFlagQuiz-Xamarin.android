package md5f1ce34275d3286ea10b6e01f8e9a9086;


public class FinishActivity
	extends android.app.Activity
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onCreate:(Landroid/os/Bundle;)V:GetOnCreate_Landroid_os_Bundle_Handler\n" +
			"";
		mono.android.Runtime.register ("WorldFlagQuiz.FinishActivity, WorldFlagQuiz", FinishActivity.class, __md_methods);
	}


	public FinishActivity ()
	{
		super ();
		if (getClass () == FinishActivity.class)
			mono.android.TypeManager.Activate ("WorldFlagQuiz.FinishActivity, WorldFlagQuiz", "", this, new java.lang.Object[] {  });
	}


	public void onCreate (android.os.Bundle p0)
	{
		n_onCreate (p0);
	}

	private native void n_onCreate (android.os.Bundle p0);

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
