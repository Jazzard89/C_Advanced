   M S B A M L   `   `   `  ����L  HTransportmiddelen, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:TransportmiddelenTransportmiddelen  5   	   "    Transportmiddelen.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   1localclr-namespace:Transportmiddelen     5   	   -   5          � Title$  
MainWindow��5   	   $	��450��6   $	��800��6)   .��5	      ]� $
��10pxq�6   
�������.+�5
   
   �� $	��Top=�6   $��Importeer bestand��6&   � 5   
    � RowDefinitions 5      �� 5      $��1* �6    �� 5      $��1* �6    �� 5      $��4* �6    �� 5      $��1* �6    �� 5      $��4* �6     � ColumnDefinitions 5      �� 5      �� 5      .+�5      ��  �� Orientation$ 
Horizontal=�6   $��1��62   $��Center=�6?   .+�5      �� $��Filter:��6   �� 5      -   5        $��CmbFietsFilter��5      �� 5       $��
Toon alles��6   5!      �� 5"      -   5        $��LbWelkom��5"   &   $��Welkom!��6   $��Right=�66   $��1��6R   $��1��6b   $��Center=�6o   �� 5$      -   5        $��
LstFietsen��5$      $��2��6(   $��2��65   �� 5&      $ 
Horizontal=�6   $��3��62   $��2��6?   $��Center=�6S   .+�5'      �� $��Filter:��6   	� 5(      -   5        $��RbOngevalVrij��5(      $��Center=�63   $��
20px 0 0 0q�6N   �� 5)      $��Ongevalvrij��6   $��Center=�6.   	� 5*      -   5        $��RbNietOngevalVrij��5*      $��Center=�67   $��
20px 0 0 0q�6R   �� 5+      $��Niet Ongevalvrij��6   	� 5,      -   5        $��	ToonAlles��5,      $��Center=�6/   $��
20px 0 0 0q�6J   �� 5-      $��
Toon alles��6   5.      �� 50      -   5        $��LstAutos��50      $��4��6&   $��2��63   51      52      53      