using AutoMapper;
using Ecommerencesite.Model;
using Ecommerencesite.MODELDTO;

namespace Ecommerencesite.Auotmapper
{
          public class UserLoginMapper : Profile
          {
                    public UserLoginMapper()
                    {
                              CreateMap<UserMedicine, UserLogindto>().ReverseMap().

                                  AddTransform<string>(s => string.IsNullOrEmpty(s) ? "" : s)

                                // .ForMember(dest => dest.id, opt => opt.MapFrom(src => src.id))
                                 .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))

                             .ForMember(dest => dest.Password, opt => opt.MapFrom(src => src.Password));
                           


                    }


          }
}



