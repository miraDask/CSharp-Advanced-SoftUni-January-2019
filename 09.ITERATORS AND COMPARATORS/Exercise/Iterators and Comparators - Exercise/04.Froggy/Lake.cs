namespace _04.Froggy
{
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    public class Lake<T> : IEnumerable<int>
    {
        public Lake(List<int> stones)
        {
            this.Stones = stones;
            StonesSort();
        }

        public List<int> Stones { get; set; }

        public IEnumerator<int> GetEnumerator()
        {
            foreach (var stone in Stones)
            {
                yield return stone;
            }
           // return new LakeEnumerator(this.Stones);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        public void StonesSort()
        {
            var firstPart = new List<int>();
            var secondPart = new List<int>();

            for (int i = 0; i < this.Stones.Count; i++)
            {
                if (i % 2 == 0)
                {
                    firstPart.Add(this.Stones[i]);
                }
                else
                {
                    secondPart.Add(this.Stones[i]);
                }
            }
            secondPart.Reverse();
            this.Stones = new List<int>();
            this.Stones.AddRange(firstPart);
            this.Stones.AddRange(secondPart);
        }
        //public class LakeEnumerator : IEnumerator<int>
        //{

        //    private int index;

        //    public LakeEnumerator(params int[] stones)
        //    {
        //        this.Stones = new List<int>(stones);
        //        this.index = -1;
        //    }

        //    public List<int> Stones { get; set; }

        //    public int Current
        //    {
        //        get
        //        {
        //            var firstPart = this.Stones.Where(s => s % 2 == 1);

        //        }
        //    }

        //    object IEnumerator.Current => this.Current;

        //    public void Dispose()
        //    {
        //    }

        //    public bool MoveNext()
        //    {
        //        throw new System.NotImplementedException();
        //    }

        //    public void Reset()
        //    {
        //        this.index = -1;
        //    }

        //    pu
        //}
    }
}
