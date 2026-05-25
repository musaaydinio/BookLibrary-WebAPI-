using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.RequestFeatures
{
    public class PagedList<T>:List<T>
    {
        public MetaDeta metaDeta { get; set; }

        public PagedList(List<T>items,int count,int pageNumaber,int pageSize)
        {
            metaDeta = new MetaDeta()
            {
                TotalCount = count,
                PageSize = pageSize,
                CurrentPage = pageNumaber,
                TotalPage=(int)Math.Ceiling(count/(double)pageSize)
            };
            AddRange(items);
        }

        public static PagedList<T>ToPagedList(IEnumerable<T> source,int pageNumber,int pageSize)
        {
            var count=source.Count();
            var items=source
                .Skip((pageNumber-1)*pageSize)
                .Take(pageSize)
                .ToList();

            return new PagedList<T>(items, count, pageNumber, pageSize);
        }
    }
}
