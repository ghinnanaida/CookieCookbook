namespace CookieCookbook.Models
{
    public class Ingredient
    {
        public int Id { get; }
        public string Name { get; }
        public string PreparationInstruction { get; }

        public Ingredient(int id, string name, string preparationInstruction)
        {
            Id = id;
            Name = name;
            PreparationInstruction = preparationInstruction;
        }

        public override string ToString()
        {
            return $"{Name}. {PreparationInstruction}";
        }
    }
}