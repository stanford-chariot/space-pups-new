using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] private GameObject cubePrefab;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject != null)
        {
            Destroy(other.gameObject);
        }

    }
    [SerializeField] private MeshRenderer meshRenderer;

    //private void OnTriggerEnter(Collider collision)
    //{
    //    switch (collision.gameObject.tag)
    //    {
    //        case "Gem":
    //            Debug.Log("You won a gem!");
    //            Destroy(collision.gameObject);
    //            break;
    //        case "Enemy":
    //            Debug.Log("You hit an opponent");
    //            break;
    //        default:
    //            break;
    //    }
    //}
}


