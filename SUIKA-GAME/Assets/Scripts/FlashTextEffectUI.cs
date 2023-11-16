using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class FlashTextEffectUI : MonoBehaviour
{
    private Text flashingText; // ����Ƽ ����UI�� ������ Ŭ���� Text�� ȣ���Ͽ� flashingText�� ����
    
    private void Start() // ��ŸƮ �޼ҵ�
    {
        OnFlashText(); // �÷��� �ؽ�Ʈ ȣ�� �޼ҵ�
    }

    private void OnFlashText() // �÷��� �ؽ�Ʈ ȣ�� �޼ҵ�
    {
        flashingText = GetComponent<Text>(); // flashingText�� �ؽ�Ʈ ������Ʈ�� �ҷ��´�
        StartCoroutine(FlashText()); // FlashText �޼ҵ带 ȣ���Ͽ� �ʱ�ȭ�Ѵ�
    }

    public IEnumerator FlashText() // �ؽ�Ʈ ������ ȿ���� �ο��ϱ� ���� �ڷ�ƾ �޼ҵ�
    {
        while (true) // ������ �ݺ��ϱ� ���� while�� ���
        {
            flashingText.text = ""; // �ؽ�Ʈ�� ������ ��Ÿ����

            yield return new WaitForSeconds(0.3f); //0.3�� �� �簳�Ѵ�

            flashingText.text = "GAME OVER"; // �ؽ�Ʈ�� GAME OVER�� ��Ÿ����

            yield return new WaitForSeconds(0.3f); // 0.3�� �� �簳�Ѵ�
        }
    }
}
