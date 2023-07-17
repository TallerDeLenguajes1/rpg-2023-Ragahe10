using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using EspacioPersonaje;
using API;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace EspacioCombates;


public static class Combates{
    public static List<Personaje> Sorteo(List<Personaje> listaP){
        var Comb = new List<Personaje>();
        var random = new Random();
        Personaje p;
        while(listaP.Count()!=0){
            p = listaP[random.Next(0,listaP.Count())];
            Comb.Add(p);
            listaP.Remove(p);
        }
        return Comb;
    }
    public static void EscribirMensaje(string message){
        for (int i = 0; i < message.Length; i++)
        {
            Console.Write(message[i]);
            Thread.Sleep(50); // Retardo de 100 milisegundos entre cada carácter
        }
        Console.WriteLine();
    }
    public static Personaje PeleaIndividual(Personaje p1, Personaje p2){
        //Guardar datos iniciales{
        Personaje auxp1 = new Personaje(), auxp2 = new Personaje();
        auxp1.Nombre = p1.Nombre;
        auxp1.Apodo = p1.Apodo;
        auxp1.Edad = p1.Edad;
        auxp1.Nivel = p1.Nivel;
        auxp1.Especial = p1.Especial;
        auxp1.FechaDeNacimiento = p1.FechaDeNacimiento;
        auxp1.Tipo = p1.Tipo;
        auxp1.Salud = p1.Salud;
        auxp1.Fuerza = p1.Fuerza;
        auxp1.Destreza = p1.Destreza;
        auxp1.Velocidad = p1.Velocidad;
        auxp1.Energia = p1.Energia;
        auxp1.Armadura = p1.Armadura;

        auxp2.Nombre = p2.Nombre;
        auxp2.Apodo = p2.Apodo;
        auxp2.Edad = p2.Edad;
        auxp2.Nivel = p2.Nivel;
        auxp2.Especial = p2.Especial;
        auxp2.FechaDeNacimiento = p2.FechaDeNacimiento;
        auxp2.Tipo = p2.Tipo;
        auxp2.Salud = p2.Salud;
        auxp2.Fuerza = p2.Fuerza;
        auxp2.Destreza = p2.Destreza;
        auxp2.Velocidad = p2.Velocidad;
        auxp2.Energia = p2.Energia;
        auxp2.Armadura = p2.Armadura;
        //}
        Conductor.CrearConductor();
        List<string>? CondDatos = Conductor.DatosConductor();
        EscribirMensaje("- Damos la bienvenida a todos a la Arena de Mad War!!...");
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
        }
        //
        EscribirMensaje("- Hoy contemplaremos una pelea de 1 vs 1...");
        Console.ReadKey();
        Console.Clear();
        if(CondDatos != null){
            EscribirMensaje("En la ciudad de "+CondDatos[2]+"...");
            Console.ReadKey();
            Console.Clear();
        }
        EscribirMensaje("- Un combate a 5 rondas, con un solo ganador...");
        Console.ReadKey();
        Console.Clear();
        string aux = "- A mi izquierda tenemos a ..." + p1.Nombre.ToUpper() +", "+ p1.Apodo.ToUpper();
        EscribirMensaje(aux);
        aux = "- Del otro lado está ..." + p2.Nombre.ToUpper() +", "+ p2.Apodo.ToUpper();
        EscribirMensaje(aux);
        Console.ReadKey();
        Console.Clear();
        EscribirMensaje("- AHORA... Demos inicio al combate en ...");
        Console.ReadKey();
        Console.Clear();
        EscribirMensaje("- 3...");
        Console.ReadKey();
        Console.Clear();
        EscribirMensaje("- 2...");
        Console.ReadKey();
        Console.Clear();
        EscribirMensaje("- 1... A PELEAR!!");
        Console.ReadKey();

        int i=1;
        while(auxp1.Salud >0 && auxp2.Salud > 0 && i<6){
            Console.Clear();
            Console.WriteLine("                ╔═════════╗                 ");
            Console.WriteLine("                ║ RONDA "+i+" ║                 ");
            Console.WriteLine("                ╚═════════╝                 ");
            System.Console.WriteLine("->"+auxp1.Nombre+", "+auxp1.Apodo);
            System.Console.WriteLine("   - TIPO:"+auxp1.Tipo);
            System.Console.WriteLine("   - SALUD:"+auxp1.Salud);
            System.Console.WriteLine("");
            System.Console.WriteLine("->"+auxp2.Nombre+", "+auxp2.Apodo);
            System.Console.WriteLine("   - TIPO:"+auxp2.Tipo);
            System.Console.WriteLine("   - SALUD:"+auxp2.Salud);
            Console.ReadKey();
            if(auxp1.Velocidad>auxp2.Velocidad){
                AtaqueManual(auxp1,auxp2);
                Console.ReadKey();
                if(auxp2.Salud>0){
                    Ataque(auxp2,auxp1, true);
                }
            }else{
                Ataque(auxp2,auxp1, true);
                Console.ReadKey();
                if(auxp1.Salud>0){
                    AtaqueManual(auxp1,auxp2);
                }
            }
            Pasiva(auxp1,true);
            Pasiva(auxp2,true);
            Console.ReadKey();
            i++;
        }
        if(auxp1.Salud<0 || auxp2.Salud<0){
            EscribirMensaje("- TENEMOS GANADOR!! Por un claro nocaut");
            Console.ReadKey();
            Console.Clear();
            if(auxp1.Salud>0){
                return p1;
            }else{
                return p2;
            }
        }else{
            EscribirMensaje("- Sorprendentemente ambos siguen en pie...");
            Console.ReadKey();
            Console.Clear();
            EscribirMensaje("- Pero los datos nos dan un solo ganador...");
            Console.ReadKey();
            Console.Clear();
            if(PorcentajeSalud(p1.Salud,auxp1.Salud)<PorcentajeSalud(p2.Salud,auxp2.Salud)){
                return p2;
            }else{
                return p1;
            }
        }
    }
    public static float PorcentajeSalud(float SaludIni, float SaludFin){
        return ((SaludFin*100)/SaludIni);
    }
    public static void AtaqueManual(Personaje p1, Personaje p2){
        int pos = 1, op = 0;
        ConsoleKeyInfo aux;
        float daño=0;
        string especial = p1.Centrar(p1.Especial+"(-4)",23);
        do{
            Console.Clear();
            Console.WriteLine("╔══════════════════════════════════════════╗");
            Console.WriteLine("║              ╔══════════╗                ║");
            Console.WriteLine("║              ║ TÚ TURNO ║                ║");
            Console.WriteLine("║              ╚══════════╝                ║");
            Console.WriteLine("║"+p1.Centrar("ENERGÍA: "+p1.Energia,42)+"║");
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
            aux = Console.ReadKey();
            if(aux.Key == ConsoleKey.Enter){
            switch (pos){
                case 1:
                    if(p1.Energia>1){
                        p1.Energia -=2;
                        daño = DañoProvocado(p1,(p2.Armadura*p2.Velocidad), true);
                        p2.Salud = p2.Salud - daño;
                    }
                    op = 1;
                    break;
                case 2:
                    p1.Armadura += 1;
                    p1.Energia +=2;
                    op = 2;
                    break;
                case 3:
                    if(p1.Energia>3){
                            if(p1.Especial == "Escudo protector" || p1.Especial == "Flecha anestésica" || p1.Especial == "Frío envolvente" || p1.Especial == "Vendas"){
                            p1.Energia -= 4;
                            p1.Armadura += 2; 
                            p1.Salud += 10;
                        }else{
                            daño = DañoProvocado(p1,(p2.Armadura*p2.Velocidad), true)*1.30f;
                            p2.Salud = p2.Salud - daño;
                            p1.Energia = p1.Energia - 4;
                        }
                    }
                    op = 3;
                    break;
            }
            }else if(aux.Key == ConsoleKey.DownArrow){
                pos++;
            }else if(aux.Key == ConsoleKey.UpArrow){
                pos--;
            }
            if(pos<1){
                pos = 1;
            }else if(pos>3){
                pos = 3;
            }
        }while(op!= pos);
    }
    public static void Ataque(Personaje p1, Personaje p2, bool comentarios){
        var valor = new Random();
        float daño;
        switch(valor.Next(1,11)){
            case 1://Ataque normal
            case 2:
            case 3:
            case 4:
            case 5:
            case 6:
                if(p1.Energia>=2){
                    if(comentarios){
                        EscribirMensaje(p1.Nombre + ", hizo un ataque normal");
                    }
                    daño = DañoProvocado(p1,(p2.Armadura*p2.Velocidad),comentarios);
                    p2.Salud = p2.Salud - daño;
                    p1.Energia = p1.Energia - 2;
                }else{
                    if(comentarios){
                        System.Console.WriteLine(p1.Nombre + ", no tiene energias para su ataque normal");   
                    }
                }
                break;
            case 7://defensa
            case 8:
            case 9:
                p1.Armadura += 1;
                p1.Energia +=2;
                if(comentarios){
                    System.Console.WriteLine(p1.Nombre + ", aumentó su defensa");        
                }
                break;
            case 10://Habilidad especial
                if(p1.Energia>=4){
                    if(comentarios){   
                        System.Console.WriteLine(p1.Nombre + ", usó su habilidad especial");
                    }
                    if(p1.Especial == "Escudo protector" || p1.Especial == "Flecha anestésica" || p1.Especial == "Frío envolvente" || p1.Especial == "Vendas"){
                        p1.Energia -= 4;
                        p1.Armadura += 2; 
                        p1.Salud += 10;
                    }else{
                        daño = DañoProvocado(p1,(p2.Armadura*p2.Velocidad),comentarios)*1.30f;
                        p2.Salud = p2.Salud - daño;
                        p1.Energia = p1.Energia - 4;
                    }
                }else{
                    if(comentarios){   
                        System.Console.WriteLine(p1.Nombre + ", no tiene energias para su ataque especial");
                    }
                }
                break;
         }
    }
    public static void Pasiva(Personaje p, bool comentarios){
        var valor = new Random();
        if(valor.Next(1,6)==1){
            if(p.Tipo!=null){
                string tipo = p.Tipo.Split(",")[0];
                if(comentarios){
                    EscribirMensaje(p.Nombre + ", pudo usar su pasiva como "+ tipo);
                }
                switch (tipo){
                    case "Humano":
                        p.Armadura += 1;
                        break;
                    case "Elfo":
                        p.Velocidad += 1;
                        break;
                    case "Orco":
                        p.Fuerza += 1;
                        break;
                    case "Muerto Viviente":
                        p.Salud += 10;
                        break;
                }
            }
        }
    }
    public static Personaje CombateAuto(Personaje p1, Personaje p2){
        var valor = new Random();
        Personaje auxp1 = new Personaje(), auxp2 = new Personaje();
        auxp1.Nombre = p1.Nombre;
        auxp1.Apodo = p1.Apodo;
        auxp1.Edad = p1.Edad;
        auxp1.Nivel = p1.Nivel;
        auxp1.Especial = p1.Especial;
        auxp1.FechaDeNacimiento = p1.FechaDeNacimiento;
        auxp1.Tipo = p1.Tipo;
        auxp1.Salud = p1.Salud;
        auxp1.Fuerza = p1.Fuerza;
        auxp1.Destreza = p1.Destreza;
        auxp1.Velocidad = p1.Velocidad;
        auxp1.Energia = p1.Energia;
        auxp1.Armadura = p1.Armadura;

        auxp2.Nombre = p2.Nombre;
        auxp2.Apodo = p2.Apodo;
        auxp2.Edad = p2.Edad;
        auxp2.Nivel = p2.Nivel;
        auxp2.Especial = p2.Especial;
        auxp2.FechaDeNacimiento = p2.FechaDeNacimiento;
        auxp2.Tipo = p2.Tipo;
        auxp2.Salud = p2.Salud;
        auxp2.Fuerza = p2.Fuerza;
        auxp2.Destreza = p2.Destreza;
        auxp2.Velocidad = p2.Velocidad;
        auxp2.Energia = p2.Energia;
        auxp2.Armadura = p2.Armadura;

        int rond =1;
        while(auxp1.Salud>0 && auxp2.Salud>0 && rond <6){
            if(auxp1.Velocidad>auxp2.Velocidad){
                Ataque(auxp1,auxp2,false);
                if(auxp2.Salud>0){
                    Ataque(auxp2,auxp1,false);
                }
            }else{
                Ataque(auxp2,auxp1, false);
                if(auxp1.Salud>0){
                    Ataque(auxp1,auxp2, false);
                }
            }
            Pasiva(auxp1,false);
            Pasiva(auxp2,false);
            rond++;
        }
        if(auxp1.Salud<0 || auxp2.Salud<0){
            if(auxp1.Salud>0){
                return p1;
            }else{
                return p2;
            }
        }else{
            if(PorcentajeSalud(p1.Salud,auxp1.Salud)<PorcentajeSalud(p2.Salud,auxp2.Salud)){
                return p2;
            }else{
                return p1;
            }
        }
    }
    public static float DañoProvocado(Personaje p1, float defensa, bool comentarios){
        float daño, ataque;
        var efectividad = new Random();
        int efe = efectividad.Next(1,101);
        ataque = p1.Fuerza * p1.Destreza * p1.Nivel;
        daño = ((ataque * efe)- defensa)/200;
        if(comentarios){
            if(efe<30){
                EscribirMensaje("Poco efecivo");
            }else if(efe<70){
                EscribirMensaje("Efectivo");
            }else{
                EscribirMensaje("Super efectivo");
            }
        }
        return daño;
    }
    public static void Torneo(List<Personaje> competidores){
        int i =1, j;
        competidores = Sorteo(competidores);
        while(competidores.Count()>1){
            if(competidores.Count() ==2){
                System.Console.WriteLine("COMBATE FINAL");
            }else{
                System.Console.WriteLine(i+"° Combates");
            }
            i++;
            j=1;
            foreach (var item in competidores)
            {
                System.Console.WriteLine(" "+j+"- "+item.Nombre+", "+item.Apodo+"("+item.Tipo+")");
                if(j%2 == 0){
                    System.Console.WriteLine(" ");
                }
                j++;
            }
            Console.ReadKey();
            competidores = Ganadores(competidores);
        }
        System.Console.WriteLine("EL GANADOR ES ");
        competidores[0].MostrarPersonaje();
        Console.ReadKey();
    }
    public static List<Personaje> Ganadores(List<Personaje> Competidores){
        var resultados = new List<Personaje>();
        while(Competidores.Count()>0){
            if(Competidores.Count()>1){
                resultados.Add(CombateAuto(Competidores[0],Competidores[1]));
                Competidores.Remove(Competidores[0]);
                Competidores.Remove(Competidores[0]);
            }else{
                resultados.Add(Competidores[0]);
                Competidores.Remove(Competidores[0]);
            }
        }
        return resultados;
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