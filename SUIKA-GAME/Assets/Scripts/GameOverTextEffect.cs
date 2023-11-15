using System.Collections;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.EventSystems;

public class GameOverTextEffect : MonoBehaviour
{
    private Text flashingText; // ����Ƽ����UI�� ������ Ŭ���� Text�� ȣ���Ͽ� flashingText�� ������
    
    private void Start()
    {
        flashingText = GetComponent<Text>(); // flashingText�� �ؽ�Ʈ ������Ʈ�� �ҷ��´�
        StartCoroutine(BlinkText()); // BlinkText�޼ҵ带 ȣ���Ͽ� �ʱ�ȭ�Ѵ�
    }

    public IEnumerator BlinkText()
    {
        while (true) // ������ �ݺ��ϱ� ���� while�� ���
        {
            flashingText.text = ""; // �ؽ�Ʈ�� ������ ��Ÿ����
            yield return new WaitForSeconds(0.3f); //0.3�� �� ����Ѵ�
            flashingText.text = "GAME OVER"; // �ؽ�Ʈ�� GAME OVER�� ��Ÿ����
            yield return new WaitForSeconds(0.3f); // 0.3�� �� ����Ѵ�
        }
    }
}
