   M S B A M L   `   `   `  ????N  JControlDeTareasDesk, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:ControlDeTareasDeskControlDeTareasDesk  5      0    *ControlDeTareasDesk.UserControlListarFlujo   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      U QMaterialDesignThemes.Wpf, Version=2.6.0.325, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      -local!clr-namespace:ControlDeTareasDesk  5      .??5
      ?   ? ColumnDefinitions  5   
   ?? 5      ?? 5      $	??18* ?6   ?? 5       ? RowDefinitions 5   
   ?? 5      $??41 ?6   ?? 5      .+?5   
   ?? $??5q?6   $??0??6   
??? ? ?$??Stretch=?6?    ?? CornerRadius$ 12??6[   ?? 5   
   $??5q?6   $??1??6   
??? ? ?$??Stretch=?6?   $ 12??6[   ._?5      ?? -   5         ??Name$ lblTitle??5      $??Control de fujos??6&   $??18(?6A   ???	#DDFFFFFF
???   ?$??
3,-2,-3,-3q?6z   $
??Bold"?6?   5      ?? 5   
   $??5q?6   $??2??6   
??? ? ?$??Stretch=?6?   $ 12??6[   ? 5   
   $??1??6   $??1??6   $	??4,0q?6,    5      ?? 5      $	??32* ?6    ?? 5      $
??341* ?6    ?? 5      $	??36* ?6    .+?5       R? -   5         R?Name$ tvwFlujo??5       $??Stretch=?6)   $	??340??6G   $??1??6W    ? 	Resources 5!       ?? 
TargetType   MaterialDesignTreeViewItem ?? BasedOn ?? Property	 ?? Value??%d   'Q?       7   ?? 5"      " Q?6   8   .?5#      ??  ?@Q?
IsExpanded	 .  6G   5$      5%      ??5&      ?? 5'      
 ?? DataType*   $ControlDeTareasDesk.TreeViewItemMenu"
  6/    ?? ItemsSource 6Z   ?? *Items+.R?5(      ??  ?? Orientation$ 
Horizontal=?6%   $??Stretch=?6>   .+?5)      A? $??10??6&   $??10??61   $??0,0,5,0q?6=   ??6N   ?? *colorSemaforo+?? 5*      $??Stretch=?6(   ??6F   ?? *Titulo+?? 5+       ??Name$ 	txtEstado??6(   $??50,0,0,0q?6;   $??Stretch=?6?   ??6M   ?? *#!detalleTarea.estado.nombre_estado+6?   ?? 5,       ??Name$ btnVerJustificacion??6%   -   5        $??10,0,0,0q?5,   B   $??ver justifiacion??6T   
??? ? ?
?????? +  %MaterialDesignThemes.Wpf.ButtonAssist   CornerRadius$ 10??6?   $??20??6?   $??10(?6?   ??5-   "   ?? 5.   &   " ??6,     MaterialDesignRaisedButton# [ 6@   .?5/   *   ??  ? y?$	 Visible=?6G    ?? Triggers 50   *   ?? 51   .    ?? Binding 6:   ?? *justificacion+ ?? Value 6\   Z? .a?52   2   ??  ? y?$	 	Collapsed=?6O   53   /   55   '   57      ? 58      $??Right=?6*   $??10??6F   $	??100??6R   $??50,0,0,0q?6^    ? Minimum$ 0Q?6p    ? Maximum$ 1Q?6|   ;  5MaterialDesignThemes.Wpf.Transitions.TransitionAssist   DisableTransitions .  ? Value 6?   ?? *
Porcentaje+6?   59      5:      5<      ?? 5=      -   5        $ btnCrear??5=      $??Crear??6'   $
??Left=?67   $??0,5,0,0q?6R   $??2??6c   $??Center=?6p   $??75??6?   6?   ?? 5>      -   5        $ 	btnEditar??5>      $??Editar??6(   $
??Left=?69   $??80,5,0,0q?6T   $??2??6f   $??Center=?6s   $??75??6?   6?   ?? 5?      -   5        $ btnRefrescar??5?      $??2??6+   $
??Left=?68   $??Center=?6S   $??	160,5,0,0q?6n   $??46??6?   ???	#FF0096DC???	#FF0096DC.??5@      '  !MaterialDesignThemes.Wpf.PackIcon  -   5          Name$ iconRefrescar??5@   *   ?  ?ControlzEx.PackIconBase`1[[MaterialDesignThemes.Wpf.PackIconKind, MaterialDesignThemes.Wpf, Version=2.6.0.325, Culture=neutral, PublicKeyToken=null]]   Kind$ Refresh=?6A   $??Center=?6P   $??16??6m   $??16??6x   
???????6?   5A      ?? 5B      -   5        $ btnEliminar??5B      $??2??6*   $??Right=?67   $??Center=?6S   $??Eliminar??6n   ???	#FFC7504A???	#FFC7504A6?   5D      5E      5F      