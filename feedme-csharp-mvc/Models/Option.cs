namespace feedme_csharp_mvc.Models
{
    public class Option
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public Option()
        {
        }

        public Option(string name)
        {
            Name = name;
        }

        public override bool Equals(object? obj)
        {
            return obj is Option option &&
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
