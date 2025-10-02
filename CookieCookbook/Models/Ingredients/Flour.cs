namespace CookieCookbook.Models
{
    public class Flour : Ingredient
    {

        public Flour(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public override string GetPreparationAction()
        {
            return "Sieve.";
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
}
