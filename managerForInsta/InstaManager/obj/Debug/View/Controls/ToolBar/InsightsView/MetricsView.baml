   M S B A M L   `   `   `  ����G  CInstaManager, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nulla5clr-namespace:InstaManager.View.Controls.InsightsView'InstaManager.View.Controls.InsightsView  5      {Bclr-namespace:InstaManager.ViewModel.Controls.ToolBar.InsightsView4InstaManager.ViewModel.Controls.ToolBar.InsightsView  5      9    3InstaManager.View.Controls.InsightsView.MetricsView   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Glocal5clr-namespace:InstaManager.View.Controls.InsightsView     5      [insightsViewBclr-namespace:InstaManager.ViewModel.Controls.ToolBar.InsightsView     5        � 	Resources  5
         ForegroundForTextBlock �� Color��%+   &	        �� 5   
   $ #747474��69   5       � DataContext 5      K   EInstaManager.ViewModel.Controls.ToolBar.InsightsView.MetricsViewModel  5   
   .��5      �  � RowDefinitions 5      �� 5      �� 5      �� 5      �� 5      .+�5   
   �� $��0��6   #��[  6!   $��Center=�6V   $��Center=�6q   $
��Wrap=�6�   Do not follow me: �� 6�   �6�   �� *!MetricsModel.TheyDontFollowBack+6�   �� 5   
   $��1��6   #��[  6!   $��Center=�6V   $��Center=�6q   $
��Wrap=�6�   I do not follow back: �� 6�   �6�   �� *MetricsModel.IDontFollowBack+6�   �� 5   
   $��2��6     
NoneButton#��[ 6     � Cursor$
 Hand��6�   
 � Tag$ 	followers��6�   ��6D   ��  �� RelativeSource �� *Self+��6�   �� *ButtonClicked+.��5      �� #��[  6   $��Center=�6M   $��Center=�6h   $
��Wrap=�6�   New Followers: �� 6�   �6�   �� *MetricsModel.FollowMe+6�   5      �� 5   
   #��[ 6   $��3��65   $
 Hand��6�   $ unfollowers��6�   ��6B   ��  �� *Self+��6�   �� *ButtonClicked+.��5      �� #��[  6   $��Center=�6N   $��Center=�6i   $
��Wrap=�6�   UnFollowers: �� 6�   �6�   �� *MetricsModel.UnFollowedMe+6�   5      5      5       