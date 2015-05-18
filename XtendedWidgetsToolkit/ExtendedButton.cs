using System;
using Xamarin.Forms;

namespace XtendedWidgetsToolkit
{
	/// <summary>
	/// Initializes a new instance of the customized button class.
	/// <list type="number">
	/// <listheader><description>Added properties are : </description></listheader>
	/// <item>
	/// <description> 1.FontName</description>
	/// </item>
	/// <item>
	/// <description> 2.BackgroundImage</description>
	/// </item>
	///	<item>
	/// <description> 3.Gravity</description>
	/// </item>
	/// </list>
	/// </summary>
	public class ExtendedButton:Button
	{
		public ExtendedButton ()
		{
		}

		public static readonly BindableProperty ExtendedFontProperty = BindableProperty.Create<ExtendedButton,string> (P => P.FontName, default(string));

		/// <summary>Gets or sets the custom font of Button :
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
		/// <value>The name of font.</value>
		public string FontName {
			get { return (string)GetValue (ExtendedFontProperty); }
			set{ SetValue (ExtendedFontProperty, value); }
		}


		public static readonly BindableProperty BackGroundProperty = BindableProperty.Create<ExtendedButton,string> (P => P.BackgroundImage, default(string));

		/// <summary>
		/// Gets or sets the background image of button. Image name should be passed as a string.
		/// </summary>
		/// <value>The background image.</value>
		public string BackgroundImage {
			get { return (string)GetValue (BackGroundProperty); }
			set{ SetValue (BackGroundProperty, value); }
		}

		public static readonly BindableProperty GravityProperty = BindableProperty.Create<ExtendedButton,string> (P => P.Gravity, default(string));

		/// <summary>
		/// Gets or sets the Gravity of the Button text : 
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
		/// <value>The Gravity of button text.</value>
		public string Gravity {
			get { return (string)GetValue (GravityProperty); }
			set{ SetValue (GravityProperty, value); }
		}
	}

}

