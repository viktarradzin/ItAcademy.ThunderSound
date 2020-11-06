using System;
using System.Collections.Generic;
using ItAcademy.ThunderSound.DomainLayer.Interfaces.Repositories;
using ItAcademy.ThunderSound.DomainLayer.Interfaces.Services;
using ItAcademy.ThunderSound.DomainLayer.Models;
using ItAcademy.ThunderSound.DomainLayer.UnitOfWork;

namespace ItAcademy.ThunderSound.DomainLayer.Services
{
    public class LabelDomainService : BaseDomainService<LabelModel>, ILabelDomainService
    {
        public LabelDomainService(ILabelRepository repository, IUnitOfWork unitOfWork)
            : base(repository, unitOfWork)
        {
        }

        public List<LabelModel> GetTopFivePopularLabels()
        {
            throw new NotImplementedException();
        }
    }
}