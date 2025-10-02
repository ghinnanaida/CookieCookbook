namespace CookieCookbook.Models
{
    public class Fat : Ingredient
    {
        public Fat(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public override string GetPreparationInstruction()
        {
            return "Melt. Add to other ingredients.";
        }
    }
    
    public class Butter : Fat
    {
        public Butter(int id) : base(id, "Butter") { }
    }
}