using Backend.Models;

namespace Backend.Data
{
    public interface IPlantRepository
    {
        void Create(List<Plant> plants);      
        List<Plant> Read();                   
        void Delete(string name);             
        void DeleteAll();
        object GenerateSchedule();
    }
}
