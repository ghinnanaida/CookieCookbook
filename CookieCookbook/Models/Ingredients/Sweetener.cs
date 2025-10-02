namespace CookieCookbook.Models
{
    public class Sweetener : Ingredient
    {
        public Sweetener(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public override string GetPreparationInstruction()
        {
            return "Add to other ingredients.";
        }
    }

    public class Sugar : Sweetener
    {
        public Sugar(int id) : base(id, "Sugar") { }
    }
    
    public class CocoaPowder : Sweetener
    {
        public CocoaPowder(int id) : base(id, "Cocoa powder") { }
    }
}