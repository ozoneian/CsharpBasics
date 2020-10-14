using System.Reflection.PortableExecutable;
using System.Windows.Controls;

namespace BusStopWPF
{
    public class BusStop
    {
        public double CanvasPos { get; set; }
        public string Name { get; set; }
        public TextBlock Info { get; set; }

        public BusStop(double canvasPos, string name)
        {
            CanvasPos = canvasPos;
            Name = name;
        }
        public void MakeBusStop()
        {
            
        }
    }
}
