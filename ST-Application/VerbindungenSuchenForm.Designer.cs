﻿namespace ST_Application
{
  partial class VerbindungenSuchenForm
  {
    /// <summary>
    /// Erforderliche Designervariable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Verwendete Ressourcen bereinigen.
    /// </summary>
    /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
    protected override void Dispose(bool disposing)
    {
      if (disposing && (components != null))
      {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Vom Windows Form-Designer generierter Code

    /// <summary>
    /// Erforderliche Methode für die Designerunterstützung.
    /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
    /// </summary>
    private void InitializeComponent()
    {
      this.spContainer = new System.Windows.Forms.SplitContainer();
      this.btnToggleView = new System.Windows.Forms.Button();
      this.btnSearch = new System.Windows.Forms.Button();
      this.cbSettings = new System.Windows.Forms.ComboBox();
      this.gbZeitDatum = new System.Windows.Forms.GroupBox();
      this.datePicker = new System.Windows.Forms.DateTimePicker();
      this.timePicker = new System.Windows.Forms.DateTimePicker();
      this.btnAbfahrtAnkunftToggle = new System.Windows.Forms.Button();
      this.gbLocation = new System.Windows.Forms.GroupBox();
      this.tbxZielLocation = new System.Windows.Forms.TextBox();
      this.tbxStartLocation = new System.Windows.Forms.TextBox();
      this.lbZiel = new System.Windows.Forms.Label();
      this.lbStart = new System.Windows.Forms.Label();
      this.lb = new System.Windows.Forms.ListBox();
      ((System.ComponentModel.ISupportInitialize)(this.spContainer)).BeginInit();
      this.spContainer.Panel1.SuspendLayout();
      this.spContainer.Panel2.SuspendLayout();
      this.spContainer.SuspendLayout();
      this.gbZeitDatum.SuspendLayout();
      this.gbLocation.SuspendLayout();
      this.SuspendLayout();
      // 
      // spContainer
      // 
      this.spContainer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.spContainer.Location = new System.Drawing.Point(-2, 1);
      this.spContainer.Margin = new System.Windows.Forms.Padding(2);
      this.spContainer.Name = "spContainer";
      this.spContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
      // 
      // spContainer.Panel1
      // 
      this.spContainer.Panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
      this.spContainer.Panel1.Controls.Add(this.btnToggleView);
      this.spContainer.Panel1.Controls.Add(this.btnSearch);
      this.spContainer.Panel1.Controls.Add(this.cbSettings);
      this.spContainer.Panel1.Controls.Add(this.gbZeitDatum);
      this.spContainer.Panel1.Controls.Add(this.gbLocation);
      // 
      // spContainer.Panel2
      // 
      this.spContainer.Panel2.Controls.Add(this.lb);
      this.spContainer.Size = new System.Drawing.Size(775, 432);
      this.spContainer.SplitterDistance = 93;
      this.spContainer.SplitterWidth = 3;
      this.spContainer.TabIndex = 0;
      // 
      // btnToggleView
      // 
      this.btnToggleView.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.btnToggleView.Location = new System.Drawing.Point(608, 11);
      this.btnToggleView.Name = "btnToggleView";
      this.btnToggleView.Size = new System.Drawing.Size(156, 23);
      this.btnToggleView.TabIndex = 7;
      this.btnToggleView.Text = "Abfahrtstafel";
      this.btnToggleView.UseVisualStyleBackColor = true;
      this.btnToggleView.Click += new System.EventHandler(this.btnToggleView_Click);
      // 
      // btnSearch
      // 
      this.btnSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.btnSearch.Enabled = false;
      this.btnSearch.Location = new System.Drawing.Point(650, 52);
      this.btnSearch.Margin = new System.Windows.Forms.Padding(2);
      this.btnSearch.Name = "btnSearch";
      this.btnSearch.Size = new System.Drawing.Size(117, 34);
      this.btnSearch.TabIndex = 6;
      this.btnSearch.Text = "Search";
      this.btnSearch.UseVisualStyleBackColor = true;
      this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
      // 
      // cbSettings
      // 
      this.cbSettings.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.cbSettings.FormattingEnabled = true;
      this.cbSettings.Location = new System.Drawing.Point(397, 32);
      this.cbSettings.Margin = new System.Windows.Forms.Padding(2);
      this.cbSettings.Name = "cbSettings";
      this.cbSettings.Size = new System.Drawing.Size(102, 21);
      this.cbSettings.TabIndex = 5;
      this.cbSettings.Text = "Settings";
      // 
      // gbZeitDatum
      // 
      this.gbZeitDatum.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
      this.gbZeitDatum.Controls.Add(this.datePicker);
      this.gbZeitDatum.Controls.Add(this.timePicker);
      this.gbZeitDatum.Controls.Add(this.btnAbfahrtAnkunftToggle);
      this.gbZeitDatum.Location = new System.Drawing.Point(180, 10);
      this.gbZeitDatum.Margin = new System.Windows.Forms.Padding(2);
      this.gbZeitDatum.Name = "gbZeitDatum";
      this.gbZeitDatum.Padding = new System.Windows.Forms.Padding(2);
      this.gbZeitDatum.Size = new System.Drawing.Size(184, 71);
      this.gbZeitDatum.TabIndex = 4;
      this.gbZeitDatum.TabStop = false;
      this.gbZeitDatum.Text = "Zeit/Datum";
      // 
      // datePicker
      // 
      this.datePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
      this.datePicker.Location = new System.Drawing.Point(76, 49);
      this.datePicker.Margin = new System.Windows.Forms.Padding(2);
      this.datePicker.Name = "datePicker";
      this.datePicker.Size = new System.Drawing.Size(89, 20);
      this.datePicker.TabIndex = 2;
      // 
      // timePicker
      // 
      this.timePicker.CustomFormat = "HH:mm";
      this.timePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
      this.timePicker.Location = new System.Drawing.Point(25, 49);
      this.timePicker.Margin = new System.Windows.Forms.Padding(2);
      this.timePicker.Name = "timePicker";
      this.timePicker.ShowUpDown = true;
      this.timePicker.Size = new System.Drawing.Size(48, 20);
      this.timePicker.TabIndex = 1;
      this.timePicker.Value = new System.DateTime(2020, 11, 26, 11, 22, 0, 0);
      // 
      // btnAbfahrtAnkunftToggle
      // 
      this.btnAbfahrtAnkunftToggle.Location = new System.Drawing.Point(25, 20);
      this.btnAbfahrtAnkunftToggle.Margin = new System.Windows.Forms.Padding(2);
      this.btnAbfahrtAnkunftToggle.Name = "btnAbfahrtAnkunftToggle";
      this.btnAbfahrtAnkunftToggle.Size = new System.Drawing.Size(140, 24);
      this.btnAbfahrtAnkunftToggle.TabIndex = 0;
      this.btnAbfahrtAnkunftToggle.Text = "Abfahrt";
      this.btnAbfahrtAnkunftToggle.UseVisualStyleBackColor = true;
      this.btnAbfahrtAnkunftToggle.Click += new System.EventHandler(this.btnAbfahrtAnkunftToggle_Click);
      // 
      // gbLocation
      // 
      this.gbLocation.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
      this.gbLocation.Controls.Add(this.tbxZielLocation);
      this.gbLocation.Controls.Add(this.tbxStartLocation);
      this.gbLocation.Controls.Add(this.lbZiel);
      this.gbLocation.Controls.Add(this.lbStart);
      this.gbLocation.Location = new System.Drawing.Point(11, 10);
      this.gbLocation.Margin = new System.Windows.Forms.Padding(2);
      this.gbLocation.Name = "gbLocation";
      this.gbLocation.Padding = new System.Windows.Forms.Padding(2);
      this.gbLocation.Size = new System.Drawing.Size(162, 71);
      this.gbLocation.TabIndex = 0;
      this.gbLocation.TabStop = false;
      this.gbLocation.Text = "Ort";
      // 
      // tbxZielLocation
      // 
      this.tbxZielLocation.Location = new System.Drawing.Point(46, 41);
      this.tbxZielLocation.Margin = new System.Windows.Forms.Padding(2);
      this.tbxZielLocation.Name = "tbxZielLocation";
      this.tbxZielLocation.Size = new System.Drawing.Size(76, 20);
      this.tbxZielLocation.TabIndex = 3;
      this.tbxZielLocation.Tag = "";
      this.tbxZielLocation.TextChanged += new System.EventHandler(this.tbxStartLocation_TextChanged);
      // 
      // tbxStartLocation
      // 
      this.tbxStartLocation.Location = new System.Drawing.Point(46, 20);
      this.tbxStartLocation.Margin = new System.Windows.Forms.Padding(2);
      this.tbxStartLocation.Name = "tbxStartLocation";
      this.tbxStartLocation.Size = new System.Drawing.Size(76, 20);
      this.tbxStartLocation.TabIndex = 2;
      this.tbxStartLocation.Tag = "";
      this.tbxStartLocation.TextChanged += new System.EventHandler(this.tbxStartLocation_TextChanged);
      // 
      // lbZiel
      // 
      this.lbZiel.AutoSize = true;
      this.lbZiel.Location = new System.Drawing.Point(4, 43);
      this.lbZiel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
      this.lbZiel.Name = "lbZiel";
      this.lbZiel.Size = new System.Drawing.Size(24, 13);
      this.lbZiel.TabIndex = 1;
      this.lbZiel.Text = "Ziel";
      // 
      // lbStart
      // 
      this.lbStart.AutoSize = true;
      this.lbStart.Location = new System.Drawing.Point(4, 22);
      this.lbStart.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
      this.lbStart.Name = "lbStart";
      this.lbStart.Size = new System.Drawing.Size(29, 13);
      this.lbStart.TabIndex = 0;
      this.lbStart.Text = "Start";
      // 
      // lb
      // 
      this.lb.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.lb.FormattingEnabled = true;
      this.lb.Location = new System.Drawing.Point(4, 4);
      this.lb.MultiColumn = true;
      this.lb.Name = "lb";
      this.lb.Size = new System.Drawing.Size(771, 329);
      this.lb.TabIndex = 0;
      // 
      // VerbindungenSuchenForm
      // 
      this.AcceptButton = this.btnSearch;
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(774, 430);
      this.Controls.Add(this.spContainer);
      this.Margin = new System.Windows.Forms.Padding(2);
      this.MinimumSize = new System.Drawing.Size(79, 89);
      this.Name = "VerbindungenSuchenForm";
      this.Text = "ÖV finder - Verbindungen suchen";
      this.spContainer.Panel1.ResumeLayout(false);
      this.spContainer.Panel2.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.spContainer)).EndInit();
      this.spContainer.ResumeLayout(false);
      this.gbZeitDatum.ResumeLayout(false);
      this.gbLocation.ResumeLayout(false);
      this.gbLocation.PerformLayout();
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.SplitContainer spContainer;
    private System.Windows.Forms.GroupBox gbLocation;
    private System.Windows.Forms.TextBox tbxStartLocation;
    private System.Windows.Forms.Label lbZiel;
    private System.Windows.Forms.Label lbStart;
    private System.Windows.Forms.GroupBox gbZeitDatum;
    private System.Windows.Forms.DateTimePicker timePicker;
    private System.Windows.Forms.Button btnAbfahrtAnkunftToggle;
    private System.Windows.Forms.TextBox tbxZielLocation;
    private System.Windows.Forms.DateTimePicker datePicker;
    private System.Windows.Forms.Button btnSearch;
    private System.Windows.Forms.ComboBox cbSettings;
    private System.Windows.Forms.Button btnToggleView;
    private System.Windows.Forms.ListBox lb;
  }
}

