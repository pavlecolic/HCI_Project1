   M S B A M L   `   `   `  ����E  ACasablanca, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:Casablanca.View.ModalCasablanca.View.Modal  5   	   Q-clr-namespace:Casablanca.ViewModel.EmployeeVMCasablanca.ViewModel.EmployeeVM  5   	   3clr-namespace:Casablanca.UtilsCasablanca.Utils  5   	   -    'Casablanca.View.Modal.AddCustomerDialog   5   	   W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5   	   R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   5local#clr-namespace:Casablanca.View.Modal     5   	   C	viewModel-clr-namespace:Casablanca.ViewModel.EmployeeVM     5   	   /utilclr-namespace:Casablanca.Utils     5   	     � Title$  AddCustomerDialog��5
   	   $	��500��6#   $	��400��60    � DataContext 5      :   4Casablanca.ViewModel.EmployeeVM.AddCustomerViewModel  5   
    � 	Resources 5         BooleanToVisibility��%   &	        �� 5   
   6E   5      y�5      �� 5   
    �� Path$ IsViewVisible�6    �� Mode$ TwoWay=�6'    �� 	Converter# [  65   .��5      � .+�5   
   �� $��10q�6     	dominant1#���  5      .+�5      ��   	firstName#���  6   $��
Montserrat)�5      $��Medium"�5        PrimaryTextBrush#���  5      $��12(�5       $��0,10,0,5q�5!      �� 5"      -   5         ��Name$ FirstNameTextBox��5"      $��13(�5$      $��Medium"�5%      $��
Montserrat)�5&      #���  5'        BorderBrush#���  5(      $��0,0,0,1q�5)      $��28��5*      $��Center=�5+      $��0,5,0,0q�5,      $��20,0,0,0q�5-      ��5#      �� *	FirstName+ �� UpdateSourceTrigger$ PropertyChanged=�5-      �� 5/        lastName#���  6   #���  50      $��
Montserrat)�51      $��Medium"�52      $��12(�53      $��0,10,0,5q�54      �� 55      -   5        $ LastNameTextBox��55      $��0,0,0,10q�56      $��13(�58      $��Medium"�59      $��
Montserrat)�5:      #���  5;      #���  5<      $��0,0,0,1q�5=      $��28��5>      $��Center=�5?      $��20,0,0,0q�5@      ��57      �� *
LastName+$ PropertyChanged=�5@      �� 5B        jmb#���  6   #���  5C      $��
Montserrat)�5D      $��Medium"�5E      $��12(�5F      $��0,10,0,5q�5G      �� 5H      -   5        $ 
JMBTextBox��5H      $��13(�5J      $��Medium"�5K      $��
Montserrat)�5L      #���  5M      #���  5N      $��0,0,0,1q�5O      $��28��5P      $��Center=�5Q      $��20,0,0,0q�5R      ��5I      �� *JMB+$ PropertyChanged=� �� ValidatesOnDataErrors$
 True��	 �� NotifyOnValidationError$
	 True��5R      �� 5U        address#���  6   #���  5V      $��
Montserrat)�5W      $��Medium"�5X      $��12(�5Y      $��0,10,0,5q�5Z      �� 5\      -   5        $ AddressTextBox��5\      $��0,0,0,10q�5]      $��13(�5_      $��Medium"�5`      $��
Montserrat)�5a      #���  5b      #���  5c      $��0,0,0,1q�5d      $��28��5e      $��Center=�5f      $��20,0,0,0q�5g      ��5^      �� *AddressName+$ PropertyChanged=�5g      �� 5h      $��Address Number��6   #���  5i      $��
Montserrat)�5j      $��Medium"�5k      $��12(�5l      $��0,10,0,5q�5m      �� 5n      -   5        $ AddressNumberTextBox��5n      $��13(�5p      $��Medium"�5q      $��
Montserrat)�5r      #���  5s      #���  5t      $��0,0,0,1q�5u      $��28��5v      $��Center=�5w      $��20,0,0,0q�5x      ��5o      �� *AddressNumber+$ PropertyChanged=�$
 True��5x      �� 5z       	 phone#���  6   #���  5{      $��
Montserrat)�5|      $��Medium"�5}      $��12(�5~      $��0,10,0,5q�5      �� 5�      -   5        $ PhoneTexBox��5�      $��0,0,0,10q�5�      $��13(�5�      $��Medium"�5�      $��
Montserrat)�5�      #���  5�      #���  5�      $��0,0,0,1q�5�      $��28��5�      $��Center=�5�      $��20,0,0,0q�5�      ��5�      �� *PhoneNumber+$ PropertyChanged=�5�      �� 5�      ���#d10a0a$��12(�5�      $��Medium"�5�      $��
Montserrat)�5�      $��0, 10, 0, 0q�5�      $
��Wrap=�5�      ��5�      �� *ErrorMessage+5�      �� 5�      
 �� Orientation$
 
Horizontal=�6   $��Right=�62   .+�5�      �� $
��Save��6   #���  5�      $��75��5�      $��5q�5�      ��5�      �� *SaveCommand+5�      �� 5�      $��Cancel��6     	 PrimaryButtonBackgroundBrush#��� 	 5�      #���  5�      $��75��5�      $��5q�5�      ��5�      �� *CancelCommand+5�      5�      5�      5�      