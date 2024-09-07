using Microsoft.AspNetCore.Mvc;

namespace WebApiHumanos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OperacionesController : ControllerBase
    {
        /// <summary>
        /// Realiza una operación matemática entre dos números (POST).
        /// </summary>
        /// <param name="num1">Primer número</param>
        /// <param name="num2">Segundo número</param>
        /// <param name="operation">Operación a realizar (add, subtract, multiply, divide)</param>
        [HttpPost("PostMath")]
        public ActionResult<double> PostMathOperation(double num1, double num2, string operation)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(operation))
                {
                    return BadRequest(new { message = "La operación no puede estar vacía." });
                }

                double result = PerformMathOperation(num1, num2, operation);

                return Ok(result);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
            catch (DivideByZeroException)
            {
                return BadRequest(new { message = "No se puede dividir por cero." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Error interno del servidor.", details = ex.Message });
            }
        }

        /// <summary>
        /// Realiza una operación matemática entre dos números (GET).
        /// </summary>
        /// <param name="num1">Primer número (desde el header)</param>
        /// <param name="num2">Segundo número (desde el header)</param>
        /// <param name="operation">Operación a realizar (add, subtract, multiply, divide)</param>
        [HttpGet("GetMath")]
        public ActionResult<double> GetMathOperation([FromHeader] double num1, [FromHeader] double num2, [FromHeader] string operation)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(operation))
                {
                    return BadRequest(new { message = "La operación no puede estar vacía." });
                }

                double result = PerformMathOperation(num1, num2, operation);

                return Ok(result);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
            catch (DivideByZeroException)
            {
                return BadRequest(new { message = "No se puede dividir por cero." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Error interno del servidor.", details = ex.Message });
            }
        }

  
        private double PerformMathOperation(double num1, double num2, string operation)
        {
            return operation.ToLower() switch
            {
                "add" => num1 + num2,
                "subtract" => num1 - num2,
                "multiply" => num1 * num2,
                "divide" => num2 != 0 ? num1 / num2 : throw new DivideByZeroException(),
                _ => throw new ArgumentException("Operación no válida. Las operaciones permitidas son: add, subtract, multiply, divide.")
            };
        }
    }
}
