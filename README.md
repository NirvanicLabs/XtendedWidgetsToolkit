# XtendedWidgetsToolkit
XtendedWidgetsToolkit - Customizing Xamarin Widgets made easy.

How to use XtendedWidgetsToolkit:

1. Create a Portable Library Project called TestApp.
2. Add  XtendedWidgetsToolkit library  to your newly created TestApp PCL project.
		A. Add XtendedWidgetsToolkit shared project as reference to TestApp’s shared project.
		B. Add XtendedWidgetsToolkitAndroid project as reference to TestApp.Droid
		C. Add XtendedWidgetsToolkitiOS project as reference to TestApp.iOS 
3. Clean and build the TestApp project.
4. Open the TestApp.shared form project and initialize the widget you need to customize.(ExtendedButton/ExtendedEntry/ExtendedPicker)
	Properties which can be customized for each widget are:
		a. ExtendedButton - BackgroundImage, Font, Gravity
		b. ExtendedEntry -PlaceholderColor,BackgroundImage,FontName,Gravity,LeftDrawable,RightDrawable,FontSize
		c. ExtendedPicker - BackgroundImage,FontName, FontSize, PlaceholderColor, 					Gravity,LeftDrawable,RightDrawable

5. In TestApp.iOS - AppDelegate.cs, Initialize XtendedWidgetsToolkitiOS by adding following line 
		new Initialzation ().init (); 

Authors - Amrut Purandare,  Amit Limje
