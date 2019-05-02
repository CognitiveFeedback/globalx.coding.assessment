using System;
using System.Text.RegularExpressions;

namespace GlobalX.Coding.Assessment.Sorting
{
    public class Name : IComparable<Name>, IComparable
    {
        private string[] parts;
        public Name(string fullName)
        {
            Regex regex = new Regex("[ ]{2,}", RegexOptions.Compiled);
            fullName = regex.Replace(fullName, " ");

            FullName = fullName;
            parts = FullName.Split();
            if (parts.Length > 4 || parts.Length < 2)
            {
                throw new ArgumentException("Full name must consist of at least one and at most three given names followed by a family name.");
            }
        }

        public string FullName { get; set; }

        public string FamilyName
        {
            get
            {
                return parts[parts.Length - 1];
            }
        }
        public string GivenName
        {
            get
            {
                return parts[0];
            }
        }
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

        public int CompareTo(Name other)
        {
            return string.Compare(ToOrderedSpelling(), other.ToOrderedSpelling());
        }

        public int CompareTo(object obj)
        {
            return CompareTo(obj as Name);
        }

        public string ToOrderedSpelling()
        {
            return $"{FamilyName}{GivenName}{SecondName}{ThirdName}".ToLower();
        }

        public override string ToString()
        {
            switch (parts.Length)
            {
                case 4:
                    return $"{GivenName} {SecondName} {ThirdName} {FamilyName}";
                case 3:
                    return $"{GivenName} {SecondName} {FamilyName}";
                default:
                    return $"{GivenName} {FamilyName}";
            }
        }
    }
}
