using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MarcosQuijada.Chemibot {
public class PickeableSubstance : MonoBehaviour
{

    public SubstanceName substanceName;
    [SerializeField] TweenEffects tweener;
    [SerializeField] ParticleSystem pickedParticle;
    [SerializeField] bool isStar = false;
    bool picked = false;


    void Start() {
        tweener = this.GetComponent<TweenEffects>();
    }


    private void OnTriggerEnter(Collider other) {
        if (picked) return;
        if (other.tag != "Player") return;
        picked = true;
        if (pickedParticle != null) pickedParticle.Play();
        if (isStar) Game.ins.soundStar.Play();
        else Game.ins.soundPickeable.Play();
        if (isStar) MtEvents.PickupStar(this.transform.position);
        else MtEvents.PickupSubstance(substanceName, this.transform.position);
        tweener.Hide();
        Invoke("Disable", 1f);
    }


    void Disable() {
        this.gameObject.SetActive(false);
    }


    public void Restart() {
        picked = false;
    }


}

}
