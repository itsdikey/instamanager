   M S B A M L   `   `   `  ����G  CInstaManager, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nulla5clr-namespace:InstaManager.ViewModel.Controls.ToolBar'InstaManager.ViewModel.Controls.ToolBar  5      Q-clr-namespace:InstaManager.Sources.ConvertersInstaManager.Sources.Converters  5      (    "InstaManager.View.Controls.Actions   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      K	viewmodel5clr-namespace:InstaManager.ViewModel.Controls.ToolBar     5      D
converters-clr-namespace:InstaManager.Sources.Converters     5        � DataContext  5
      >   8InstaManager.ViewModel.Controls.ToolBar.ActionsViewModel  5   
    � 	Resources 5      B   <InstaManager.Sources.Converters.BooleanToVisibilityConverter (  $BooleanToVisibilityConverterStraight ' #BooleanToVisibilityConverterInverse�   �InstaManager.Sources.Converters.BooleanConverter`1[[System.Windows.Visibility, PresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35]]   True   False��%]   &	        &	        5   
   62     5   
   $ 	Collapsed=�6^   $ Visible=�6o   5      .��5      �  � RowDefinitions 5   
   �� 5      $��30 �6   �� 5      $��40 �6   �� 5      $��40 �6   �� 5      .+�5   
   �� ���#747474$��Center=�6)   $��Center=�6D   $��2��6a   -----actions-----6�   �� 5   
    �� Orientation$ 
Horizontal=�6   $��1��6.   $��Center=�6;   .+�5      �� $��Center=�6   ���#747474
to follow:6T   �� 5      -   5         ��Name$ FollowCount��5      $��Center=�6-   ���#747474$��2,0,0,0q�6]   ��6n   ��  �� Path$ ToFollows.Count� �� Mode$ OneWay=�5      �� 5   
   $ 
Horizontal=�6   $��2��6.   $��Center=�6;   .+�5      �� $��Center=�6   ���#747474to unfollow:6V   �� 5       -   5        $ UnFollowCount��5       $��Center=�6/   ���#747474$��2,0,0,0q�6_   ��6p   �� $ ToUnFollow.Count�$ OneWay=�5!      �� 5"   
   -   5        	 ��Name$	 PerformActions��5"   e   $��3��6     ShadedButton#��[ 6   $��10q�6D   ���#747474��6}   �� *PerformActionsCommand+y�6�   �� *IsPerformingActions+
 �� 	Converter#
 [ .��6  Perform All5$      � 5%   
   $��3��6   $��10q�6#   ���#747474���#272727y�6Y   �� *IsPerformingActions+#
 [   � Value 6�   �� *ActionsAlreadyPerformed+ � Maximum 6�   �� *TotalActionToPerform+5&      5'      