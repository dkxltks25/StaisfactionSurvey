   M S B A M L   `   `   `  ����A  =Survey, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:SurveySurvey  5   	       Survey.DepartmentAdd   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   &localclr-namespace:Survey     5   	   S OMaterialDesignThemes.Wpf, Version=1.0.1.0, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	     � Title$  DepartmentAdd��5	   	   $	��450��6   $��945.735��6,   .��5
      �  � RowDefinitions 5   
   �� 5      $
��0.5* �6   �� 5      �� 5      �� 5      $
��0.1* �6    � ColumnDefinitions 5   
   �� 5      �� 5      $
��0.7* �6   .+�5   
   #  MaterialDesignThemes.Wpf.Card  $��2��6   .��5      �  5      �� 5      $
��0.3* �6'   �� 5      .+�5      �� ._�5      �� $��Bottom=�6   $��8��68    J� RenderTransformOrigin$ 0.5,0.5&�6C   .+�5      ��  �� Left$ 5��6    
 �� Top$	 -27��60   .��6B   	검색:6G   �� 5      -   5         ��Name$ 
SelectText��5   "   $	��130��67   $ 43��6e   $	 -28��6v   5       5!      �� 5"      $��1��6   ._�5#      � $��Right=�6    $��Center=�6=   $��0,2,10,1q�6X   .+�5$      �� -   5         ��Name$ 
InfoButton��5$   !   $
��Auto��66   $��
10,10,0,10q�6D   $��66��6X   .��5%      '  !MaterialDesignThemes.Wpf.PackIcon     Kind$ Information=�66   $
��AUTO��6I   $
��AUTO��6V   5&      �� 5'      -   5        $ SearchButton��5'   !   $
��Auto��67   $��
10,10,0,10q�6E   $��66��6Y   .��5(        $ 
FileSearch=�66   $
��AUTO��6H   $
��AUTO��6U   5)      �� 5*      -   5        $ 	AddButton��5*   !   $
��Auto��64   $��
10,10,0,10q�6B   $��66��6V   .��5+        $	 Add=�66   $
��AUTO��6A   $
��AUTO��6N   5,      �� 5-      -   5        $ UpdateButton��5-   !   $
��Auto��67   $��
10,10,0,10q�6E   $��66��6Y   .��5.        $ Update=�66   $
��AUTO��6D   $
��AUTO��6Q   5/      �� 50      -   5        $ DeleteButton��50   !   $
��Auto��67   $��
10,10,0,10q�6E   $��66��6Y   .��51        $ Delete=�66   $
��AUTO��6D   $
��AUTO��6Q   52      �� 53      -   5        $ CheckButton��53   !   $
��Auto��66   $��
10,10,0,10q�6D   $��66��6X   .��54        $ Check=�66   $
��AUTO��6C   $
��AUTO��6P   55      �� 56      -   5        $ CancelButton��56   !   $
��Auto��67   $��
10,10,0,10q�6E   $��66��6Y   .��57        $ Clear=�66   $
��AUTO��6C   $
��AUTO��6P   58      �� 59      -	   5        $ 
SaveButton��59   !   $
��Auto��65   $��
10,10,0,10q�6C   $��66��6W   .��5:        $ ContentSave=�66   $
��AUTO��6I   $
��AUTO��6V   5;      5<      5=      5>      5?      �� 5@   
   $��1��5A      $��2��5B      $��10q�5C      ���	#FF673AB7$��3q�5E      ._�5F      &   System.Windows.Controls.DataGrid  -
   5        $	��DG1��5H      	   CanUserAddRows	 .  
   CanUserResizeColumns
 .     CanUserSortColumns .    EnableRowVirtualization .     AutoGenerateColumns .     CanUserDeleteRows .    Columns 5O      1  +MaterialDesignThemes.Wpf.DataGridTextColumn  5P      ,  &System.Windows.Controls.DataGridColumn   Header$ 입력구분��6U      CanUserReorder .    
IsReadOnly . 1  +System.Windows.Controls.DataGridBoundColumn   Binding 68   �� *
DeptCode+6y   0  *System.Windows.Controls.DataGridTextColumn  5Q       .  $! 부서 및 학과 아이디��6<    6Q   �� *DeptId+  5R       .  $ 부서 및 학과 이름��6<    6P   �� *
DeptName+  5S       .  $! 부서 및 학과 생성일��6<    6Q   �� *DeptCreateAt+5W      5X      �� 5Y   
   -   5         ��Name$ DeptInfo��5Y      $��1��6%   $��2��62   $��1��6C   $��10q�6S   $��학과및 부서 입력��6_   .��5Z      �� .+�5[      �� $!��학과 및 부서 아이디��6   $ 10��6.   $ 18��6?   6Q   �� 5\      -   5        $ dept_id��5\      $	��122��6,   $	 132��68   $ 13��6J   ��6Z   �� *DeptId+ �� Mode$ TwoWay=�6�   �� 5]      $��학과 및 부서 이름��6   $ 18��6-   $ 62��6>   �� 5^      -   5        $ 	dept_name��5^      $	��122��6.   $	 132��6:   $ 61��6L   ��6\   �� *
DeptName+$ TwoWay=�6�   5_      5`      5a      5b      