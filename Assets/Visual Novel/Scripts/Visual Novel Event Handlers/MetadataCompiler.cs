using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MetadataCompiler : MonoBehaviour {
    public MetadataObject CompileMetadata(string metadata)
    {
        MetadataObject mo = (MetadataObject)ScriptableObject.CreateInstance(typeof(MetadataObject));
        foreach (string obj in metadata.Split(','))
        {
            string noSpaces = obj.Replace(" ", "");
            noSpaces = noSpaces.Replace("{", "").Replace("}", "");
            string metaTag = noSpaces.Substring(0, noSpaces.IndexOf(":"));
            string startOfValue = obj.Substring(obj.IndexOf("\"") + 1);
            string metaValue = startOfValue.Substring(0, startOfValue.IndexOf("\""));
            mo = GetSpecificData(metaTag, metaValue, mo);
        }
        return mo;
    }
    private MetadataObject GetSpecificData(string metaTag, string metaValue, MetadataObject mo)
    {
        switch (metaTag.ToLower())
        {
            case "name":
                mo.SetName(metaValue);
                break;
            case "voice":
                mo.SetVoice(metaValue);
                break;
            case "speed":
                mo.SetSpeed(float.Parse(metaValue));
                break;
        }
        return mo;
    }
}
