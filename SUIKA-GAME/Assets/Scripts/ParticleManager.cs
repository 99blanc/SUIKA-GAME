using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Particle
{
    public string name; // ��ƼŬ �̸��� ���ڿ��� �ν����� â���� ����
    public ParticleSystem effect; // ��ƼŬ ���� ������Ʈ�� ��ƼŬ�� �ν����� â���� ����
    public float delay; // ��ƼŬ ���� �ð��� �Ǽ� ���� ������ ����
}

public class ParticleManager : MonoBehaviour
{
    [HideInInspector] public static ParticleManager Show; // �� Ŭ���� ��ü�� �ν��Ͻ�ȭ ���� �ٸ� Ŭ���������� ȣ�� �����ϰ� �Ѵ�

    public Particle[] particleEffect; // ��ƼŬ ���� ������Ʈ�� ������ ������ �� Ŭ���� ����� name, clip�� ������ ������

    public string[] showParticleName; // �������� �ִ� ��ƼŬ ���� ������Ʈ�� ������ ���ڿ� �迭 ���� ��
    public GameObject[] showParticleGameObject; // �������� �ִ� ��ƼŬ ���� ������Ʈ�� ������ ���� ������Ʈ �迭 ���� ��

    private void Awake() // ���� ���ʿ� �� �� ����Ǵ� �޼ҵ�
    {
        OnParitcleManagerInit(); // ��ƼŬ �Ŵ��� ���� �޼ҵ�
    }

    private void OnParitcleManagerInit() // ��ƼŬ �Ŵ��� ���� �޼ҵ�
    {
        if (Show == null) // �ν��Ͻ�ȭ�� �ȵǾ��ִٸ�
        {
            Show = this; // �� Ŭ������ �ν��Ͻ��� �����Ѵ�
            DontDestroyOnLoad(gameObject); // ���� ������Ʈ�� ���� ������ �̵��Ͽ��� �ı��� �� ���� �����Ѵ�
        }
        else // ���� ���ǿ� �������� �ʴٸ�
        {
            Destroy(gameObject); // ���� ������Ʈ�� �ı��Ѵ�, �̴� �ٽ� Ÿ��Ʋ ȭ������ ���ư��� ��� ���� �����Ǵ� ���� �Ŵ����� �����ϱ� �����̴�
        }

        showParticleName = new string[particleEffect.Length]; // ��ƼŬ �̸��� ũ�⸦ particleEffect�� ���̷� �Ѵ�
        showParticleGameObject = new GameObject[particleEffect.Length]; // ��ƼŬ ���� ������Ʈ�� ũ�⸦ particleEffect�� ���̷� �Ѵ�
    }

    public void ShowParticle(string _particleName, Vector3 _position) // ��ƼŬ ���� �޼ҵ�
    {
        if (_particleName == null) // ��ƼŬ �̸��� �������� �ʴٸ�
        {
            return; // �Ʒ� ���� ��ɾ���� �����ϰ� ��ȯ
        }

        for (int i = 0; i < particleEffect.Length; ++i) // ��ƼŬ ũ�⸦ ������ �迭�� ũ�⸸ŭ �ݺ����� �����Ѵ�
        {
            if (_particleName.Equals(particleEffect[i].name)) // ���� ������ ���� ��ƼŬ �̸��� ������ ��ƼŬ �̸��� ���ٸ�
            {
                for (int j = 0; j < showParticleName.Length; ++j) // ȿ���� ���� ũ�⸦ ������ �迭�� ũ�⸸ŭ �ݺ����� �����Ѵ�
                {
                    if (particleEffect[i].name.Equals(showParticleName[j]) == false) // ȿ������ ���������� �ʴٸ�
                    {
                        GameObject _particle = Instantiate(particleEffect[i].effect.gameObject, _position, particleEffect[i].effect.transform.rotation);
                        _particle.GetComponent<ParticleSystem>().Play();
                        // ��ƼŬ ���� ������Ʈ�� ����� �����ǿ� �°� �����Ѵ�
                        showParticleName[j] = _particleName; // ���� ���� ���� �̸��� ȿ���� ���� �̸����� �����Ѵ�
                        showParticleGameObject[j] = _particle; // ���� ���� ��ƼŬ ���� ������Ʈ�� ��ƼŬ ���� ������Ʈ�� �����Ѵ�
                        HideParticle(particleEffect[i].name); // ��ƼŬ ����� �޼ҵ� ȣ��

                        return; // �Ʒ� ���� ��ɾ���� �����ϰ� ��ȯ
                    }
                }

                return; // �Ʒ� ���� ��ɾ���� �����ϰ� ��ȯ
            }
        }
    }

    public void HideParticle(string _particleName) // ��ƼŬ ���� �޼ҵ�
    {
        if (_particleName == null) // ��ƼŬ �̸��� �������� �ʴٸ�
        {
            return; // �Ʒ� ���� ��ɾ���� �����ϰ� ��ȯ
        }

        for (int i = 0; i < particleEffect.Length; ++i) // ��ƼŬ ũ�⸦ ������ �迭�� ũ�⸸ŭ �ݺ����� �����Ѵ�
        {
            if (showParticleName[i] != null && showParticleName[i].Equals(_particleName) == true)
                // �������� ��ƼŬ �̸��� ���ڷ� �޾ƿ� ��ƼŬ �̸��� �����ϸ�
            {
                showParticleName[i] = null; // �������� ��ƼŬ �̸��� null�� �����
                Destroy(showParticleGameObject[i], particleEffect[i].delay); // ��ƼŬ ���� ������Ʈ�� delay ��ŭ�� �� �ڿ� �ı��Ѵ�
                showParticleGameObject[i] = null; // �������� ��ƼŬ ���� ������Ʈ�� null�� �����

                return; // �Ʒ� ���� ��ɾ���� �����ϰ� ��ȯ
            }
        }
    }
}
