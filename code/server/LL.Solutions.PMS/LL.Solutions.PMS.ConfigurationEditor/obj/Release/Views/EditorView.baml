   M S B A M L   `   `   `  ���� Z  VLL.Solutions.PMS.Infrastructure, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullzVclr-namespace:LL.Solutions.PMS.Infrastructure;assembly=LL.Solutions.PMS.InfrastructureLL.Solutions.PMS.Infrastructure   System.WindowsU;clr-namespace:System.ComponentModel;assembly=System.WindowsSystem.ComponentModel Q9clr-namespace:System.Windows.Data;assembly=System.WindowsSystem.Windows.Data ( $LL.Solutions.PMS.ConfigurationEditor;   5LL.Solutions.PMS.ConfigurationEditor.Views.EditorView   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     Msdk=http://schemas.microsoft.com/winfx/2006/xaml/presentation/sdk     qinfrastructureVclr-namespace:LL.Solutions.PMS.Infrastructure;assembly=LL.Solutions.PMS.Infrastructure     Jcm;clr-namespace:System.ComponentModel;assembly=System.Windows     Jdata9clr-namespace:System.Windows.Data;assembly=System.Windows     .���   � RowDefinitions  �� $��35 ��� $	��150 ��� $��35 ��� $��* ��� $��30 � � ColumnDefinitions �� $
��Auto ��� $��* �.+��� $��0��$��System Configuration��$��	ExtraBold"����	#FFFFFFFF$��16(� �� Padding$ 10q��� -   $��0��$��1��$��12(�$
��Edit�� � Cursor$
 Hand��$��Right=�$��Center=�$��0,0,40,0q�����  �� 
TargetType" ��.R��� �� ����  �� 
TargetType" ��.���  �� Property � �� �� Value
 ����� �� Triggers P� 	 P� Property	 �@J�IsMouseOver
 P� Value
 . . ���  � ��
 �  ���� -   $��0��$��1��$��12(�$
��Save��$
 Hand��$��Right=�$��Center=�$��0,0,10,0q����� " ��.R��� �� ���� " ��.���  � ��
 ����� P� 	 �@J�IsMouseOver
 . . ���  � ��
 �  ���� $��1��$��2��$��5, 10, 5, 0q�._��� $��Stretch=�$��Stretch=�$
��Auto=�.��� -    �Name$ gridMain��$��Stretch=�$��Stretch=�$��5q�{�.   �� $	��200 ��� $��* �  �� $��* ��� $��* ��� $��* ��� $��* ��� $��* �.+��� $��0��$��0��
��������� $��0��$��0��
�������.��	Server IP�� -    ��Name$ txtServerIP��$��0��$��1��
�������$��1q��� $��1��$��0���� $��1��$��0��
�������$��1,0,0,0q�.��	Port No�� -   $ txtPortNumber��$��1��$��1��
�������$��1,0,1,0q��� $��2��$��0��
��������� $��2��$��0��
�������.��Main Controller IP�� -   $ txtControllerIP��$��2��$��1��
�������$��1q��� $��3��$��0���� $��3��$��0��
�������$��1,0,0,0q�.��Total Spaces�� -   $ txtTotalSpace��$��3��$��1��
�������$��1,0,1,0q��� $��4��$��0��
��������� $��4��$��0��
�������.��Total Levels�� -   $ txtTotalLevels��$��4��$��1��
�������$��1q��� $��2��$��Level Configuration��$��	ExtraBold"����	#FFFFFFFF$��16(�$ 10q��� -	    ��Name$ btnLevel��{�.  $��2��$��1��$��12(�$��	Add Level��$
 Hand��$��Right=�$��Center=�$��0,0,10,0q����� " ��.R��� �� ���� " ��.���  � ��
 ����� P� 	 �@J�IsMouseOver
 . . ���  � ��
 �  ���� $��3��$��2��$��5, 10, 5, 0q�._��� $��Stretch=�$��Stretch=�$
��Auto=�.���� -
    ��Name$ spLevelContoller�� �� Orientation$ Vertical=�{�.  �� $��4��$��2��
�������$��1q����#828282$	��200��$��5,0,5,5q�._�]� .+��� -    ��Name$ sbMain��$��Bottom=����	#FFFFAC42
������ ���� .R��  �� $	��200 ��� $
��Auto ��� $��* ��� $
��Auto ��� $	��100 �.@��� .���� -   $��	lblMethod���� $��1���� $��2��.���� -   $��	lblAction���� $��3���� $��4��.��� -   $��pbMain�� � Value$ 0Q�$��90��$��16��