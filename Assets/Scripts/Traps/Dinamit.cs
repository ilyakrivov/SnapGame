using System.Collections;
using UnityEngine;
using CartoonFX;

public class Dinamit : Trap
{

    private float timerPuff = 5f;
    private float timerDestroy = 5.3f; // разброс 0.3f
    private bool flagExplosive = false;
    private bool flagMinus = false;
    private bool flagPlus = false;
    private bool Check1 = false; // булы для одиночного запуска сложения или вычитания очков
    private bool Check2 = false;

    //в данном скрипте испльзуем только Puff для взрыва

    public void Start()
    {
        psDamage = ParticleDamage.GetComponentInChildren<ParticleSystem>();
        psDestroy = ParticleDestoy.GetComponentInChildren<ParticleSystem>();
        shake.GetComponent<CFXR_Effect>().enabled = false;
        psDamage.Pause();
        psDestroy.Pause();
    }

    protected override void Update()
    {
        if (flagExplosive)
        {
            timerPuff -= Time.deltaTime; 
            timerDestroy -= Time.deltaTime;
            if (timerPuff <= 0)
            {
                Puff();

            }
            if (timerDestroy <= 0)
            {
                Destroy();

            }
        } 
    if (flagMinus)  // минус очки (корутина для одиночного запуска
    {
        timerPuff -= Time.deltaTime;
        if (Check1)
            {
                if (timerPuff <= 0)
                {
                    StartCoroutine(MinusCorut());
                    Check1 = false;
                }
            }
    }   
    if (flagPlus)  // плюс очки (корутина для одиночного запуска
        {
        timerPuff -= Time.deltaTime;
        if (Check2)
            {
                if (timerPuff <= 0)
                {
                    StartCoroutine(PlusCorut());
                    Check2 = false;
                }
            }
    }

    }
    IEnumerator PlusCorut()
    {
        yield return new WaitForEndOfFrame();
        CountPlus();
    }
    IEnumerator MinusCorut()
    {
        yield return new WaitForEndOfFrame();
        CountMinus();
    }

    protected override void OnTriggerEnter(Collider other) //переназначаем функцию (не наследуем у объекта наследования)
    {
        if (isDead)
        {
            return;
        }
        if (checkTouch)
        {
            return;
        }
         if (other.gameObject.CompareTag("Ally")) // если противник имеет тег "Ally"
        {
            flagMinus = true; // делаем флаг для запуска отсчёта таймера для взрыва и отнимания очков
            Check1 = true;

        }
        if (other.gameObject.CompareTag("Enemy")) // если противник имеет тег "Enemy"
        {
            flagPlus = true; // делаем флаг для запуска отсчёта таймера для взрыва и прибавления
            Check2 = true;
        }

        if (other.gameObject.CompareTag("Ground")) //проверка соприкосновения ловушки запуск фх и таймер с запуском фх на уничтожение
        {
            flagExplosive = true;
            checkTouch = true;
        }
    }

    protected override void Destroy()
    {
        Destroy(gameObject);
    }

    protected override void Puff()
    {
        shake.GetComponent<CFXR_Effect>().enabled = true;
        psDamage.Play();
    }

    protected override void CountMinus()
    {
        base.CountMinus();
    }
    protected override void CountPlus()
    {
        base.CountPlus();
    }
}
