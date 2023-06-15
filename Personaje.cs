namespace EspacioPersonaje;

public class Personaje{
    //ATRIBUTOS
    //DATOS
    private string? tipo;
    private string? nombre;
    private string? apodo;
    private DateTime fechaDeNacimiento;
    private int edad;
    //CARACTERISTICAS
    private int velocidad;
    private int destreza;
    private int fuerza;
    private int nivel;
    private int armadura;
    private int salud;
    //Propiedades de datos
    public string? Tipo { get => tipo; set => tipo = value; }
    public string? Nombre { get => nombre; set => nombre = value; }
    public string? Apodo { get => apodo; set => apodo = value; }
    public DateTime FechaDeNacimiento { get => fechaDeNacimiento; set => fechaDeNacimiento = value; }
    public int Edad { get => edad; set => edad = value; }
    //Propiedades de Caracteristicas
    public int Velocidad { get => velocidad; set => velocidad = value; }
    public int Destreza { get => destreza; set => destreza = value; }
    public int Fuerza { get => fuerza; set => fuerza = value; }
    public int Nivel { get => nivel; set => nivel = value; }
    public int Armadura { get => armadura; set => armadura = value; }
    public int Salud { get => salud; set => salud = value; }
    //Constructor
    // public Personaje (string tipo, string nombre, string apodo, DateTime Fnac, int edad, int vel, int dezt, int fuerza, int niv, int armad, int salud){
    //     Tipo = tipo;
    //     Nombre = nombre;
    //     Apodo = apodo;
    //     FechaDeNacimiento = Fnac;
    //     Edad = edad;
    //     Velocidad = vel;
    //     Destreza =dezt;
    //     Fuerza = fuerza;
    //     Nivel = niv;
    //     Armadura = armad;
    //     Salud = salud;
    // }
}

public class FabricaDePersonaje{
    public string[] Nombres = {
        "Carlos",
        "Pepe",
        "Juan",
        "Colo",
        "Jose",
        "Rama",
        "Guillo",
        "Gaby",
        "Luciano",
        "Sergio"
    };
    public string[] Apodos = {
        "Tronco",
        "Oso",
        "Pato",
        "La Cabra",
        "Enano",
        "Fideo",
        "La Pulga",
        "Buitre",
        "Neblina",
        "El Profe"
    };
    public Personaje CrearPersonaje(){
        Personaje nuevo = new Personaje();
        Random valor = new Random();
        int anio = valor.Next(1723,2023);
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

        //Datos
        nuevo.Nombre = Nombres[valor.Next(0,9)];
        nuevo.Apodo = Apodos[valor.Next(0,9)];
        nuevo.FechaDeNacimiento = new DateTime(anio, mes, dia);
        nuevo.Edad = CalcularEdad(nuevo.FechaDeNacimiento);
        //Caracteristicas
        
        nuevo.Velocidad = valor.Next(1,11);
        nuevo.Destreza = valor.Next(1,6);
        nuevo.Fuerza = valor.Next(1,11);
        nuevo.Nivel = valor.Next(1,11);
        nuevo.Armadura = valor.Next(1,11);
        nuevo.Salud = 100;

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

