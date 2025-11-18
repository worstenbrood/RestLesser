using RestLesser.Examples.TvMaze.Models;

namespace RestLesser.Examples.TvMaze
{
    public class TvMazeClient : RestClient
    {
        public TvMazeClient() : base("https://api.tvmaze.com")
        { 
        }

        public Show GetShow(int id)
        {
            return Get<Show>($"/shows/{id}");
        }
    }
}
