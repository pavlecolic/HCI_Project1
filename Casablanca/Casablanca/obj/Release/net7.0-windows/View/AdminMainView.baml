   M S B A M L   `   `   `  ���� E  ACasablanca, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:Casablanca.ViewCasablanca.View  O6clr-namespace:Casablanca.Resources;assembly=CasablancaCasablanca.Resources  ;"clr-namespace:Casablanca.ViewModelCasablanca.ViewModel  =#clr-namespace:Casablanca.ComponentsCasablanca.Components  #    Casablanca.View.AdminMainView   W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     /localclr-namespace:Casablanca.View     Dp6clr-namespace:Casablanca.Resources;assembly=Casablanca     8	viewModel"clr-namespace:Casablanca.ViewModel     9	component#clr-namespace:Casablanca.Components     X TFontAwesome.Sharp, Version=6.3.0.0, Culture=neutral, PublicKeyToken=d16d1e4e568ec10fFfa=http://schemas.awesome.incremented/wpf/xaml/fontawesome.sharp    � Title$  AdminMainView��$	��700��$
��1300�� � WindowStartupLocation$ CenterScreen=� � WindowStyle$
 None=�
������  � AllowsTransparency$
 True�� � DataContext -  'Casablanca.ViewModel.AdminMainViewModel   � 	Resources  �� 
TargetType �� Property �� Value    PrimaryButtonBackgroundBrush  PrimaryTextBrush	 �� Triggers
 P� Property P� Value % !PrimaryButtonBackgroundHoverBrush��%  '��       �� " ��.���  � ��$ 5q���  � ��$
 10,5q���  � ��$ 16(���  � ��# �   ��  � ��# �  ��  � ��$ 1q���  � ��$ Stretch=���  � ��$ Center=�	 P� 
 �@J�IsMouseOver$
 True��. ���  � ��# �  .����  �� CornerRadius$ 12��$��2q�����  �� 
StartPoint$	 0,0&� �� EndPoint$	 1,1&�.���   WinBorderColor2 � Color# �   � Offset$ 0Q��   WinBorderColor1# �  $
 0.75Q��   WinBorderColor3# �  $ 1Q�._��  � ColumnDefinitions �� $	��250 ��� $��* �.+��� $ 	10,0,0,10��$��0������ $	 0,0&�$ 1,0.7&�.���   SecondaryBackColor1# �  $ 0Q��   SecondaryBackColor2# �  $ 1Q�._��� .+���  �� Orientation$ 
Horizontal=�$��35��$��
15,25,0,40q�.+��� $��/Images/Logo.png��$��30���� $��
CASABLANCA��#���  $��20(�$��
Montserrat)�$��Medium"�$��	10 10 0 0q�	�   
menuButton#��[  	 color11
 � Tag# � 	 .���� $ 
Horizontal=�.+�!  FontAwesome.Sharp.IconImage  �  �FontAwesome.Sharp.IconImageBase`1[[FontAwesome.Sharp.IconChar, FontAwesome.Sharp, Version=6.3.0.0, Culture=neutral, PublicKeyToken=d16d1e4e568ec10f]]   Icon$ Users=� 
 menuButtonIcon#��� 
 �� #   Casablanca.Resources.Language   	Employees#��Z   menuButtonText#���  	� #��[   color12# �  .���� $ 
Horizontal=�.+�  $ 
TruckField=�#��� 
 ��    	Suppliers#��Z #���  	� #��[   color13# �  .���� $ 
Horizontal=�.+�  $ ParachuteBox=�#��� 
 ��    Invoices#��Z #���  	� #��[   color14# �  .���� $ 
Horizontal=�.+�  $ CompactDisc=�#��� 
 ��    Articles#��Z #���  	� #��[   color15# �  .���� $ 
Horizontal=�.+�  $
 Font=�#��� 
 ��    ArticleTypes#��Z #���  	� #��[ # �  .���� $ 
Horizontal=�.+�  $ Gears=�#��� 
 �� $��Settings��#���  �� $ 	0,10,10,0��$��1������ $	 1,1&�$	 0,0&�.��� # �  $ 0Q�� # �  $ 1Q�._��  �� $
��420* ��� $
��103* � � RowDefinitions �� $��25 ��� $��35 ��� $��* �.+��� -    ��Name$ pnlControlBar��$��0��$ 
Horizontal=�$��RightToLeft=�
������ $��0,0,5,0q�$��2��.+��� -    ��Name$ btnClose��  controlButton#���    DangerButtonBackgroundBrush# �  .��  $ Xmark=�  controlButtonIcon#��[ �� -   $ btnMaximize��#���   
 color9# �  .��  $ Square=�#��[ �� -   $ btnMinimize��#���   
 color7# �  .��  $ WindowMinimize=�$��12��#��[ � $��1��$��2�� �� �� .+��� $��0��$ 
Horizontal=�$��Center=�.+�  $
 Home=�$��20��$��20��  SecondaryTextBrush   
Foreground# �  $��	35,0,10,0q��� $��	Employees��#���  $��16(�$��
Montserrat)�$��Medium"�$��Center=��� $��1��$ 
Horizontal=�$��RightToLeft=�$��Center=�$��0 0 10 0q�.+���   
iconButton#���   
 color1# �  $��5 0 0 0q�.��  $ 	AngleDown=�  iconButtonIcon#��[ �� #��� 	 $��
Montserrat)�$��12(�$��Center=����� * CurrentUserAccount.DisplayName+A� $��35��$��35��#��� 	 $��2��$��	10 0 10 0q�����  �� ImageSource$! /Images/profile-picture.png��