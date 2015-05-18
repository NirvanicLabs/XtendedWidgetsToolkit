using System;
using Xamarin.Forms;

namespace XtendedWidgetsToolkit
{
	/// <summary>
	/// Initializes a new instance of the customized entry class.
	/// <list type="number">
	/// <listheader><description>Added properties are : </description></listheader>
	/// <item>
	/// <description> 1.FontName</description>
	/// </item>
	/// <item>
	/// <description> 2.Font size</description>
	/// </item>
	///	<item>
	/// <description> 3.Left drawable</description>
	/// </item>
	///	<item>
	/// <description> 4.Right drawable</description>
	/// </item>
	///	<item>
	/// <description> 5.Background image</description>
	/// </item>
	///	<item>
	/// <description> 6.Placeholder color</description>
	/// </item>
	///	<item>
	/// <description> 7.Gravity </description>
	/// </item>
	/// </list>
	/// </summary>
	public class ExtendedEntry:Entry
	{
		public ExtendedEntry ()
		{
		}

		public static readonly BindableProperty FontPropertyValue =
			BindableProperty.Create<ExtendedEntry,string> (P => P.FontName, default(string));

		public static readonly BindableProperty FontPropertySize =
			BindableProperty.Create<ExtendedEntry,float> (p => p.FontSize, default(float));

		public static readonly BindableProperty LeftDrawableProperty =
			BindableProperty.Create<ExtendedEntry,string> (P => P.LeftDrawable, "");

		public static readonly BindableProperty RightDrawableProperty =
			BindableProperty.Create<ExtendedEntry,string> (P => P.RightDrawable, "");

		public static readonly BindableProperty BackgroundImageProperty =
			BindableProperty.Create<ExtendedEntry,string> (P => P.BackgroundImage, "");

		public static readonly BindableProperty PlaceholderColorProperty =
			BindableProperty.Create<ExtendedEntry,string> (P => P.PlaceholderColor, "");

		public static readonly BindableProperty GravityProperty =
			BindableProperty.Create<ExtendedEntry,string> (P => P.Gravity, "");


		/// <summary>Gets or sets the custom font of Entry :
		/// <list type="number">
		/// <listheader>
		/// <description>Acceptable values are as follows : </description>
		/// </listheader>
		/// <item>
		/// <description> 1.For android provide full font name with '.ttf' extension</description>
		/// </item>
		/// <item>
		/// <description> 2.For iOS provide font family name</description>
		/// </item>
		/// </list>
		/// </summary>
		/// <value>The name of the font.</value>
		public string FontName {
			get { return (string)GetValue (FontPropertyValue); }
			set{ SetValue (FontPropertyValue, value); }
		}

		/// <summary>Gets or sets the font size of Entry :
		///<description>Fontsize should be given in float for example 20f</description>
		/// </summary>
		/// <value>The size of the font.</value>
		public float FontSize {
			get { return (float)GetValue (FontPropertySize); }
			set{ SetValue (FontPropertySize, value); }
		}

		/// <summary>Gets or sets the left drawable of Entry :
		///<description>Image name should be passed as a string. For example LeftDrawable = Device.OnPlatform ("Icon-76", "icon", null). Where 'Icon-76' is image for iOS and 'icon' is image for android</description>
		/// </summary>
		/// <value>Left drawable for the entry.</value>
		public string LeftDrawable {
			get { return (string)GetValue (LeftDrawableProperty); }
			set{ SetValue (LeftDrawableProperty, value); }
		}

		/// <summary>Gets or sets the right drawable of Entry :
		///<description>Image name should be passed as a string. For example RightDrawable = Device.OnPlatform ("Icon-76", "icon", null). Where 'Icon-76' is image for iOS and 'icon' is image for android</description>
		/// </summary>
		/// <value>Right drawable for the entry</value>
		public string RightDrawable {
			get { return (string)GetValue (RightDrawableProperty); }
			set{ SetValue (RightDrawableProperty, value); }
		}

		/// <summary>Gets or sets the background image to the Entry :
		///<description>Image name should be passed as a string. For example BackgroundImage = Device.OnPlatform ("Icon-76", "icon", null). Where 'Icon-76' is image for iOS and 'icon' is image for android</description>
		/// </summary>
		/// <value>Background Image for the entry</value>
		public string BackgroundImage {
			get { return (string)GetValue (BackgroundImageProperty); }
			set{ SetValue (BackgroundImageProperty, value); }
		}

		/// <summary>Gets or sets the placeholder color to the Entry :
		///<description>Placeholder color should be a hex value which should be passed as a string. For example- PlaceholderColor = "FFF000"</description>
		/// </summary>
		/// <value>Right drawable for the entry</value>
		public string PlaceholderColor {
			get { return (string)GetValue (PlaceholderColorProperty); }
			set{ SetValue (PlaceholderColorProperty, value); }
		}

		/// <summary>
		/// Gets or sets the Gravity of the Entry text : 
		///<list type="number"> 
		/// <listheader>
		/// <description>Acceptable values are as follows: </description>
		/// </listheader>
		/// <item> 
		/// 	<description>1.left </description>
		/// </item>
		/// <item> 
		/// 	<description> 2.right </description>
		/// </item>
		/// <item> 
		/// 	<description> 3.center </description>
		/// </item>
		/// </list>
		/// </summary>
		/// <value>The Gravity of entry text.</value>
		public string Gravity {
			get { return (string)GetValue (GravityProperty); }
			set{ SetValue (GravityProperty, value); }
		}
	}
}

