using Microsoft.AspNetCore.Mvc;

namespace ProgramasFacpya.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class OperadorController : ControllerBase
{
    #region Operaciones básicas (3 - 5)

    // 3. Suma de 2 números
    [HttpGet("Suma/{numero1:double}/{numero2:double}")]
    public IActionResult Suma(double numero1, double numero2)
    {
        return Ok(numero1 + numero2);
    }

    // 4. Resta de 2 números
    [HttpGet("Resta/{numero1:double}/{numero2:double}")]
    public IActionResult Resta(double numero1, double numero2)
    {
        return Ok(numero1 - numero2);
    }

    // 5. Multiplicación de 2 números
    [HttpGet("Multiplicacion/{numero1:double}/{numero2:double}")]
    public IActionResult Multiplicacion(double numero1, double numero2)
    {
        return Ok(numero1 * numero2);
    }

    #endregion

    #region Promedio y cuadrado (6 - 8)

    // 6. Promedio de 3 calificaciones
    [HttpGet("Promedio/{calificacion1:double}/{calificacion2:double}/{calificacion3:double}")]
    public IActionResult Promedio(double calificacion1, double calificacion2, double calificacion3)
    {
        return Ok(Math.Round((calificacion1 + calificacion2 + calificacion3) / 3, 2));
    }

    // 7. Cuadrado de un número
    [HttpGet("Cuadrado/{numero:double}")]
    public IActionResult Cuadrado(double numero)
    {
        return Ok(numero * numero);
    }

    // 8. Área del cuadrado
    [HttpGet("AreaCuadrado/{lado:double}")]
    public IActionResult AreaCuadrado(double lado)
    {
        if (lado < 0) return BadRequest("El lado no puede ser negativo.");
        return Ok(lado * lado);
    }

    #endregion

    #region Figuras geométricas (9 - 13)

    // 9. Perímetro del cuadrado
    [HttpGet("PerimetroCuadrado/{lado:double}")]
    public IActionResult PerimetroCuadrado(double lado)
    {
        if (lado < 0) return BadRequest("El lado no puede ser negativo.");
        return Ok(lado * 4);
    }

    // 10. Área del círculo
    [HttpGet("AreaCirculo/{radio:double}")]
    public IActionResult AreaCirculo(double radio)
    {
        if (radio < 0) return BadRequest("El radio no puede ser negativo.");
        return Ok(Math.Round(Math.PI * radio * radio, 2));
    }

    // 11. Perímetro del círculo
    [HttpGet("PerimetroCirculo/{radio:double}")]
    public IActionResult PerimetroCirculo(double radio)
    {
        if (radio < 0) return BadRequest("El radio no puede ser negativo.");
        return Ok(Math.Round(2 * Math.PI * radio, 2));
    }

    // 12. Área del rectángulo
    [HttpGet("AreaRectangulo/{baseRect:double}/{altura:double}")]
    public IActionResult AreaRectangulo(double baseRect, double altura)
    {
        if (baseRect < 0 || altura < 0) return BadRequest("Las medidas no pueden ser negativas.");
        return Ok(baseRect * altura);
    }

    // 13. Área del triángulo
    [HttpGet("AreaTriangulo/{baseTri:double}/{altura:double}")]
    public IActionResult AreaTriangulo(double baseTri, double altura)
    {
        if (baseTri < 0 || altura < 0) return BadRequest("Las medidas no pueden ser negativas.");
        return Ok(0.5 * baseTri * altura);
    }

    #endregion

    #region Porcentaje (14)

    // 14. Porcentaje de una cantidad
    [HttpGet("Porcentaje/{cantidad:double}/{porcentaje:double}")]
    public IActionResult Porcentaje(double cantidad, double porcentaje)
    {
        return Ok(cantidad * porcentaje / 100);
    }

    #endregion

    #region Conversión de monedas (15 - 20)

    // Tipos de cambio base (ajústalos al valor del día)
    private const decimal PesosPorDolar = 17.50m;  // 1 USD = 17.50 MXN
    private const decimal EurosPorDolar = 0.92m;   // 1 USD = 0.92 EUR

    // Método reutilizable para todas las conversiones
    private IActionResult Convertir(decimal cantidad, decimal tasa,
                                    string monedaOrigen, string monedaDestino)
    {
        if (cantidad < 0)
            return BadRequest("La cantidad no puede ser negativa.");

        return Ok(new
        {
            Origen = monedaOrigen,
            Destino = monedaDestino,
            Cantidad = cantidad,
            TipoCambio = Math.Round(tasa, 4),
            Resultado = Math.Round(cantidad * tasa, 2)
        });
    }

    // 15. Dólares a pesos
    [HttpGet("DolarAPeso/{cantidad:decimal}")]
    public IActionResult DolarAPeso(decimal cantidad)
        => Convertir(cantidad, PesosPorDolar, "USD", "MXN");

    // 16. Dólares a euros
    [HttpGet("DolarAEuro/{cantidad:decimal}")]
    public IActionResult DolarAEuro(decimal cantidad)
        => Convertir(cantidad, EurosPorDolar, "USD", "EUR");

    // 17. Pesos a dólares
    [HttpGet("PesoADolar/{cantidad:decimal}")]
    public IActionResult PesoADolar(decimal cantidad)
        => Convertir(cantidad, 1 / PesosPorDolar, "MXN", "USD");

    // 18. Pesos a euros
    [HttpGet("PesoAEuro/{cantidad:decimal}")]
    public IActionResult PesoAEuro(decimal cantidad)
        => Convertir(cantidad, EurosPorDolar / PesosPorDolar, "MXN", "EUR");

    // 19. Euros a pesos
    [HttpGet("EuroAPeso/{cantidad:decimal}")]
    public IActionResult EuroAPeso(decimal cantidad)
        => Convertir(cantidad, PesosPorDolar / EurosPorDolar, "EUR", "MXN");

    // 20. Euros a dólares
    [HttpGet("EuroADolar/{cantidad:decimal}")]
    public IActionResult EuroADolar(decimal cantidad)
        => Convertir(cantidad, 1 / EurosPorDolar, "EUR", "USD");

    #endregion
}