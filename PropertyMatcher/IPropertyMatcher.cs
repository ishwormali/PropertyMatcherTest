using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropertyMatcherLibrary
{
    using Models;

    /// <summary>
    /// Contract for property matcher
    /// </summary>
    public interface IPropertyMatcher
    {
        /// <summary>
        /// Compare and check if the property sent by agency is a match with the property stored in the db.
        /// </summary>
        /// <param name="agencyProperty">Represents agency property</param>
        /// <param name="DatabaseProperty">Represents database property</param>
        /// <returns></returns>
        bool IsMatch(Property agencyProperty, Property DatabaseProperty);
    }
}
