   M S B A M L   `   `   `  ����   LL.Solutions.PMS    LL.Solutions.PMS.Login   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     -     �Name$  LoginWindow�� � WindowStartupLocation$ CenterScreen=� � SizeToContent$ WidthAndHeight=����#FFFFFF � Title$	 PMS��$	��300��$	��300�� � WindowStyle$
 None=� � 	Resources  �� MergedDictionaries �� Source��  �� $ ResourceDictionary.xaml?�%    .��� -    �Name$ 
LayoutRoot��	 � ColumnDefinitions	 �� $��* �
 � RowDefinitions
 �� $��* �.+���    BlueTileBrush#��[  $��1q���  �� Orientation$ Vertical=�$��105,100,35,50q�.+��� $ 
Horizontal=�$��10q�.+��� $��	User Name��$	��100���� -    ��Name$ txtUserName��$	��250��.���� $ 
Horizontal=�$��10q�.+��� $��Password��$	��100��G� -    G�Name$ txtPassword��$	��250�� G� 	MaxLength$ 10�� G� PasswordChar$ *���� $ 
Horizontal=�$��10q�$��Center=�.+��� -    ��Name$ btnLogin�� �� 	IsDefault . $��30,2,2,2q�.���� $ 
Horizontal=�.+��� $��../Images/icon_login.png��$��30���� $��Center=�Login�� -   $ 	btnCancel�� �� IsCancel . $��2q�.���� $ 
Horizontal=�.+��� $��../Images/icon_cancel.png��$��30���� $��Center=�Cancel�� $ 
Horizontal=�$��Center=�.+��� -    ��Name$ lblError��
���  ���� $��..\Images\ll.png��$��493,140,29,-115q�$��70���� $��
LIQUIDPARK��$��40(�$��217,-88,134,253q����#00004B�� $��..\Images\lp.png��$��27,-75,495,108q�$��70���� $+��%Copyright Liquid Lab Infosystems 2016��$��	1,319,1,1q�