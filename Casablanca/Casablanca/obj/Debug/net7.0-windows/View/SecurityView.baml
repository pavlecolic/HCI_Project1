   M S B A M L   `   `   `  ����E  ACasablanca, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:Casablanca.ViewCasablanca.View  5      5clr-namespace:Casablanca.CustomCasablanca.Custom  5      ;"clr-namespace:Casablanca.ViewModelCasablanca.ViewModel  5	      "    Casablanca.View.SecurityView   5      W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5      R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      /localclr-namespace:Casablanca.View     5      2customclr-namespace:Casablanca.Custom     5      8	viewModel"clr-namespace:Casablanca.ViewModel     5	        � DataContext  5      ,   &Casablanca.ViewModel.SecurityViewModel  5   
    � 	Resources 5       �� 
TargetType   RoundedPasswordBox �� Property �� Value �� 
TargetType �� CornerRadius ��Name  PrimaryTextBrush  color31��%�  &	        �� 5   
   " G�6   .�5      ��  � �� 5      �� 5      " G�6&   .R�5      �� #��z��6!   #��z��5   
   #��z��5   
   $ 5��5   
   ._�5      �� $ PART_ContentHost��66   $��0q�6+   66   5      5      5      �� 5       � ��$ 5q�6(   �� 5        � ��# �  6+   �� 5!       � ��# �  6,   �� 5"       � ��# �  6+   5#      5$      .��5(      �� $	��300��6    �� Orientation$ Vertical=�6   $��0,20,0,0q�64     	dominant1#���  5)   %   .+�5+   
   ��   oldPassword#���  6   #���  5,      $��12(�5-      $��Medium"�5.      $��
Montserrat)�5/      $��0, 15, 0, 0q�50      +   %Casablanca.Custom.BindablePasswordBox  52   
   $��28��53      #���  54      $��0,5,0,0q�55      	   Password	 52   %   �� *CurrentPassword+
 �� Mode$
 TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=�56      �� 58   
     password#���  6   #���  59      $��12(�5:      $��Medium"�5;      $��
Montserrat)�5<      $��0, 15, 0, 0q�5=        5?   
   $��28��5@      #���  5A      $��0,5,0,0q�5B      	 5?   %   �� *NewPassword+$
 TwoWay=�$ PropertyChanged=�5C      �� 5E   
     confirmPassword#���  6   #���  5F      $��12(�5G      $��Medium"�5H      $��
Montserrat)�5I      $��0, 15, 0, 0q�5J        5L   
   $��28��5M      #���  5N      $��0,5,0,0q�5O      	 5L   %   �� *ConfirmNewPassword+$
 TwoWay=�$ PropertyChanged=�5P      �� 5R   
   $
��Save��6   #���  5T      $��75��5U      $��5q�5V      ��5S      �� *ChangePasswordCommand+5V      5W      5Y      