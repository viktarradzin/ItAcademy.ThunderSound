using System.Collections.Generic;
using ItAcademy.ThunderSound.DomainLayer.Models;

namespace ItAcademy.ThunderSound.DomainLayer.Interfaces.Services
{
    public interface ILabelDomainService : IBaseDomainService<LabelModel>
    {
         List<LabelModel> GetTopFivePopularLabels();
    }
}