using Gravity.Services.DataContracts.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Gravity.Service.Standalone.Internal.Extensions
{
    internal static class ObjectExtensions
    {
        /// <summary>
        /// check for method matching
        /// </summary>
        /// <typeparam name="T">attribute type to match</typeparam>
        /// <param name="type">type to check for matching</param>
        /// <param name="nameToMatch">name to assert</param>
        /// <returns>true if match; false if not</returns>
        public static bool AttributeNameMatch<T>(this Type type, string nameToMatch) where T : Attribute, IHasName
        {
            // setup conditions
            var isAttribute = type.GetCustomAttribute<T>() != null;

            // exit conditions
            if (!isAttribute)
            {
                return false;
            }

            // setup conditions
            const StringComparison STRING_COMPARE = StringComparison.OrdinalIgnoreCase;
            var isName = type.GetCustomAttribute<T>().Name.Equals(nameToMatch, STRING_COMPARE);

            // assert
            return isAttribute && isName;
        }

        public static bool TryAdd<T>(this List<T> list, T obj)
        {
            if (EqualityComparer<T>.Default.Equals(obj, default))
            {
                return false;
            }
            list.Add(obj);
            return true;
        }

        public static bool TryAddRange<T>(this List<T> list, IEnumerable<T> obj)
        {
            if (obj?.Any() != true)
            {
                return false;
            }
            list.AddRange(obj);
            return true;
        }
    }
}
