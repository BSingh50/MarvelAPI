using MarvelAPI.Model;
using MarvelAPIService.Marvel;
using MarvelAPIService.Model;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

namespace MarvelAPIService.GetData
{
    public class MarvelDataContainer : IMarvelDataContainer
    {
        IMarvelDataHandler _marvelDataHandler;
        List<CharacterId> characterIds;
        public MarvelDataContainer(IMarvelDataHandler marvelDataHandler)
        {
            _marvelDataHandler = marvelDataHandler;
            characterIds = new List<CharacterId>();
        }
        public async Task<List<CharacterId>> GetAllCharacterIds(int offset = 0)
        {
            var characterList = JsonConvert.DeserializeObject<Data<Result<CharacterId>>>(await _marvelDataHandler.GetMarvelApiData("characters",offset)).data.results.ToList();
            characterIds.AddRange(characterList);
            offset += 100;
            while (characterList.Count > 0)
            {
                GetAllCharacterIds(offset);
            }
            return characterIds;
        }

        public async Task<Data<Result<CharacterDescription>>> GetCharacterDescription(int characterId)
        {
            return JsonConvert.DeserializeObject<Data<Result<CharacterDescription>>>(await _marvelDataHandler.GetMarvelApiData($"characters/{characterId}"));
        }
    }
}
