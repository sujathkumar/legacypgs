   M S B A M L   `   `   `  ����_  [LL.Solutions.PMS.ConfigurationEditor, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullg8clr-namespace:LL.Solutions.PMS.ConfigurationEditor.Views*LL.Solutions.PMS.ConfigurationEditor.Views  5      @    :LL.Solutions.PMS.ConfigurationEditor.Views.LevelController   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Jlocal8clr-namespace:LL.Solutions.PMS.ConfigurationEditor.Views     5      -   5        $��LController��5      .��5      9� $��Configuration Details��6     9� 
IsExpanded  . .��5   
   �� 
�������$��1q�6)   ._�5      � $��5q�6    � ColumnDefinitions 5      �� 5      $	��200 �6'   �� 5      $��* �6'    � RowDefinitions 5      �� 5      $��* �6$   �� 5      $��* �6$   �� 5      $��* �6$   �� 5      $��* �6$   �� 5      $��* �6$   �� 5      $��* �6$   �� 5      $��* �6$   .+�5      �� $��0��6   $��0��6)   
�������69   �� 5      $��0��6   $��0��6%   
�������.��6H   Level Controller No6]   �� 5      -   5         ��Name$ txtLevelControllerNumber��5      $��0��6<   $��1��6I   
�������$��1q�6q   6�   �� 5      $��1��6   $��0��6)   �� 5      $��1��6   $��0��6%   
�������$��1,0,0,0q�6M   .��6g   Level Controller IP6|   �� 5       -   5        $ txtLevelControllerIP��5       $��1��68   $��1��6E   
�������$��1,0,1,0q�6m   6�   �� 5!      $��2��6   $��0��6)   
�������69   �� 5"      $��2��6   $��0��6%   
�������.��6H   Level Spaces6V   �� 5#      -   5        $ txtLevelSpaces��5#      $��2��62   $��1��6?   
�������$��1q�6g   6}   �� 5$      $��3��6   $��0��6)   �� 5%      $��3��6   $��0��6%   
�������$��1,0,0,0q�6M   .��6g   Level Zones6t   �� 5&      -   5        $ txtTotalZones��5&      $��3��61   $��1��6>   
�������$��1,0,1,0q�6f   6�   �� 5'      $��4��6   $��0��6)   
�������69   �� 5(      $��4��6   $��0��6%   
�������.��6H   Level Detectors6Y   �� 5)      -   5        $ txtLevelDetectors��5)      $��4��65   $��1��6B   
�������$��1q�6j   6�   �� 5*      $��5��6   $��2��6&   $��5, 10, 5, 0q�6:   ._�5+      �� $��Stretch=�6#   $��Stretch=�6?   $
��Auto=�6]   .��5,      �� -   5         ��Name$ spZoneContoller��5,   %    �� Orientation$ Vertical=�6>   6W   5-      5.      �� 5/      -   5         ��Name$ btnZone��5/      $��6��6*   $��1��67   $��12(�6G   $��Add Zone��6U    � Cursor$
 Hand��6h   $��Right=�6v   $��Center=�6�   $��0,0,10,0q�6�   ��50      �� 51       �� 
TargetType" ��6*   .R�52      �� �� 53      54      55      ��57      �� 58      	 �� 
TargetType"	 ��6    .�59      �� 
 �� Property
 � �� �� Value
 �   �6;    �� Triggers 5:      P� 5;   "    P� Property �@J�IsMouseOver P� Value . . �5<   &   �� 
 � ��
 �  ��6C   5=   #   5?      5A      5B      5C      5D      5E      