using System;
using System.Text.RegularExpressions;

namespace GlobalX.Coding.Assessment.Sorting.Models
{
    /// <summary>
    /// Class Name
    /// Constructed with a string representing a full name with up to 3 given names followed by a family name
    /// </summary>
    public class OrderedName : IComparable<OrderedName>
    {
        private string[] parts;
        public OrderedName(string fullName)
        {
            // Replace multiple spaces with a single space so that the proceding split() operation works correctly on space delimited names
            var regex = new Regex("[ ]{2,}", RegexOptions.Compiled);
            fullName = regex.Replace(fullName, " ");

            FullName = fullName;
            parts = FullName.Split();
            if (parts.Length > 4 || parts.Length < 2)
            {
                throw new ArgumentException("Full name must consist of at least one and at most three given names followed by a family name.");
            }
        }

        /// <summary>
        /// The original full name specified on construction
        /// </summary>
        public string FullName { get; set; }

        /// <summary>
        /// The last name specified in the full name given on construction
        /// </summary>
        public string FamilyName
        {
            get
            {
                return parts[parts.Length - 1];
            }
        }

        /// <summary>
        /// The first name specified in the full name given on construction
        /// </summary>
        public string GivenName
        {
            get
            {
                return parts[0];
            }
        }

        /// <summary>
        /// The second given name specified in the full name given on construction, if one does not exist then return an empty string
        /// </summary>
        public string SecondName
        {
            get
            {
                if (parts.Length > 2)
                {
                    return parts[1];
                }
                else
                {
                    return string.Empty;
                }
            }
        }

        /// <summary>
        /// The third given name specified in the full name given on construction, if one does not exist then return an empty string
        /// </summary>
        public string ThirdName
        {
            get
            {
                if (parts.Length > 3)
                {
                    return parts[2];
                }
                else
                {
                    return string.Empty;
                }
            }
        }

        /// <summary>
        /// Retrun the ordering of two operands each of this type.
        /// If the first operand alphabetically precedes the second operand then return -1
        /// If the two operands are alphabetically equal then return 0
        /// If the second operand alphabetically precedes the first operand then return 1
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public int CompareTo(OrderedName other)
        {
            return string.Compare(ToOrderedSpelling(), other.ToOrderedSpelling(), StringComparison.InvariantCultureIgnoreCase);
        }

        /// <summary>
        /// The alphabetical ordering definition for this class.
        /// Order by family name then each of the given names in order.
        /// </summary>
        /// <returns></returns>
        public string ToOrderedSpelling()
        {
            return $"{FamilyName}{GivenName}{SecondName}{ThirdName}";
        }

        public override string ToString()
        {
            return FullName;
        }
    }
}
