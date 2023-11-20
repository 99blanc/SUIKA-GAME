using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class TextBlinkUI : MonoBehaviour
{
    [SerializeField] private bool isBlinked; // ��ũ Ÿ�� ���θ� �� or ������ �Ҹ��� ������ 
    [SerializeField] private float blinkDelay = 0.6f;

    private Text blinkText; // ����Ƽ ���� UI�� ������ Ŭ���� Text�� ȣ���Ͽ� blinkingText�� ����
    private int count = 0;

    private void Start() // ��ŸƮ �޼ҵ�
    {
        OnBlinkTextInit(); // ��ũ �ؽ�Ʈ ���� �޼ҵ� ȣ��
    }

    private void OnBlinkTextInit() // ��ũ �ؽ�Ʈ ���� �޼ҵ� ȣ��
    {
        blinkText = GetComponent<Text>(); // ��ũ �ؽ�Ʈ�� ������Ʈ�� �����´�
        StartCoroutine(OnBlinkText(isBlinked, blinkText.text));
        // ��Ʈ Ÿ�� ���ο� ��ũ �ؽ�Ʈ ���ڿ��� ���� ������ ������ ��ũ �ؽ�Ʈ �޼ҵ带 ȣ���Ѵ�
    }

    private IEnumerator OnBlinkText(bool _isBlinked, string _text) // ��ũ Ÿ�� ���ο� ��ũ �ؽ�Ʈ ���ڿ��� ���� ������ �޴� ��ũ �ؽ�Ʈ �޼ҵ�
    {
        char[] _textAlphabet = blinkText.text.ToCharArray(); // ��ũ �ؽ�Ʈ ���ڿ��� ĳ���� �� �迭�� �����Ѵ�

        if (_isBlinked) // ��ũ Ÿ�� ���ΰ� ���̶��
        {
            while (true) // ���� �ݺ��� ����
            {
                bool _isChecked = false; // üũ ���� ǥ�ø� �������� �����Ѵ�
                string _blinkText = ""; // ��ũ �ؽ�Ʈ ���ڿ��� �����´�
                blinkText.text = ""; // ��ũ �ؽ�Ʈ�� �� ���ڿ��� �����

                if (count == _textAlphabet.Length) // ī��Ʈ ���� ���� �ؽ�Ʈ ĳ���� �� �迭�� ���̿� ���ٸ�
                {
                    count = 0; // ī��Ʈ ���� ���� 0���� �ʱ�ȭ �Ѵ�
                    blinkText.text = new string(_textAlphabet); // ��ũ �ؽ�Ʈ�� �ؽ�Ʈ�� �����ڸ� �̿��Ͽ� ���ڿ��� �ٲ۴�

                    yield return new WaitForSeconds(blinkDelay); // blinkDelay ��ŭ ���ð��� ���´�

                    continue; // while �ݺ��� �������� �Ʒ� �������� �����ϰ� ����Ѵ�
                }

                for (int i = 0; i < _textAlphabet.Length; ++i) // �ؽ�Ʈ ĳ���� �� �迭�� ũ�⸸ŭ �ݺ����� �ݺ��Ѵ�
                {
                    if (_isChecked == false && _textAlphabet[count].Equals(_textAlphabet[i])) // üũ ���� ǥ�ð� �����̰� ī��Ʈ ���� i���� �����ϴٸ�
                    {
                        _blinkText += _textAlphabet[i]; // ��ũ �ؽ�Ʈ�� �ش� ���ڸ� ���Ѵ�
                        _isChecked = true; // üũ ���� ǥ�ø� ������ �ٲ۴�
                    }
                    else
                    {
                        _blinkText += "   "; // �ش����� �ʴ� ���� ��ġ�� �������� ��ü�Ѵ�
                    }
                }

                blinkText.text = _blinkText; // ��ũ �ؽ�Ʈ�� �ؽ�Ʈ�� �� ���·� �����Ѵ�

                yield return new WaitForSeconds(blinkDelay); // blinkDelay ��ŭ ���ð��� ���´�

                ++count; // ī��Ʈ�� ���� �����ڷ� �ø���
            }
        }
        else // ��ũ Ÿ�� ���ΰ� �����̶��
        {
            while (true) // ���� �ݺ��� ����
            {
                string _blinkText = blinkText.text; // ��ũ �ؽ�Ʈ ���ڿ��� �����´�
                blinkText.text = ""; // ��ũ �ؽ�Ʈ�� �� ���ڿ��� �����

                yield return new WaitForSeconds(blinkDelay); // blinkDelay ��ŭ ���ð��� ���´�

                blinkText.text = _blinkText; // ��ũ �ؽ�Ʈ�� �ؽ�Ʈ�� �� ���·� �����Ѵ�

                yield return new WaitForSeconds(blinkDelay); // blinkDelay ��ŭ ���ð��� ���´�
            }
        }
    }
}
