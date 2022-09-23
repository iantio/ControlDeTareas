using System.Windows.Controls;

namespace ControlDeTareasDesk
{
    public class SubItem
    {
        public SubItem(string name, UserControl screen = null)
        {
            Name = name;
            Screen = screen;
        }

        public bool Estado { get; set; }
        public string Name { get; private set; }
        public UserControl Screen { get; private set; }
    }
}
