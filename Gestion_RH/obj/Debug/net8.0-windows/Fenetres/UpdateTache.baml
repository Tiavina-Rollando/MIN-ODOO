   M S B A M L   `   `   `  ����E  AGestion_RH, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:Gestion_RH.ConvertersGestion_RH.Converters  5   	   9!clr-namespace:Gestion_RH.FenetresGestion_RH.Fenetres  5   	   %    Gestion_RH.Fenetres.UpdateTache   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   4conv#clr-namespace:Gestion_RH.Converters     5   	   3local!clr-namespace:Gestion_RH.Fenetres     5   	     � Title$  UpdateTache��5	   	   $	��450��6   $	��800��6*    � 	Resources 5
         RoundedButtonStyle �� 
TargetType �� Property �� Value �� 
TargetType �� CornerRadius �� Padding �� Triggers	 P� Property
 P� Value.   (Gestion_RH.Converters.TagFormatConverter  TagFormatConverter��%�  &	        &	 s    �� 5   
   " ��6+   .�5      ��  � �� 5      �� 5      " ��6&   .R�5      �� #��z��6!   #��z��5      #��z��5      $ 5��5      $ 5q�6   ._�5      �� $��Center=�6/   $��Center=�6L   5      5      5       5      P� 5      	 �@J�IsMouseOver$

 True��61   . �5      ��  � �� �#2C3E5063   �� 5       � ��
 �����63   �� 5       � ��
 �����64   5      P� 5      	 � ��$

 True��6/   . �5      ��  � �� �#2980B963   �� 5        � ��
 �����63   �� 5!       � ��
 ��  �64   5"      5$        5&   
   6"   5'      .��5)      � .+�5*   
   �� $
��Auto=�6   .��5+      �� 
�������$ 15��6(   $ 20q�6:   $��20q�6G   ���#D1D1D1$��1q�6i    J� Effect 5,      3  -System.Windows.Media.Effects.DropShadowEffect  5-         Color$ Black��6'      
BlurRadius$ 10Q�65      ShadowDepth$ 5Q�6E   ._�50      �� .+�52      �� $��Mettre à jour la tâche��6    $��22(�6>   $
��Bold"�6L   ���#2C3E50$��Center=�53      $
��0,20q�67   A� 56       A� Columns$ 2��6"   $��Center=�6.   $��10q�6K   $	��650��6W   .+�59      ��  �� Orientation$ 
Horizontal=�6%   $��5q�6>   .+�5:      �� $
��🆔��6(   $��18(�62   $��Center=�6@   �� 5;      $��Objet :��6(   $
��Bold"�67   $��5,5,0,0q�6I   5<      �� 5=      -   5         ��Name$ NomTacheTextBox��5=   "   $��30��6;   $	��300��6G   $��5q�6S   �� 5@      $ 
Horizontal=�6%   $��5q�6>   .+�5A      �� $
��🏢��6(   $��18(�62   $��Center=�6@   �� 5B      $��Date d'expedition :��6(   $
��Bold"�6C   $��5,5,0,0q�6U   5C      (  "System.Windows.Controls.DatePicker  5D      -   5          Name$ DateExpeditionPicker��5D   %   $��30��6C   $	��300��6O   $��5q�6[   �� 5H      $ 
Horizontal=�6%   $��5q�6>   .+�5I      �� $
��🏢��6(   $��18(�62   $��Center=�6@   �� 5J      $��Date deadline :��6(   $
��Bold"�6?   $��5,5,0,0q�6Q   5K        5L      -   5        $ DateDeadlinePicker��5L   %   $��30��6A   $	��300��6M   $��5q�6Y   �� 5N      -   5        
�������#��[  5N   4   ���#2C3E50$��Ajouter support(s)��6v   
 � Tag$ employes��6�   $��10,10,10,10q�6�   $��30��6�   $	��200��6�   �� 5O      -   5        
�������#��[  5O   4   ���#2C3E50$��Ajouter consigne(s)��6v   $ employes��6�   $��10,10,10,10q�6�   $��30��6�   $	��200��6�   5R      �� 5S      -   5        $��SupportListView��5S   #   $��10q�6^   ��6:   �� *SupportList+��5T      �� 5U      .R�5V   "   �� ���#f2f2f2���#ccc$��1q�6Q   $ 10��6e   $	��250��6w   $ 10q�6�   $��5q�6�   ._�5W   &   �� .+�5X   *   �� -   5        
������ $��0q�5X   �   $��Right=�6�    6I   �� *Id+ �� 	Converter# [  �� ConverterParameter$ support��.��5Y   .   �� $��../Assets/trash-icon.png��64   $��20��6V   $��20��6a   5Z   +   �� 5[   *   $
��Bold"�6P   ���#2C3E50��64   �� *
NomFichier+6b   5\   '   5]   #   5^      5`      �� 5c      -   5        
�������#��[  5c   0   ���#2980B9$��Enregistrer��6q   $ employes��6�   $��10,10,10,10q�6�   $��30��6�   $	��200��6�   5d      5g      5h      5i      5j      