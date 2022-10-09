using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Base
{
    public class PagedList<T> : List<T>
    {

        public int CurrentPage { get; private set; }
        public int TotalPages { get; private set; }
        public int PageSize { get; private set; }
        public int TotalCount { get; private set; }
        public bool HasPrevious => CurrentPage > 1;
        public bool HasNext => CurrentPage < TotalPages;

        public PagedList(List<T> items, int pageNumber, int pageSize, int totalCount)
        {
            TotalCount = totalCount;
            PageSize = pageSize;
            CurrentPage = pageNumber;
            TotalPages = (totalCount == 0) || ((int)Math.Ceiling(totalCount / (double)pageSize) < 0) ? 0 : (int)Math.Ceiling(totalCount / (double)pageSize);

            AddRange(items);
        }

        public static PagedList<T> ToPagedList(List<T> source, int pageNumber, int pageSize, int totalCount)
        {
            return new PagedList<T>(source, pageNumber, pageSize, totalCount);
        }

        public dynamic GetPaginationMetaData()
        {
            return new { TotalCount = TotalCount, PageSize = PageSize, CurrentPage = CurrentPage, TotalPages = TotalPages, HasNext = HasNext, HasPrevious = HasPrevious };
        }
    }
}
