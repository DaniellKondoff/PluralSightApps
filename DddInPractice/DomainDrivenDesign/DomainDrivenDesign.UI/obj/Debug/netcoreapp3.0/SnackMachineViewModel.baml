   M S B A M L   `   `   `  ����P  LDomainDrivenDesign.UI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:DomainDrivenDesign.UIDomainDrivenDesign.UI  5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089   SnackMachineViewModel  �� DataType � ColumnDefinitions � RowDefinitions �� Orientation  img1Cent  	img10Cent  	img25Cent  
img1Dollar  
img5Dollar  img20Dollar�� 5      F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     :x,http://schemas.microsoft.com/winfx/2006/xaml     5      *ui#clr-namespace:DomainDrivenDesign.UI  5      %�  &	        7  7  7  7  7  7  �� 5      $  ui:SnackMachineViewModel��61   .R�5   
   �  5      �� 5      $��* �6#   �� 5	      $��* �6#    5      �� 5      $
��Auto �6    �� 5      $
��Auto �6    .+�5      � $��0��6   $��0��6#   $��2��60   $��Center=�6D    5      �� 5      $
��Auto �6$   �� 5      $
��Auto �6$   �� 5      $
��Auto �6$   �� 5      $
��Auto �6$   �� 5      $
��Auto �6$   �� 5      $
��Auto �6$    5      �� 5      $
��Auto �6'   �� 5      $
��Auto �6'   �� 5      $
��Auto �6'   .+�5      �� $��0��6   $��0��6)   $��3��66   $��Buy a Snack��6J   $��18(�6`   $��10q�6n   $��10q�6{   $��1��6�   ��6�   �� *BuySnackCommand+6�   �� 5!      $��3��6   $��0��61   $��1��6A   $ 
Horizontal=�6N   $��Center=�6g   .+�5"      �� $��Money inserted:��6   $��18(�66   �� 5#      $��18(�6C   $
��Bold"�6Q   ��6   �� *MoneyInTransaction+6Q   5$      �� 5&      $��0��6   $��2��6)   $��Put ¢1��66   $��18(�6G   $��10q�6U   $��10q�6b   ��6n   �� *InsertCentCommand+�� 5'      $��1��6   $��2��6)   $��Put ¢10��66   $��18(�6H   $��10q�6V   $��10q�6c   ��6o   �� *InsertTenCentCommand+�� 5(      $��2��6   $��2��6)   $��Put ¢25��66   $��18(�6H   $��10q�6V   $��10q�6c   ��6o   �� *InsertQuarterCommand+�� 5*      $��0��6   $��3��6)   $��Put $1��66   $��18(�6G   $��10q�6U   $��10q�6b   ��6n   �� *InsertDollarCommand+�� 5+      $��1��6   $��3��6)   $��Put $5��66   $��18(�6G   $��10q�6U   $��10q�6b   ��6n   �� *InsertFiveDollarCommand+�� 5,      $��2��6   $��3��6)   $��Put $20��66   $��18(�6H   $��10q�6V   $��10q�6c   ��6o   �� *InsertTwentyDollarCommand+�� 5.      $��3��6   $��0��6-   $��4��6=   $��Return money��6J   $��18(�5/      $��10q�6'   $��10q�64   ��5.   a   �� *ReturnMoneyCommand+5/   4   �� 51      $��3��6   $��0��6,   $��5��6<   $��Center=�6e   $��16(�6�   ��6I   �� *	Message+6�   52      �� 54      $��0��6   $��1��6)   $��2��66   $��Center=�6J   $��0 10 0 0q�6g   .+�55      �� $ 
Horizontal=�6   $��Center=�66   .+�56      �� $��Money inside:��6   $��20(�64   �� 57      $��20(�6<   $
��Bold"�6J   ��6   �� *MoneyInside+6J   58      �� 59      $ 
Horizontal=�6   $��0 10 0 0q�66   .+�5:      �� 8��  $	��100��6?   �� 5;      $��20(�6I   $
��Bold"�6W   $��
10 30 30 0q�6i   ��6   �� *MoneyInside.OneCentCount+6i   �� 5=      8�� $	��100��6@   �� 5>      $��20(�6I   $
��Bold"�6W   $��
10 30 30 0q�6i   ��6   �� *MoneyInside.TenCentCount+6i   �� 5@      8�� $	��100��6@   �� 5A      $��20(�6I   $
��Bold"�6W   $��
10 30 30 0q�6i   ��6   �� *MoneyInside.QuarterCount+6i   5B      �� 5C      $ 
Horizontal=�6   $��0 20 0 0q�66   .+�5D      �� 8�� $	��100��6A   �� 5E      $��20(�6K   $
��Bold"�6Y   $��	10 3 30 0q�6k   ��6   �� *MoneyInside.OneDollarCount+6k   �� 5G      8�� $	��100��6A   �� 5H      $��20(�6L   $
��Bold"�6Z   $��	10 3 30 0q�6l   ��6   �� *MoneyInside.FiveDollarCount+6l   �� 5J      8�� $	��100��6B   �� 5K      $��20(�6N   $
��Bold"�6\   $��	10 3 30 0q�6n   ��6   �� *MoneyInside.TwentyDollarCount+6n   5L      5M      5N      5P      5Q      