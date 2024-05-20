using homePrakticee.DAL;
using homePrakticee.Models;
using homePrakticee.ViewModels.Sliders;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace homePrakticee.Controllers
{
    public class SliderController(PrakticeContext _prakticeContext) : Controller
    {
        
        public async Task<IActionResult> Index()
        {
            var data =await _prakticeContext.Sliders.Select(s=>new GetAdminSliderVM 
            {
                SubTitle = s.Title,
                Title = s.Title,
                CreatedTime = s.CreatedTime,
                Id = s.Id,
                ImgUrl = s.ImgUrl,
                IsDeleted = s.IsDeleted,
            
            }
            ).ToListAsync();
            
            return View(data);
        }

        public async Task <IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateSliderVM sliderVM)
        {
            Slider slider = new Slider
            {
                Title = sliderVM.Title,
                SubTitle = sliderVM.Title,
                ImgUrl = sliderVM.ImgUrl,
                CreatedTime = DateTime.Now,
                IsDeleted = false
            };
            await _prakticeContext.Sliders.AddAsync(slider);
            await _prakticeContext.SaveChangesAsync();


            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Update (int? id)
        {
            Slider slider= await _prakticeContext.Sliders.FindAsync(id);
            UpdateSliderVM sliderVM = new UpdateSliderVM
            {
                Title = slider.Title,
                SubTitle = slider.Title,
                ImgUrl = slider.ImgUrl
            };
            return View(sliderVM);
        }


        [HttpPost]
        public async Task<IActionResult> Update(int? id,UpdateSliderVM sliderVM)
        {
            var exis = await _prakticeContext.Sliders.FirstOrDefaultAsync(x => x.Id == id);

            exis.Title= sliderVM.Title;
            exis.SubTitle= sliderVM.SubTitle;
            exis.ImgUrl= sliderVM.ImgUrl;
            
            await _prakticeContext.SaveChangesAsync();
            return RedirectToAction(nameof(Index));

        }

        public async Task<IActionResult> Delete (int? id)
        {
            var slide = await _prakticeContext.Sliders.FindAsync(id);
            _prakticeContext.Sliders.Remove(slide);
            await _prakticeContext.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
