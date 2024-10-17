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
    string[] Level1Passwords = {"Интерстеллар","Начало","Гладиатор","Аватар","Титаник",
"Матрица","Дюна","Джуманджи","Джокер","Рэмбо",
"Тор","Годзилла","Кингсман","Аладдин","Константин",
"Сумерки","Логан","Обливион","Трон","Спартак"};
    string[] Level2Passwords = {"Мулан","Аладдин","Бемби","Храбрая","Моана",
"Тарзан","Пиноккио","Геркулес","Рапунцель","Динозавр",
"Золушка","Покахонтас","Дамбо","Русалочка","Фантазия",
"Питер","Лука","Рая","Энканто","Аристокаты"};
    string[] Level3Passwords = {"Портал","Дум","Майнкрафт","Овервотч","Фортнайт",
"Киберпанк","Террария","Халф-Лайф","Квейк","Старкрафт",
"Варкрафт","Диабло","Фаркрай","Биошок","Валорант",
"Дестини","Прей","Стрей","Инсайд","Хадес"};
 

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
        Terminal.WriteLine("Введите '0' - Закрыть игру");
        Terminal.WriteLine("Введите '1' - Категория фильмы");
        Terminal.WriteLine("Введите '2' - Категория мультфильмы");
        Terminal.WriteLine("Введите '3' - Категория игры");
        Terminal.WriteLine("Ваш выбор:");
    }

    void OnUserInput(string input) 
    {
        if (input == "0")
        {
            Application.Quit();
            #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
            #endif
            return; 
        }
        if (input == "меню")
        {
            ShowMainMenu("рад снова тебя видеть");
        }
        else if (currentScreen == Screen.MainMenu)
        {
            RunMainMenu (input);
        }
        else if (input == "ок")
        {
            GameStart ();
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
                    Terminal.WriteLine("Вы угадали игру, поздравляем!");
                    Terminal.WriteLine(" ");
                break;
        }
        Terminal.WriteLine(menuHint);
        Terminal.WriteLine("Или введите 'ок' чтобы играть еще!");
    }

    void GameStart ()
    {
        Terminal.ClearScreen();
        currentScreen = Screen.Password;
        Terminal.WriteLine(menuHint);
        
        switch(level)
        {
            case 1:
                    password = Level1Passwords[UnityEngine.Random.Range(0, Level1Passwords.Length)];
                    Terminal.WriteLine("Приветствуем в категории Фильмы!");
                    Terminal.WriteLine("Какое название тут зашифровано?");
                    Terminal.WriteLine(" ");
                    Terminal.WriteLine("Подсказка: "+password.Anagram());
                    Terminal.WriteLine(" ");
                break;
            case 2:
                    password = Level2Passwords[UnityEngine.Random.Range(0, Level2Passwords.Length)];
                    Terminal.WriteLine("Приветствуем в категории Мультфильмы!");
                    Terminal.WriteLine("Какое название тут зашифровано?");
                    Terminal.WriteLine(" ");
                    Terminal.WriteLine("Подсказка: "+password.Anagram());
                    Terminal.WriteLine(" ");
                break;
            case 3:
                    password = Level3Passwords[UnityEngine.Random.Range(0, Level3Passwords.Length)];
                    Terminal.WriteLine("Приветствуем в категории игры!");
                    Terminal.WriteLine("Какое название тут зашифровано?");
                    Terminal.WriteLine(" ");
                    Terminal.WriteLine("Подсказка: "+password.Anagram());
                    Terminal.WriteLine(" ");
                break;
            default:
                Debug.LogError("Такого уровня не существует!");
                break;
        }
        Terminal.WriteLine ("Введите зашифрованное название:");
    }
}

