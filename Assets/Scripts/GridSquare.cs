using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using static GameEvents;

public class GridSquare : Selectable, IPointerClickHandler, ISubmitHandler, IPointerUpHandler, IPointerExitHandler
{
    public GameObject number_text;
    private int number_ = 0;

    private bool selected_ = false;
    private int square_index = -1;

    public bool IsSelected()
    {
        return selected_;
    }

    public void SetSquareIndex(int square_index)
    {
        this.square_index = square_index;
    }

    void Start()
    {
        selected_ = false;
    }
   
    // Update is called once per frame
    void Update()
    {
        
    }

    public void DisplayText()
    {
        if (number_ <= 0)
        {
            number_text.GetComponent<Text>().text = " "; 
        }
        else
        {
            number_text.GetComponent<Text>().text = number_.ToString();
        }
    }
    
    public void SetNumber(int number)
    {
        number_ = number;
        DisplayText();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        selected_ = true;
        GameEvents.SquareSelectedMethod(square_index);
    }
    public void OnSubmit(BaseEventData eventData)
    {

    }

    private void OnEnable()
    {
        GameEvents.OnUpdateSquareNumber += OnSetNumber;
        GameEvents.OnSquareSelected += OnSquareSelected;
    }
    private void OnDisable()
    {
        GameEvents.OnUpdateSquareNumber -= OnSetNumber;
        GameEvents.OnSquareSelected  -= OnSquareSelected;
    }

    public void OnSetNumber(int number)
    {
        if(selected_)
        {
            SetNumber(number);
        }
    }

    public void OnSquareSelected(int square_index)
    {
        if (this.square_index != square_index) 
        {
            selected_ = false;
        }
    }
}
