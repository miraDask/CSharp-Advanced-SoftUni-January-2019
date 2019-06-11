namespace GenericScale
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class EqualityScale<T>
    {
        public EqualityScale(T left, T right)
        {
            this.LeftElement = left;
            this.RightElement = right;
        }

        public T LeftElement { get; set; }
        public T RightElement { get; set; }

        public bool AreEqual()
        {
            return this.LeftElement.Equals(this.RightElement);
        }
    }
}
