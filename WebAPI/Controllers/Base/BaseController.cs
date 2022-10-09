using Application.Services.Abstractions.Base;
using Domain.Entities.Base;
using Domain.Enums;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers.Base
{
    public class BaseController<T> : ControllerBase where T : BaseEntity
    {
        IBaseService<T> _service;

        public BaseController(IBaseService<T> service)
        {
            _service = service;
        }


        public async Task<IActionResult> GetByStateAsync<U>(string state, CommuneType communeType)
        {
            var response = await _service.GetByStateAsync<U>(state, communeType);

            return Ok(response);
        }        
    }
}
