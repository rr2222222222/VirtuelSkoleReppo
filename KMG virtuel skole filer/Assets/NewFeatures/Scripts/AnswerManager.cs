using UnityEngine;

public class AnswerManager : MonoBehaviour
{
    public static AnswerManager answerManager;
    [HideInInspector] public Animator anim;

    private void Awake()
    {
        anim = gameObject.GetComponent<Animator>();

        if (answerManager != null)
            Destroy(gameObject);
        else
            answerManager = this;
    }

    public void Correct()
    {
        anim.SetTrigger("Correct");
    }
    public void Incorrect()
    {
        anim.SetTrigger("Incorrect");
    }
}
