using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class SaveSystem
{
    public static class SaveGameBase
    {
        public static bool CkeckSaveGameBaseIsCreated(){
            if(FileBasedPrefs.HasKey("Save Game Exist")){
                return(true);
            }
            else{
                return(false);
            }
        }
        public static void CreateSaveGameBase(){
            SaveKeys.NormalKeys.SaveInt("Save Game Exist", 1);

            SaveKeys.NormalKeys.SaveFloat("Soundtrack Volume", 1.0f);
            SaveKeys.NormalKeys.SaveFloat("Sound Effects Volume", 1.0f);

            SaveKeys.NormalKeys.SaveInt("Level To Open", 0);
            SaveKeys.NormalKeys.SaveInt("Maximum Level", 0);

            SaveKeys.NormalKeys.SaveInt("Graphics", 4);

        }
        public static void DeleteSaveGameBase(){
            FileBasedPrefs.DeleteAll();
        }
    }
    
    public static class SaveValue
    {
        public static void SoundtrackVolume(float Value){ SaveKeys.NormalKeys.SaveFloat("Soundtrack Volume", Value); }
        public static void SoundEffectsVolume(float Value){ SaveKeys.NormalKeys.SaveFloat("Sound Effects Volume", Value); }
        
        public static void LevelToOpen(int Value){ SaveKeys.NormalKeys.SaveInt("Level To Open", Value); }
        public static void MaximumLevel(int Value){ SaveKeys.NormalKeys.SaveInt("Maximum Level", Value); }

        public static void Graphics(int Value){ SaveKeys.NormalKeys.SaveInt("Graphics", Value); }
    }

    public static class LoadValue
    {
        public static float SoundtrackVolume(){ return SaveKeys.NormalKeys.LoadFloat("Soundtrack Volume"); }
        public static float SoundEffectsVolume(){ return SaveKeys.NormalKeys.LoadFloat("Sound Effects Volume"); }

        public static int LevelToOpen(){ return SaveKeys.NormalKeys.LoadInt("Level To Open"); }
        public static int CurrentLevel(){ return SaveKeys.NormalKeys.LoadInt("Level To Open"); }
        public static int MaximumLevel(){ return SaveKeys.NormalKeys.LoadInt("Maximum Level"); }

        public static int Graphics(){ return SaveKeys.NormalKeys.LoadInt("Graphics"); }
    }
}

