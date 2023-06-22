namespace dotnet_api;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        CreateMap<Charater, GetCharaterDto>();
        CreateMap<AddCharaterDto, Charater>();
        CreateMap<UpdateCharaterDto, Charater>();
    }
}