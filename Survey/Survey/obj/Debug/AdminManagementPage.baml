   M S B A M L   `   `   `  ����A  =Survey, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:SurveySurvey  5   	        Survey.AdminManagementPage   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   &localclr-namespace:Survey     5   	   S OMaterialDesignThemes.Wpf, Version=1.0.1.0, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	     � Title$  AdminManagementPage��5	   	   $��495.185��6%   $��989.959��66   .��5
      �  � ColumnDefinitions 5   
   �� 5      $
��327* �6   �� 5      $
��124* �6   �� 5      $
��204* �6   �� 5      $
��327* �6    � RowDefinitions 5   
   �� 5      $
��0.5* �6   �� 5      $��2* �6   �� 5      $��2* �6   �� 5      $
��0.5* �6   .+�5   
   #  MaterialDesignThemes.Wpf.Card  $��4��6   .��5      ]� $��Right=�6   .+�5      � $��Center=�6   $��0,2,10,1q�68   .+�5      �� -   5         ��Name$ 
InfoButton��5      $
��Auto��62   $��
10,10,0,10q�6@   $��66��6T   .��5      '  !MaterialDesignThemes.Wpf.PackIcon     Kind$ Information=�62   $
��AUTO��6E   $
��AUTO��6R   5      �� 5      -   5        $ SelectButton��5      $
��Auto��64   $��
10,10,0,10q�6B   $��66��6V   .��5        $ 
FileSearch=�62   $
��AUTO��6D   $
��AUTO��6Q   5       �� 5"      -   5        $ 	AddButton��5"      $
��Auto��61   $��
10,10,0,10q�6?   $��66��6S   {�6v   ��  �� Path$ 
AddEnabled�.��5#        $	 add=�62   $
��AUTO��6=   $
��AUTO��6J   5$      �� 5%      -   5        $ UpdateButton��5%      $
��Auto��63   $��
10,10,0,10q�6A   $��66��6U   .��5&        $ Update=�62   $
��AUTO��6@   $
��AUTO��6M   5'      �� 5(      -   5        $ DeleteButton��5(      $
��Auto��63   $��
10,10,0,10q�6A   $��66��6U   .��5)        $ Delete=�62   $
��AUTO��6@   $
��AUTO��6M   5*      �� 5+      -   5        $ CheckButton��5+      $
��Auto��62   $��
10,10,0,10q�6@   $��66��6T   .��5,        $ Check=�62   $
��AUTO��6?   $
��AUTO��6L   5-      �� 5.      -   5        $ CancelButton��5.      $
��Auto��63   $��
10,10,0,10q�6A   $��66��6U   .��5/        $ Cancel=�62   $
��AUTO��6@   $
��AUTO��6M   50      51      52      53      �� 54   
   $��3q�55      $��10 10 10 10 q�56      $��3��57      $��1��58      $��2��59      $!��관리자 입력 및 수정��5:      .��5<      �� -   5         ��Name$ 	AdminInfo��5<      .+�5=      �� 
 �� Top$ 18��6   .��6)   관리자 아이디62   �� 5>      -	   5         ��Name$ adminId��5>      	 �� TextWrapping$
	 Wrap=�6,   $	��169��6f   
 �� Left$
 98��6r   $ 18��6�   ��6@   �� *	AdminId+ �� Mode$ TwoWay=�6�   �� 5?      $
 28��6   $ 48��6)   .��69   비밀번호6?   �� 5@      -
   5        $ adminPassword��5@      $	 WrapWithOverflow=�61   $	��169��6}   $
 98��6�   $ 48��6�    �� 	UndoLimit$ 12��6�   ��6Q   �� *AdminPassword+$ TwoWay=�6�   �� 5A      $
 16��6   $ 88��6)   .��6:   관리자이름6A   �� 5B      -   5        $ 	adminName��5B      $
	 Wrap=�6.   $	��169��6j   $
 98��6v   $ 87��6�   ��6B   �� *	AdminName+$ TwoWay=�6�   �� 5C      $
 16��6   $	 129��6)   .��6;   관리자등급6B   �� 5D      -   5         ��Name$ 
adminGrade��5E      $
 98��5G      $	 129��5H      $��35��5I       �� Text 5F      �� *AdminSGrade+.@�5J      �� .��6#   M6&   �� 5K      .��6#   N6&   5L      5M      5N      �� 5O   
   ���	#FF673AB7$��3q�5Q      $��0��5R      $��1��5S      $��2��5T      $��3��5U      $��10q�5V      ._�5W      &   System.Windows.Controls.DataGrid  -   5        $	��DG1��5W         CanUserAddRows .     CanUserResizeColumns .     CanUserSortColumns .    EnableRowVirtualization .     AutoGenerateColumns .     CanUserDeleteRows .    FrozenColumnCount$ 2��5_         Columns 5b      1  +MaterialDesignThemes.Wpf.DataGridTextColumn  5c      ,  &System.Windows.Controls.DataGridColumn   Header$ 입력구분��6V      CanUserReorder .    
IsReadOnly . 1  +System.Windows.Controls.DataGridBoundColumn   Binding 68   �� *	AdminCode+6z   0  *System.Windows.Controls.DataGridTextColumn  5d      $ 관리자아이디��6*    .  5e   )   �� *	AdminId+$ TwoWay=�  5f       .  $ 비밀번호��6<    6J   �� *AdminPassword+  5g       .  $ 관리자이름��6<    6K   �� *	AdminName+  5h       .  $ 관리자 등급��6<    6L   �� *AdminSGrade+  5i       . $ 관리자 생성일��6;    6M   �� *AdminCreateAt+5l      5m      5n      5o      