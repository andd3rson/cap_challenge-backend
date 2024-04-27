using Microsoft.EntityFrameworkCore;

namespace EmployeeManagement.Application.Common;

public class PagedList<T>
{
    public IEnumerable<T> Items { get; }
    public int Page { get; set; }
    public int PageSize { get; }
    public int TotalPage { get; set; }

    public PagedList(IEnumerable<T> items, int pageSize, int page, int totalPage)
    {
        Items = items;
        PageSize = pageSize;
        Page = page;
        TotalPage = totalPage;
    }

    public static PagedList<T> CreateAsync(List<T> pagedList, int page, int pageSize, int totalPage)
    {
        return new PagedList<T>(pagedList, pageSize, page, totalPage);
    }
}