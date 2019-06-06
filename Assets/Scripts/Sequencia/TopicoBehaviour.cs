using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TopicoBehaviour : MonoBehaviour, IPointerDownHandler, IPointerUpHandler{

    //Variável que contem a posicao
    private string id;
    private bool beenHold = false;
    private int corretude = 0;

    //Variável que contem a posição inicial da poção e a próxima
    private Vector2 defaultSpot;
    private Vector2 newSpot;
    private GameObject inContact = null;
    private bool inTopicContact = false;

    //Variável que contem a posição inicial e final do movimento da poção
    private Vector2 homeSpot, targetSpot, deltaSpot;

    //Variável que contem a velocidade atual
    private float moveSpeed = 0;

    private RectTransform rect;
    private Animator anim;

    // ************ Get n Set *****************

    public void SetId(string id)
    {
        this.id = id;
    }

    // ************ MonoBehaviour ***********************


    void Start()
    {
        rect = GetComponent<RectTransform>();
        anim = GetComponent<Animator>();
        defaultSpot = rect.localPosition;
    }

    void Update()
    {
        if(beenHold)
        {
            transform.position = Input.mousePosition;
        }
        else if(moveSpeed > 0)
        {
            goTo(targetSpot);
        }
    }


    //quero que va para 480 740
    // 2708 2084

    // ************ Mátodos de Manipulação *******************


    // Método que move a poção até um certo lugar
    private void goTo(Vector2 spot)
    {

        moveSpeed += Time.deltaTime * 895; // Duração do movimento atual é 0.2s, para alterar fazer a conta 179 / t   (ex: 179/0.2 = 895)

        if(moveSpeed >= 180)
        {
            rect.localPosition = targetSpot;
            moveSpeed = 0;

            if(inContact != null)
            {
                if(inContact.name.Contains(id))
                {

                    if (corretude == 1)
                        return;

                    corretude = 1;
                    SequenciaPanelBehavior.CurrentSequencia.Acertou();
                    anim.SetTrigger("Certo");
                    

                    //Acertou
                }
                else
                {

                    if(corretude == 1)
                        SequenciaPanelBehavior.CurrentSequencia.Errou();

                    anim.SetTrigger("Errado");
                    corretude = 0;



                    //Errou
                }
            }
            else
            {
                if (corretude == 1)
                    SequenciaPanelBehavior.CurrentSequencia.Errou();

                corretude = 0;
            }

            return;
        }

        rect.localPosition = homeSpot + (deltaSpot - deltaSpot * Mathf.Cos(moveSpeed * Mathf.Deg2Rad)) / 2; 




    }
    

    public void OnPointerDown(PointerEventData eventData)
    {
        beenHold = true;
        transform.SetAsLastSibling();
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        beenHold = false;

        if (inContact != null)
        {
            targetSpot = newSpot;
        }
        else
        {
            targetSpot = defaultSpot;
        }

        homeSpot = rect.localPosition;
        deltaSpot = targetSpot - homeSpot;
        moveSpeed = 1;
    }

    // Métodos de colisão

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Topico")
        {
            inTopicContact = true;
        }
        else if(!inTopicContact)
        {
            newSpot = collision.gameObject.GetComponent<RectTransform>().localPosition;
            inContact = collision.gameObject;
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Topico")
        {
            inTopicContact = false;
        }

        inContact = null;

    }


}
