   M S B A M L   `   `   `  ����J  FFlightSimulator, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:FlightSimulator.ViewsFlightSimulator.Views  5      '    !FlightSimulator.Views.ManualPilot   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      5local#clr-namespace:FlightSimulator.Views     5      .��5	      � .+�5
   
   ]� $��18(�6   $
��Bold"�6,   .+�5      � $	��Top=�6   .+�5      �� $��Center=�6   $��⟵ aileron ⟶��69   6N   �� 5      $��Right=�6   $��0 0 26 0q�68   ��6J   ��   �� ElementName$  
MyJoystick�� �� Path$ Aileron� �� StringFormat$ N2��6�   5      � 5      $��Right=�6   .+�5      �� $��Center=�6   $��⟵ elevator ⟶��67    � LayoutTransform 5      �� 5       �� Angle$ 90Q�6*   67   5   3   �� 5      $	��top=�6   $��0 5 0 0q�64   ��6E   �� $  
MyJoystick��$ Elevator�$ N2�� 5      �� 5      $ 90Q�6*   67   5   3   5      � 5      $��	0 20 0 80q�6   $
��Left=�6&    � ColumnDefinitions 5      �� 5      $
��Auto �6'   66   �� 5      $
��Auto �6'   66    � RowDefinitions 5      �� 5       $
��Auto �6$   64   �� 5!      $��* �6$   61   .+�5#      �� $��1��6   $��Center=�6)   $��⟵ throttle ⟶��6D    5$      �� 5%      $ 90Q�6*   67   5'      �� 5(      -   5         ��Name$ 
leftSlider��5(      $��	0 20 0 10q�6-   $��1��6A    �� TickPlacement$ BottomRight=�6N   	 �� TickFrequency$		 0.1Q�6j   $��1��6~   
 � Minimum$
 -1Q�6�    � Maximum$ 1Q�6�    � Value 6�   �� *VM_Throttle+ 5)      �� 5*      $	 -90Q�6*   68   5,      �� 5-      $��1��6   $	��Top=�6,   ��6D   �� $  
leftSlider��$ Value�$ N2��6�   5.      � 5/      $��Bottom=�6    50      �� 51      $��* �6'   63   �� 52      $
��Auto �6'   66    54      �� 55      $
��Auto �6$   64   �� 56      $
��Auto �6$   64   .+�58      �� $��0 0 0 10q�6   $��1��6.   $��Center=�6;   $��⟵ rudder ⟶��6X   6l   �� 59      -   5        $ buttomSlider��59      $��	30 0 30 0q�6/   $ BottomRight=�6C   $		 0.1Q�6_   $
 -1Q�6s   $ 1Q�6�    6�   �� *	VM_Rudder+6�   �� 5:      $��2��6   $	��Top=�6,   ��6D   �� $  buttomSlider��$ Value�$ N2��6�   5;      (� 5<       (� StretchDirection$
 Both=�6    (� Stretch$ Uniform=�6.   .��5=      $   FlightSimulator.Views.Joystick  -   5          Name$ 
MyJoystick��5=   !   $��10q�65      Aileron 6A   �� *
VM_Aileron+ �� Mode$ OneWayToSource=� �� UpdateSourceTrigger$ PropertyChanged=�   Elevator 6�   �� *VM_Elevator+$ OneWayToSource=�$ PropertyChanged=�6�   5>      5?      5@      5A      