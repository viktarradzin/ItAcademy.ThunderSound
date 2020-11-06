using System.Collections.Generic;

namespace ItAcademy.ThunderSound.DomainLayer.Models
{
    public class LabelModel
    {
        public int LabelId { get; set; }

        public string LabelName { get; set; }

        public byte[] Image { get; set; }

        public List<PlayListModel> PlayLists { get; set; }
    }
}