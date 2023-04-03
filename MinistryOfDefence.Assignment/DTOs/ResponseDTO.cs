namespace MinistryOfDefence.Assignment.DTOs
{
    public class ResponseDTO
    {
        public Dictionary<int, CategoryDTO> Categories { get; set; } = new Dictionary<int, CategoryDTO>();
    }
}
