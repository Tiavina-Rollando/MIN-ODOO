   M S B A M L   `   `   `  ����E  AGestion_RH, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:Gestion_RH.ConvertersGestion_RH.Converters  5   	   =#clr-namespace:Gestion_RH.ViewModelsGestion_RH.ViewModels  5   	   &     Gestion_RH.Fenetres.ChoixEmploye   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   4conv#clr-namespace:Gestion_RH.Converters     5   	   4view#clr-namespace:Gestion_RH.ViewModels     5   	     � Title$  Choix Employé��5   	    � SizeToContent$ WidthAndHeight=�5   	    � DataContext 5	      1   +Gestion_RH.ViewModels.ChoixEmployeViewModel  5
   
    � 	Resources 5         RoundedButtonStyle �� 
TargetType �� Property �� Value �� 
TargetType �� CornerRadius	 �� Padding
 � Cursor �� Triggers P� Property P� Value5   /Gestion_RH.Converters.ByteArrayToImageConverter  ByteArrayToImageConverter��%�  &	        &	 �    �� 5   
   " ��6+   .�5      ��  � �� 5      �� 5      " ��6&   .R�5      �� #��z��6!   #��z��5      #��z��5      $ 5��5      $	 5q�6'   $

 Hand��64   ._�5      �� $��Center=�6/   $��Center=�6L   5      5      5       5      P� 5       �@J�IsMouseOver$
 True��61   . �5      ��  � �� �#2C3E5063   �� 5       � ��
 �����63   �� 5       � ��
 �����64   5       P� 5!       � ��$
 True��6/   . �5"      ��  � �� �#2980B963   �� 5#       � ��
 �����63   �� 5$       � ��
 ��  �64   5%      5'        5(   
   6)   5)      .��5+      � .+�5,   
   �� .+�5.      �� $��Assigner la tâche à��6   $��22(�63   $
��Bold"�6A   $��Center=�6S   ���#2C3E50$��30q�6�   �� 51      $
��Auto=�6   .��53      �  � Orientation$ 
Horizontal=�6   $��10q�65   $	��850��6A   .+�54      �� ��6#   �� *ListeEmployesCard+��55      �� 56      .R�57   "   � $ 
Horizontal=�6,   58      ��5:      �� 5;      .R�5<   "   �� ���#f2f2f2���#ccc$��1q�6Q   $	��200��6e   $	��160��6q   $ 10��6~   $	 10q�6�   $��5q�6�   ._�5=   &   �� .+�5?   *   A� $��50��62   $��50��6=   
�������$��2��6W   $��Center=�6k   ��5@   .   �� 5A   2    j� Stretch$ UniformToFill=�6�    �� ImageSource 6=   �� *Photo+ �� 	Converter# [ 6�   5C   +   �� 5D   *   $
��Bold"�6I   ���#2C3E50 �� TextAlignment$ Center=�6p   ��64   �� *Nom+6p   �� 5E   *   
�������$ Center=�6^   ��64   �� *Prenom+6^   �� 5F   *   
���  ��$ Center=�6_   ��64   �� *
NomPoste+6_   �� 5G   *   -   5        $��Choisir��5G   1   #��[  6D   $	��100��6�   $��10,5,0,0q�6�   $��Center=�6�   
 � Tag 6�   �� 6�   5H   '   5I   #   5J      5L      5M      5O      5Q      5R      5S      