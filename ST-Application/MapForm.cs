using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ST_Application
{
  public partial class MapForm : Form
  {
    double XCoordinate;
    double YCoordinate;

    public MapForm(double XCoordinate, double YCoordinate)
    {
      InitializeComponent();
      this.XCoordinate = XCoordinate;
      this.YCoordinate = YCoordinate;
    }

    private void MapForm_Load(object sender, EventArgs e)
    {
      gmap.DragButton = MouseButtons.Left;
      gmap.CanDragMap = true;
      gmap.MapProvider = GMapProviders.GoogleMap;
      gmap.Position = new PointLatLng(XCoordinate, YCoordinate);
      gmap.MinZoom = 0;
      gmap.MaxZoom = 24;
      gmap.Zoom = 9;
      gmap.AutoScroll = true;


      GMapOverlay markersOverlay = new GMapOverlay("marker1");
      GMarkerGoogle marker = new GMarkerGoogle(new PointLatLng(XCoordinate, YCoordinate), GMarkerGoogleType.red);
      markersOverlay.Markers.Add(marker);
      gmap.Overlays.Add(markersOverlay);
    }
  }
}
