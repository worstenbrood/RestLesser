using System.Net;
using RestLesser.Authentication;
using RestLesser.DataAdapters;
using RestLesser.Examples.TeamCity.Models;

namespace RestLesser.Examples.TeamCity
{
    public class TeamCityClient : RestClient
    {
        private TeamCityClient(string url, IAuthentication authentication) : base(url, authentication,
            new HttpClientHandler
            {
                CookieContainer = new CookieContainer(),
                UseCookies = true
            },
            new XmlAdapter())
        {
            Client.Timeout = TimeSpan.FromMinutes(5.0);
        }

        public TeamCityClient(string url, string token) : this(url, new TeamCityAuthentication(url, token))
        {
        }

        /// <summary>
        /// Trigger a <see cref="Build"/>
        /// </summary>
        /// <param name="build"></param>
        /// <returns></returns>
        public Build TriggerBuild(Build build)
        {
            return Post<Build, Build>("httpAuth/app/rest/buildQueue?moveToTop=true", build);
        }

        /// <summary>
        /// Fetch a <see cref="Build"/> by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Build FetchBuild(int id)
        {
            string path = string.Format("httpAuth/app/rest/builds/id:{0}", id);
            return Get<Build>(path);       
        }

        /// <summary>
        /// Get latest buil id for a given build type
        /// </summary>
        /// <param name="buildType"></param>
        /// <returns></returns>
        public int GetLatestBuildId(string buildType)
        {
            return Get<int>($"httpAuth/app/rest/buildTypes/{buildType}/builds/status:success/id");
        }

        /// <summary>
        /// Fetch an artifact from the given build
        /// </summary>
        /// <param name="id"></param>
        /// <param name="artifact"></param>
        /// <param name="accept"></param>
        /// <param name="output"></param>
        public void FetchTextArtifact(int id, string artifact, string accept, Stream output)
        {
            GetFile($"httpAuth/app/rest/builds/id:{id}/artifacts/content/{artifact}", output, accept);
        }

        /// <summary>
        /// Get artifact from the latest build of <paramref name="buildType"/>
        /// </summary>
        /// <param name="buildType"></param>
        /// <param name="artifact"></param>
        /// <param name="accept"></param>
        /// <param name="output"></param>
        public void GetLatestArtifact(string buildType, string artifact, string accept, Stream output)
        {
            var buildId = GetLatestBuildId(buildType);
            FetchTextArtifact(buildId, artifact, accept, output);
        }

        /// <summary>
        /// Get artifact from the latest build of <paramref name="buildType"/>,
        /// streamed to memory.
        /// </summary>
        /// <param name="buildType"></param>
        /// <param name="artifact"></param>
        /// <param name="accept"></param>
        /// <returns></returns>
        public MemoryStream GetLatestArtifact(string buildType, string artifact, string accept)
        {
            var buildId = GetLatestBuildId(buildType);
            var output = new MemoryStream();
            FetchTextArtifact(buildId, artifact, accept, output);
            return output;
        }
    }
}
