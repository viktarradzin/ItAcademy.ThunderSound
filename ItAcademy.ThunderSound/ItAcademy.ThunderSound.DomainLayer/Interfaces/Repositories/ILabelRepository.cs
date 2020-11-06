using System.Collections.Generic;
using ItAcademy.ThunderSound.DomainLayer.Models;

namespace ItAcademy.ThunderSound.DomainLayer.Interfaces.Repositories
{
    public interface ILabelRepository : IBaseRepository<LabelModel>
    {
        List<LabelModel> GetTopFivePopularLabels();
    }
}