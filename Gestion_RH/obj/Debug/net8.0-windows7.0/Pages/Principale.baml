   M S B A M L   `   `   `  ����E  AGestion_RH, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:Gestion_RH.ConvertersGestion_RH.Converters  5      =#clr-namespace:Gestion_RH.ViewModelsGestion_RH.ViewModels  5      [ WLiveChartsCore.SkiaSharpView.WPF, Version=2.0.0.0, Culture=neutral, PublicKeyToken=null}Xclr-namespace:LiveChartsCore.SkiaSharpView.WPF;assembly=LiveChartsCore.SkiaSharpView.WPF LiveChartsCore.SkiaSharpView.WPF 5	      W SLiveChartsCore.SkiaSharpView, Version=2.0.0.0, Culture=neutral, PublicKeyToken=nullqPclr-namespace:LiveChartsCore.SkiaSharpView;assembly=LiveChartsCore.SkiaSharpViewLiveChartsCore.SkiaSharpView 5
      I ELiveChartsCore, Version=2.0.0.0, Culture=neutral, PublicKeyToken=nullG4clr-namespace:LiveChartsCore;assembly=LiveChartsCoreLiveChartsCore 5      !    Gestion_RH.Pages.Principale   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      4conv#clr-namespace:Gestion_RH.Converters     5      4view#clr-namespace:Gestion_RH.ViewModels     5      Z	 VFontAwesome.WPF, Version=4.7.0.37774, Culture=neutral, PublicKeyToken=0758b07a11a4f466-fa$http://schemas.fontawesome.io/icons/ 	 5      blvcXclr-namespace:LiveChartsCore.SkiaSharpView.WPF;assembly=LiveChartsCore.SkiaSharpView.WPF 	 5	      [lvc1Pclr-namespace:LiveChartsCore.SkiaSharpView;assembly=LiveChartsCore.SkiaSharpView 	 5
      ?lvcw4clr-namespace:LiveChartsCore;assembly=LiveChartsCore 	 5        N� Title$  
Principale��5       � 	Resources 5      =  7System.Windows.Controls.Primitives.DataGridColumnHeader �� 
TargetType �� Property �� Value*  $System.Windows.Controls.DataGridCell)  #System.Windows.Controls.DataGridRow �� Triggers �� Binding �� Value   RoundedButtonStyle �� 
TargetType	 �� CornerRadius
 �� Padding � Cursor P� Property P� Value  BoolToVisConverter5   /Gestion_RH.Converters.ByteArrayToImageConverter  ByteArrayToImageConverter.   (Gestion_RH.Converters.TagFormatConverter  TagFormatConverter=   7Gestion_RH.Converters.BoolToVisibilityInvertedConverter  BoolToVisInvertedConverter��%�  '        '  �     '  �    &	  �    &	 *    &	 =    &	 P    &	 c    �� 5   
   "  6   .�5      ��  � �� �#2C3E506+   �� 5       � ��
 �����6+   �� 5       � ��$ 16(�6)   �� 5       � ��$ 40��6'   �� 5       � ��$ Center=�6;   5      �� 5   
   "  6   .�5      ��  � ��$ 10q�6(   �� 5       � ��$ 16(�6)   �� 5       � ��
 �   �6+   �� 5       � ��
 �����6+   �� 5        � ��
 �����6,   �� 5!       � ��$ 5q�60   5"      �� 5%   
   "  6   .�5&      ��  � ��
 �����6+    5'      �� 5(       6   �� *
IsSelected+ True6=   .a�5)      ��  � �� �#D6EAF863   5*      5,      �� 5.   
   " ��6+   .�5/      ��  � �� 50      �� 51      " ��6&   .R�52      �� #��z��6!   #��z��53      #��z��54      $	 5��55      $
 5q�6/   $
 Hand��6<   ._�56      �� $��Center=�6/   $��Center=�6L   57      58      5:       5;      P� 5<       �@J�IsMouseOver$
 True��61   . �5=      ��  � ��
 ���� 63   �� 5>       � ��
 �����63   �� 5?       � ��
 �����64   5@      P� 5A       � ��$
 True��6/   . �5B      ��  � �� �#2980B963   �� 5C       � ��
 �����63   �� 5D       � ��
 ��  �64   5E      5G      �� 5H   
   6'     5I   
   6)     5J   
   6"     5K   
   61   5L      .��5P      � ���#F8F8F8 � RowDefinitions 5Q   
   �� 5R      $
��Auto �6   �� 5S      $��* �6   .+�5W   
   �� $��0��6   ��5X      �� 5Y       �� ImageSource$ ../Assets/backrgound1.jpg��6   6G    J� Effect 5[      3  -System.Windows.Media.Effects.DropShadowEffect  5\         Color$ Black��6#      ShadowDepth$ 5Q�61   ._�5^      ]� $��False��6   .+�5_      �� -   5        $��BienvenuText��5_      $��24(�60   $
��Bold"�6>   
�������$
��30,0q�6c   $��Center=�6q   A� 5a      $��50��6   $��50��6%   
�������$��2��6?   $��Right=�5b      $��Right=�6   ��5c      �� 5d      -   5        
PhotoBrush�� j� Stretch$ UniformToFill=�5d   9   5f      5g      5h      � 5l   
   $��1��6   $��20q�6    � ColumnDefinitions 5m      �� 5n      $	��300 �6#   �� 5o      $��* �6#   .+�5r      �� $��0��6   ��5s      �� 5t      $ ../Assets/backrgound1.jpg��6!   6K    5v        5w      $ Black��6'   $ 5Q�65   ._�5z      �  5{      �� 5|      $
��Auto �6(   �� 5~      $��* �6(   �� 5�      $
��Auto �6(   .+�5�      �� $��0��6!   $��0��62   $	��Top=�6?   .+�5�      �� -   5        $
 Hand��5�   !   $��45��6/   $��5q�6;   $��14(�6Y   #��[  6g   .��5�      �� $��🏠 Accueil��6(   $��Center=�6:   $��Right=�6U   5�      �� 5�      -   5        $
 Hand��5�   !   $��45��6/   $��5q�6;   $��14(�6b   #��[  6p   .��5�      �� $��📅 Demande de congé��6(   $��Center=�6C   $��Right=�6^   5�      �� 5�      -   5        $
 Hand��5�   !   $��45��6/   $��5q�6;   $��14(�6c   #��[  6q   .��5�      �� $��📄 Consulter bulletins��6(   $��Center=�6F   $��Right=�6a   5�      �� 5�      -   5        $
 Hand��5�   !   $��45��6/   $��5q�6;   $��14(�6c   #��[  6q   .��5�      �� $��🧾 Mes tâches��6(   $��Center=�6=   $��Right=�6X   5�      5�      �� 5�      $��1��6!   �� 5�      $��2��6!   .+�5�      �� -   5        $
 Hand��5�   !   $��45��6/   $��5q�6;   $��14(�6_   #��[  6m   .��5�      �� $ ��🔒 Modifier mot de passe��6(   $��Center=�6H   $��Right=�6c   5�      �� 5�      -   5        $
 Hand��5�   !   $��45��6/   $��5q�6;   $��14(�6\   #��[  6j   .��5�      �� $��🚪 Déconnexion��6(   $��Center=�6>   $��Right=�6Y   5�      5�      5�      5�      � 5�      $��1��6   ���#ecf0f1.+�5�      �� -	   5        $��ListTask��5�      $y�	Collapsed=�6-   .+�5�      �� $��Liste de mes tâches��6    $��22(�6;   $
��Bold"�6I   ���#2C3E50$��Center=�6p   $��10q�6�   �� 5�      $
��Auto=�6#   $
��Auto=�6H   .��5�      �� -
   5         ��Name$
 card��5�   '   ��5�      �� 5�   "   .R�5�   &   �  � Orientation$ 
Horizontal=�60   5�   #   ��5�      �� 5�   "   .R�5�   &   �� ���#f2f2f2���#ccc$��1q�6U   $	��200��6i   $��70��6u   $	 10��6�   $
 10q�6�   $��5q�6�   $
 Hand��6�   ._�5�   *   �� .+�5�   .   �� $
��Bold"�6M   ���#2C3E50 �� TextAlignment$ Center=�6t   ��68   �� *Nom+6t   �� 5�   .   
�������$ Center=�6�   ��68   �� *DateExpedition+ �� StringFormat$ {0:dd/MM/yyyy}��6�   �� 5�   .   
���  ��$ Center=�6�   ��68   �� *
Deadline+$ {0:dd/MM/yyyy}��6�   5�   +   5�   '   5�   #   5�      5�      5�      � 5�      -   5        $
��Page��5�      $y�Visible=�6(   $ 
Horizontal=�6=   $��Center=�6V   $��Center=�6s   .+�5�      �� ���#fae5d3$	 20��62   $��20q�6D   ���#ccc$��1q�6c   $	��500��6w   $	��300��6�    5�        5�      $ Black��6/      
BlurRadius$ 10Q�6=   $ 5Q�6M   ._�5�      �� $��Center=�6%   .+�5�      �� $)��#🏖️ Congés restants : 10 jours��6(   $��16(�6N   $��Center=�6\   $��Center=�6w   5  /LiveChartsCore.SkiaSharpView.WPF.CartesianChart  5�      $	��200��5�   !   $	��500��5�   !      Series 5�   !   �� *ColumnSeries+   XAxes 5�   !   �� *XAxesC+   YAxes 5�   !   �� *YAxesC+5�   !   5�      5�      �� 5�      ���#aeb6bf$	 20��63   $��20q�6E   ���#ccc$��1q�6d   $	��500��6x   $	��300��6�    5�        5�      $ Black��6/   $ 10Q�6=   $ 5Q�6M   ._�5�      �� $��Center=�6%   .+�5�      �� $��📊 Statistique de paie��6(   $��16(�6F   $��Center=�6T   $��Center=�6o     5�      $	��200��5�   !   $	��500��5�   !    5�   !   �� *
LineSeries+ 5�   !   �� *XAxesL+ 5�   !   �� *YAxesL+5�   !   5�      5�      �� 5�      
�������$	 20��60   $��20q�6B   ���#ccc$��1q�6a   $	��500��6u   $	��300��6�    5�        5�      $ Black��6/   $ 10Q�6=   $ 5Q�6M   ._�5�      �� $��Center=�6%   .+�5�      �� $6��0✅ Statistique de présences / absences du mois��6(   $��16(�6]   $��Center=�6k   $��Center=�6�   /	  )LiveChartsCore.SkiaSharpView.WPF.PieChart	  5�      $	��200��6H   $	��500��6U    	  Series 6+   �� *	PieSeries+6U   5�      5�      �� 5�      ���#a9cce3$	 20��63   $��20q�6E   ���#ccc$��1q�6d   $	��500��6x   $	��300��6�    5�        5�      $ Black��6/   $ 10Q�6=   $ 5Q�6M   ._�5�      �� .+�5�      �� $)��#📅 Tâche à livrer cette semaine��6(   $��24(�6O   $��Center=�6]   $��Center=�6x   �� 5�      -   5         ��Name$ ChecklistTasksBox��5�   &   $��10q�6A   $��20(�6M   
������ ��5�   "   �� 5�   &   .R�5�   *   �� ��63   �� *Nom+ d� 	IsChecked 6K   �� *Statut+5�   '   5�      5�      5�      5�      5�      5�      5�      5�      