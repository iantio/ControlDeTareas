   M S B A M L   `   `   `  ????N  JControlDeTareasDesk, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:ControlDeTareasDeskControlDeTareasDesk  5      -    'ControlDeTareasDesk.UserControlProcesos   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      3local!clr-namespace:ControlDeTareasDesk     5      U QMaterialDesignThemes.Wpf, Version=2.6.0.325, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      .??5
      ?   ? ColumnDefinitions  5   
   ?? 5      ?? 5      $	??18* ?6   ?? 5       ? RowDefinitions 5   
   ?? 5      $??41 ?6   ?? 5      .+?5   
   ?? $??5q?6   $??0??6   
??? ? ?$??Stretch=?6?    ?? CornerRadius$ 12??6[   ?? 5   
   $??5q?6   $??1??6   
??? ? ?$??Stretch=?6?   $ 12??6[   ._?5      ?? $ ??Administracion de Procesos??6   $??18(?69   ???	#DDFFFFFF
???   ?$??
3,-2,-3,-3q?6r   $
??Bold"?6?   5      ?? 5   
   $??5q?6   $??2??6   
??? ? ?$??Stretch=?6?   $ 12??6[   ? 5   
   $??1??6   $??1??6   $	??4,0q?6,    5      ?? 5      $	??32* ?6    ?? 5      $
??341* ?6    ?? 5      $	??36* ?6    .+?5       ?? -   5         ??Name$ 	txtBuscar??5       $??0,0,74,0q?6)   
??????????	#FF2C2C2C$??14(?6e   $??Right=?6s   $??Center=?6?   $??32??6?    J? RenderTransformOrigin$ 0.5,0.5&?6?   $	??268??6?   ?? 5!       J? IsHitTestVisible .  $??Enter Search Term Here??61   $??Center=?6O   $??Right=?6j   $??	0,8,211,8q?6?   
???????$??16??6?   ??5"      ?? 5#       ?? 
TargetType" ??6   .?5$      ??  ?? Property ? y? ?? Value$ 	Collapsed=?67   	 ?? Triggers	 5%      ?? 5&      
 ?? Binding
 6*   ?? *Text+ ?? ElementName$ 	txtBuscar?? ?? Value  6Z   .a?5'   "   ??  ? y?$ Visible=?6?   5(      5*      5,      ?? 5-      -   5         ??Name$ 	btnBuscar??5-      $??Buscar??6(   $??Right=?69   $??Center=?6U   6p   &   System.Windows.Controls.DataGrid  5.      -   5          Name$ 
dgProcesos??5.      $??Stretch=?6+   $??Stretch=?6I   $	??340??6e   $	??500??6u   $??0,6,0,0q?6?   $??1??6?      
IsReadOnly .    AutoGenerateColumns .     Columns 5/      0  *System.Windows.Controls.DataGridTextColumn  50      ,  &System.Windows.Controls.DataGridColumn   Header$ 
id Proceso??6k   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6)   ?? *
id_proceso+   ClipboardContentBinding 6H   Z? 6k     51      $ Nombre Proceso??6o    6)   ?? *nombre_proceso+ 6L   Z? 6o     52      $ Estado??6u    6)   ?? *estado.nombre_estado+ 6R   Z? 6u     53      $ Fecha de Inicio??6?    6)   ?? *fecha_inicio+ ?? StringFormat$ 
dd/MM/yyyy?? 6c   Z? 6?     54      $ Fecha de Termino??6?    6)   ?? *fecha_termino+$ 
dd/MM/yyyy?? 6d   Z? 6?   56      ?? 57      -   5        $ btnCrear??57      $??2??6'   $??Crear Proceso??64   $
??Left=?6L   $??Center=?6g   $??0,4,0,0q?6?   $	??120??6?   ?? 58      -   5        $ 	btnEditar??58      $??2??6(   $??Editar Proceso??65   $
??Left=?6N   $??Center=?6i   $??	125,4,0,0q?6?   $	??123??6?   ?? 59      -   5        $ btnRefrescar??59      $??2??6+   $
??Left=?68   $??Center=?6S   $??	253,4,0,0q?6n   $??46??6?   ???	#FF0096DC???	#FF0096DC.??5:      '  !MaterialDesignThemes.Wpf.PackIcon  -   5          Name$ iconRefrescar??5:   *   $??Center=?6A   $??16??6^   $??16??6i   
???????6u   5;      ?? 5<      -   5        $ btnEliminar??5<      $??2??6*   $??Eliminar??67   $??Right=?6J   $??Center=?6f   ???	#FFC7504A???	#FFC7504A$??84??6?   $??0,4,0,0q?6?   5=      5>      5?      