using System.Collections.Generic;
using System.IO;
using System.Web;
using AutoMapper;
using ItAcademy.ThunderSound.Client.Models;
using ItAcademy.ThunderSound.Client.Services.Interfaces;
using ItAcademy.ThunderSound.DomainLayer.Interfaces.Services;
using ItAcademy.ThunderSound.DomainLayer.Models;

namespace ItAcademy.ThunderSound.Client.Services
{
    public class LabelPresentationService : ILabelPresentationService
    {
        private readonly ILabelDomainService labelDomainService;

        public LabelPresentationService(ILabelDomainService labelDomainService)
        {
            this.labelDomainService = labelDomainService;
        }

        public byte[] GetImage(int id)
        {
            var labelView = labelDomainService.Get(id);

            byte[] imageBytes = labelView.Image;

            return imageBytes;
        }

        public List<LabelViewModel> GetAllLabels()
        {
            var label = labelDomainService.GetAll();

            var labelView = Mapper.Map<List<LabelViewModel>>(label);

            return labelView;
        }

        public LabelViewModel GetLabelById(int id)
        {
            var label = labelDomainService.Get(id);

            var labelView = Mapper.Map<LabelViewModel>(label);

            return labelView;
        }

        public LabelViewModel EditLabel(int id)
        {
            return Mapper.Map<LabelViewModel>(labelDomainService.Get(id));
        }

        public void EditLabel(LabelViewModel labelView, HttpPostedFileBase uploadImage)
        {
            var label = labelDomainService.Get(labelView.LabelId);

            label.Image = TransformPostedFileToByte(uploadImage);

            Mapper.Map(labelView, label);

            labelDomainService.Edit();
        }

        public void AddLabel(LabelViewModel labelView, HttpPostedFileBase uploadImage)
        {
            var label = Mapper.Map<LabelViewModel, LabelModel>(labelView);

            label.Image = TransformPostedFileToByte(uploadImage);

            labelDomainService.Add(label);
        }

        public void DeleteLabelById(int id)
        {
            labelDomainService.DeleteById(id);
        }

        private byte[] TransformPostedFileToByte(HttpPostedFileBase uploadImage)
        {
            byte[] imageData = null;

            using (var binaryReader = new BinaryReader(uploadImage.InputStream))
            {
                imageData = binaryReader.ReadBytes(uploadImage.ContentLength);
            }

            return imageData;
        }
    }
}