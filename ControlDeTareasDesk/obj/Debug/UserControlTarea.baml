   M S B A M L   `   `   `  ????N  JControlDeTareasDesk, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:ControlDeTareasDeskControlDeTareasDesk  5      *    $ControlDeTareasDesk.UserControlTarea   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      U QMaterialDesignThemes.Wpf, Version=2.6.0.325, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      -local!clr-namespace:ControlDeTareasDesk  5      .??5
      ?   ? ColumnDefinitions  5   
   ?? 5      ?? 5      $	??18* ?6   ?? 5       ? RowDefinitions 5   
   ?? 5      $??41 ?6   ?? 5      .+?5   
   ?? $??5q?6   $??0??6   
??? ? ?$??Stretch=?6?    ?? CornerRadius$ 12??6[   ?? 5   
   $??5q?6   $??1??6   
??? ? ?$??Stretch=?6?   $ 12??6[   ._?5      ?? $??Administracion de Tareas??6   $??18(?67   ???	#DDFFFFFF
???   ?$??
3,-2,-3,-3q?6p   $
??Bold"?6?   5      ?? 5   
   $??5q?6   $??2??6   
??? ? ?$??Stretch=?6?   $ 12??6[   ? 5   
   $??1??6   $??1??6   $	??4,0q?6,    5      ?? 5      $	??32* ?6    ?? 5      $
??341* ?6    ?? 5      $	??36* ?6    .+?5       ?? -   5         ??Name$ 	txtBuscar??5       $??0,0,74,0q?6)   
??????????	#FF2C2C2C$??14(?6e   $??Right=?6s   $??Center=?6?   $??32??6?    J? RenderTransformOrigin$ 0.5,0.5&?6?   $	??268??6?   ?? 5!       J? IsHitTestVisible .  $??Enter Search Term Here??61   $??Center=?6O   $??Right=?6j   $??	0,8,211,8q?6?   
???????$??16??6?   ??5"      ?? 5#       ?? 
TargetType" ??6   .?5$      ??  ?? Property ? y? ?? Value$ 	Collapsed=?67   	 ?? Triggers	 5%      ?? 5&      
 ?? Binding
 6*   ?? *Text+ ?? ElementName$ 	txtBuscar?? ?? Value  6Z   .a?5'   "   ??  ? y?$ Visible=?6?   5(      5*      5,      ?? 5-      -   5         ??Name$ 	btnBuscar??5-      $??Buscar??6(   $??Right=?69   $??Center=?6U   6p   &   System.Windows.Controls.DataGrid  5.      -   5          Name$ dgTareas??5.      $??Stretch=?6)   $??Stretch=?6G   $??0,6,0,0q?6c   $??1??6t      
IsReadOnly .    AutoGenerateColumns .     Columns 5/      0  *System.Windows.Controls.DataGridTextColumn  50      ,  &System.Windows.Controls.DataGridColumn   Header$ Id Tarea??6i   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6)   ?? *
id_tarea+   ClipboardContentBinding 6F   Z? 6i     51      $ Nombre Tarea??6m    6)   ?? *nombre_tarea+ 6J   Z? 6m     52      $ Nombre Unidad??6u    6)   ?? *unidad.nombre_unidad+ 6R   Z? 6u     53      $ Nombre Proceso??6~    6)   ?? *unidad.proceso.nombre_proceso+ 6[   Z? 6~     54      $ Estado??6u    6)   ?? *estado.nombre_estado+ 6R   Z? 6u     55      $ Fecha de Inicio??6?    6)   ?? *fecha_inicio+ ?? StringFormat$ 
dd/MM/yyyy?? 6c   Z? 6?     56      $ Fecha de Termino??6?    6)   ?? *fecha_termino+$ 
dd/MM/yyyy?? 6d   Z? 6?   58      ?? 59      -   5        $ btnCrear??59      $??2??6'   $??Crear Tarea??64   $
??Left=?6J   $??Center=?6e   $??0,5,0,1q?6?   $	??103??6?   ?? 5:      -   5        $ 	btnEditar??5:      $??2??6(   $??Editar Tarea??65   $
??Left=?6L   $??Center=?6g   $??	108,5,0,1q?6?   $	??106??6?   ?? 5;      -   5        $ btnRefrescar??5;      $??2??6+   $
??Left=?68   $??Center=?6S   $??	219,5,0,1q?6n   $??46??6?   ???	#FF0096DC???	#FF0096DC.??5<      '  !MaterialDesignThemes.Wpf.PackIcon  -   5          Name$ iconRefrescar??5<   *   $??Center=?6A   $??16??6^   $??16??6i   
???????6u   5=      ?? 5>      -   5        $ btnEliminar??5>      $??2??6*   $??Eliminar??67   $??Right=?6J   $??Center=?6f   ???	#FFC7504A???	#FFC7504A$??84??6?   $??0,5,0,1q?6?   5?      5@      5A      