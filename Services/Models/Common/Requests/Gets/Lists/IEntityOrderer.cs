using System.ComponentModel;

namespace QueryPlusPlus.Services.Models.Common.Requests.Gets.Lists
{
    public interface IEntityOrderer<TEntity>
    {
        public string SortBy { get; set; }

        public ListSortDirection SortDirection { get; set; }
    }
}
