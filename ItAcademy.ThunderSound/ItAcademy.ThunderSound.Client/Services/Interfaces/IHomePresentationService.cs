using System.Collections.Generic;
using ItAcademy.ThunderSound.Client.Models;

namespace ItAcademy.ThunderSound.Client.Services.Interfaces
{
    public interface IHomePresentationService
    {
        List<TrackViewModel> GetSixRandomTrackWithPlayList();

        byte[] GetImage(int id);
    }
}