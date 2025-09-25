using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PrimerParcial.Models
{
    public class Recipe
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }

        public int PreparationTimeMinutes { get; set; }
        public int Servings { get; set; }
        public string Instructions { get; set; }
        public DateTime DateCreated { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }

        public List<Ingredient> Ingredients { get; set; }
    }
}
