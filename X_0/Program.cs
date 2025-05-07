// See https://aka.ms/new-console-template for more information
Console.WriteLine("Добрый день!");
Console.WriteLine("Вы Человек, вы начинаете первым, сейчас вы X");
Console.WriteLine($"Управление: {Environment.NewLine}7 8 9{Environment.NewLine}4 5 6{Environment.NewLine}1 2 3");
char[,] pole= { {'-','-','-'},
                {'-','-','-'},
                {'-','-','-'}};
char igrock = 'X';
Console.WriteLine("Игра НАЧАЛАСЬ!!!");
var maping = new Dictionary<int, (int, int)> { { 7, (0, 0) },{ 8, (0, 1) },{ 9,(0,2)},
                                               { 4, (1, 0) },{ 5, (1, 1) },{ 6,(1,2)},
                                               { 1, (2, 0) },{ 2, (2, 1) },{ 3,(2,2)}};
var rand = new Random();
X_0();
void X_0()
{   
    begin:
    Console.WriteLine(Environment.NewLine +  pole[0, 0] + ' ' + pole[0, 1] + ' ' + pole[0, 2] + Environment.NewLine + pole[1, 0] + ' ' + pole[1, 1] + ' ' + pole[1, 2] + Environment.NewLine +
                        pole[2, 0] + ' ' + pole[2, 1] + ' ' + pole[2, 2]);

    if (igrock == 'X') 
    {


        while (true)
        {
            int hod = ReadKeyFromDebil();
            if (ProvHoda(hod))
            { break; }
            else { Console.WriteLine("Нормально ходи и нормально все будет"); }
        }
        igrock = '0';
        if (Pobeda() == true) {
            Console.WriteLine(Environment.NewLine + pole[0, 0] + ' ' + pole[0, 1] + ' ' + pole[0, 2] + Environment.NewLine + pole[1, 0] + ' ' + pole[1, 1] + ' ' + pole[1, 2] + Environment.NewLine +
                        pole[2, 0] + ' ' + pole[2, 1] + ' ' + pole[2, 2]); Console.WriteLine("КОнец!"); return; }
        if (Continue()==false) { Console.WriteLine("КОнец!"); return; }
    }

    Console.WriteLine(Environment.NewLine + pole[0, 0] + ' ' + pole[0, 1] + ' ' + pole[0, 2] + Environment.NewLine + pole[1, 0] + ' ' + pole[1, 1] + ' ' + pole[1, 2] + Environment.NewLine +
                       pole[2, 0] + ' ' + pole[2, 1] + ' ' + pole[2, 2]);

    if (igrock == '0')
    {
        
        while (true)
        {
            int bot = rand.Next(1, 9);
            if (ProvHoda(bot))
            { break; }
        }
        igrock = 'X';
        if (Pobeda() == true) {
            Console.WriteLine(Environment.NewLine + pole[0, 0] + ' ' + pole[0, 1] + ' ' + pole[0, 2] + Environment.NewLine + pole[1, 0] + ' ' + pole[1, 1] + ' ' + pole[1, 2] + Environment.NewLine +
                        pole[2, 0] + ' ' + pole[2, 1] + ' ' + pole[2, 2]); Console.WriteLine("КОнец!"); return; }
        if (Continue() == false) { Console.WriteLine("КОнец!"); return; }
    }
    goto begin;
}

bool ProvHoda(int hod)
{   
    var dildo = maping[hod];
    if (pole[dildo.Item1,dildo.Item2] == '-')
    {
        pole[dildo.Item1, dildo.Item2] = igrock;
        return true;
    }
    return false;
   
}

//Читать цифру с ввода
int ReadKeyFromDebil()
{
    while (true)
    {
        var readKey = Console.ReadKey(true).KeyChar;
        if (char.IsDigit(readKey))
        {
            Console.WriteLine(readKey);
            return (int)char.GetNumericValue(readKey);
        }
    }
}

//Проверка на победу, если победа, вернет true, иначе вернет false, при побуду напишет в консоль кто выйграл
bool? Pobeda() 
{
    if ((pole[0, 0] == pole[0, 1]) && (pole[0, 1] == pole[0, 2]&& pole[0, 2] != '-'))
    {
        Console.WriteLine("ПОБЕДИЛИЛДА: " + pole[0, 0]);
        return true;
    }
    else if ((pole[1, 0] == pole[1, 1]) && (pole[1, 1] == pole[1, 2] && pole[1, 2] != '-'))
    {
        Console.WriteLine("ПОБЕДИЛИЛДА: " + pole[1, 0]);
        return true;
    }
    else if ((pole[2, 0] == pole[2, 1]) && (pole[2, 1] == pole[2, 2] && pole[2, 2] != '-'))
    {
        Console.WriteLine("ПОБЕДИЛИЛДА: " + pole[2, 0]);
        return true;  
    }
    else if ((pole[0, 0] == pole[1, 1]) && (pole[1, 1] == pole[2, 2] && pole[2, 2] != '-'))
    {
        Console.WriteLine("ПОБЕДИЛИЛДА: " + pole[1, 1]);
        return true;
    }
    else if ((pole[0, 2] == pole[1, 1]) && (pole[1, 1] == pole[2, 0] && pole[2, 0] != '-'))
    {
        Console.WriteLine("ПОБЕДИЛИЛДА: " + pole[1, 1]);
        return true;
    }
    else if ((pole[0, 0] == pole[1, 0]) && (pole[1, 0] == pole[2, 0] && pole[2, 0] != '-'))
    {
        Console.WriteLine("ПОБЕДИЛИЛДА: " + pole[0, 0]);
        return true;
    }
    else if ((pole[0, 1] == pole[1, 1]) && (pole[1, 1] == pole[2, 1] && pole[2, 1] != '-'))
    {
        Console.WriteLine("ПОБЕДИЛИЛДА: " + pole[1, 1]);
        return true;
    }
    else if ((pole[0, 2] == pole[1, 2]) && (pole[1, 2] == pole[2, 2] && pole[2, 2] != '-'))
    {
        Console.WriteLine("ПОБЕДИЛИЛДА: " + pole[2, 2]);
        return true;
    }
    return false;
}

//Если есть куда ходить, то true, если поле забито, то false
bool? Continue()
{
    for (int i = 0; i < 3; i++) 
    {
        for (int j = 0; j < 3; j++)
        {
            if (pole[i, j] == '-')
            { return true; }
        }
    }
    return false;
}

//Чистим поле меняя все символы на пробелы
void PusroPole()
{
    for (int i = 0; i < 3; i++)
    {
        for (int j = 0; j < 3; j++)
        {
            pole[i, j] = '-';
        }
    }
}



