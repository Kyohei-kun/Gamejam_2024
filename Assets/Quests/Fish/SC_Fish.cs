using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class SC_Fish : MonoBehaviour, CS_I_Fart
{
    [SerializeField]
    SC_FishingBear bear;
    [SerializeField]
    GameObject fxExplode;
    Vector3 startpos;
    GameObject obj;

    public void FartInteract()
    {
        GetComponent<Animator>().SetTrigger("scared");
    }

    private void Start()
    {
        bear.ListFish.Add(gameObject);
        startpos = transform.position;
        FartMagazin.AddAbo(this, gameObject, 5);
        obj = gameObject;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "TriggerLac")
        {
            bear.ListFish.Remove(gameObject);
            GameObject.Instantiate(fxExplode, transform.position, Quaternion.identity);
            GameObject.Destroy(gameObject);
        }
    }

    void Update()
    {
        if(Vector3.Distance(startpos, transform.position) > 10f)
        {
            bear.ListFish.Remove(gameObject);
            GameObject.Instantiate(fxExplode,transform.position,Quaternion.identity);
            GameObject.Destroy(gameObject);
        }
    }

    public void FishScared()
    {
        transform.Rotate(0, Random.Range(-180, 180), 0, Space.Self);

        StartCoroutine(Fuite());
    }

    IEnumerator Fuite()
    {
        float timer = 0;

        while(timer < 1f)
        {
            timer += Time.deltaTime;
            obj.transform.position += (transform.right * 0.05f);

            yield return 0f;
        }
    }
}
