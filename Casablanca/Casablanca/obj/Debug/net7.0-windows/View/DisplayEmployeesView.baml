   M S B A M L   `   `   `  ����E  ACasablanca, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:Casablanca.ViewCasablanca.View  5      ;"clr-namespace:Casablanca.ViewModelCasablanca.ViewModel  5      3clr-namespace:Casablanca.UtilsCasablanca.Utils  5      *    $Casablanca.View.DisplayEmployeesView   5      W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5      R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      /localclr-namespace:Casablanca.View     5      8	viewModel"clr-namespace:Casablanca.ViewModel     5      0utilsclr-namespace:Casablanca.Utils     5      T PMahApps.Metro, Version=2.0.0.0, Culture=neutral, PublicKeyToken=51482d6f650b2b3f8metro,http://metro.mahapps.com/winfx/xaml/controls  5	        � DataContext  5      -   'Casablanca.ViewModel.EmployeesViewModel  5   
    � 	Resources 5       �� MergedDictionaries �� Source-   'Casablanca.Utils.NullToBooleanConverter   NullToBooleanConverter�� 5   
    5      �� 5      $  /Custom/DataGridStyle.xaml?�6%   %   &	          5      6+   5      .��5      �� .+�5   
   ��  �� Orientation$ 
Horizontal=�6   $��Right=�6.   $��10q�6J   .+�5      ��   add#���  6    
 color7#���  5!      $��5q�5"      ��5       �� *
AddCommand+5"      �� 5$        edit#���  6    
 color6#���  5&      $��5q�5(      ��5%      �� *EditCommand+��5'      �� *SelectedEmployee+{�5)      �� *SelectedEmployee+ �� 	Converter# [  �� 5+       
 remove#���  6    
 color8#���  5-      $��5q�5/      ��5,      �� *RemoveCommand+��5.      �� *SelectedEmployee+{�50      �� *SelectedEmployee+# [  51      &   System.Windows.Controls.DataGrid  54   
   -   5          Name$
 User��54         AutoGenerateColumns$ False��55       
 color1   AlternatingRowBackground# �  56        MetroDataGrid#��[ 59      ��57      �� *	Employees+	 �� SelectedItem	 58      �� *SelectedEmployee+
   Columns
 5;      0  *System.Windows.Controls.DataGridTextColumn  5<       	 	firstName,  &System.Windows.Controls.DataGridColumn   Header# � 	 6)      Width5  /System.Windows.Controls.DataGridLengthConverter$ * 6m   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6N   �� *	firstName+6m     5=       
 lastName# � 
 6)   $ * 6j    6M   �� *
lastName+6j     5>       
 salary# �  6)   $ * 6v    6K   �� *salary+ �� StringFormat$ C��6v     5?        username# �  6)   $ * 6j    6M   �� *
username+6j   5A      5B      5D      