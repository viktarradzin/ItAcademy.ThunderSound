using System.Collections.Generic;
using System.Linq;
using ItAcademy.ThunderSound.DomainLayer.Interfaces.Repositories;
using ItAcademy.ThunderSound.DomainLayer.Models;
using ItAcademy.ThunderSound.DomainLayer.UnitOfWork;

namespace ItAcademy.ThunderSound.DataLayer.Repositories
{
    public class LabelRepository : BaseRepository<LabelModel>, ILabelRepository
    {
        public LabelRepository(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        public List<LabelModel> GetTopFivePopularLabels()
        {
            return GetQueryableItems().OrderBy(x => x.LabelId).Take(5).ToList();
        }
    }
}