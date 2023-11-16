using System.Collections.Generic;
using UnityEngine;

public class PlanetDatabase : MonoBehaviour
{
    public static int[] planetLevel { get; private set; } 
    // �༺ ������ ���� �迭�� ���� ������ ����, �� �� �� ��ũ��Ʈ������ ���� ������ �����ϰ� �ٸ� ��ũ��Ʈ������ ���� ���� �������� �͸� �����ϴ�
    public static int[] planetScore { get; private set; }
    // ���� �������������� �༺ ������ ���� �迭�� ��´�
    public static string[] planetName { get; private set; }
    // ���� �������������� �༺ �̸��� ���ڿ� ������ ��´�
    public static float[] planetColliderRadius { get; private set; }
    // ���� �������������� �༺ CircleCollider2D�� ���� ���� �Ǽ� �迭�� ��´�
    public static Vector3[] planetScale { get; private set; }
    // ���� �������������� �༺ ũ�� ���� Vector3 �迭�� ��´�
    public static Sprite[] planetSprite { get; private set; }
    // ���� �������������� �༺ �̹��� ��������Ʈ�� ��������Ʈ �迭�� ��´�
    public static int planetIndex { get; private set; }
    // ���� �������������� �༺�� �� ������ ���� ���� ���� ��´�

    private void Start() // ��ŸƮ �޼ҵ�
    {
        OnLoadDataSheet(); // �༺�� ��� ������ ���� ������ ��Ʈ���� �ε��ϴ� �޼ҵ�
    }

    private void OnLoadDataSheet() // �༺�� ��� ������ ���� ������ ��Ʈ���� �ε��ϴ� �޼ҵ�
    {
        List<Dictionary<string, object>> data = CSVReader.Read("DataSheets/PlanetInfoSheet");
        // ����Ʈ ���� ��ųʸ��� �ε��� ���� header (ex) "Level", "Name"���� ����� �ǹ�)�� ��� ���� CSV ������ ��´�
        planetIndex = data.Count; // �༺�� �� ������ ���� ���� ���� ��´�

        planetLevel = new int[data.Count]; // �༺ ������ ���� �迭 ����(ũ��) ����
        planetScore = new int[data.Count]; // �༺ ������ ���� �迭 ����(ũ��) ����
        planetName = new string[data.Count]; // �༺ �̸��� ���� �迭 ����(ũ��) ����
        planetColliderRadius = new float[data.Count]; // �༺ CircleCollider2D�� ���� �迭 ����(ũ��) ����
        planetScale = new Vector3[data.Count]; // �༺ ũ�⿡ ���� �迭 ����(ũ��) ����
        planetSprite = new Sprite[data.Count]; // �༺ �̹��� ��������Ʈ�� ���� �迭 ����(ũ��) ����

        for (var i = 0; i < data.Count; ++i) // �༺�� �� ���� ��ŭ�� �ݺ���
        {
            planetLevel[i] = int.Parse(data[i]["Level"].ToString()); // object�� ���ڿ��� ����ȯ�� �� ������ ����ȯ
            planetScore[i] = int.Parse(data[i]["Score"].ToString()); // object�� ���ڿ��� ����ȯ�� �� ������ ����ȯ
            planetName[i] = (string)data[i]["Name"].ToString();
            // ���ڿ� ����ȯ �Ŀ� ���ڿ� �迭 ������ ��´�
            planetColliderRadius[i] = float.Parse(data[i]["ColliderRadius"].ToString());
            // ���ڿ� ����ȯ �Ŀ� �Ǽ��� ����ȯ �� ������ ��´�
            planetScale[i] = new Vector3(float.Parse(data[i]["ScaleX"].ToString()), float.Parse(data[i]["ScaleX"].ToString()), 1.0f);
            // ���ڿ� ����ȯ �Ŀ� �Ǽ��� ����ȯ �� ������ x, y, z ��ǥ�� ��´�
            planetSprite[i] = Resources.Load<Sprite>((string)data[i]["ImageResource"].ToString());
            // �̹��� ��������Ʈ�� Assets/Resources ��ο� �ִ� �̹��� ��������Ʈ ��θ� ã�� ����ȯ �Ŀ� ������ ��´�
        }
    }
}
