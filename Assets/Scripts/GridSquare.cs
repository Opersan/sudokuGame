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
    private int correct_number_ = 0;
    
    // Checks selected grid
    private bool selected_ = false;
    private int square_index = -1;
    // Checks if it grid has default value
    private bool has_default_value_ = false;
    private bool has_wrong_value = false;

    public bool HasWrongValue()
    {
        return has_wrong_value;
    }
    public void SetHasDefaultValue(bool has_default)
    {
        has_default_value_ = has_default;
    }

    public bool GetHasDefaultValue()
    {
        return has_default_value_;
    }


    public bool IsSelected()
    {
        return selected_;
    }

    public void SetSquareIndex(int square_index)
    {
        this.square_index = square_index;
    }

    public void SetCorrectNumber(int number)
    {
        correct_number_ = number;
        has_wrong_value = false;
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
        if(selected_ && has_default_value_ == false)
        {
            SetNumber(number);

            if (number_ != correct_number_)
            {
                has_wrong_value = true;
                var colors = this.colors;
                colors.normalColor = Color.red;
                this.colors = colors;

                GameEvents.OnWrongNumberMethod();
            }
            else
            {
                has_wrong_value = false;
                has_default_value_ = true;
                var colors = this.colors;
                colors.normalColor = Color.white;
                this.colors = colors;
            }
        }
    }

    public void OnSquareSelected(int square_index)
    {
        if (this.square_index != square_index) 
        {
            selected_ = false;
        }
    }

    public void SetSquareColor(Color col)
    {
        var colors = this.colors;
        colors.normalColor = col;
        this.colors = colors;
    }
}
