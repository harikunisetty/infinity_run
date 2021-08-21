using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] GameObject[] platfroms;
 
    [SerializeField] float blockpointer;
    [SerializeField] float safearea;

    private void Awake()
    {
        GameObject GO = Instantiate(platfroms[0], transform.position, Quaternion.identity);
        GO.transform.SetParent(transform);

        GO.transform.position = Vector3.zero;
    }

    void Start()
    {
        player = GameObject.Find("Player");
    }

    void Update()
    {
        if (player == null)
            return;

        while (blockpointer < player.transform.position.x + safearea)
        {
            GameObject GO = Instantiate(platfroms[0], transform.position, Quaternion.identity);
            GO.transform.SetParent(transform);

            PlatformController platfrom = GO.GetComponent<PlatformController>();

            GO.transform.position = new Vector3(blockpointer + platfrom.size, 0f, 0f);

            blockpointer += platfrom.size;
        }

    }
}
