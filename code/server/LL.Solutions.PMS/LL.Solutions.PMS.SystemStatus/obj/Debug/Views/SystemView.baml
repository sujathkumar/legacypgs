   M S B A M L   `   `   `  ����Z  VLL.Solutions.PMS.Infrastructure, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullzVclr-namespace:LL.Solutions.PMS.Infrastructure;assembly=LL.Solutions.PMS.InfrastructureLL.Solutions.PMS.Infrastructure  5      T PLL.Solutions.PMS.Controls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullhJclr-namespace:LL.Solutions.PMS.Controls;assembly=LL.Solutions.PMS.ControlsLL.Solutions.PMS.Controls 5	      ! LL.Solutions.PMS.SystemStatus4   .LL.Solutions.PMS.SystemStatus.Views.SystemView   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      qinfrastructureVclr-namespace:LL.Solutions.PMS.Infrastructure;assembly=LL.Solutions.PMS.Infrastructure     5      _controlsJclr-namespace:LL.Solutions.PMS.Controls;assembly=LL.Solutions.PMS.Controls     5	      -   5          >�Name$  userControl��5       � 	Resources 5      A   ;LL.Solutions.PMS.Infrastructure.ObjectToVisibilityConverter   ObjectToVisibility " SystemStatusListContainerStyle �� 
TargetType  DefaultListBoxItemStyle �� BasedOn �� Property �� Value  SystemStatusListTemplate � RowDefinitions � ColumnDefinitions �� Orientation4  .System.Windows.Automation.AutomationProperties	   AutomationId
 �� ElementName  SystemStatusTemplate��%K  &	        &	      7  &	 �     &	 �      5   
   65   �� 5   
   " ��67   8   .�5      ��  � ��$ 0q�6(   �� 5       � ��$ Stretch=�6;   5      �� 5   
   .R�5      �� 
�������$��0,0,0,1q�6(   ._�5      �  5      �� 5      $
��Auto �6(   �� 5      $
��Auto �6(    5      �� 5      $��* �6+   �� 5      $
��Auto �6+   .+�5!      �� $��0��66   ��6    �� *Name+66   �� 5#      $��1��6!   $��2��61   $ 
Horizontal=�6C   .+�5$      �� $	��5,0q�5'      $��Center=�5(      $��Center=�5)      $
��Auto��5*      $	 
OpenButton��5+      ��5%      �� * DataContext.OpenMessageCommand+$
 
LayoutRoot����5&      �� .��5+   L   
Open Log5-      5.      5/      50      51      �� 53   
   .R�54      �  55      �� 56      $
��Auto �6$   �� 57      $
��Auto �6$   �� 58      $
��Auto �6$   �� 59      $��* �6$    5<      �� 5=      $
��Auto �6'   �� 5>      $��* �6'   .+�5A      �� $��3��6   $��2��6&   ���	#FF0F68A6$��2q�6R   $��5, 10, 5, 0q�6f   ._�5B      �� $��Stretch=�6#   $��Stretch=�6?   $
��Auto=�5C      .��5D      �� $��5q�6=   $
��Wrap=�6H   $	 TextBlockSystemStatusData��6\   ��6$   �� *	Message+6\   5E      5F      5G      5H      5I      .��5K      � -   5         �Name$ 
LayoutRoot��5K      
������� 5L   
   �� 5M      $
��Auto �6   �� 5N      $
��Auto �6   �� 5O      $
��Auto �6   �� 5P      $��* �6   .+�5R   
   �� $��0��6   ._�5S      �� $��Stretch=�6   $��Stretch=�5T      $��5,15,5,5q�5U      $
��Auto=�5V      .��5W      �� $	��Top=�6   $ Vertical=�65   {�.  $
��Left=�6^   .+�5X      �� $��0��6    $��Level Statistics��6-   $��	ExtraBold"�6E   ���#333333$��16(�6q    �� Padding$ 5q�6   �� 5Y      $ 
Horizontal=�6!   .+�5Z      �� ���#616161$��1q�67    �� Padding$ 5q�6K   $��5q�6W   $	��170��6b   $	��250��6o   ._�5[      � $
��Left=�6#   $	��238��6>    5\   "   �� 5]   &   $
��Auto �64   �� 5^   &   $	��120 �64    5`   "   �� 5a   &   $	��180 �67   �� 5b   &   $��60 �67   .+�5d   "   �� -   5         ��Name$ 
txtLvlName��5d   ,   $��0��6@   $��2��6M   $ 5q�6a   $
��Bold"�6m   Overall Status6�   � 5e   "   $��1��6'   $��0��64    5f   &   �� 5g   *   $��* �68   �� 5h   *   $��* �68   �� 5i   *   $��* �68    5k   &   �� 5l   *   $��* �6;   .+�5n   &   �� $��0��6-   $��0��6:   
���   �$��1,1,1,0q�6^   ._�5o   *   ]� .+�5p   .   �� $��Center=�68   $��Center=�6U   $��60��6p    �� TextAlignment$ Center=�6{   ALL6�   �� 5q   .   -   5        $ txtLvlAS��5q   8   $��Stretch=�6J   $��Stretch=�6h   $ Center=�6�   $	��120��6�   ���#616161
��� ���$��26(�6�   06�   5r   +   5s   '   �� 5t   &   $��1��6-   $��0��6:   
���   �$��1,1,1,0q�6^   ._�5u   *   ]� .+�5v   .   �� $��Center=�68   $��Center=�6U   $��60��6p   $ Center=�6{   FREE6�   �� 5w   .   -   5        $ txtLvlFS��5w   8   $��Stretch=�6J   $��Stretch=�6h   $ Center=�6�   $	��120��6�   ���#616161
������$��26(�6�   06�   5x   +   5y   '   �� 5z   &   $��2��6-   $��0��6:   
���   �$��1,1,1,1q�6^   ._�5{   *   ]� .+�5|   .   �� $��Center=�68   $��Center=�6U   $��60��6p   $ Center=�6{   BUSY6�   �� 5}   .   -   5        $ txtLvlBS��5}   8   $��Stretch=�6J   $��Stretch=�6h   $ Center=�6�   $	��120��6�   ���#616161
���  ��$��26(�6�   06�   5~   +   5   '   5�   #   � 5�   "   -   5        $��pbLevel��5�   K   $��2��6.   $��1��6;    � Value$ 0Q�6Z    � Orientation$ Vertical=�6d   $��40��6{   $	��120��6�   $��	10,0,10,0q�6�   �� 5�   "   -   5        $ 
txtPBLevel��5�   ,   $��2��6@   $��1��6M   $��0%��6]   $��Center=�6g   $��Center=�6�   5�      5�      �� 5�      ���#616161$��1q�67   $ 5q�6K   $��5q�6W   ._�5�      �  5�   "   �� 5�   &   $��20 �64   6B   �� 5�   &   $
��Auto �64   6D    5�   "   �� 5�   &   69   .+�5�   "   �� $��0��6,   $��Level Indicator��69   $
��Bold"�6P   ���#333333$��14(�6w   $��Center=�6�   �� 5�   "   -	   5         ��Name$ spLevelController��5�   :   $��1��6-   $	��Top=�6U   $ 
Horizontal=�6m   {�.  $
��Left=�6�   5�   #   5�      5�      5�      5�      5�      5�      �� 5�   
   $��1��6   $��Stretch=�6$   $	��Top=�6B   $��10��6Z    �� ShowsPreview . ��5�      �� 5�       �� 
TargetType" ��6"   .R�5�      � .+�5�      �� $	��⁞��6!   �� 5�      ���#8282826$   5�      5�      5�      �� 5�   
   $��1��6   $	��Top=�6"   $ Vertical=�6:   $��5q�6Q   .+�5�      �� $��Zone Statistics��6   $��	ExtraBold"�6/   ���#333333$��16(�6[   $ 	5,10,0,10q�6i   �� 5�      -
   5         ��Name$ MessagesListBox��5�      #��[ 5�      #��[ 5�      $	 MessagesList��5�      ��5�      �� *
Messages+5�      5�      �� 5�   
   $��2��6   ._�5�      �� $��Stretch=�6   $��Stretch=�5�      $��5,15,5,5q�5�      $
��Auto=�5�      y�5�      �� *Messages.CurrentItem+ �� 	Converter# [  .��5�      �� -   5        $ spZoneController��5�      $	��Top=�67   $ 
Horizontal=�6O   {�.  $
��Left=�6z   6�   5�      5�      5�      5�      