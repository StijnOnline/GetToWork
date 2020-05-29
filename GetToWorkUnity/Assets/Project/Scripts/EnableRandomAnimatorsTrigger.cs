using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EnableRandomAnimatorsTrigger : MonoBehaviour
{
    [SerializeField] private List<Animator> animatorsToEnable;
    [SerializeField] private float delay;
    [SerializeField] private int enablecount;
    private System.Random rnd;

    private void Start() {
        rnd = new System.Random();
    }

    //should be able to reset;
    /*public void ResetObjects() {
        GetComponent<Collider>().enabled = true;
        foreach(Animator a in animatorsToEnable) {            
            a.Play(a.GetCurrentAnimatorStateInfo(0).shortNameHash, 0, 0);
            a.enabled = false;
        }
        
    }*/

    private void OnTriggerEnter(Collider other) {
        StartCoroutine(EnableAnimators());
        GetComponent<Collider>().enabled = false;
    }

    private IEnumerator EnableAnimators() {
        yield return new WaitForSeconds(delay);
        var randomOrder = animatorsToEnable.OrderBy(x => rnd.Next());
        var randomLimited = randomOrder.Take(enablecount);
        foreach(Animator a in randomLimited) {
            a.enabled = true;
        }
    }
}