namespace MinistryOfDefence.Assignment.DTOs
{
    public class CategoryDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string NameHeb { get; set; }
        public List<ItemDTO> Items { get; set; } = new List<ItemDTO>();
    }
}
