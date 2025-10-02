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

    public class Flour : Ingredient
    {

        public Flour(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public override string GetPreparationInstruction()
        {
            return "Sieve. Add to other ingredients.";
        }
    }

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

    public class WheatFlour : Flour
    {
        public WheatFlour(int id) : base(id, "Wheat flour") { }
    }

    public class CoconutFlour : Flour
    {
        public CoconutFlour(int id) : base(id, "Coconut flour") { }
    }

    public class Butter : Fat
    {
        public Butter(int id) : base(id, "Butter") { }
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

    public class Sugar : Sweetener
    {
        public Sugar(int id) : base(id, "Sugar") { }
    }

    public class Cinnamon : Spice
    {
        public Cinnamon(int id) : base(id, "Cinnamon") { }
    }
    public class Cardamom : Spice
    {
        public Cardamom(int id) : base(id, "Cardamom") { }
    }
    
    public class CocoaPowder : Sweetener
    {
        public CocoaPowder(int id) : base(id, "Cocoa powder") { }
    }
}