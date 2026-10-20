using Microsoft.AspNetCore.Mvc;

namespace ProgramasFacpya.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class Operador : ControllerBase
{
    [HttpGet("Suma/{Numero1:int}/{Numero2:int}")]
    public IActionResult Suma(int Numero1, int Numero2)
    {
        return Ok(Numero1 + Numero2);
    }

    [HttpGet("Resta/{Numero1:int}/{Numero2:int}")]
    public IActionResult Resta(int Numero1, int Numero2)
    {
        return Ok(Numero1 - Numero2);
    }

    [HttpGet("Multiplicacion/{Numero1:int}/{Numero2:int}")]
    public IActionResult Multiplicacion(int Numero1, int Numero2)
    {
        return Ok(Numero1 * Numero2);
    }

    [HttpGet("Promedio/{Numero1:int}/{Numero2:int} {Numero3:int}")]
    public IActionResult Promedio(int Numero1, int Numero2, int Numero3)
    {
        return Ok((Numero1 + Numero2 + Numero3) / 3.0);
    }

    [HttpGet("Cuadrado de un numero/{Numero:int}")]
    public IActionResult Cuadrado(int Numero)
    {
        return Ok(Numero * Numero);
    }

    [HttpGet("Area de un cuadrado/{Lado:int}")]
    public IActionResult Area(int Lado)
    {
        return Ok(Lado * Lado);
    }

    [HttpGet("Perimetro de un cuadrado/{Lado:int}")]
    public IActionResult Perimetro(int Lado)
    {
        return Ok(Lado * 4);
    }

    [HttpGet("Area de un circulo/{Radio:int}")]

    public IActionResult AreaCirculo(int Radio)
    {
        return Ok (Math.PI * Radio * Radio);
    }

    [HttpGet("Perimetro de un circulo/{Radio:int}")]

    public IActionResult PerimetroCirculo(int Radio)
    {
        return Ok(2 * Math.PI * Radio);
    }

    [HttpGet("Area de un triangulo/{Base:int}/{Altura:int}")]
    public IActionResult AreaTriangulo(int Base, int Altura)
    {
        return Ok(0.5 * Base * Altura);
    }

    [HttpGet("Area de un rectangulo/{Base:int}/{Altura:int}")]

    public IActionResult AreaRectangulo(int Base, int Altura)
    {
        return Ok(Base * Altura);
    }

}