   M S B A M L   `   `   `  ����E  ACasablanca, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:Casablanca.ViewCasablanca.View  5      ;"clr-namespace:Casablanca.ViewModelCasablanca.ViewModel  5      3clr-namespace:Casablanca.UtilsCasablanca.Utils  5      "    Casablanca.View.SettingsView   5      W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5      R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      /localclr-namespace:Casablanca.View     5      8	viewModel"clr-namespace:Casablanca.ViewModel     5      0utilsclr-namespace:Casablanca.Utils     5        � DataContext  5      ,   &Casablanca.ViewModel.SettingsViewModel  5   
    � 	Resources 5         PrimaryBackgroundColor  PrimaryBackground �� Color  SecondaryBackgroundColor  SecondaryBackground  PrimaryTextColor  PrimaryText  ButtonBackgroundColor  ButtonBackground  ButtonHoverBackgroundColor 	 ButtonHoverBackground 
 ButtonForegroundColor  ButtonForeground �� 
TargetType  RoundedTextBox �� Property �� Value �� 
TargetType �� CornerRadius ��Name  PrimaryTextBrush  color31��%r  &	        &	      &	 4     &	 N     &	 h     &	
 �     &	 �     �� 5   
   # �  69   �� 5   
   # �  6;   �� 5   
   # �  63   �� 5   
   # �  68   �� 5   
   # � 	 6=   �� 5   
   # �  68   �� 5   
   " ��6   .�5      ��  � �� 5      �� 5      " ��6&   .R�5      �� #��z��6!   #��z��5      #��z��5      $ 5��5       ._�5!      �� $ PART_ContentHost��66   $��0q�6+   66   5"      5#      5%      �� 5&       � ��$ 5q�6(   �� 5'       � ��# �  6+   �� 5(       � ��# �  6,   �� 5)       � ��# �  6+   5*      5,      .��5.      ��   WindowBackgroundBrush#��[ 6   	 �� Padding$	 20q�6A   $ 10��6N   ._�5/   
   �� 
 �� Orientation$
 Vertical=�6   $��Center=�6,   $��Center=�6I   $	��300��6d   .+�52      �� $��User Settings��6   $��20(�6-   $
��Bold"�6;   #��[ 53      $��0,0,0,20q�6G    �� TextAlignment$ Center=�6Y   �� 56      $
 Vertical=�6   $��0,0,0,10q�60   .+�57      �� $��Username��6   #��[ 6,   $��5q�6[   �� 59      $	��280��6Y   #��[ 5:      ��59      �� *
Username+ �� UpdateSourceTrigger$ PropertyChanged=�5:      5;      �� 5@      $
 Vertical=�6   $��0,0,0,10q�60   .+�5A      �� $��
First Name��6   #��[ 6.   $��5q�6]   �� 5B      $	��280��6Z   #��[ 5C      ��5B      �� *	FirstName+$ PropertyChanged=�5C      5D      �� 5G      $
 Vertical=�6   $��0,0,0,20q�60   .+�5H      �� $��	Last Name��6   #��[ 6-   $��5q�6\   �� 5I      $	��280��6Y   #��[ 5J      ��5I      �� *
LastName+$ PropertyChanged=�5J      5K      �� 5N      $
��Save��6   $	��120��6$   $��Center=�60   $	��8,4q�6M   $
��Bold"�6[      PrimaryButtonBackgroundBrush#��[ 5O        color16#��[ 6P   #��[ 5P      $��1q�6<   ��5Q      �� *SaveCommand+��5R      �� 5S      " ��6   .�5T      ��  � ��# [ 67    �� Triggers 5U      P� 5V       P� Property �@J�IsMouseOver P� Value$
 True��6=   . �5W   "   ��  � �� % !PrimaryButtonBackgroundHoverBrush# [ 6?   5X      5Z      5\      5]      5^      5_      