   M S B A M L   `   `   `  ����P  LMinecraft skin editor, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullI)clr-namespace:Minecraft_skin_editor.ViewsMinecraft_skin_editor.Views  5      S.clr-namespace:Minecraft_skin_editor.ViewModels Minecraft_skin_editor.ViewModels  5      N JDirectxImageControl, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullV>clr-namespace:DirectxImageControl;assembly=DirectxImageControlDirectxImageControl 5	      ,    &Minecraft_skin_editor.Views.SkinEditor   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      ;local)clr-namespace:Minecraft_skin_editor.Views     5      c _System.Windows.Interactivity, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  5      ?
viewModels.clr-namespace:Minecraft_skin_editor.ViewModels  5      XDirectxImageControl>clr-namespace:DirectxImageControl;assembly=DirectxImageControl  5	      X TXceed.Wpf.Toolkit, Version=3.0.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f44xctk)http://schemas.xceed.com/wpf/xaml/toolkit  5
      .��5      �   � DataContext  5   
   0   *Minecraft_skin_editor.ViewModels.ViewModel  5       � RowDefinitions 5   
   �� 5      $
��1.2* �6   �� 5      $
��4.5* �6   �� 5      $��1* �6   �� 5      $
��1.5* �6   �� 5      $��0.55* �6   �� 5      $
��0.4* �6    � ColumnDefinitions 5   
   �� 5      $��2* �6   �� 5      $
��0.4* �6   �� 5      $��3* �6   �� 5      $
��0.4* �6   �� 5       $��2* �6   .+�5"   
   �� -   5         ��Name$ image��5"      $
��Fill=�6   $*��$/Resources/Tex/gewoneAchtergrond.png��6.   $��5��6\   $��6��6p   $��0,0,-0.308,0.25q�6�   �� 5#   
   -   5         ��Name$
 size��5#      $��1��6#   
���   �$��1��6@   
�������$��3��6\   $��2��6p   $��	20,9,20,0q�6�   6�   �� 5$   
   -   5        $ SkinBack��5$      $��1��6"    �� BitmapScalingMode$ NearestNeighbor=�62   $��
20,20,20,0q�6d   $��/Resources/Tex/Steve.png��6x   $
��Fill=�6�   $��2��6�   $��1��6�   $��3��6�   #  Xceed.Wpf.Toolkit.ColorCanvas  5%   
   $��0,0,0,10q�6�   $��2��6�   $��3��6�   ���	#FF6BAE43���	#FF79553A$��Center=�6  $��Bottom=�64  y�6   �� *SetColorPicker+   BoolVisConv �� 	Converter# [  {�6k   �� *SetColorPicker+   SelectedColor 6�   �� *BrushColorPick+64  � 5&   
   $��3��6   $��4��6   $��3��6,    5'      �� 5(      $
��1.2* �6#   �� 5)      $��3* �6#   .+�5+      �� $��1��6`   ��6   �� *BrushColorPick+  
RGBColConv# [ 6`   5,      � 5-   
   $��1��6   $��4��6   $��2��6,    5.      �� 5/      $��1* �6#   �� 50      $��1* �6#   �� 51      $��1* �6#   �� 52      $��1* �6#    54      �� 55      $��2* �6    �� 56      $
��0.5* �6    �� 57      $
��0.3* �6    �� 58      $
��0.5* �6    .+�5:      �� $��2,10,6,2q�6s   $��4��6�   ���	#FF9D714E���	#FF38261B��6   �� *NamesDownloaded+ �� Mode$ TwoWay=�	 �� SelectedItem	 6J   �� *SelecteListItem+6�   �� 5;      $��1��6@   $��5q�6M   ���	#FF533B29���	#FF3F6427$��3��6�   
 �� SelectionBrush
 �	#FF4C3524$��24(�6�   ��6   �� *
NameOfSkin+$ TwoWay=���6�   Z� 6�   �� 5<      $��3��6Z   $
��Load��6g   ���	#FF9E724E$	��1,0q�6�   $
��Auto��6�   $��Center=�6�   ��6   �� *LoadNamesCommand+��6;   �� *.+��6�   Z� 6�   �� 5=      $��3��6Z   $
��Save��6g   ���	#FF9E724E$��1q�6�   $��2��6�   $
��Auto��6�   $��Center=�6�   ��6   �� *SaveNamesCommand+��6;   �� *.+��6�   Z� 6�   �� 5>      $��3��6\   $��Apply��6i   ���	#FF9E724E$��1q�6�   $��1��6�   $
��Auto��6�   $��Center=�6�   ��6   �� *ApplyTextureToSkin+��6=   �� *.+��6�   Z� 6�   �� 5?      $��2��6\   $��Delete��6i   ���	#FF9E724E$��1q�6�   $��2��6�   $
��Auto��6�   $��Center=�6�   ��6   �� *DeleteSkinFromList+��6=   �� *.+��6�   Z� 6�   �� 5@      $	��Add��6W   ���	#FF9E724E$��1q�6|   $
��Auto��6�   $��Center=�6�   $��2��6�   ��6   �� *AddSkinToList+��68   �� *.+��6�   Z� 6�   5A      � 5B   
   $��5q�6   $��1��6    5C      �� 5D      $��1* �6#   �� 5E      $��1* �6#   �� 5F      $��1* �6#    5H      �� 5I      $��8* �6    �� 5J      $��1* �6    �� 5K      $��1* �6    �� 5L      $��1* �6    .+�5N      *  $DirectxImageControl.DX10RenderCanvas  -   5          Name$ dX10RenderCanvas��5N   R   $��5q�6l   $��3��6w      Viewport 63   �� *
Viewport+6w   �� 5O      -   5         ��Name$ 
buttonLeft��5O   S   $
��Left��6g   $
��Auto��6v   ���	#FF61A238���	#FF3E3E42$��1q�6�   $��2��6�   ��6   �� *
LeftTurn+��64   �� *.+6�   �� 5P      -   5        $ 
buttonAuto��5P   S   $
��Auto��6g   $
��Auto��6v   ���	#FF61A238���	#FF3E3E42$��1q�6�   $��2��6�   $��1��6�   $��12(�6�   ��6   �� *
AutoTurn+��64   �� *.+6�   �� 5Q      -   5        $ buttonRight��5Q   T   $��Right��6i   $
��Auto��6y   ���	#FF61A238���	#FF3E3E42$��1q�6�   $��2��6�   $��2��6�   $��12(�6�   ��6   �� *	RightTurn+��65   �� *.+6�   �� 5R      -   5        $ buttonUp��5R   M   $��Up��6_   $
��Auto��6l   ���	#FF61A238���	#FF3E3E42$��1q�6�   $��1��6�   $��1��6�   $��12(�6�   ��6   �� *Up+��6.   �� *.+6�   �� 5S      -	   5        $ 
buttonDown��5S   O   $
��Down��6c   $
��Auto��6r   ���	#FF61A238���	#FF3E3E42$��1q�6�   $��3��6�   $��1��6�   $��12(�6�   ��6   �� *Down+��60   �� *.+6�   5T      �� 5U   
   -
   5        $ SkinImageLive��5U      $��1��6(   $ NearestNeighbor=�6e   $��
20,20,20,0q�6�   $
��Fill=�6�   $��2��6�   $��1��6�   $��3��6�    J� Opacity$ 1Q�6�   ��69   �� *ImageSource+$ TwoWay=�6�   � 5V   
   $��2��6   $��0q�6   $��4��6*    5W      �� 5X      $��0.25* �6#   �� 5Y      $��1* �6#   �� 5Z      $
��0.2* �6#   �� 5[      $��1* �6#   �� 5\      $
��0.2* �6#   �� 5]      $��1* �6#   �� 5^      $
��0.2* �6#   �� 5_      $��1* �6#   �� 5`      $
��0.2* �6#   �� 5a      $��1* �6#   �� 5b      $
��0.2* �6#   �� 5c      $��1* �6#   �� 5d      $
��0.2* �6#   �� 5e      $��1* �6#   �� 5f      $
��0.2* �6#   �� 5g      $��1* �6#   �� 5h      $
��0.2* �6#   �� 5i      $��1* �6#   �� 5j      $
��0.2* �6#   .+�5l      �� -   5        $ button��5l   V   $��1��6g   $
��Auto��6w   ���	#FF61A238���	#FF3E3E42$��5q�6�   ��6   �� *BrushCommand+��67   �� *.+6�   �� 5m      -   5        $ button1��5m   ]   $��3��6o   $
��Auto��6   ���	#FF61A238���	#FF3E3E42$��5q�6�   ��6   �� *PenPixelDownCommand+��6>   �� *.+6�   �� 5n      -   5        $ button2��5n   b   $��5��6s   $
��Auto��6�   ���	#FF61A238���	#FF3E3E42$��5q�6�   ��6   �� *ButtonColorPickerCommand+��6C   �� *.+6�   �� 5o      -   5        $ button3��5o   ]   $��7��6n   $
��Auto��6~   ���	#FF61A238���	#FF3E3E42$��5q�6�   ��6   �� *RandomColorCommand+��6=   �� *.+6�   �� 5p      -   5        $ button4��5p   V   $��9��6g   $
��Auto��6w   ���	#FF61A238���	#FF3E3E42$��5q�6�   ��6   �� *EmptyCommand+��67   �� *.+6�   �� 5q      -   5        $ button5��5q   V   $��11��6g   $
��Auto��6x   ���	#FF61A238���	#FF3E3E42$��5q�6�   ��6   �� *UndoCommand+��66   �� *.+6�   �� 5r      -   5        $ button6��5r   U   $��13��6f   $
��Auto��6w   ���	#FF61A238���	#FF3E3E42$��5q�6�   ��6   �� *RedoCommand+��66   �� *.+6�   �� 5s      -   5        $ button7��5s   Z   $��15��6k   $
��Auto��6|   ���	#FF61A238���	#FF3E3E42$��5q�6�   ��6   �� *SaveSkinCommand+��6:   �� *.+6�   �� 5t      -   5        $ button8��5t   Z   $��17��6k   $
��Auto��6|   ���	#FF61A238���	#FF3E3E42$��5q�6�   ��6   �� *LoadSkinCommand+��6:   �� *.+6�   �� 5u      $��1��6   $"��/Resources/Tex/BrushIcon.png��6$   $��10q�6J    J� IsHitTestVisible .  6V   �� 5v      $��3��6   $?��9/Minecraft skin editor;component/Resources/Tex/pencil.png��6$   $��10q�6g    .   J� OpacityMask 5w      �� 5x       �� Color$ Black��6&   5z      �� 5{      $��5��6   $��10q�6$    .  $(��"/Resources/Tex/colorpickerIcon.png��6I   �� 5}      $��7��6   $��10q�6$    .  $#��/Resources/Tex/RandomIcon.png��6I   �� 5~      $��9��6   $��10q�6$    .  $"��/Resources/Tex/NieuwIcon.png��6I   �� 5      $��11��6   $&�� /Resources/Tex/PijltjeSymbol.png��6%   $��10q�6O    .  6[   �� 5�      $��13��6   $&�� /Resources/Tex/PijltjeSymbol.png��6%   $��10q�6O    J� RenderTransformOrigin$ 0.5,0.5&�6[    .  z�5�      V� 5�      .~�5�      ��  �� ScaleY$ 1Q�6)    �� ScaleX$ -1Q�64   �� 5�       �� AngleY$ 0Q�6(    �� AngleX$ 0Q�63   �� 5�       �� Angle$ 0Q�6*   T� 5�      5�      5�      �� 5�      $��15��6   $!��/Resources/Tex/SaveIcon.png��6%   $��10q�6J    .  6V   �� 5�      $��17��6   $#��/Resources/Tex/FolderIcon.png��6%   $��10q�6L    .  6X   5�      �� 5�   
   $J��D/Minecraft skin editor;component/Resources/Tex/MAchtergrondEigen.png��6   $
��Fill=�6^   $��8��6m   $��6��6~   $��Center=�6�   $��Center=�6�    .  6�   .  (System.Windows.Interactivity.Interaction   Triggers 5�   
   /  )System.Windows.Interactivity.EventTrigger  5�         	EventName$ 	MouseDown��6   .  (System.Windows.Interactivity.TriggerBase   Actions. 5�      6  0System.Windows.Interactivity.InvokeCommandAction     Command 6(   �� *PaintCommand+   CommandParameter 6I   �� *.+5�        5�      $ 	MouseMove��6   . 5�         6(   �� *PaintMoveCommand+ 6M   �� *.+5�        5�      $ SizeChanged��6   . 5�         6(   �� *PaintCommand+ 6I   �� *.+5�        5�      $ MouseUp��6   . 5�         6(   �� *MouseUpCommand+ 6K   �� *.+5�      5�      5�      