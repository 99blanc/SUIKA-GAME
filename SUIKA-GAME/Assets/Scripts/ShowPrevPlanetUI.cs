using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ShowPrevPlanetUI : MonoBehaviour
{
    public static Image preview; // �̹��� ��������Ʈ�� ȭ�鿡 �����ֱ� ���� �̹��� ����

    private Text blinkingText; // ����Ƽ ���� UI�� ������ Ŭ���� Text�� ȣ���Ͽ� blinkingText�� ����

    private void Start() // ��ŸƮ �޼ҵ�
    {
        OnBlinkText(); // ��ũ �ؽ�Ʈ ȣ�� �޼ҵ�
    }

    public void OnBlinkText() // ��ũ �ؽ�Ʈ ȣ�� �޼ҵ�
    {
        preview = GetComponentInParent<Image>();
        blinkingText = GetComponent<Text>(); // ��ũ �ؽ�Ʈ ������Ʈ �ؽ�Ʈ ����
        StartCoroutine(BlinkText()); // ��ũ �ؽ�Ʈ �ڷ�ƾ ȣ��
    }

    public IEnumerator BlinkText() // ��ũ �ؽ�Ʈ �ڷ�ƾ ȣ��
    {
        while (true) // ���� �ݺ�
        {
            blinkingText.text = "P      "; // �ؽ�Ʈ�� ������ ��Ÿ����
            yield return new WaitForSeconds(0.3f); //0.3�� �� �簳�Ѵ�

            blinkingText.text = "  R    "; // �ؽ�Ʈ�� ������ ��Ÿ����
            yield return new WaitForSeconds(0.3f); //0.3�� �� �簳�Ѵ�

            blinkingText.text = "    E  "; // �ؽ�Ʈ�� ������ ��Ÿ����
            yield return new WaitForSeconds(0.3f); //0.3�� �� �簳�Ѵ�

            blinkingText.text = "      V"; // �ؽ�Ʈ�� ������ ��Ÿ����
            yield return new WaitForSeconds(0.3f); //0.3�� �� �簳�Ѵ�

            blinkingText.text = "PREV"; // �ؽ�Ʈ ����
            yield return new WaitForSeconds(0.3f); //0.3�� �� �簳�Ѵ�
        }
    }

    public static void OnSpriteChange(int _index) // ��������Ʈ �̹��� ������ ���� �޼ҵ�
    {
        preview.sprite = PlanetDatabase.planetSprite[_index]; // _index ���ڸ� �̿��ؼ� PlanetDatabase���� sprite�� ã�´�
    }
}
