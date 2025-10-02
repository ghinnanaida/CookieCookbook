namespace CookieCookbook.Models
{
    public class Fat : Ingredient
    {
        public Fat(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public override string GetPreparationAction()
        {
            return "Melt.";
        }
    }
    
    public class Butter : Fat
    {
        public Butter() : base(3, "Butter") { }
    }
}