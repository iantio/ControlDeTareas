   M S B A M L   `   `   `  ????N  JControlDeTareasDesk, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:ControlDeTareasDeskControlDeTareasDesk  5      +    %ControlDeTareasDesk.UserControlInicio   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      U QMaterialDesignThemes.Wpf, Version=2.6.0.325, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      -local!clr-namespace:ControlDeTareasDesk  5      .??5
      ?   ? ColumnDefinitions  5   
   ?? 5      ?? 5      $	??18* ?6   ?? 5       ? RowDefinitions 5   
   ?? 5      $??41 ?6   ?? 5      .+?5   
   ?? -   5         ??Name$ btnAnterior??5       *  &MaterialDesignFloatingActionMiniButton#??[  6&    ? ToolTip$, &MaterialDesignFloatingActionMiniButton??6f   .??5      '  !MaterialDesignThemes.Wpf.PackIcon  ?  ?ControlzEx.PackIconBase`1[[MaterialDesignThemes.Wpf.PackIconKind, MaterialDesignThemes.Wpf, Version=2.6.0.325, Culture=neutral, PublicKeyToken=null]]   Kind$ ArrowLeftBoldCircle=?6&   $??24??6A   $??24??6M   5      ?? 5   
   $??5q?6   $??1??6   
??? ? ?$??Stretch=?6?    ?? CornerRadius$ 12??6[   ._?5      ?? -   5         ??Name$ lblTitle??5      $??Sin procesos asignados??6&   $??18(?6G   ???	#DDFFFFFF
???   ?$??
3,-2,-3,-3q?6?   $
??Bold"?6?   5      ?? 5   
   -   5        $ btnSiguiente??5      $??2??6'   #??[  67   $, &MaterialDesignFloatingActionMiniButton??6w   .??5        $ ArrowRightBoldCircle=?6&   $??24??6B   $??24??6N   5      ? 5   
   $??1??6   $??1??6   $	??4,0q?6,    5      ?? 5      $	??32* ?6    ?? 5       $
??341* ?6    ?? 5!      $	??36* ?6    .+?5#      ? -   5         ?Name$ 
pbProgreso??5#      $??0??6.   $??Stretch=?6;   $??20??6Y   $??Center=?6e    ? Minimum$ 0Q?6?   	 ? Maximum$	 1Q?6?   
 ? Value$
 0Q?6?   ???	#FF383838$	??0,6q?6?   ;  5MaterialDesignThemes.Wpf.Transitions.TransitionAssist   DisableTransitions . 6?   ?? 5$      -   5         ??Name$ 
tbProgreso??5$      $??0??6,   $??Center=?69   $??Center=?6V   
???????$
??Bold"?6?   ??6q   ??  ?? ElementName$ 
pbProgreso?? ?? Path$ Value? ?? StringFormat$ {0:0%}??6?   R? 5%      -   5         R?Name$ tvwFlujo??5%      $??1??6)   $??Stretch=?66   $	??340??6T    ? 	Resources 5&       ?? 
TargetType  MaterialDesignTreeViewItem ?? BasedOn ?? Property ?? Value??%d   'Q?       7  ?? 5'      " Q?6   8   .?5(      ??  ?@Q?
IsExpanded . 6F   5)      5*      ??5+      ?? 5,       ?? DataType*   $ControlDeTareasDesk.TreeViewItemMenu"  6/    ?? ItemsSource 6Z   ?? *Items+.R?5-      ??  ?? Orientation$ 
Horizontal=?6%   $??Stretch=?6>   .+?5.      A? $??10??6&   $??10??61   $??0,0,5,0q?6=   ??6N   ?? *colorSemaforo+?? 5/      $??Stretch=?6(   ??6F   ?? *Titulo+? 50      $??Right=?6*   $??10??6F   $	??100??6R   $??50,0,0,0q?6^   $ 0Q?6p   $	 1Q?6|    . 
 6?   ?? *
Porcentaje+6?   51      52      54      ?? 55      -   5        $ btnTerminar??55      $??Marcar Terminado??6*   $
??Left=?6E   $??0,4,0,0q?6`   $??2??6q   $	??Top=?6~   $	??149??6?   6?   ?? 56      -   5        $ btnRefrescar??56      $??2??6+   $
??Left=?68   $??Center=?6S   $??	154,4,0,0q?6n   $??46??6?   ???	#FF0096DC???	#FF0096DC.??57        -	   5          Name$ iconRefrescar??57   *   $ Refresh=?6A   $??Center=?6P   $??16??6m   $??16??6x   
???????6?   58      59      5:      5;      