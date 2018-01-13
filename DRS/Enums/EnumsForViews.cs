using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace DRS.Enums
{
    public class EnumsForViews
    {
        public enum VesselApplicationType
        {
            [Description("New")]    //License Type for IMUL
            New = 1,
            [Description("Renewal")]    //License Type IMUL
            Renewal = 2,
            [Description("No Status")]  //License Type IMUL/OFRP/MTRB/NTRB/NBSB
            No_Status = 3
        }

        public enum DistressVesselApplicationType
        {
            [Description("No Status")]  //License Type IMUL/OFRP/MTRB/NTRB/NBSB
            No_Status = 3
        }

        public enum OwnerSearchType
        {
            [Description("Owner Name")]
            Name = 1,
            [Description("Owner NIC")]
            NIC = 2,
            [Description("Owner Tel")]
            Tel = 3
        }

        public enum LattitudeDirections
        {
            [Description("North")]
            North = 1,
            [Description("South")]
            South = 4
        }

        public enum LongDirections
        {
            [Description("East")]
            East = 2,
            [Description("West")]
            West = 3
        }

    }
}