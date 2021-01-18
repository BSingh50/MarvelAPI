using MarvelAPI.Model;
using MarvelAPIService.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MarvelAPIService.GetData
{
    public interface IMarvelDataContainer
    {
        Task<List<CharacterId>> GetAllCharacterIds(int offset = 0);
        Task<Data<Result<CharacterDescription>>> GetCharacterDescription(int characterId);
    }
}
