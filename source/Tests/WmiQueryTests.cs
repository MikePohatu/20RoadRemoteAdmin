﻿#region license
// Copyright (c) 2021 20Road Limited
//
// This file is part of DevChecker.
//
// DevChecker is free software: you can redistribute it and/or modify
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
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsHelpers;

namespace Tests
{
    [TestFixture]
    public class WmiQueryTests
    {
        [Test]
        [TestCase( "SELECT * FROM Win32_ComputerSystem")]
        public async Task WmiConnectTest(string Query)
        {
            string test = await LocalSystemConnector.GetWmiStringAsync(Query);
            Assert.IsTrue(string.IsNullOrEmpty(test) == false);
        }
    }
}
