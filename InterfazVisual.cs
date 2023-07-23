using EspacioPersonaje;
using EspacioCombates;
namespace InterfasVisual;
public static class Interfas{
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
                                var win =Combates.PeleaIndividual(player1, oponente);
                                win.MostrarPersonaje();
                                if(player1.Nombre==win.Nombre){
                                    Combates.EscribirMensaje("GANASTE!");
                                }else{
                                    Combates.EscribirMensaje("PERDISTE :(");
                                }
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
    static int ElegirPersonaje(List<Personaje> listaP){
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
            Conductor.CrearConductor();
            List<string>? CondDatos = Conductor.DatosConductor();
            Combates.EscribirMensaje("- Bienvenido a la Arena de 'Mad War'...");
            Console.ReadKey();
            Console.Clear();
            // presentacion del anfitrion
            if(CondDatos != null){
                if(CondDatos[1] == "male"){
                    Combates.EscribirMensaje("- Mi nombre es "+CondDatos[0]+" y seré su conductor esta noche...");
                }else{
                    Combates.EscribirMensaje("- Mi nombre es "+CondDatos[0]+" y seré su conductora esta noche ");
                }
                Console.ReadKey();
                Console.Clear();
                Combates.EscribirMensaje("- El estadio está en "+CondDatos[2]+"...");
                Console.ReadKey();
                Console.Clear();
            }
            Combates.EscribirMensaje("- El modo torneo sirve para ver, en condiciones azarosas, quien es mejor...");
            Console.ReadKey();
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
                        Combates.Torneo(lp);
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