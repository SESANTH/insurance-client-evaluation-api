using InsuranceClientEvaluation.Models;
using InsuranceClientEvaluation.Services;
using Microsoft.AspNetCore.Mvc;

namespace InsuranceClientEvaluation.Controllers
{
    [ApiController]
    [Route("api/client-evaluation")]
    public class ClientEvaluationController : ControllerBase
    {
        private readonly ClientEvaluator _evaluator;

        public ClientEvaluationController(ClientEvaluator evaluator)
        {
            _evaluator = evaluator;
        }

        [HttpPost("evaluate")]
        public ActionResult<ClientEvaluationResult> EvaluateClient([FromBody] Person person)
        {
            var result = _evaluator.Evaluate(person);
            return Ok(result);
        }

        [HttpPost("evaluate-batch")]
        public ActionResult<IEnumerable<ClientEvaluationResult>> EvaluateClients(
            [FromBody] List<Person> persons)
        {
            var results = persons.Select(p => _evaluator.Evaluate(p));
            return Ok(results);
        }

    }
}
