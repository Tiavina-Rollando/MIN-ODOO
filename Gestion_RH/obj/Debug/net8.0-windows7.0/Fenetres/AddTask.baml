   M S B A M L   `   `   `  ����E  AGestion_RH, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:Gestion_RH.FenetresGestion_RH.Fenetres  5   	   !    Gestion_RH.Fenetres.AddTask   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   3local!clr-namespace:Gestion_RH.Fenetres     5   	     � Title$  AddTask��5   	    � SizeToContent$ WidthAndHeight=�5	   	    � 	Resources 5
         RoundedButtonStyle �� 
TargetType �� Property �� Value �� 
TargetType �� CornerRadius �� Padding	 �� Triggers
 P� Property P� Value��%}  &	        �� 5   
   " ��6+   .�5      ��  � �� 5      �� 5      " ��6&   .R�5      �� #��z��6!   #��z��5      #��z��5      $ 5��5      $ 5q�6#   ._�5      �� $��Center=�6/   $��Center=�6L   5      5      5      	 5      P� 5      
 �@J�IsMouseOver$
 True��61   . �5      ��  � �� �#2C3E5063   �� 5       � ��
 �����63   �� 5       � ��
 �����64   5      P� 5      
 � ��$
 True��6/   . �5      ��  � �� �#2980B963   �� 5        � ��
 �����63   �� 5!       � ��
 ��  �64   5"      5$      5%      .��5'      � .+�5(   
   �� $
��Auto=�6   .��5)      �� 
�������$ 15��6(   $ 20q�6:   $��20q�6G   ���#D1D1D1$��1q�6i    J� Effect 5*      3  -System.Windows.Media.Effects.DropShadowEffect  5+         Color$ Black��6'      
BlurRadius$ 10Q�65      ShadowDepth$ 5Q�6E   ._�5.      �� .+�50      �� $%��Insertion d'une nouvelle tâche��6    $��22(�6F   $
��Bold"�6T   ���#2C3E50$��Center=�51      $
��0,20q�6;   A� 54       A� Columns$ 2��6"   $��Center=�6.   $��10q�6K   $	��650��6W   .+�57      ��  �� Orientation$ 
Horizontal=�6%   $��5q�6>   .+�58      �� $
��🆔��6(   $��18(�62   $��Center=�6@   �� 59      $��Objet :��6(   $
��Bold"�67   $��5,5,0,0q�6I   5:      �� 5;      -   5         ��Name$ NomTacheTextBox��5;   "   $��30��6;   $	��300��6G   $��5q�6S   �� 5>      $ 
Horizontal=�6%   $��5q�6>   .+�5?      �� $
��🏢��6(   $��18(�62   $��Center=�6@   �� 5@      $��Date d'expedition :��6(   $
��Bold"�6C   $��5,5,0,0q�6U   5A      (  "System.Windows.Controls.DatePicker  5B      -   5          Name$ DateExpeditionPicker��5B   %   $��30��6C   $	��300��6O   $��5q�6[   �� 5F      $ 
Horizontal=�6%   $��5q�6>   .+�5G      �� $
��🏢��6(   $��18(�62   $��Center=�6@   �� 5H      $��Date deadline :��6(   $
��Bold"�6?   $��5,5,0,0q�6Q   5I        5J      -   5        $ DateDeadlinePicker��5J   %   $��30��6A   $	��300��6M   $��5q�6Y   �� 5L      -   5        
�������#��[  5L   4   ���#2C3E50$��Ajouter support(s)��6v   
 � Tag$ employes��6�   $��10,10,10,10q�6�   $��30��6�   $	��200��6�   �� 5M      -   5        
�������#��[  5M   4   ���#2C3E50$��Ajouter consigne(s)��6v   $ employes��6�   $��10,10,10,10q�6�   $��30��6�   $	��200��6�   5P      �� 5Q      -   5        $��SupportListView��5Q   #   $��10q�6^   ��6:   �� *SupportList+��5R      �� 5S      .R�5T   "   �� ���#f2f2f2$	��250��6>   ���#ccc$��1q�6]   $ 10��6q   $ 10q�6�   $��5q�6�   ._�5U   &   �� .+�5V   *   �� $
��Bold"�6P   ���#2C3E50��64   �� *
NomFichier+6b   5W   '   5X   #   5Y      5[      �� 5^      -   5        
�������#��[  5^   0   ���#2980B9$��Valider��6q   $ employes��6�   $��10,10,10,10q�6�   $��30��6�   $	��200��6�   5_      5b      5c      5d      5e      