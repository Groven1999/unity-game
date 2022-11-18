using UnityEngine;
using System.Collections;


public class DestroyBox : MonoBehaviour
{
    public IEnumerator DestroyBoxEffect() {

        gameObject.GetComponent<ParticleEffectExplosion>().ParticleExplosionGoldBoxDestroy();
        print("Ienumerator position: " + gameObject.transform.position);

        Destroy(gameObject);

        yield return null;

    }
}
