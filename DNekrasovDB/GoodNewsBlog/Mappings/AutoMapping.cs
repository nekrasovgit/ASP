using AutoMapper;
using GoodNewsBlog.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoodNewsBlog.Mappings
{
    public class AutoMapping : Profile
    {
        /*public AutoMapping()
        {
            CreateMap<News, NewsDTO>();
            CreateMap<NewsDTO, News>();
        }*/


        //к примеру надо сделать заппрос в бд _context.News.Select(news => _mapper.Map<NewsDTO>(news)).ToList();
        // _context.AddRangeAsync(newsFromUrl.Select(dto => _mapper.Map<News>(dto)));
        // Map<указываем какой тип объекта нужно создать, если тянем из бд - в NewsDTO, если записываем в бд - то в News>
    }
}
