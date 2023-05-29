namespace Presentation.Models
{
    public class CreateRecipeModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public IFormFile? Image { get; set; }
        public List<Directions> Directions { get; set; }
    }
    public class Directions
    {
        public short StepNumber { get; set; }
        public string Direction { get; set; }
    }
}
