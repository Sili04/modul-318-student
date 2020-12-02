using SwissTransport;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ST_Application
{
  class IntellisenseController
  {

    Transport transport = new Transport();
    
    public bool CalculateFireEvent(KeyEventArgs e)
    {
      if (e.KeyCode != Keys.Down && e.KeyCode != Keys.Up && e.KeyCode != Keys.Enter)
      {
        return true;
      }
      else
      {
        return false;
      }
    }

    public List<string> GenerateAutocompleteSource(string query)
    {
      List<string> source = new List<string>();
      try
      {
        Stations stations = transport.GetStations(query);
        foreach (Station station in stations.StationList)
        {
          source.Add(station.Name);
        }
        if (source.Count == 0)
        {
          source.Add("Keine Ergebnisse");
        }
      }
      catch (Exception)
      {

      }

      return source;
    }
  }
}
