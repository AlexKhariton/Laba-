using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Windows.Automation;
using System.Threading;
using Automation = System.Windows.Automation;
using System.Diagnostics;
using System.Windows.Forms;
using System.Windows.Automation.Provider;

namespace ConsoleApp5
{
    class Program
    {
        static void LogMessage(string s)
        {
            Console.WriteLine("INFO: " + s + "\n");
        }
        static AutomationElement findElementbyName(AutomationElement rootElement, string name)
        {
            Automation.Condition condition = new PropertyCondition(AutomationElement.NameProperty, name);

            LogMessage("Поиск " + name + " ...");
            Thread.Sleep(1000);
            AutomationElement appElement = rootElement.FindFirst(TreeScope.Children, condition);

            return appElement;
        }
        static AutomationElement findElementbyId(AutomationElement rootElement, string id)
        {
            Automation.Condition condition = new PropertyCondition(AutomationElement.AutomationIdProperty, id);

            LogMessage("Поиск " + id + " ...");
            Thread.Sleep(1000);
            AutomationElement appElement = rootElement.FindFirst(TreeScope.Children, condition);

            return appElement;
        }
        static void Automate()
        {
            LogMessage("Getting Root...");
            AutomationElement rootElement = AutomationElement.RootElement;

            if (rootElement != null)
            {
                LogMessage("OK.");

                
                AutomationElement appElement = findElementbyName(rootElement, "Form1");


                if (appElement != null)
                {
                    LogMessage("OK.");

                    AutomationElement panel = findElementbyId(appElement, "panel1");

                    if(panel != null)
                    {
                        Console.WriteLine("Выберите пол.");
                        Console.WriteLine("1 - Мужской");
                        Console.WriteLine("2 - Женский");
                        string tmp = Console.ReadLine();
                        AutomationElement radio = null;
                        switch (tmp)
                        {
                            case "1":
                                radio = findElementbyId(panel, "radioButton1");
                                break;
                            case "2":
                                radio = findElementbyId(panel, "radioButton2");
                                break;
                        }

                        if (radio != null)
                        {
                            SelectionItemPattern selectionItemPattern = radio.GetCurrentPattern(SelectionItemPattern.Pattern) as SelectionItemPattern;
                            selectionItemPattern.Select();
                            LogMessage("OK.");
                        }
                        else
                        {
                            LogMessage("ERROR");
                        }
                    }
                    else 
                    {
                        LogMessage("ERROR");
                    }

                    AutomationElement text_height = findElementbyId(appElement, "textBox1");

                    if (text_height != null)
                    {
                        Console.Write("Введите рост -> ");
                        string str = Console.ReadLine();
                        ValuePattern text = text_height.GetCurrentPattern(ValuePattern.Pattern) as ValuePattern;
                        text.SetValue(str);
                        LogMessage("OK.");
                    }
                    else
                    {
                        LogMessage("ERROR");
                    }

                    AutomationElement text_weight = findElementbyId(appElement, "textBox2");

                    if (text_weight != null)
                    {
                        Console.Write("Введите вес -> ");
                        string str = Console.ReadLine();
                        ValuePattern text = text_weight.GetCurrentPattern(ValuePattern.Pattern) as ValuePattern;
                        text.SetValue(str);
                        LogMessage("OK.");
                    }
                    else
                    {
                        LogMessage("ERROR");
                    }

                    AutomationElement text_age = findElementbyId(appElement, "textBox3");

                    if (text_age != null)
                    {
                        Console.Write("Введите возраст -> ");
                        string str = Console.ReadLine();
                        ValuePattern text = text_age.GetCurrentPattern(ValuePattern.Pattern) as ValuePattern;
                        text.SetValue(str);
                        LogMessage("OK.");
                    }
                    else
                    {
                        LogMessage("ERROR");
                    }

                    Console.WriteLine("Выберите активность.");
                    Console.WriteLine("1 - Низкая");
                    Console.WriteLine("2 - Средняя");
                    Console.WriteLine("3 - Высокая");
                    string temp = Console.ReadLine();
                    AutomationElement radio1 = null;
                    switch (temp)
                    {
                        case "1":
                            radio1 = findElementbyId(appElement, "radioButton3");
                            break;
                        case "2":
                            radio1 = findElementbyId(appElement, "radioButton4");
                            break;
                        case "3":
                            radio1 = findElementbyId(appElement, "radioButton5");
                            break;
                    }

                    if (radio1 != null)
                    {
                        SelectionItemPattern selectionItemPattern = radio1.GetCurrentPattern(SelectionItemPattern.Pattern) as SelectionItemPattern;
                        selectionItemPattern.Select();
                        LogMessage("OK.");
                    }
                    else
                    {
                        LogMessage("ERROR");
                    }

                    AutomationElement button_rez = findElementbyName(appElement, "Расчитать");

                    if (button_rez != null)
                    {
                        InvokePattern but = button_rez.GetCurrentPattern(InvokePattern.Pattern) as InvokePattern;
                        but.Invoke();
                        LogMessage("OK.");
                    }
                    else
                    {
                        LogMessage("ERROR");
                    }
                }
                else
                {
                    LogMessage("ERROR");
                }
            }
        }
        static void Main(string[] args)
        {
            System.Diagnostics.Process.Start("\"C:\\Users\\Александр\\source\\repos\\WinFormsApp1\\WinFormsApp1\\bin\\Debug\\netcoreapp3.1\\WinFormsApp1.exe\"");
            while (true)
            {
                Automate();
            }
        }
    }
}
