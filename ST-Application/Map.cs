using SwissTransport;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ST_Application
{
  class Map
  {
    static Transport transport = new Transport();

    public static void Show(string station)
    {
      Stations stations = transport.GetStations(station);
      if (stations.StationList.Count != 0)
      {
        MapForm mapForm = new MapForm(stations.StationList[0].Coordinate.XCoordinate, stations.StationList[0].Coordinate.YCoordinate);
        mapForm.Show();
      }
    }

    public static void Show()
    {
      
    }
  }
}
