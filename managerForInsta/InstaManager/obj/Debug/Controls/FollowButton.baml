   M S B A M L   `   `   `  ����G  CInstaManager, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:InstaManager.ControlsInstaManager.Controls  5      (    "InstaManager.Controls.FollowButton   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      5local#clr-namespace:InstaManager.Controls     5      
������   � 	Resources  5	         Button.Static.Background �� Color  Button.Static.Border  Button.MouseOver.Background  Button.MouseOver.Border  Button.Pressed.Background  Button.Pressed.Border  Button.Disabled.Background  Button.Disabled.Border  Button.Disabled.Foreground 	 NonReactiveButton �� 
TargetType �� Property 
 FocusVisual �� Value �� 
TargetType ��Name J� SnapsToDevicePixels'  !System.Windows.VisualStateManager   VisualStateGroups%  System.Windows.VisualStateGroup	   States   System.Windows.VisualState
 ��Name �� Triggers P� Property P� Value �� 
TargetName ��Name  Selected g� Duration �� TargetProperty �� 
TargetName9  3System.Windows.Media.Animation.EasingDoubleKeyFrame O� KeyTime O� Value  
UnSelected��%  &	        &	 #     &	 F     &	 i     &	 �     &	 �     &	 �     &	 �     &	     &		 ;    7 
 7   7  7  7  7  7  7  7  7  &	 �    &	 �
    �� 5
   
   $ 	#FF272727��6;   �� 5   
   $ 	#FF747474��67   �� 5   
   $ 	#FF272727��6>   �� 5   
   $ 	#FF747474��6:   �� 5   
   $ 	#FF747474��6<   �� 5   
   $ 	#FF272727��68   �� 5   
   $ 	#FF272727��6=   �� 5   
   $ 	#FF747474��69   �� 5   
   $ 	#FF272727��6=   �� 5   
   " ��6*   .�5      ��  �@�FocusVisualStyle8   61   �� 5       � ��8  6+   �� 5       � ��8  6,   �� 5       � ��# � ��6+   �� 5       � ��$ 1q�60   �� 5       � ��$ Center=�6;   �� 5       � ��$ Center=�69   �� 5       � ��$ 1q�6(   �� 5       � �� 5      �� 5      " ��6&   .R�5      �� $ border��6!   #��z��61   #��z��6]    . ���	#FF272727 5         5!   "   CommonStates��.	 5"   &     
Normal��62     5#   &   	MouseOver��62     5$   &   Pressed��62     5%   &   Disabled��62   5&   #   ._�5(      �� $
 contentPresenter��6/   |�.  #��z��6[   #��z��6�   ��. # z 6�   #��z��6  5)       5*      P� 5+       �@��IsDefaulted . . �5,   "   �� $ border��6@   # � ��6T    � ��5-      P� 5.       �@J�IsMouseOver . . �5/   "   �� $ border��6?   8   � ��6S   �� 50   "   $ border��6@   8   � ��6T   51      P� 52       � �� . . �53   "   �� $ border��6?   8   � ��6S   �� 54   "   $ border��6@   8   � ��6T   55      P� 56       � {� .  . �57   "   �� $ border��6?   8   � ��6S   �� 58   "   $ border��6@   8   � ��6T   �� 59   "   $ contentPresenter��6K   8 	  � ��6i   5:      5<      5>      5?      �� 5@   
   $ SelectedStoryboard��6&   $ 0:0:0.3D�6B   .��5A      U� $U O(UIElement.RenderTransform).(TransformGroup.Children)[3].(TranslateTransform.X)�6,   $ 	textBlock��6�   .\�5B        $ 0:0:0.3��6'   $ 12.834Q�69   5C      U� 5D      $U O(UIElement.RenderTransform).(TransformGroup.Children)[3].(TranslateTransform.Y)�6,   $ 	textBlock��6�   .\�5E        $ 0:0:0.3��6'   $ 0.214Q�69   5F      U� 5G      $U O(UIElement.RenderTransform).(TransformGroup.Children)[3].(TranslateTransform.X)�6,   $ viewbox��6�   .\�5H        $ 0:0:0.3��6'   $	 -52Q�69   5I      U� 5J      $V P(UIElement.RenderTransform).(TransformGroup.Children)[0].(ScaleTransform.ScaleX)�6,   $
 grid��6�   .\�5K        $ 0:0:0.3��6'   $	 0.9Q�69   5L      U� 5M      $V P(UIElement.RenderTransform).(TransformGroup.Children)[0].(ScaleTransform.ScaleY)�6,   $
 grid��6�   .\�5N        $ 0:0:0.3��6'   $	 0.9Q�69   5O      5P      �� 5Q   
   $ UnSelectedStoryboard��6(   $ 0:0:0.3D�6G   .��5R      U� $U O(UIElement.RenderTransform).(TransformGroup.Children)[3].(TranslateTransform.X)�6,   $ 	textBlock��6�   .\�5S        $ 0:0:0.0��6'   $ 12.834Q�69     5T      $ 0:0:0.3��6'   $ 0Q�69   5U      U� 5V      $U O(UIElement.RenderTransform).(TransformGroup.Children)[3].(TranslateTransform.Y)�6,   $ 	textBlock��6�   .\�5W        $ 0:0:0��6'   $ 0Q�67     5X      $ 0:0:0.3��6'   $ 0Q�69   5Y      U� 5Z      $U O(UIElement.RenderTransform).(TransformGroup.Children)[3].(TranslateTransform.X)�6,   $ viewbox��6�   .\�5[        $ 0:0:0.0��6'   $	 -52Q�69     5\      $ 0:0:0.3��6'   $	 -83Q�69   5]      U� 5^      $V P(UIElement.RenderTransform).(TransformGroup.Children)[0].(ScaleTransform.ScaleX)�6,   $
 grid��6�   .\�5_        $ 0:0:0.0��6'   $	 0.9Q�69     5`      $ 0:0:0.3��6'   $ 1Q�69   5a      U� 5b      $V P(UIElement.RenderTransform).(TransformGroup.Children)[0].(ScaleTransform.ScaleY)�6,   $
 grid��6�   .\�5c        $ 0:0:0.0��6'   $	 0.9Q�69     5d      $ 0:0:0.3��6'   $ 1Q�69   5e      5f      5g      .��5h      �� -   5         ��Name$ 
MainButton��5h   :   ���#272727���	#74747474$��10q�6N   #��� 	 6Z    J� Clip 5i   
   �� 5j       �� Rect$ 
0,0,150,80�6   .��5l   
   � -   5         �Name$
 grid��5l       J� RenderTransformOrigin$ 0.5,0.5&�6   z�5m      V� 5n      .~�5o      �� �� 5p      �� 5q      T� 5r      5s      .+�5u      (� -   5         (�Name$ viewbox��5u      $��36��6'   $��36��62   $��Center=�6>   $��Center=�6Y   $ 0.5,0.5&�6v   z�5v      V� 5w      .~�5x      �� �� 5y      �� 5z      T� 5{       T� X$	 -83Q�6-   5|      .��5~      �� $��24��6   $��24��6$   .+�5      F� K����@o@��j �@T� ��!��g5 `�� Ѱ�J �z� Q@T� �Q��+0@�p�*�KU �@o@��j 	���#FFE4006Z   5�      5�      �� 5�      -   5         ��Name$ 	textBlock��5�      $��Center=�6+   $��Center=�6F   ���#FFE400$��24(�6x   $
��Bold"�6�   
unfollowz�5�      V� 5�      .~�5�      �� �� 5�      �� 5�      T� 5�      5�      5�      5�      5�      5�      