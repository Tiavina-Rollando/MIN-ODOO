   M S B A M L   `   `   `  ����E  AGestion_RH, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:Gestion_RH.FenetresGestion_RH.Fenetres  5   	   &     Gestion_RH.Fenetres.RequestConge   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   3local!clr-namespace:Gestion_RH.Fenetres     5   	     � Title$  Demande de congé��5   	    � SizeToContent$ WidthAndHeight=�5	   	    � WindowStartupLocation$ CenterScreen=�5
   	   ���#F0F0F0 � 	Resources 5         RoundedButtonStyle �� 
TargetType �� Property �� Value �� 
TargetType �� CornerRadius	 � Cursor
 �� Padding �� Triggers P� Property P� Value��%�  &	        �� 5   
   " ��6+   .�5      ��  � �� 5      �� 5      " ��6&   .R�5      �� #��z��5      #��z��5      $ 5��5      $
	 Hand��6.   $
 5q�6<   ���#2980B9._�5      �� $��Center=�6/   $��Center=�6L   5      5      5       5      P� 5       �@J�IsMouseOver$
 True��61   . �5      ��  � �� �#2C3E5063   �� 5        � ��
 �����63   �� 5!       � ��
 �����64   5"      P� 5#       � ��$
 True��6/   . �5$      ��  � �� �#2980B963   �� 5%       � ��
 �����63   �� 5&       � ��
 ��  �64   5'      5)      5*      .��5,      � .+�5-   
   �� $
��Auto=�6   .��5.      �� 
�������$ 15��6(   $
 30q�6:   $��30q�6G   ���#D1D1D1$��1q�6i    J� Effect 5/      3  -System.Windows.Media.Effects.DropShadowEffect  50         Color$ Black��6'      
BlurRadius$ 10Q�65      ShadowDepth$ 5Q�6E   ._�53      �� .+�55      �� $��Demande de congé��6    $��22(�68   $
��Bold"�6F   ���#2C3E50$��Center=�56   5   $��	0,10,0,30q�6R   �� 59      -   5         ��Name$ 
EtapeMotif��59   !   $y�Visible=�65   $��0,0,0,20q�6J   .+�5:      �� $%��Choisissez le motif du congé :��6$   $
��Bold"�6J   $��0,0,0,10q�6\   �� 5;      -   5         ��Name$ MotifComboBox��5;   #   $��35��6:   $	��300��6F   .@�5<      �� $��Congé annuel��6+   �� 5=      $��Congé maladie��6+   �� 5>      $$��Congé maternité / paternité��6+   �� 5?      $��Congé exceptionnel��6+   �� 5@      $��Congé sans solde��6+   �� 5A      $��Autres��6+   5B      �� 5C      -   5        $��Suivant��5C   !   #��[  63   
�������$��0,20,0,0q�5D   <   $	��150��6N   $��35��6Z   $��Right=�6f   5E      �� 5H      -   5        $ 
EtapeDebut��5H   !   $y�	Collapsed=�65   $��0,0,0,20q�6L   .+�5I      �� $'��!Sélectionnez la date de début :��6$   $
��Bold"�6K   $��0,0,0,10q�6]   (  "System.Windows.Controls.DatePicker  5J      -   5          Name$ DateDebutPicker��5J   %   $	��200��6>   �� 5K      -   5        $��Suivant��5K   !   #��[  63   
�������$��0,20,0,0q�5L   <   $	��150��6N   $��35��6Z   $��Right=�6f   5M      �� 5P      -   5        $ EtapeFin��5P   !   $y�	Collapsed=�63   .+�5Q      �� $$��Sélectionnez la date de fin :��6$   $
��Bold"�6I   $��0,0,0,10q�6[     5R      -   5        $ DateFinPicker��5R   %   $	��200��6<   �� 5S      -	   5        $��Envoyer��5S   !   #��[  63   
�������$��0,20,0,0q�5T   8   $	��150��6J   $��35��6V   $��Right=�6b   5U      5W      5X      5Y      5Z      5[      