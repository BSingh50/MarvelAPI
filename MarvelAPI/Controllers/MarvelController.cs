using MarvelAPIService.Services;
using MarvelStorage.DataHandler;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MarvelAPI.Controllers
{
    public class MarvelController : ControllerBase
    {
        private readonly IMarvelService _marvelService;
        private readonly IDataHandler _dataHandler;

        public MarvelController(IMarvelService marvelService, IDataHandler dataHandler)
        {
            _marvelService = marvelService;
            _dataHandler = dataHandler;
        }

        [HttpGet]
        [Route("characterids")]
        public async Task<IActionResult> GetAllCharacterIds()
        {
            var result = await _marvelService.GetAllCharacterIds();
            _dataHandler.saveToFile(@"MarvelCharacterIds.txt", result);
            return Ok(result);
        }

        [HttpGet]
        [Route("characterdescriptions")]
        public async Task<IActionResult> GetCharacterDescription()
        {
            var result = await _marvelService.GetCharacterDescription(1009435);
            return Ok(result);
        }
    }
}
