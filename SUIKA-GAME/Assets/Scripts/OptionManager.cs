using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class OptionManager : MonoBehaviour
{
    public Slider backgroundSlider; // ����� �����̴��� ������ ��
    public Slider effectSlider; // ȿ���� �����̴��� ������ ��
    public Slider mouseSpeedSlider; // ���콺 �ӵ� �����̴��� ������ ��

    private float backgroundVolume; // ����� ���� ũ�⸦ ������ ��
    private float effectVolume; // ȿ���� ���� ũ�⸦ ������ ��
    private float mouseSpeed; // ���콺 �ӵ��� ������ ��

    private void Start()
    {
        OnUpdateOption(); // ���� ������Ʈ �� ȣ�� �޼ҵ�
    }

    public void OnUpdateOption() // ���� ������Ʈ �� ȣ�� �޼ҵ�
    {
        backgroundVolume = PlayerPrefs.GetFloat("BackgroundVolume"); // ����� ���� ũ�⸦ ������ ������ �����´�
        effectVolume = PlayerPrefs.GetFloat("EffectVolume"); // ȿ���� ���� ũ�⸦ ������ ������ �����´�
        mouseSpeed = PlayerPrefs.GetFloat("MouseSpeed"); // ���콺 �ӵ��� ������ ������ �����´�

        backgroundSlider.value = backgroundVolume; // ����� �����̴��� ���� �����ߴ� ������ �����Ͽ� UI�� ǥ���Ѵ�
        effectSlider.value = effectVolume; // ȿ���� �����̴��� ���� �����ߴ� ������ �����Ͽ� UI�� ǥ���Ѵ�
        mouseSpeedSlider.value = mouseSpeed; // ���콺 �ӵ� �����̴��� ���� �����ߴ� ������ �����Ͽ� UI�� ǥ���Ѵ�

        backgroundSlider.onValueChanged.AddListener(delegate { OnSaveOption(); }); // ����� �����̴��� ���� ������ ������ �Լ��� ȣ���Ѵ�
        effectSlider.onValueChanged.AddListener(delegate { OnSaveOption(); }); // ȿ���� �����̴��� ���� ������ ������ �Լ��� ȣ���Ѵ�
        mouseSpeedSlider.onValueChanged.AddListener(delegate { OnSaveOption(); }); // ���콺 �ӵ� �����̴��� ���� ������ ������ �Լ��� ȣ���Ѵ�
    }

    public void OnSaveOption() // ���� ���� �����ϴ� �޼ҵ�
    {
        backgroundVolume = backgroundSlider.value; // ����� ũ�⸦ ����� �����̴� ������ �����´�
        effectVolume = effectSlider.value; // ȿ���� ũ�⸦ ȿ�� �����̴� ������ �����´�
        mouseSpeed = mouseSpeedSlider.value; // ���콺 �ӵ��� ���콺 �ӵ� �����̴� ������ �����´�

        PlayerPrefs.SetFloat("BackgroundVolume", backgroundVolume); // ����� ũ�⸦ ������ ������ �����Ѵ�
        PlayerPrefs.SetFloat("EffectVolume", effectVolume); // ȿ���� ũ�⸦ ������ ������ �����Ѵ�
        PlayerPrefs.SetFloat("MouseSpeed", mouseSpeed); // ���콺 �ӵ��� ������ ������ �����Ѵ�
    }
    public void OnSaveClick()
    {
        PlayerPrefs.SetInt("Score", 0); // ���ھ� Ű�� ���ھ� ������ ã�� �����Ѵ�
        OnSaveOption(); // ���� ���� �����ϴ� �޼ҵ� ȣ��
        SoundManager.Play.PlayEffect("MouseClick"); // ���� �̸����� ���� ���
        SceneManager.LoadScene(PlayerPrefs.GetString("SceneName")); // ���� ���� ������ ������ ȣ���Ͽ� �ҷ��´�
    }

    public void OnCheckSceneChange()
    {
        SoundManager.Play.PlayEffect("SceneChange"); // ���� �̸����� ���� ���
    }
}
