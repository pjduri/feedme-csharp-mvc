using Newtonsoft.Json;

namespace feedme_csharp_mvc.Models
{
    public class ChoiceListLayout
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }

        [JsonIgnore]
        public List<ChoiceList>? ChoiceLists { get; set; }

        public ChoiceListLayout()
        {
        }

        public ChoiceListLayout(string? name, string? description) : this()
        {
            Name = name;
            Description = description;
        }

        public override bool Equals(object? obj)
        {
            return obj is ChoiceListLayout layout &&
                   Id == layout.Id;
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
