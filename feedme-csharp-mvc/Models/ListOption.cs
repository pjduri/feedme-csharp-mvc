

using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace feedme_csharp_mvc.Models
{
    public class ListOption
    {
        public int Id { get; set; }
        public string? Name { get; set; }

        public int? ChoiceListId { get; set; }

        [JsonIgnore]
        public ChoiceList? ChoiceList { get; set; }

        public ListOption()
        {
        }

        public ListOption(string name) : this()
        {
            Name = name;
        }

        public override bool Equals(object? obj)
        {
            return obj is ListOption option &&
                   Id == option.Id;
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
