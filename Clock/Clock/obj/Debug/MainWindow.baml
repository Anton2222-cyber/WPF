   M S B A M L   `   `   `  ����@  <Clock, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:ClockClock  5   	       Clock.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   %localclr-namespace:Clock     5   	   -   5          �Name$  window��5   	    � Title$ MyClock��5   	   $	��500��6   $	��500��6&   
���   � � 	Resources 5
         col � Color � Offset��%|   &	        
� 5   
   .��5      � $ White��6   $ 0Q�6)   � 5      $ Black��6   $ 1Q�6)   5      5      .��5      �� -   5         ��Name$ 
ClockPlace��5      $	��400��6!   $	��400��6-   .+�5   
   A� -   5         A�Name$ Ellipse_Clock��5   .   #��[  6   $	��400��6E   $	��400��6Q   $��2��6^   �� 5   
   -   5         ��Name$ SecondsLine��5      	 �� X1$	 200��6%   		 �� Y1$		 200��6.   	
 �� X2$	
 200��67   	 �� Y2$ 0��6@   
�������$��3��6V   �� 5   
   -   5        $ MinutessLine��5      $	 200��6%   $		 200��6.   $	
 250��67   $	 200��6@   
�������$��5��6X   �� 5   
   -   5        $ 	HoursLine��5      $	 200��6"   $		 200��6+   $	
 200��64   $	 200��6=   
�������$��6��6U   A� 5   
   $��20��6   $��20��6   #��[  6)   $	��190q�6E   5      5      