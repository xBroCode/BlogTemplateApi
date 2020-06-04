namespace BroCode.BlogTemplate.DTO
{
    public class CreateCategoryDTO
    {
        public string Name { get; set; }
    }

    public class CategoryDTO
    {
        public CategoryDTO(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public CategoryDTO()
        {

        }

        public int Id { get; set; }
        public string Name { get; set; }
    }
}
