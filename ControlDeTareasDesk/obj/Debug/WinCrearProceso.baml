   M S B A M L   `   `   `  ????N  JControlDeTareasDesk, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:ControlDeTareasDeskControlDeTareasDesk  5   	   )    #ControlDeTareasDesk.WinCrearProceso   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   U QMaterialDesignThemes.Wpf, Version=2.6.0.325, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   -local!clr-namespace:ControlDeTareasDesk  5   	     ? Title$+  %ControlDeTareas - Creacion de proceso??5	   	   $??394.688??67   $??266.564??6H   ???	#FF131313 ? 
ResizeMode$ NoResize=?6o    ? WindowStartupLocation$ CenterScreen=?6?   .??5
      ? .+?5   
   ?? -   5         ??Name$ lblTitle??5      $??Creacion de procesos??6"   $
??Left=?6A   $??	32,10,0,0q?6\   $	??Top=?6o   $??20(?6?   ???	#DDFFFFFF6?   ?? 5   
   -   5        $ 	lblNombre??5      $??Nombre Proceso??6#   $
??Left=?6<   $??	23,72,0,0q?6W   $	??Top=?6j   ???	#DDFFFFFF6?   ?? 5   
   -   5         ??Name$ txtNombreProceso??5      $
??Left=?6,   $??24??6G   $??	28,98,0,0q?6S    ?? TextWrapping$
 Wrap=?6f   $	??Top=?6z   $	??208??6?   ???	#89009C2B
???????6?   ?? 5   
   -   5        $ lblFechaInicio??5      $??Fecha Inicio??6(   $
??Left=?6?   $??
23,126,0,0q?6Z   $	??Top=?6n   ???	#DDFFFFFF6?   (  "System.Windows.Controls.DatePicker  5   
   -   5          Name$ dtpFechaInicio??5      $
??Left=?6-   $??
28,152,0,0q?6H   $	??Top=?6\   $	??208??6t   $??24??6?   
??????????	#89009C2B6?   ?? 5   
   -   5        $ lblFechaTermino??5      $??Fecha Termino??6)   $
??Left=?6A   $??
23,180,0,0q?6\   $	??Top=?6p   ???	#DDFFFFFF6?     5   
   -   5        $ dtpFechaTermino??5      $
??Left=?6.   $??
28,206,0,0q?6I   $	??Top=?6]   $	??208??6u   $??24??6?   ???	#89009C2B
???????6?   ?? 5   
   -   5         ??Name$ 
btnGuardar??5      $??Guardar??6%   $
??Left=?67   $??
28,304,0,0q?6R   $	??Top=?6f   $??94??6~   6?   ?? 5   
   -	   5        $ btnCancelar??5      $??Cancelar??6&   $
??Left=?69   $??142,304,0,0q?6T   $	??Top=?6i   $??94??6?   ???	#FFC7504A???	#FFC7504A6?   5      5      