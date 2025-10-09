using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed = 5f;

    private void Update()
    {
        Vector3 pos = transform.position;   

        if (this.CompareTag("Player Unit"))
        {
            pos.x += speed * Time.deltaTime;
        }
        else if (this.CompareTag("Enemy"))
        {
            pos.x -= speed * Time.deltaTime;
        }

        transform.position = pos;
    }
}
