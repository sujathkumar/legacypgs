   M S B A M L   `   `   `  ���� _  [LL.Solutions.PMS.ConfigurationEditor, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullg8clr-namespace:LL.Solutions.PMS.ConfigurationEditor.Views*LL.Solutions.PMS.ConfigurationEditor.Views  @    :LL.Solutions.PMS.ConfigurationEditor.Views.LevelController   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     Jlocal8clr-namespace:LL.Solutions.PMS.ConfigurationEditor.Views     -   $��LController��.��9� $��Configuration Details��  9� 
IsExpanded  . .���� 
�������$��1q�._�� $��5q� � ColumnDefinitions �� $	��200 ��� $��* � � RowDefinitions �� $��* ��� $��* ��� $��* ��� $��* ��� $��* ��� $��* ��� $��* �.+��� $��0��$��0��
��������� $��0��$��0��
�������.��Level Controller No�� -    ��Name$ txtLevelControllerNumber��$��0��$��1��
�������$��1q��� $��1��$��0���� $��1��$��0��
�������$��1,0,0,0q�.��Level Controller IP�� -   $ txtLevelControllerIP��$��1��$��1��
�������$��1,0,1,0q��� $��2��$��0��
��������� $��2��$��0��
�������.��Level Spaces�� -   $ txtLevelSpaces��$��2��$��1��
�������$��1q��� $��3��$��0���� $��3��$��0��
�������$��1,0,0,0q�.��Level Zones�� -   $ txtTotalZones��$��3��$��1��
�������$��1,0,1,0q��� $��4��$��0��
��������� $��4��$��0��
�������.��Level Detectors�� -   $ txtLevelDetectors��$��4��$��1��
�������$��1q��� $��5��$��2��$��5, 10, 5, 0q�._��� $��Stretch=�$��Stretch=�$
��Auto=�.���� -    ��Name$ spZoneContoller�� �� Orientation$ Vertical=��� -    ��Name$ btnZone��$��6��$��1��$��12(�$��Add Zone�� � Cursor$
 Hand��$��Right=�$��Center=�$��0,0,10,0q�����  �� 
TargetType" ��.R��� �� ���� 	 �� 
TargetType"	 ��.��� 
 �� Property
 � �� �� Value
 �   � �� Triggers P�  P� Property �@J�IsMouseOver P� Value . . ��� 
 � ��
 �  ��