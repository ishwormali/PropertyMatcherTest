using PropertyMatcherLibrary.Rules.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropertyMatcherLibrary
{
    /// <summary>
    /// Library level constants.
    /// </summary>
    public class Constants
    {
        /// <summary>
        /// Location closeness in meterr. 
        /// </summary>
        public const decimal LocationClosenessInMtr = 200;
        /// <summary>
        /// Cordinate degree to km 
        /// </summary>
        public const decimal CoordinateDegreeToKm = 111;
        /// <summary>
        /// Pre defined agent property rules, which can come from db.
        /// </summary>
        public static IDictionary<string, IEnumerable<string>> PredefinedAgentPropertyRules = new Dictionary<string, IEnumerable<string>>()
        {
            {"OTBRE",new List<string>{
                nameof(NoPunctuationNameRule),
                nameof(NoPunctuationAddressRule)
                }
            },
            {"LRE",new List<string>{
                nameof(AgencyCodeRule),
                nameof(LocationRule)
                }
            },
            {"CRE",new List<string>{
                nameof(ReverseNameRule)
                }
            }
        };

    }
}
