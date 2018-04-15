using PropertyMatcherLibrary.Impl;
using PropertyMatcherLibrary.Models;
using PropertyMatcherLibrary.Rules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace PropertyMatcherLibrary.Helpers
{
    /// <summary>
    /// Helper functions for reflections
    /// </summary>
    public static class ReflectionHelpers
    {
        /// <summary>
        /// Finds rule implementing <see cref="IRule{T}"/> for the given names
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="names"></param>
        /// <returns></returns>
        public static IEnumerable<IRule<T>> FindRulesByNames<T>(params string[] names)
        {
            //Get all rule types IRule<T>
            var allTypes = GetClassOfType<IRule<T>>();
            IList<IRule<T>> allTypeObjectsWithNames = new List<IRule<T>>();
            foreach (var name in names)
            {
                //if rule objects have been cached, return the cache.
                if(ruleByNamesCache.ContainsKey(name))
                {
                    allTypeObjectsWithNames.Add((IRule<T>)ruleByNamesCache[name]);

                }
                else
                {
                    //Find rule with name equals to the rule name
                    var typ = allTypes.FirstOrDefault(m => m.GetCustomAttributes<RuleSetAttribute>().Any(a => a.Name == name));
                    if(typ==null)
                    {
                        //Rule does not exist in the loaded modules.
                        throw new ArgumentException($"Ruleset {name} not defined.");
                    }
                    //Instantiate the rule and cache it for future.
                    var typeObject = ServiceProvider.GetService(typ);
                    ruleByNamesCache.Add(name, typeObject);
                    allTypeObjectsWithNames.Add((IRule<T>)typeObject);


                }
            }

            return allTypeObjectsWithNames;
        }
        
        /// <summary>
        /// Get class of given  type
        /// </summary>
        /// <typeparam name="TI"></typeparam>
        /// <returns></returns>
        public static IEnumerable<Type> GetClassOfType<TI>()
        {
            IEnumerable<Type> allTypes = new List<Type>(); 
            //Check if the types have already been discovered and cached in static variable
            if(typesImplementingCache.ContainsKey(typeof(TI)))
            {
                //Returning from cache
                allTypes= typesImplementingCache.Where(m => m.Key == typeof(TI)).SelectMany(m => m.Value);
            }
            else
            {
                //Find all class types within loaded assemblies that has been derived from type TI.
                allTypes = AppDomain.CurrentDomain.GetAssemblies().SelectMany(a=>a.GetTypes().Where(m => m.IsClass && typeof(TI).IsAssignableFrom(m))).ToList();
                typesImplementingCache.Add(typeof(TI), allTypes);
            }

            return allTypes;
        }

        private static IDictionary<Type, IEnumerable<Type>> typesImplementingCache=new Dictionary<Type,IEnumerable<Type>>();

        private static IDictionary<string, object> ruleByNamesCache = new Dictionary<string, object>();

        public static IServiceProvider ServiceProvider = new ServiceProvider();
    }
}
