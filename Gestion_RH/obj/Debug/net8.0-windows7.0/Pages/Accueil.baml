   M S B A M L   `   `   `  ����E  AGestion_RH, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:Gestion_RH.ConvertersGestion_RH.Converters  5      =#clr-namespace:Gestion_RH.ViewModelsGestion_RH.ViewModels  5          Gestion_RH.Pages.Accueil   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      4conv#clr-namespace:Gestion_RH.Converters     5      4view#clr-namespace:Gestion_RH.ViewModels     5      Z VFontAwesome.WPF, Version=4.7.0.37774, Culture=neutral, PublicKeyToken=0758b07a11a4f466-fa$http://schemas.fontawesome.io/icons/  5        N� Title$  Accueil��5       � 	Resources 5      =  7System.Windows.Controls.Primitives.DataGridColumnHeader �� 
TargetType �� Property �� Value*  $System.Windows.Controls.DataGridCell)  #System.Windows.Controls.DataGridRow �� Triggers �� Binding �� Value   RoundedButtonStyle �� 
TargetType	 �� CornerRadius
 �� Padding � Cursor P� Property P� Value  BoolToVisConverter5   /Gestion_RH.Converters.ByteArrayToImageConverter  ByteArrayToImageConverter.   (Gestion_RH.Converters.TagFormatConverter  TagFormatConverter=   7Gestion_RH.Converters.BoolToVisibilityInvertedConverter  BoolToVisInvertedConverter��%�  '        '  �     '  �    &	  �    &	 .    &	 A    &	 T    &	 g    �� 5   
   "  6   .�5      ��  � �� �#2C3E506+   �� 5       � ��
 �����6+   �� 5       � ��$ 16(�6)   �� 5       � ��$ 40��6'   �� 5       � ��$ Center=�6;   5      �� 5   
   "  6   .�5      ��  � ��$ 10q�6(   �� 5       � ��$ 16(�6)   �� 5       � ��
 �   �6+   �� 5       � ��
 �����6+   �� 5       � ��
 �����6,   �� 5       � ��$ 5q�60   5      �� 5"   
   "  6   .�5#      ��  � ��
 �����6+    5$      �� 5%       6   �� *
IsSelected+ True6=   .a�5&      ��  � �� �#D6EAF863   5'      5)      �� 5+   
   " ��6+   .�5,      ��  � �� 5-      �� 5.      " ��6&   .R�5/      �� #��z��6!   #��z��50      #��z��51      $	 5��52      $
 5q�6/   $
 Hand��6<   ._�53      �� $��Center=�6/   $��Center=�6L   54      55      57       58      P� 59       �@J�IsMouseOver$
 True��61   . �5:      ��  � �� �#2C3E5063   �� 5;       � ��
 �����63   �� 5<       � ��
 �����64   5=      P� 5>       � ��$
 True��6/   . �5?      ��  � �� �#2980B963   �� 5@       � ��
 �����63   �� 5A       � ��
 ��  �64   5B      5D      �� 5E   
   6'     5F   
   6)     5G   
   6"     5H   
   61   5I      .��5K      �  � ColumnDefinitions 5L   
   �� 5N      $	��250 �6   �� 5P      $��* �6   .+�5S   
   �� $��0��6   ���#2C3E50$
 10q�66    J� Effect 5T      3  -System.Windows.Media.Effects.DropShadowEffect  5U         Color$ Black��6#      ShadowDepth$ 5Q�61   ._�5X      �  � RowDefinitions 5Z      �� 5[      $
��Auto �6$   �� 5]      $��* �6$   �� 5_      $
��Auto �6$   .+�5d      �� $��0��6   .+�5e      �� $
��Menu��6    $��32(�6,   
�������$��Center=�6M   �� 5f      �� 5g      $
 Hand��6   $��45��6+   $��5q�67   $��14(�6B   #��[  6P   .��5h      ��  �� Orientation$ 
Horizontal=�6%   .+�5i      "  FontAwesome.WPF.ImageAwesome     Icon$
 Home=�6.   $��5q�6:   $��22��6E   $
��Left=�6P   $��24��6k   �� 5j      $��Accueil��6(   $��Center=�67   $��Right=�6R   5k      5l      �� 5n      -   5        $
 Hand��5n      $��45��6+   $��5q�67   $��14(�6B   #��[  6P   .��5o      �� $ 
Horizontal=�6%   .+�5p        $ 
PlusSquare=�6.   $��5q�6@   $��22��6K   $
��Left=�6V   $��24��6q   �� 5q      $��Ajouter��6(   $��Center=�67   $��Right=�6R   5r      5s      �� 5t      $��25,0,0,0q�6!   y�63   �� *AjoutVisible+ �� 	Converter# [ .+�5u      �� -   5        $
 Hand��5u   !   $��40��6/   $��5q�6;   $��13(�6F   #��[  6T   
 � Tag$ taches��6�   .��5v      �� $ 
Horizontal=�6)   .+�5w   "     $ Tasks=�62   $��5q�6?   $��20��6J   $
��Left=�6U   $��24��6p   �� 5x   "   $��Nouvelle tâche��6,   $��Center=�6B   $��Right=�6]   5y      5z      �� 5{      -   5        $
 Hand��5{   !   $��40��6/   $��5q�6;   $��13(�6F   #��[  6T   $ employes��6�   .��5|      �� $ 
Horizontal=�6)   .+�5}   "     $
 User=�62   $��5q�6>   $��20��6I   $
��Left=�6T   $��24��6o   �� 5~   "   $��Nouveau employé��6,   $��Center=�6C   $��Right=�6^   5      5�      5�      �� 5�      -   5        $
 Hand��5�      $��45��6+   $��5q�67   $��14(�6B   #��[  6P   .��5�      �� $ 
Horizontal=�6%   .+�5�        $
 List=�6.   $��5q�6:   $��22��6E   $
��Left=�6P   $��24��6k   �� 5�      $��Afficher tableau��6(   $��Center=�6@   $��Right=�6[   5�      5�      �� 5�      $��25,0,0,0q�6!   y�63   �� *AfficherVisible+# [ .+�5�      �� -   5        $
 Hand��5�   !   $��40��6/   $��5q�6;   $��13(�6F   #��[  6T   $ departements��6�   .��5�      �� $ 
Horizontal=�6)   .+�5�   "     $ Building=�62   $��5q�6B   $��20��6M   $
��Left=�6X   $��24��6s   �� 5�   "   $��Liste départements��6,   $��Center=�6F   $��Right=�6a   5�      5�      �� 5�      -   5        $��40��5�   !   $
 Hand��6-   $��5q�6;   $��13(�6F   #��[  6T   $ postes��6�   .��5�      �� $ 
Horizontal=�6)   .+�5�   "     $ 	Briefcase=�62   $��5q�6C   $��20��6N   $
��Left=�6Y   $��24��6t   �� 5�   "   $��Liste postes��6,   $��Center=�6@   $��Right=�6[   5�      5�      �� 5�      -   5        $��40��5�   !   $��5q�6-   $
 Hand��68   $��13(�6F   #��[  6T   $ nations��6�   .��5�      �� $ 
Horizontal=�6)   .+�5�   "     $
 Flag=�62   $��5q�6>   $��20��6I   $
��Left=�6T   $��24��6o   �� 5�   "   $��Liste nations��6,   $��Center=�6A   $��Right=�6\   5�      5�      �� 5�      -   5        $��40��5�   !   $��5q�6-   $
 Hand��68   $��13(�6F   #��[  6T   $ roles��6�   .��5�      �� $ 
Horizontal=�6)   .+�5�   "     $ BlackTie=�62   $��5q�6B   $��20��6M   $
��Left=�6X   $��24��6s   �� 5�   "   $��Liste rôles��6,   $��Center=�6?   $��Right=�6Z   5�      5�      5�      �� 5�      �� 5�      -	   5        $��45��5�      $��5q�6)   $��14(�64   $
 Hand��6B   #��[  6P   .��5�      �� $ 
Horizontal=�6%   .+�5�        $	 Eye=�6.   $��5q�69   $��22��6D   $
��Left=�6O   $��24��6j   �� 5�      $��Suivie��6(   $��Center=�66   $��Right=�6Q   5�      5�      �� 5�      $��25,0,0,0q�6!   y�63   �� *SuiviVisible+# [ .+�5�      �� -
   5        $��40��5�   !   $��5q�6-   $��13(�68   $
 Hand��6F   #��[  6T   $ 
tachesCard��6�   .��5�      �� $ 
Horizontal=�6)   .+�5�   "     $ Tasks=�62   $��5q�6?   $��20��6J   $
��Left=�6U   $��24��6p   �� 5�   "   $��Tâches��6,   $��Center=�6:   $��Right=�6U   5�      5�      �� 5�      -   5        $
 Hand��5�   !   $��40��6/   $��5q�6;   $��13(�6F   #��[  6T   $ employesCard��6�   .��5�      �� $ 
Horizontal=�6)   .+�5�   "     $
 User=�62   $��5q�6>   $��20��6I   $
��Left=�6T   $��24��6o   �� 5�   "   $��	Employés��6,   $��Center=�6<   $��Right=�6W   5�      5�      5�      5�      �� 5�      $��1��6   �� 5�      -   5        $��50��5�      $
 Hand��6%   $��14(�63   #��[  6A   $��2��6�   .��5�      �� $ 
Horizontal=�6!   .+�5�        $ PowerOff=�6*   $��5q�6:   $��24��6E   $
��Left=�6P   $��24��6k   �� 5�      $��Quitter��6$   $��Center=�63   $��Right=�6N   5�      5�      5�      5�      �� 5�   
   $��1��6   $
��Auto=�6'   .��5�      �� $��20q�6   .+�5�      �� $��Liste des employés��6   $��22(�66   $
��Bold"�6D   ���#2C3E50$��Center=�6k   y�6�   �� *EmployesCardVisible+# [ � 5�       � Orientation$ 
Horizontal=�6   $��10q�65   y�6A   �� *EmployesCardVisible+# [ .+�5�      �� ��6#   �� *ListEmployesCard+��5�      �� 5�      .R�5�   "   � $ 
Horizontal=�6,   5�      ��5�      �� 5�      .R�5�   "   �� ���#f2f2f2���#ccc$��1q�6Q   $	��200��6e   $	��180��6q   $	 10��6~   $
 10q�6�   $��5q�6�   ._�5�   &   �� .+�5�   *   �� -   5        
������ $��0q�5�   �   $��Right=�6�    6I   �� *Id+# [  �� ConverterParameter$ employes��.��5�   .   �� $��../Assets/trash-icon.png��64   $��20��6V   $��20��6a   5�   +   A� 5�   *   $��50��62   $��50��6=   
�������$��2��6W   $��Center=�6k   ��5�   .   �� 5�   2    j� Stretch$ UniformToFill=�6�    �� ImageSource 6=   �� *Photo+# [ 6�   5�   +   �� 5�   *   $
��Bold"�6I   ���#2C3E50 �� TextAlignment$ Center=�6p   ��64   �� *Nom+6p   �� 5�   *   
�������$ Center=�6^   ��64   �� *Prenom+6^   �� 5�   *   
���  ��$ Center=�6_   ��64   �� *
NomPoste+6_   �� 5�   *   -   5        $
��Voir��5�   1   #��[  6@   $	��100��6�   $��10,5,0,0q�6�   $��Center=�6�    6�   �� 6�   5�   '   5�   #   5�      5�      5�      �� 5�      $��Liste des tâches��6   $��22(�64   $
��Bold"�6B   ���#2C3E50$��Center=�5�      y�69   �� *TaskVisible+# [ � 5�      $ 
Horizontal=�6   $��10q�65   y�6A   �� *TaskVisible+# [ .+�5�      �� ��6#   �� *Taches+��5�      �� 5�      .R�5�   "   � $ 
Horizontal=�6,   5�      ��5�      �� 5�      .R�5�   "   �� ���#f2f2f2���#ccc$��1q�6Q   $	��200��6e   $	��130��6q   $	 10��6~   $
 10q�6�   $��5q�6�   ._�5�   &   �� .+�5�   *   �� 
������ $��0q�6�   $��Right=�6
  y�61   �� *Statut+# [  6~   �� *Id+# [ $ taches��.��5   .   �� $��../Assets/coche-verte.png��64   $��20��6W   $��20��6b   5  +   �� 5  *   -   5        
������ $��0q�5    $��Right=�6*  y�6I   �� *Statut+# [  6�   �� *Id+# [ $ taches��.��5  .   �� $��../Assets/trash-icon.png��64   $��20��6V   $��20��6a   5  +   �� 5  *   $
��Bold"�6I   ���#2C3E50$ Center=�6p   ��64   �� *Nom+6p   �� 5  *   
�������$ Center=�6f   ��64   �� *DateExpedition+6f   �� 5	  *   
���  ��$ Center=�6_   ��64   �� *
Deadline+6_   �� 5
  *   -   5        $��Détails��5
  1   #��[  6D   $	��100��6�   $��10,5,0,0q�6�   $��Center=�6�    6�   �� 6�   5  '   5  #   5     5     5     �� 5     $��Liste des départements��6   $��22(�6:   $
��Bold"�6H   ���#2C3E50$��Center=�5     y�69   �� *DepartementsVisible+# [ &	   System.Windows.Controls.DataGrid	  5     -   5         	 Name$ DepartementsDataGrid��5      	  AutoGenerateColumns$ False��69    	  CanUserAddRows$ False��6U   $��	0,10,0,30q�5  e   $ 	  HorizontalScrollBarVisibility$
 Auto=�5     "  	  VerticalScrollBarVisibility$
  Auto=�60   y�5     �� *DepartementsVisible+# [  5     ��%    5     ! 	  Columns! 5      0
  *System.Windows.Controls.DataGridTextColumn
  5!     ,  &System.Windows.Controls.DataGridColumn"   Header$	" Nom��6-   #   Width5  /System.Windows.Controls.DataGridLengthConverter$# * 6R   1  +System.Windows.Controls.DataGridBoundColumn$   Binding$ 6:   �� *Nom+6R   5$     �� 5'     $��Liste des postes��6   $��22(�64   $
��Bold"�6B   ���#2C3E50$��Center=�5(     y�69   �� *PostesVisible+# [ 	  5)     -   5        $ PostesDataGrid��5)     $ False��63   $ False��6O   $��	0,10,0,30q�5*  o   y�6   �� *PostesVisible+# [ ! 5+     
  5-     $	" Nom��6-   $	# 400 6R   $ 6:   �� *Nom+6R   
  5.     $" Departement��6-   $# * 6e   $ 6B   �� *NomDepartement+6e   50     �� 53     $��Liste des nations��6   $��22(�65   $
��Bold"�6C   ���#2C3E50$��Center=�54     y�69   �� *NationsVisible+# [ 	  55     -   5        $ NationsDataGrid��55     $ False��64   $ False��6P   $��	0,10,0,30q�56  p   y�6   �� *NationsVisible+# [ ! 57     
  58     $	" Nom��6-   $# * 6R   $ 6:   �� *Nom+6R   
  59     $" Peuple��6-   $	# 400 6X   $ 6=   �� *Peuple+6X   5;     �� 5>     $��Liste des rôles��6   $��22(�63   $
��Bold"�6A   ���#2C3E50$��Center=�5?     y�69   �� *RolesVisible+# [ 	  5@     -   5        $ RolesDataGrid��5@     $ False��62   $ False��6N   $��	0,10,0,30q�5A  n   y�6   �� *RolesVisible+# [ ! 5B     
  5C     $	" Nom��6-   $# * 6R   $ 6:   �� *Nom+6R   5E     �� 5H     $��Liste des employés��6   $��22(�66   $
��Bold"�6D   ���#2C3E50$��Center=�6k   y�6�   �� *EmployesVisible+# [ �� 5I     $ 
Horizontal=�6   $��	950,0,0,0q�66   y�6I   �� *EmployesVisible+# [ .+�5J     �� -   5        % ��Name$% txtRecherche��5J     $	��270��64   $��25��6@   6L   �� 5L     $
��🔍��6    $��18(�6*   $��Center=�68   $��5q�6S   5M     	  5P     -   5        $ EmployesDataGrid��5P     $ False��65   $ False��6x   $��	0,10,0,30q�6�   & 	  CanUserSortColumns$
& True��6�   y�6�   �� *EmployesVisible+# [ ! 5Q     
  5R     $	" Nom��6-   $# * 6R   '   CanUserSort$
' True��6\   $ 6:   �� *Nom+6\   
  5S     $" 
Prénom(s)��6-   $	# 200 6[   $
' True��6g   $ 6@   �� *Prenom+6g   
  5T     $" Poste��6-   $	# 200 6Y   $
' True��6e   $ 6<   �� *
NomPoste+6e   4  .System.Windows.Controls.DataGridTemplateColumn  5U     $" Actions��61   $	# 100 6B   (   CellTemplate( 5V     �� 5W  "   .R�5X  &   �� -   5        
������ $��0q�5Y  F    5X  E   �� *Id+# [ $ employes��.��5Z  *   �� $��../Assets/trash-icon.png��60   $��20��6R   $��20��6]   5[  '   5\  #   5^     5`     5b     5c     5d     5e     