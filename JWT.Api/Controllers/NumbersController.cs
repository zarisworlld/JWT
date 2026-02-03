using Microsoft.AspNetCore.Mvc;

namespace JWT.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class NumbersController : ControllerBase
    {
        private readonly string binaryFile = "numbers.bin";

        private static Random rnd = new Random();
        [HttpGet("sum-random")]
        public ActionResult<sumres> SumRandomNumbers()
        {
            const int count = 1_000_000;
            double sum = 0;

            for (int i = 0; i < count; i++)
            {
                float value = (float)rnd.NextDouble(); 
                sum += Math.Pow(value, 4);
            }

            return Ok(new SumResponse { Sum = sum });
        }

        [HttpGet("sum-binary")]
        public ActionResult<SumResponse> SumBinaryNumbers()
        {
            if (!System.IO.File.Exists(binaryFile))
                return NotFound("Binary file not found");

            var bytes = System.IO.File.ReadAllBytes(binaryFile);
            int floatCount = bytes.Length / sizeof(float);

            double sum = 0;
            for (int i = 0; i < floatCount; i++)
            {
                float value = BitConverter.ToSingle(bytes, i * sizeof(float));
                sum += value;
            }

            return Ok(new SumResponse { Sum = sum });
        }
    }

}
