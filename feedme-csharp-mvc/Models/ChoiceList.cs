using Microsoft.Extensions.Options;
using System.Text.Json.Serialization;

namespace feedme_csharp_mvc.Models
{
    public class ChoiceList
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public int ChoiceListLayoutId { get; set; }
        
        [JsonIgnore]
        public ChoiceListLayout? ChoiceListLayout { get; set; }

        [JsonIgnore]
        public List<ListOption>? Options { get; set; }

        public ChoiceList()
        {
        }

        public ChoiceList(string? name, string? description) : this()
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
