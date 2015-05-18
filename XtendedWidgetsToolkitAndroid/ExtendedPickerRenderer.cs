using System;
using Xamarin.Forms.Platform.Android;
using Xamarin.Forms;
using System.ComponentModel;
using Android.Text;
using Android.Graphics;
using Android.Views;
using XtendedWidgetsToolkit;
using XtendedWidgetsToolkitAndroid;

[assembly: ExportRenderer (typeof(ExtendedPicker), typeof(ExtendedPickerRenderer))]
namespace XtendedWidgetsToolkitAndroid
{
	public class ExtendedPickerRenderer:PickerRenderer
	{
		public ExtendedPickerRenderer ()
		{
		}

		protected override void OnElementChanged (ElementChangedEventArgs<Picker> e)
		{
			base.OnElementChanged (e);
			var view = (ExtendedPicker)Element;

			if (view != null) {

				try {
					setFont (view);
					setFontSize (view);
					setLeftDrawable (view);
					setRightDrawable (view);
					setBackgroundImage (view);
					setPlaceholderColor (view);
					setGravity (view);
				} catch (Java.Lang.Exception ex) {
					ex.PrintStackTrace ();
				}

			}

		}

		protected override void OnElementPropertyChanged (object sender, PropertyChangedEventArgs e)
		{
			base.OnElementPropertyChanged (sender, e);
			var view = (ExtendedPicker)Element;
			if (view != null && !TextUtils.IsEmpty (e.PropertyName)) {

				try {
					//checking which property is changing
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
					}
				} catch (Java.Lang.Exception ex) {
					ex.PrintStackTrace ();
				}

			}
		}

		void setFont (ExtendedPicker view)
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

		void setFontSize (ExtendedPicker view)
		{
			if (view.FontSize == 0f) {
				Control.TextSize = 17f;
			} else {
				Control.TextSize = view.FontSize;
			}
		}

		void setLeftDrawable (ExtendedPicker view)
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

		void setRightDrawable (ExtendedPicker view)
		{
			if (TextUtils.IsEmpty (view.RightDrawable) || Context == null || Control == null)
				return;

			if (!view.RightDrawable.Equals ("")) {
				int id = Context.Resources.GetIdentifier (view.RightDrawable, "drawable", Context.PackageName);
				if (id == 0)
					throw  new Android.Content.Res.Resources.NotFoundException ();
				else {
					Control.CompoundDrawablePadding = 15;
					Control.SetCompoundDrawablesRelativeWithIntrinsicBounds (0, 0, id, 0);
				}
			}	
		}

		void setBackgroundImage (ExtendedPicker view)
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

		void setPlaceholderColor (ExtendedPicker view)
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
		void setGravity (ExtendedPicker view)
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

