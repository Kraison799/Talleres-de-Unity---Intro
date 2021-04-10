using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    // Prefabs
    public GameObject target;
    public GameObject obstacle;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("CreateBoulder", 0f, 3f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void CreateBoulder()
    {
        Vector3 position = new Vector3(Random.Range(-18, 18), 1, Random.Range(-18, 18));
        GameObject instance = Instantiate(target, transform.position + position, transform.rotation);

        Vector3 position2 = new Vector3(Random.Range(-18, 18), 1, Random.Range(-18, 18));
        GameObject instance2 = Instantiate(obstacle, transform.position + position2, transform.rotation);

        Vector3 position3 = new Vector3(Random.Range(-18, 18), 1, Random.Range(-18, 18));
        GameObject instance3 = Instantiate(obstacle, transform.position + position3, transform.rotation);

        Physics.IgnoreCollision(instance.GetComponent<Collider>(), instance2.GetComponent<Collider>());
        Physics.IgnoreCollision(instance.GetComponent<Collider>(), instance3.GetComponent<Collider>());
        Physics.IgnoreCollision(instance2.GetComponent<Collider>(), instance3.GetComponent<Collider>());

        Destroy(instance, 7f);
        Destroy(instance2, 7f);
        Destroy(instance3, 7f);
    }
}
