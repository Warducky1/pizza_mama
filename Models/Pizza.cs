using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Pizza_mama.Models
{
    public class Pizza
    {
        [JsonIgnore]
        public int PizzaID { get; set; }

        [Display(Name = "Nom")]
        public string name { get; set; }

        [Display(Name = "Prix (€)")]
        public float price { get; set; }
        [Display(Name = "Végétarienne")]
        public bool vegetarian { get; set; }

        [JsonIgnore]
        [Display(Name = "Ingrédient")]        
        public string? ingredients { get; set; }

        [NotMapped]
        [JsonPropertyName("ingredients")]
        public string[] listeIngredients 
        { 
            get
            {
                if(ingredients == null || ingredients.Count() == 0)
                {
                    return null;
                }

                return ingredients.Split(", ");
            }
        }

    }
}
