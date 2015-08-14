namespace GodLesZ.Library.Imaging.Filters
{
    using System;
    using System.Drawing;

    public class FilterIterator : IFilter
    {
        private IFilter baseFilter;
        private int iterations;

        public FilterIterator()
        {
            this.iterations = 1;
        }

        public FilterIterator(IFilter baseFilter)
        {
            this.iterations = 1;
            this.baseFilter = baseFilter;
        }

        public FilterIterator(IFilter baseFilter, int iterations)
        {
            this.iterations = 1;
            this.baseFilter = baseFilter;
            this.iterations = iterations;
        }

        public Bitmap Apply(Bitmap srcImg)
        {
            if (this.baseFilter == null)
            {
                throw new NullReferenceException("Base filter is not set");
            }
            Bitmap bitmap = this.baseFilter.Apply(srcImg);
            for (int i = 1; i < this.iterations; i++)
            {
                Bitmap img = bitmap;
                bitmap = this.baseFilter.Apply(img);
                img.Dispose();
            }
            return bitmap;
        }

        public IFilter BaseFilter
        {
            get
            {
                return this.baseFilter;
            }
            set
            {
                this.baseFilter = value;
            }
        }

        public int Iterations
        {
            get
            {
                return this.iterations;
            }
            set
            {
                this.iterations = Math.Max(1, Math.Min(0xff, value));
            }
        }
    }
}

