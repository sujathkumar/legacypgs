   M S B A M L   `   `   `  ����T  PLL.Solutions.PMS.Controls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullhJclr-namespace:LL.Solutions.PMS.Controls;assembly=LL.Solutions.PMS.ControlsLL.Solutions.PMS.Controls  5       LL.Solutions.PMS   LL.Solutions.PMS.Shell   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      P LPrism.Wpf, Version=6.1.0.0, Culture=neutral, PublicKeyToken=91a96d2a154366d8)prismhttp://www.codeplex.com/prism  5      YcontrolsJclr-namespace:LL.Solutions.PMS.Controls;assembly=LL.Solutions.PMS.Controls  5      -   5          � Title$  
LIQUIDPARK��5	       � WindowState$ 	Maximized=�5
       � Icon$ ../Images/cgslogo.png��5      .��5      � -   5         �Name$ 
LayoutRoot��5         MainBackground#��[  5      .+�5   
   � $	��300��6    � ColumnDefinitions 5      �� 5      $
��Auto �6#   �� 5       � RowDefinitions 5      �� 5      $��70 �6    �� 5      $
��Auto �6    �� 5      $��* �6    .+�5      ]� $��0��6   $��3��6%   $��4q�69   .+�5      o� $	��Top=�6   
�������$��1q�6@   $��5q�6T   ��5      �� 5       �� EndPoint$	 0,1&�6.    �� 
StartPoint$	 0,0&�6=   .��5      �  � Color$ #616161��6+   	 � Offset$	 0.528Q�6;   � 5      $ #808080��6+   $
	 0.01Q�6;   � 5       $ #616161��6+   $	 1Q�6;   � 5!      $ #808080��6+   $	 1Q�6;   5"      
 J� BitmapEffect
 5$      F� 5%      .@�5'      m� -   5         m�Name$ menuComponents��5'      $��_View Componets��67   
�������$��Center=�6c   $��20��6~    m� Icon 5(      �� 5)      $��../Images/icon_menu.png��6$   .@�5+      m� -   5        $��ControllerStatus��5+   #   $��_Controller Status��6<   
���   �5,      m� 5-      -   5        $��SystemConfiguration��5-   #   $��_System Configuration��6>   
���   �5.      �� 5/      m� 50      -   5        $
��Exit��50   #   $��_Exit��6/   
���   �6Q   51      52      53      �� 54      $��0��6   $��2��6&    �� Orientation$ 
Horizontal=�6:   $��Center=�6S   .+�55      �� $��..\Images\cgslogo.png��6   $��	0,12,0,13q�67   $��73��6J   �� 56      $��
LIQUIDPARK��6   $��	ExtraBold"�6.   ���	#FFFFFFFF$��36(�6\    �� Padding$ 10q�6j   57      �� 58      -   5         ��Name$ lblUserName��58   1   $��0��6   $��1��6!   $��Welcome��6F   
�������$��16(�6k   $��Right=�6y   $��Center=�6�   $��10q�6�   6�   �� 59      $��0��6   $��2��6%   
������$	��140��6J   $��5,0,0,5q�6Y   ._�5:      �� -   5         ��Name$ NavigationItemsControl��5:      !  Prism.Regions.RegionManager   
RegionName$ MainNavigationRegion��6?   $��0��6u   $��5q�6�   $��5q�6�   5;      �� 5<      $ MainContentRegion��6   $��1��5=      $��2��6)   $��5,0,5,5q�66   $��Stretch=�6G   $��Stretch=�6l   5>      5?      5@      