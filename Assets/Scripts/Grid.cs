using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid : MonoBehaviour
{
    public int columns = 0;
    public int rows = 0;
    public float square_offset = 0.0f;
    public GameObject grid_square;
    public Vector2 start_position = new Vector2(0.0f, 0.0f);
    public float square_scale = 1.0f;
    public float square_gap = 0.1f;

    private List<GameObject> grid_square_ = new List<GameObject>();
    private int selected_grid_data = -1;


    // Start is called before the first frame update
    void Start()
    {
        if (grid_square.GetComponent<GridSquare>() == null)
        {
            Debug.LogError("This Game Object need to have GridSquare script attached");
        }
        CreateGrid();
        SetGridNumber(GameSettings.ins.GetGameMode());
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void CreateGrid()
    {
        SpawnGridSquares();
        SetSquaresPosition();
    }

    private void SpawnGridSquares()
    {
        int square_index = 0;
        for( int row = 0; row < rows; row++ )
        {
            for (int column = 0; column < columns; column++)
            {
                grid_square_.Add(Instantiate(grid_square) as GameObject);
                grid_square_[grid_square_.Count - 1].GetComponent<GridSquare>().SetSquareIndex(square_index);
                grid_square_[grid_square_.Count - 1].transform.SetParent(this.transform);
                grid_square_[grid_square_.Count - 1].transform.localScale = new Vector3(square_scale, square_scale, square_scale);
                square_index++;
            }
        }
        
    }

    private void SetSquaresPosition()
    {
        var square_rect = grid_square_[0].GetComponent<RectTransform>();
        Vector2 offset = new Vector2();
        Vector2 square_gap_number = new Vector2(0.0f, 0.0f);
        bool row_moved = false;

        offset.x = square_rect.rect.width * square_rect.transform.localScale.x + square_offset;
        offset.y = square_rect.rect.height * square_rect.transform.localScale.y + square_offset;

        int column_number = 0;
        int row_number = 0;

        foreach (GameObject square in grid_square_)
        {
            if (column_number + 1 > columns)
            {
                row_number++;
                column_number = 0;
                square_gap_number.x = 0;
                row_moved = false;
            }

            var pos_x_offset = offset.x * column_number + (square_gap_number.x * square_gap);
            var pos_y_offset = offset.y * row_number + (square_gap_number.y * square_gap);

            if(column_number > 0 && column_number % 3 == 0)
            {
                square_gap_number.x++;
                pos_x_offset += square_gap;
            }
            if (row_number > 0 && row_number % 3 == 0 && row_moved == false)
            {
                row_moved = true;
                square_gap_number.y++;
                pos_y_offset += square_gap;
            }

            square.GetComponent<RectTransform>().anchoredPosition = new Vector2(start_position.x + pos_x_offset,
                start_position.y - pos_y_offset);
            column_number++;

        }
    }

    private void SetGridNumber(string level)
    {
        selected_grid_data = UnityEngine.Random.Range(0, SudokuData.ins.sudoku_game[level].Count);
        var data = SudokuData.ins.sudoku_game[level][selected_grid_data];

        setGridSquareData(data);
    }
    private void setGridSquareData(SudokuData.SudokuBoardData data)
    {
        for (int i = 0; i < grid_square_.Count; i++)
        {
            grid_square_[i].GetComponent<GridSquare>().SetNumber(data.unsolved_data[i]);
            grid_square_[i].GetComponent<GridSquare>().SetCorrectNumber(data.solved_data[i]);
            grid_square_[i].GetComponent<GridSquare>().SetHasDefaultValue(data.unsolved_data[i] != 0 && data.unsolved_data[i] == data.solved_data[i]);
        }
    }
}
