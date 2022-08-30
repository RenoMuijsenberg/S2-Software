int lengthArray = 3;

bool[] lamp = new bool[lengthArray];

for (int i = 0; i < lengthArray; i++)
{
    lamp[i] = false;
}

CheckAlgoritme();

void CheckLights()
{
    for (int i = 0; i < lamp.Length; i++)
    {
        if (lamp[i] == false)
        {
            Console.WriteLine("False");
        }
        else if(lamp.Length -1 == i)
        {
            Console.WriteLine("True");
        }
    }
}

void TurnOnLights(int index)
{
    Console.WriteLine("Turn on lights");
    //Turn on/off index of light
    if (lamp[index] == false)
    {
        lamp[index] = true;
    }
    else
    {
        lamp[index] = false;
    }

    //Als index + 1 groter is dan lengte array wordt de index 0 anderds index +1
    if (index + 1 > lamp.Length -1)
    {
        if (lamp[0] == false)
        {
            lamp[0] = true;
        }
        else
        {
            lamp[0] = false;
        }
    }
    else
    {
        if (lamp[index + 1] == false)
        {
            lamp[index +1] = true;
        }
        else
        {
            lamp[index + 1] = false;
        }
    }

    //Als index -1 is dan wordt die laatste van array anders pak index -1
    if (index - 1 < 0)
    {
        if (lamp[lamp.Length - 1] == false)
        {
            lamp[lamp.Length -1] = true;
        }
        else
        {
            lamp[lamp.Length -1] = false;
        }
    }
    else
    {
        if (lamp[index -1] == false)
        {
            lamp[index -1] = true;
        }
        else
        {
            lamp[index -1] = false;
        }
    }
}

void CheckAlgoritme()
{        
    Console.WriteLine(lamp.Length);
    Console.WriteLine((lamp.Length - 1) % 3 == 0);
    if (lamp.Length % 3 == 0)
    {
        Console.WriteLine("bocen");
        DivideByThreeAlgoritme();
    }
    else if ((lamp.Length - 1) % 3 == 0)
    {
        DivideByThreePlusOne();
    }
    else
    {
        DivideByThreePlusTwo();
    }
}

void DivideByThreeAlgoritme()
{
    for (int j = 0; j < lamp.Length; j++)
    {
        TurnOnLights(j);
    }
     
    CheckLights();
}

void DivideByThreePlusOne()
{
    for (int j = 0; j < lamp.Length; j++)
    {
        TurnOnLights(j);
    }
    
    CheckLights();
}

void DivideByThreePlusTwo()
{
     for (int j = 0; j < lamp.Length; j++)
     {
         TurnOnLights(j);
     }
     
     CheckLights();
}

for (int i = 0; i < lamp.Length; i++)
{
    Console.WriteLine(lamp[i]);
}