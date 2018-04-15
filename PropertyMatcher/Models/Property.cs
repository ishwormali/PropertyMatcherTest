using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropertyMatcherLibrary.Models
{
    /// <summary>
    /// Property entity
    /// </summary>
    public class Property
    {
        /// <summary>
        /// Address of the property
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// Agency code this property belongs
        /// </summary>
        public string AgencyCode { get; set; }

        /// <summary>
        /// Name of the property
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Latitude component of the address of the property
        /// </summary>
        public decimal Latitude { get; set; }

        /// <summary>
        /// Longitude component of the address of the property
        /// </summary>
        public decimal Longitude { get; set; }



    }
}
