   M S B A M L   `   `   `  ����E  ACasablanca, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:Casablanca.ViewCasablanca.View  5   	   ;"clr-namespace:Casablanca.ViewModelCasablanca.ViewModel  5   	   5clr-namespace:Casablanca.CustomCasablanca.Custom  5   	   ;"clr-namespace:Casablanca.ResourcesCasablanca.Resources  5	   	   =#clr-namespace:Casablanca.ComponentsCasablanca.Components  5
   	       Casablanca.View.LoginView   5   	   W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5   	   R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   /localclr-namespace:Casablanca.View     5   	   8	viewModel"clr-namespace:Casablanca.ViewModel     5   	   2customclr-namespace:Casablanca.Custom     5   	   0p"clr-namespace:Casablanca.Resources     5	   	   9	component#clr-namespace:Casablanca.Components     5
   	   -   5          � Title$  	LoginView��5   	   $	��550��6   $	��800��6(    � WindowStyle$
 None=�5   	    � 
ResizeMode$ NoResize=�5   	    � WindowStartupLocation$ CenterScreen=�5   	   
������  � AllowsTransparency$
 True��5   	    � DataContext 5      )   #Casablanca.ViewModel.LoginViewModel  5   
    � 	Resources 5         BooleanToVisibility��%   &	        �� 5   
   6E   5      y�5      �� 5   
    �� Path$ IsViewVisible�6    �� Mode$ TwoWay=�6'   	 �� 	Converter#	 [  65   .��5       �� 
 �� CornerRadius$
 12��6   ��5!   
   �� 5"       �� ImageSource$ /Images/back-image.jpg��6   ._�5$   
   �� $
 12��6   $��2q�5%       J� Opacity$
 0.95Q�5&      ��5(      �� 5)       �� 
StartPoint$	 0,0&�6&    �� EndPoint$	 1,1&�67   .��5*      �  � Color$ White��6#    � Offset$ 0Q�61   � 5+      $
 Gray��6#   $
 0.75Q�60   � 5,      $ Black��6#   $ 1Q�61   5-      ��51      �� 52      $	 0,1&�6&   $	 1,0&�67   .��53      � $ White��6#   $ 0Q�61   � 54      $
 Gray��6#   $ 1Q�60   55      ._�59      �  � RowDefinitions 5:      �� 5;      $��30 �6$   �� 5<      .+�5@      �  � ColumnDefinitions 5A      �� 5B      �� 5C      $��25 �6+   �� 5D      $��25 �6+   �� 5E      $��5 �6+   .+�5H      �� $��LOG IN��6    
�������$��10(�5J       $��
Montserrat)�5K       $��0��5L       $��Center=�5M       $��10,0,0,0q�5N       �� 5O      -   5         ��Name$ btnMinimize��5O      $��0q�5P      $��-��5Q      
�������$��16(�5S      $��
Montserrat)�5T       � Cursor$
 Hand��5U      $��1��5V      ��5X      �� 5Y       �� 
TargetType" ��6$   .�5Z   "   ��  �� Property � �� �� Value �#278BEF6?    �� Triggers 5[   "   P� 5\   &    P� Property �@J�IsMouseOver P� Value$
 True��6E   . �5]   *   ��  � �� �#28AEED6G   5^   '   5`      ��5c      �� 5d       �� 
TargetType" ��6.   .R�5e   "   �� $��18��6)   $��18��64   $
 9��5f   )   #��z��5g   )   ._�5h   &   �� $��Center=�67   $��Center=�5i   7   5j   #   5l      5o      �� 5q      -   5        $ btnClose��5q      $��0q�5s      $��X��5t      
�������$��16(�5v      $��
Montserrat)�5w      $
 Hand��5x      $��2��5y      ��5{      �� 5|      " ��6$   .�5}   "   ��  � �� �#e048486?    5~   "   P� 5   &    �@J�IsMouseOver$
 True��6E   . �5�   *   ��  � �� �#d10a0a6G   5�   '   5�      ��5�      �� 5�      " ��6.   .R�5�   "   �� $��18��6)   $��18��64   $
 9��5�   )   #��z��5�   )   ._�5�   &   �� $��Center=�67   $��Center=�5�   7   5�   #   5�      5�      5�      �� 5�      $	��250��6   $��2��5�       �� Orientation$ Vertical=�5�      $��0,30,0,0q�5�      .+�5�      4   .Casablanca.Components.LanguageSelectionControl  $��Center=�69   $��Center=�6V   �� 5�      $��/Images/Logo.png��6   $	��100��5�      $	��100��6(   �� 5�      $��
CASABLANCA��6    
���   �$��25(�5�       $��Medium"�5�       $��
Montserrat)�5�       $��Center=�5�       �� 5�       
 slogan#���  6    
���   �$��12(�5�       $��Medium"�5�       $��
Montserrat)�5�       $��Center=�5�       �� 5�        username#���  6    
���   �$��12(�5�      $��Medium"�5�      $��
Montserrat)�5�      $��0, 35, 0, 0q�5�      �� 5�      -   5         ��Name$ txtUser��5�      $��13(�5�      $��Medium"�5�      $��
Montserrat)�5�      ���#0004B3
���   �$��0,0,0,1q�5�      $��28��5�      $��Center=�5�      $��0,5,0,0q�5�      $��20,0,0,0q�5�      ��5�      �� *
Username+ �� UpdateSourceTrigger$ PropertyChanged=�.��5�   1   ��5�      �� 5�      $ /Images/user-icon.png��6)    j� Stretch$
 None=�5�   )     j� 
AlignmentX$
  Left=�5�   )   5�      .��5�   .   5�      �� 5�        password#���  6    
���   �$��12(�5�      $��Medium"�5�      $��
Montserrat)�5�      $��0, 15, 0, 0q�5�      +   %Casablanca.Custom.BindablePasswordBox  5�      $��28��5�   1   $��0,5,0,0q�5�   1   !   Password! 5�   1   �� *
Password+$ TwoWay=�$ PropertyChanged=�5�      �� 5�      ���#d10a0a$��12(�5�      $��Medium"�5�      $��
Montserrat)�5�      $��0, 10, 0, 0q�5�      $
��Wrap=�5�      ��5�   $   �� *ErrorMessage+5�      �� 5�      -   5        $ btnLogin��5�   !   $��0q�5�       	 logIn#���  5�      
�������$��16(�5�      $��
Montserrat)�5�      $
 Hand��5�      $��2��5�      $��0,30,0,0q�5�      ��5�      �� *LoginCommand+��5�      �� 5�      " ��6$   .�5�   "   ��  � �� �#0036b36?    5�   "   P� 5�   &    �@J�IsMouseOver$
 True��6E   . �5�   *   ��  � �� �#0004B36G   5�   '   5�      ��5�      �� 5�      " ��6.   .R�5�   "   �� $	��150��6)   $��40��65   $
 20��5�   )   #��z��5�   )   ._�5�   &   �� $��Center=�67   $��Center=�5�   7   5�   #   5�      5�      5�      5�      5�      5�      5      