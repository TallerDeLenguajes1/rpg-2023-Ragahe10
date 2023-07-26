namespace EspacioPersonaje;
using System.Text.Json;
using System.Text.Json.Serialization;
using InterfasVisual;
public class Personaje{
    //ATRIBUTOS
    //DATOS
    private string? tipo;
    private string? nombre;
    private string? apodo;
    private DateTime fechaDeNacimiento;
    private int edad;
    //CARACTERISTICAS
    private string? especial;
    private float velocidad;
    private float destreza;
    private float fuerza;
    private int nivel;
    private float armadura;
    private float salud;
    private int energia;

    //Propiedades de datos
    public string? Tipo { get => tipo; set => tipo = value; }
    public string? Nombre { get => nombre; set => nombre = value; }
    public string? Apodo { get => apodo; set => apodo = value; }
    public DateTime FechaDeNacimiento { get => fechaDeNacimiento; set => fechaDeNacimiento = value; }
    public int Edad { get => edad; set => edad = value; }
    //Propiedades de Caracteristicas
    public string? Especial { get => especial; set => especial = value; }
    public float Velocidad { get => velocidad; set => velocidad = value; }
    public float Destreza { get => destreza; set => destreza = value; }
    public float Fuerza { get => fuerza; set => fuerza = value; }
    public int Nivel { get => nivel; set => nivel = value; }
    public float Armadura { get => armadura; set => armadura = value; }
    public float Salud { get => salud; set => salud = value; }
    public int Energia { get => energia; set => energia = value; }

    public void MostrarPersonaje(){
        string aux = "¤ " + Nombre + ", "+ Apodo + " ¤";
        string aux3 = "«LVL: " + Nivel + "»";
        string aux2;
        string signo = "<O>";
        if(Tipo != null){
            aux2 = "«" + Tipo.Split(',')[1] + " »";
            switch (Tipo.Split(',')[0]){
            case "Humano":
                signo = "HUM";
            break;
            case "Elfo":
                signo = "ELF";
            break;
            case "Muerto Viviente":
                signo = "MVT";
            break;
            case "Orco":
                signo = "ORC";
            break;
            default:
                signo = "<O>";
            break;
        } 
        }else{
            aux2 = "«" + "" + " »";
        }
        
        System.Console.WriteLine("║┌──────────────────────────────────────────┐║");
        System.Console.WriteLine("║│" +Interfas.Centrar(aux,42) + "│║");
        System.Console.WriteLine("║├──────────────────────────────────────────┤║");
        System.Console.WriteLine("║│" + Interfas.Centrar("Fecha Nac: "+ FechaDeNacimiento.ToShortDateString(),42)+"│║");
        System.Console.WriteLine("║│" + Interfas.Centrar("Edad: "+ Numero(Edad),42)+"│║");
        System.Console.WriteLine("║│" +Interfas.Centrar(aux2,18) + "┌───┐" + Interfas.Centrar(aux3,19) + "│║");
        System.Console.WriteLine("║└─────────────────┐│"+ signo +"│┌──────────────────┘║");
        System.Console.WriteLine("║┌─────────────────┘└───┘└──────────────────┐║");
        System.Console.WriteLine("║│             »CARACTERISTICAS«            │║");
        System.Console.WriteLine("║├──────────────────────────────────────────┤║");
        System.Console.WriteLine("║│              ♥ Vida ♥: "+ Numero(Salud) +"               │║");
        System.Console.WriteLine("║│              ♣ Dest ♣: "+ Numero(Destreza) +"               │║");
        System.Console.WriteLine("║│              ♠ Frza ♠: "+ Numero(Fuerza) +"               │║");
        System.Console.WriteLine("║│              ♦ Velc ♦: "+ Numero(Velocidad) +"               │║");
        System.Console.WriteLine("║│              ◘ Armd ◘: "+ Numero(Armadura) +"               │║");
        System.Console.WriteLine("║│                »ESPECIAL«                │║");
        aux ="< " + Especial + " >";
        System.Console.WriteLine("║│" +Interfas.Centrar(aux,42) + "│║");
        System.Console.WriteLine("║└──────────────────────────────────────────┘║");
        System.Console.WriteLine("╚════════════════════════════════════════════╝");
    }
    
    public void PresentacionCorta(){
        Console.WriteLine("┌────────────────────────────────────────┐");
        Console.WriteLine("│"+Interfas.Centrar(Nombre+", "+Apodo,40)+"│");
        Console.WriteLine("│"+Interfas.Centrar(Tipo,40)+"│");
        Console.WriteLine("└────────────────────────────────────────┘");
    }
    private string Numero(float num){
        string aux;
        if(num<10){
            aux = "  "+num;
        }else{
            if(num<100){
                aux = " "+num;
            }else{
                aux = num.ToString();
            }
        }
        return aux;
    }
}

public class FabricaDePersonaje{
    public string[] Nombres = {
        //HUMANOS
        "Juan","Guillermo", "José", "Miguel", "Ramiro",
        "Alejandro", "Ricardo", "Arturo", "Luis", "Eduardo",
        "Godric", "Gareth", "Leofric","Alfredo", "Baldwin",
        //ORCOS
        "Gorruk", "Grommash", "Morgoth", "Dargor", "Urzog", 
        "Thragg", "Grishnak", "Skarn", "Drekthar", "Gorlog",
        "Zorrok", "Gul'dan", "Morgash", "Drakka", "Narzug",
        //ELFOS
        "Lorindel", "Eldarian", "Elysia", "Caladwen", "Thalorin", 
        "Aerendir", "Ariella", "Celeborn", "Elowen", "Galadriel",
        "Melian", "Nimrodel", "Finwe", "Arwen", "Lindariel",
        //MUERTOS VIVIENTES
        "Morwen", "Aldric", "Seraphine", "Valerian", "Evelina", 
        "Cassius", "Letholdus", "Rowena", "Hadrian", "Helena",
        "Severus", "Lilith", "Necros", "Vespera", "Grimwald"
    };
    public string[] Apodos = {
        //HUMANOS
        "El Bravo", "El León", "El Valiente", "El Justiciero", "El Audaz", 
        "El Caballero", "El Sabio", "El Honorable","El Lobo", "El Intrépido", 
        "El Templario", "El Cruzado", "El Conquistador", "El Fiero", "El Victorioso",
        //ORCOS
        "El Desgarrador", "El Destructor", "El Devorador de Carne", "El Azote", "El Aplastador", 
        "El Despiadado","El Feroz", "El Sanguinario", "El Salvaje", "El Colmillo Negro", 
        "El Vengador", "El Rugido Negro", "El Terror Verde", "El Desollador", "El Inquebrantable",
        //ELFOS
        "El Radiante", "El Susurrante", "El Luminoso", "El Danzante", "El Eterno", 
        "El Cazador de Estrellas", "El Guardián de los Bosques","El Portador de Luz", "El Sabio del monte", "El Vidente", 
        "El Embajador de los Elfos", "El Canción de Luna", "El Bailarín Élfico","El Guardián de los Secretos", "El Celestial",
        //MUERTOS VIVIENTES
        "El Despojado", "El Desangrado", "El Peregrino Oscuro", "El Hambriento", "El Devorador de Almas", "El Espectro",
        "El Desolado", "El Lamento Silencioso", "El Caminante Nocturno", "El Señor de las Sombras", "El Vengador Eterno",
        "El Enjambre de Huesos", "El Susurrante", "El Corazón Helado", "El Infame Desollador", "El Alma Errante"

    };
    public string[] Tipos ={
        "Humano", "Elfo", "Muerto Viviente", "Orco" 
    };
    public string[] roles ={
        "Caballero", "Arquero", "Mago", "Común"
    };
    public string[] Especiales ={
        "Embiste heroico",   "Escudo protector",
        "Lluvia de flechas", "Flecha anestésica",
        "Bola de fuego",     "Frío envolvente",
        "Golpe frenético",   "Vendas"
    };

    public Personaje CrearPersonaje(){
        Personaje nuevo = new Personaje();
        Random valor = new Random();
        nuevo.Tipo = Tipos[valor.Next(0,4)];
        int anio = valor.Next(1723,2024);
        int mes = valor.Next(1,13);
        int dia;
        switch (mes)
        {
            case 1:
            case 3:
            case 5:
            case 7:
            case 8:
            case 10:
            case 12:
                dia = valor.Next(1,32);
                break;
            case 2:
                dia = valor.Next(1,29);
                break;
            default:
                dia = valor.Next(1,31);
                break;
        }
        nuevo.Salud = (float)100;
        //Datos segun e tipo
        switch (nuevo.Tipo){
            case "Humano":
                nuevo.Nombre = Nombres[valor.Next(0,15)];
                nuevo.Apodo = Apodos[valor.Next(0,15)];
                nuevo.Velocidad = (float)valor.Next(1,11);
                nuevo.Destreza = (float)valor.Next(1,6);
                nuevo.Fuerza = (float)valor.Next(1,9);
                nuevo.Armadura = (float)valor.Next(5,11);
                break;
            case "Orco":
                nuevo.Nombre = Nombres[valor.Next(15,30)];
                nuevo.Apodo = Apodos[valor.Next(15,30)];
                nuevo.Velocidad = (float)valor.Next(1,11);
                nuevo.Destreza = (float)valor.Next(1,6);
                nuevo.Fuerza = (float)valor.Next(5,11);
                nuevo.Armadura = (float)valor.Next(1,9);
                break;
            case "Elfo":
                nuevo.Nombre = Nombres[valor.Next(30,45)];
                nuevo.Apodo = Apodos[valor.Next(30,45)];
                nuevo.Velocidad = (float)valor.Next(5,11);
                nuevo.Destreza = (float)valor.Next(1,6);
                nuevo.Fuerza = (float)valor.Next(1,11);
                nuevo.Armadura = (float)valor.Next(1,11);
                nuevo.Salud = (float)valor.Next(90,101);
                break;
            case "Muerto Viviente":
                nuevo.Nombre = Nombres[valor.Next(45,60)];
                nuevo.Apodo = Apodos[valor.Next(45,60)];
                nuevo.Velocidad = (float)valor.Next(1,9);
                nuevo.Destreza = (float)valor.Next(1,6);
                nuevo.Fuerza = (float)valor.Next(1,11);
                nuevo.Armadura = (float)valor.Next(1,11);
                nuevo.Salud += (float)(10*valor.Next(1,6));
                break;
        }
        nuevo.Energia = 10;
        //incremento los campos segun el rol
        string rol = roles[valor.Next(0,4)];
        switch (rol){
            case "Caballero":
                nuevo.Armadura +=(float)2;
                nuevo.Salud +=(float)5;
                nuevo.Especial = Especiales[valor.Next(0,2)];
                break;
            case "Arquero":
                nuevo.Velocidad +=(float)2;
                nuevo.Armadura +=(float)1;
                nuevo.Especial = Especiales[valor.Next(2,4)];
                break;
            case "Mago":
                nuevo.Fuerza += (float)2;
                nuevo.Velocidad +=(float)1;
                nuevo.Especial = Especiales[valor.Next(4,6)];
                break;
            default:
                nuevo.Especial = Especiales[valor.Next(6,8)];
                break;
        }
        nuevo.Tipo = nuevo.Tipo + ", " + rol; 
        //Incremento los campos segun el nivel
        // float campo = 0.25f;
        nuevo.Nivel = valor.Next(1,7);
        // campo = ((nuevo.Nivel)-1)*campo;
        // nuevo.Velocidad += campo;
        // nuevo.Destreza += campo;
        // nuevo.Fuerza += campo;
        // nuevo.Armadura += campo;
        // nuevo.Salud += (float)(((nuevo.Nivel)-1)*5);

        
        nuevo.FechaDeNacimiento = new DateTime(anio, mes, dia);
        nuevo.Edad = CalcularEdad(nuevo.FechaDeNacimiento);
        

        return  nuevo;
    }
    
    public  int CalcularEdad(DateTime fechaNacimiento)
    {
        DateTime fechaActual = DateTime.Now;
        int edad = fechaActual.Year - fechaNacimiento.Year;

        if (fechaActual.Month < fechaNacimiento.Month || (fechaActual.Month == fechaNacimiento.Month && fechaActual.Day < fechaNacimiento.Day))
        {
            edad--;
        }
        return edad;
    }
}

public class PersonajesJson{
    //serializacion
    public void GuardarPersonajes(List<Personaje> lista, string Nombre){
        string json ;
        //var config = new JsonSerializerOptions { WriteIndented = true };
        // foreach (var personaje in lista){
        //     json = json +"\n\r"+JsonSerializer.Serialize(personaje/*, config*/);
        // }
        json = JsonSerializer.Serialize(lista);
        File.WriteAllText(Nombre+".json",json);
    }
    //deserializacion
    public List<Personaje>? LeerPersonajes(string nombreArch){
        List<Personaje>? listPer = null;
        if(Existe(nombreArch)){
            string json = File.ReadAllText(nombreArch);
            listPer = JsonSerializer.Deserialize<List<Personaje>>(json);
        }
        return listPer;
    }
    public bool Existe(string nombreArch){
        return (File.Exists(nombreArch));
    }
}
