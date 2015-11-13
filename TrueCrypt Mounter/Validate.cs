using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TrueCrypt_Mounter
{
    static class Validate
    {
        /// <summary>
        /// Validate the mainsettings.
        /// </summary>
        /// <returns> 
        /// true = mainsettings is done.
        /// false = mainsettings is not done.
        /// </returns>
        public static bool ValidateConfig()
        {
            Boolean status = true;
            var config = new Config();
            config = Singleton<ConfigManager>.Instance.Init(config);
            const string sectionGrundeinstellung = "Grundeinstellungen";
            const string nameDriveletter = "Driveletter";
            const string nameKontainerpath = "Kontainerpath";
            const string nameNokeyfile = "Nokeyfile";
            const string nameReadonly = "Readonly";
            const string nameRemovable = "Removable";
            const string nameSilentmode = "Silentmode";
            const string nameTruecryptpath = "Truecryptpath";
            const string namePasswordcache = "Passwordcache";

            //Test if the minimal config is done
            if (!config.HasEntry(sectionGrundeinstellung, nameTruecryptpath))
                status = false;
            if (!config.HasEntry(sectionGrundeinstellung, nameNokeyfile))
                status = false;
            if (!config.HasEntry(sectionGrundeinstellung, nameSilentmode))
                status = false;
            if (!config.HasEntry(sectionGrundeinstellung, namePasswordcache))
                status = false;

            //Test if the config is done for the keyfilekontainer.
            if (!config.GetValue(sectionGrundeinstellung, nameNokeyfile, false))
            {
                if (!config.HasEntry(sectionGrundeinstellung, nameKontainerpath))
                    status = false;
                if (!config.HasEntry(sectionGrundeinstellung, nameDriveletter))
                    status = false;
                if (!config.HasEntry(sectionGrundeinstellung, nameReadonly))
                    status = false;
                if (!config.HasEntry(sectionGrundeinstellung, nameRemovable))
                    status = false;
            }

            return status;
        }
    }
}
