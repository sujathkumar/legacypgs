   M S B A M L   `   `   `  ����!  LL.Solutions.PMS.SystemStatus;    5LL.Solutions.PMS.SystemStatus.Views.ControllerLogView   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      -   5          � 	Resources  5         SystemStatusTemplate � RowDefinitions � ColumnDefinitions4  .System.Windows.Automation.AutomationProperties   AutomationId��%/  &	        �� 5   
   .R�5      �  5      �� 5      $
��Auto �6$   �� 5      $
��Auto �6$   �� 5      $
��Auto �6$   �� 5      $��* �6$    5      �� 5      $
��Auto �6'   �� 5      $��* �6'   .+�5      �� $��3��6   $��2��6&   ���	#FF0F68A6$��2q�6R   $��5, 10, 5, 0q�6f   ._�5      �� $��Stretch=�6#   $��Stretch=�6?   $
��Auto=�5      .��5      �� $��5q�6:   $
��Wrap=�6E   $ TextBlockSystemStatusData��6Y   ��6$   �� *Text+6Y   5      5      5       5!      5#      .��5%      � -   5         �Name$ 
LayoutRoot��5%      
������� 5'   
   �� 5(      $��* �6   �� 5)      $
��Auto �6   .+�5.   
   �� $��0��6    �� Orientation$ Vertical=�6"   .+�5/      �� -   5         ��Name$ txtTitle��5/      $��10q�6*   $��20��66   $��14(�6B   $
��Bold"�6P   6d   �� 50      -   5        $ txtLog��50      $��10q�6(   66   51      �� 53   
   $��1��6   $��60��6   $��Right=�6)   $��0,5,5,5q�6E   $��Go Back��54   ;   ��6   �� *GoBackCommand+6;   55      56      