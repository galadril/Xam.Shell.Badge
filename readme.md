
[![nuget](https://img.shields.io/nuget/v/Xam.Shell.Badge.svg)](https://www.nuget.org/packages/Xam.Shell.Badge/) ![Nuget](https://img.shields.io/nuget/dt/Xam.Shell.Badge)

![icon](https://raw.githubusercontent.com/galadril/Xam.Shell.Badge/master/sample/Xam.Shell.Badge.Sample/Xam.Shell.Badge.Sample.Android/Resources/mipmap-xxxhdpi/ic_launcher.png)

# Xam.Shell.Badge
Just a simple fix for adding a badge to a Shell Bottom Tabbar for your Xamarin Forms project. 
Linked issue on Xamarin Forms github:
https://github.com/xamarin/Xamarin.Forms/issues/6112


# Example
![ios](https://user-images.githubusercontent.com/33980667/96633525-e57daf80-1321-11eb-9fc8-d98f2c3a78b5.png)


# Setup
* Available on Nuget:
https://www.nuget.org/packages/Xam.Shell.Badge 
!!Install into your projects. !!


# Init
Init the library within your Android (MainActivity) and iOS (AppDelegate) project

```
            BottomBar.Init();
```


# Usage
Please check the sample project on how its implemented.
Just create a shell bottom bar like done in the sample project

```

    <TabBar x:Name="tabBar">
        <Tab Title="Test1" Icon="icon.png">
            <ShellContent ContentTemplate="{DataTemplate local:MainPage}" />
        </Tab>
        <Tab Title="Test2" Icon="icon.png">
            <ShellContent ContentTemplate="{DataTemplate local:MainPage}" />
        </Tab>
        <Tab Title="Test3" Icon="icon.png">
            <ShellContent ContentTemplate="{DataTemplate local:MainPage}" />
        </Tab>
        <Tab Title="Test4" Icon="icon.png">
            <ShellContent ContentTemplate="{DataTemplate local:MainPage}" />
        </Tab>
    </TabBar>
	    
```


Then set a badge in you project code via:


```
            new BottomBarHelper().SetBadge(1, 2);

            or

            new BottomBarHelper().SetTinyBadge(1, Color.Red);

```


If you like, you can remove the badge via:


```
            new BottomBarHelper().RemoveBadge(1);

```
            

The first value is the badge position, and the second value is the counter to show;
Or you can just look at the code to implement a badge yourself via Shell Renderers!



# Donation

If you like to say thanks, you could always buy me a cup of coffee (/beer)!   
(Thanks!)  
[![PayPal donate button](https://img.shields.io/badge/paypal-donate-yellow.svg)](https://www.paypal.me/markheinis)
