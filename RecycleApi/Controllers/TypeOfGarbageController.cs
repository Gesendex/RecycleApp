using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Recycle.Interfaces.Services;
using Recycle.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;

namespace RecycleApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TypeOfGarbageController : ControllerBase
    {
        ITypeOfGarbageService typeOfGarbageService;

        public TypeOfGarbageController(ITypeOfGarbageService typeOfGarbageService)
        {
            this.typeOfGarbageService = typeOfGarbageService;
        }

        [HttpGet("GetAll")]
        public async Task<IEnumerable<TypeOfGarbage>> GetAll()
        {
            return await typeOfGarbageService.GetAllAsync();
        }

        [HttpGet("GetAllWithImage")]
        public async Task<IEnumerable<TypeOfGarbage>> GetAllWithImage()
        {
            return await typeOfGarbageService.GetAllWithImageAsync();
        }

        [HttpGet("GetById/{id}")]
        public async Task<TypeOfGarbage> GetById(int id)
        {
            return await typeOfGarbageService.GetByIdAsync(id);
        }
    }
}
