   M S B A M L   `   `   `  ����G  CInstaManager, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:InstaManager.ViewInstaManager.View  5      ?$clr-namespace:InstaManager.ViewModelInstaManager.ViewModel  5      '    !InstaManager.View.UserProfileView   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      1localclr-namespace:InstaManager.View     5      :	viewModel$clr-namespace:InstaManager.ViewModel     5        � DataContext  5
      1   +InstaManager.ViewModel.UserProfileViewModel  5   
   .��5      �  � ColumnDefinitions 5   
   �� 5      $��80 �6   �� 5      �� 5      .+�5   
   �� -   5         ��Name$ 	UserImage��5      $��75��6#   $��75��6.   ��6:   �� *86UserProfileModel.LoginModel.CurrentUser.ProfilePicture+ J� Clip 5      @� 5       @� Center$ 	37.5,37.5&�6"    @� RadiusX$ 30Q�65    @� RadiusY$ 30Q�6B   5      �� 5   
   $��1��6   $	��2,5q�6%   $��Center=�62   .+�5      �� -   5         ��Name$ UserName��5      
�������$��22(�6=   ��6K   �� *20UserProfileModel.LoginModel.CurrentUser.UserName+�� 5      -   5        $ FullName��5      ���	#74747474$��18(�6A   ��6O   �� *20UserProfileModel.LoginModel.CurrentUser.FullName+5      � 5   
   $��2��6    5      �� 5      �� 5      .+�5!      ��  �� Orientation$ 
Horizontal=�6   .+�5"      (� $��48��6   $��48��6%   $
��Left=�61   .��5#      �� $��24��6   $��24��6(   .+�5$      F� a����@KL �f�p�� ��j �@T� ��j �@T� @KL ���!@KL ���!��� �@f��� �@f�S� ��a ��!�@KL �f	���#FF652F6Z   5%      5&      �� 5'      -   5        $ FollowingCount��5'      $��Center=�64   $��Center=�6O   $��40(�5(      
�������$
��Bold"�6=   ��6P   �� *!UserProfileModel.FollowingCount+5)      �� 5*      $��1��6   $ 
Horizontal=�6)   .+�5+      (� $��48��6   $��48��6%   .��5,      �� $��24��6   $��24��6(   .+�5-      F� a������!�a ��f@KL ���j p�� ���j @T� �@KL @T� �@KL ��!���� ��!���� @fѐS� @f���!�a 	���#14A76C6Z   5.      5/      �� 50      -   5        $ FollowerCount��50      $��Center=�63   $��Center=�6N   $��40(�6k   
�������$
��Bold"�51   /   ��6A   �� * UserProfileModel.FollowerCount+52      �� 53      -   5        	 ��Name$	 RefreshButton��53   #   
 � Cursor$

 Hand��6   $��0,0,10,0q�6c   $��0q�6u   $��1��6�   $��20��6�   $��Right=�6�   $	��Top=�6�      
NoneButton#��[  6�   $��70��6�   ��6:   �� *RefreshButtonClicked+.��54      � .+�55      F� $��Center=�6   $��Center=�66   +����        р��  -1� �� -1р,    	���	#ff444444���#747474$	��0.3��6�   �� 56      ���#747474$��Center=�65   $��Center=�6P   	Refresh6v   57      59      5:      5=      5>      