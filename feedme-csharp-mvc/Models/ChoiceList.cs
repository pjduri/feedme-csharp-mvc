namespace feedme_csharp_mvc.Models
{
    public class ChoiceList
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<Option> Options { get; set; }

        public ChoiceList()
        {
        }

        public ChoiceList(string name, string description, List<Option> options)
        {
            Name = name;
            Description = description;
            Options = options;
        }

        public override bool Equals(object? obj)
        {
            return obj is ChoiceList list &&
                   Id == list.Id;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id);
        }

        public override string? ToString()
        {
            return Name;
        }
    }
}
