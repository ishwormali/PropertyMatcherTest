using PropertyMatcherLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropertyMatcherLibrary
{
    /// <summary>
    /// Contract for Property comparer
    /// </summary>
    public interface IPropertyComparer
    {
        /// <summary>
        /// Checks if the properties are a match
        /// </summary>
        /// <param name="agencyProperty">Agency property</param>
        /// <param name="databaseProperty">Existing db property</param>
        /// <returns></returns>
        bool IsMatch(Property agencyProperty, Property databaseProperty);
    }
}
