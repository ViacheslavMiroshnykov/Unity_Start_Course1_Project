using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerminalControl : MonoBehaviour
{
    enum Screen {MainMenu,Password,Win};
    Screen currentScreen = Screen.MainMenu;
    int level;
    string password;
    string[] Level1Passwords = {"ключ","кига","ручка","шкаф","блокнот"};
    string[] Level2Passwords = {"огнемет","дубинка","тюрьма","наручники","прокурор"};
    string[] Level3Passwords = {"марвел","комета","луна","астероид","спутник"};

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
        else if (currentScreen == Screen.Password)
        {
            CheckPassword (input);
        }
    }
    void RunMainMenu (string input)
    {
       bool isValidLevelNumber = (input == "1" || input == "2" || input == "3");

        if(isValidLevelNumber)
        {
            level = int.Parse(input);
            GameStart();
        }
        else if (input == "007")
        {
            Terminal.WriteLine("Hello Mr Bond!");
        }       
        else
        {
            Terminal.WriteLine("Введите правильное значение");
        }
    }

    void CheckPassword (string input)
    {
        if (input == password)
        {
            Terminal.WriteLine ("Поздравляем, терминал взломан!");
        }
        else
        {
            Terminal.WriteLine ("Попробуйте еще раз...");
        }
    }
    void GameStart ()
    {
        switch(level)
        {
            case 1:
                password = Level1Passwords[2];
                break;
            case 2:
                password = Level2Passwords[4];
                break;
            case 3:
                password = Level3Passwords[0];
                break;
            default:
                Debug.LogError("Такого уровня не существует!");
                break;
        }

        currentScreen = Screen.Password;
        Terminal.ClearScreen();
        Terminal.WriteLine("Вы выбрали "+level+" уровень.");
        Terminal.WriteLine ("Введите пароль.");
    }
}

