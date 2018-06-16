using Repository.Entities;
using System.Collections.Generic;

namespace Repository
{
    public interface IConfigRepository
    {
        Config GetById(int id);
        Config GetByKey(string key);

        IReadOnlyList<Config> GetAll();
    }
}
