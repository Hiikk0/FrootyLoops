   M S B A M L   `   `   `  ���� F  BFrootyLoops, Version=0.2.5.0, Culture=neutral, PublicKeyToken=nullc6clr-namespace:FrootyLoops.UserControls.SettingsContent(FrootyLoops.UserControls.SettingsContent  ;    5FrootyLoops.UserControls.SettingsContent.UserSettings   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     S OHandyControl, Version=3.5.2.0, Culture=neutral, PublicKeyToken=45be8712787a1e5b0hc'https://handyorg.github.io/handycontrol  Blocal6clr-namespace:FrootyLoops.UserControls.SettingsContent  Dmc;http://schemas.openxmlformats.org/markup-compatibility/2006  $	��400��$	��400��.��,  &HandyControl.Controls.SimpleStackPanel  .+�(  "HandyControl.Controls.ScrollViewer  $	��330��$
��True��$��Visible=�    IsInertiaEnabled$
  True�� J� IsManipulationEnabled$
 True��$
��Auto=�.��  $��Center=�$
 True��$
��True��.+��� $��
10,10,0,10q�$
��Left=�$��18(�   TextBlockStyle#��[  $.��(Here you can set your personal settings.��� $	��100��$	��400��$	��457��$��0,0,0,10q�$
��Left=�$	��Top=�$��Bottom=� � ColumnDefinitions �� $	��110 ��� $
��Auto �$	��100��$	��200���� $
��Auto � � RowDefinitions �� $
��Auto �.+�)  #HandyControl.Controls.ImageSelector  -     Name$ UserPic��$	��100��$	��100��$��Right=�$	��Top=�)  #HandyControl.Controls.BorderElement   CornerRadius$ 50��   
DefaultExt$  /Data/Design/Pics/Pic1.jpg��   Stretch$ UniformToFill=�#  HandyControl.Controls.TextBox  -     Name$ Username��$��1��$��32��$	��145��$��5,0,3,0q�$��Stretch=�$��Center=�$?��9./../../../Data/Fonts/Sansation_Light.ttf#Sansation Light)�$��24(�	 �� 	MaxLength$	 45��  TextBoxStyle#��[ $��Username���� $��2��$��64��$��64��$��2,0,0,0q�$
��Left=�
������ $��0q�.���� $��56��$��56��$,��&/Data/Design/Icons/settingsOutline.png���� $��2��$��64��$��64��$��73,0,0,0q�$
��Left=�
������ $��0q�.���� $��56��$��56��$.��(/Data/Design/Icons/helpCircleOutline.png��$
��None=�
 �� StretchDirection$
 DownOnly=�� $��10,0,0,0q�$
��Left=� �� �� �� ��  �� $
��Auto ��� $
��Auto �.+��� $��0��$��0��$��Center=�$��18(�#��[  $��Email��  -   $ 	UserEmail��$��0��$��1��$	��280��$��32��$��	5,10,5,10q�$
��Left=�$��Center=�$?��9./../../../Data/Fonts/Sansation_Light.ttf#Sansation Light)�$��24(�#��[ $��Email���� $��1��$��0��$��Center=�$��18(�#��[  $��Password��  -   $ UserPassword��$��1��$��1��$	��280��$��32��$��	5,10,5,10q�$��Center=�$?��9./../../../Data/Fonts/Sansation_Light.ttf#Sansation Light)�$��24(�#��[ $��Password���� $��2��$��0��$��95��$��Center=�$��18(�$
��True��$��Visible=�#��[  $��New Password��$
��Wrap=�  -   $ NewPassword��$��2��$��1��$	��280��$��32��$��	5,10,5,10q�$��Center=�$?��9./../../../Data/Fonts/Sansation_Light.ttf#Sansation Light)�$��24(�${�False��#��[ $��Password���� $��3��$��0��$��95��$��Center=�$��18(�$
��True��$��Visible=�#��[  $��Password Hint��$
��Wrap=�  -   $ UserPasswordHint��$��3��$��1��$	��280��$��32��$��	5,10,5,10q�$��Center=�$?��9./../../../Data/Fonts/Sansation_Light.ttf#Sansation Light)�$��24(�#��[ $��PasswordHint���� -     SmallDeclineButton#��[ $	��400��$��	0,20,0,20q�.���� $��16(�#��[  $��DELETE ACCOUNT��'  !HandyControl.Controls.SimplePanel  $��45��$��0,0,0,20q�$��Center=�$��Bottom=�.+��� -    ��Name$ CancelButton��$	��100��$
��Left=�$��Center=�$
��Left=�$��Cancel��#��[ �� -	   $ AcceptButton��$	��100��$��	270,0,0,0q�$
��Left=�$��Center=�$��Right=�$��Accept!��  SmallAcceptButton#��[ 