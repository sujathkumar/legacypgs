   M S B A M L   `   `   `  ����  LL.Solutions.PMS    LL.Solutions.PMS.Login   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      -   5          �Name$  LoginWindow��5   *    � WindowStartupLocation$ CenterScreen=�5       � SizeToContent$ WidthAndHeight=�6*   ���#FFFFFF � Title$	 PMS��5      $	��300��6   $	��300��6     � WindowStyle$
 None=�60    � Icon$ ../Images/cgslogo.png��5       � 	Resources 5
       �� MergedDictionaries �� Source�� 5   
    5      �� 5      $ ResourceDictionary.xaml?�6%   %    5      .��5      � -   5        	 �Name$	 
LayoutRoot��5      
 � ColumnDefinitions
 5   
   �� 5      $��* �6    � RowDefinitions 5   
   �� 5      $��* �6   .+�5   
   ��    BlueTileBrush#��[  6   $��1q�6<   �� 5   
    �� Orientation$ Vertical=�6   $��105,100,35,50q�6,   .+�5      �� $ 
Horizontal=�6   $��10q�62   .+�5      �� $��	User Name��6   $	��100��6-   �� 5      -   5         ��Name$ txtUserName��5      $	��250��6/   .��6;   5       5!      �� 5"      $ 
Horizontal=�6   $��10q�62   .+�5#      �� $��Password��6   $	��100��6,   G� 5$      -   5         G�Name$ txtPassword��5$      $	��250��63    G� 	MaxLength$ 10��6?    G� PasswordChar$ *��6N   6a   5%      �� 5&      $ 
Horizontal=�6   $��10q�62   $��Center=�6>   .+�5'      �� -   5         ��Name$ btnLogin��5'       �� 	IsDefault . $��30,2,2,2q�6<   .��5(      �� $ 
Horizontal=�6!   .+�5)      �� $��../Images/icon_login.png��6    $��30��6B   �� 5*      $��Center=�6$   Login6F   5+      5,      �� 5-      -   5        $ 	btnCancel��5-       �� IsCancel . $��2q�6<   .��5.      �� $ 
Horizontal=�6!   .+�5/      �� $��../Images/icon_cancel.png��6    $��30��6C   �� 50      $��Center=�6$   Cancel6G   51      52      53      �� 54      $ 
Horizontal=�6   $��Center=�62   .+�55      �� -   5         ��Name$ lblError��55      
���  ��6+   56      57      �� 58   
   $��..\Images\ll.png��6   $��493,140,29,-115q�6*   $��70��6C   �� 5:   
   $��
LIQUIDPARK��6   $��40(�6%   $��217,-88,134,253q�63   ���#00004B6L   �� 5;   
   $��..\Images\lp.png��6   $��27,-75,495,108q�6*   $��70��6B   �� 5<   
   $+��%Copyright Liquid Lab Infosystems 2016��6   $��	1,319,1,1q�6@   5=      5>      