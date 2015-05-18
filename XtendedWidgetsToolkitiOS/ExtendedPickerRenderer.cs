using System;
using Xamarin.Forms.Platform.iOS;
using Xamarin.Forms;
using System.Diagnostics;
using UIKit;
using Foundation;
using CoreGraphics;
using System.ComponentModel;
using XtendedWidgetsToolkit;
using XtendedWidgetsToolkitiOS;

[assembly: ExportRenderer (typeof(ExtendedPicker), typeof(ExtendedPickerRenderer))]
namespace XtendedWidgetsToolkitiOS
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
					setLeftDrawable (view);
					setRightDrawable (view);
					setBackgroundImage (view);
					setPlaceholderColor (view);
					setGravity (view);
				} catch (Exception error) {
					Debug.WriteLine (error.Message);
				}
			}
		}

		protected override void OnElementPropertyChanged (object sender, PropertyChangedEventArgs e)
		{
			base.OnElementPropertyChanged (sender, e);
			var view = (ExtendedPicker)Element;

			if (view != null && !string.IsNullOrWhiteSpace (e.PropertyName)) {

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
				} catch (Exception error) {
					Debug.WriteLine (error.Message);
				}
			}
		}

		void setFont (ExtendedPicker view)
		{

			if (string.IsNullOrWhiteSpace (view.FontName) || Control == null) {
				if (view.FontSize != 0f) {
					Control.Font = UIFont.SystemFontOfSize ((float)view.FontSize);
				}
				return;
			}

			if (view.FontSize == 0f) {
				UIFont uiFont = UIFont.FromName (view.FontName, 17f);

				if (!uiFont.Equals (Font.Default) && (uiFont != null)) {
					Control.Font = uiFont;
				} else if (uiFont.Equals (Font.Default))
					Control.Font = UIFont.SystemFontOfSize (17f);	
			} else {
				UIFont uiFont = UIFont.FromName (view.FontName, (float)view.FontSize);

				if (!uiFont.Equals (Font.Default) && (uiFont != null)) {
					Control.Font = uiFont;
				} else if (uiFont.Equals (Font.Default))
					Control.Font = UIFont.SystemFontOfSize ((float)view.FontSize);
			}
		}

		void setLeftDrawable (ExtendedPicker view)
		{
			if (string.IsNullOrWhiteSpace (view.LeftDrawable) || Control == null)
				return;
			if (!view.LeftDrawable.Equals ("")) {

				if (view.HeightRequest != -1) {
					var lImageView1 = new UIImageView (UIImage.FromBundle (view.LeftDrawable));
					lImageView1.Frame = new CGRect (10, 0, view.HeightRequest - 10, view.HeightRequest - 10);
					var lViewToAdd = new UIView (new CGRect (0, 0, view.HeightRequest + 10, view.HeightRequest - 10));
					lViewToAdd.AddSubview (lImageView1);
					Control.LeftViewMode = UITextFieldViewMode.Always;
					Control.LeftView = lViewToAdd;
				} else {
					var lImageView1 = new UIImageView (UIImage.FromBundle (view.LeftDrawable));
					lImageView1.Frame = new CGRect (10, 2.5, 25, 25);
					var lViewToAdd = new UIView (new CGRect (0, 0, 50, 30));
					lViewToAdd.AddSubview (lImageView1);
					Control.LeftViewMode = UITextFieldViewMode.Always;
					Control.LeftView = lViewToAdd;
				}
			}
		}

		void setRightDrawable (ExtendedPicker view)
		{
			if (string.IsNullOrWhiteSpace (view.RightDrawable) || Control == null)
				return;

			if (!view.RightDrawable.Equals ("")) {

				if (view.HeightRequest != -1) {
					var lImageView1 = new UIImageView (UIImage.FromBundle (view.RightDrawable));
					lImageView1.Frame = new CGRect (0, 0, view.HeightRequest - 10, view.HeightRequest - 10);
					var lViewToAdd = new UIView (new CGRect (0, 0, view.HeightRequest, view.HeightRequest - 10));
					lViewToAdd.AddSubview (lImageView1);
					Control.RightViewMode = UITextFieldViewMode.Always;
					Control.RightView = lViewToAdd;
				} else {
					var lImageView1 = new UIImageView (UIImage.FromBundle (view.RightDrawable));
					lImageView1.Frame = new CGRect (10, 2.5, 25, 25);
					var lViewToAdd = new UIView (new CGRect (0, 0, 40, 30));
					lViewToAdd.AddSubview (lImageView1);
					Control.RightViewMode = UITextFieldViewMode.Always;
					Control.RightView = lViewToAdd;
				}
			}
		}

		void setBackgroundImage (ExtendedPicker view)
		{
			if (string.IsNullOrWhiteSpace (view.BackgroundImage) || Control == null)
				return;

			if (!view.BackgroundImage.Equals ("")) {
				Control.BorderStyle = UITextBorderStyle.None;
				Control.Background = UIImage.FromBundle (view.BackgroundImage);
			}
		}

		void setPlaceholderColor (ExtendedPicker view)
		{
			if (string.IsNullOrWhiteSpace (view.Title) || Control == null)
				return;

			if (!view.PlaceholderColor.Equals ("")) {
				Control.AttributedPlaceholder = new NSAttributedString (view.Title, foregroundColor: FromHexString (view.PlaceholderColor));
			}
		}

		/// <summary>
		/// Sets the gravity.
		/// </summary>
		/// <param name="view">View.</param>
		void setGravity (ExtendedPicker view)
		{
			if (string.IsNullOrWhiteSpace (view.Gravity) || Control == null)
				return;
			
			if (view.Gravity.Equals ("left", StringComparison.CurrentCultureIgnoreCase))
				Control.TextAlignment = UITextAlignment.Left;
			else if (view.Gravity.Equals ("right", StringComparison.CurrentCultureIgnoreCase))
				Control.TextAlignment = UITextAlignment.Right;
			else if (view.Gravity.Equals ("center", StringComparison.CurrentCultureIgnoreCase) || view.Gravity.Equals ("centre", StringComparison.CurrentCultureIgnoreCase))
				Control.TextAlignment = UITextAlignment.Center;
		}



		static UIColor FromHexString (string hexValue, float alpha = 1.0f)
		{
			var colorString = hexValue.Replace ("#", "");
			if (alpha > 1.0f) {
				alpha = 1.0f;
			} else if (alpha < 0.0f) {
				alpha = 0.0f;
			}

			float red, green, blue;

			switch (colorString.Length) {
			case 3: // #RGB
				{
					red = Convert.ToInt32 (string.Format ("{0}{0}", colorString.Substring (0, 1)), 16) / 255f;
					green = Convert.ToInt32 (string.Format ("{0}{0}", colorString.Substring (1, 1)), 16) / 255f;
					blue = Convert.ToInt32 (string.Format ("{0}{0}", colorString.Substring (2, 1)), 16) / 255f;
					return UIColor.FromRGBA (red, green, blue, alpha);
				}
			case 6: // #RRGGBB
				{
					red = Convert.ToInt32 (colorString.Substring (0, 2), 16) / 255f;
					green = Convert.ToInt32 (colorString.Substring (2, 2), 16) / 255f;
					blue = Convert.ToInt32 (colorString.Substring (4, 2), 16) / 255f;
					return UIColor.FromRGBA (red, green, blue, alpha);
				}

			default:
				throw new ArgumentOutOfRangeException (string.Format ("Invalid color value {0} is invalid. It should be a hex value of the form #RBG, #RRGGBB", hexValue));

			}
		}
	}
}

