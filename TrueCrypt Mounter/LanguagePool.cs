using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Web;
using System.Web.Caching;
using System.Xml;

namespace VeraCrypt_Mounter
{
    internal class LanguagePool
    {
        #region Variables


        // Konstanten
        private const string CacheKey = "LanguagePool";
        private const string XmlRootnode = "LanguagePool/Region";
        private static Config _config = new Config();

        private readonly Hashtable _regions = new Hashtable();

        #endregion

        #region Property: DefaultLanguage

        /// <summary>
        /// Standardsprache (aus Config-Datei)
        /// </summary>
        public static string DefaultLanguage
        {
            get { return _config.GetValue("Grundeinstellungen", "Defaultlanguage", "E"); }
        }

        #endregion

        #region Property: SourceFile

        /// <summary>
        /// Physischer Pfad zur Xml-Datei (aus Config-Datei)
        /// </summary>
        public static string SourceFile
        {
            get { return _config.GetValue("Grundeinstellungen", "Languagefile", ""); }
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Privater Konstruktor
        /// </summary>
        private LanguagePool()
        {
            _config = Singleton<ConfigManager>.Instance.Init(_config);
        }

        #endregion

        #region Methods: GetInstance (Singleton-Pattern)

        /// <summary>
        /// Liefert eine Instanz von StringPool (Singleton)
        /// </summary>
        /// <returns></returns>
        public static LanguagePool GetInstance()
        {
            // Erstelle Cache-Objekt je nach Plattform (Web- / Winform)
            Cache myCache = HttpContext.Current == null ? HttpRuntime.Cache : HttpContext.Current.Cache;

            // Prüfe ob Cache leer ist
            if (myCache[CacheKey] == null)
            {
                // Erstelle StringPool-Instanz und lade Strings
                var st = new LanguagePool();
                st.LoadStrings();

                // Cache neu füllen
                myCache.Insert(
                    CacheKey, st, new CacheDependency(SourceFile));
            }

            // Gebe StringPool-Objekt aus Cache zurück
            return (LanguagePool) myCache[CacheKey];
        }

        #endregion

        #region Methods: LoadSourceFile

        /// <summary>
        /// Lädt die XML-Source-Datei in ein XmlDocument-Objekt
        /// </summary>
        /// <param name="file">Pfad zur Source-Datei</param>
        /// <returns>XmlDocument</returns>
        private static XmlDocument LoadSourceFile(string file)
        {
            // Load the xml-file in a xml-document
            var xDoc = new XmlDocument();

            try
            {
                xDoc.Load(file);
            }
            catch (FileNotFoundException)
            {
                throw new Exception("Xml-File " + file + " wurde nicht gefunden");
            }
            catch (Exception ex)
            {
                throw new Exception("Allgemeiner Fehler beim Laden von " + file + ": " + ex.Message);
            }

            return xDoc;
        }

        #endregion

        #region Methods: LoadStrings

        /// <summary>
        /// Lädt die Strings aus dem XmlFile in das Datenmodel mit den verschachtelten Dictionaries
        /// </summary>
        public void LoadStrings()
        {
            // Regions-Hashtable leeren
            _regions.Clear();

            // XML-File laden
            XmlDocument xDoc = LoadSourceFile(SourceFile);

            // XML-Daten lesen
            try
            {
                // Durch Region-Nodes iterieren
                if (xDoc != null)
// ReSharper disable PossibleNullReferenceException
                    foreach (XmlNode regionNode in xDoc.SelectNodes(XmlRootnode))
// ReSharper restore PossibleNullReferenceException
                    {
                        var strs = new Hashtable();

                        // Durch Text-Nodes in aktuellem Region-Node iterieren
                        foreach (XmlNode textNode in regionNode.ChildNodes)
                        {

                            var texts = new StringDictionary();
                            // Durch Text-Elemente iterieren und diese in eine Hashtable speichern
                            foreach (XmlNode txt in textNode.ChildNodes)
                            {
                                try
                                {
                                    texts.Add(txt.Name, txt.InnerText);
                                }
                                catch (Exception x)
                                {
                                    throw new Exception("HIER:" + txt.InnerText + x.Message);
                                }
                                
                            }
                            try
                            {
                                strs.Add(textNode.Attributes["key"].Value, texts);
                            }
                            catch (Exception x)
                            {
                                throw new Exception("HIER:" + texts.Keys.ToString() + texts.Values.ToString() + x.Message);
                            }
                            // StringDictionary mit Text-Elementen in übergeordnetes HashTable-Item speichern
                            
                        }

                        _regions.Add(regionNode.Attributes["name"].Value, strs);
                    }
            }
            catch (Exception ex)
            {
                throw new Exception("Fehler beim einlesen des Xml-Files "+ SourceFile + ": " + ex.Message);
            }
        }

        #endregion

        #region Methods: GetString

        /// <summary>
        /// Liefert den gewünschten String abhängig vom Key in der gewünschhten Sprache
        /// </summary>
        /// <param name="region">Bestimmt den Namen der gesuchten Region</param>
        /// <param name="key">Key des String-Eintrags</param>
        /// <param name="language">Sprache</param>
        /// <returns>String</returns>
        public string GetString(string region, string key, string language)
        {
            string text;

            // Lese Text mit den gegebenen Parametern region, key und language
            try
            {
                // Prüfen ob Regions vorhanden sind
                if (_regions.Count > 0)
                {
                    //  Prüfen ob angeforderte Region vorhanden ist
                    if (_regions[region] != null)
                    {
                        // Prüfen ob gewählte Sprache vorhanden ist;
                        // ansonsten wird die Default-Sprache verwendet
                        if (((StringDictionary) ((Hashtable) _regions[region])[key]).ContainsKey(language))
                            text = ((StringDictionary) ((Hashtable) _regions[region])[key])[language];
                        else
                            text = ((StringDictionary) ((Hashtable) _regions[region])[key])[DefaultLanguage];

                        return text;
                    }
                    throw new Exception(string.Format(
                                            "Region {0} ist nicht vorhanden", region));
                }
                return "";
            }
                // Fehlerbehandlung
            catch (Exception ex)
            {
                throw new Exception("Folgende Parameter ergaben kein Ergebnis im aktuellen Objekt:" +
                                    "Region: " + region + " " +
                                    "Key: " + key + " " +
                                    "Language: " + language +
                                    "Fehlermeldung: " + ex.Message);
            }
        }

        public string GetString(string region, string key)
        {
            return GetString(region, key, DefaultLanguage);
        }

        #endregion

        #region Methods:GetLanguage

        /// <summary>
        /// Get the Languages in the xml file
        /// </summary>
        /// <returns>List or null</returns>
        public List<string[]> GetLanguages()
        {
            var languages = new List<string[]>();
            // Lese Text mit den gegebenen Parametern region, key und language
            try
            {
                // Prüfen ob Regions vorhanden sind
                if (_regions.Count > 0)
                {
                    //  Prüfen ob angeforderte Region vorhanden ist
                    if (_regions["Languages"] != null)
                    {
                        //Hashtable table = (Hashtable)_regions["Languages"];
                        // Hole keys in der region "Languages"                        
                        foreach (string key in ((Hashtable) _regions["Languages"]).Keys)
                        {
                            var language = new string[2];
                            language[0] = key;
                            // Hole zugehörigen Buchstaben zur Sprache
                            language[1] = GetString("Languages", key, "E");
                            languages.Add(language);
                        }
                        return languages;
                    }
                    throw new Exception("Region 'Languages' in language.xml nicht vorhanden");
                }
                return null;
            }
                // Fehlerbehandlung
            catch (Exception ex)
            {
                throw new Exception("Fehlermeldung: " + ex.Message);
            }
        }

        #endregion
    }
}