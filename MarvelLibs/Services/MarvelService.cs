using MarvelAPI.Model;
using MarvelAPIService.GetData;
using MarvelAPIService.Marvel;
using MarvelAPIService.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MarvelAPIService.Services
{
    public class MarvelService : IMarvelService
    {
        private readonly IMarvelDataContainer _marvelDataContainer;
        
        public MarvelService(IMarvelDataContainer marvelDataContainer)
        {
            _marvelDataContainer = marvelDataContainer;
        }
        
        public async Task<List<CharacterId>> GetAllCharacterIds()
        {
            return await _marvelDataContainer.GetAllCharacterIds();
        }

        public async Task<Data<Result<CharacterDescription>>> GetCharacterDescription(int characterId)
        {
            return await _marvelDataContainer.GetCharacterDescription(characterId);
        }
    }
}
