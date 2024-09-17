using AutoMapper;
using Foody.BusinessLayer.Abstract;
using Foody.DtoLayer.Dtos.SliderDtos;
using Foody.EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace Foody.PresentationLayer.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SlidersController : Controller
    {
        private readonly ISliderService _sliderService;
        private readonly IMapper _mapper;

        public SlidersController(ISliderService sliderService, IMapper mapper)
        {
            _sliderService = sliderService;
            _mapper = mapper;
        }

        public IActionResult SliderList()
        {
            var values=_sliderService.TGetAll();
            return View(_mapper.Map<List<ResultSliderDto>>(values));
        }

        [HttpGet]
        public IActionResult CreateSlider()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateSlider(CreateSliderDto createSliderDto)
        {
            var value = _mapper.Map<Slider>(createSliderDto);
            _sliderService.TInsert(value);
            return RedirectToAction("SliderList");
        }
        public IActionResult DeleteSlider(int id)
        {
            _sliderService.TDelete(id);
            return RedirectToAction("SliderList");
        }
        [HttpGet]
        public IActionResult UpdateSlider(int id)
        {
            // ID ile Slider'ı çekiyoruz
            var slider = _sliderService.TGetById(id);

            // GetByIdSliderDto'yu UpdateSliderDto'ya mapliyoruz ve view'e bu DTO'yu gönderiyoruz
            var updateSliderDto = _mapper.Map<UpdateSliderDto>(slider);

            return View(updateSliderDto);
        }

        [HttpPost]
        public IActionResult UpdateSlider(UpdateSliderDto updateSliderDto)
        {
            // UpdateSliderDto'yu Slider entity'sine mapliyoruz
            var value = _mapper.Map<Slider>(updateSliderDto);

            // Güncelleme işlemi
            _sliderService.TUpdate(value);

            // Güncelleme işlemi sonrası SliderList sayfasına yönlendirme
            return RedirectToAction("SliderList");
        }


    }
}
