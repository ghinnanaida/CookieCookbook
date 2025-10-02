namespace CookieCookbook.Models
{
    public class Spice : Ingredient
    {
        public Spice(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public override string GetPreparationInstruction()
        {
            return "Take half a teaspoon. Add to other ingredients.";
        }
    }

    public class Cinnamon : Spice
    {
        public Cinnamon(int id) : base(id, "Cinnamon") { }
    }
    public class Cardamom : Spice
    {
        public Cardamom(int id) : base(id, "Cardamom") { }
    }
}