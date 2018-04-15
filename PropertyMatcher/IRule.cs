using PropertyMatcherLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropertyMatcherLibrary
{
    /// <summary>
    /// Contract for rule
    /// </summary>
    public interface IRule<T>
    {
        /// <summary>
        /// Test the rule on property
        /// </summary>
        /// <param name="match">object of type <typeparamref name="T"/> to compare</param>
        /// <param name="matchWith">Source object of type <typeparamref name="T"/> to compare with</param>
        /// <returns></returns>
        bool Test(T match, T matchWith);
    }
    
}
