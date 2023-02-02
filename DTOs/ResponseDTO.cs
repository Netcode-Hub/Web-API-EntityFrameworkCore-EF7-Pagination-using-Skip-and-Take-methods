using EFCoreRelationships.Models;

namespace EFCoreRelationships.DTOs
{
    public class ResponseDTO
    {
        public int Page { get; set; }
        public int CurrentPage { get; set; }

        public List<Employee> Employees { get; set; } = new List<Employee>();

        
    }
}
