using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;

namespace System
{
    public static class EnumExtensions
    {
        /// <summary>
        /// Gets the Display(Name) attribute value for display.
        /// </summary>
        /// <param name="param"></param>
        /// <returns>The Display(Name) attribute value if it's specified, otherwise the Enum value ToString()</returns>
        public static string GetDisplayName(this Enum param) 
            => param.GetType().GetMember(param.ToString()).First().GetCustomAttribute<DisplayAttribute>()?.Name ?? param.ToString();
    }
}
