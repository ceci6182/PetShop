namespace Compulsory1.Petshop.Domain.Models
{
    public class PetType
    {
        public int? Id {
            get;
            set;
        }
        public string Name { get; set; }

        public override string ToString()
        {
            return $"id = {Id}, Pet type = {Name}";
        }
    }
}