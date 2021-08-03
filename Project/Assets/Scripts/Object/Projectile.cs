using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float damage;

    private void OnCollisionEnter(Collision other) {
        if(other.gameObject.tag == "Ground"){
            Destroy(gameObject, 3);
        }
        else if(other.gameObject.tag == "Wall"){
            Destroy(gameObject);
        }
    }

}
