   M S B A M L   `   `   `  ����E  ACasablanca, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:Casablanca.ViewCasablanca.View  5      Q-clr-namespace:Casablanca.ViewModel.EmployeeVMCasablanca.ViewModel.EmployeeVM  5      3clr-namespace:Casablanca.UtilsCasablanca.Utils  5      3    -Casablanca.View.UserView.ArticlesEmployeeView   5      W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5      R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      /localclr-namespace:Casablanca.View     5      C	viewModel-clr-namespace:Casablanca.ViewModel.EmployeeVM     5      0utilsclr-namespace:Casablanca.Utils     5      T PMahApps.Metro, Version=2.0.0.0, Culture=neutral, PublicKeyToken=51482d6f650b2b3f8metro,http://metro.mahapps.com/winfx/xaml/controls  5	      X TFontAwesome.Sharp, Version=6.3.0.0, Culture=neutral, PublicKeyToken=d16d1e4e568ec10fFfa=http://schemas.awesome.incremented/wpf/xaml/fontawesome.sharp  5
        � DataContext  5      ?   9Casablanca.ViewModel.EmployeeVM.ArticlesEmployeeViewModel  5   
    � 	Resources 5       �� MergedDictionaries �� Source-   'Casablanca.Utils.NullToBooleanConverter   NullToBooleanConverter�� 5   
    5      �� 5      $  /Custom/DataGridStyle.xaml?�6%   %   &	          5      6+   5      .��5      �� .+�5   
   ��  
 remove#���  6    
 color8#���  5       $��5q�5"      $	��100��5#      ��5      �� *RemoveCommand+��5!      �� *SelectedArticle+{�5$      �� *SelectedArticle+ �� 	Converter# [  �� 5&   
     add#���  6    
 color7#���  5(      $��5q�5)      $	��100��5*      ��5'      �� *
AddCommand+5*      �� 5,   
    �� Orientation$ 
Horizontal=�6   $��10q�6.   $	��Top=�6:   .+�5.      !  FontAwesome.Sharp.IconBlock  �  �FontAwesome.Sharp.IconBlockBase`1[[FontAwesome.Sharp.IconChar, FontAwesome.Sharp, Version=6.3.0.0, Culture=neutral, PublicKeyToken=d16d1e4e568ec10f]]   Icon$ Search=�6   
�������$��20��6;   $��20��6F   $	��5,0q�6R   $
��Left=�6_   �� 51      $	��260��6   $��	30,5,10,5q�6"   ��66   �� *SearchQuery+ �� UpdateSourceTrigger$ PropertyChanged=�.��6x   ��52      �� 53       �� 
TargetType" ��6   .�54      �� 	 �� Property	 � ��
 �� Value

 �����67   �� 55      	 � ��$
 14(�65   �� 56      	 � ��

 �����68   �� 57      	 � ��$
 1q�6<   �� 58      	 � ��
 �#FFF67    �� Triggers 59      P� 5:       P� Property �@J�IsMouseOver P� Value$
 True��6=   . �5;   "   �� 	 � ��

 �����6@   5<      5>      .��5?   !   5@      �� 5B      $	��100��6   $��0,0,10,0q�6#    �� DisplayMemberPath$ TypeName��5C      ��5B   5   �� *
Categories+ �� SelectedItem 5C   4   �� *SelectedCategory+�� 5F      $��Rented��6    d� 	IsChecked 6(   �� *IsRentedFilter+5G      �� 5I   
   $
��Auto=�6   .��5J      �� -   5         ��Name$ ArticlesList��5J      ��61   �� *FilteredArticles+��5K      �� 5L      .R�5M      �� $��10q�6!    �� Padding$ 10q�6-   
�������$��1q�6M    �� CornerRadius$ 5��6a   ._�5N      �� $	��150��6)   $��Center=�65    J� InputBindings 5O   "   d� 5P   &    d� Gesture$ 	LeftClicka�63    �� Command 5Q   3   �� *" DataContext.SelectArticleCommand+ �� RelativeSource ��  �� AncestorType UserControl �� CommandParameter 5R   3   �� .+�5T   "   �� $	��100��6D   $	��100��6P   $��0,0,0,10q�6]   ��6(   �� *
ImageURL+6]   �� 5U   "   $
��Bold"�6B    �� TextAlignment$ Center=�6T     PrimaryTextBrush#���  6k   ��6,   �� *Name+6k   �� 5V   "   $ Center=�6S   #���  6j   ��6,   �� *Price+ �� StringFormat$ C��6j   5W      5X      5Y      ��5[      �� 5\      .R�5]      � 5^      5`      5a      5b      5c      