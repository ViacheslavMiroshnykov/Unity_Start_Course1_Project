using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerminalControl : MonoBehaviour
{
    enum Screen {MainMenu,Password,Win};
    Screen currentScreen = Screen.MainMenu;
    int level;

    // Start is called before the first frame update
    void Start()
    {
        ShowMainMenu("Слава");
    }

    void ShowMainMenu (string PlayerName)
    {
        currentScreen = Screen.MainMenu;
        level = 0;
        Terminal.ClearScreen();
        Terminal.WriteLine("Привет, "+PlayerName+"!");
        Terminal.WriteLine("Какой терминал хотите взломать сегодня?");
        Terminal.WriteLine(" ");
        Terminal.WriteLine("Введите 1 - городская библиотека");
        Terminal.WriteLine("Введите 2 - полицейский участов");
        Terminal.WriteLine("Введите 3 - космический корабль");
        Terminal.WriteLine("Введите ваш выбор:");
    }

    void OnUserInput(string input) 
    {
        if (input == "меню")
        {
            ShowMainMenu("рад тебя видеть снова!");
        }
        else if (currentScreen == Screen.MainMenu)
        {
            RunMainMenu (input);
        }
    }
    void RunMainMenu (string input)
    {
        if (input == "007")
        {
            Terminal.WriteLine("Hello Mr Bond!");
        }
        else if (input == "1")
        {
            level = 1;
            GameStart();
        }
        else if (input == "2")
        {
            level = 2;
            GameStart();
        }      
        else if (input == "3")
        {
            level = 3;
            GameStart();
        }       
        else
        {
            Terminal.WriteLine("Введите правильное значение");
        }
    }
    void GameStart ()
    {
        currentScreen = Screen.Password;
        Terminal.WriteLine("Вы выбрали "+level+" уровень.");
    }
}

