namespace CookieCookbook.Models
{
    public abstract class Ingredient
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public abstract string GetPreparationInstruction();

        public override string ToString()
        {
            return $"{Name}. {GetPreparationInstruction()}";
        }
    }

    public class Chocolate : Ingredient
    {
        public Chocolate(int id, string name = "Chocolate") {
            Id = id;
            Name = name;
         }

        public override string GetPreparationInstruction()
        {
            return "Melt in a water bath. Add to other ingredients.";
        }
    }
}