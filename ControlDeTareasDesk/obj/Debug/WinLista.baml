   M S B A M L   `   `   `  ????N  JControlDeTareasDesk, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:ControlDeTareasDeskControlDeTareasDesk  5   	   "    ControlDeTareasDesk.WinLista   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   U QMaterialDesignThemes.Wpf, Version=2.6.0.325, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   -local!clr-namespace:ControlDeTareasDesk  5   	     ? Title$  WinLista??5	   	   $	??450??6   $	??800??6'   ???	#FF131313 ? WindowStartupLocation$ CenterScreen=?6J   .??5
      ? -   5         ?Name$ 	btnBuscar??5
       ? ColumnDefinitions 5   
   ?? 5      $	??15* ?6   ?? 5      $
??200* ?6   ?? 5      $	??15* ?6    ? RowDefinitions 5   
   ?? 5      $	??41* ?6   ?? 5      $	??42* ?6   ?? 5      $
??287* ?6   ?? 5      $	??49* ?6   .+?5   
   ?? -   5         ??Name$ lblTitle??5      $??Buscador de Tareas??6"   $??1??6?   $??Center=?6O   $	??Top=?6l   $??24(?6?   $??238,0,239,0q?6?   $??42??6?   $	??212??6?   $??2??6?   ?? 5   
   -   5         ??Name$ 	txtBuscar??5      $??1??6%   $??1??62   $??0,5,80,5q?6B   
??????????	#FF2C2C2C$??14(?6~   $??Right=?6?   $??Center=?6?   $??32??6?    J? RenderTransformOrigin$ 0.5,0.5&?6?   $	??268??6?   ?? 5   
   $??1??6   $??1??6!    J? IsHitTestVisible .  $??Enter Search Term Here??6J   $??Center=?6h   $??Right=?6?   $??0,13,211,13q?6?   
???????$??16??6?   $	??124??6?   ??5      ?? 5      	 ?? 
TargetType"	 ??6   .?5      ?? 
 ?? Property
 ? y? ?? Value$ 	Collapsed=?63    ?? Triggers 5      ?? 5       ?? Binding 6&   ?? *Text+ ?? ElementName$ 	txtBuscar?? ?? Value  6V   .a?5      ?? 
 ? y?$ Visible=?6;   5      5!      5#      ?? 5$   
   -   5         ??Name$ 
btn_Buscar??5$      $??Buscar??6%   $??1??66   $??1??6F   $??Right=?6S   $??Center=?6o   $??75??6?   $??32??6?   $??0,5,0,5q?6?   6?   &   System.Windows.Controls.DataGrid  5%   
   -   5          Name$ dgTareas??5%      $y?Hidden=?6%   $??1??69   $??2??6I   $??Stretch=?6V   $??Stretch=?6t      AutoGenerateColumns .     SelectionMode$ Extended=?6?      SelectionUnit$ FullRow=?6?      
IsReadOnly .    CanUserAddRows .     Columns 5&      0  *System.Windows.Controls.DataGridTextColumn  5'      ,  &System.Windows.Controls.DataGridColumn   Header$ Nombre??6i   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6%   ?? *nombre_tarea+   ClipboardContentBinding 6F   Z? 6i     5(      $ Estado??6q    6%   ?? *estado.nombre_estado+ 6N   Z? 6q     5)      $ Fecha de inicio??6?    6%   ?? *fecha_inicio+ ?? StringFormat$ 
dd/MM/yyyy?? 6_   Z? 6?     5*      $ Fecha de Termino??6?    6%   ?? *fecha_termino+$ 
dd/MM/yyyy?? 6`   Z? 6?   5,        5-   
   -   5        $ dgEmpleados??5-      $y?Hidden=?6)   $??1??6=   $??2??6M   $??Stretch=?6Z   $??Stretch=?6x    .  $ Extended=?6?   $ FullRow=?6?    .  .   5.        5/      $	 Rut??6c    6%   ?? *id_rut+ 6@   Z? 6c     50      $ Nombre??6g    6%   ?? *
nombre_emp+ 6D   Z? 6g     51      $	 Rol??6k    6%   ?? *rol.nombre_rol+ 6H   Z? 6k     52      $ Fecha de ingreso??6?    6%   ?? *fecha_ingreso+$ 
dd/MM/yyyy?? 6`   Z? 6?   54      ?? 55   
   -   5        $ 
btnLimpiar??55      $??Limpiar??6%   $??1??67   $??3??6G   $
??Left=?6T   $??0,8,0,9q?6o   $??Center=?6?   $	??108??6?   6?   ?? 56   
   -   5        $ 	btnCerrar??56      $??Cerrar??6%   $??1??66   $??Right=?6F   $??0,0,0,0q?6b   $??3??6s   $??Center=?6?   $??90??6?   ???	#FFC7504A???	#FFC7504A6?   57      58      