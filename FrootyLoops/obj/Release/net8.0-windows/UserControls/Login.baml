   M S B A M L   `   `   `  ���� G  CFrootyLoops, Version=0.2.11.0, Culture=neutral, PublicKeyToken=nullC&clr-namespace:FrootyLoops.UserControlsFrootyLoops.UserControls  $    FrootyLoops.UserControls.Login   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     S OHandyControl, Version=3.5.2.0, Culture=neutral, PublicKeyToken=45be8712787a1e5b0hc'https://handyorg.github.io/handycontrol  2local&clr-namespace:FrootyLoops.UserControls  Dmc;http://schemas.openxmlformats.org/markup-compatibility/2006  $	��700��$	��350��.��� .+��� $��	0,24,0,32q�$��Center=�.+�/  )HandyControl.Controls.UniformSpacingPanel  $��84��$��0,0,0,16q�$��Center=�    ItemHorizontalAlignment
  Center   ItemVerticalAlignment
 Center   Orientation$ Vertical=�.+�&   HandyControl.Controls.SimpleText  $��Center=�$��Center=�   
FontFamily$@ :./../../../Data/Fonts/HappyMonkey-Regular.ttf#Happy Monkey)�   FontSize$ 48(�   	TextColor   
Foreground# [     Text$ Hello!��  $��Center=�$	��Top=�$@ :./../../../Data/Fonts/HappyMonkey-Regular.ttf#Happy Monkey)�$ 16(�# [  $ Have you met me before?��� $��Center=� � RowDefinitions �� $��40 ��� $��40 ��� $��10 � � ColumnDefinitions �� $��85 ��� $��* �.+��� $��0��$��0��$��Center=�$��Center=�  TextBlockStyle#��[ $��	Username:��#  HandyControl.Controls.TextBox  -   	  Name$	 Username��$��0��$��1��$��Center=�
 �� 	MaxLength$
 45��  TextBoxStyle#��[ �� $��1��$��0��$��Center=�$��Center=�#��[ $��	Password:��  -   $	 Password��$��1��$��1��$��Bottom=�#��[ �� -   $��2��$��1�� �� Padding$ 0,0,0,0q�$��Right=�$��Bottom=�$��8(�#��[ $��We don't know each other?�� � UseLayoutRounding$
 True��  $	��700��$	��110��$��Center=�
  Center
 Center$ 
Horizontal=�   Spacing$ 10Q�.+��� -    ��Name$ 
RememberMe��$	��185��$��60��$��
110,0,0,50q�$��Stretch=�$��Stretch=�$��0q�
 � Tag$ Unactive������  �� 
TargetType" ��.R���  ��Name$ border��
������  �� CornerRadius$ 15��._���  �� Orientation$ 
Horizontal=�.+��� $��64��$��64��$
��Left=�$��Center=�$:��4/Data/Design/Icons/unactiveRememberLoginButtonIc.png��$ Unactive���� $��Center=�$��Center=�$@��:./../../../Data/Fonts/HappyMonkey-Regular.ttf#Happy Monkey)�$��16(�#��[  $��Remember me���� -   $��
90,10,0,60q�$��Here you are!��  SmallAcceptButton#��[ (  "HandyControl.Controls.ScrollViewer  $	��352��$
��Left=�   IsInertiaEnabled$
 True�� J� IsManipulationEnabled$
 True��$
��Auto=�.���� $��	10,0,0,10q�$	��Top=�!  HandyControl.Controls.Growl   GrowlParent$
 True��   Token$ LoginErrors�� �� CanVerticallyScroll$
 True��