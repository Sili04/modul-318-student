using SwissTransport;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Device.Location;

namespace ST_Application
{
  partial class VerbindungenSuchenForm : Form
  {
    Transport transport = new Transport();
    IntellisenseController intellisenseController = new IntellisenseController();
    bool abfahrtstafelShown = false;
    int abfahrtAnkunftToggle = 0;

    public VerbindungenSuchenForm()
    {
      InitializeComponent();
      timePicker.Text = DateTime.Now.ToString("HH:mm");
      datePicker.Text = DateTime.Now.ToString("dd.MM.yyyy");
      CheckConnection();
    }

    private void CheckConnection()
    {
      PingReply result = null;
      while (result == null)
      {
        LoadingForm loadingForm = new LoadingForm();
        try
        {
          loadingForm.Show();
          result = new Ping().Send("google.com", 500);
          loadingForm.Close();
        }
        catch (Exception)
        {
          loadingForm.Close();
          DialogResult dialogResult = MessageBox.Show("Sie haben keine Internetverbindung! Bitte stellen Sie eine aktive Verbindung mit dem Internet her.", "Keine Internetverbindung", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
          if (dialogResult == DialogResult.Cancel)
          {
            Environment.Exit(0);
          }
        }
      }
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
        this.Text = "ÖV finder - Abfahrtstafel";
        btnToggleView.Text = "Verbindungen suchen";
        tbxZielLocation.Enabled = false;
        btnAbfahrtAnkunftToggle.Enabled = false;
        btnAbfahrtAnkunftToggle.Text = "Abfahrt";
      }
      else
      {
        this.Text = "ÖV finder - Verbindungen suchen";
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

    private void tbxStartLocation_TextChanged(object sender, KeyEventArgs e)
    {
      if (intellisenseController.CalculateFireEvent(e))
      {
        UpdateIntellisenseForStartLocation();
      }

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

    private void UpdateIntellisenseForStartLocation()
    {
      while (tbxStartLocation.Items.Count > 0)
      {
        tbxStartLocation.Items.RemoveAt(0);
      }
      List<string> stations = intellisenseController.GenerateAutocompleteSource(tbxStartLocation.Text);
      foreach (String station in stations)
      {
        if (station != null)
        {
          tbxStartLocation.Items.Add(station);
        }
      }
      tbxStartLocation.DroppedDown = true;
    }

    private void tbxZielLocation_TextChanged(object sender, KeyEventArgs e)
    {
      if (intellisenseController.CalculateFireEvent(e))
      {
        UpdateIntellisenseForZielLocation();
      }

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

    private void UpdateIntellisenseForZielLocation()
    {
      while (tbxZielLocation.Items.Count > 0)
      {
        tbxZielLocation.Items.RemoveAt(0);
      }
      List<string> stations = intellisenseController.GenerateAutocompleteSource(tbxZielLocation.Text);
      foreach (String station in stations)
      {
        if (station != null)
        {
          tbxZielLocation.Items.Add(station);
        }
      }
      tbxZielLocation.DroppedDown = true;
    }

    private void btnMapStartStation_Click(object sender, EventArgs e)
    {
      Map.Show(tbxStartLocation.Text);
    }

    private void btnMapZielStation_Click(object sender, EventArgs e)
    {
      Map.Show(tbxZielLocation.Text);
    }

    private void btnSendEmail_Click(object sender, EventArgs e)
    {
      string emailText = GenerateMailText();
      Process.Start("mailto: " + "?subject=ÖV-finder" + tbxMail.Text + "&body=" + emailText);
    }

    private string GenerateMailText()
    {
      string emailText = "";
      emailText += "Verbindungen: ";
      foreach (DataGridViewRow row in dgv.SelectedRows)
      {
        emailText += "\n";
        foreach (DataGridViewCell cell in row.Cells)
        {
          emailText += cell.Value + "; ";
        }
      }

      return emailText;
    }

    private void dgv_CellClick(object sender, DataGridViewCellEventArgs e)
    {
      BtnSendValidation();
    }

    private void tbxMail_TextChanged(object sender, EventArgs e)
    {
      BtnSendValidation();
    }

    private void BtnSendValidation()
    {
      if (dgv.SelectedRows.Count != 0 && tbxMail.Text.Length != 0)
      {
        btnSendEmail.Enabled = true;
      }
      else
      {
        btnSendEmail.Enabled = false;
      }
    }

    private void btnShowMap_Click(object sender, EventArgs e)
    {
      GeoCoordinateWatcher watcher = new GeoCoordinateWatcher();

      string x = watcher.Position.Location.Latitude.ToString();
      string y = watcher.Position.Location.Longitude.ToString();

        dgv.Rows.Clear();
        dgv.Columns.Clear();
        dgv.Columns.Add("Name", "Name");
        dgv.Columns.Add("Entfernung", "Entfernung");
        Stations stations = transport.GetNextStations(x, y);
        foreach (Station station in stations.StationList)
        {
          dgv.Rows.Add(new[] { station.Name, station.Distance + "m" });
        }
    }

    private void VerbindungenSuchenForm_Load(object sender, EventArgs e)
    {

    }
  }
}

