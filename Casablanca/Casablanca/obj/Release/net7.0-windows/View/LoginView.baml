   M S B A M L   `   `   `  ���� E  ACasablanca, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:Casablanca.ViewCasablanca.View  ;"clr-namespace:Casablanca.ViewModelCasablanca.ViewModel  5clr-namespace:Casablanca.CustomCasablanca.Custom  ;"clr-namespace:Casablanca.ResourcesCasablanca.Resources  =#clr-namespace:Casablanca.ComponentsCasablanca.Components      Casablanca.View.LoginView   W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     /localclr-namespace:Casablanca.View     8	viewModel"clr-namespace:Casablanca.ViewModel     2customclr-namespace:Casablanca.Custom     0p"clr-namespace:Casablanca.Resources     9	component#clr-namespace:Casablanca.Components     -     � Title$  	LoginView��$	��550��$	��800�� � WindowStyle$
 None=� � 
ResizeMode$ NoResize=� � WindowStartupLocation$ CenterScreen=�
������  � AllowsTransparency$
 True�� � DataContext )   #Casablanca.ViewModel.LoginViewModel   � 	Resources    BooleanToVisibility��%   &	        �� y���  �� Path$ IsViewVisible� �� Mode$ TwoWay=�	 �� 	Converter#	 [  .���� 
 �� CornerRadius$
 12������  �� ImageSource$ /Images/back-image.jpg��._��� $
 12��$��2q� J� Opacity$
 0.95Q�����  �� 
StartPoint$	 0,0&� �� EndPoint$	 1,1&�.���  � Color$ White�� � Offset$ 0Q�� $
 Gray��$
 0.75Q�� $ Black��$ 1Q����� $	 0,1&�$	 1,0&�.��� $ White��$ 0Q�� $
 Gray��$ 1Q�._��  � RowDefinitions �� $��30 ��� .+��  � ColumnDefinitions �� �� $��25 ��� $��25 ��� $��5 �.+��� $��LOG IN��
�������$��10(�$��
Montserrat)�$��0��$��Center=�$��10,0,0,0q��� -    ��Name$ btnMinimize��$��0q�$��-��
�������$��16(�$��
Montserrat)� � Cursor$
 Hand��$��1������  �� 
TargetType" ��.���  �� Property � �� �� Value �#278BEF �� Triggers P�  P� Property �@J�IsMouseOver P� Value$
 True��. ���  � �� �#28AEED����  �� 
TargetType" ��.R��� $��18��$��18��$
 9��#��z��._��� $��Center=�$��Center=��� -   $ btnClose��$��0q�$��X��
�������$��16(�$��
Montserrat)�$
 Hand��$��2������ " ��.���  � �� �#e04848 P�  �@J�IsMouseOver$
 True��. ���  � �� �#d10a0a���� " ��.R��� $��18��$��18��$
 9��#��z��._��� $��Center=�$��Center=��� $	��250��$��2�� �� Orientation$ Vertical=�$��0,30,0,0q�.+�4   .Casablanca.Components.LanguageSelectionControl  $��Center=�$��Center=��� $��/Images/Logo.png��$	��100��$	��100���� $��
CASABLANCA��
���   �$��25(�$��Medium"�$��
Montserrat)�$��Center=���  
 Slogan#���  
���   �$��12(�$��Medium"�$��
Montserrat)�$��Center=��� $��Username��
���   �$��12(�$��Medium"�$��
Montserrat)�$��0, 35, 0, 0q��� -    ��Name$ txtUser��$��13(�$��Medium"�$��
Montserrat)����#0004B3
���   �$��0,0,0,1q�$��28��$��Center=�$��0,5,0,0q�$��20,0,0,0q����� *
Username+ �� UpdateSourceTrigger$ PropertyChanged=�.������ $ /Images/user-icon.png�� j� Stretch$
 None=�  j� 
AlignmentX$
  Left=�.���� #   Casablanca.Resources.Language!   Password#��Z! 
���   �$��12(�$��Medium"�$��
Montserrat)�$��0, 15, 0, 0q�+   %Casablanca.Custom.BindablePasswordBox  $��28��$��0,5,0,0q�"   Password" �� *
Password+$ TwoWay=�$ PropertyChanged=��� ���#d10a0a$��12(�$��Medium"�$��
Montserrat)�$��0, 10, 0, 0q�$
��Wrap=����� *ErrorMessage+�� -   $ btnLogin��$��0q�#   LogIn#��Z# 
�������$��16(�$��
Montserrat)�$
 Hand��$��2��$��0,30,0,0q����� *LoginCommand+���� " ��.���  � �� �#0036b3 P�  �@J�IsMouseOver$
 True��. ���  � �� �#0004B3���� " ��.R��� $	��150��$��40��$
 20��#��z��._��� $��Center=�$��Center=�