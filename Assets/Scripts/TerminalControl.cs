using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerminalControl : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        ShowMainMenu("Слава");
    }

    void ShowMainMenu (string PlayerName)
    {
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
        if (input == "1")
        {
            Terminal.ClearScreen();
            Terminal.WriteLine("Библиотека, серьезно? Попробуй что-то посложнее...");
            Terminal.WriteLine("Введите ОК чтобы продолжить:");
        }

        else if (input == "ОК")
        {
            Terminal.ClearScreen();
            Terminal.WriteLine("В этот раз выбери что-то посложнее.");
            Terminal.WriteLine("Ну что, какой взламываем на этот раз??");
            Terminal.WriteLine(" ");
            Terminal.WriteLine("Введите 1 - городская библиотека");
            Terminal.WriteLine("Введите 2 - полицейский участов");
            Terminal.WriteLine("Введите 3 - космический корабль");
            Terminal.WriteLine("Введите ваш выбор:"); 
        }

        if (input == "2"){
            Terminal.ClearScreen();
            Terminal.WriteLine("В этот раз не лучше... Иди-ка ты спать, а...");
        }
    }
}
