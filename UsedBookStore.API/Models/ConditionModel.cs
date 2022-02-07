namespace UsedBookStore.API.Models
{
    public class ConditionModel
    {
        public ConditionModel()
        {

        }
        public ConditionModel(string name)
        {
            Name = name;
        }

        public ConditionModel(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public int Id { get; set; }
        public string Name { get; set; }

    }
}
