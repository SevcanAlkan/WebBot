using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace WebSearcher.Data
{
    public static class KeywordContext
    {
        public static List<string> Keywords { get; private set; }

        private readonly static string directory = AppDomain.CurrentDomain.BaseDirectory;
        private readonly static string keywordsFilePath = directory + @"\Keywords.txt";

        public static void Load()
        {
            Keywords = new List<string>();

            LoadFromFile();
        }

        private static void LoadFromFile()
        {
            try
            {
                CheckFiles();
                
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
                string keywordsJson = Keywords.Count <= 0 ? "" : JsonConvert.SerializeObject(Keywords);

                CheckFiles();
                

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

    }
}
