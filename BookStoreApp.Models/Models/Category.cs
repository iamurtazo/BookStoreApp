using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BookStoreApp.Models;

public class Category
{
    [Key]
    [Required]
    public int Id { get; set; }
    [Required]
    [MaxLength(50)]
    [DisplayName("Category Name")]
    public string Name { get; set; }
    [Required]
    [DisplayName("Display Order")]
    [Range(1, int.MaxValue, ErrorMessage = "Number must be greater than 0")]
    public int DisplayOrder { get; set; }
}
