using System;
using Xamarin.Forms.Platform.Android;
using Android.Text;
using Android.Graphics;
using System.ComponentModel;
using Xamarin.Forms;
using Android.Views;
using XtendedWidgetsToolkit;
using XtendedWidgetsToolkitAndroid;

[assembly: ExportRenderer (typeof(ExtendedEntry), typeof(ExtendedEntryRenderer))]
namespace XtendedWidgetsToolkitAndroid
{
	public class ExtendedEntryRenderer:EntryRenderer
	{
		public ExtendedEntryRenderer ()
		{
		}

		protected override void OnElementChanged (ElementChangedEventArgs<Entry> e)
		{
			base.OnElementChanged (e);
			try {
				var view = (ExtendedEntry)Element;
				if (view != null) {
					setFont (view);
					setFontSize (view);
					setLeftDrawable (view);
					setRightDrawable (view);
					setBackgroundImage (view);
					setPlaceholderColor (view);
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
				var view = (ExtendedEntry)Element;
				if (view != null && !TextUtils.IsEmpty (e.PropertyName)) {
					switch (e.PropertyName) {
					case "FontName":
						setFont (view);
						break;

					case "LeftDrawable":
						setLeftDrawable (view);
						break;

					case "RightDrawable":
						setRightDrawable (view);
						break;

					case"BackgroundImage":
						setBackgroundImage (view);
						break;

					case"PlaceholderColor":
						setPlaceholderColor (view);
						break;

					case"Gravity":
						setGravity (view);
						break;

					default:
						break;
					}
				}
			} catch (Java.Lang.Exception exception) {
				exception.PrintStackTrace ();
			}
		}

		/// <summary>
		/// Sets the font.
		/// </summary>
		/// <param name="view">View.</param>
		void setFont (ExtendedEntry view)
		{
			if (TextUtils.IsEmpty (view.FontName) && Context == null && Control == null)
				return;

			Typeface typeface = Typeface.CreateFromAsset (Context.Assets, view.FontName);

			if (!typeface.Equals (Typeface.Default) && (typeface != null)) {
				Control.Typeface = typeface;
			} else if (typeface.Equals (Typeface.Default)) {
				Control.Typeface = Typeface.SansSerif;
			}			
		}

		/// <summary>
		/// Sets the size of the font.
		/// </summary>
		/// <param name="view">View.</param>
		void setFontSize (ExtendedEntry view)
		{
			if (view.FontSize == 0f) {
				Control.TextSize = 17f;
			} else {
				Control.TextSize = view.FontSize;
			}
		}

		/// <summary>
		/// Sets the left drawable.
		/// </summary>
		/// <param name="view">View.</param>
		void setLeftDrawable (ExtendedEntry view)
		{
			if (TextUtils.IsEmpty (view.LeftDrawable) || Context == null || Control == null)
				return;
			
			if (!view.LeftDrawable.Equals ("")) {
				int id = Context.Resources.GetIdentifier (view.LeftDrawable, "drawable", Context.PackageName);
				if (id == 0)
					throw  new Android.Content.Res.Resources.NotFoundException ();
				else {
					Control.SetCompoundDrawablesRelativeWithIntrinsicBounds (id, 0, 0, 0);
					Control.CompoundDrawablePadding = 15;
				}
			}

		}

		/// <summary>
		/// Sets the right drawable.
		/// </summary>
		/// <param name="view">View.</param>
		void setRightDrawable (ExtendedEntry view)
		{
			if (TextUtils.IsEmpty (view.RightDrawable) || Context == null || Control == null)
				return;
			
			if (!view.RightDrawable.Equals ("")) {
				int id = Context.Resources.GetIdentifier (view.RightDrawable, "drawable", Context.PackageName);
				if (id == 0)
					throw  new Android.Content.Res.Resources.NotFoundException ();
				else {
					Control.SetCompoundDrawablesRelativeWithIntrinsicBounds (0, 0, id, 0);
					Control.CompoundDrawablePadding = 15;
				}
			}	
		}

		/// <summary>
		/// Sets the background image.
		/// </summary>
		/// <param name="view">View.</param>
		void setBackgroundImage (ExtendedEntry view)
		{
			if (TextUtils.IsEmpty (view.BackgroundImage) || Context == null || Control == null)
				return;
			
			if (!view.BackgroundImage.Equals ("")) {
				int id = Context.Resources.GetIdentifier (view.BackgroundImage, "drawable", Context.PackageName);
				if (id == 0)
					throw  new Android.Content.Res.Resources.NotFoundException ();
				else
					Control.SetBackgroundResource (id);	
			}	
		}

		/// <summary>
		/// Sets the color of the placeholder.
		/// </summary>
		/// <param name="view">View.</param>
		void setPlaceholderColor (ExtendedEntry view)
		{
			if (TextUtils.IsEmpty (view.PlaceholderColor) || Context == null || Control == null)
				return;
			
			if (!view.PlaceholderColor.Equals ("")) {
				Control.SetHintTextColor (Android.Graphics.Color.ParseColor (view.PlaceholderColor));
			}	
		}

		/// <summary>
		/// Sets the gravity.
		/// </summary>
		/// <param name="view">View.</param>
		void setGravity (ExtendedEntry view)
		{
			if (TextUtils.IsEmpty (view.Gravity) || Context == null || Control == null)
				return;
			
			if (view.Gravity.Equals ("left", StringComparison.CurrentCultureIgnoreCase))
				Control.Gravity = GravityFlags.Left;
			else if (view.Gravity.Equals ("right", StringComparison.CurrentCultureIgnoreCase))
				Control.Gravity = GravityFlags.Right;
			else if (view.Gravity.Equals ("center", StringComparison.CurrentCultureIgnoreCase) || view.Gravity.Equals ("centre", StringComparison.CurrentCultureIgnoreCase))
				Control.Gravity = GravityFlags.Center;
		}
	}
}

