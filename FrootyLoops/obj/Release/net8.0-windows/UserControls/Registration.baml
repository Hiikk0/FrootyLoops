   M S B A M L   `   `   `  ���� G  CFrootyLoops, Version=0.2.11.0, Culture=neutral, PublicKeyToken=nullC&clr-namespace:FrootyLoops.UserControlsFrootyLoops.UserControls  +    %FrootyLoops.UserControls.Registration   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     S OHandyControl, Version=3.5.2.0, Culture=neutral, PublicKeyToken=45be8712787a1e5b0hc'https://handyorg.github.io/handycontrol  2local&clr-namespace:FrootyLoops.UserControls  Dmc;http://schemas.openxmlformats.org/markup-compatibility/2006  $	��700��$	��400��.��� $��	0,24,0,32q�.+��� $��Center=�.+�/  )HandyControl.Controls.UniformSpacingPanel  $��84��$��0,0,0,16q�$��Center=�$��Center=�    ItemHorizontalAlignment
  Center   ItemVerticalAlignment
 Center   Orientation$ Vertical=�.+�&   HandyControl.Controls.SimpleText  $��Center=�$��Center=�   
FontFamily$@ :./../../../Data/Fonts/HappyMonkey-Regular.ttf#Happy Monkey)�   FontSize$ 48(�   	TextColor   
Foreground# [     Text$ Welcome to FL!��  $��Center=�$	��Top=�$@ :./../../../Data/Fonts/HappyMonkey-Regular.ttf#Happy Monkey)�$ 16(�# [  $ Let's be friends!��� .+�� $��Center=� � RowDefinitions �� $��43 ��� $��43 ��� $��43 ��� $��43 � � ColumnDefinitions �� $��85 ��� $��* �.+��� $��0��$��0��$��Center=�  TextBlockStyle#��[ $��	Username:��#  HandyControl.Controls.TextBox  -   	  Name$	 Username��$��0��$��1��$��Center=�  TextBoxStyle#��[ �� $��1��$��0��$��Center=�#��[ $��	Password:��  -   $	 Password��$��1��$��1��$��Center=�#��[ �� $��2��$��0��$��Center=�#��[ $��E-Mail:��  -   $	 EMail��$��2��$��1��$��Center=�#��[ �� $��3��$��0��$
��Left=�$��Center=�#��[ $��Password Hint:��
 �� TextAlignment$
 Center=�$
��Wrap=�  -   $
	 Hint��$��3��$��1��$��Center=�#��[   $	��700��$��80��$��Bottom=�
  Center
 Center$ 
Horizontal=�   Spacing$ 65Q�.+��� -   $��90,0,0,0q�$��Center=�$��Center=�$��Oh, I remembered my name!��  SmallDeclineButton#��[ �� -   $
��Left=�$	��Top=�$��Complete registration!��  SmallAcceptButton#��[ (  "HandyControl.Controls.ScrollViewer  $	��352��$
��Left=�   IsInertiaEnabled$
 True�� J� IsManipulationEnabled$
 True��$
��Auto=�.���� $��	10,0,0,10q�$	��Top=�!  HandyControl.Controls.Growl   GrowlParent$
 True��   Token$ RegistrationErrors�� �� CanVerticallyScroll$
 True��