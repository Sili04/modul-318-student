using SwissTransport;
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
  partial class VerbindungenSuchenForm : Form
  {
    Transport transport = new Transport();
    bool toggleView = false;
    bool abfahrtAnkunftToggle = false;

    public VerbindungenSuchenForm()
    {
      InitializeComponent();
    }

    private void tbxStartLocation_TextChanged(object sender, EventArgs e)
    {
      if (tbxStartLocation.Text.Length != 0 && tbxZielLocation.Text.Length != 0)
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
      if (tbxStartLocation.Text.Length != 0 && tbxZielLocation.Text.Length != 0)
      {
        Cursor.Current = Cursors.WaitCursor;
        tbxStartLocation.BackColor = Color.White;
        tbxZielLocation.BackColor = Color.White;
        Connections connections = transport.GetConnections(tbxStartLocation.Text, tbxZielLocation.Text, 16, "2020-11-26", timePicker.Text, 2);
        if (connections.ConnectionList.Count != 0)
        {
          UpdateData(connections);
        }
        else
        {
          tbxStartLocation.BackColor = Color.Red;
          tbxZielLocation.BackColor = Color.Red;
          tbxStartLocation.Text = "";
          tbxZielLocation.Text = "";
        }
        Cursor.Current = Cursors.Default;
      }
    }

    private void UpdateData(Connections connections)
    {
      lb.Items.Clear();
      foreach (Connection connection in connections.ConnectionList)
      {
        TimeSpan duration = TimeSpan.Parse(connection.Duration.Replace("d", ":"));
        String connectionInformations = "Zeit: " + DateTime.Parse(connection.From.Departure).ToString("HH:mm") + " - " + DateTime.Parse(connection.To.Arrival).ToString("HH:mm") + "\t\tDauer: " + duration.ToString(@"hh\:mm") + "\t\tVon: " + connection.From.Station.Name + "\t Kante: " + connection.From.Platform + "\t\t Nach: " + connection.To.Station.Name + "\t Gleis: " + connection.To.Platform;
        lb.Items.Add(connectionInformations);
      }
    }

    private void btnToggleView_Click(object sender, EventArgs e)
    {
      toggleView = !toggleView;
      if (toggleView)
      {
        btnToggleView.Text = "Verbindungen suchen";
        tbxZielLocation.Enabled = false;
        btnAbfahrtAnkunftToggle.Enabled = false;
        btnAbfahrtAnkunftToggle.Text = "Abfahrt";
      }
      else
      {
        btnToggleView.Text = "Abfahrtstafel";
        tbxZielLocation.Enabled = true;
        btnAbfahrtAnkunftToggle.Enabled = true;
      }
    }

    private void btnAbfahrtAnkunftToggle_Click(object sender, EventArgs e)
    {
      abfahrtAnkunftToggle = !abfahrtAnkunftToggle;
    }
  }
}

