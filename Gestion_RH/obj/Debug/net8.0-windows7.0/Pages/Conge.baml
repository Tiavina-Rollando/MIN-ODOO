   M S B A M L   `   `   `  ����E  AGestion_RH, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:Gestion_RH.PagesGestion_RH.Pages  5      =#clr-namespace:Gestion_RH.ConvertersGestion_RH.Converters  5      =#clr-namespace:Gestion_RH.ViewModelsGestion_RH.ViewModels  5	      [ WLiveChartsCore.SkiaSharpView.WPF, Version=2.0.0.0, Culture=neutral, PublicKeyToken=null}Xclr-namespace:LiveChartsCore.SkiaSharpView.WPF;assembly=LiveChartsCore.SkiaSharpView.WPF LiveChartsCore.SkiaSharpView.WPF 5      W SLiveChartsCore.SkiaSharpView, Version=2.0.0.0, Culture=neutral, PublicKeyToken=nullqPclr-namespace:LiveChartsCore.SkiaSharpView;assembly=LiveChartsCore.SkiaSharpViewLiveChartsCore.SkiaSharpView 5      I ELiveChartsCore, Version=2.0.0.0, Culture=neutral, PublicKeyToken=nullG4clr-namespace:LiveChartsCore;assembly=LiveChartsCoreLiveChartsCore 5          Gestion_RH.Pages.Conge   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      0localclr-namespace:Gestion_RH.Pages     5      4conv#clr-namespace:Gestion_RH.Converters     5      4view#clr-namespace:Gestion_RH.ViewModels     5	      Z	 VFontAwesome.WPF, Version=4.7.0.37774, Culture=neutral, PublicKeyToken=0758b07a11a4f466-fa$http://schemas.fontawesome.io/icons/ 	 5
      blvcXclr-namespace:LiveChartsCore.SkiaSharpView.WPF;assembly=LiveChartsCore.SkiaSharpView.WPF 	 5      [lvc1Pclr-namespace:LiveChartsCore.SkiaSharpView;assembly=LiveChartsCore.SkiaSharpView 	 5      ?lvcw4clr-namespace:LiveChartsCore;assembly=LiveChartsCore 	 5        N� Title$  Conge��5       � 	Resources 5         ShowNotificationPanel �� 
TargetName �� TargetProperty W� From	 W� To g� Duration  HideNotificationPanel  NoHoverButtonStyle �� 
TargetType �� Property	 �� Value
 �� 
TargetType=  7System.Windows.Controls.Primitives.DataGridColumnHeader*  $System.Windows.Controls.DataGridCell)  #System.Windows.Controls.DataGridRow �� Triggers �� Binding �� Value  RoundedButtonStyle �� CornerRadius �� Padding P� Property P� Value��%�  &	        &	     &	 2    '  G    '  +    '  ,    &	 �    �� 5   
   .��5      W� $ NotificationPanel��6   $ Opacity�5       05       16#   $ 0:0:0.3D�6*   W� 5      $ NotificationPanel��6   $, &RenderTransform.(TranslateTransform.Y)�5       -205       06%   $ 0:0:0.3D�6,   5      �� 5   
   .��5      W� $ NotificationPanel��6   $ Opacity�5       15       06   $ 0:0:0.3D�6&   W� 5      $ NotificationPanel��6   $, &RenderTransform.(TranslateTransform.Y)�5       05        -206   $ 0:0:0.3D�6(   5!      �� 5#   
   " ��6+   .�5$      ��  � ��
	 ���� 6+   �� 5%       � ��
	 ���� 6,   �� 5&       � ��$	 0q�60   �� 5'       � ��	 5(      �� 5)      "
 ��6&   .R�5*      �� $��Center=�6+   $��Center=�6H   5+      5-      5.      �� 50   
   "  6   .�51      ��  � ��	 �#0033666+   �� 52       � ��
	 �����6+   �� 53       � ��$	 16(�6)   �� 54       � ��$	 40��6'   �� 55       � ��$	 Center=�6;   56      �� 59   
   "  6   .�5:      ��  � ��$	 10q�6(   �� 5;       � ��$	 16(�6)   �� 5<       � ��
	 �   �6+   �� 5=       � ��
	 �����6+   �� 5>       � ��
	 �����6,   �� 5?       � ��$	 5q�60   5@      �� 5C   
   "  6   .�5D      ��  � ��
	 �����6+    5E      �� 5F       6   �� *
IsSelected+ True6=   .a�5G      ��  � ��	 �#D6EAF863   5H      5J      �� 5M   
   " ��6+   .�5N      ��  � ��	 5O      �� 5P      "
 ��6&   .R�5Q      �� #��z��6!   #��z��5R      #��z��5S      $ 5��5T      $ 5q�6+   ._�5U      �� $��Center=�6/   $��Center=�6L   5V      5W      5Y       5Z      P� 5[       �@J�IsMouseOver$
 True��61   . �5\      ��  � ��
	 ���� 63   �� 5]       � ��
	 �����63   �� 5^       � ��
	 �����64   5_      P� 5`       � ��$
 True��6/   . �5a      ��  � ��	 �#2980B963   �� 5b       � ��
	 �����63   �� 5c       � ��
	 ��  �64   5d      5f      5g      .��5i      �  � ColumnDefinitions 5k   
   �� 5m      $
��Auto �6   �� 5o      $��* �6   .+�5q   
   �� -   5         ��Name$ 	MenuPanel��5q      $y�Visible=�6$   $��0��69   $ 10q�6I   ��5r      �� 5s       �� ImageSource$ ../Assets/backrgound1.jpg��6   6G    J� Effect 5u      3  -System.Windows.Media.Effects.DropShadowEffect  5v         Color$ Black��6#      ShadowDepth$ 5Q�61   ._�5x      �  � RowDefinitions 5z      �� 5{      $
��Auto �6$   �� 5}      $��* �6$   �� 5      $
��Auto �6$   .+�5�      �� $��0��6   .+�5�      �� -   5         � Cursor$
 Hand��5�      $��45��6+   $��5q�6V   $��14(�6a   #��[ 6o   .��5�      ��  �� Orientation$ 
Horizontal=�6%   .+�5�      " 	 FontAwesome.WPF.ImageAwesome     Icon$
 Bell=�6.   $��5q�6:   $��22��6E   $
��Left=�6P   $��24��6k   �� 5�      $��Notification��6(   $��Center=�6<   $��Right=�6W   5�      5�      �� 5�      &   System.Windows.Controls.Calendar  5�      -   5        $��calConge��5�      6/   �� 5�      5�      �� 5�      $��1��6   �� 5�      -   5        $
 Hand��5�      $��45��6'   $��5q�63   $��14(�6>   #��[ 6L   $��2��6�   .��5�      �� $ 
Horizontal=�6!   .+�5�        $ ArrowCircleLeft=�6*   $��5q�6A   $��22��6L   $
��Left=�6W   $��24��6r   �� 5�      $��Retour��6$   $��Center=�62   $��Right=�6M   5�      5�      5�      5�      �� 5�   
   $��1��6   $
��Auto=�6'   $y�Visible=�6J   ���#ecf0f1.��5�      �� .+�5�      � -   5         �Name$
 View��5�      $y�	Collapsed=�6%   .+�5�      � $��Center=�6    .+�5�      �� $ Vertical=�6%   $��0,0,20,0q�6<   $	��Top=�6N   .+�5�      �� $ 
Horizontal=�6)   $��Center=�6B   .+�5�   "   �� -   5        $	��150��5�   =   
���/���
�������$��50��6t   $��20(�6�   $��2q�6�   
�������#��[ 6�   $��10q�6�   .��5�   &   �� $��🟢 Approuver��60   5�   #   �� 5�   "   -   5        $	��150��5�   @   $��50��6L   
���\\��
�������$��20(�6�   $��2q�6�   
�������#��[ 6�   $��10q�6�   .��5�   &   �� $��⛔ Refuser��60   5�   #   5�      �� 5�      ���#dcdcdc$	��570��6:   $	��300��6F   $ 20��6S   $��20q�6e   ���#ccc$��1q�6�    5�   "     5�   &   $ Black��67      
BlurRadius$ 10Q�6E   $ 5Q�6U   ._�5�   "   �� .+�5�   &   �� $"��📋 À propos de la demande��60   $��24(�6Q   $��Center=�6_   $��Center=�6z   5�   #   5�      5�      �� 5�      ���#fae5d3$��0,65,0,0q�66   $ 20��6H   ���#ccc$��1q�6m   $	��570��6�   $	��300��6�    5�        5�   "   $ Black��63   $ 10Q�6A   $ 5Q�6Q   ._�5�      �� $��Center=�6)   .+�5�   "   �� $!��🏖️ Congés de l'année��6,   $��16(�6I   $��Center=�6W   $��Center=�6r   5  /LiveChartsCore.SkiaSharpView.WPF.CartesianChart  5�   "   $	��200��5�   %   $	��500��5�   %      Series 5�   %   �� *
LineSeries+   XAxes 5�   %   �� *XAxesL+    YAxes  5�   %   �� *YAxesL+5�   %   5�      5�      �� 5�      
�������$ 20��64   $��20q�6F   ���#ccc$��1q�6e   $	��570��6y   $	��300��6�    5�        5�   "   $ Black��63   $ 10Q�6A   $ 5Q�6Q   ._�5�      �� $��Center=�6)   .+�5�   "   �� $+��%✅ Présences / Absences de l'année��6,   $��16(�6U   $��Center=�6c   $��Center=�6~   /  )LiveChartsCore.SkiaSharpView.WPF.PieChart  5�   "   $	��200��6L   $	��500��6Y   !   Series! 6/   �� *	PieSeries+6Y   5�      5�      �� 5�      ���#9caf88$	��570��66   $	��300��6B   $ 20��6O   $��20q�6a   ���#ccc$��1q�6�    5�        5�   "   $ Black��63   $ 10Q�6A   $ 5Q�6Q   ._�5�      �� .+�5�   "   �� $-��'📋 Tâche à livrer dans l'intervalle��6,   $��24(�6W   $��Center=�6e   $��Center=�6�   �� 5�   "   -   5        " ��Name$" ChecklistTasksBox��5�   *   $��10q�6E   $��20(�6Q   
������ ��5�   &   �� 5�   *   .R�5�   .   �� ��67   �� *Nom+# d� 	IsChecked# 6O   �� *Statut+5�   +   5�   #   5�      5�      �� 5�      ���#eacbd2$ 20��66   $��20q�6H   ���#ccc$��1q�6g   $	��570��6{   $	��300��6�    5�        5�   "   $ Black��63   $ 10Q�6A   $ 5Q�6Q   ._�5�      �� .+�5�   "   �� $+��%📅 Congés prévus du département ��6,   $��24(�6T   $��Center=�6b   $��Center=�6}   �� 5�   "   -	   5        $" ChecklistCongesBox��5�   *   $��10q�6F   $��0q�6R   $��20(�6f   
������ ��6�   �� *ListeDesNoms+��5�   &   �� 5�   *   .R�5�   .   �� ��68   �� 5�   +   5�   #   5�      5�      �� 5�      ���#cde4f2$ 20��66   $��20q�6H   ���#ccc$��1q�6g   $	��570��6{   $	��300��6�    5�        5�   "   $ Black��63   $ 10Q�6A   $ 5Q�6Q   ._�5�      �� .+�5�   "   �� $$��👥  Membres du département ��6,   $��24(�6O   $��Center=�6]   $��Center=�6x   �� 5�   "   -
   5        $" ChecklistMembreBox��5�   *   $��10q�6F   $��0q�6R   $��20(�6f   
������ ��6�   �� *ListeDesNoms+��5�   &   �� 5�   *   .R�5�   .   �� ��68   �� 5�   +   5�   #   5�      5�      5�      5�      �� 5     $��Historique des congés��6   $��22(�69   $
��Bold"�6G   ���#2C3E50$��Center=�6n   y�6�   �� *CongesVisible+  BoolToVisConverter$ �� 	Converter#$ [ &	   System.Windows.Controls.DataGrid	  5     -   5        % 	 Name$% CongesDataGrid��5     & 	  AutoGenerateColumns$& False��63   ' 	  CanUserAddRows$' False��6P   $
��0,10q�6�   ( 	  CanUserSortColumns$
( True��6�   y�6g   �� *CongesVisible+#$ [ ) 	  Columns) 5     0
  *System.Windows.Controls.DataGridTextColumn
  5     ,  &System.Windows.Controls.DataGridColumn*   Header$* Motif��6-   +   Width5  /System.Windows.Controls.DataGridLengthConverter$	+ 300 6V   ,   CanUserSort$
, True��6b   1  +System.Windows.Controls.DataGridBoundColumn-   Binding- 6<   �� *Motif+6b   
  5     $* Date début��6-   $	+ 115 6|   $
, True��6�   - 6A   �� *Debut+. �� StringFormat$. {0:dd/MM/yyyy}��6�   
  5     $* Date fin��6-   $	+ 115 6x   $
, True��6�   - 6?   �� *Fin+$. {0:dd/MM/yyyy}��6�   
  5	     $* 	Titulaire��6-   $+ * 6_   $
, True��6i   - 6@   �� *
NomEmploye+6i   4  .System.Windows.Controls.DataGridTemplateColumn  5
     $* Statut��61   $	+ 200 6A   /   CellTemplate/ 5     �� 5  "   .R�5  &   �� $ 
Horizontal=�62   $��Center=�6K   $��Center=�6h   .+�5  *   �� $��20��60   $��20��6;   $
��Left=�6G   ��5  .   �� 5  2   " ��68   .�5  6   ��  � ��$	 ../Assets/en-cours.png��6O    5  6   �� 5  :    6F   �� *Statut+ Terminé6a   .a�5  >   ��  � ��$	 ../Assets/coche-verte.png��6W   5  ;   �� 5  :    6F   �� *Statut+ À venir6a   .a�5  >   ��  � ��$ 	 ../Assets/notification.png��6W   5  ;   5  3   5  +   �� 5  *   $��Center=�6L   
���   ���64   �� *Statut+6i   5  '   5  #   5!     5#     �� 5%     $��Historique des demandes��6   $��22(�6;   $
��Bold"�6I   ���#2C3E50$��Center=�6p   y�6�   �� *DemandesVisible+#$ [ 	  5'     -   5        $% DemandesDataGrid��5'     $& False��65   $' False��6R   $
��0,10q�6�   $
( True��6�   y�6i   �� *DemandesVisible+#$ [ ) 5(     
  5)     $* Date envoye��6-   $	+ 115 6~   $
, True��6�   - 6B   �� *Envoye+$. {0:dd/MM/yyyy}��6�   
  5*     $* Motif��6-   $	+ 300 6V   $
, True��6b   - 6<   �� *Motif+6b   
  5+     $* Date début��6-   $	+ 115 6|   $
, True��6�   - 6A   �� *Debut+$. {0:dd/MM/yyyy}��6�   
  5,     $* Date fin��6-   $	+ 115 6x   $
, True��6�   - 6?   �� *Fin+$. {0:dd/MM/yyyy}��6�   
  5-     $* 	Titulaire��6-   $+ * 6_   $
, True��6i   - 6@   �� *
NomEmploye+6i     5.     $* Statut��61   $	+ 200 6A   / 5/     �� 50  "   .R�51  &   �� $ 
Horizontal=�61   $��Center=�6J   $��Center=�6g   .+�52  *   �� $��20��60   $��20��6;   ��6G   �� *StatutImage+�� 53  *   $��Center=�6P   
���   ���64   �� *
TextStatut+6m   54  '   55  #   57     59     5:     5;     �� 5=  
   -   5        0 ��Name$0 NotificationPanel��5=     $��0��62   $
��Auto=�6B   $y�	Collapsed=�6e   1 J� Opacity$1 0Q�6|   2 J� RenderTransformOrigin$2 0.5,0&�6�   z�5>     T� 5?     3 T� Y$	3 -20Q�6%   .��5B     �� $ 10q�6   ��5C     �� 5D     $ ../Assets/backrgound1.jpg��6!   6K    5F       5G     $ Black��6'   $ 5Q�65   ._�5I     �� .+�5J     �� -   5        $
 Hand��5J     $��45��6+   $��5q�67   #��[ 6B   .��5K     �� $ 
Horizontal=�6%   .+�5L       $ ArrowCircleLeft=�6.   $��5q�6E   $��22��6P   $
��Left=�6[   $��24��6v   5M     5N     �� 5O     $��Demandes��6    $��32(�60   
�������$��Center=�6Q   �� 5Q     � 5R     4 � Orientation$4 Vertical=�6    $��10q�67   .+�5S     �� ��6'   �� *
Demandes+��5T     �� 5U  "   .R�5V  &   � $4 Vertical=�60   5W  #   ��5Y     �� 5Z  "   .R�5[  &   �� ���#f2f2f2���#ccc$��1q�6U   $	��200��6i   $	��110��6u   $ 10��6�   $ 10q�6�   $��5q�6�   ._�5\  *   �� .+�5]  .   �� $
��Bold"�6P   ���#2C3E505 �� TextAlignment$5 Center=�6w   ��68   �� *Motif+6w   �� 5^  .   
�������$5 Center=�6g   ��68   �� *
NomEmploye+6g   �� 5_  .   
���  ��$5 Center=�6�   ��68   �� *Envoye+$. {0:dd/MM/yyyy}��6�   �� 5`  .   -   5        $
��Voir��5`  5   #��[ 6E   $	��100��6q   $��10,5,0,0q�6�   $��Center=�6�   
6 � Tag6 6}   �� 6�   5a  +   5b  '   5c  #   5e     5f     5g     5h     5i     5j     5k     