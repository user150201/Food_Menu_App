namespace Menu.Models
{
    public class DishIngrediant
    {
        public int DishId { get; set; }

        public  Dish Dish { get;set; }

        public int IngrediantId     { get; set; }

        public  Ingrediant? Ingrediant { get; set; }
    }
}
