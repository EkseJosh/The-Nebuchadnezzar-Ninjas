   M S B A M L   `   `   `  ����Q  MSpace Invaders Project, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:Space_Invaders_ProjectSpace_Invaders_Project  5   	   +    %Space_Invaders_Project.GameOverScreen   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   6local$clr-namespace:Space_Invaders_Project     5   	     � Title$   ��5   	   $	��681��6   $
��1350��6    � WindowState$ 	Maximized=�6,    � WindowStartupLocation$ CenterScreen=�6D   .��5	      �  � ColumnDefinitions 5
   
   �� 5      $
��643* �6   �� 5      $	��28* �6   .+�5   
   �� $
��Left=�6   $	��760��6,   $��0,-3,-108,-107q�69   $	��Top=�6Q   $
��1450��6i   $��2��6v   ���	#FF0A0406.+�5      �� -   5         ��Name$ label��5      $��
HIGHSCORES��6#   $
��Left=�68   $	��Top=�6S    J� RenderTransformOrigin$ 0.039,0.404&�6k   $��63��6�   $	��296��6�   
����������	#FF0A0406$��48(�6�   
 �� Top$	 176��6�   �� 5      -   5         ��Name$ GameOver��5      $	��681��6&   $
��1056��63   $,��&63520164-space-invaders-wallpapers.png��6@   $
��Fill=�6p    �� Left$	 294��6   �� 5      -   5        $ lblHighScore��5      $��SCORE:��6*   $
��Left=�6;   $	��Top=�6V   $��96��6n   $	��296��6z   ���	#FF0A0406���	#FFC72B2B$��72(�6�   $��Stencil)�6�   
���   �6�   �� 5      -   5        	 ��Name$	 	btnReturn��5      $��	MAIN MENU��6(   $	 700��6<   $	 577��6N   $	��232��6_   $��58��6k   ���	#FF0A0406���	#FF25BB0D���	#FF0A0406$��36(�6�   $��Showcard Gothic)�6�   6�   �� 5      -   5        
 ��Name$
 txtScoreList��5      $	��483��6,    �� TextWrapping$
 Wrap=�69   $	 277��6M   $	��289��6^   ���	#FF0A0406
�������$��Kristen ITC)�6�   $��24(�6�   5      �� 5   
   -   5        $
 txtScoreShow��5      $
��Left=�6(   $��70��6C   $��0,94,0,0q�6O   $
 Wrap=�6a   $	��Top=�6u   $	��296��6�   ���	#FF0A0406���	#FFD41717���	#FF020306 �� 
IsReadOnly . $��Stencil)�6�   $��48(�6  5      5      