namespace Domain
{
    public class Playlist
    {
        public int Id { get; set; }

        public override bool Equals(object obj)
        {
            var result = false;

            if (obj is Playlist category)
            {
                result = this.Id == category.Id;
            }

            return result;
        }
    }
}