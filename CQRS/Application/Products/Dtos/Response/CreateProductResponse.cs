namespace Application.Products.Dtos.Response
{
    public class CreateProductResponse
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public DateTime CreatedTime { get; set; }
    }
}
