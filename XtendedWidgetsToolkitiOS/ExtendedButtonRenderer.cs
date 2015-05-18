using System;
using Xamarin.Forms.Platform.iOS;
using Xamarin.Forms;
using System.ComponentModel;
using UIKit;
using System.Diagnostics;
using XtendedWidgetsToolkitiOS;
using XtendedWidgetsToolkit;

[assembly:ExportRenderer (typeof(ExtendedButton), typeof(ExtendedButtonRenderer))]
namespace XtendedWidgetsToolkitiOS
{
	public class ExtendedButtonRenderer:ButtonRenderer
	{
		public ExtendedButtonRenderer ()
		{
		}

		protected override void OnElementChanged (ElementChangedEventArgs<Button> e)
		{
			base.OnElementChanged (e);
			try {
				var view = (ExtendedButton)Element;
				if (view != null) {
					setFont (view);
					setBackgroundImage (view);
					setGravity (view);
				}
			} catch (Exception error) {
				Debug.WriteLine (error.Message + error.Source);
			}
		}

		// triggered whenever any bindable property is changed
		protected override void OnElementPropertyChanged (object sender, PropertyChangedEventArgs e)
		{
			base.OnElementPropertyChanged (sender, e);
			try {
				var view = (ExtendedButton)Element;
				if (view != null && !string.IsNullOrWhiteSpace (e.PropertyName)) {
					if (e.PropertyName.Equals ("FontName"))
						setFont (view);
					else if (e.PropertyName.Equals ("BackgroundImage"))
						setBackgroundImage (view);
					else if (e.PropertyName.Equals ("Gravity"))
						setGravity (view);
				}
			} catch (Exception error) {
				Debug.WriteLine (error.Message);
			}
		}

		/// <summary>
		/// Sets the font.
		/// </summary>
		/// <param name="view">View.</param>
		void setFont (ExtendedButton view)
		{
			if (string.IsNullOrWhiteSpace (view.FontName) || Control == null)
				return;

			UIFont uiFont = UIFont.FromName (view.FontName, (float)view.FontSize);

			if (!uiFont.Equals (Font.Default) && (uiFont != null)) {
				Control.Font = uiFont;
			} else if (uiFont.Equals (Font.Default))
				Control.Font = UIFont.SystemFontOfSize ((float)view.FontSize);
		}

		/// <summary>
		/// Sets the background image.
		/// </summary>
		/// <param name="view">View.</param>
		void setBackgroundImage (ExtendedButton view)
		{
			if (string.IsNullOrWhiteSpace (view.BackgroundImage) || Control == null)
				return;

			UIImage image = UIImage.FromBundle (view.BackgroundImage);
			if (image == null)
				throw new NullReferenceException ();
			else
				Control.SetBackgroundImage (image, UIControlState.Normal);
		}

		/// <summary>
		/// Sets the gravity.
		/// </summary>
		/// <param name="view">View.</param>
		void setGravity (ExtendedButton view)
		{
			if (string.IsNullOrWhiteSpace (view.Gravity) || Control == null)
				return;

			if (view.Gravity.Equals ("left", StringComparison.CurrentCultureIgnoreCase))
				Control.HorizontalAlignment = UIControlContentHorizontalAlignment.Left;
			else if (view.Gravity.Equals ("right", StringComparison.CurrentCultureIgnoreCase))
				Control.HorizontalAlignment = UIControlContentHorizontalAlignment.Right;
			else if (view.Gravity.Equals ("center", StringComparison.CurrentCultureIgnoreCase) || view.Gravity.Equals ("centre", StringComparison.CurrentCultureIgnoreCase))
				Control.HorizontalAlignment = UIControlContentHorizontalAlignment.Center;
			else
				Control.HorizontalAlignment = UIControlContentHorizontalAlignment.Center;
		}
	}
}


