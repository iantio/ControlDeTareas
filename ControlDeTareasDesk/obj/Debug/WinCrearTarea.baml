   M S B A M L   `   `   `  ????N  JControlDeTareasDesk, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:ControlDeTareasDeskControlDeTareasDesk  5   	   '    !ControlDeTareasDesk.WinCrearTarea   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   3local!clr-namespace:ControlDeTareasDesk     5   	     ? Title$$  ControlDeTareas - Crear Tareas??5   	   $??517.5??60   $??316.25??6?   ???	#FF131313 ? 
ResizeMode$ NoResize=?6e    ? WindowStartupLocation$ CenterScreen=?6{   .??5	      ? .+?5
   
   ?? -   5         ??Name$ lblNombreTarea??5
      $??Nombre tarea??6(   $
??Left=?6?   $??	46,84,0,0q?6Z   $	??Top=?6m   ???	#DDFFFFFF6?   ?? 5   
   -   5         ??Name$ 	txtNombre??5      $
??Left=?6%   $??22??6@   $??
50,106,0,0q?6L    ?? TextWrapping$
 Wrap=?6`   $	??Top=?6t   $	??208??6?   
??????????	#89009C2B6?   ?? 5   
   -   5        $ lblTitle??5      $??Creacion de tareas??6"   $
??Left=?6?   $??55,0,0,0q?6Z   $	??Top=?6l   ???	#DDFFFFFF$??20(?6?   ?? 5   
   -   5        $ lblFechaInicio??5      $??Fecha de inicio??6(   $
??Left=?6B   $??
46,133,0,0q?6]   $	??Top=?6q   ???	#DDFFFFFF6?   (  "System.Windows.Controls.DatePicker  5   
   -   5          Name$ dtpFechaInicio??5      $
??Left=?6-   $??
50,154,0,0q?6H   $	??Top=?6\   $	??208??6t   ???	#89009C2B
??????????	#000000006?   ?? 5   
   -   5        $ lblFechaTermino??5      $??Fecha de termino??6)   $
??Left=?6D   $??
46,184,0,0q?6_   $	??Top=?6s   ???	#DDFFFFFF6?     5   
   -   5        $ dtpFechaTermino??5      $
??Left=?6.   $??
50,205,0,0q?6I   $	??Top=?6]   $	??208??6u   ???	#89009C2B
??????????	#000000006?   ?? 5   
   -   5        $ 
lblProceso??5      $??Proceso??6$   $
??Left=?66   $??
46,235,0,0q?6Q   $	??Top=?6e   ???	#DDFFFFFF6}   ?? 5   
   -	   5         ??Name$ 
cmbProceso??5       ?? DisplayMemberPath$ nombre_proceso??6'   	 ?? SelectedValuePath$	 
id_proceso??6J   $
??Left=?6i   $??
50,257,0,0q?6?   $	??Top=?6?   $	??208??6?   ???	#89009C2B
???????
 ?? SelectedIndex$
 0??6?   ???	#FF131313 ?? 
IsReadOnly . $??25??6"  6.  ?? 5   
   -
   5        $ 	lblUnidad??5      $??Unidad??6#   $
??Left=?64   $??
46,287,0,0q?6O   $	??Top=?6c   ???	#DDFFFFFF6{   ?? 5   
   -   5        $ 	cmbUnidad??5      $ nombre_unidad??6&   $	 	id_unidad??6H   $
??Left=?6f   $??
50,309,0,0q?6?   $	??Top=?6?   $	??208??6?   ???	#89009C2B$
 0??6?   
???????6?   ?? 5   
   -   5         ??Name$ 
btnGuardar??5      $??Guardar??6%   $
??Left=?67   $??
46,424,0,0q?6R   $	??Top=?6f   $	??101??6~   6?   ?? 5   
   -   5        $ btnCancelar??5      $??Cancelar??6&   $
??Left=?69   $??163,424,0,0q?6T   $	??Top=?6i   $??95??6?   ???	#FFC7504A???	#FFC7504A6?   ?? 5   
   -   5        $ 
lbl_Estado??5      $??Estado tarea??6$   $
??Left=?6;   $??
46,341,0,0q?6V   $	??Top=?6j   ???	#DDFFFFFF6?   ?? 5   
   -   5        $ 	cmbEstado??5      $ nombre_estado??6&   $	 	id_estado??6H   $
??Left=?6f   $??
50,363,0,0q?6?   $	??Top=?6?   $	??208??6?   ???	#89009C2B
??????? . $
 0??6?   5      5      