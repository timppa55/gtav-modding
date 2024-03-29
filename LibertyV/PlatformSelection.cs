﻿/*
 
    LibertyV - Viewer/Editor for RAGE Package File version 7
    Copyright (C) 2013  koolk <koolkdev at gmail.com>
   
    This program is free software: you can redistribute it and/or modify
    it under the terms of the GNU General Public License as published by
    the Free Software Foundation, either version 3 of the License, or
    (at your option) any later version.
  
    This program is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    GNU General Public License for more details.
   
    You should have received a copy of the GNU General Public License
    along with this program.  If not, see <http://www.gnu.org/licenses/>.
 
 */

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using LibertyV.Utils;
using System.IO;

namespace LibertyV
{
    public partial class PlatformSelection : Form
    {
        public PlatformSelection()
        {
            InitializeComponent();
            UpdatePlatformButtons();
        }

        private void UpdatePlatformButtons()
        {
            xboxSelect.Enabled = Properties.Settings.Default.Xbox360KeyFileEnabled;
            playstationSelect.Enabled = Properties.Settings.Default.PS3KeyFileEnabled;
        }

        private void xboxSelect_Click(object sender, EventArgs e)
        {
            GlobalOptions.Platform = Platform.PlatformType.XBOX360;
            AES.Key = File.ReadAllBytes(Properties.Settings.Default.Xbox360KeyFile);
            Close();
        }

        private void playstationSelect_Click(object sender, EventArgs e)
        {
            GlobalOptions.Platform = Platform.PlatformType.PLAYSTATION3;
            AES.Key = File.ReadAllBytes(Properties.Settings.Default.PS3KeyFile);
            Close();
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void settingsButton_Click(object sender, EventArgs e)
        {
            new Settings.Settings().ShowDialog();
            UpdatePlatformButtons();
        }
    }
}
