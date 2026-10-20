using Microsoft.AspNetCore.Mvc;

namespace ProgramasFacpya.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class Practica : ControllerBase
{
    //Realizar un programa que determine si un numero es mayor a 0, menor a 0 o igual a 0

    [HttpPost] 
    public IActionResult DeterminarNumeros([FromBody] int numero)
    {
        if (numero > 0)
        {
          return Ok("El numero es mayor a 0");
        }
        else if (numero < 0) 
        {
            return Ok ("El numero es menor a 0");
        }
        else
        {
            return Ok("El numero es igual a 0");
        }
    }


    // Realizar un programa que genere el promedio de 5 materias que el usuario ingrese.*Nota: Si el promedio esta entre 60 y 100,debe de indicar que el estudiante APOROBO el semestre, de lo contrario indicar que No APROBO

    [HttpPost("Promedio")]
    public IActionResult Promedio([FromBody] List<int> calificaciones)
    {
        if (calificaciones.Count != 5)
        {
            return BadRequest("Debe Ingresar exactamente 5 calificaciones.");
        }
        double promedio = calificaciones.Average();
        if (promedio >= 60 && promedio <= 100)
        {
            return Ok("El estudiante APROBO el semestre.");
        }
        else
        {
            return Ok("El estudiante No APROBO el semestre.");
        }
    }
      //Realizar un programa que permita leer tres valores y almacenarlos en variables Num1, Num2 y Num3
      //El programa debe de imprimir cual es el mayor Recuerde constatar que los 3 valores introducidos por el teclado sean valores distintos
    [HttpPost("LeerValores")]
    public IActionResult LeerValores([FromBody] List<int> valores)
    {
        if (valores.Count != 3)
        {
            return BadRequest("Debe Ingresar exactamente 3 valores.");
        }
        if (valores.Distinct().Count() != 3)
        {
            return BadRequest("Los valores deben ser distintos.");
        }
        int mayor = valores.Max();
        return Ok($"El valor mayor es: {mayor}");
    }

    //Ingresar por el tecaldo 3 numeros enteros y mostrar el numero menor de los 3 numeros ingresados
    [HttpPost("NumeroMenor")]
    public IActionResult NumeroMenor([FromBody] List<int> numeros)
    {
        if (numeros.Count != 3)
        {
            return BadRequest("Debe Ingresar exactamente 3 numeros.");
        }
        int menor = numeros.Min();
        return Ok($"El numero menor es: {menor}");
    }

    // realizar un progrma que le pida un valor numerico e indique si es par o impar

    [HttpPost("ParImpar")]
    public IActionResult ParImpar([FromBody] int numero)
    {
        if (numero % 2 == 0)
        {
            return Ok ("El numero es par");
        }
        else
        {
            return Ok ("El numero es impar");
        }

    }

    //realizar un porgrana que determine si una letra ingresada por el teclado es una vocal o no 

    [HttpPost("Vocal")]
    public IActionResult Vocal([FromBody] char letra)
    {
        char LetraMinuscula = char.ToLower(letra);
        if (LetraMinuscula == 'a' || LetraMinuscula == 'e' || LetraMinuscula == 'i' || LetraMinuscula == 'o' || LetraMinuscula == 'u')
        {
            return Ok("La letra es una vocal.");
        }
        else
        {
            return Ok("La letra no es una vocal.");
        }
    }
}