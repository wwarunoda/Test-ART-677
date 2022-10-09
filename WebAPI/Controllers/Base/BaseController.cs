using Application.Services.Abstractions.Base;
using Domain.Entities.Base;
using Domain.Enums;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers.Base
{
    public class BaseController<T> : ControllerBase where T : BaseResidenceEntity
    {
        IBaseService<T> _service;

        public BaseController(IBaseService<T> service)
        {
            _service = service;
        }


        public async Task<IActionResult> GetByStateAsync<U>(string state, CommuneType communeType)
        {
            var response = await _service.GetByStateAsync<U>(state, communeType);
            if (response.Message == MessageTypes.No_Data_Found.AsText())
                throw new KeyNotFoundException("No data found. Try again");
            return Ok(response);
        }        
    }
}
