using ItAcademy.ThunderSound.DomainLayer.Models;
using System.Data.Entity;
using System.IO;

namespace ItAcademy.ThunderSound.DataLayer.Context
{
    class UserDbInitializer : DropCreateDatabaseAlways<ThunderSoundDbContext>
    {
        protected override void Seed(ThunderSoundDbContext thunderSoundDbContext)
        {
            Genre Genre1 = new Genre { Name = "Jazz" };
            Genre Genre2 = new Genre { Name = "Rock" };
            Genre Genre3 = new Genre { Name = "Metal" };
            Genre Genre4 = new Genre { Name = "Dance" };
            Genre Genre5 = new Genre { Name = "Trance" };
            Label Label1 = new Label { Name = "House Home01" };
            Label Label2 = new Label { Name = "House Home02" };
            Label Label3 = new Label { Name = "House Home03" };
            Singer singer1 = new Singer { Name = "Travis" , Genre = Genre1,  Image = File.ReadAllBytes(@"D:\Music_Database\img\Starfish.jpg" )};
            PlayList playList1 = new PlayList { Genre = Genre1, Name = "Sun Rise", Singer = singer1, Label = Label1 };
            Track track1_1 = new Track { Name = "Travis - A Ghost01",  Singer = singer1, File = File.ReadAllBytes(@"D:\Music_Database\Travis\Travis - A Ghost.mp3") , Genre = Genre1, PlayList = playList1};
            Track track1_2 = new Track { Name = "Travis - A Ghost02", Singer =  singer1 , File = File.ReadAllBytes(@"D:\Music_Database\Travis\Travis - A Million Hearts.mp3"), Genre = Genre1, PlayList = playList1 };
            Track track1_3 = new Track { Name = "Travis - A Ghost03", Singer = singer1 , File = File.ReadAllBytes(@"D:\Music_Database\Travis\Travis - All Fall Down.mp3"), Genre = Genre1 , PlayList = playList1 };
            playList1.Tracks.Add(track1_1);
            playList1.Tracks.Add(track1_2);
            playList1.Tracks.Add(track1_3);
            Singer singer2 = new Singer { Name = "Coler" , Genre = Genre2, Image = File.ReadAllBytes(@"D:\Music_Database\img\Starfish.jpg") };
            PlayList playList2 = new PlayList { Genre = Genre2, Name = "Call Me" , Singer = singer2, Label = Label2};
            Track track2_1 = new Track { Name = "Coler - Butter1", Singer = singer2, File = File.ReadAllBytes(@"D:\Music_Database\Coler\Coler - Butterflies - Kissing in the Wind.mp3"), Genre = Genre2, PlayList = playList2 };
            Track track2_2 = new Track { Name = "Coler - Butter2", Singer = singer2, File = File.ReadAllBytes(@"D:\Music_Database\Coler\Coler - Butterflies.mp3") ,Genre = Genre2, PlayList = playList2 };
            Track track2_3 = new Track { Name = "Coler - Butter3", Singer = singer2, File = File.ReadAllBytes(@"D:\Music_Database\Coler\Coler - Nina's Song.mp3"), Genre = Genre2, PlayList = playList2 };
            playList2.Tracks.Add(track2_1);
            playList2.Tracks.Add(track2_2);
            playList2.Tracks.Add(track2_3);
            Singer singer3 = new Singer { Name = "Marry" , Genre = Genre3 , Image = File.ReadAllBytes(@"D:\Music_Database\img\Starfish.jpg") };
            PlayList playList3 = new PlayList { Genre = Genre3, Name = "Love you", Label = Label3, Singer = singer3 };
            Track track3_1 = new Track { Name = "Marry - No Love01", Singer = singer3, File = File.ReadAllBytes(@"D:\Music_Database\Marry\Marry - No Love Lost.mp3") , Genre = Genre3, PlayList = playList3 };
            Track track3_2 = new Track { Name = "Marry - No Love02", Singer = singer3, File = File.ReadAllBytes(@"D:\Music_Database\Marry\Marry - The Only Thing.mp3"), Genre = Genre3, PlayList = playList3 };
            Track track3_3 = new Track { Name = "Marry - No Love03", Singer = singer3, File = File.ReadAllBytes(@"D:\Music_Database\Marry\Marry - Valentine.mp3"), Genre = Genre3 , PlayList = playList3};
            playList3.Tracks.Add(track3_1);
            playList3.Tracks.Add(track3_2);
            playList3.Tracks.Add(track3_3);
            thunderSoundDbContext.Genre.Add(Genre1);
            thunderSoundDbContext.Genre.Add(Genre2);
            thunderSoundDbContext.Genre.Add(Genre3);
            thunderSoundDbContext.Genre.Add(Genre4);
            thunderSoundDbContext.Genre.Add(Genre5);
            thunderSoundDbContext.PlayLists.Add(playList1);
            thunderSoundDbContext.PlayLists.Add(playList2);
            thunderSoundDbContext.PlayLists.Add(playList3);
            thunderSoundDbContext.SaveChanges();
        }
    }
}