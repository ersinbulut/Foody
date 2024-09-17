using AutoMapper;
using Foody.BusinessLayer.Abstract;
using Foody.DtoLayer.Dtos.AboutDtos;
using Foody.EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace Foody.PresentationLayer.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AboutsController : Controller
    {
        private readonly IAboutService _aboutService;
        private readonly IMapper _mapper;

        public AboutsController(IAboutService aboutService, IMapper mapper)
        {
            _aboutService = aboutService;
            _mapper = mapper;
        }

        public IActionResult AboutList()
        {
            var values = _aboutService.TGetAll();
            return View(_mapper.Map<List<ResultAboutDto>>(values));
        }

        [HttpGet]
        public IActionResult CreateAbout()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateAbout(CreateAboutDto createAboutDto)
        {
            var value = _mapper.Map<About>(createAboutDto);
            _aboutService.TInsert(value);
            return RedirectToAction("AboutList");
        }
        public IActionResult DeleteAbout(int id)
        {
            _aboutService.TDelete(id);
            return RedirectToAction("AboutList");
        }
        [HttpGet]
        public IActionResult UpdateAbout(int id)
        {
            // ID ile About'ı çekiyoruz
            var About = _aboutService.TGetById(id);

            // GetByIdAboutDto'yu UpdateAboutDto'ya mapliyoruz ve view'e bu DTO'yu gönderiyoruz
            var updateAboutDto = _mapper.Map<UpdateAboutDto>(About);

            return View(updateAboutDto);
        }

        [HttpPost]
        public IActionResult UpdateAbout(UpdateAboutDto updateAboutDto)
        {
            // UpdateAboutDto'yu About entity'sine mapliyoruz
            var value = _mapper.Map<About>(updateAboutDto);

            // Güncelleme işlemi
            _aboutService.TUpdate(value);

            // Güncelleme işlemi sonrası AboutList sayfasına yönlendirme
            return RedirectToAction("AboutList");
        }
    }
}
