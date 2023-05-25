using Microsoft.Extensions.Options;

namespace feedme_csharp_mvc.Models
{
    public class ChoiceList
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public List<ListOption>? Options { get; set; }

        public ListOption GetRandomOption()
        {
            // Generate a random index
            var random = new Random();
            var randomIndex = random.Next(0, Options.Count);

            // Retrieve the randomly selected option
            ListOption randomOption = Options[randomIndex];

            return randomOption;
        }

        public ChoiceList()
        {
        }

        public ChoiceList(string name, string description) : this()
        {
            Name = name;
            Description = description;
            Options = new List<ListOption>();
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
