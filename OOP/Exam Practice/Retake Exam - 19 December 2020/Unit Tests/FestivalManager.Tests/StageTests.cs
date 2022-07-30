// Use this file for your unit tests.
// When you are ready to submit, REMOVE all using statements to Festival Manager (entities/controllers/etc)
// Test ONLY the Stage class. 

using FestivalManager.Entities;

namespace FestivalManager.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
	public class StageTests
    {
		[Test]
	    public void AddPerformerMethodShouldThrowExceptionIfPerformerAgeUnder18()
	    {
			Stage stage = new Stage();

            Assert.Throws<ArgumentException>(() => stage.AddPerformer(new Performer("Lady", "Gaga", 17)));
        }

        [Test]
        public void AddPerformerMethodShouldAddPerformersToList()
        {
            Stage stage = new Stage();
            stage.AddPerformer(new Performer("Lady", "Gaga", 18));

            Assert.AreEqual(1, stage.Performers.Count);
        }

        [Test]
        public void AddSongMethodShouldThrowExceptionIfSongIsLessThanOneMinute()
        {
            Stage stage = new Stage();
            Song song = new Song("Hey Jude", new TimeSpan(0, 0, 0, 59));

            Assert.Throws<ArgumentException>(() => stage.AddSong(song));
        }

        //[Test]
        //public void AddSongMethodShouldAddSongToList()
        //{
        //    Stage stage = new Stage();
        //    Song song = new Song("Hey Jude", new TimeSpan(0, 0, 3, 49));
        //}

        [Test]
        public void AddSongToPerformerShouldAddSongToPerformerSongList()
        {
            Stage stage = new Stage();
            Performer performer = new Performer("Lady", "Gaga", 27);
            Song song = new Song("Hey Jude", new TimeSpan(0, 0, 3, 59));

            stage.AddPerformer(performer);
            stage.AddSong(song);
            performer.SongList.Add(song);
            string message = stage.AddSongToPerformer("Hey Jude", "Lady Gaga");

            Assert.AreEqual($"Hey Jude (03:59) will be performed by Lady Gaga", message);
        }

        [Test]
        public void PlayMethodShouldReturnCountOfPerformersAndSongs()
        {
            Stage stage = new Stage();

            Performer performer1 = new Performer("Lady", "Gaga", 27);
            Performer performer2 = new Performer("The", "Beatles", 38);

            Song song1 = new Song("Hey Jude", new TimeSpan(0, 0, 3, 59));
            Song song2 = new Song("Yellow Submarine", new TimeSpan(0, 0, 3, 15));
            Song song3 = new Song("Shallow", new TimeSpan(0, 0, 4, 3));

            stage.AddPerformer(performer1);
            stage.AddPerformer(performer2);

            stage.AddSong(song1);
            stage.AddSong(song2);
            stage.AddSong(song3);

            performer1.SongList.Add(song3);
            performer2.SongList.Add(song1);
            performer2.SongList.Add(song2);
            
            string message = stage.Play();

            Assert.AreEqual($"2 performers played 3 songs", message);
        }

        [Test]
        public void GetPerformerShouldThrowExceptionIfPerformerNotInList()
        {
            Stage stage = new Stage();

            Performer performer1 = new Performer("Lady", "Gaga", 27);
            Song song1 = new Song("Hey Jude", new TimeSpan(0, 0, 3, 59));

            stage.AddPerformer(performer1);
            stage.AddSong(song1);

            Assert.Throws<ArgumentException>(() => stage.AddSongToPerformer("Hey Jude", "The Beatles"));

        }

        [Test]
        public void GetSongShouldThrowExceptionIfSongNotInList()
        {
            Stage stage = new Stage();

            Performer performer1 = new Performer("Lady", "Gaga", 27);

            stage.AddPerformer(performer1);

            Assert.Throws<ArgumentException>(() => stage.AddSongToPerformer("Hey Jude", "Lady Gaga"));
        }

        [Test]
        public void ValidateNullValueShouldThrowExceptionIfObjectNotInstanatiated()
        {
            Stage stage = new Stage();
            Performer performer = null;

            Assert.Throws<ArgumentNullException>(() => stage.AddPerformer(performer));
        }
    }
}