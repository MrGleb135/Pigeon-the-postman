using UnityEngine;

public class RandomBlinkAnimation : MonoBehaviour
{
    Animator anim;
    int idleCounter = 0;
    int nextBlinkAfter;
    int previousLoopCount = -1;
    bool isBlinking = false;

    // Установка случайного числа циклов до следующего моргания
    void SetNextBlink()
    {
        nextBlinkAfter = Random.Range(3, 6);
    }

    void Start()
    {
        anim = GetComponent<Animator>(); // Получаем Animator на объекте
        SetNextBlink(); // Задаём первое случайное моргание
    }
    void Update()
    {
        // Получаем информацию о текущем состоянии анимации
        AnimatorStateInfo state = anim.GetCurrentAnimatorStateInfo(0);

        if (isBlinking)
        {
            if (state.IsName("PigionBlinkAnimation") && state.normalizedTime >= 1f)
            {
                anim.SetBool("RandomBlink", false);
                isBlinking = false;
                previousLoopCount = -1;
            }
            return;
        }
        
        if (state.IsName("PigionStayAnimation"))
        {
            // normalizedTime - количество пройденных полных циклов анимации
            int currentLoopCount = (int)state.normalizedTime;

            if (currentLoopCount > previousLoopCount)
            {
                if (previousLoopCount >= 0)
                {
                    idleCounter++;
                }
                previousLoopCount = currentLoopCount;
            }
            
            if (idleCounter >= nextBlinkAfter)
            {
                anim.SetBool("RandomBlink", true);
                idleCounter = 0;
                previousLoopCount = -1;
                SetNextBlink();
                isBlinking = true;
            }
        }
        else
        {
            previousLoopCount = -1;
        }
    }
}   