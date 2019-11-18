using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace WebSearcher.Data
{
    public static class DataContext
    {
        public static List<WebSite> WebSites { get; private set; }
        public static List<SearchPoint> SearchPoints { get; private set; }
        public static List<string> Keywords { get; private set; }

        private readonly static string directory = AppDomain.CurrentDomain.BaseDirectory;
        private readonly static string webSitesFilePath = directory + @"\WebSites.txt";
        private readonly static string searchPointsFilePath = directory + @"\SearchPoints.txt";
        private readonly static string keywordsFilePath = directory + @"\Keywords.txt";

        public static void Load()
        {
            WebSites = new List<WebSite>();
            SearchPoints = new List<SearchPoint>();
            Keywords = new List<string>();

            LoadFromFile();
        }

        private static void LoadFromFile()
        {
            try
            {
                CheckFiles();

                string webSitesJson = File.ReadAllText(webSitesFilePath);
                if (webSitesJson != "")
                {
                    List<WebSite> webSites = JsonConvert.DeserializeObject<List<WebSite>>(webSitesJson);

                    if (webSites != null)
                        WebSites = webSites;
                }

                string searchPointsJson = File.ReadAllText(searchPointsFilePath);
                if (searchPointsJson != "")
                {
                    List<SearchPoint> searchPoints = JsonConvert.DeserializeObject<List<SearchPoint>>(searchPointsJson);

                    if (searchPoints != null)
                        SearchPoints = searchPoints;
                }

                string keywordsJson = File.ReadAllText(keywordsFilePath);
                if (keywordsJson != "")
                {
                    List<string> keywords = JsonConvert.DeserializeObject<List<string>>(keywordsJson);

                    if (keywords != null)
                        Keywords = keywords;
                }
            }
            catch (JsonSerializationException e)
            {
                throw e;
            }
            catch (IOException e)
            {
                throw e;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public static void Save()
        {
            try
            {
                string webSitesJson = WebSites.Count <= 0 ? "" : JsonConvert.SerializeObject(WebSites);
                string searchPointsJson = SearchPoints.Count <= 0 ? "" : JsonConvert.SerializeObject(SearchPoints);
                string keywordsJson = Keywords.Count <= 0 ? "" : JsonConvert.SerializeObject(Keywords);

                CheckFiles();
                File.WriteAllText(webSitesFilePath, String.Empty);
                File.WriteAllText(webSitesFilePath, webSitesJson);

                File.WriteAllText(searchPointsFilePath, String.Empty);
                File.WriteAllText(searchPointsFilePath, searchPointsJson);

                File.WriteAllText(keywordsFilePath, String.Empty);
                File.WriteAllText(keywordsFilePath, keywordsJson);
            }
            catch (JsonSerializationException e)
            {
                throw e;
            }
            catch (IOException e)
            {
                throw e;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        private static void CheckFiles()
        {
            try
            {
                if (!File.Exists(webSitesFilePath))
                    File.Create(webSitesFilePath);

                if (!File.Exists(searchPointsFilePath))
                    File.Create(searchPointsFilePath);

                if (!File.Exists(keywordsFilePath))
                    File.Create(keywordsFilePath);
            }
            catch (JsonSerializationException e)
            {
                throw e;
            }
            catch (IOException e)
            {
                throw e;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public static void AddKeyword(string keyword)
        {
            keyword = keyword.ToLower().Trim();

            if (!Keywords.Any(a => a == keyword))
            {
                Keywords.Add(keyword);
            }
        }

        public static string TakeKeyword()
        {
            string txt = "";

            if (Keywords.Count > 0)
            {
                txt = Keywords.First();
                Keywords.Remove(txt);
            }

            return txt;
        }

        public static void RemoveKeyword(string keyword)
        {
            keyword = keyword.ToLower().Trim();

            if (Keywords.Any(a => a == keyword))
            {
                Keywords.Remove(keyword);
            }
        }

        public static void AddWebSite(string name, string url)
        {
            WebSites.Add(new WebSite() { Id = Guid.NewGuid(), Name = name, Url = url });
        }

        public static void AddSearchPoint(string urlParameters, Guid webSiteId)
        {
            SearchPoints.Add(new SearchPoint() { Id = Guid.NewGuid(), CheckDate = null, Price = 0, UrlParameters = urlParameters, WebSiteId = webSiteId });
        }
    }
}
