﻿#region license
// Copyright (c) 2021 20Road Limited
//
// This file is part of 20Road Remote Admin.
//
// 20Road Remote Admin is free software: you can redistribute it and/or modify
// it under the terms of the GNU General Public License as published by
// the Free Software Foundation, version 3 of the License.
//
// This program is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.
//
// You should have received a copy of the GNU General Public License
// along with this program.  If not, see <http://www.gnu.org/licenses/>.
//
#endregion
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsHelpers;

namespace _20RoadRemoteAdmin.Config
{
    public class Configuration
    {
        public string ConfigMgrServer { get; set; }
        public string LastDevice { get; set; }

        public bool ClientSSL { get; set; }
        public bool ServerSSL { get; set; }

        public bool UseSSL { get; set; } = false;

        public static Configuration Instance { get; private set; } = new Configuration();
        private Configuration() { }

        public static async Task LoadAsync(string filePath)
        {
            string json = await IOHelpers.ReadFileAsync(filePath);
            Instance = JsonConvert.DeserializeObject<Configuration>(json);
        }

        public async Task WriteAsync(string filePath)
        {
            string json = JsonConvert.SerializeObject(this);
            await IOHelpers.WriteTextFileAsync(filePath, json);
        }
    }
}
