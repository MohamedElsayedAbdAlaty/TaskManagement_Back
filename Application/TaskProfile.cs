using AutoMapper;
using Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Application
{
    public class TaskProfile : Profile
    {
        public TaskProfile()
        {

            CreateMap<Core.Task, Core.TaskDto>().ReverseMap();
                
        }
    }
   
}
