   M S B A M L   `   `   `  ����B  >WpfApp1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:WpfApp1WpfApp1  5          WpfApp1.UserCard   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      'localclr-namespace:WpfApp1     5      $��0 1 0 1q�5      
���   �.��5	      � -   5          �Name$  
WorkerCard��5	       � RowDefinitions 5
   
   �� 5      �� 5      �� 5      �� 5      �� 5      �� 5       � ColumnDefinitions 5   
   �� 5      �� 5      .+�5   
   �� -   5        $��FullnameLabel��5      $��0��6   $��25(�62   $
��Bold"�6@   .��6R   	ФИО:6X   �� 5   
   -   5         ��Name$ DeleteWorkerButton��5   .   $��1��6   $��1��6   $��Right=�6J   $��Center=�6f   $��95��6�   $��30��6�   $��0 0 10 0q�6�   $��18(�6�   $
��Bold"�6�   .��6�   Удалить6�   �� 5   
   -   5        $ UpgradeJobButton��5   .   $��2��6   $��1��6   $��Right=�6H   $��Center=�6d   $��95��6   $��30��6�   $��	0 10 10 0q�6�   $��18(�6�   $
��Bold"�6�   .��6�   Повысить6�   �� 5   
   -   5        $ DowngradeJobButton��5   .   $��3��6   $��1��6   $��Right=�6J   $��Center=�6f   $��95��6�   $��30��6�   $��	0 10 10 0q�6�   $��18(�6�   $
��Bold"�6�   .��6�   Понизить6�   �� 5   
   -   5        $ EditUserButton��5   .   $��4��6   $��1��6   $��Right=�6F   $��Center=�6b   $��95��6}   $��30��6�   $��	0 10 10 0q�6�   $��18(�6�   $
��Bold"�6�   .��6�   Изменить6�   �� 5   
   -   5        $��BirthdayLabel��5      $��1��6   $��18(�62   .��6@   Дата рождения:6P   �� 5   
   -   5        $��GenderLabel��5      $��2��6   $��18(�60   .��6>   	Пол:6D   �� 5   
   -	   5        $��JobLabel��5      $��3��6   $��18(�6-   .��6;   Должность:6G   �� 5    
   -
   5        $��ChiefFullNameLabel��5       $��4��6   $��18(�67   .��6E   Начальник:6Q   �� 5!   
   -   5        $��SubdivisionLabel��5!      $��5��6   $��18(�65   .��6C   Подразделение:6S   5"      5#      