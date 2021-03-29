using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public static class AnimatorExtension
{
    public static void SetTriggerOneFrame(this Animator self, MonoBehaviour monoBehaviour, string name)
    {
        IEnumerator SetTriggerOneFrame(Animator animator, string triggerName)
        {
            animator.SetTrigger(triggerName);
            yield return null;
            if (animator != null)
            {
                animator.ResetTrigger(triggerName);
            }
        }
        monoBehaviour.StartCoroutine(SetTriggerOneFrame(self, name));
    }

    public static void SetTriggerOneFrame(this Animator self, MonoBehaviour monoBehaviour, int id)
    {
        IEnumerator SetTriggerOneFrame(Animator animator, int triggerId)
        {
            animator.SetTrigger(triggerId);
            yield return null;
            if (animator != null)
            {
                animator.ResetTrigger(triggerId);
            }
        }
        monoBehaviour.StartCoroutine(SetTriggerOneFrame(self, id));
    }
}
public class Attack : MonoBehaviour
{

    Animator animator;

    private Collider weaponCollider;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        weaponCollider = GameObject.Find("W_R").GetComponent<BoxCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            animator.SetTriggerOneFrame(this, "Attack");

           //  animator.SetBool("Attack", true);
            weaponCollider.enabled = true;
            Invoke("ColliderReset", 1.5f);
        }
    }

    private void OnAnimatorMove()
    {
        animator.ResetTrigger("Attack");
    }

    private void ColliderReset()
    {
        weaponCollider.enabled = false;
    }
}
