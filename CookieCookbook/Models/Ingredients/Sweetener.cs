namespace CookieCookbook.Models
{
    public class Sweetener : Ingredient
    {
        public Sweetener(int id, string name)
        {
            Id = id;
            Name = name;
        }
        public override string GetPreparationAction()
        {
            return "Measure the required amount.";
        }
    }

    public class Sugar : Sweetener
    {
        public Sugar() : base(5, "Sugar") { }
    }
    
    public class CocoaPowder : Sweetener
    {
        public CocoaPowder() : base(8, "Cocoa powder") { }
    }
}