   M S B A M L   `   `   `  ����D  @WpfClient, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:WpfClient	WpfClient  5   	       WpfClient.InfoWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   )localclr-namespace:WpfClient     5   	     � Title$  
MainWindow��5   	   $	��450��6   $	��800��6)    � 	Resources 5         InfosCollection �� Source �� Path��%B   &	        �� 5   
    5      �� $ InfoList�5      5      .��5      &   System.Windows.Controls.DataGrid  -   5          Name$ dgNews��5      $��1��5      $��2��6      AutoGenerateColumns .     SelectionMode$ Single=�5         SelectionUnit$ FullRow=�5         GridLinesVisibility$ 
Horizontal=�5      	   CanUserDeleteRows	 .  
   CanUserAddRows
 .     CanUserResizeRows .  ��5   0   ��  �� Source# [     Columns 5   
   0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$
 Name��6!      Width5  /System.Windows.Controls.DataGridLengthConverter$ SizeToCells 6/      
IsReadOnly .    MaxWidth$	 450Q�6U   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6d   �� *name+  5      $ Price��6!   $ SizeToCells 60    . $	 100Q�6V    6e   �� *price+  5      $ Change��6!   $ SizeToCells 61    . $	 100Q�6W    6f   �� *change+   RowDetailsTemplate 5   
   �� 5       .R�5!      ]� 
�������.+�5"      � $
��0,10q�6    � ColumnDefinitions 5#      �� 5$      $��80 �6/   �� 5%      $	��500 �6/    � RowDefinitions 5'      �� 5(      $
��Auto �6,   �� 5)      $
��Auto �6,   �� 5*      $
��Auto �6,   �� 5+      $
��Auto �6,   �� 5,      $
��Auto �6,   �� 5-      $
��Auto �6,   �� 5.      $
��Auto �6,   �� 5/      $
��Auto �6,   �� 50      $
��Auto �6,   �� 51      $
��Auto �6,   �� 52      $
��Auto �6,   �� 53      $
��Auto �6,   �� 54      $
��Auto �6,   �� 55      $
��Auto �6,   .+�58      �� $
��Id: ��6$   $
��Bold"�60   $��0��6B   $��0��6R   �� 59      $��1��68   ��6$   �� *id+68   �� 5:      $��Name: ��6$   $
��Bold"�62   $��0��6D   $��1��6T   �� 5;      $��1��6:   $��1��6J   ��6$   �� *name+6J   �� 5<      $��Price: ��6$   $
��Bold"�63   $��0��6E   $��2��6U   �� 5=      $��1��6;   $��2��6K   $
��Wrap=�6X   ��6$   �� *price+6X   �� 5>      $��Change: ��6$   $
��Bold"�64   $��0��6F   $��3��6V   �� 5?      $��1��6<   $��3��6L   ��6$   �� *change+6L   �� 5@      $��Percantage Changed: ��6$   $
��Bold"�6@   $��0��6S   $��4��6c   �� 5A      $��1��6G   $��4��6W   ��6$   �� *perentage_changed+6W   �� 5B      $��
Is liked: ��6$   $
��Bold"�66   $��0��6I   $��5��6Y   �� 5C      $��1��6:   $��5��6J   ��6$   �� *like+6J   � 5D      $
��0,10q�6   $��1��6-   $��6��6=    5E      �� 5F   "   $��80 �63   �� 5G   "   $��80 �63    5I      �� 5J   "   $
��Auto �60   .+�5L      �� -   5        $��0��5L   8   $��0��6H   $
��Like��6U   �� 5M      -   5        $��1��5M   ;   $��0��6K   .��6X   	Dislike6a   5N      5O      5P      5Q         	CellStyle 5S   
   �� 5T       �� 
TargetType*  $System.Windows.Controls.DataGridCell"  6    �� Triggers 5U      P� 5V       P� Property �@ 
IsSelected P� Value . . �5W      ��  �� Property � �� �� Value$ 0q�6<   5X      5Z      5\      5]      