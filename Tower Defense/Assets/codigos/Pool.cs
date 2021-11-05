using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pool : MonoBehaviour
{
    static Dictionary<int, Queue<GameObject>> pool = new Dictionary<int, Queue<GameObject>>();

    public static void PreInstantiate(GameObject Enemy, int amount) {
        pool.Add(Enemy.GetInstanceID(), new Queue<GameObject>());

        for (int i = 0; i < amount; i++) {
            GameObject go = Instantiate(Enemy) as GameObject;
            pool[Enemy.GetInstanceID()].Enqueue(go);
            go.SetActive(false);
        }
    }

    public static void Reuse(GameObject Enemy, Vector3 pos, Quaternion rot) {
        if (pool.ContainsKey(Enemy.GetInstanceID())) {
            GameObject go = pool[Enemy.GetInstanceID()].Dequeue();
            go.transform.position = pos;
            go.transform.rotation = rot;
            go.SetActive(true);
            pool[Enemy.GetInstanceID()].Enqueue(go);
        }
    }
}
