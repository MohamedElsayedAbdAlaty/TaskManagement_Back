﻿using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            var configuration = new MapperConfiguration(cfg => cfg.AddProfiles(new List<Profile>() {
                new TaskProfile(), 
            }));

        }
    }
   
}
