   M S B A M L   `   `   `  ����E  ACasablanca, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:Casablanca.CustomCasablanca.Custom  5   	   ;"clr-namespace:Casablanca.ViewModelCasablanca.ViewModel  5   	   -    'Casablanca.View.Modal.AddEmployeeDialog   5   	   W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5   	   R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   2customclr-namespace:Casablanca.Custom     5   	   8	viewModel"clr-namespace:Casablanca.ViewModel     5   	     � 
ResizeMode$  NoResize=�5   	    � WindowStartupLocation$ CenterScreen=�5   	    � Title$ Add Employee��5   	   $	��500��6   $	��400��6+    � DataContext 5      /   )Casablanca.ViewModel.AddEmployeeViewModel  5   
    � 	Resources 5         BooleanToVisibility��%   &	        �� 5   
   6E   5      y�5      �� 5   
    �� Path$ IsViewVisible�6    �� Mode$ TwoWay=�6'    �� 	Converter# [  65   .��5      � .+�5   
   �� $��10q�6     	dominant1#���  5      .+�5      ��   	firstName#���  6   $��
Montserrat)�5      $��Medium"�5        PrimaryTextBrush#���  5      $��12(�5       $��0,10,0,5q�5!      �� 5"      -   5         ��Name$ FirstNameTextBox��5"      $��13(�5$      $��Medium"�5%      $��
Montserrat)�5&      #���  5(        BorderBrush#���  5)      $��0,0,0,1q�5*      $��28��5+      $��Center=�5,      $��0,5,0,0q�5-      $��20,0,0,0q�5.      ��5#      �� *	FirstName+	 �� UpdateSourceTrigger$	 PropertyChanged=�5.      �� 50        lastName#���  6   #���  51      $��
Montserrat)�52      $��Medium"�53      $��12(�54      $��0,10,0,5q�55      �� 56      -   5        $ LastNameTextBox��56      $��0,0,0,10q�57      $��13(�59      $��Medium"�5:      $��
Montserrat)�5;      #���  5<      #���  5=      $��0,0,0,1q�5>      $��28��5?      $��Center=�5@      $��20,0,0,0q�5A      ��58      �� *
LastName+$	 PropertyChanged=�5A      �� 5C       
 salary#���  6   #���  5D      $��
Montserrat)�5E      $��Medium"�5F      $��12(�5G      $��0,0,0,5q�5H      �� 5I      -   5        $ SalaryTextBox��5I      $��0,0,0,10q�5K      $��13(�5M      #���  5N      $��Medium"�5O      $��
Montserrat)�5P      #���  5Q      $��0,0,0,1q�5R      $��28��5S      $��Center=�5T      $��20,0,0,0q�5U      ��5L      �� *Salary+$	 PropertyChanged=�5U      �� 5W        username#���  6   $��
Montserrat)�5X      #���  5Y      $��Medium"�5Z      $��12(�5[      $��0,0,0,5q�5\      �� 5^      -   5        $ UsernameTextBox��5^      $��0,0,0,10q�5_      $��13(�5a      #���  5b      $��Medium"�5c      $��
Montserrat)�5d      #���  5e      $��0,0,0,1q�5f      $��28��5g      $��Center=�5h      $��20,0,0,0q�5i      ��5`      �� *
Username+$	 PropertyChanged=�5i      �� 5k        password#���  6   #���  5l      $��12(�5m      $��Medium"�5n      $��
Montserrat)�5o      $��0, 15, 0, 0q�5p      +   %Casablanca.Custom.BindablePasswordBox  5r      $��28��5s      #���  5t      $��0,5,0,0q�5u      
   Password
 5r   )   �� *
Password+$ TwoWay=�$	 PropertyChanged=�5v      �� 5x       	 confirmPassword#��� 	 6   #���  5y      $��12(�5z      $��Medium"�5{      $��
Montserrat)�5|      $��0, 15, 0, 0q�5}        5      $��28��5�      #���  5�      $��0,5,0,0q�5�      
 5   )   �� *ConfirmPassword+$ TwoWay=�$	 PropertyChanged=�5�      �� 5�      ���#d10a0a$��12(�5�      $��Medium"�5�      $��
Montserrat)�5�      $��0, 10, 0, 0q�5�      $
��Wrap=�5�      ��5�      �� *ErrorMessage+5�      �� 5�       �� Orientation$ 
Horizontal=�6   $��Right=�62   .+�5�      �� $
��Save��6   #���  5�      $��75��5�      $��5q�5�      ��5�      �� *SaveCommand+5�      �� 5�      $��Cancel��6     
 PrimaryButtonBackgroundBrush#��� 
 5�      #���  5�      $��75��5�      $��5q�5�      ��5�      �� *CancelCommand+5�      5�      5�      5�      