   M S B A M L   `   `   `  ����J  FFlightSimulator, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:FlightSimulator.ViewsFlightSimulator.Views  5   	   *    $FlightSimulator.Views.SettingsWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   5local#clr-namespace:FlightSimulator.Views     5   	     � Title$  Settings��5   	   $	��250��6   $	��275��6'   .��5	      � $��14(�6    � RowDefinitions 5
   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6    � ColumnDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $��* �6   .+�5   
   ��  �� Padding$ 3q�6   $��3q�6    Flight Server IP:6>   �� 5   
   -   5         ��Name$ ServerIP��5      $��2��6$   $��3q�64   $��3q�6@   .��6K   5      �� 5   
   $��1��6   $ 3q�6!   $��3q�6-   Flight Info Port:6K   �� 5   
   -   5        $ 
ServerPort��5      $��1��6&   $��1��63   $��3q�6C   $��3q�5      6   �� 5   
   $��2��6   $ 3q�6!   $��3q�6-   Flight Command Port:6N   �� 5   
   -   5        $ CommandPort��5      $��2��6'   $��1��64   $��3q�6D   $��3q�5      6   �� 5   
   -   5         ��Name$ btnOk��5      $��3��6    $��0��6-   $��Center=�6=   $��62,21,25,-11q�6n   $��5q�6�   $��60��6�   .��6�   OK6�   �� 5   
   -   5        $ 	btnCancel��5      $��3��6$   $��1��61   $��Center=�6A   $��3,21,57,-11q�6v   $��5q�6�   $��60��6�   .��6�   Cancel6�   5      5       