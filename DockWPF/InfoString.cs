﻿using System;
using System.Collections.Generic;
using System.Text;

namespace DockWPF
{
    class InfoString //couldn't figure out how to do it differently fast enough
    {
        public string Location { get; set; }
        public string BoatType { get; set; }
        public string ID { get; set; }
        public int Weight { get; set; }
        public int MaxSpeed { get; set; }

        public string Unique { get; set; }
    }
}
