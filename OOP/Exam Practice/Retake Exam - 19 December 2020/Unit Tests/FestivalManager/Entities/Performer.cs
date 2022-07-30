namespace FestivalManager.Entities
{
	using System.Collections.Generic;

	public class Performer
	{

		public Performer(string firstName, string lastName, int age)
		{
			this.FirstName = firstName;
			this.LastName = lastName;
			this.Age = age;

			this.SongList = new List<Song>();
		}

        private string FirstName { get; }
		private string LastName { get; }

		public string FullName => FirstName + " " + LastName;

		public int Age { get; }
        public List<Song> SongList { get; }

        public override string ToString()
		{
			return this.FullName;
		}
	}
}
