using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planet : MonoBehaviour
{
    public int level; // ���� ��������
    public bool isMerged; // ismerged (�༺�� ���������� Ȯ���ϱ�����) �Ҹ������� Y or N 
    public GameObject nextLevelObject; // ���� �༺�� ȣ���ϱ� ���� ��������

    private bool isTagged; // isTagged�� Y or N

    private void Start()
    {
        
    }

    private void Update()
    {
        OnMerge(isMerged);
    }

    private void OnCollisionEnter2D(Collision2D _hit) // rigidbody2D�� �ٸ� rigidbody2D�� �浹�ϸ� ȣ���Ѵ�.
    {
        if (!isTagged) // isTagged == false
        {
            gameObject.tag = "Planet"; // �����±׸� Planet�� �ٲ۴�.
            isTagged = true; 
        }

        if (isMerged == false && _hit.collider.CompareTag("Planet")) 
        {
            Planet _other = _hit.gameObject.GetComponent<Planet>();
            Vector3 _otherPosition = _other.transform.position;
            Quaternion _otherRotation = _other.transform.rotation;

            if (nextLevelObject != null && _other.isMerged == false && _other.level == level)
            {
                _other.isMerged = isMerged = true;
                GameObject _nextLevelObject = Instantiate(_other.nextLevelObject, _otherPosition, _otherRotation);
            }
        }
    }
    
    private void OnMerge(bool _isMerged)
    {
        if (_isMerged)
        {
            Destroy(gameObject);
        }
    }
}
