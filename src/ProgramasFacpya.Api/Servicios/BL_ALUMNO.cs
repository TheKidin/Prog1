namespace ProgramasFacpya.Api.Servicios;

public class BL_ALUMNO
{
    public static List<string>Validaciones(string P_Nombre, string P_APaterno, string P_AMaterno)
    {
        List<string> lstErrores = [];
        if (P_Nombre.Replace(" ", "").Length <3)
            lstErrores.Add("El nombre debe tener al menos 3 caracteres");

        if (ValidarTexto(P_Nombre))
            lstErrores.Add("El nombre no debe contener caracteres especiales");

        if (P_APaterno.Replace(" ", "").Length <3)
            lstErrores.Add("El apellido paterno debe tener al menos 3 caracteres");

        if (ValidarTexto(P_APaterno))
            lstErrores.Add("El apellido paterno no debe contener caracteres especiales");

        if (P_AMaterno.Replace(" ", "").Length <3)
            lstErrores.Add("El apellido materno debe tener al menos 3 caracteres");

        if (ValidarTexto(P_AMaterno))
            lstErrores.Add("El apellido materno no debe contener caracteres especiales");

        return lstErrores;
    }
    

    private static bool ValidarTexto (string Texto)
    {
        bool IsActivo = false;
        foreach (char Letra in Texto.Replace(" ", ""))
        {
            if (!char.IsLetter(Letra))
            {
                IsActivo = true;
                break;
            }
        }
        return IsActivo;
    }
}
