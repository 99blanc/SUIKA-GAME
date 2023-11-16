using UnityEngine;

public class PlanetController : MonoBehaviour
{
    [HideInInspector] public int planetLevel; // �༺ ������ ������ ���� ���� ��
    [HideInInspector] public int planetScore; // �༺ ������ ������ ���� ���� ��

    private string planetName; // �༺ �̸��� ���ڿ��� ������ ���ڿ� ��
    private float planetColliderRadius; // �༺ CircleCollider2D�� ������ ������ �Ǽ� ��
    private Vector3 planetScale; // �༺ transform.localScale(ũ��)�� �����ϱ� ���� Vector3 ��
    private Sprite planetSprite; // �༺ �̹��� ��������Ʈ�� ���� ��������Ʈ ��
    [HideInInspector] public int planetIndex; // �÷��� ������ �ε���ȭ�� ���� ��

    [HideInInspector] public bool isGrowed; // �༺�� Ŀ���� ���� �Ǵ��ϴ� �� or ������ �Ҹ��� ��
    [HideInInspector] private bool isTagged; // �༺�� �±װ� �޷ȴ����� �Ǵ��ϴ� �� or ������ �Ҹ��� ��

    public void OnPlanetInit(int _index) // �÷��� ����(�⺻ ���� ����) �Լ�
    {
        planetIndex = _index; // �༺ �ε����� �޼ҵ� ���� _index�� ����

        planetLevel = PlanetDatabase.planetLevel[_index]; // �༺ ������ PlanetDatabase���� �������� ����
        planetScore = PlanetDatabase.planetScore[_index]; // �༺ ������ PlanetDatabase���� �������� ����
        planetName = PlanetDatabase.planetName[_index]; // �༺ �̸��� PlanetDatabase���� �������� ����
        planetColliderRadius = PlanetDatabase.planetColliderRadius[_index];
        // �༺ CircleCollider2D�� ������ PlanetDatabase���� �������� ����
        planetScale = PlanetDatabase.planetScale[_index]; // �༺ ũ�⸦ PlanetDatabase���� �������� ����
        planetSprite = PlanetDatabase.planetSprite[_index]; // �༺ �̹��� ��������Ʈ�� PlanetDatabase���� �������� ����

        gameObject.name = planetName; // �� ��ũ��Ʈ�� ���� ���� ������Ʈ�� �̸��� ������ �༺ �̸����� �����Ѵ�
        GetComponent<CircleCollider2D>().radius = planetColliderRadius; 
        // �� ���� ������Ʈ�� CircleCollider2D�� ������ ������ �༺ ������ �����Ѵ�
        transform.localScale = planetScale; // �༺ ũ�⸦ �����Ѵ�
        GetComponent<SpriteRenderer>().sprite = planetSprite;
        // �� ���� ������Ʈ�� SpriteRenderer�� �̹��� ��������Ʈ�� ������ �༺ �̹��� ��������Ʈ�� �����Ѵ�
    }

    private void OnCollisionStay2D(Collision2D _hit) // �ݶ��̴��� ��� �浹 ���� ��
    {
        if (!isTagged) // �±� ������ �ȵǾ��ٸ�
        {
            gameObject.tag = "Planet"; // �� ���� ������Ʈ�� �±׸� Planet���� �����Ѵ�
            isTagged = true; // �±� ���� ���θ� �˱� ���� �Ҹ��� ���� ������ �����Ѵ�
        }

        if (isGrowed == false && _hit.collider.CompareTag("Planet")) // �༺�� Ŀ�� ���°� �ƴϰ� �浹�� ������Ʈ�� �±װ� Planet(�༺) �̶��
        {
            PlanetController _other = _hit.gameObject.GetComponent<PlanetController>(); // �༺ ��Ʈ�ѷ��� �浹 ������Ʈ���� �����´�
            Vector3 _otherPosition = _other.transform.position; // �浹 ������Ʈ�� ��ġ���� �����´�
            Quaternion _otherRotation = _other.transform.rotation; // �浹 ������Ʈ�� ȸ������ �����´�

            if (_other.isGrowed == false && _other.planetLevel == planetLevel)
                // �浹 ������Ʈ�� �� ���� ������Ʈ�� �༺�� Ŀ�� ���� ���ο� ������ ������ �������� Ȯ���Ѵ�
            {
                _other.isGrowed = isGrowed = true; // �浹 ������Ʈ�� �� ���� ������Ʈ�� �༺�� Ŀ�� ���¸� �� �Ҹ��� ������ �����Ѵ�
                OnGrow(isGrowed); // �༺�� Ŀ�� �� �޼ҵ带 ȣ���Ѵ�
                _other.OnLevelUp(_otherPosition, _otherRotation); // �浹 ������Ʈ�� ������(�༺�� Ŀ���� ��) �޼ҵ带 ȣ���Ѵ�
            }
        }
    }

    public void OnGrow(bool _isGrowed) // �༺�� Ŀ�� �� �޼ҵ�
    {
        if (_isGrowed) // �༺�� Ŀ���ٸ�
        {
            Destroy(gameObject); // �� ���� ������Ʈ�� �����Ѵ�
        }
    }

    private void OnLevelUp(Vector3 _position, Quaternion _rotation) // ������(�༺�� Ŀ���� ��) �޼ҵ�
    {
        transform.position = _position; // �� ���� ������Ʈ�� ��ġ���� �浹 ������Ʈ�� ��ġ������ �Ѵ�
        transform.rotation = _rotation; // �� ���� ������Ʈ�� ȸ������ �浹 ������Ʈ�� ȸ�������� �Ѵ�
        isGrowed = false; // �� �༺�� Ŀ�� ���¸� �ٽ� ���� �Ҹ��� ������ �����Ѵ�

        int _index = ++planetIndex; // �༺ �ε����� ���� ������ �ε����� �ٲ۴�
        ScoreManager.OnSetScore(PlanetDatabase.planetScore[_index]); // ���ھ �ش� ������ �༺ ���ھ ���� ���� ���Ѵ�
        OnPlanetInit(_index);
        // ���� �ε����� �ѱ� ���� �ٽ� OnPlanetInit() �޼ҵ带 ���� ȣ���Ͽ� �� ���� ������Ʈ�� �������� �����Ѵ�
    }
}