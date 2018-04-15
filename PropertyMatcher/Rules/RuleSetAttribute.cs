using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropertyMatcherLibrary.Rules
{
    /// <summary>
    /// Rule set attribute to be decorated on rule to define rule name
    /// </summary>
    [AttributeUsage(AttributeTargets.Class)]
    public class RuleSetAttribute:Attribute
    {
        /// <summary>
        /// Name of the rule
        /// </summary>
        public string Name { get; set; }

        public RuleSetAttribute(string name)
        {
            this.Name = name;
        }
    }
}
