using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClickOnNo : MonoBehaviour
{
    [SerializeField] GameObject _button;
    [SerializeField] Text exitText;
    [SerializeField] Text mainText;
    string wantToExitX;
    int x;
    int y;
    int no = 0;
    bool yes = false;
    bool noDecision = false;
    RectTransform buttonTransform;
    // Start is called before the first frame update
    void Start()
    {
        buttonTransform = _button.GetComponent<RectTransform>();
        Application.wantsToQuit += wantQuit;
        wantToExitX = "никуда ты не уйдешь, пока не ответишь)";
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ClickNo()
    {
        no += 1;
        if (no == 20)
        {
            yes = true;
            noDecision = true;
           StartCoroutine(Quit());
        }
        else
        {
            x = Random.Range(-300, 300);
            y = Random.Range(-190, 190);

            buttonTransform.localPosition = new Vector2(x, y);
        }
      
    }

    public void ClickYessss()
    {
        yes = true;
       StartCoroutine(Quit());
    }

    public bool wantQuit()
    {
        // _text.text = nooo;
        if (yes)
        {
            
            return true;
        }
        else
        {
            exitText.text = wantToExitX;
            return false;
        }
    }

    IEnumerator Quit()
    {
        if (noDecision)
        {
            mainText.text = "ну ладно, ладно";
        }
        else
        {
            mainText.text = "Я знала)";            
        }
        yield return new WaitForSeconds(1);
        Application.Quit();
    }

    
}
