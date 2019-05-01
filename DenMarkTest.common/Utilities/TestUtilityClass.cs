using System;
using System.Collections.Generic;
using System.Text;

namespace DenMarkTest.common.Utilities
{
    /// <summary>
    /// Generic utility class to be use for all utility operation within the solution
    /// </summary>
    public class TestUtilityClass
    {
        /// <summary>
        /// Calculate rating based on grade level scores
        /// </summary>
        /// <returns></returns>
        public string getRating(string value)
        {
            var val = Convert.ToDouble(value);
            var res = string.Empty;
            try
            {
                if (val<=1000)
                {
                    res = "Below Average";
                }

                else if (val<=2000 && val>1000)
                {
                    res = "Average";
                }

                else if (val<=3500 && val>2000)
                {
                    res = "Good";
                }

                else if (val>3500)
                {
                    res = "Very Good";
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }

            return res;
        }
    }
}
