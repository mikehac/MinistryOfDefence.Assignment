using AutoMapper;
using MinistryOfDefence.Assignment.DTOs;
using MinistryOfDefence.Assignment.Models;

namespace MinistryOfDefence.Assignment.Mapping
{
    public class EntityiesProfile:Profile
    {
        public EntityiesProfile()
        {
            CreateMap<Category,CategoryDTO>().ReverseMap();
            CreateMap<Item,ItemDTO>().ReverseMap();
        }
    }
}
