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
    Personaje CrearPersonaje(){
        
    }
}
