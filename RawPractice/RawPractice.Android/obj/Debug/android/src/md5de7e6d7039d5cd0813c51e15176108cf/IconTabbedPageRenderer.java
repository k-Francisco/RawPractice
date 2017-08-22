package md5de7e6d7039d5cd0813c51e15176108cf;


public class IconTabbedPageRenderer
	extends md5270abb39e60627f0f200893b490a1ade.TabbedPageRenderer
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onAttachedToWindow:()V:GetOnAttachedToWindowHandler\n" +
			"";
		mono.android.Runtime.register ("FormsPlugin.Iconize.Droid.IconTabbedPageRenderer, FormsPlugin.Iconize.Droid, Version=1.0.10.0, Culture=neutral, PublicKeyToken=null", IconTabbedPageRenderer.class, __md_methods);
	}


	public IconTabbedPageRenderer (android.content.Context p0, android.util.AttributeSet p1, int p2) throws java.lang.Throwable
	{
		super (p0, p1, p2);
		if (getClass () == IconTabbedPageRenderer.class)
			mono.android.TypeManager.Activate ("FormsPlugin.Iconize.Droid.IconTabbedPageRenderer, FormsPlugin.Iconize.Droid, Version=1.0.10.0, Culture=neutral, PublicKeyToken=null", "Android.Content.Context, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=84e04ff9cfb79065:Android.Util.IAttributeSet, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=84e04ff9cfb79065:System.Int32, mscorlib, Version=2.0.5.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e", this, new java.lang.Object[] { p0, p1, p2 });
	}


	public IconTabbedPageRenderer (android.content.Context p0, android.util.AttributeSet p1) throws java.lang.Throwable
	{
		super (p0, p1);
		if (getClass () == IconTabbedPageRenderer.class)
			mono.android.TypeManager.Activate ("FormsPlugin.Iconize.Droid.IconTabbedPageRenderer, FormsPlugin.Iconize.Droid, Version=1.0.10.0, Culture=neutral, PublicKeyToken=null", "Android.Content.Context, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=84e04ff9cfb79065:Android.Util.IAttributeSet, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=84e04ff9cfb79065", this, new java.lang.Object[] { p0, p1 });
	}


	public IconTabbedPageRenderer (android.content.Context p0) throws java.lang.Throwable
	{
		super (p0);
		if (getClass () == IconTabbedPageRenderer.class)
			mono.android.TypeManager.Activate ("FormsPlugin.Iconize.Droid.IconTabbedPageRenderer, FormsPlugin.Iconize.Droid, Version=1.0.10.0, Culture=neutral, PublicKeyToken=null", "Android.Content.Context, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=84e04ff9cfb79065", this, new java.lang.Object[] { p0 });
	}


	public void onAttachedToWindow ()
	{
		n_onAttachedToWindow ();
	}

	private native void n_onAttachedToWindow ();

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
