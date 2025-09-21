using System;
using System.Collections.Generic;

namespace PingCRM.Helpers
{
    public class PaginatedList<T>
    {
        public IEnumerable<T> Data { get; }
        public int CurrentPage { get; }
        public int PerPage { get; }
        public int Total { get; }
        public int LastPage { get; }
        public string Path { get; }
        public int From { get; }
        public int To { get; }

        public PaginatedList(IEnumerable<T> data, int total, int currentPage, int perPage, string path = null)
        {
            Data = data;
            Total = total;
            CurrentPage = currentPage;
            PerPage = perPage;
            LastPage = (int)Math.Ceiling((double)total / perPage);
            Path = path ?? "";
            From = ((currentPage - 1) * perPage) + 1;
            To = Math.Min(currentPage * perPage, total);
        }
    }
}