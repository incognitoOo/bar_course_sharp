﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAddressbookTests
{
    class GroupData

    {
        private string groupName;
        public string groupHeader = "";
        public string groupFooter = "";
        public GroupData (string groupName) { this.groupName = groupName; }
        public string GroupName     { get { return groupName; }     set { groupName = value; } }
        public string GroupHeader   { get { return groupHeader; }   set { groupHeader = value; } }
        public string GroupFooter   { get { return groupFooter; }   set { groupFooter = value; }
        }
    }
}