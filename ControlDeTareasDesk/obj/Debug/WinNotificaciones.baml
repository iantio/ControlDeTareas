   M S B A M L   `   `   `  ????N  JControlDeTareasDesk, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:ControlDeTareasDeskControlDeTareasDesk  5   	   +    %ControlDeTareasDesk.WinNotificaciones   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   U QMaterialDesignThemes.Wpf, Version=2.6.0.325, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   -local!clr-namespace:ControlDeTareasDesk  5   	     ? Title$  WinNotificaciones??5	   	   $??564.137??6#   $??385.477??64   ???	#FF131313 ? WindowStartupLocation$ CenterScreen=?6[    ? 
ResizeMode$ NoResize=?6?   .??5      ? .+?5   
   ?? -   5         ??Name$ lblSinNotificaciones??5      $??Sin notificaciones??6.   $??Center=?6K   $??Center=?6h   $??36(?6?   $
??Bold"?6?   $y?	Collapsed=?6?   ?? 5   
   -   5         ??Name$ itemsNotificacion??5       ? IsSharedSizeScope . ??5      ?? 5      .R?5      ??  ??Name$ Border??6    ?? Padding$ 8q?6-   $??0,0,0,1q?69      MaterialDesignDivider#???   6S   ._?5      ? $??Stretch=?6    ? ColumnDefinitions 5      ?? 5   "   $??40 ?63   ?? 5   "   $	??200 ?63   ?? 5   "   $??* ?63   .+?5      d? $??0??6+   $
??Left=?6;   $??Center=?6V    ) %MaterialDesignActionLightToggleButton#??[ 6?   	 d? 	IsChecked	 6q   ?? *
IsSelected+??6?   ?? *Code+?? 5      $??0,0,0,0q?6*   $??1??6;   .+?5   "   ?? $
??Bold"?6,   $&?? Solicitud de asignacion de tarea??6>   
???????6f   ?? 5   "   
?????????6,   ?? *%#tarea.unidad.proceso.nombre_proceso+6a   ?? 5   "   
?????????6,   ?? *tarea.unidad.nombre_unidad+6X   ?? 5   "   
?????????6,   ?? *tarea.nombre_tarea+6P   5      ?? 5      $??2??6)   $??Right=?69   $??0,0,0,0q?6U   .+?5   "   ?? 
 ??Name$
 
btnAceptar??6)   -   5        $??Aceptar??5   >   $??0,0,0,1q?6P   ???	#FF4CAF50
?????? +  %MaterialDesignThemes.Wpf.ButtonAssist   CornerRadius$ 10??6?   ?? 5    "   $
 btnRechazar??6)   -   5        $??Rechazar??5    >   ???	#FFC7504A
?????? $ 10??6?   6?   5!      5"      5#       ?? Triggers 5$      ?? 5%       ?? Value$
 True??6E    ?? Binding 6&   ?? *
IsSelected+.a?5&      ??  ?? 
TargetName$ Border??6%     MaterialDesignSelection ?? Value# ?  6O    ?? Property ? ??5'      5)      5+      5,      5-      