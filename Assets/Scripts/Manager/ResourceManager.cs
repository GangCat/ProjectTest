using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceManager : MonoBehaviour
{
    public void Init()
    {
        gm = GameManager.Instance;
        foreach (GameObject go in resourcePrefabs)
            listResource.Add(go.GetComponent<ResourceBase>());

        StartCoroutine("SpawnResourcesCoroutine");
    }

    private IEnumerator SpawnResourcesCoroutine()
    {
        for(int i = 0; i < listResource.Count; ++i)
        {
            GameObject resGo = Instantiate(listResource[i].gameObject, transform);
            resGo.GetComponent<ResourceBase>().Init();
            

            yield return null;
        }
    }







    [SerializeField]
    private GameObject[] resourcePrefabs = null;

    private List<ResourceBase> listResource = new List<ResourceBase>();
    private GameManager gm = null;
}
