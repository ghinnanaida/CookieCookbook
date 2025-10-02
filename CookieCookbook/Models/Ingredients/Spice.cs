namespace CookieCookbook.Models
{
    public class Spice : Ingredient
    {
        public Spice(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public override string GetPreparationAction()
        {
            return "Take half a teaspoon.";
        }
    }

    public class Cinnamon : Spice
    {
        public Cinnamon() : base(6, "Cinnamon") { }
    }
    public class Cardamom : Spice
    {
        public Cardamom() : base(7, "Cardamom") { }
    }
}