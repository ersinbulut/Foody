using AutoMapper;
using Foody.BusinessLayer.Abstract;
using Foody.DtoLayer.Dtos.FeatureDtos;
using Foody.EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace Foody.PresentationLayer.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class FeaturesController : Controller
    {
        private readonly IFeatureService _featureService;
        private readonly IMapper _mapper;

        public FeaturesController(IFeatureService featureService, IMapper mapper)
        {
            _featureService = featureService;
            _mapper = mapper;
        }

        public IActionResult FeatureList()
        {
            var values = _featureService.TGetAll();
            return View(_mapper.Map<List<ResultFeatureDto>>(values));
        }

        [HttpGet]
        public IActionResult CreateFeature()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateFeature(CreateFeatureDto createFeatureDto)
        {
            var value = _mapper.Map<Feature>(createFeatureDto);
            _featureService.TInsert(value);
            return RedirectToAction("FeatureList");
        }
        public IActionResult DeleteFeature(int id)
        {
            _featureService.TDelete(id);
            return RedirectToAction("FeatureList");
        }
        [HttpGet]
        public IActionResult UpdateFeature(int id)
        {
            // ID ile Feature'ı çekiyoruz
            var Feature = _featureService.TGetById(id);

            // GetByIdFeatureDto'yu UpdateFeatureDto'ya mapliyoruz ve view'e bu DTO'yu gönderiyoruz
            var updateFeatureDto = _mapper.Map<UpdateFeatureDto>(Feature);

            return View(updateFeatureDto);
        }

        [HttpPost]
        public IActionResult UpdateFeature(UpdateFeatureDto updateFeatureDto)
        {
            // UpdateFeatureDto'yu Feature entity'sine mapliyoruz
            var value = _mapper.Map<Feature>(updateFeatureDto);

            // Güncelleme işlemi
            _featureService.TUpdate(value);

            // Güncelleme işlemi sonrası FeatureList sayfasına yönlendirme
            return RedirectToAction("FeatureList");
        }
    }
}

