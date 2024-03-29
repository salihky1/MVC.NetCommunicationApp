using System.ComponentModel.DataAnnotations;
namespace ContactApp.Models
{
	public class Category
	{

		public int CategoryId { get; set; }

		[Required]
		public string Name { get; set; } = null!;
	}
}

