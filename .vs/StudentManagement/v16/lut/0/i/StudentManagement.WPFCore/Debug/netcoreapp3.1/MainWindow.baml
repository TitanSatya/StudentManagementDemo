   M S B A M L   `   `   `  ����T  PStudentManagement.WPFCore, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullE'clr-namespace:StudentManagement.WPFCoreStudentManagement.WPFCore  5   	   *    $StudentManagement.WPFCore.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   9local'clr-namespace:StudentManagement.WPFCore     5   	   V RMaterialDesignThemes.Wpf, Version=3.1.3.1513, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   
      MaterialDesignBody#���   5	   
   $��Regular"�5
   
   $��13(�5   
   &   System.Windows.Media.TextOptions    TextFormattingMode$  Ideal=�5   
      TextRenderingMode$
 Auto=�5   
     MaterialDesignPaper#���  5   
     MaterialDesignFont#���  5   
    � Title$ 
MainWindow��5   	   $	��450��6   $	��800��6)   .��5      �  � ColumnDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $��* �6   .+�5   
   � $��0��6   $��5 0 5 0q�6    � RowDefinitions 5      �� 5      $
��Auto �6    �� 5      $
��Auto �6    �� 5      $
��Auto �6    �� 5      $
��Auto �6    �� 5      $
��Auto �6    �� 5      $
��Auto �6    �� 5      $
��Auto �6    �� 5       $
��Auto �6    �� 5!      $
��Auto �6     5$      �� 5%      $
��Auto �6#   �� 5&      $	��150 �6#   .+�5*      #  MaterialDesignThemes.Wpf.Card  $��5q�6"   $��5q�5+   "   $��0��5,   "   $	��150��5-   "   $��2��5.   "   .��5/      �� $��Center=�50      $
��Bold"�51      $��16(�52         MaterialDesignTitleTextBlock#���  53      Edit Student Data54   (   55      �� 56      $��0��6   $��4q�57      $��1��58      First Name:5:      �� 5;      $��0��6   $��4q�5<      $��2��5=      
Last Name:5?      �� 5@      $��0��6   $��4q�5A      $��3��5B      DOB:5D      �� 5E      $��0��6   $��4q�5F      $��4��5G      
Address:5I      �� 5J      -   5         ��Name$ StudentFirstNameTextBox��5J      $��4q�5K      $��1��5L      $
��Left=�5M      $	��136��5N      $��1��5O      ��5P      �� *StudentFirstName+ �� Mode$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=��� 5Q      -   5        $ StudentLastNameTextBox��5Q      $��4q�5R      $��2��5S      $
��Left=�5T      $	��136��5U      $��1��5V      ��5W      �� *StudentLastName+$ TwoWay=�$ PropertyChanged=�(  "System.Windows.Controls.DatePicker  5X      -   5          Name$ StudentDOBDatePicker��5X      $��4,0,0,0q�5Y      $��3��5Z      $	��136��5[      $
��Left=�5\      $��1��5]      	   Text	 5^      �� *
StudentDOB+$ TwoWay=�$ PropertyChanged=��� 5_      -   5        $ StudentAddress��5_      $��4q�5`      $��4��5a      $
��Left=�5b      $	��136��5c      $��3��5d      $	��200��5e      
 �� AcceptsReturn$

 True��5f       �� TextWrapping$
 Wrap=�5g      $��1��5h      ��5i      �� *StudentAddress+$ TwoWay=�$ PropertyChanged=��� 5k      -   5         ��Name$ 
SaveButton��5k      $��8��5l      $��1��5m       & "MaterialDesignFloatingActionButton#��[ 5n   	   $��32��5o      $��32��5p      $��Right=�5q      $��Center=�5s      ��5r      �� *SaveCommand+.��5t      '  !MaterialDesignThemes.Wpf.PackIcon     Kind$ ContentSave=�6*   5v      5w      5x      &   System.Windows.Controls.DataGrid  5y   
   -   5          Name$ StudentDatagrid��5z      $��1��5y         CanUserAddRows$ False��5|         AutoGenerateColumns$ False��5~      ��5{      �� *AllStudents+ �� SelectedItem 5}      �� *SelectedStudent+$ TwoWay=�$ PropertyChanged=�   Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5�      ,  &System.Windows.Controls.DataGridColumn   Header$ 	FirstName��6%   1  +System.Windows.Controls.DataGridBoundColumn   Binding 5�   !   �� *StudentFirstName+  5�      $ 	Last Name��6%    5�   !   �� *StudentLastName+  5�      $ Student DOB��6%    5�   !   �� *
StudentDOB+  5�      $ Student Address��6%    5�   !   �� *StudentAddress+4	  .System.Windows.Controls.DataGridTemplateColumn	  5�      $ Delete��6)    	  CellTemplate 5�      �� 5�      .R�5�      �� $ 
SaveButton��6%   $��8��5�      $��1��5�      #��[ 5�      $��32��5�      $��32��5�      
���  ��
���  ��$��Right=�5�      $��Center=�5�      ��5�      �� *DataContext.DeleteCommand+ �� ElementName$ StudentDatagrid��.��5�   "     $ Delete=�6:   5�      5�      5�      5�      5�      5�      