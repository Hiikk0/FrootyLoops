   M S B A M L   `   `   `  ���� F  BFrootyLoops, Version=0.2.5.0, Culture=neutral, PublicKeyToken=nullc6clr-namespace:FrootyLoops.UserControls.SettingsContent(FrootyLoops.UserControls.SettingsContent  5    /FrootyLoops.UserControls.SettingsContent.Update   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     S OHandyControl, Version=3.5.2.0, Culture=neutral, PublicKeyToken=45be8712787a1e5b0hc'https://handyorg.github.io/handycontrol  Blocal6clr-namespace:FrootyLoops.UserControls.SettingsContent  Dmc;http://schemas.openxmlformats.org/markup-compatibility/2006  $	��400��$	��400��.���   � RowDefinitions  �� $
��Auto ��� $
��Auto ��� $
��Auto �.+�'  !HandyControl.Controls.SimplePanel  $��
10,10,10,0q�$��0��.+��� $
��Left=�   TextBlockStyle#��[  $��Current version: ��  $��
10,10,10,0q�$��1��.+��� $
��Left=�#��[  $��Available version: ��� $��
10,10,10,0q�$��2�� � ColumnDefinitions �� $
��Auto ��� $
��Auto �.+���   SmallAcceptButton#��[ $	��165��$
��Left=�.��,  &HandyControl.Controls.SimpleStackPanel     Orientation$ 
Horizontal=�.+��� $��40��$
��Left=�$'��!/Data/Design/Icons/updateIcon.png���� $
��Left=�$��Center=�#��[  $��Check for update��$��10,0,0,0q��� -   #��[ $��1��$
��Left=�$	��205��$��10,0,0,0q�.��  $ 
Horizontal=�.+��� $��40��$
��Left=�$.��(/Data/Design/Icons/installUpdateIcon.png���� $
��Left=�$��Center=�#��[  $��Load and install update��$��10,0,0,0q�