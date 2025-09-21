using System.Collections.Generic;
using System.Linq;
using PingCRM.Helpers;
using PingCRM.ViewModels.Shared;

namespace PingCRM.Extensions
{
    public static class PaginationExtensions
    {
        public static PaginatedData<T> ToPaginatedData<T>(this PaginatedList<T> paginatedList)
        {
            var links = GeneratePaginationLinks(paginatedList);

            return new PaginatedData<T>
            {
                Data = paginatedList.Data.ToList(),
                Links = links,
                Meta = new PaginationMeta
                {
                    CurrentPage = paginatedList.CurrentPage,
                    From = paginatedList.From,
                    LastPage = paginatedList.LastPage,
                    Path = paginatedList.Path ?? string.Empty,
                    PerPage = paginatedList.PerPage,
                    To = paginatedList.To,
                    Total = paginatedList.Total
                }
            };
        }

        private static List<PaginationLink> GeneratePaginationLinks<T>(PaginatedList<T> paginatedList)
        {
            var links = new List<PaginationLink>();

            // Previous link
            if (paginatedList.CurrentPage > 1)
            {
                links.Add(new PaginationLink
                {
                    Url = $"?page={paginatedList.CurrentPage - 1}",
                    Label = "« Previous",
                    Active = false
                });
            }
            else
            {
                links.Add(new PaginationLink
                {
                    Url = null,
                    Label = "« Previous",
                    Active = false
                });
            }

            // Page number links
            for (int i = 1; i <= paginatedList.LastPage; i++)
            {
                links.Add(new PaginationLink
                {
                    Url = $"?page={i}",
                    Label = i.ToString(),
                    Active = i == paginatedList.CurrentPage
                });
            }

            // Next link
            if (paginatedList.CurrentPage < paginatedList.LastPage)
            {
                links.Add(new PaginationLink
                {
                    Url = $"?page={paginatedList.CurrentPage + 1}",
                    Label = "Next »",
                    Active = false
                });
            }
            else
            {
                links.Add(new PaginationLink
                {
                    Url = null,
                    Label = "Next »",
                    Active = false
                });
            }

            return links;
        }
    }
}