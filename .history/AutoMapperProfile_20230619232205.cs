namespace dotnet_api;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        CreateMap<Charater, GetCharaterDto>();
    }
}