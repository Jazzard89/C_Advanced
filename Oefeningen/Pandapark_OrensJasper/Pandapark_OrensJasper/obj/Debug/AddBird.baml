   M S B A M L   `   `   `  ����P  LPandapark_OrensJasper, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:Pandapark_OrensJasperPandapark_OrensJasper  5   	   #    Pandapark_OrensJasper.AddBird   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   5local#clr-namespace:Pandapark_OrensJasper     5   	     � Title$  Vogel Toevoegen��5      $	��450��6    $	��800��6-   .��5	      ]� 
�������.+�5
   
   �� ���#58a518$	��Top=�6*   .+�5      �� $��images/birds.jpg��6   $	��150��6.   $��Uniform=�6;   6O   5      � 5   
   $��20 10 50 10q�6    � ColumnDefinitions 5      �� 5      �� 5      $��3* �6#    � RowDefinitions 5      �� 5      �� 5      �� 5      �� 5      �� 5      �� 5      �� 5      �� 5      �� 5      �� 5      .+�5      �� $
��20 0q�6   $��Center=�6&   Naam6G   �� 5       -   5        $��TextBoxName��5!      $��1��5       $��Stretch=�6&   5!   .   �� 5"      $
��20 0q�6   $��1��6&   $��Center=�63   Soort6U   �� 5#      -   5        $��TextBoxType��5$      $��1��5#      $��1��6&   $��Stretch=�63   5$   .   �� 5%      $
��20 0q�6   $��Center=�6&   $��2��5&      Is gevaarlijk65   �� 5'      -   5        $��CheckBoxDanger��5(   4   $��1��5'      $��2��6'   $��Stretch=�64   $��Center=�5(      5)      �� 5*      $
��20 0q�6   $��Center=�6&   $��3��5+      Dieet6-   �� 5,      -   5        $��ComboBoxDiet��5-   4   $��1��5,      $��3��6'   $��Stretch=�64   $��Center=�5-      .@�5/      �� .��6   	Herbivoor6*   �� 50      .��6   	Carnivoor6*   �� 51      .��6   
Omnivoor6)   52      �� 53      $
��20 0q�6   $��Center=�6&   $��4��54      
Geslacht60   �� 55      -   5        $��ComboBoxGender��56   4   $��1��55      $��4��6'   $��Stretch=�64   $��Center=�56      .@�58      �� .��6   	Mannelijk6*   �� 59      .��6   
Vrouwelijk6+   5:      �� 5;      $
��20 0q�6   $��Center=�6&   $��5��5<      Geboorteland64   �� 5=      -   5        $��TextBoxCountry��5=   Q   $��1��6   $��5��6&   $��Stretch=�63   5>      �� 5?      $
��20 0q�6   $��Center=�6&   $��6��5@      GeboorteDatum65   (  "System.Windows.Controls.DatePicker  5A      -   5        $��DatePickerBirth��5A   T   $��1��6   $��6��6)   $��Stretch=�66   5B      �� 5D      $
��20 0q�6   $��Center=�6&   $��7��6A   
NestType6X   �� 5E      -   5        $��ComboBoxNestType��5F   4   $��1��5E      $��7��6'   $��Stretch=�64   $��Center=�5F      .@�5H      �� .��6   Platform nest6.   �� 5I      .��6   
Kom nest6)   �� 5J      .��6   
Holte nest6+   �� 5K      .��6   
Grond nest6+   5L      �� 5N      $
��20 0q�6   $��Center=�6&   $��8��6A   
WingSpan6X   �� 5O      -	   5        $��TextBoxWingSpan��5P      $��1��5O      $��8��6&   $��Stretch=�63   5P   2   �� 5R      -
   5        $��9��5R      $��3q�68   .��6C   Voeg Vogel Toe6S   5S      5U      5V      