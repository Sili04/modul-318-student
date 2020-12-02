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
        string XCoordinate = stations.StationList[0].Coordinate.XCoordinate.ToString().Replace(',', '.');
        string YCoordinate = stations.StationList[0].Coordinate.YCoordinate.ToString().Replace(',', '.');
        Process.Start("https://www.google.com/maps/search/" + XCoordinate + "," + YCoordinate);
      }
    }

    public static void Show()
    {
      Process.Start("https://www.google.com/maps/");
    }
  }
}
