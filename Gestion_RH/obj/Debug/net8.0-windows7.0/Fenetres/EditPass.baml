   M S B A M L   `   `   `  ����E  AGestion_RH, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:Gestion_RH.FenetresGestion_RH.Fenetres  5   	   "    Gestion_RH.Fenetres.EditPass   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   3local!clr-namespace:Gestion_RH.Fenetres     5   	     � Title$  Edit Password��5   	    � SizeToContent$ WidthAndHeight=�5	   	    � WindowStartupLocation$ CenterScreen=�5
   	    � 	Resources 5         RoundedButtonStyle �� 
TargetType �� Property �� Value �� 
TargetType �� CornerRadius	 � Cursor
 �� Padding �� Triggers P� Property P� Value��%�  &	        �� 5   
   " ��6+   .�5      ��  � �� 5      �� 5      " ��6&   .R�5      �� #��z��5      #��z��5      $ 5��5      $
	 Hand��6+   $
 5q�6:   ���#2980B9._�5      �� $��Center=�6/   $��Center=�6L   5      5      5       5      P� 5       �@J�IsMouseOver$
 True��61   . �5      ��  � �� �#2C3E5063   �� 5       � ��
 �����63   �� 5       � ��
 �����64   5      P� 5        � ��$
 True��6/   . �5!      ��  � �� �#2980B963   �� 5"       � ��
 �����63   �� 5#       � ��
 ��  �64   5$      5&      5'      .��5)      � .+�5*   
   �� $
��Auto=�6   .��5+      �� 
�������$ 15��6(   $
 20q�6:   $��20q�6G   ���#D1D1D1$��1q�6i    J� Effect 5,      3  -System.Windows.Media.Effects.DropShadowEffect  5-         Color$ Black��6'      
BlurRadius$ 10Q�65      ShadowDepth$ 5Q�6E   ._�50      �� .+�52      �� $!��Modifier votre mot de passe��6    $��22(�6C   $
��Bold"�6Q   ���#2C3E50$��Center=�53   !   $
��0,20q�6>   A� 56       A� Columns$ 2��6"   $��Center=�6.   $��10q�6K   $	��650��6W   .+�59      ��  �� Orientation$ 
Horizontal=�6%   $��5q�6>   .+�5:      �� $
��🆔��6(   $��18(�62   $��Center=�6@   �� 5;      $��Mot de passe actuel :��6(   $
��Bold"�6E   $��5,5,0,0q�6W   5<      G� 5=      -   5         G�Name$ 
OldPassBox��5=   &   $��30��6:   $	��300��6F   $��5q�6R   �� 5?      $ 
Horizontal=�6%   $��5q�6>   .+�5@      �� $
��🆔��6(   $��18(�62   $��Center=�6@   �� 5A      $��Nouveau mot de passe :��6(   $
��Bold"�6F   $��5,5,0,0q�6X   5B      G� 5C      -   5        $ 
NewPassBox��5C   &   $��30��6:   $	��300��6F   $��5q�6R   �� 5E      $ 
Horizontal=�6%   $��5q�6>   .+�5F      �� $
��🆔��6(   $��18(�62   $��Center=�6@   �� 5G      $)��#Confirmer le nouveau mot de passe :��6(   $
��Bold"�6S   $��5,5,0,0q�6e   5H      G� 5I      -   5        $ NewPassConfBox��5I   &   $��30��6>   $	��300��6J   $��5q�6V   5K      � 5L       � ColumnDefinitions 5M      �� 5N      $
��Auto �6/   �� 5O      $��* �6/   .+�5R      �� -   5        $��0��5R   !   
�������#��[  6D   $��Réinitialiser��6q   $��10,10,10,10q�6�   $��30��6�   $	��200��6�   $
��Left=�6�   �� 5T      -   5        $��1��5T   !   
�������#��[  6D   $��Enregistrer��6q   $��10,10,10,10q�6�   $��30��6�   $	��200��6�   $��Right=�6�   5U      5V      5Y      5Z      5[      5\      