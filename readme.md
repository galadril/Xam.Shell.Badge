
[![nuget](https://img.shields.io/nuget/v/Xam.Shell.Badge.svg)](https://www.nuget.org/packages/Xam.Shell.Badge/) ![Nuget](https://img.shields.io/nuget/dt/Xam.Shell.Badge)

![icon](https://raw.githubusercontent.com/galadril/Xam.Shell.Badge/master/sample/Xam.Shell.Badge.Sample/Xam.Shell.Badge.Sample.Android/Resources/mipmap-xxxhdpi/ic_launcher.png)

# Xam.Shell.Badge
Just a simple fix for adding a badge to a Shell Bottom Tabbar for your Xamarin Forms project. 
Linked issue on Xamarin Forms github:
https://github.com/xamarin/Xamarin.Forms/issues/6112


# Example
![ios](https://user-images.githubusercontent.com/14561640/96969211-6bf8e380-1512-11eb-8bcc-7b4a91ee64bd.png)


# Setup
* Available on Nuget:
https://www.nuget.org/packages/Xam.Shell.Badge 
!!Install into shared & platform projects. !!


# Init
Init the library within your Android (MainActivity) and iOS (AppDelegate) project

```C#
        BottomBar.Init();
```


# Usage
Please check the sample project on how its implemented.
Just create a shell bottom bar like done in the sample project

```XAML
    xmlns:badge="clr-namespace:Xam.Shell.Badge;assembly=Xam.Shell.Badge"

    ...

     <TabBar x:Name="tabBar">
        <Tab
            Title="Test1"
            badge:Badge.BackgroundColor="Red"
            badge:Badge.Text="2">
            <ShellContent ContentTemplate="{DataTemplate local:MainPage}" />
        </Tab>
        <Tab
            Title="Test2"
            badge:Badge.Text="0"
            badge:Badge.TextColor="Orange">
            <ShellContent ContentTemplate="{DataTemplate local:MainPage}" />
        </Tab>
        <Tab Title="Test3" badge:Badge.Text="">
            <ShellContent ContentTemplate="{DataTemplate local:MainPage}" />
        </Tab>
        <Tab
            Title="Test4"
            badge:Badge.BackgroundColor="Green"
            badge:Badge.Text="200">
            <ShellContent ContentTemplate="{DataTemplate local:MainPage}" />
        </Tab>
    </TabBar>
	    
```


Then set a badge properties on the Tab bar via the next properties:

```XAML
        badge:Badge.Text="0"
        badge:Badge.TextColor="Orange"
        badge:Badge.BackgroundColor="Red"
```

badge:Badge.Text="0"    -> Tiny Badge
badge:Badge.Text="5"    -> Normal Badge


If you like, you can remove the badge via:

```XAML
        badge:Badge.Text=""
```
            

Check the sample project for more info!


# Contribution
Feel free to create PR's with fixes/new features!


# Donation

If you like to say thanks, you could always buy me a cup of coffee (/beer)!   
(Thanks!)  
[![PayPal donate button](https://img.shields.io/badge/paypal-donate-yellow.svg)](https://www.paypal.me/markheinis)
