using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;


public class TerminalControl : MonoBehaviour
{
    enum Screen {MainMenu,Password,Win};
    Screen currentScreen = Screen.MainMenu;
    const string menuHint = "Напишите 'меню', чтобы вернуться назад.";
    int level;
    string password;
    string[] Level1Passwords = {"ключ","книга","ручка","шкаф","блокнот"};
    string[] Level2Passwords = {"огнемет","дубинка","тюрьма","наручники","прокурор"};
    string[] Level3Passwords = {"марвел","комета","луна","астероид","спутник"};

    // Start is called before the first frame update
    void Start()
    {
        ShowMainMenu("Игрок");
    }

    void ShowMainMenu (string PlayerName)
    {
        currentScreen = Screen.MainMenu;
        level = 0;
        Terminal.ClearScreen();
        Terminal.WriteLine("Привет, "+PlayerName+"!");
        Terminal.WriteLine("Какую категорию хотите отгадывать?");
        Terminal.WriteLine(" ");
        Terminal.WriteLine("Введите '1' - Категория фильмы");
        Terminal.WriteLine("Введите '2' - Категория мультфильмы");
        Terminal.WriteLine("Введите '3' - Категория игры");
        Terminal.WriteLine("Ваш выбор:");
    }

    void OnUserInput(string input) 
    {
        if (input == "меню")
        {
            ShowMainMenu("рад снова тебя видеть");
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
        else
        {
            Terminal.WriteLine("Введите правильное значение");
        }
        switch(input)
        {
            case "007":
                    Terminal.WriteLine ("Привет, Агент!");
                break;
        } 
    }

    void CheckPassword (string input)
    {
        if (input == password)
        {
            ShowWinScreen();
        }
        else
        {
            GameStart();
        }
    }

    void ShowWinScreen()
    {
        Terminal.ClearScreen();
        Reward();
    }

    void Reward()
    {
        currentScreen = Screen.Win;
        switch(level)
        {
            case 1:
                    Terminal.WriteLine("Вы угадали фильм, поздравляем!");
                    Terminal.WriteLine(" ");
                break;
            case 2:
                    Terminal.WriteLine("Вы угадали мультфильм, поздравляем!");
                    Terminal.WriteLine(" ");
                break;
            case 3:
                    Terminal.WriteLine("Вы угадали фильм, поздравляем!");
                    Terminal.WriteLine(" ");
                break;
        }
        Terminal.WriteLine(menuHint);
    }

    void GameStart ()
    {
        switch(level)
        {
            case 1:
                password = Level1Passwords[UnityEngine.Random.Range(0, Level1Passwords.Length)];
                break;
            case 2:
                password = Level2Passwords[UnityEngine.Random.Range(0, Level2Passwords.Length)];
                break;
            case 3:
                password = Level3Passwords[UnityEngine.Random.Range(0, Level3Passwords.Length)];
                break;
            default:
                Debug.LogError("Такого уровня не существует!");
                break;
        }

        currentScreen = Screen.Password;
        Terminal.ClearScreen();
        switch(level)
        {
            case 1:
                    Terminal.WriteLine("Приветствуем в категории Фильмы!");
                    Terminal.WriteLine("Какое название тут зашифровано?");
                    Terminal.WriteLine(" ");
                    Terminal.WriteLine("Подсказка: "+password.Anagram());
                    Terminal.WriteLine(" ");
                break;
            case 2:
                    Terminal.WriteLine("Приветствуем в категории Мультфильмы!");
                    Terminal.WriteLine("Какое название тут зашифровано?");
                    Terminal.WriteLine(" ");
                    Terminal.WriteLine("Подсказка: "+password.Anagram());
                    Terminal.WriteLine(" ");
                break;
            case 3:
                    Terminal.WriteLine("Приветствуем в категории игры!");
                    Terminal.WriteLine("Какое название тут зашифровано?");
                    Terminal.WriteLine(" ");
                    Terminal.WriteLine("Подсказка: "+password.Anagram());
                    Terminal.WriteLine(" ");
            break;
        }
        Terminal.WriteLine(menuHint);
        Terminal.WriteLine ("Введите зашифрованное название:");
    }
}

