   M S B A M L   `   `   `  ����A  =Survey, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:Survey.SurveyToolSurvey.SurveyTool  5   	   $    Survey.SurveyTool.CreateSurvey   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   1localclr-namespace:Survey.SurveyTool     5   	   S OMaterialDesignThemes.Wpf, Version=1.0.1.0, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	     � Title$  CreateSurvey��5
   	   $��982.674��6   $��931.199��6/    � WindowStartupLocation$ CenterScreen=�6?    � WindowState$ 	Maximized=�6d   .��5      �  � ColumnDefinitions 5   
   �� 5      $
��0.5* �6   �� 5      �� 5      �� 5      $
��0.5* �6    � RowDefinitions 5   
   �� 5      $��0.15* �6   �� 5      $
��0.3* �6   �� 5      �� 5      $
��0.3* �6   �� 5      �� 5      $
��0.2* �6   .+�5   
   #  MaterialDesignThemes.Wpf.Card  $��4��5      .��5      � $��1��6   $��Right=�6(   $��Center=�6D   $��0,2,10,1q�6_   .+�5      �� -   5         ��Name$ 
InfoButton��5      $
��Auto��6.   $��
10,10,0,10q�6<   $��66��6P   .��5      '  !MaterialDesignThemes.Wpf.PackIcon     Kind$ Information=�6.   $
��AUTO��6A   $
��AUTO��6N   5      �� 5       -   5        $ 	AddButton��5       $
��Auto��6,   $��
10,10,0,10q�6:   $��66��6N   .��5!        $	 Add=�6.   $
��AUTO��69   $
��AUTO��6F   5"      �� 5#      -   5        $ UpdateButton��5#      $
��Auto��6/   $��
10,10,0,10q�6=   $��66��6Q   .��5$        $ Update=�6.   $
��AUTO��6<   $
��AUTO��6I   5%      �� 5&      -   5        $ 
SaveButton��5&      $
��Auto��6-   $��
10,10,0,10q�6;   $��66��6O   .��5'        $ ContentSave=�6.   $
��AUTO��6A   $
��AUTO��6N   5(      5)      5+      �� 5,   
   $��1��6   $��2��6    $��작업관리도구��64   $��10q�6D   .��5-      � .+�5.      �� -   5        $ DG1_AddButton��5.      $
��Auto��60   $��66��6?   $
��Left=�6K   .��5/        $	 Add=�6.   $
��AUTO��69   $
��AUTO��6F   50      �� 51      -   5        $ DG1_DeleteButton��51      $
��Auto��63   $��66��6B   $
��Left=�6N    �� Left$ 86��6i   $��86,0,0,0q�6z   .��52        $ Delete=�6.   $
��AUTO��6<   $
��AUTO��6I   53      54      55      �� 56   
   $��0��57      $��2��58      $��2��59      $��10q�5:      ���	#FF673AB7$��3q�5<      ._�5=      &   System.Windows.Controls.DataGrid  -   5        $	��DG1��5?         SelectionMode$ Extended=�5>      	   CanUserAddRows	 .  
   CanUserResizeColumns
 .     CanUserSortColumns .    EnableRowVirtualization .     AutoGenerateColumns .     Columns 5F      1  +MaterialDesignThemes.Wpf.DataGridTextColumn  5G      ,  &System.Windows.Controls.DataGridColumn   
IsReadOnly .    Header$ 입력구분��6N   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6\   �� *
SurveyCode+4  .System.Windows.Controls.DataGridTemplateColumn  5H         Width5  /System.Windows.Controls.DataGridLengthConverter$	 100 61   $ 설문지 항목��6=      CellTemplate 5I      �� 5J   "   .R�5K   &   ��  ��Name$ DGCom��6/   -   5        {�.  �� 
IsEditable .  �� 
IsReadOnly . ��5O   +   �� *SurveyOptionList+ �� SelectedValue 5Q   +   �� *SurveyOption+ �� NotifyOnSourceUpdated .  �� Mode$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=�5T   '   5U   #   5W        5X       .  $ 제목��6O    6[   �� *SurveyTitle+  5Y       .  $ 설명��6O    6[   �� *SurveyDescrip+5[      5\      �� 5]   
   $��3��6   $��2��6    $��작업관리도구��64   $��10q�6D   .��5^      � .+�5_      �� -	   5        $ DG2_AddButton��5_      $
��Auto��60   $��66��6?   $
��Left=�6K   .��5`        $	 Add=�6*   $
��AUTO��65   $
��AUTO��6B   5a      �� 5b      -
   5        $ DG2_DeleteButton��5b      $
��Auto��6/   $��66��6>   $
��Left=�6J   $ 86��6e   $��86,0,0,0q�6v   .��5c        $ Delete=�6*   $
��AUTO��68   $
��AUTO��6E   5d      5e      5f      �� 5g   
   $��4��5h      $��2��5i      ���	#FF673AB7$��3q�5k      $��10q�5l      ._�5n        -   5          Name$	 DG2��5n      $ Extended=�5o      	 .  
 .   .  .   .  5u      5v      �� 5w   
   $��10q�5x      $��2��5y      $��2��5z      $��1��5{      $��5��5|      $��결과 화면��5}      $��2q�5~      {�.  .��5�      (	  "System.Windows.Controls.WebBrowser	  -   5         	 Name$	 web��5�      5�      5�      5�      