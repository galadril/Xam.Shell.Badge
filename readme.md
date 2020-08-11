[![nuget](https://img.shields.io/nuget/v/Xam.Shell.Badge.svg)](https://www.nuget.org/packages/Xam.Shell.Badge/) ![Nuget](https://img.shields.io/nuget/dt/Xam.Shell.Badge)


# Xam.Shell.Badge
Just a simple fix for adding a badge to a Shell Bottom Tabbar for your Xamarin Forms project. 
https://github.com/xamarin/Xamarin.Forms/issues/6112


# Setup
* Available on Nuget:
https://www.nuget.org/packages/Xam.Shell.Badge 
!!Install into your .net standaard project. !!


# Example
![ios](https://user-images.githubusercontent.com/14561640/89870939-e7efba80-dbb6-11ea-827b-80904f29a0ab.png)


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

```

The first value is the badge position, and the second value is the counter to show;


Or you can just look at the code to implement a badge yourself via Shell Renderers!
