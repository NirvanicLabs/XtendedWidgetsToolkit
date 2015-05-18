# XtendedWidgetsToolkit
XtendedWidgetsToolkit provides extended xamarin widgets, developed using mix of Xamarin's PCL (Portable Class Library) and platform specific code.

How to use XtendedWidgetsToolkit:

1. Create a Portable Library Project called TestApp.
2. Add  XtendedWidgetsToolkit library  to your newly created TestApp PCL project.<br/>
		A. Add XtendedWidgetsToolkit shared project as reference to TestApp’s shared project.<br/>
		B. Add XtendedWidgetsToolkitAndroid project as reference to TestApp.Droid<br/>
		C. Add XtendedWidgetsToolkitiOS project as reference to TestApp.iOS<br/> 
3. Clean and build the TestApp project.
4. Open the TestApp.shared form project and initialize the widget you need to customize.(ExtendedButton/ExtendedEntry/ExtendedPicker)
	Properties which can be customized for each widget are:<br/>
		a. ExtendedButton - BackgroundImage, Font, Gravity<br/>
		b. ExtendedEntry -PlaceholderColor,BackgroundImage,FontName,Gravity,LeftDrawable,RightDrawable,FontSize<br/>
		c. ExtendedPicker 
- BackgroundImage,FontName, FontSize, PlaceholderColor,Gravity,LeftDrawable,RightDrawable<br/> 			

5. In TestApp.iOS - AppDelegate.cs, Initialize XtendedWidgetsToolkitiOS by adding following line 
		new Initialzation ().init (); 

Contributors: Amrit, Amit and Chaitanya
