using System.Net;
using EspacioPersonaje;
using EspacioCombates;
using API;
using System.Text.Json;
using System.Text.Json.Serialization;
namespace InterfasVisual;
public static class Interfas{
    public static void EscribirMensaje(string message){
        for (int i = 0; i < message.Length; i++)
        {
            Console.Write(message[i]);
            Thread.Sleep(10); // Retardo de 10 milisegundos entre cada carácter
        }
        Console.WriteLine();
    }

    public static string Centrar(string palabra, int espacios){
        int Blanco = (espacios - palabra.Length)/2;
        string palabraCentrada = palabra.PadLeft(palabra.Length + Blanco);
        palabraCentrada = palabraCentrada.PadRight(espacios);
        return palabraCentrada;
    }
    public static string EspaciadoDer(string frase, int espacios){
        espacios = espacios - frase.Count();
        for (int i = 0; i < espacios; i++){
            frase = frase + " ";
        }
        return frase;
    }
    public static void Presentacion()
    {
        Console.WriteLine("┌─────────────────────────────────────────────────────────────────────────────────────────┐");
        Console.WriteLine("│ ┌───────┐┌───────┐┌──────────┐┌────────┐     ┌───┐        ┌───┐┌──────────┐┌────────┐   │");
        Console.WriteLine("│ │       └┘       ││          ││        └─┐   │   │        │   ││          ││        └─┐ │");
        Console.WriteLine("│ │   ┌──┐  ┌──┐   ││  ┌────┐  ││  ┌───┐   └┐  │   │        │   ││  ┌────┐  ││  ┌───┐   │ │");
        Console.WriteLine("│ │   │  │  │  │   ││  │    │  ││  │   └─┐  │  │   │        │   ││  │    │  ││  │   └┐  │ │");
        Console.WriteLine("│ │   │  │  │  │   ││  │    │  ││  │     │  │  │   │        │   ││  │    │  ││  │   ┌┘  │ │");
        Console.WriteLine("│ │   │  │  │  │   ││  └────┘  ││  │     │  │  │   │  ┌──┐  │   ││  └────┘  ││  └───┘  ┌┘ │");
        Console.WriteLine("│ │   │  └──┘  │   ││  ┌────┐  ││  │     │  │  │   │  │  │  │   ││  ┌────┐  ││       ┌─┘  │");
        Console.WriteLine("│ │   │        │   ││  │    │  ││  │   ┌─┘  │  │   │  │  │  │   ││  │    │  ││  ┌─┐  └─┐  │");
        Console.WriteLine("│ │   │        │   ││  │    │  ││  └───┘   ┌┘  │   └──┘  └──┘   ││  │    │  ││  │ └─┐  └┐ │");
        Console.WriteLine("│ │   │        │   ││  │    │  ││        ┌─┘   │       ┌┐       ││  │    │  ││  │   └┐  │ │");
        Console.WriteLine("│ └───┘        └───┘└──┘    └──┘└────────┘     └───────┘└───────┘└──┘    └──┘└──┘    └──┘ │");
        Console.WriteLine("└─────────────────────────────────────────────────────────────────────────────────────────┘");
        Console.WriteLine("                                 >>press ENTER to start<<");
        Console.ReadKey();
        Console.Clear();
    }
    public static void Menu(PersonajesJson pjson, FabricaDePersonaje fp){
        ConsoleKeyInfo key;
        int option = 1, salida=0;
        
        do{
            Console.WriteLine("╔══════════════════════════════════════════╗");
            Console.WriteLine("║                                          ║");
            Console.WriteLine("║                 ╔══════╗                 ║");
            Console.WriteLine("║                 ║INICIO║                 ║");
            Console.WriteLine("║                 ╚══════╝                 ║");
            Console.WriteLine("║         ┌─────────────────────┐          ║");
            if(option == 1){
                Console.WriteLine("║        ►│ .      Jugar      . │◄         ║");
            }else{
                Console.WriteLine("║         │ .      Jugar      . │          ║");
            }
            Console.WriteLine("║         ├─────────────────────┤          ║");
            if(option == 2){
                Console.WriteLine("║        ►│ .    Personajes   . │◄         ║");
            }else{
                Console.WriteLine("║         │ .    Personajes   . │          ║");
            }
            Console.WriteLine("║         ├─────────────────────┤          ║");
            if(option == 3){
                Console.WriteLine("║        ►│ .      SALIR      . │◄         ║");
            }else{
                Console.WriteLine("║         │ .      SALIR      . │          ║");
            }
            Console.WriteLine("║         └─────────────────────┘          ║");
            Console.WriteLine("║                                          ║");
            Console.WriteLine("║                                          ║");
            Console.WriteLine("║         ©Copyright El PricuQuicu         ║");
            Console.WriteLine("╚══════════════════════════════════════════╝");
            key = Console.ReadKey();
            Console.Clear();
            if(key.Key == ConsoleKey.Enter){
                switch (option){
                    case 1:
                        OpJugar(fp,pjson);
                        break;
                    case 2:
                        OpPersonajes(fp,pjson);
                        break;
                    case 3:
                        salida = 3;
                        break;
                }
            }else if(key.Key == ConsoleKey.DownArrow){
                option++;
            }else if(key.Key == ConsoleKey.UpArrow){
                option--;
            }
            if(option<1){
                option = 1;
            }else if(option>3){
                option = 3;
            }
            Console.Clear();
        }while(salida != 3 && key.Key != ConsoleKey.Escape);
    }
    public static void OpJugar(FabricaDePersonaje fp, PersonajesJson pjson){
        ConsoleKeyInfo key;
        List<Personaje>? listaP = new List<Personaje>();
        if(pjson.Existe("Personajes.json")){
            listaP = pjson.LeerPersonajes("Personajes.json");
        }else{
            for (int j = 1; j < 10; j++){
                listaP.Add(fp.CrearPersonaje());
            }
            pjson.GuardarPersonajes(listaP, "Personajes");
        }
        int option = 1, salida=0;
        if(listaP != null){
            do{
                Console.WriteLine("╔══════════════════════════════════════════╗");
                Console.WriteLine("║                                          ║");
                Console.WriteLine("║                ╔═══════╗                 ║");
                Console.WriteLine("║                ║ JUGAR ║                 ║");
                Console.WriteLine("║                ╚═══════╝                 ║");
                Console.WriteLine("║         ┌─────────────────────┐          ║");
                if(option == 1){
                    Console.WriteLine("║        ►│ . Partida  Rápida . │◄         ║");
                }else{
                    Console.WriteLine("║         │ . Partida  Rápida . │          ║");
                }
                Console.WriteLine("║         ├─────────────────────┤          ║");
                if(option == 2){
                    Console.WriteLine("║        ►│ .     Torneo      . │◄         ║");
                }else{
                    Console.WriteLine("║         │ .     Torneo      . │          ║");
                }
                Console.WriteLine("║         ├─────────────────────┤          ║");
                if(option == 3){
                    Console.WriteLine("║        ►│ .     VOLVER      . │◄         ║");
                }else{
                    Console.WriteLine("║         │ .     VOLVER      . │          ║");
                }
                Console.WriteLine("║         └─────────────────────┘          ║");
                Console.WriteLine("║                                          ║");
                Console.WriteLine("║                                          ║");
                Console.WriteLine("║         ©Copyright El PricuQuicu         ║");
                Console.WriteLine("╚══════════════════════════════════════════╝");
                key = Console.ReadKey();
                Console.Clear();
                if(key.Key == ConsoleKey.Enter){
                    switch (option){
                        case 1:
                            var ind = ElegirPersonaje(listaP);
                            if(ind >-1){
                                Console.Clear();
                                var player1 = listaP[ind];
                                Personaje oponente;
                                do{
                                    oponente = Combates.Sorteo(listaP)[0];
                                }while(oponente == player1);
                                var win =Combates.PeleaIndividual(player1, oponente, true);
                                Result(win);
                                Console.ReadKey();
                            }
                            break;
                        case 2:
                            ModoTorneo(listaP);
                            break;
                        case 3:
                            salida = 3;
                            break;
                    }
                }else if(key.Key == ConsoleKey.RightArrow || key.Key == ConsoleKey.DownArrow){
                    option++;
                }else if(key.Key == ConsoleKey.LeftArrow || key.Key == ConsoleKey.UpArrow){
                    option--;
                }
                if(option<1){
                    option = 1;
                }else if(option>3){
                    option = 3;
                }
                Console.Clear();
                listaP = pjson.LeerPersonajes("Personajes.json");
                if(listaP ==null){
                    salida = 3;
                }
            }while(salida != 3 && key.Key != ConsoleKey.Escape);
        }
    }
    public static void Result(Personaje win){
        Console.WriteLine("╔════════════════════════════════════════════╗");
        Console.WriteLine("║                ╔═════════╗                 ║");
        Console.WriteLine("║                ║ GANADOR ║                 ║");
        Console.WriteLine("║                ╚═════════╝                 ║");
        win.MostrarPersonaje();
        
    }
    static int ElegirPersonaje(List<Personaje> listaP){
        int i = 0, prim = listaP.Count()-1;
        ConsoleKeyInfo aux;
        int op =1, salida =0;
        do{
            Console.Clear();
            Console.Clear();
            System.Console.WriteLine("╔════════════════════════════════════════════╗");
            System.Console.WriteLine("║          ╔══════════════════════╗          ║");
            System.Console.WriteLine("║          ║   ELEGIR PERSONAJE   ║          ║");
            System.Console.WriteLine("║          ╚══════════════════════╝          ║");
            listaP[i].MostrarPersonaje();
            System.Console.WriteLine("'Usa las flechas (<- ó ->)para cambiar de personaje'");
            System.Console.WriteLine("          ┌─────────────────────┐");
            if(op == 1){
            System.Console.WriteLine("         ►│ .   SELECCIONAR   . │◄");
            }else{
            System.Console.WriteLine("          │ .   SELECCIONAR   . │");
            }
            System.Console.WriteLine("          ├─────────────────────┤");
            if(op == 2){
            System.Console.WriteLine("         ►│ .      SALIR      . │◄");
            }else{
            System.Console.WriteLine("          │ .      SALIR      . │");
            }
            System.Console.WriteLine("          └─────────────────────┘");
            aux = Console.ReadKey(intercept: true);
            if(aux.Key == ConsoleKey.UpArrow){
                op--;
            }else if(aux.Key == ConsoleKey.DownArrow){
                op++;
            }
            if(op<1){
                op = 1;
            }else if(op>2){
                op = 2;
            }
            if(aux.Key == ConsoleKey.RightArrow){
                i++;
            }else if(aux.Key == ConsoleKey.LeftArrow){
                i--;
            }
            if(i<0){
                i = (listaP.Count()-1);
            }else if(i>(listaP.Count()-1)){
                i = 0;
            }
            if(aux.Key == ConsoleKey.Enter){
                if(op==1){
                    return i;
                }else if(op ==2){
                    salida = 1;
                }
            }
        }while(aux.Key != ConsoleKey.Escape && salida !=1);
        return -1;
    }

    public static void ModoTorneo(List<Personaje>? lp){
        if(lp!=null){
            List<string>? CondDatos = Conductor.DatosConductor();
            EscribirMensaje("- Bienvenido a la Arena de 'Mad War'...");
            Console.ReadKey();
            Console.Clear();
            // presentacion del anfitrion
            if(CondDatos != null){
                if(CondDatos[1] == "male"){
                    EscribirMensaje("- Mi nombre es "+CondDatos[0]+" y seré su conductor esta noche...");
                }else{
                    EscribirMensaje("- Mi nombre es "+CondDatos[0]+" y seré su conductora esta noche ");
                }
                Console.ReadKey();
                Console.Clear();
                if(CondDatos[2]!=null){
                    EscribirMensaje("- El estadio está en "+CondDatos[2]+"...");
                    Console.ReadKey();
                    Console.Clear();
                }
            }
            EscribirMensaje("- El modo torneo sirve para ver, en condiciones azarosas, quien es mejor...");
            Console.ReadKey();
            var seleccion = lp[ElegirPersonaje(lp)];
            Console.Clear();
            ConsoleKeyInfo key;
            int option = 1, salida=0;
            
            do{
                Console.WriteLine("╔══════════════════════════════════════════╗");
                Console.WriteLine("║                                          ║");
                Console.WriteLine("║                ╔════════╗                ║");
                Console.WriteLine("║                ║ TORNEO ║                ║");
                Console.WriteLine("║                ╚════════╝                ║");
                Console.WriteLine("║         ┌─────────────────────┐          ║");
                if(option == 1){
                    Console.WriteLine("║        ►│ .     Entrar      . │◄         ║");
                }else{
                    Console.WriteLine("║         │ .     Entrar      . │          ║");
                }
                Console.WriteLine("║         ├─────────────────────┤          ║");
                if(option == 2){
                    Console.WriteLine("║        ►│ .     VOLVER      . │◄         ║");
                }else{
                    Console.WriteLine("║         │ .     VOLVER      . │          ║");
                }
                Console.WriteLine("║         └─────────────────────┘          ║");
                Console.WriteLine("║                                          ║");
                Console.WriteLine("║                                          ║");
                Console.WriteLine("║         ©Copyright El PricuQuicu         ║");
                Console.WriteLine("╚══════════════════════════════════════════╝");
                key = Console.ReadKey();
                Console.Clear();
                if(key.Key == ConsoleKey.Enter){
                    if(option==1){
                        Combates.Torneo(lp, seleccion);
                    }
                    salida = 2;
                }else if(key.Key == ConsoleKey.RightArrow || key.Key == ConsoleKey.DownArrow){
                    option++;
                }else if(key.Key == ConsoleKey.LeftArrow || key.Key == ConsoleKey.UpArrow){
                    option--;
                }
                if(option<1){
                    option = 1;
                }else if(option>2){
                    option = 2;
                }
                Console.Clear();
            }while(salida != 2 && key.Key != ConsoleKey.Escape);
        }
    }

    public static void OpPersonajes(FabricaDePersonaje fp, PersonajesJson pjson){
        List<Personaje>? listaP = new List<Personaje>();
        if(pjson.Existe("Personajes.json")){
            listaP = pjson.LeerPersonajes("Personajes.json");
        }else{
            for (int j = 1; j < 10; j++){
                listaP.Add(fp.CrearPersonaje());
            }
            pjson.GuardarPersonajes(listaP, "Personajes");
        }
        if(listaP !=null){
            int i = 0, prim = listaP.Count()-1;
            ConsoleKeyInfo aux;
            int op =1, salida =0;
            do{
                Console.Clear();
                Console.Clear();
                System.Console.WriteLine("╔════════════════════════════════════════════╗");
                System.Console.WriteLine("║          ╔══════════════════════╗          ║");
                System.Console.WriteLine("║          ║  >>> PERSONAJES <<<  ║          ║");
                System.Console.WriteLine("║          ╚══════════════════════╝          ║");
                listaP[i].MostrarPersonaje();
                System.Console.WriteLine("'Usa las flechas (<- ó ->)para cambiar de personaje'");
                System.Console.WriteLine("          ┌─────────────────────┐");
                if(op == 1){
                System.Console.WriteLine("         ►│ . Crear Personaje . │◄");
                }else{
                System.Console.WriteLine("          │ . Crear Personaje . │");
                }
                System.Console.WriteLine("          ├─────────────────────┤");
                if(i>prim){
                    if(op == 2){
                    System.Console.WriteLine("         ►│ .      SALIR      . │◄");
                    }else{
                    System.Console.WriteLine("          │ .      SALIR      . │");
                    }
                    System.Console.WriteLine("          ├─────────────────────┤");
                    if(op == 3){
                    System.Console.WriteLine("         ►│ .      BORRAR     . │◄");
                    }else{
                    System.Console.WriteLine("          │ .      BORRAR     . │");
                    }
                    System.Console.WriteLine("          └─────────────────────┘");
                    aux = Console.ReadKey(intercept: true);
                    if(aux.Key == ConsoleKey.UpArrow){
                        op--;
                    }else if(aux.Key == ConsoleKey.DownArrow){
                        op++;
                    }
                    if(op<1){
                        op = 1;
                    }else if(op>3){
                        op = 3;
                    }
                }else{
                    if(op == 2){
                    System.Console.WriteLine("         ►│ .      SALIR      . │◄");
                    }else{
                    System.Console.WriteLine("          │ .      SALIR      . │");
                    }
                    System.Console.WriteLine("          └─────────────────────┘");
                    aux = Console.ReadKey(intercept: true);
                    if(aux.Key == ConsoleKey.UpArrow){
                        op--;
                    }else if(aux.Key == ConsoleKey.DownArrow){
                        op++;
                    }
                    if(op<1){
                        op = 1;
                    }else if(op>2){
                        op = 2;
                    }
                }
                if(aux.Key == ConsoleKey.RightArrow){
                    i++;
                }else if(aux.Key == ConsoleKey.LeftArrow){
                    i--;
                }
                if(i<0){
                    i = (listaP.Count()-1);
                }else if(i>(listaP.Count()-1)){
                    i = 0;
                }
                if(aux.Key == ConsoleKey.Enter){
                    if(op==1){
                        var nuevo = fp.CrearPersonaje();
                        string? name;
                        do{
                            Console.Clear();
                            System.Console.WriteLine("          ╔═══════════════════════╗");
                            System.Console.WriteLine("          ║ >> CREAR PERSONAJE << ║");
                            System.Console.WriteLine("          ╚═══════════════════════╝");
                            System.Console.WriteLine("Ingrese el NOMBRE del Personaje: ");
                            name = Console.ReadLine();
                        }while(name == null || name =="");
                        nuevo.Nombre = name;
                        do{
                            Console.Clear();
                            System.Console.WriteLine("          ╔═══════════════════════╗");
                            System.Console.WriteLine("          ║ >> CREAR PERSONAJE << ║");
                            System.Console.WriteLine("          ╚═══════════════════════╝");
                            System.Console.WriteLine(">>NOMBRE: "+ nuevo.Nombre);
                            System.Console.WriteLine("Ingrese el APODO del Personaje: ");
                            name = Console.ReadLine();
                        }while(name ==null || name =="");
                        nuevo.Apodo = name;
                        listaP.Add(nuevo);
                        Console.Clear();
                    }else if(op ==2){
                        salida = 1;
                    }else if(op==3){
                        listaP.Remove(listaP[i]);
                        op=1;
                        i--;
                    }
                    pjson.GuardarPersonajes(listaP,"Personajes");
                }
            }while(aux.Key != ConsoleKey.Escape && salida !=1);
        }
    }

    public static void Turno(int pos, Personaje p1, string especial){
        Console.WriteLine("╔══════════════════════════════════════════╗");
        Console.WriteLine("║              ╔══════════╗                ║");
        Console.WriteLine("║              ║ TÚ TURNO ║                ║");
        Console.WriteLine("║              ╚══════════╝                ║");
        Console.WriteLine("║"+Interfas.Centrar("ENERGÍA: "+p1.Energia,42)+"║");
        Console.WriteLine("║      ┌───────────────────────────┐       ║");
        if(pos == 1){
            Console.WriteLine("║     »│ .      Atacar(-2)       . │«      ║");
        }else{
            Console.WriteLine("║      │ .      Atacar(-2)       . │       ║");
        }
        Console.WriteLine("║      ├───────────────────────────┤       ║");
        if(pos == 2){
            Console.WriteLine("║     »│ .     Defender(+2)      . │«      ║");
        }else{
            Console.WriteLine("║      │ .     Defender(+2)      . │       ║");
        }
        Console.WriteLine("║      ├───────────────────────────┤       ║");
        if(pos == 3){
            Console.WriteLine("║     »│ ."+especial+". │«      ║");
        }else{
            Console.WriteLine("║      │ ."+especial+". │       ║");
        }
        Console.WriteLine("║      └───────────────────────────┘       ║");
        Console.WriteLine("║                                          ║");
        Console.WriteLine("║                                          ║");
        Console.WriteLine("║         ©Copyright El PricuQuicu         ║");
        Console.WriteLine("╚══════════════════════════════════════════╝");
    }
    public static void Ronda(Personaje p1, Personaje p2, int i){
        Console.WriteLine("                  ╔═════════╗                 ");
        Console.WriteLine("                  ║ RONDA "+i+" ║                 ");
        Console.WriteLine("                  ╚═════════╝                 ");
        Console.WriteLine("   ┌────────────────────────────────────────┐");
        Console.WriteLine("   │"+Centrar(p1.Nombre+", "+p1.Apodo,40)+"│");
        Console.WriteLine("   ├────────────────────────────────────────┤");
        if(p1.Tipo!=null){
            Console.WriteLine("   │  • TIPO : "+EspaciadoDer(p1.Tipo,29)+"│");
        }
        Console.WriteLine("   │  • SALUD: "+EspaciadoDer(p1.Salud.ToString(),29)+"│");
        Console.WriteLine("   │  • ENERG: "+EspaciadoDer(p1.Energia.ToString(),29)+"│");
        Console.WriteLine("   └────────────────────────────────────────┘");
        Console.WriteLine("");
        Console.WriteLine("   ┌────────────────────────────────────────┐");
        Console.WriteLine("   │"+Centrar(p2.Nombre+", "+p2.Apodo,40)+"│");
        Console.WriteLine("   ├────────────────────────────────────────┤");
        if(p2.Tipo!=null){
            Console.WriteLine("   │  • TIPO : "+EspaciadoDer(p2.Tipo,29)+"│");
        }
        Console.WriteLine("   │  • SALUD: "+EspaciadoDer(p2.Salud.ToString(),29)+"│");
        Console.WriteLine("   │  • ENERG: "+EspaciadoDer(p2.Energia.ToString(),29)+"│");
        Console.WriteLine("   └────────────────────────────────────────┘");
    }
    public static void Versus(Personaje p1, Personaje? p2){
        if(p2!=null){
            Console.WriteLine("┌────────────────────────────────────────┐");
            Console.WriteLine("│"+Centrar(p1.Nombre+", "+p1.Apodo,40)+"│");
            if(p1.Tipo!=null){
                Console.WriteLine("│"+Centrar(p1.Tipo,40)+"│");
            }
            Console.WriteLine("└────────────────────────────────────────┘");
            Console.WriteLine("                            ► VS ◄");
            Console.WriteLine("                   ┌────────────────────────────────────────┐");
            Console.WriteLine("                   │"+Centrar(p2.Nombre+", "+p2.Apodo,40)+"│");
            if(p2.Tipo!=null){
                Console.WriteLine("                   │"+Centrar(p2.Tipo,40)+"│");
            }
            Console.WriteLine("                   └────────────────────────────────────────┘");
        }else{
            Console.WriteLine("┌────────────────────────────────────────┐");
            Console.WriteLine("│"+Centrar(p1.Nombre+", "+p1.Apodo,40)+"│");
            if(p1.Tipo!=null){
                Console.WriteLine("│"+Centrar(p1.Tipo,40)+"│");
            }
            Console.WriteLine("└────────────────────────────────────────┘");
        }
        Console.WriteLine("                 >>Clik Enter<<");
        Console.ReadKey();
    }
    public static void Ganador(){
        System.Console.WriteLine("              ╔═════════════╗");
        System.Console.WriteLine("              ║   GANADOR   ║");
        System.Console.WriteLine("              ╚═════════════╝");
    }
}

public static class Conductor{
    public static void CrearConductor(){
        var url = $"https://randomuser.me/api/";
        var request = (HttpWebRequest)WebRequest.Create(url);
        request.Method = "GET";
        request.ContentType = "application/json";
        request.Accept = "application/json";
        try{
            using (WebResponse response = request.GetResponse())
            {
                using (Stream strReader = response.GetResponseStream())
                {
                    if (strReader == null) return;
                    using (StreamReader objReader = new StreamReader(strReader))
                    {
                        string responseBody = objReader.ReadToEnd();
                        //System.Console.WriteLine(responseBody);
                        //Root Pers = JsonSerializer.Deserialize<Root>(responseBody);
                        File.WriteAllText("Conductor.json",responseBody);
                    }
                }
            }
        }
        catch (WebException){
            Console.WriteLine("Problemas de acceso a la API");
        }
    }
    public static List<string>? DatosConductor(){
        Root? datos;
        List<string>? cond = new List<string>();
        string aux;
        if(File.Exists("Conductor.json")){
            string json = File.ReadAllText("Conductor.json");
            datos = JsonSerializer.Deserialize<Root>(json);
            aux = datos.results[0].name.first+" "+datos.results[0].name.last;
            cond.Add(aux);
            cond.Add(datos.results[0].gender);
            aux = datos.results[0].location.city+", "+datos.results[0].location.country;
            cond.Add(aux);
        }
        return cond;
    }
}