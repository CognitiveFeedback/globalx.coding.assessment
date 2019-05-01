using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobalX.Coding.Assessment.Sorting
{
    public class Name : IComparable<Name>
    {
        private string fullName = string.Empty;
        private string[] parts;
        public Name(string fullName)
        {
            this.fullName = fullName;
            this.parts = fullName.Split();
            if (parts.Length > 4 || parts.Length < 2)
            {
                throw new ArgumentException("Name must consist of at least one and at most three given names, plus a family name.");
            }
        }
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
            return string.Compare(this.ToOrderedSpelling(), other.ToOrderedSpelling());
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
