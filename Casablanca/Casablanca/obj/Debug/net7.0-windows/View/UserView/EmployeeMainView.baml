   M S B A M L   `   `   `  ����E  ACasablanca, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullC&clr-namespace:Casablanca.View.UserViewCasablanca.View.UserView  5   	   O6clr-namespace:Casablanca.Resources;assembly=CasablancaCasablanca.Resources  5   	   Q-clr-namespace:Casablanca.ViewModel.EmployeeVMCasablanca.ViewModel.EmployeeVM  5   	   =#clr-namespace:Casablanca.ComponentsCasablanca.Components  5	   	   /    )Casablanca.View.UserView.EmployeeMainView   5   	   W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5   	   R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   8local&clr-namespace:Casablanca.View.UserView     5   	   Dp6clr-namespace:Casablanca.Resources;assembly=Casablanca     5   	   C	viewModel-clr-namespace:Casablanca.ViewModel.EmployeeVM     5   	   9	component#clr-namespace:Casablanca.Components     5	   	   X TFontAwesome.Sharp, Version=6.3.0.0, Culture=neutral, PublicKeyToken=d16d1e4e568ec10fFfa=http://schemas.awesome.incremented/wpf/xaml/fontawesome.sharp  5   	     � Title$  EmployeeMainView��5   	   $	��700��5   	   $
��1300��6    � WindowStartupLocation$ CenterScreen=�5   	    � WindowStyle$
 None=�5   	   
������  � AllowsTransparency$
 True��5   	    � DataContext 5      ;   5Casablanca.ViewModel.EmployeeVM.EmployeeMainViewModel  5   
    � 	Resources 5       �� DataType?   9Casablanca.ViewModel.EmployeeVM.ArticlesEmployeeViewModel3   -Casablanca.View.UserView.ArticlesEmployeeView8   2Casablanca.ViewModel.EmployeeVM.CustomersViewModel,   &Casablanca.View.UserView.CustomersView6   0Casablanca.ViewModel.EmployeeVM.RentalsViewModel*   $Casablanca.View.UserView.RentalsView8   2Casablanca.ViewModel.EmployeeVM.NewRentalViewModel(	   "Casablanca.View.UserView.NewRental��%,  (��       5      *, +)(�� 2     5      *, +)(�� d     5!      *, +)(�� �     5%      *, +)�� 5   
   "  6   .R�5        5      �� 5   
   "  6   .R�5        5      �� 5!   
   "  6   .R�5"        5#      �� 5%   
   "  6   .R�5&      	  5'      5)      .��5+      ��  �� CornerRadius$ 12��6   $��2q�5,      ��5-   
   �� 5.       �� 
StartPoint$	 0,0&�6"   	 �� EndPoint$		 1,1&�63   .��5/      �    WinBorderColor2
 � Color#
 �   6    � Offset$ 0Q�6I   � 50        WinBorderColor1#
 �  6   $
 0.75Q�6I   � 51        WinBorderColor3#
 �  6   $ 1Q�6I   52      ._�55   
   �  � ColumnDefinitions 56      �� 57      $	��250 �6#   �� 58      $��* �6#   .+�5;      �� $ 	10,0,0,10��6   $��0��5<      ��5>      �� 5?      $	 0,0&�6*   $	 1,0.7&�6;   .��5@      �   SecondaryBackColor1#
 �  6'   $ 0Q�6U   � 5A        SecondaryBackColor2#
 �  6'   $ 1Q�6U   5B      ._�5E      �� .+�5F      ��  �� Orientation$ 
Horizontal=�6!   $��35��5G   !   $��
15,25,0,40q�5H   !   .+�5J      �� $��/Images/Logo.png��6    $��30��6:   �� 5K      $��
CASABLANCA��6"     PrimaryTextBrush#���  5L   "   $��20(�5M   "   $��
Montserrat)�5N   !   $��Medium"�5O   !   $��	10 10 0 0q�5P   !   5Q      	� 5S        
menuButton#��[ 6"     color30
 � Tag# �  5T   !    d� 	IsChecked$
 TrueY�5U   !   ��5V   !   �� *ShowArticleViewCommand+.��5X      �� $ 
Horizontal=�6%   .+�5Y      !
  FontAwesome.Sharp.IconImage
  �  �FontAwesome.Sharp.IconImageBase`1[[FontAwesome.Sharp.IconChar, FontAwesome.Sharp, Version=6.3.0.0, Culture=neutral, PublicKeyToken=d16d1e4e568ec10f]]   Icon$ CompactDisc=�6+     menuButtonIcon#���  6>   6i   �� 5Z       	 articles#��� 	 6(    
 menuButtonText#��� 
 6J   5[      5\      	� 5^      #��[ 6"     color11# �  5_   "   ��5`   "   �� *ShowCustomerViewCommand+.��5b      �� $ 
Horizontal=�6%   .+�5c      
  $ Users=�6+   #���  68   6c   �� 5d        	customers#���  6(   #��� 
 6K   5e      5f      	� 5h      #��[ 6"   # �  5i   !   ��5j   !   �� *ShowNewRentalView+.��5l      �� $ 
Horizontal=�6%   .+�5m      
  $ TruckRampBox=�6+   #���  6?   6j   �� 5n        	newRental#���  6(   #��� 
 6K   5o      5p      5u      5v      �� 5x      $ 	0,10,10,0��6   $��1��5y      ��5{      �� 5|      $	 1,1&�6*   $		 0,0&�6;   .��5}      � #
 �  6'   $ 0Q�6U   � 5~      #
 �  6'   $ 1Q�6U   5      ._�5�      �  � RowDefinitions 5�      �� 5�      $��25 �6(   �� 5�      $��35 �6(   �� 5�      $��* �6(   .+�5�      �� -   5         ��Name$ pnlControlBar��5�   !   $��0��5�   !   $ 
Horizontal=�5�   !   $��RightToLeft=�5�   !   
������ $��0,0,5,0q�5�   !   $��2��5�   G   .+�5�      �� -   5         ��Name$ btnClose��5�   !     controlButton#���  5�   !     DangerButtonBackgroundBrush# �  5�   !   .��5�      
  $ Xmark=�6+     controlButtonIcon#��[ 68   5�      �� 5�      -   5        $ btnMaximize��5�   !   #���  5�   !    
 color9# �  5�   !   .��5�      
  $ Square=�6+   #��[ 69   5�      �� 5�      -   5        $ btnMinimize��5�   !   #���  5�   !    
 color7# �  5�   !   .��5�      
  $ WindowMinimize=�6+   $��12��6A   #��[ 6L   5�      5�      � 5�      $��1��6   $��2��6(    5�      �� 5�      �� 5�      .+�5�      �� $��0��6%   $ 
Horizontal=�5�   &   $��Center=�5�   &   .+�5�      
  $��20��5�   +   $��20��5�   +     SecondaryTextBrush   
Foreground# �  5�   +   $��	35,0,10,0q�5�   +    5�   +   �� *Icon+5�   +   �� 5�      #���  5�   (   $��16(�5�   (   $��
Montserrat)�5�   (   $��Medium"�5�   (   $��Center=�5�   (   ��5�   (   �� *	Caption+5�   (   5�      �� 5�      $��1��6%   $ 
Horizontal=�5�   %   $��RightToLeft=�5�   %   $��Center=�5�   %   $��0 0 10 0q�5�   %   .+�5�      ��   
iconButton#���  6%     color10# �  5�   %   $��5 0 0 0q�5�   %   ��5�   %   �� *LogOutCommand+.��5�   "   
  $ 	ArrowDown=�6/     iconButtonIcon#��[ 6@   5�      �� 5�      #���  5�   (   $��
Montserrat)�5�   (   $��12(�5�   (   $��Center=�5�   (   ��5�   (   �� * CurrentUserAccount.DisplayName+5�   (   A� 5�      $��35��6&   $��35��62   #���  5�   &   $��2��5�   &   $��	10 0 10 0q�5�   &   ��5�   "   �� 5�   &    �� ImageSource$! /Images/profile-picture.png��61   5�      4   .Casablanca.Components.LanguageSelectionControl  5�      $��Center=�6A   $��Center=�6^   .   (Casablanca.Components.ChangeThemeControl  5�      $��Center=�6;   $��Center=�6X   5�      5�      �� 5�      $��2��5�   %   $��25q�5�   %   ��5�   %   �� *CurrentChildView+5�   %   5�      5�      5�      5�      5�      