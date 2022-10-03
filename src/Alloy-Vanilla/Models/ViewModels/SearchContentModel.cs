using Alloy_Vanilla.Models.Pages;

namespace Alloy_Vanilla.Models.ViewModels;

public class SearchContentModel : PageViewModel<SearchPage>
{
    public SearchContentModel(SearchPage currentPage)
        : base(currentPage)
    {
    }

    public bool SearchServiceDisabled { get; set; }

    public string SearchedQuery { get; set; }

    public int NumberOfHits { get; set; }

    public IEnumerable<SearchHit> Hits { get; set; }

    public class SearchHit
    {
        public string Title { get; set; }

        public string Url { get; set; }

        public string Excerpt { get; set; }
    }
}
