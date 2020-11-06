using System.Windows.Forms;

namespace FlightPathVector.server
{
  class Program
  {
    static ConfigPanel myForm;

    static void Main(string[] args)
    {
      Application.EnableVisualStyles();
      Application.SetCompatibleTextRenderingDefault(false);
      myForm = new ConfigPanel();
      Application.Run(myForm);
    }
  }
}