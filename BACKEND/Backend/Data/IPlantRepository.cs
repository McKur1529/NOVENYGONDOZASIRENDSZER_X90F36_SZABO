using Backend.Model;
using Backend.Models;

namespace Backend.Data
{
    public interface IPlantRepository
    {
        void Create(Plant plant);      
        List<Plant> Read();                   
        void Delete(string name);             
        void DeleteAll();
        Schedule GenerateSchedule();
    }
}
