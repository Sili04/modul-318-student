using SwissTransport;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ST_Application
{
  partial class VerbindungenSuchenForm : Form
  {
    Transport transport = new Transport();
    bool abfahrtstafelShown = false;
    int abfahrtAnkunftToggle = 0;

    public VerbindungenSuchenForm()
    {
      InitializeComponent();
      timePicker.Text = DateTime.Now.ToString("HH:mm");
      datePicker.Text = DateTime.Now.ToString("dd.MM.yyyy");
    }

    private void tbxLocationChanged()
    {
      tbxStartLocation.BackColor = Color.White;
      tbxZielLocation.BackColor = Color.White;
      if (tbxStartLocation.Text.Length != 0 && tbxZielLocation.Text.Length != 0 && !abfahrtstafelShown)
      {
        btnSearch.Enabled = true;
      }
      else if (abfahrtstafelShown && tbxStartLocation.Text.Length != 0)
      {
        btnSearch.Enabled = true;
      }
      else
      {
        btnSearch.Enabled = false;
      }
    }

    private AutoCompleteStringCollection GenerateAutocompleteSource(string query)
    {
      AutoCompleteStringCollection source = new AutoCompleteStringCollection();
      Stations stations = transport.GetStations(query);
      if (query.Length > 2)
      {
        foreach (Station station in stations.StationList)
        {
          source.Add(station.Name);
        }
      }

      return source;
    }

    private void btnSearch_Click(object sender, EventArgs e)
    {
      if (tbxStartLocation.Text.Length != 0)
      {
        Cursor.Current = Cursors.WaitCursor;
        DateTime dateTime = DateTime.Parse(datePicker.Text);
        try
        {
          if (!abfahrtstafelShown && tbxZielLocation.Text.Length != 0)
          {
            Connections connections = transport.GetConnections(tbxStartLocation.Text, tbxZielLocation.Text, 16, dateTime.ToString("yyyy-MM-dd"), timePicker.Text, abfahrtAnkunftToggle);
            if (connections.ConnectionList.Count != 0)
            {
              UpdateConnectionData(connections);
            }
            else
            {
              ErrorMessage();
            }
          } else if (abfahrtstafelShown)
          {
            StationBoardRoot stationBoardRoot = transport.GetStationBoard(tbxStartLocation.Text, "0", dateTime.ToString("yyyy-MM-dd") + " " + DateTime.Parse(timePicker.Text).ToString("HH:mm"));
            if (stationBoardRoot.Entries.Count != 0)
            {
              UpdateStationBoardData(stationBoardRoot);
            }
            else
            {
              ErrorMessage();
            }
          }
        }
        catch (Exception)
        {
          ErrorMessage();
        }
        Cursor.Current = Cursors.Default;
      }
    }

    private void ErrorMessage()
    {
      tbxStartLocation.Text = "";
      tbxZielLocation.Text = "";
      tbxStartLocation.BackColor = Color.Red;
      tbxZielLocation.BackColor = Color.Red;
    }

    private void UpdateConnectionData(Connections connections)
    {
      dgv.Rows.Clear();
      dgv.Columns.Clear();
      dgv.Columns.Add("Datum", "Datum");
      dgv.Columns.Add("Abfahrtzeit", "Abfahrtzeit");
      dgv.Columns.Add("Ankunftzeit", "Ankunftzeit");
      dgv.Columns.Add("Dauer", "Dauer");
      dgv.Columns.Add("Abfahrtsort", "Abfahrtsort");
      dgv.Columns.Add("Kante Abfahrtsort", "Kante Abfahrtsort");
      dgv.Columns.Add("Ankunftsort", "Ankunftsort");
      dgv.Columns.Add("Kante Ankunftsort", "Kante Ankunftsort");

      foreach (Connection connection in connections.ConnectionList)
      {
        TimeSpan duration = TimeSpan.Parse(connection.Duration.Replace("d", ":"));
        dgv.Rows.Add(new[] { DateTime.Parse(connection.From.Departure).ToString("dd.MM.yyyy"), DateTime.Parse(connection.From.Departure).ToString("HH:mm"), DateTime.Parse(connection.To.Arrival).ToString("HH:mm"), duration.ToString(@"hh\:mm"), connection.From.Station.Name, connection.From.Platform, connection.To.Station.Name, connection.To.Platform });
      }
    }

    private void UpdateStationBoardData(StationBoardRoot stationBoardRoot)
    {
      dgv.Rows.Clear();
      dgv.Columns.Clear();
      dgv.Columns.Add("Datum", "Datum"); 
      dgv.Columns.Add("Abfahrtzeit", "Abfahrtzeit");
      dgv.Columns.Add("Abfahrtsort", "Abfahrtsort");
      dgv.Columns.Add("Richtung", "Richtung");
      dgv.Columns.Add("Linie", "Linie");
      foreach (StationBoard stationBoard in stationBoardRoot.Entries)
      {
        dgv.Rows.Add(new[] { stationBoard.Stop.Departure.ToString("dd.MM.yyyy"), stationBoard.Stop.Departure.ToString("HH:mm"), stationBoardRoot.Station.Name, stationBoard.To, stationBoard.Name});
      }
    }

    private void btnToggleView_Click(object sender, EventArgs e)
    {
      abfahrtstafelShown = !abfahrtstafelShown;
      if (abfahrtstafelShown)
      {
        this.Text = "�V finder - Abfahrtstafel";
        btnToggleView.Text = "Verbindungen suchen";
        tbxZielLocation.Enabled = false;
        btnAbfahrtAnkunftToggle.Enabled = false;
        btnAbfahrtAnkunftToggle.Text = "Abfahrt";
      }
      else
      {
        this.Text = "�V finder - Verbindungen suchen";
        btnToggleView.Text = "Abfahrtstafel";
        tbxZielLocation.Enabled = true;
        btnAbfahrtAnkunftToggle.Enabled = true;
        btnAbfahrtAnkunftToggle_Click(null, null);
      }
    }

    private void btnAbfahrtAnkunftToggle_Click(object sender, EventArgs e)
    {
      if (abfahrtAnkunftToggle == 0)
      {
        abfahrtAnkunftToggle = 1;
        btnAbfahrtAnkunftToggle.Text = "Ankunft um";
      }
      else
      {
        abfahrtAnkunftToggle = 0;
        btnAbfahrtAnkunftToggle.Text = "Abfahrt um";
      }
    }

    private void tbxStartLocation_TextChanged(object sender, EventArgs e)
    {
      tbxStartLocation.AutoCompleteCustomSource = GenerateAutocompleteSource(tbxStartLocation.Text);
      if (tbxStartLocation.Text.Length != 0)
      {
        btnMapStartStation.Enabled = true;
      }
      else
      {
        btnMapStartStation.Enabled = false;
      }
      tbxLocationChanged();
    }

    private void tbxZielLocation_TextChanged(object sender, EventArgs e)
    {
      tbxZielLocation.AutoCompleteCustomSource = GenerateAutocompleteSource(tbxZielLocation.Text);
      if (tbxZielLocation.Text.Length != 0)
      {
        btnMapZielStation.Enabled = true;
      }
      else
      {
        btnMapZielStation.Enabled = false;
      }
      tbxLocationChanged();
    }

    private void btnMapStartStation_Click(object sender, EventArgs e)
    {
      OpenStationOnMap(tbxStartLocation.Text);
    }

    private void btnMapZielStation_Click(object sender, EventArgs e)
    {
      OpenStationOnMap(tbxZielLocation.Text);
    }

    private void OpenStationOnMap(string station)
    {
      Stations stations = transport.GetStations(station);
      if (stations.StationList.Count != 0)
      {
        string locationFormatted = stations.StationList[0].Name.Replace("/", " ");
        Process.Start("https://www.google.com/maps/search/" + locationFormatted);
      }
    }

    private void OpenDirectionOnMap(string startLocation, string endLocation)
    {
      Stations startStations = transport.GetStations(startLocation);
      Stations endStations = transport.GetStations(endLocation);
      if (startStations.StationList.Count != 0 && endStations.StationList.Count != 0)
      {
        string startLocationFormatted = startStations.StationList[0].Name.Replace("/", " ");
        string endLocationFormatted = endStations.StationList[0].Name.Replace("/", " ");
        Process.Start("https://www.google.com/maps/dir/" + startLocationFormatted + "/" + endLocationFormatted);
      }
    }
  }
}

