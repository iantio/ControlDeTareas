   M S B A M L   `   `   `  ????N  JControlDeTareasDesk, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:ControlDeTareasDeskControlDeTareasDesk  5   	   '    !ControlDeTareasDesk.MenuPrincipal   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   3local!clr-namespace:ControlDeTareasDesk     5   	   U QMaterialDesignThemes.Wpf, Version=2.6.0.325, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	     ? Title$(  "Control de Tareas - Menu Principal??5	   	   $	??647??64   $
??1200??6A   ???	#FF131313 ? WindowStartupLocation$ CenterScreen=?5
   	   .??5      ?  ? RowDefinitions 5   
   ?? 5      $
??auto ?6   $	??146??6*   ?? 5       ? ColumnDefinitions 5   
   ?? 5      $	??250 ?6   ?? 5      $??* ?6   .+?5   
   ? $??Stretch=?6   $??0??6-      PrimaryHueDarkBrush#??[  6:   $??2??6l    5      ?? 5      $	??150 ?6    ?? 5      .+?5      ? 
??? ? ?6   ?? 5      -   5         ??Name$ 
imgEmpresa??5      ?? 5      $??Stretch=?6   $??Disabled=?69   $
??Auto=?6b   $??1??6?   $??0,5,0,52q?6?   .??5      ?? -   5         ??Name$
 Menu??5      $??10q?6+   5      ?? 5      -   5         ??Name$ btnCerrarSesion??5      $??Cerrar Sesión??6.   $??Stretch=?6F   $??
10,0,10,10q?6d   $??Bottom=?6x   $??37??6?   
???????
???????$
??Bold"?6?   $??14(?6?   
???   ?$??1??6  5       ? 5!   
   -   5         ?Name$ StackPanelMain??5!      $??1??6(   $??1??65   $??Stretch=?6E   ?? 5"   
   -   5        $ 
imgUsuario??5"      $
??Left=?6$   $??69??6?   $	??Top=?6K   $??68??6c   $??	47,10,0,0q?6n   $??usuario.png??6?   $??1??6?   ?? 5#   
   -   5         ??Name$ lblBienvenida??5#      $??¡Bienvenido Usuario!??6'   $
??Left=?6F   $??
121,10,0,0q?6a   $	??Top=?6u   
???????$??24(?6?   $??51??6?   $	??818??6?   $??1??6?   ?? 5$   
   -   5        $ lblRol??5$      $	??Rol??6    $
??Left=?6.   $??
121,43,0,0q?6I   $	??Top=?6]   
???????$??14(?6?   $??1??6?   $??29??6?   $	??818??6?   %  MaterialDesignThemes.Wpf.Badged  5%   
   -   5        	  Name$	 countNotificacion??5%         ControlzEx.BadgedEx
   Badge$
  ??6;      BadgeBackground
 ?  ??$??Right=?6Z   $	??Top=?6v   $??1??6?   $??	0,13,30,0q?6?   .??5&      ?? -	   5        $ btnNotificacion??5&       0 ,MaterialDesignFloatingActionMiniAccentButton#??[ 5'       ? ToolTip$2 ,MaterialDesignFloatingActionMiniAccentButton??5(      .??5)      '  !MaterialDesignThemes.Wpf.PackIcon  ?  ?ControlzEx.PackIconBase`1[[MaterialDesignThemes.Wpf.PackIconKind, MaterialDesignThemes.Wpf, Version=2.6.0.325, Culture=neutral, PublicKeyToken=null]]   Kind$ Email=?5*      $??24??5+      $??24??5,      5-      5.      5/      50      