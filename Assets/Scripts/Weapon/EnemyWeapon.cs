using UnityEngine;

public class EnemyWeapon : MonoBehaviour
{
    private ParticleSystem _particle;

    void Start()
    {
        transform.rotation = new Quaternion(0f, 90f, 0f, 0f);
    }
}
