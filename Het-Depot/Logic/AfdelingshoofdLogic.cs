public static class AfdelingshoofdLogic
{
    public static void MenuOptions(string userInput)
    {
        if (userInput == "A")
        {
            BaseLogic.DisplayRondleidingen();
            Program.world.WriteLine("Wilt u een rondleiding:\n[A] Toevoegen\n[B] Verwijderen\n[C] Aanpassen\n[D] Terug");
            string keuze = Program.world.ReadLine()!.ToLower();
            ChangeATour(keuze);
        }
        else if (userInput == "B")
        {
            DisplayCodes();
            Program.world.WriteLine("[A] Leeghalen\n[B] Toevoegen");
            string keuze = Program.world.ReadLine()!.ToUpper();
            if (keuze == "A")
            {
                DataModel.visitorCodes = new List<string>();;
            }
            else if (keuze == "B")
            {
                Program.world.WriteLine("[A] Een voor een [B] code,code,code");
                string keuze2 = Program.world.ReadLine()!.ToUpper();
                if (keuze2 == "A")
                {
                    string code;
                    do
                    {
                        Program.world.WriteLine("Welke code wilt u toevoegen:");
                        code = Program.world.ReadLine()!.ToLower();
                        DataModel.visitorCodes!.Add(code);

                    } while (code != "");
                }
                else if (keuze2 == "B")
                {
                    string codes;
                    do
                    {
                        Program.world.WriteLine("Welke codes wilt u toevoegen: (code,code,code,...)");
                        codes = Program.world.ReadLine()!.ToLower();
                        List<string> visitorCodes = codes.Split(",").ToList();
                        // DataModel.visitorCodes!.Add(code);
                        foreach (string code in visitorCodes)
                        { DataModel.visitorCodes!.Add(code);}

                    } while (codes != "");
                }
            }
        }
        else if (userInput == "C")
        {
            Program.Main();
        }
    }

    public static void ChangeATour(string keuze)
    {
        if (keuze == "a")
        {
            string code;
            do
            {
                Program.world.WriteLine("Voeg een rondleiding toe: (Start,Eindtijd)"); 

                code = Program.world.ReadLine()!;
                if (code == "") { continue; }
                string[] start = code.Split(",");
                if (start.Length < 2 || start.Length > 2)
                {
                    Program.world.WriteLine("Ongeldige hoeveelheid tijden");
                    continue;
                }
                string id = Convert.ToString(Convert.ToInt32(DataModel.listoftours![^1].Id) + 1);
                Tour tourtoadd = new Tour(id, start[0], start[1], null!, null!);
                DataModel.listoftours.Add(tourtoadd);
                // DataModel.visitorCodes!.Add(code);

            } while (code != "");
        }
        if (keuze == "b")
        {
            string code;
            do
            {
                Program.world.WriteLine("Verwijder een rondleiding: (ID)"); 

                code = Program.world.ReadLine()!;
                foreach (Tour tour in DataModel.listoftours!)
                {
                    if (tour.Id == code)
                    {
                        DataModel.listoftours!.Remove(tour);
                        break;
                    }
                }

            } while (code != "");
        }
        if (keuze == "c")
        {
            string code;
            do
            {
                Program.world.WriteLine("kies een rondleiding om aan te passen: (ID)"); 

                code = Program.world.ReadLine()!;
                foreach (Tour tour in DataModel.listoftours!)
                {
                    if (tour.Id == code)
                    {
                        Program.world.WriteLine($"|{tour.Id}|{tour.Start} - {tour.End}\nVoer nieuwe tijden in (start,eind)");
                        string[] times = Program.world.ReadLine()!.Split(",");
                        tour.Start = times[0];
                        tour.End = times[1];
                    }
                }

            } while (code != "");
        }
    }

    public static void DisplayCodes()
    {
        Program.world.WriteLine("Lijst van code op dit moment:");
        foreach (string ccode in DataModel.visitorCodes!)
        {
            Program.world.WriteLine(ccode);
        }
    }
}