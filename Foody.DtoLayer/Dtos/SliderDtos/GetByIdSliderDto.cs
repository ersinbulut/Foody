﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foody.DtoLayer.Dtos.SliderDtos
{
    public class GetByIdSliderDto
    {
        public int SliderID { get; set; }
        public string Title { get; set; }
        public string ImageUrl { get; set; }
    }
}
