using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class SaveKeys
{
    public static class NormalKeys
    {
        public static void SaveFloat(string KeyName, float Value){
            FileBasedPrefs.SetFloat(KeyName, Value);
        }
        public static float LoadFloat(string KeyName){
            return  FileBasedPrefs.GetFloat(KeyName);
        }

        public static void SaveInt(string KeyName, int Value){
            FileBasedPrefs.SetInt(KeyName, Value);
        }
        public static int LoadInt(string KeyName){
            return  FileBasedPrefs.GetInt(KeyName);
        }

        public static void SaveString(string KeyName, string Text){
            FileBasedPrefs.SetString(KeyName, Text);
        }
        public static string LoadString(string KeyName){
            return FileBasedPrefs.GetString(KeyName);
        }
    }
    public class SpecialKeys{
        public static void SaveBool(string KeyName, bool Value)
        {
            if(Value == true){
                FileBasedPrefs.SetInt(KeyName, 1);        
            }
            else{
                FileBasedPrefs.SetInt(KeyName, 0);      
            }
        }

        public static bool LoadBool(string KeyName)
        {
            int aux = FileBasedPrefs.GetInt(KeyName);
            
            if(aux == 1){
                return true;       
            }
            else{
                return false;
            }
        }
    }
}
