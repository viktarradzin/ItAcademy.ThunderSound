using System;
using System.Collections.Generic;
using System.IO;
using ItAcademy.ThunderSound.DataLayer.Context;
using ItAcademy.ThunderSound.DomainLayer.Models;

namespace DB_Initializer
{
    public class Initialize
    {
        public static void Main()
        {
            // var connectionString = @"data source=.;initial catalog=ThunderSound;integrated security=True;MultipleActiveResultSets=true";
            var connectionString = @"data source=.;initial catalog=ThunderSound;integrated security=True;MultipleActiveResultSets=true";
            var pathImage = @"D:\ThunderSound_Database\img\";
            var pathMusicFiles = @"D:\ThunderSound_Database\music\";

            using (ThunderSoundDbContext context = new ThunderSoundDbContext(connectionString))
            {
                LabelModel label1 = new LabelModel { LabelName = "Some label", Image = File.ReadAllBytes(pathImage + @"Label\gazgolder.jpg") };

                context.Label.Add(label1);

                List<GenreModel> genreModels = new List<GenreModel>
                {
                    new GenreModel { GenreName = "Инди", Image = File.ReadAllBytes(pathImage + @"Genre\Инди.jpg") },
                    new GenreModel { GenreName = "Диско", Image = File.ReadAllBytes(pathImage + @"Genre\Диско.jpg") },
                    new GenreModel { GenreName = "Металл", Image = File.ReadAllBytes(pathImage + @"Genre\Металл.jpg") },
                    new GenreModel { GenreName = "Рок", Image = File.ReadAllBytes(pathImage + @"Genre\Рок.jpg") },
                    new GenreModel { GenreName = "Джаз", Image = File.ReadAllBytes(pathImage + @"Genre\Джаз.jpg") }
                };

                foreach (var item in genreModels)
                {
                    context.Genre.Add(item);
                }

                List<SingerModel> singerModels = new List<SingerModel>
                {
                    new SingerModel { SingerName = "Arctic Monkeys", Genre = genreModels[0], Image = File.ReadAllBytes(pathImage + @"Singer\Arctic Monkeys.jpg") },
                    new SingerModel { SingerName = "Bad Boys Blue", Genre = genreModels[1], Image = File.ReadAllBytes(pathImage + @"Singer\Bad Boys Blue.jpg") },
                    new SingerModel { SingerName = "Metallica", Genre = genreModels[2], Image = File.ReadAllBytes(pathImage + @"Singer\Metallica.jpg") },
                    new SingerModel { SingerName = "Король и Шут", Genre = genreModels[3], Image = File.ReadAllBytes(pathImage + @"Singer\Король и Шут.jpg") },
                    new SingerModel { SingerName = "Richard Holmes", Genre = genreModels[4], Image = File.ReadAllBytes(pathImage + @"Singer\Richard Holmes.jpg") }
                };

                foreach (var item in singerModels)
                {
                    context.Singers.Add(item);
                }

                var tracks = new List<TrackModel>();

                List<PlayListModel> playListModels = new List<PlayListModel>
                {
                    new PlayListModel
                    {
                        Genre = genreModels[0],
                        PlayListName = "AM",
                        Singer = singerModels[0],
                        Label = label1,
                        Image = File.ReadAllBytes(pathImage + @"PlayList\AM.jpg")
                    },
                    new PlayListModel
                    {
                        Genre = genreModels[0],
                        PlayListName = "Five Minutes With Monkeys",
                        Singer = singerModels[0],
                        Label = label1,
                        Image = File.ReadAllBytes(pathImage + @"PlayList\Five Minutes With Monkeys.jpg")
                    },
                    new PlayListModel
                    {
                        Genre = genreModels[0],
                        PlayListName = "Matador",
                        Singer = singerModels[0],
                        Label = label1,
                        Image = File.ReadAllBytes(pathImage + @"PlayList\Matador.jpg")
                    },
                    new PlayListModel
                    {
                        Genre = genreModels[0],
                        PlayListName = "R U Mine",
                        Singer = singerModels[0],
                        Label = label1,
                        Image = File.ReadAllBytes(pathImage + @"PlayList\R U Mine.jpg")
                    },
                    new PlayListModel
                    {
                        Genre = genreModels[0],
                        PlayListName = "Suck It And See",
                        Singer = singerModels[0],
                        Label = label1,
                        Image = File.ReadAllBytes(pathImage + @"PlayList\Suck It And See.jpg")
                    },
                    new PlayListModel
                    {
                        Genre = genreModels[1],
                        PlayListName = "Hot Girls, Bad Boys",
                        Singer = singerModels[1],
                        Label = label1,
                        Image = File.ReadAllBytes(pathImage + @"PlayList\Hot Girls Bad Boys.jpg")
                    },
                    new PlayListModel
                    {
                        Genre = genreModels[2],
                        PlayListName = "Muster of puppets",
                        Singer = singerModels[2],
                        Label = label1,
                        Image = File.ReadAllBytes(pathImage + @"PlayList\Muster of puppets.jpg")
                    },
                    new PlayListModel
                    {
                        Genre = genreModels[3],
                        PlayListName = "Бунт на корабле",
                        Singer = singerModels[3],
                        Label = label1,
                        Image = File.ReadAllBytes(pathImage + @"PlayList\Бунт на корабле.jpg")
                    },
                    new PlayListModel
                    {
                        Genre = genreModels[4],
                        PlayListName = "Comin' On Home",
                        Singer = singerModels[4],
                        Label = label1,
                        Image = File.ReadAllBytes(pathImage + @"PlayList\Comin' On Home.jpg")
                    }
                };

                foreach (var item in playListModels)
                {
                    context.PlayLists.Add(item);
                }

                List<TrackModel> trackModels = new List<TrackModel>
                {
                    new TrackModel
                    {
                        TrackName = "Dont mess with me",
                        Singer = singerModels[4],
                        File = File.ReadAllBytes(pathMusicFiles + @"Richard Holmes\dont-mess-with-me.mp3"),
                        Genre = genreModels[4],
                        PlayList = playListModels[8]
                    },
                    new TrackModel
                    {
                        TrackName = "Down home funk",
                        Singer = singerModels[4],
                        File = File.ReadAllBytes(pathMusicFiles + @"Richard Holmes\down-home-funk.mp3"),
                        Genre = genreModels[4],
                        PlayList = playListModels[8]
                    },
                    new TrackModel
                    {
                        TrackName = "Groovin for mr g",
                        Singer = singerModels[4],
                        File = File.ReadAllBytes(pathMusicFiles + @"Richard Holmes\groovin-for-mr-g.mp3"),
                        Genre = genreModels[4],
                        PlayList = playListModels[8]
                    },
                    new TrackModel
                    {
                        TrackName = "Mr clean",
                        Singer = singerModels[4],
                        File = File.ReadAllBytes(pathMusicFiles + @"Richard Holmes\mr-clean.mp3"),
                        Genre = genreModels[4],
                        PlayList = playListModels[8]
                    },
                    new TrackModel
                    {
                        TrackName = "Theme from love story",
                        Singer = singerModels[4],
                        File = File.ReadAllBytes(pathMusicFiles + @"Richard Holmes\theme-from-love-story.mp3"),
                        Genre = genreModels[4],
                        PlayList = playListModels[8]
                    },
                    new TrackModel
                    {
                        TrackName = "This here",
                        Singer = singerModels[4],
                        File = File.ReadAllBytes(pathMusicFiles + @"Richard Holmes\this-here.mp3"),
                        Genre = genreModels[4],
                        PlayList = playListModels[8]
                    },
                    new TrackModel
                    {
                        TrackName = "Wave",
                        Singer = singerModels[4],
                        File = File.ReadAllBytes(pathMusicFiles + @"Richard Holmes\wave.mp3"),
                        Genre = genreModels[4],
                        PlayList = playListModels[8]
                    },
                    new TrackModel
                    {
                        TrackName = "Battery",
                        Singer = singerModels[2],
                        File = File.ReadAllBytes(pathMusicFiles + @"Metallica\battery.mp3"),
                        Genre = genreModels[2],
                        PlayList = playListModels[6]
                    },
                    new TrackModel
                    {
                        TrackName = "Damage inc",
                        Singer = singerModels[2],
                        File = File.ReadAllBytes(pathMusicFiles + @"Metallica\damage-inc.mp3"),
                        Genre = genreModels[2],
                        PlayList = playListModels[6]
                    },
                    new TrackModel
                    {
                        TrackName = "Disposable heroes",
                        Singer = singerModels[2],
                        File = File.ReadAllBytes(pathMusicFiles + @"Metallica\disposable-heroes.mp3"),
                        Genre = genreModels[2],
                        PlayList = playListModels[6]
                    },
                    new TrackModel
                    {
                        TrackName = "Leper messiah",
                        Singer = singerModels[2],
                        File = File.ReadAllBytes(pathMusicFiles + @"Metallica\leper-messiah.mp3"),
                        Genre = genreModels[2],
                        PlayList = playListModels[6]
                    },
                    new TrackModel
                    {
                        TrackName = "Orion instrumental",
                        Singer = singerModels[2],
                        File = File.ReadAllBytes(pathMusicFiles + @"Metallica\orion-instrumental.mp3"),
                        Genre = genreModels[2],
                        PlayList = playListModels[6]
                    },
                    new TrackModel
                    {
                        TrackName = "Thing that should not be",
                        Singer = singerModels[2],
                        File = File.ReadAllBytes(pathMusicFiles + @"Metallica\the-thing-that-should-not-be.mp3"),
                        Genre = genreModels[2],
                        PlayList = playListModels[6]
                    },
                    new TrackModel
                    {
                        TrackName = "Welcome home sanitarium",
                        Singer = singerModels[2],
                        File = File.ReadAllBytes(pathMusicFiles + @"Metallica\welcome-home-sanitarium.mp3"),
                        Genre = genreModels[2],
                        PlayList = playListModels[6]
                    },
                    new TrackModel
                    {
                        TrackName = "For your love",
                        Singer = singerModels[1],
                        File = File.ReadAllBytes(pathMusicFiles + @"Bad Boys Blue\for-your-love.mp3"),
                        Genre = genreModels[1],
                        PlayList = playListModels[5]
                    },
                    new TrackModel
                    {
                        TrackName = "Hot girls bad boys",
                        Singer = singerModels[1],
                        File = File.ReadAllBytes(pathMusicFiles + @"Bad Boys Blue\hot-girls-bad-boys.mp3"),
                        Genre = genreModels[1],
                        PlayList = playListModels[5]
                    },
                    new TrackModel
                    {
                        TrackName = "I live",
                        Singer = singerModels[1],
                        File = File.ReadAllBytes(pathMusicFiles + @"Bad Boys Blue\i-live.mp3"),
                        Genre = genreModels[1],
                        PlayList = playListModels[5]
                    },
                    new TrackModel
                    {
                        TrackName = "Kiss you all over baby",
                        Singer = singerModels[1],
                        File = File.ReadAllBytes(pathMusicFiles + @"Bad Boys Blue\kiss-you-all-over-baby.mp3"),
                        Genre = genreModels[1],
                        PlayList = playListModels[5]
                    },
                    new TrackModel
                    {
                        TrackName = "L o v e in my car",
                        Singer = singerModels[1],
                        File = File.ReadAllBytes(pathMusicFiles + @"Bad Boys Blue\l-o-v-e-in-my-car.mp3"),
                        Genre = genreModels[1],
                        PlayList = playListModels[5]
                    },
                    new TrackModel
                    {
                        TrackName = "People of the night",
                        Singer = singerModels[1],
                        File = File.ReadAllBytes(pathMusicFiles + @"Bad Boys Blue\people-of-the-night.mp3"),
                        Genre = genreModels[1],
                        PlayList = playListModels[5]
                    },
                    new TrackModel
                    {
                        TrackName = "Pretty young girl",
                        Singer = singerModels[1],
                        File = File.ReadAllBytes(pathMusicFiles + @"Bad Boys Blue\pretty-young-girl.mp3"),
                        Genre = genreModels[1],
                        PlayList = playListModels[5]
                    },
                    new TrackModel
                    {
                        TrackName = "Youre a woman",
                        Singer = singerModels[1],
                        File = File.ReadAllBytes(pathMusicFiles + @"Bad Boys Blue\youre-a-woman.mp3"),
                        Genre = genreModels[1],
                        PlayList = playListModels[5]
                    },
                    new TrackModel
                    {
                        TrackName = "Бунт на корабле",
                        Singer = singerModels[3],
                        File = File.ReadAllBytes(pathMusicFiles + @"КиШ\бунт-на-корабле.mp3"),
                        Genre = genreModels[3],
                        PlayList = playListModels[7]
                    },
                    new TrackModel
                    {
                        TrackName = "Волшебныи глаз старика",
                        Singer = singerModels[3],
                        File = File.ReadAllBytes(pathMusicFiles + @"КиШ\волшебныи-глаз-старика-алонса.mp3"),
                        Genre = genreModels[3],
                        PlayList = playListModels[7]
                    },
                    new TrackModel
                    {
                        TrackName = "Задира и солдат",
                        Singer = singerModels[3],
                        File = File.ReadAllBytes(pathMusicFiles + @"КиШ\задира-и-солдат.mp3"),
                        Genre = genreModels[3],
                        PlayList = playListModels[7]
                    },
                    new TrackModel
                    {
                        TrackName = "Идол",
                        Singer = singerModels[3],
                        File = File.ReadAllBytes(pathMusicFiles + @"КиШ\идол.mp3"),
                        Genre = genreModels[3],
                        PlayList = playListModels[7]
                    },
                    new TrackModel
                    {
                        TrackName = "Инквизитор",
                        Singer = singerModels[3],
                        File = File.ReadAllBytes(pathMusicFiles + @"КиШ\инквизитор.mp3"),
                        Genre = genreModels[3],
                        PlayList = playListModels[7]
                    },
                    new TrackModel
                    {
                        TrackName = "Исповедь вампира",
                        Singer = singerModels[3],
                        File = File.ReadAllBytes(pathMusicFiles + @"КиШ\исповедь-вампира.mp3"),
                        Genre = genreModels[3],
                        PlayList = playListModels[7]
                    },
                    new TrackModel
                    {
                        TrackName = "Arabella",
                        Singer = singerModels[0],
                        File = File.ReadAllBytes(pathMusicFiles + @"Arctic Monkeys\AM\arabella.mp3"),
                        Genre = genreModels[0],
                        PlayList = playListModels[0]
                    },
                    new TrackModel
                    {
                        TrackName = "Do I wanna know",
                        Singer = singerModels[0],
                        File = File.ReadAllBytes(pathMusicFiles + @"Arctic Monkeys\AM\do-i-wanna-know.mp3"),
                        Genre = genreModels[0],
                        PlayList = playListModels[0]
                    },
                    new TrackModel
                    {
                        TrackName = "Fireside",
                        Singer = singerModels[0],
                        File = File.ReadAllBytes(pathMusicFiles + @"Arctic Monkeys\AM\fireside.mp3"),
                        Genre = genreModels[0],
                        PlayList = playListModels[0]
                    },
                    new TrackModel
                    {
                        TrackName = "Fake tales of SF",
                        Singer = singerModels[0],
                        File = File.ReadAllBytes(pathMusicFiles + @"Arctic Monkeys\Five Minutes\fake-tales-of-san-francisco.mp3"),
                        Genre = genreModels[0],
                        PlayList = playListModels[1]
                    },
                    new TrackModel
                    {
                        TrackName = "From ritz to rubble",
                        Singer = singerModels[0],
                        File = File.ReadAllBytes(pathMusicFiles + @"Arctic Monkeys\Five Minutes\from-the-ritz-to-the-rubble.mp3"),
                        Genre = genreModels[0],
                        PlayList = playListModels[1]
                    },
                    new TrackModel
                    {
                        TrackName = "I wanna be yours",
                        Singer = singerModels[0],
                        File = File.ReadAllBytes(pathMusicFiles + @"Arctic Monkeys\Five Minutes\i-wanna-be-yours.mp3"),
                        Genre = genreModels[0],
                        PlayList = playListModels[1]
                    },
                    new TrackModel
                    {
                        TrackName = "Daframe2r",
                        Singer = singerModels[0],
                        File = File.ReadAllBytes(pathMusicFiles + @"Arctic Monkeys\Matador\daframe2r.mp3"),
                        Genre = genreModels[0],
                        PlayList = playListModels[2]
                    },
                    new TrackModel
                    {
                        TrackName = "I want it all",
                        Singer = singerModels[0],
                        File = File.ReadAllBytes(pathMusicFiles + @"Arctic Monkeys\Matador\i-want-it-all.mp3"),
                        Genre = genreModels[0],
                        PlayList = playListModels[2]
                    },
                    new TrackModel
                    {
                        TrackName = "Matador",
                        Singer = singerModels[0],
                        File = File.ReadAllBytes(pathMusicFiles + @"Arctic Monkeys\Matador\matador.mp3"),
                        Genre = genreModels[0],
                        PlayList = playListModels[2]
                    },
                    new TrackModel
                    {
                        TrackName = "Electricity",
                        Singer = singerModels[0],
                        File = File.ReadAllBytes(pathMusicFiles + @"Arctic Monkeys\R U Mine\electricity.mp3"),
                        Genre = genreModels[0],
                        PlayList = playListModels[3]
                    },
                    new TrackModel
                    {
                        TrackName = "Mad sounds",
                        Singer = singerModels[0],
                        File = File.ReadAllBytes(pathMusicFiles + @"Arctic Monkeys\R U Mine\mad-sounds.mp3"),
                        Genre = genreModels[0],
                        PlayList = playListModels[3]
                    },
                    new TrackModel
                    {
                        TrackName = "R U mine",
                        Singer = singerModels[0],
                        File = File.ReadAllBytes(pathMusicFiles + @"Arctic Monkeys\R U Mine\r-u-mine.mp3"),
                        Genre = genreModels[0],
                        PlayList = playListModels[3]
                    },
                    new TrackModel
                    {
                        TrackName = "Evil twin",
                        Singer = singerModels[0],
                        File = File.ReadAllBytes(pathMusicFiles + @"Arctic Monkeys\Suck It And See\evil-twin.mp3"),
                        Genre = genreModels[0],
                        PlayList = playListModels[4]
                    },
                    new TrackModel
                    {
                        TrackName = "Suck it and see",
                        Singer = singerModels[0],
                        File = File.ReadAllBytes(pathMusicFiles + @"Arctic Monkeys\Suck It And See\suck-it-and-see.mp3"),
                        Genre = genreModels[0],
                        PlayList = playListModels[4]
                    },
                    new TrackModel
                    {
                        TrackName = "Knee socks",
                        Singer = singerModels[0],
                        File = File.ReadAllBytes(pathMusicFiles + @"Arctic Monkeys\Suck It And See\knee-socks.mp3"),
                        Genre = genreModels[0],
                        PlayList = playListModels[4]
                    },
                };

                foreach (var item in trackModels)
                {
                    context.Tracks.Add(item);
                    context.SaveChanges();
                }

                Console.WriteLine("Import Done");
                Console.ReadLine();
            }
        }
    }
}
