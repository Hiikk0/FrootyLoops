using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Octokit;
using System.Net.Http.Headers;
using System.Diagnostics;
using System.Net;
using System.IO;
using System.Net.Http;
using System.Threading;

namespace FrootyLoops.Services
{
    public class UpdateManager
    {
        private readonly GitHubClient _client;
        private readonly string _currentVersion;
        public static Version? _lastestVersion;

        public UpdateManager(string currentVersion)
        {
            _client = new GitHubClient(new Octokit.ProductHeaderValue("FrootyLoops")) { Credentials = new Credentials(File.ReadAllText(App.STDPATH + "/Data/Info/Config.txt")) };
            _currentVersion = currentVersion;
        }

        public async Task CheckForUpdatesAsync(string owner, string repo, bool download)
        {
            var release = await _client.Repository.Release.GetLatest(owner, repo);
            Version.TryParse(release.TagName, out _lastestVersion);
            if (download && Version.TryParse(release.TagName, out var _latestVersion) &&
                Version.TryParse(_currentVersion, out var currentVersion) &&
                _latestVersion > currentVersion)
            {
                await DownloadLatestReleaseAsync(release, owner, repo);
            }
        }

        private async Task DownloadLatestReleaseAsync(Release release, string owner, string repo)
        {
            using (var client = new System.Net.Http.HttpClient())
            {
                var credentials = string.Format(System.Globalization.CultureInfo.InvariantCulture, "{0}:", "");
                credentials = Convert.ToBase64String(System.Text.Encoding.ASCII.GetBytes(credentials));
                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", credentials);
                foreach (var asset in release.Assets)
                {
                    if (asset.Name.EndsWith("setup.exe"))
                    {
                        var contents = await client.GetByteArrayAsync(asset.BrowserDownloadUrl);
                        System.IO.File.WriteAllBytes(Path.Combine(Path.GetTempPath(), asset.Name), contents);
                    }
                    if (asset.Name.EndsWith("FL.Setup.msi"))
                    {
                        var contents = await client.GetByteArrayAsync(asset.BrowserDownloadUrl);
                        System.IO.File.WriteAllBytes(Path.Combine(Path.GetTempPath(), asset.Name), contents);
                    }
                }
                if (File.Exists(Path.Combine(Path.GetTempPath(), "setup.exe")) && File.Exists(Path.Combine(Path.GetTempPath(), "FL.Setup.msi")))
                {
                    Process.Start(Path.Combine(Path.GetTempPath(), "setup.exe"));
                    Environment.Exit(0);
                }
            }
        }
    }
}
