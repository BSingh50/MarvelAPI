using MarvelAPI.Model;
using MarvelAPIService.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MarvelAPIService.Services
{
    public interface IMarvelService
    {
        Task<List<CharacterId>> GetAllCharacterIds();
        Task<Data<Result<CharacterDescription>>> GetCharacterDescription(int characterId);
    }
}
