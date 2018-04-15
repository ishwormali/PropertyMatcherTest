using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropertyMatcherLibrary.Rules
{
    /// <summary>
    /// Static sets of primitive rules on commonly used primitive data types.
    /// </summary>
    public static class PrimitiveRules
    {
        /// <summary>
        /// Checks match between two strings ignoring punctuation marks.
        /// </summary>
        /// <param name="source">Compare string</param>
        /// <param name="compareWith">Compare with</param>
        /// <returns>Boolean value indicating match</returns>
        public static bool NoPunctuationStringComparer(string source, string compareWith)
        {
            string sanitizedSource = source.Replace('-', ' ');
            string sanitizedCompareWith = compareWith.Replace('-', ' ');

            string sourceNoPuncuation = new string(sanitizedSource.Where(m => !char.IsPunctuation(m)).ToArray());
            string compareWithNoPunctuation = new string(sanitizedCompareWith.Where(m => !char.IsPunctuation(m)).ToArray());

            return String.Equals(sourceNoPuncuation, compareWithNoPunctuation, StringComparison.OrdinalIgnoreCase);

        }

        /// <summary>
        /// Checks if the two location in degree are close within 200 meters.
        /// </summary>
        /// <param name="source">Source </param>
        /// <param name="compareWith">Match with </param>
        /// <returns>True = match and False = Do not match</returns>
        public static bool CloseLocationMatch( decimal source,decimal compareWith)
        {
            decimal diff= source - compareWith;
            decimal diffInMeter = (Math.Abs(diff) * Constants.CoordinateDegreeToKm * 1000);
            return diffInMeter <= Constants.LocationClosenessInMtr;
        }

        /// <summary>
        /// Checks if the reverse of compareWith match with the source string.
        /// </summary>
        /// <param name="source">Source string</param>
        /// <param name="compareWith">compare with string</param>
        /// <returns></returns>
        public static bool ReverseWordsMatch(string source, string compareWith)
        {
            string[] sourceWords = source.Split(' ').Where(m => !string.IsNullOrWhiteSpace(m)).ToArray();
            string[] compareWithWords= compareWith.Split(' ').Where(m => !string.IsNullOrWhiteSpace(m)).ToArray();
            if(sourceWords.Length==compareWithWords.Length)
            {
                string[] reverseCompareWithWords = compareWithWords;
                Array.Reverse(reverseCompareWithWords);
                for(int i=0;i<sourceWords.Length;i++)
                {
                    if(!string.Equals(sourceWords[i],reverseCompareWithWords[i]))
                    {
                        return false;
                    }
                }

                return true;

            }

            return false;
        }

        
    }
}
