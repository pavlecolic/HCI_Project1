   M S B A M L   `   `   `  ����E  ACasablanca, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:Casablanca.View.ModalCasablanca.View.Modal  5   	   Q-clr-namespace:Casablanca.ViewModel.EmployeeVMCasablanca.ViewModel.EmployeeVM  5   	   ,    &Casablanca.View.Modal.AddArticleDialog   5   	   W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5   	   R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   5local#clr-namespace:Casablanca.View.Modal     5   	   C	viewModel-clr-namespace:Casablanca.ViewModel.EmployeeVM     5   	     � Title$  Add Article��5	   	   $	��450��6   $	��800��6*    � DataContext 5      9   3Casablanca.ViewModel.EmployeeVM.AddArticleViewModel  5   
    � 	Resources 5         BooleanToVisibility��%   &	        �� 5   
   6E   5      y�5      �� 5   
    �� Path$ IsViewVisible�6    �� Mode$ TwoWay=�6'    �� 	Converter# [  65   .��5      �� $��20q�6   $	��Top=�6   .+�5   
   �� $��Article Name:��6   $
��Bold"�6)   $��0,10,0,5q�6;   �� 5   
   ��6   �� *Name+ �� UpdateSourceTrigger$ PropertyChanged=��� 5   
   $��Image:��6   $
��Bold"�6"   $��0,10,0,5q�64   �� 5   
    �� Orientation$ 
Horizontal=�6   .+�5      ��  �� 
IsReadOnly$
 True��6U   $	��250��6g   ��6   �� *
ImageURL+$ PropertyChanged=�6g   �� 5      $��Browse��6   $	��100��6M   $��10,0,0,0q�6Y   ��6&   �� *BrowseImageCommand+6Y   5       �� 5"   
   $��Price:��6   $
��Bold"�6"   $��0,10,0,5q�64   �� 5#   
   ��6   �� *Price+$ PropertyChanged=��� 5%   
   $��
Publisher:��6   $
��Bold"�6&   $��0,10,0,5q�68   �� 5&   
   	 �� DisplayMemberPath$	 PublisherName��5'      ��5&      �� *
Publishers+
 �� SelectedItem
 66   �� *SelectedPublisher+5'      �� 5)   
   $��Type:��6   $
��Bold"�6!   $��0,10,0,5q�63   �� 5*   
   $	 TypeName��5+      ��5*      �� *Types+
 61   �� *SelectedType+5+      �� 5-   
   $ 
Horizontal=�6   $��Right=�6.   $��0,20,0,0q�6J   .+�5.      �� $
��Save��6   $��5q�6D   ��6$   �� *SaveCommand+6D   �� 5/      $��Cancel��6   $��5q�6H   ��6&   �� *CancelCommand+6H   50      51      52      