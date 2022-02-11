namespace UsedBookStore.Web.Models.ViewModels
{
    public class ConditionViewModel
    {
        public ConditionModel ConditionForm { get; set; }
        public IEnumerable<BookModel> BooksByCondition { get; set; }
    }
}
