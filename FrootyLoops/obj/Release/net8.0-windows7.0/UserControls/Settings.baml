   M S B A M L   `   `   `  ���� F  BFrootyLoops, Version=0.2.5.0, Culture=neutral, PublicKeyToken=nullC&clr-namespace:FrootyLoops.UserControlsFrootyLoops.UserControls  =#clr-namespace:FrootyLoops.ViewModelFrootyLoops.ViewModel  '    !FrootyLoops.UserControls.Settings   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     S OHandyControl, Version=3.5.2.0, Culture=neutral, PublicKeyToken=45be8712787a1e5b0hc'https://handyorg.github.io/handycontrol  2local&clr-namespace:FrootyLoops.UserControls  Dmc;http://schemas.openxmlformats.org/markup-compatibility/2006  3	viewmodel#clr-namespace:FrootyLoops.ViewModel  $	��960��$	��576��.��� $��0,0,0,32q�  � ColumnDefinitions  �� $	��535 ��� $��2* �.+��� $��0��$	��485��$��
25,25,0,25q�$
��Left=�   
PanelColor#���    �� CornerRadius$ 30��._�'  !HandyControl.Controls.SimplePanel  .+�  $��	0,50,0,70q�.+�(  "HandyControl.Controls.ScrollViewer     IsInertiaEnabled$
 True�� J� IsManipulationEnabled$
 True��$
��Auto=�.��/  )HandyControl.Controls.UniformSpacingPanel  $��
0,20,0,-20q�$��Center=�   Orientation$ Vertical=�   Spacing$ 24Q�.+�	� -    	�Name$ 
UserSetBtn��$��Center=�  SmallSettingsRadioButton#���  .���� $��10,0,0,0q�$
��Left=� �� Orientation$ 
Horizontal=�.+��� $
��Left=�$0��*/Data/Design/Icons/userSettingsOutline.png���� $��8,0,0,0q�$��32(�  TextBlockStyle#���  $��User Settings���� $��	0,0,0,-24q�$
��Left=�$��Bottom=�  DividerColor#���  #���  $��Programs Settings��#  HandyControl.Controls.Divider  $��	0,20,0,12q�#���  	� -   $ ThemeSetBtn��$��Center=�$��Center=�#���  .���� $��10,0,0,0q�$
��Left=�$ 
Horizontal=�.+��� $
��Left=�$)��#/Data/Design/Icons/themeOutline.png���� $��8,0,0,0q�$��32(�#���  $��Theme��	� -   $ 
LangSetBtn��$��Center=�$��Center=�#���  .���� $��10,0,0,0q�$
��Left=�$ 
Horizontal=�.+��� $
��Left=�$,��&/Data/Design/Icons/languageOutline.png���� $��8,0,0,0q�$��32(�#���  $��Language��	� -   $ 
WorkSetBtn��$��Center=�$��Center=�#���  .���� $��10,0,0,0q�$
��Left=�$ 
Horizontal=�.+��� $
��Left=�$-��'/Data/Design/Icons/monitorDashboard.png���� $��8,0,0,0q�$��32(�#���  $��Workzone��	� -   $ 	SysSetBtn��$��Center=�$��Center=�#���  .���� $��10,0,0,0q�$
��Left=�$ 
Horizontal=�.+��� $
��Left=�$,��&/Data/Design/Icons/settingsOutline.png���� $��8,0,0,0q�$��32(�#���  $��System Settings���� $��	0,0,0,-24q�$
��Left=�$��Bottom=�#���  #���  $
��Info��  $��	0,20,0,12q�#���  	� -   $ CLogBtn��$��Center=�$��Center=�#���  .���� $��10,0,0,0q�$
��Left=�$ 
Horizontal=�.+��� $
��Left=�$/��)/Data/Design/Icons/outlineNewReleases.png���� $��8,0,0,0q�$��32(�#���  $��What’s new?��	� -   $ HelpBtn��$��Center=�$��Center=�#���  .���� $��10,0,0,0q�$
��Left=�$ 
Horizontal=�.+��� $
��Left=�$.��(/Data/Design/Icons/helpCircleOutline.png���� $��8,0,0,0q�$��32(�#���  $
��Help��	� -   $ CheckUpdatesBtn��$��Center=�$��Center=�#���  .���� $��10,0,0,0q�$
��Left=�$ 
Horizontal=�.+��� $
��Left=�$'��!/Data/Design/Icons/updateIcon.png���� $��8,0,0,0q�$��32(�#���  $��Check for updates��  $	��274��$��	25,0,0,20q�$
��Left=�$��Bottom=�.+��� -	    ��Name$ ExitFromAccBtn��$	��274��$��40��$��Stretch=�$��Stretch=�  SmallDeclineButton#���  .���� $
��Left=�$��Bottom=�$ 
Horizontal=�.+��� $
��Left=�$��Center=�$3��-/Data/Design/Icons/exitFromAccountRounded.png���� $��8,0,0,0q�$
��Left=�$��Center=�$��24                 (�#���  $��Exit from account���� $��1��$	��400��$��
0,25,25,25q�#���   $ 30��._�� 	 � RowDefinitions	 �� $��96 ��� .+��� -
   $��0��$��64��$��64��$��	0,12,12,0q�$��0,0,0,0q�$��Right=�$	��Top=�
������ $��0q�.��  .+��� $��48��$��48��$��0,0,5,6q�$��Center=�$��Center=�$%��/Data/Design/Icons/backIcon.png��A� $��64��$��64��$��Center=�$��Center=�
������ ���#D9D9D9$��2��� $��1��$
}�True��.+��� -   
 ��Name$
 Content��  $��0��$
��Left=�$
 True��$
 True��$
��Auto=�.���� $��	10,0,0,10q�$	��Top=�!  HandyControl.Controls.Growl   GrowlParent$
 True��   Token$ SettingsErrors�� �� CanVerticallyScroll$
 True��