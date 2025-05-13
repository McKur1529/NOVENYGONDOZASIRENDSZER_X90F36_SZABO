using Backend.Models;

namespace Backend.Data
{
    public class PlantRepository : IPlantRepository
    {
        private List<Plant> _plants = new();

        public void Create(List<Plant> plants)
        {
            _plants.Clear(); // ha új listát küldünk, töröljük a régit
            _plants.AddRange(plants);
        }

        public List<Plant> Read()
        {
            return _plants;
        }

        public void Delete(string name)
        {
            var target = _plants.FirstOrDefault(p => p.Name == name);
            if (target != null)
            {
                _plants.Remove(target);
            }
        }

        public void DeleteAll()
        {
            _plants.Clear();
        }
    }
}

