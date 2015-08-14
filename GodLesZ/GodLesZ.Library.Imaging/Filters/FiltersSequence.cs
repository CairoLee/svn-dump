namespace GodLesZ.Library.Imaging.Filters
{
    using System;
    using System.Collections;
    using System.Drawing;

	public class FiltersSequence : CollectionBase, IFilter
    {
        public FiltersSequence()
        {
        }

        public FiltersSequence(params IFilter[] filters)
        {
            base.InnerList.AddRange(filters);
        }

        public void Add(IFilter filter)
        {
            base.InnerList.Add(filter);
        }

        public Bitmap Apply(Bitmap srcImg)
        {
            Bitmap bitmap = null;
            Bitmap img = null;
            int count = base.InnerList.Count;
            if (count == 0)
            {
                throw new ApplicationException();
            }
            bitmap = ((IFilter) base.InnerList[0]).Apply(srcImg);
            for (int i = 1; i < count; i++)
            {
                img = bitmap;
                bitmap = ((IFilter) base.InnerList[i]).Apply(img);
                img.Dispose();
            }
            return bitmap;
        }

        public IFilter this[int index]
        {
            get
            {
                return (IFilter) base.InnerList[index];
            }
        }
    }
}

