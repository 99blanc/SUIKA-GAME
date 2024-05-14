using System.Collections.Generic;
using UnityEngine;

public class PlanetDatabase : MonoBehaviour
{
    public static int[] planetLevel { get; private set; }
    public static int[] planetScore { get; private set; }
    public static string[] planetName { get; private set; }
    public static float[] planetColliderRadius { get; private set; }
    public static Vector3[] planetScale { get; private set; }
    public static Sprite[] planetSprite { get; private set; }
    public static int planetIndex { get; private set; }

    private void Start()
    {
        OnLoadDataSheet();
    }

    private void OnLoadDataSheet()
    {
        List<Dictionary<string, object>> data = CSVReader.Read("DataSheets/PlanetInfoSheet");
        planetIndex = data.Count;

        planetLevel = new int[data.Count];
        planetScore = new int[data.Count];
        planetName = new string[data.Count];
        planetColliderRadius = new float[data.Count];
        planetScale = new Vector3[data.Count];
        planetSprite = new Sprite[data.Count];

        for (int i = 0; i < data.Count; ++i)
        {
            planetLevel[i] = int.Parse(data[i]["Level"].ToString());
            planetScore[i] = int.Parse(data[i]["Score"].ToString());
            planetName[i] = (string)data[i]["Name"].ToString();
            planetColliderRadius[i] = float.Parse(data[i]["ColliderRadius"].ToString());
            planetScale[i] = new Vector3(float.Parse(data[i]["ScaleX"].ToString()), float.Parse(data[i]["ScaleX"].ToString()), 1.0f);
            planetSprite[i] = Resources.Load<Sprite>((string)data[i]["ImageResource"].ToString());
        }
    }
}
