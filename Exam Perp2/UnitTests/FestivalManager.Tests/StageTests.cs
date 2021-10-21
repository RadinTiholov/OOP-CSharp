// Use this file for your unit tests.
// When you are ready to submit, REMOVE all using statements to Festival Manager (entities/controllers/etc)
// Test ONLY the Stage class. 
namespace FestivalManager.Tests
{
    using FestivalManager.Entities;
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;
    using System.Linq;

	[TestFixture]
	public class StageTests
	{
		private Stage stage;
		[SetUp]
		public void Init()
		{
			stage = new Stage();
		}
		[Test]
		public void CtorWorksProperly()
		{
			Assert.That(stage.Performers.Count, Is.EqualTo(0));
		}
		[Test]
		public void AddPerformerWorksCorrectly()
		{
			Performer performer = new Performer("Gosho", "Ivanov", 23);
			Performer performer1 = new Performer("Goshoasd", "Ivanov1", 43);
			stage.AddPerformer(performer);
			stage.AddPerformer(performer1);
			Assert.That(stage.Performers.Count, Is.EqualTo(2));
		}
		[Test]
		public void AddPerformerThrowsExceptionWhenUnderEighteen()
		{
			Performer performer = new Performer("Gosho", "Ivanov", 17);
			Assert.That(() => stage.AddPerformer(performer), Throws.ArgumentException);
		}
		[Test]
		public void AddPerformerThrowsExceptionWhenNull()
		{
			Performer performer = null;
			Assert.That(() => stage.AddPerformer(performer), Throws.ArgumentNullException);
		}
		[Test]
		public void AddSongThrowsExceptionWhenNull()
		{
			Song song = null;
			Assert.That(() => stage.AddSong(song), Throws.ArgumentNullException);
		}
		[Test]
		public void AddSongThrowsExceptionWhenunderAMinute()
		{
			Song song = new Song("super", new TimeSpan(0, 0, 40));
			Assert.That(() => stage.AddSong(song), Throws.ArgumentException);
		}
		[Test]
		public void AddSongWorksCorrectly()
		{
			Song song = new Song("super", new TimeSpan(0, 2, 40));
			Song song1 = new Song("bomba", new TimeSpan(0, 22, 40));
			stage.AddSong(song);
			stage.AddSong(song1);
			Performer performer = new Performer("Pesho", "Ivanov", 20);
			stage.AddPerformer(performer);
			stage.AddSongToPerformer("super", "Pesho Ivanov");
			stage.AddSongToPerformer("bomba", "Pesho Ivanov");
			List<Performer> performers = stage.Performers.ToList();
			Performer secondPerformer = performers[0];
			Assert.That(secondPerformer.SongList.Count, Is.EqualTo(2));
		}
		[Test]
		public void PlaySongWorksCorrectly()
		{
			Song song = new Song("super", new TimeSpan(0, 2, 40));
			Song song1 = new Song("bomba", new TimeSpan(0, 22, 40));
			stage.AddSong(song);
			stage.AddSong(song1);
			Performer performer = new Performer("Pesho", "Ivanov", 20);
			stage.AddPerformer(performer);
			stage.AddSongToPerformer("super", "Pesho Ivanov");
			stage.AddSongToPerformer("bomba", "Pesho Ivanov");
			string result = stage.Play();
			Assert.That(result, Is.EqualTo("1 performers played 2 songs"));
		}
		[Test]
		public void AddSongToPerformerThrowsExceptionWhenNull()
		{
			Assert.That(() => stage.AddSongToPerformer(null, "asaa"), Throws.ArgumentNullException);
			Assert.That(() => stage.AddSongToPerformer("asd", null), Throws.ArgumentNullException);
		}
		[Test]
		public void AddSongToPerformerWorksCorrectly()
		{
			Song song = new Song("super", new TimeSpan(0, 2, 40));
			Song song1 = new Song("bomba", new TimeSpan(0, 22, 40));
			stage.AddSong(song);
			stage.AddSong(song1);
			Performer performer = new Performer("Pesho", "Ivanov", 20);
			stage.AddPerformer(performer);
			string result = stage.AddSongToPerformer("bomba", "Pesho Ivanov");
			Assert.That(result, Is.EqualTo("bomba (22:40) will be performed by Pesho Ivanov"));
		}
		[Test]
		public void AddSongToPerfomerthrowsExceptionWhenInvalid()
		{
			Assert.That(() =>stage.AddSongToPerformer("adad", "adadd"), Throws.ArgumentException);
		}
		[Test]
		public void AddSongToPerfomerthrowsExceptionWhenInvalidSong()
		{
			Performer performer = new Performer("Pesho", "Ivanov", 20);
			Assert.That(() => stage.AddSongToPerformer("adad", "Pesho Ivanov"), Throws.ArgumentException);
		}
		[Test]
		public void AddSongToPerformerIsOk()
		{
			Song song = new Song("super", new TimeSpan(0, 2, 40));
			Song song1 = new Song("bomba", new TimeSpan(0, 22, 40));
			stage.AddSong(song);
			stage.AddSong(song1);
			Performer performer = new Performer("Pesho", "Ivanov", 20);
			stage.AddPerformer(performer);
			stage.AddSongToPerformer("super", "Pesho Ivanov");
			stage.AddSongToPerformer("bomba", "Pesho Ivanov");

			List<Performer> performers = stage.Performers.ToList();
			Performer secondPerformer = performers[0];
			int count = secondPerformer.SongList.Count;
			Assert.That(count, Is.EqualTo(2));
		}
	}
}