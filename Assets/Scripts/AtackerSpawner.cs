using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtackerSpawner : MonoBehaviour
{
    bool spawn = true;
    [SerializeField] float minTimeBetweenSpawns = 1f;
    [SerializeField] float maxTimeBetweenSpawns = 5f;
    [SerializeField] Atacker[] atackerPrefabArray;


    // Start is called before the first frame update
    IEnumerator Start()
    {
        while (spawn)
        {
            yield return new WaitForSeconds(UnityEngine.Random.Range(minTimeBetweenSpawns, maxTimeBetweenSpawns));
            SpawnAtacker();
        }
    }

    public void StopSpawing()
    {
        spawn = false;
    }

    private void SpawnAtacker()
    {
        var atackerIndex = Random.Range(0, atackerPrefabArray.Length);
        Spawn(atackerPrefabArray[atackerIndex]);
       
    }

    private void Spawn(Atacker myAtacker)
    {
        Atacker newAtacker = Instantiate(myAtacker, transform.position, transform.rotation) as Atacker;
        newAtacker.transform.parent = transform;
    }
}
