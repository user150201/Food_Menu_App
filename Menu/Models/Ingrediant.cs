namespace Menu.Models
{
    public class Ingrediant
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<DishIngrediant>? DishIngrediants { get; set; }

    }
}
