[![nuget](https://img.shields.io/nuget/v/Xam.Shell.Badge.svg)](https://www.nuget.org/packages/Xam.Shell.Badge/) ![Nuget](https://img.shields.io/nuget/dt/Xam.Shell.Badge)

![Icon](https://raw.githubusercontent.com/galadril/Xam.Shell.Badge/master/Samples/Xam.Shell.Badge.Samples/Xam.Shell.Badge.Samples.Android/Resources/mipmap-xxhdpi/Icon.png)


# Xam.Shell.Badge
Just a simple fix for adding a badge to a Shell Bottom Tabbar for your Xamarin Forms project 


# Setup
* Available on Nuget:
https://www.nuget.org/packages/Xam.Shell.Badge

!!Install into your .net standaard project. !!


# Example
![shell_badge](https://user-images.githubusercontent.com/14561640/45887098-2c072580-bdbb-11e8-9084-3136bd911062.gif)



# Init
Init the library within your Android (MainActivity) and iOS (AppDelegate) project

```
 
            BottomBar.Init();

```


# Usage
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

```

The first value is the badge position, and the second value is the counter to show;
