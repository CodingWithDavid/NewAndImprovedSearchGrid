
using InternalLib;
using System;
using System.Collections.Generic;
using System.Linq;

namespace UILab.UIControls.DataGrid
{
    public class DataGridService<T>
    {
        public int PageSize { get; set; }
        public int PageCount { get; set; }
        public int CurrentPage { get; set; }

        public string GetSortStyle(int index, int sortIndex, bool sortDirection)
        {
            string result = string.Empty;
            if (index == sortIndex)
            {
                if (sortDirection)
                {
                    result = "fa-sort-up";
                }
                else
                {
                    result = "fa-sort-down";
                }
            }
            return result;
        }

        public int GetPageCount(int pageSize, int recordCount)
        {
            int result = 0;
            if(pageSize > 0)
            {
                result = recordCount / pageSize;
                int remainer = recordCount % pageSize;
                if(remainer > 0)
                {
                    result++;
                }
            }
            return result;
        }

        public List<T> GetPage(IQueryable<T> data, int page )
        {
            if (page > 0 && page <= PageCount)
            {
                return (from a in data
                         select a).Skip(page - 1).Take(PageSize).ToList();

            }
            return data.ToList();
        }

        public List<T> Sort(IQueryable<T> data, string sortProperty, string sortDir)
        {
            if (data != null && sortProperty.IsNotEmpty())
            {
                if(sortDir.IsEmpty())
                {
                    sortDir = "OrderBy";
                }
                return RecordSorterHelper.ApplyOrder<T>(data.AsQueryable(), sortProperty, sortDir).ToList();
            }
            return data.ToList();
        }
    }
}
