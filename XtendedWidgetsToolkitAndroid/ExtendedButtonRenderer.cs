using System;
using Xamarin.Forms.Platform.Android;
using System.ComponentModel;
using Android.Text;
using Android.Graphics;
using Xamarin.Forms;
using Android.Views;
using XtendedWidgetsToolkit;
using XtendedWidgetsToolkitAndroid;

[assembly:ExportRenderer (typeof(ExtendedButton), typeof(ExtendedButtonRenderer))]
namespace XtendedWidgetsToolkitAndroid
{
	public class ExtendedButtonRenderer:ButtonRenderer
	{
		public ExtendedButtonRenderer ()
		{
		}

		protected override void OnElementChanged (ElementChangedEventArgs<Xamarin.Forms.Button> e)
		{
			base.OnElementChanged (e);

			try {
				var view = (ExtendedButton)Element;
				if (view != null) {
					setFont (view);
					setBackgroundImage (view);
					setGravity (view);
				}
			} catch (Java.Lang.Exception exception) {
				exception.PrintStackTrace ();
			}
		}

		protected override void OnElementPropertyChanged (object sender, PropertyChangedEventArgs e)
		{
			base.OnElementPropertyChanged (sender, e);
			try {
				var view = (ExtendedButton)Element;
				if (view != null && !TextUtils.IsEmpty (e.PropertyName)) {
					if (e.PropertyName.Equals ("FontName"))
						setFont (view);
					else if (e.PropertyName.Equals ("BackgroundImage"))
						setBackgroundImage (view);
					else if (e.PropertyName.Equals ("Gravity"))
						setGravity (view);
				}
			} catch (Java.Lang.Exception exception) {
				exception.PrintStackTrace ();
			}
		}

		/// <summary>
		/// Sets the font.
		/// </summary>
		/// <param name="view">View.</param>
		void setFont (ExtendedButton view)
		{
			if (TextUtils.IsEmpty (view.FontName) || Context == null || Control == null)
				return;

			Typeface typeface = Typeface.CreateFromAsset (Context.Assets, view.FontName);
			if (!typeface.Equals (Typeface.Default) && (typeface != null)) {
				Control.Typeface = typeface;
			} else if (typeface.Equals (Typeface.Default)) {
				Control.Typeface = Typeface.SansSerif;
			}			
		}

		/// <summary>
		/// Sets the background image.
		/// </summary>
		/// <param name="view">View.</param>
		void setBackgroundImage (ExtendedButton view)
		{
			if (TextUtils.IsEmpty (view.BackgroundImage) || Context == null || Control == null)
				return;

			// http://stackoverflow.com/questions/13351003/find-drawable-by-string
			int id = Context.Resources.GetIdentifier (view.BackgroundImage, "drawable", Context.PackageName);
			if (id == 0)
				throw  new Android.Content.Res.Resources.NotFoundException ();
			else
				Control.SetBackgroundResource (id);				
		}

		/// <summary>
		/// Sets the text gravity.
		/// </summary>
		/// <param name="view">View.</param>
		void setGravity (ExtendedButton view)
		{
			if (TextUtils.IsEmpty (view.Gravity) || Context == null || Control == null)
				return;
			
			if (view.Gravity.Equals ("left", StringComparison.CurrentCultureIgnoreCase))
				Control.Gravity = GravityFlags.Left;
			else if (view.Gravity.Equals ("right", StringComparison.CurrentCultureIgnoreCase))
				Control.Gravity = GravityFlags.Right;
			else if (view.Gravity.Equals ("center", StringComparison.CurrentCultureIgnoreCase) || view.Gravity.Equals ("centre", StringComparison.CurrentCultureIgnoreCase))
				Control.Gravity = GravityFlags.Center;
			else
				Control.Gravity = GravityFlags.Center;
		}
	}
}

