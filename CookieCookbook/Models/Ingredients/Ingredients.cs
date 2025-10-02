namespace CookieCookbook.Models
{
    public abstract class Ingredient
    {
        public int Id { get; set; }
        public string Name { get; set; }

         public string GetPreparationInstruction()
        {
            
            return $"{GetPreparationAction()} {GetMixingMethod()}";
        }

        public abstract string GetPreparationAction();

        public virtual string GetMixingMethod()
        {
            return "Add to other ingredients.";
        }

        public override string ToString()
        {
            return $"{Name}. {GetPreparationInstruction()}";
        }
    }

    public class Chocolate : Ingredient
    {
        public Chocolate(int id = 4, string name = "Chocolate") {
            Id = id;
            Name = name;
         }

        public override string GetPreparationAction()
        {
            return "Melt in a water bath.";
        }
    }
}