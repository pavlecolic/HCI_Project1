   M S B A M L   `   `   `  ����E  ACasablanca, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:Casablanca.ViewCasablanca.View  5   	   O6clr-namespace:Casablanca.Resources;assembly=CasablancaCasablanca.Resources  5   	   ;"clr-namespace:Casablanca.ViewModelCasablanca.ViewModel  5   	   =#clr-namespace:Casablanca.ComponentsCasablanca.Components  5	   	   #    Casablanca.View.AdminMainView   5   	   W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5   	   R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   /localclr-namespace:Casablanca.View     5   	   Dp6clr-namespace:Casablanca.Resources;assembly=Casablanca     5   	   8	viewModel"clr-namespace:Casablanca.ViewModel     5   	   9	component#clr-namespace:Casablanca.Components     5	   	   X TFontAwesome.Sharp, Version=6.3.0.0, Culture=neutral, PublicKeyToken=d16d1e4e568ec10fFfa=http://schemas.awesome.incremented/wpf/xaml/fontawesome.sharp  5   	     � Title$  AdminMainView��5   	   $	��700��6   $
��1300��6,    � WindowStartupLocation$ CenterScreen=�5   	    � WindowStyle$
 None=�5   	   
������  � AllowsTransparency$
 True��5   	    � DataContext 5      -  'Casablanca.ViewModel.AdminMainViewModel  5   
    � 	Resources 5       �� DataType-   'Casablanca.ViewModel.EmployeesViewModel*   $Casablanca.View.DisplayEmployeesView-   'Casablanca.ViewModel.SuppliersViewModel#   Casablanca.View.SuppliersView*   $Casablanca.ViewModel.CitiesViewModel    Casablanca.View.CitiesView,   &Casablanca.ViewModel.ArticlesViewModel)	   #Casablanca.View.DisplayArticlesView/
   )Casablanca.ViewModel.ArticleTypeViewModel%   Casablanca.View.ArticleTypeView,   &Casablanca.ViewModel.SettingsViewModel"   Casablanca.View.SettingsView,   &Casablanca.ViewModel.SecurityViewModel"   Casablanca.View.SecurityView��%  (��       5      *, +)(�� 2     5      *, +)(�� d     5!      *, +)(�� �     5$      *, +)(�� �     5'      *,
 +)(�� �     5*      *, +)(�� ,    5.      *, +)�� 5   
   "  6   .R�5        5      �� 5   
   "  6   .R�5        5       �� 5!   
   "  6   .R�5"        5#      �� 5$   
   "  6   .R�5%      	  5&      �� 5'   
   " 
 6   .R�5(        5)      �� 5*   
   "  6   .R�5+        5,      �� 5.   
   "  6   .R�5/        50      52      .��55      ��  �� CornerRadius$ 12��6   $��2q�56   	   ��58   
   �� 59       �� 
StartPoint$	 0,0&�6"   	 �� EndPoint$		 1,1&�63   .��5:      �    WinBorderColor2
 � Color#
 �   6    � Offset$ 0Q�6I   � 5;        WinBorderColor1#
 �  6   $
 0.75Q�6I   � 5<        WinBorderColor3#
 �  6   $ 1Q�6I   5=      ._�5@   
   �  � ColumnDefinitions 5A      �� 5B      $	��250 �6#   �� 5C      $��* �6#   .+�5F      �� $ 	10,0,0,10��6   $��0��5G      ��5I      �� 5J      $	 0,0&�6*   $	 1,0.7&�6;   .��5K      �   SecondaryBackColor1#
 �  6'   $ 0Q�6U   � 5L        SecondaryBackColor2#
 �  6'   $ 1Q�6U   5M      ._�5P      �� .+�5Q      ��  �� Orientation$ 
Horizontal=�6!   $��35��5R   !   $��
15,25,0,40q�5S   !   .+�5T      �� $��/Images/Logo.png��6    $��30��6:   �� 5U      $��
CASABLANCA��6$     PrimaryTextBrush#���  5V   $   $��20(�5W   $   $��
Montserrat)�5X   $   $��Medium"�5Y   $   $��	10 10 0 0q�5Z   $   5[      	� 5]        
menuButton#��[ 6"     color11
 � Tag# �  5^   "    d� 	IsChecked$
 TrueY�5_   "   ��5`   "   �� *ShowEmployeeViewCommand+.��5b      �� $ 
Horizontal=�6%   .+�5c      !  FontAwesome.Sharp.IconImage  �  �FontAwesome.Sharp.IconImageBase`1[[FontAwesome.Sharp.IconChar, FontAwesome.Sharp, Version=6.3.0.0, Culture=neutral, PublicKeyToken=d16d1e4e568ec10f]]   Icon$ Users=�6+     menuButtonIcon#���  68   6c   �� 5d       	 	employees#��� 	 6(    
 menuButtonText#��� 
 6K   5e      5f      	� 5h      -   5        #��[ 5h   "     color30# �  5i   "   ��5j   "   �� *ShowSupplierViewCommand+.��5l      �� $ 
Horizontal=�6%   .+�5m        $ 
TruckField=�6+   #���  6=   6h   �� 5n        	suppliers#���  6(   #��� 
 6K   5o      5p      	� 5r      #��[ 6"     color13# �  5s   "   ��5t   "   �� *ShowCitiesViewCommand+.��5v      �� $ 
Horizontal=�6%   .+�5w        $
 City=�6+   #���  67   6b   �� 5x       
 cities#���  6(   #��� 
 6H   5y      5z      	� 5}      #��[ 6"     color14# �  5~   "   ��5   "   �� *ShowArticleViewCommand+.��5�      �� $ 
Horizontal=�6%   .+�5�        $ CompactDisc=�6+   #���  6>   6i   �� 5�        articles#���  6(   #��� 
 6J   5�      5�      	� 5�      #��[ 6"     color15# �  5�   "   ��5�   "   �� *ShowArticleTypeViewCommand+.��5�      �� $ 
Horizontal=�6%   .+�5�        $
 Font=�6+   #���  67   6b   �� 5�        articleTypes#���  6(   #��� 
 6N   5�      5�      	� 5�      #��[ 6"   # �  5�   "   ��5�   "   �� *ShowSettingsViewCommand+.��5�      �� $ 
Horizontal=�6%   .+�5�        $ Gears=�6+   #���  68   6c   �� 5�        settings#���  6(   #��� 
 6J   5�      5�      	� 5�      #��[ 6"   # �  5�   "   ��5�   "   �� *ShowSecurityViewCommand+.��5�      �� $ 
Horizontal=�6%   .+�5�        $	 Key=�6+   #���  66   6a   �� 5�        security#���  6(   #��� 
 6J   5�      5�      5�      5�      �� 5�      $ 	0,10,10,0��6   $��1��5�      ��5�      �� 5�      $	 1,1&�6*   $		 0,0&�6;   .��5�      � #
 �  6'   $ 0Q�6U   � 5�      #
 �  6'   $ 1Q�6U   5�      ._�5�      �  � RowDefinitions 5�      �� 5�      $��25 �6(   �� 5�      $��35 �6(   �� 5�      $��* �6(   .+�5�      �� -   5         ��Name$ pnlControlBar��5�   !   $��0��5�   !   $ 
Horizontal=�5�   !   $��RightToLeft=�5�   !   
������ $��0,0,5,0q�5�   !   $��2��5�   G   .+�5�      �� -   5         ��Name$ btnClose��5�   !     controlButton#���  5�   !     DangerButtonBackgroundBrush# �  5�   !   .��5�        $ Xmark=�6+     controlButtonIcon#��[ 68   5�      �� 5�      -   5        $ btnMaximize��5�   !   #���  5�   !    
 color9# �  5�   !   .��5�        $ Square=�6+   #��[ 69   5�      �� 5�      -   5        $ btnMinimize��5�   !   #���  5�   !    
 color7# �  5�   !   .��5�        $ WindowMinimize=�6+   $��12��6A   #��[ 6L   5�      5�      � 5�      $��1��6   $��2��6(    5�      �� 5�      �� 5�      .+�5�      �� $��0��6%   $ 
Horizontal=�5�   &   $��Center=�5�   &   .+�5�        $��20��5�   +   $��20��5�   +     SecondaryTextBrush   
Foreground# �  5�   +   $��	35,0,10,0q�5�   +    5�   +   �� *Icon+5�   +   �� 5�      #���  5�   (   $��16(�5�   (   $��
Montserrat)�5�   (   $��Medium"�5�   (   $��Center=�5�   (   ��5�   (   �� *	Caption+5�   (   5�      �� 5�      $��1��6%   $ 
Horizontal=�5�   %   $��RightToLeft=�5�   %   $��Center=�5�   %   $��0 0 10 0q�5�   %   .+�5�      ��   
iconButton#���  6%     color10# �  5�   %   $��5 0 0 0q�5�   %   ��5�   %   �� *LogOutCommand+.��5�   "     $ 	ArrowDown=�6/     iconButtonIcon#��[ 6@   5�      �� 5�      #���  5   (   $��
Montserrat)�5  (   $��12(�5  (   $��Center=�5  (   ��5�   (   �� * CurrentUserAccount.DisplayName+5  (   A� 5     $��35��6&   $��35��62   #���  5  &   $��2��5  &   $��	10 0 10 0q�5  &   ��5	  "   �� 5
  &    �� ImageSource$! /Images/profile-picture.png��61   5     4   .Casablanca.Components.LanguageSelectionControl  5     $��Center=�6A   $��Center=�6^   .   (Casablanca.Components.ChangeThemeControl  5     $��Center=�6;   $��Center=�6X   5     5     �� 5     $��2��5  %   $��25q�5  %   ��5  %   �� *CurrentChildView+5  %   5     5     5     5     5     