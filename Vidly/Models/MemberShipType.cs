using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class MemberShipType
    {
        public byte Id { get; set; }

        [StringLength(255)]
        public string Name { get; set; }

        public short SignUpFee { get; set; }
        public byte DurationInMonts { get; set; }
        public byte DiscontRare { get; set; }

        public static readonly byte Unknown = 0;
        public static readonly byte PayAsYouGo = 1;

    }
}